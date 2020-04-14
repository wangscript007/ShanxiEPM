﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using hc.Plat.Common.Extend;

namespace CreateModelTools
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public string ConnectionString
        {
            get
            {
                return tbConnectionString.Text;
            }
        }
        /// <summary>
        /// 连接数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            BindTable();
        }
        /// <summary>
        /// 绑定列表
        /// </summary>
        /// <param name="isMap"></param>
        private void BindTable(bool isMap = true)
        {
            IList<string> tableNames = new List<string>();

            try
            {
                tableNames = DBHelper.GetTableName(ConnectionString);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            List<TableModel> list = new List<TableModel>();
            foreach (var item in tableNames)
            {
                TableModel m = new TableModel();
                m.IsMap = isMap;
                m.Name = item;
                list.Add(m);
            }
            gvTables.DataSource = list.OrderBy(i => i.Name).ToList();
        }

        /// <summary>
        /// 要过滤的列
        /// </summary>
        public List<string> FilterColumns
        {
            get
            {
                List<string> list = new List<string>() { "RecordTime", "Id", "IsDelete", "DeleteTime", "CreateUserId", "CreateUserName", "CreateTime", "OperateUserId", "OperateUserName", "OperateTime" };

                return list;
            }
        }
        /// <summary>
        /// 生成文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                List<TableModel> list = new List<TableModel>();
                foreach (DataGridViewRow row in gvTables.Rows)
                {
                    TableModel item = (TableModel)row.DataBoundItem;
                    if (item.IsMap)
                    {
                        list.Add(item);
                    }
                }
                string strNamespace = tbNamespace.Text;
                string savePath = tbSavePath.Text;
                string parentClass = tbParentClass.Text;
                if (!string.IsNullOrEmpty(parentClass))
                {
                    parentClass = ":" + parentClass;
                }
                //生成代码
                foreach (var item in list)
                {
                    //获取表的所有列
                    var columns = DBHelper.GetColumn(ConnectionString, item.Name);
                    StringBuilder strModel = new StringBuilder();
                    strModel.AppendLine("//------------------------------------------------------------------------------");
                    strModel.AppendLine("// <auto-generated>");
                    strModel.AppendLine("// 此代码由华春网络代码生成工具生成");
                    strModel.AppendLine("// version 1.0");
                    strModel.AppendLine("// author hanshiwei 2017.07.24");
                    strModel.AppendLine("// auto create time:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    strModel.AppendLine("// </auto-generated>");
                    strModel.AppendLine("//------------------------------------------------------------------------------");


                    strModel.AppendLine("using System;");
                    strModel.AppendLine("using System.Collections.Generic;");
                    strModel.AppendLine("using hc.epm.DataModel.BaseCore;");
                    //主体
                    if (!string.IsNullOrEmpty(strNamespace))
                    {
                        strModel.AppendLine("namespace " + strNamespace);
                        strModel.AppendLine("{ ");
                    }
                    strModel.AppendLine(getTab() + "///<summary>");
                    strModel.AppendLine(getTab() + "///" + columns.FirstOrDefault().TableName + ":" + columns.FirstOrDefault().TableDescription);
                    strModel.AppendLine(getTab() + "///</summary>");
                    strModel.AppendLine(getTab() + " public  class  " + item.Name + parentClass);
                    strModel.AppendLine(getTab() + "{ ");
                    //循环列
                    foreach (var column in columns)
                    {
                        //过滤列
                        if (FilterColumns.Contains(column.ColumnName))
                        {
                            continue;
                        }
                        var property = getStringProperty(column);
                        strModel.AppendLine(property);
                    }

                    strModel.AppendLine(getTab() + "}");

                    if (!string.IsNullOrEmpty(strNamespace))
                    {
                        strModel.AppendLine("}");
                    }
                    //输出文件
                    StreamWriter sw = null;
                    try
                    {
                        string path = savePath + "\\Model";
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        sw = File.CreateText(path + "\\" + item.Name + ".cs");
                        sw.WriteLine(strModel);
                        sw.Flush();
                    }
                    finally
                    {
                        if (sw != null)
                            sw.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            MessageBox.Show("生成成功");
        }
        /// <summary>
        /// 获取属性
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        private string getStringProperty(TableColumn column)
        {
            string type = getColumnType(column.SType);
            StringBuilder strProperty = new StringBuilder();
            strProperty.AppendLine(getTab(2) + "///<summary>");
            strProperty.AppendLine(getTab(2) + "///" + column.Remark);
            strProperty.AppendLine(getTab(2) + "///</summary>");
            strProperty.AppendLine(getTab(2) + "public " + type + ((column.IsNULLS && type != "string") ? "?" : "") + " " + column.ColumnName + " { get; set; }");
            return strProperty.ToString();
        }
        /// <summary>
        /// 获取制表符
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        private string getTab(int count = 1)
        {
            string result = "";
            for (int i = 0; i < count; i++)
            {
                result += "\t";
            }
            return result;
        }
        /// <summary>
        /// 获取数据库列对应的c#类型
        /// </summary>
        /// <param name="dataColumnType"></param>
        /// <returns></returns>
        private string getColumnType(string dataColumnType)
        {
            string colType = "";

            switch (dataColumnType.ToLower())
            {
                case "int":
                    colType = "int";
                    break;
                case "bigint":
                    colType = "long";
                    break;
                case "bool":
                case "bit":
                    colType = "bool";
                    break;
                case "nchar":
                case "ntext":
                case "nvarchar":
                case "char":
                case "text":
                case "varchar":
                case "string":
                    colType = "string";
                    break;
                case "datetime":
                    colType = "DateTime";
                    break;
                case "decimal":
                case "double":
                case "float":
                    colType = "decimal";
                    break;
                default:
                    break;

            }
            return colType;
        }

        /// <summary>
        /// 自动创建dbset
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateDBSet_Click(object sender, EventArgs e)
        {
            List<TableModel> list = new List<TableModel>();
            foreach (DataGridViewRow row in gvTables.Rows)
            {
                TableModel item = (TableModel)row.DataBoundItem;
                if (item.IsMap)
                {
                    //获取表注释
                    item.Description = DBHelper.GetColumn(ConnectionString, item.Name).FirstOrDefault().TableDescription;
                    list.Add(item);
                }
            }
            StringBuilder strDBSet = new StringBuilder();
            foreach (var item in list)
            {
                strDBSet.AppendLine("///<summary>");
                strDBSet.AppendLine("///" + item.Description);
                strDBSet.AppendLine("///</summary>");
                strDBSet.AppendLine("public  DbSet<" + item.Name + "> " + item.Name + " { get; set; }");
            }

            ShowText m = new ShowText();
            m.SetTextContent(strDBSet.ToString());
            m.Show();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string text = btnSelect.Text;
            if (text == "None")
            {
                BindTable(false);
                btnSelect.Text = "All";
            }
            else
            {
                BindTable();
                btnSelect.Text = "None";
            }
        }

        private void btnCreateServerType_Click(object sender, EventArgs e)
        {
            List<TableModel> list = new List<TableModel>();
            foreach (DataGridViewRow row in gvTables.Rows)
            {
                TableModel item = (TableModel)row.DataBoundItem;
                if (item.IsMap)
                {
                    list.Add(item);
                }
            }
            StringBuilder strServerType = new StringBuilder();
            foreach (var item in list)
            {

                strServerType.AppendLine("[ServiceKnownType(typeof(" + item.Name + "))]");
            }

            ShowText m = new ShowText();
            m.SetTextContent(strServerType.ToString());
            m.Show();
        }
        /// <summary>
        /// 创建service
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateService_Click(object sender, EventArgs e)
        {
            List<TableModel> list = new List<TableModel>();
            string db = tbDataOperate.Text;
            foreach (DataGridViewRow row in gvTables.Rows)
            {
                TableModel item = (TableModel)row.DataBoundItem;
                if (item.IsMap)
                {
                    //获取表注释
                    item.Description = DBHelper.GetColumn(ConnectionString, item.Name).FirstOrDefault().TableDescription;
                    list.Add(item);
                }
            }

            StringBuilder strClass = new StringBuilder();
            var actionList = Enum<Operate>.AsEnumerable();
            foreach (var item in list)
            {
                //class
                foreach (var action in actionList)
                {
                    strClass.AppendLine("///<summary>");
                    strClass.AppendLine("///" + DBHelper.ActionText[action] + ":" + item.Description);
                    strClass.AppendLine("///</summary>");
                    string actionName = action.GetText().Replace("{Model}", item.NoPrefixName);
                    string data = "result.Data = -1;";
                    switch (action)
                    {
                        case Operate.Add:
                            strClass.AppendLine(" /// <param name=\"model\">要添加的model</param>");
                            strClass.AppendLine(" /// <returns>受影响的行数</returns>");

                            strClass.AppendLine("public  Result<int> " + actionName + "(" + item.Name + " model)");
                            strClass.AppendLine("{");
                            strClass.AppendLine("Result<int> result = new Result<int>();");
                            strClass.AppendLine("try");
                            strClass.AppendLine("{");
                            strClass.AppendLine("var rows = " + db + "<" + item.Name + ">.Get().Add(model);");
                            strClass.AppendLine(" result.Data = rows;");
                            strClass.AppendLine("result.Flag = EResultFlag.Success;");
                            strClass.AppendLine(" WriteLog(AdminModule." + item.NoPrefixName + ".GetText(), SystemRight.Add.GetText(), \"新增" + item.Description + ": \" + model.Id );");
                            break;
                        case Operate.Edit:
                            strClass.AppendLine(" /// <param name=\"model\">要修改的model</param>");
                            strClass.AppendLine(" /// <returns>受影响的行数</returns>");

                            strClass.AppendLine("public  Result<int> " + actionName + "(" + item.Name + " model)");
                            strClass.AppendLine("{");
                            strClass.AppendLine("Result<int> result = new Result<int>();");
                            strClass.AppendLine("try");
                            strClass.AppendLine("{");
                            strClass.AppendLine("var rows = " + db + "<" + item.Name + ">.Get().Update(model);");
                            strClass.AppendLine("result.Data = rows;");
                            strClass.AppendLine("result.Flag = EResultFlag.Success;");
                            strClass.AppendLine(" WriteLog(AdminModule." + item.NoPrefixName + ".GetText(), SystemRight.Modify.GetText(), \"修改" + item.Description + ": \" + model.Id );");

                            break;
                        case Operate.Delete:
                            strClass.AppendLine(" /// <param name=\"ids\">要删除的Id集合</param>");
                            strClass.AppendLine(" /// <returns>受影响的行数</returns>");

                            strClass.AppendLine("public  Result<int> " + actionName + "(List<long> ids)");
                            strClass.AppendLine("{");
                            strClass.AppendLine("Result<int> result = new Result<int>();");
                            strClass.AppendLine("try");
                            strClass.AppendLine("{");
                            strClass.AppendLine("var models = " + db + "<" + item.Name + ">.Get().GetList(i => ids.Contains(i.Id)).ToList();");
                            strClass.AppendLine("var rows = " + db + "<" + item.Name + ">.Get().DeleteRange(models);");
                            strClass.AppendLine("result.Data = rows;");
                            strClass.AppendLine("result.Flag = EResultFlag.Success;");
                            strClass.AppendLine(" WriteLog(AdminModule." + item.NoPrefixName + ".GetText(), SystemRight.Delete.GetText(), \"批量删除" + item.Description + ": \" + rows );");

                            break;
                        case Operate.List:
                            strClass.AppendLine(" /// <param name=\"qc\">查询条件</param>");
                            strClass.AppendLine(" /// <returns>符合条件的数据集合</returns>");

                            strClass.AppendLine("public Result<List<" + item.Name + ">> " + actionName + "(QueryCondition qc)");
                            strClass.AppendLine("{");
                            strClass.AppendLine(" qc = AddDefault(qc);");
                            strClass.AppendLine(" Result<List<" + item.Name + ">> result = new Result<List<" + item.Name + ">>();");
                            strClass.AppendLine("try");
                            strClass.AppendLine("{");
                            strClass.AppendLine("result = hc.Plat.Common.Service.DataOperate.QueryListSimple<" + item.Name + ">(context, qc);");
                            data = "result.Data = null;";
                            break;
                        case Operate.Detail:
                            strClass.AppendLine(" /// <param name=\"id\">数据Id</param>");
                            strClass.AppendLine(" /// <returns>数据详情model</returns>");

                            strClass.AppendLine("public Result<" + item.Name + "> " + actionName + "(long id)");
                            strClass.AppendLine("{");
                            strClass.AppendLine(" Result<" + item.Name + "> result = new Result<" + item.Name + ">();");
                            strClass.AppendLine("try");
                            strClass.AppendLine("{");
                            strClass.AppendLine(" var model = " + db + "<" + item.Name + ">.Get().GetModel(id);");
                            strClass.AppendLine("result.Data = model;");
                            strClass.AppendLine("result.Flag = EResultFlag.Success;");
                            data = "result.Data = null;";
                            break;
                        default:
                            break;
                    }
                    strClass.AppendLine(" }");
                    strClass.AppendLine("catch (Exception ex)");
                    strClass.AppendLine("{");
                    strClass.AppendLine(data);
                    strClass.AppendLine("result.Flag = EResultFlag.Failure;");
                    strClass.AppendLine("result.Exception = new ExceptionEx(ex, \"" + actionName + "\");");
                    strClass.AppendLine("}");
                    strClass.AppendLine("return result;");
                    strClass.AppendLine("}");

                }

            }

            ShowText m = new ShowText();
            m.SetTextContent(strClass.ToString() + "");
            m.Show();
        }
        /// <summary>
        /// 创建接口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateInterface_Click(object sender, EventArgs e)
        {
            List<TableModel> list = new List<TableModel>();
            string db = tbDataOperate.Text;
            foreach (DataGridViewRow row in gvTables.Rows)
            {
                TableModel item = (TableModel)row.DataBoundItem;
                if (item.IsMap)
                {
                    //获取表注释
                    item.Description = DBHelper.GetColumn(ConnectionString, item.Name).FirstOrDefault().TableDescription;
                    list.Add(item);
                }
            }
            StringBuilder strInterface = new StringBuilder();
            var actionList = Enum<Operate>.AsEnumerable();
            foreach (var item in list)
            {
                //interface
                foreach (var action in actionList)
                {
                    string actionName = action.GetText().Replace("{Model}", item.NoPrefixName);
                    strInterface.AppendLine("///<summary>");
                    strInterface.AppendLine("///" + DBHelper.ActionText[action] + ":" + item.Description);
                    strInterface.AppendLine("///</summary>");
                  
                    switch (action)
                    {
                        case Operate.Add:
                            strInterface.AppendLine(" ///<param name=\"model\">要添加的model</param>");
                            strInterface.AppendLine(" ///<returns>受影响的行数</returns>");
                            strInterface.AppendLine("[OperationContract]");
                            strInterface.AppendLine(" Result<int> " + actionName + "(" + item.Name + " model);");
                            break;
                        case Operate.Edit:
                            strInterface.AppendLine(" ///<param name=\"model\">要修改的model</param>");
                            strInterface.AppendLine(" ///<returns>受影响的行数</returns>");
                            strInterface.AppendLine("[OperationContract]");
                            strInterface.AppendLine(" Result<int> " + actionName + "(" + item.Name + " model);");
                            break;
                        case Operate.Delete:
                            strInterface.AppendLine(" ///<param name=\"ids\">要删除的Id集合</param>");
                            strInterface.AppendLine(" ///<returns>受影响的行数</returns>");
                            strInterface.AppendLine("[OperationContract]");
                            strInterface.AppendLine(" Result<int> " + actionName + "(List<long> ids);");
                            break;
                        case Operate.List:
                            strInterface.AppendLine(" ///<param name=\"qc\">查询条件</param>");
                            strInterface.AppendLine(" ///<returns>符合条件的数据集合</returns>");
                            strInterface.AppendLine("[OperationContract]");
                            strInterface.AppendLine(" Result<List<" + item.Name + ">> " + actionName + "(QueryCondition qc);");
                            break;
                        case Operate.Detail:
                            strInterface.AppendLine(" ///<param name=\"id\">数据Id</param>");
                            strInterface.AppendLine(" ///<returns>数据详情model</returns>");
                            strInterface.AppendLine("[OperationContract]");
                            strInterface.AppendLine(" Result<" + item.Name + "> " + actionName + "(long id);");
                            break;
                        default:
                            break;
                    }

                }
            }
            strInterface.AppendLine("");
            strInterface.AppendLine("");
            strInterface.AppendLine("");
            foreach (var item in list)
            {
                //proxy
                foreach (var action in actionList)
                {
                    string actionName = action.GetText().Replace("{Model}", item.NoPrefixName);
                    strInterface.AppendLine("///<summary>");
                    strInterface.AppendLine("///" + DBHelper.ActionText[action] + ":" + item.Description);
                    strInterface.AppendLine("///</summary>");
                    switch (action)
                    {
                        case Operate.Add:
                            strInterface.AppendLine(" ///<param name=\"model\">要添加的model</param>");
                            strInterface.AppendLine(" ///<returns>受影响的行数</returns>");

                            strInterface.AppendLine(" public Result<int> " + actionName + "(" + item.Name + " model)");
                            strInterface.AppendLine(" {");
                            strInterface.AppendLine("  return base.Channel." + actionName + "(model);");
                            strInterface.AppendLine(" }");
                            break;
                        case Operate.Edit:
                            strInterface.AppendLine(" ///<param name=\"model\">要修改的model</param>");
                            strInterface.AppendLine(" ///<returns>受影响的行数</returns>");

                            strInterface.AppendLine(" public Result<int> " + actionName + "(" + item.Name + " model)");
                            strInterface.AppendLine(" {");
                            strInterface.AppendLine("  return base.Channel." + actionName + "(model);");
                            strInterface.AppendLine(" }");
                            break;
                        case Operate.Delete:
                            strInterface.AppendLine(" ///<param name=\"ids\">要删除的Id集合</param>");
                            strInterface.AppendLine(" ///<returns>受影响的行数</returns>");

                            strInterface.AppendLine(" public Result<int> " + actionName + "(List<long> ids)");
                            strInterface.AppendLine(" {");
                            strInterface.AppendLine("  return base.Channel." + actionName + "(ids);");
                            strInterface.AppendLine(" }");
                            break;
                        case Operate.List:
                            strInterface.AppendLine(" ///<param name=\"qc\">查询条件</param>");
                            strInterface.AppendLine(" ///<returns>符合条件的数据集合</returns>");

                            strInterface.AppendLine(" public Result<List<" + item.Name + ">> " + actionName + "(QueryCondition qc)");
                            strInterface.AppendLine(" {");
                            strInterface.AppendLine("  return base.Channel." + actionName + "(qc);");
                            strInterface.AppendLine(" }");
                            break;
                        case Operate.Detail:
                            strInterface.AppendLine(" ///<param name=\"id\">数据Id</param>");
                            strInterface.AppendLine(" ///<returns>数据详情model</returns>");

                            strInterface.AppendLine(" public Result<" + item.Name + "> " + actionName + "(long id)");
                            strInterface.AppendLine(" {");
                            strInterface.AppendLine("  return base.Channel." + actionName + "(id);");
                            strInterface.AppendLine(" }");
                            break;
                        default:
                            break;
                    }

                }

            }
            ShowText m = new ShowText();
            m.SetTextContent(strInterface.ToString() + "");
            m.Show();
        }
    }
}
