using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
namespace LocalControl
{
    public partial class TPBindView : Form
    {
        private DataTable dtData;
        private DataSet dst;
        private int id_flag = 0;
        private int min_id_flag = 0;
        private System.Windows.Forms.ToolBarButton toolBarButton6;
        private System.Windows.Forms.Button button1;
        private int max_id_flag = 0;
        private string conn_str = ConfigurationManager.AppSettings["sql_connstr"].Trim();
        ClassLocalControl _clc = null;

        public TPBindView()
        {
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			_clc = new ClassLocalControl();
			_clc.ConnectString = this.conn_str;
			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

        private void TPBindView_Load(object sender, EventArgs e)
        {
            

        }

        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            string buttonTxt = e.Button.Text;//删除一个托盘绑定 删除所有托盘绑定
            switch (buttonTxt)
            {
                case "查询":
                    //					LocalCheck();//以前的查询
                    LoadData();
                    SetDataGrid();
                    break;
                case "删除一个托盘绑定":
                    if (DialogResult.Yes == MessageBox.Show("此操作将删除托盘的绑定数据，请确认要执行吗？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        if (DialogResult.Yes == MessageBox.Show("此操作将删除托盘的绑定数据，请再次确认一定要执行吗？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                        {
                            string tpNo = txt_tpNo.Text.Trim();
                            DelTPBind(tpNo);
                        }
                    }
                    break;
                case "删除所有托盘绑定":
                    if (DialogResult.Yes == MessageBox.Show("此操作将删除所有的绑定数据，请确认要执行吗？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        if (DialogResult.Yes == MessageBox.Show("此操作将删除所有的绑定数据，请再次确认一定要执行吗？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                        {
                            DataBase db = new DataBase();
                            int count = db.RunSelectCountSQL("select count(*) from T_txBind");
                            db.RunDelOrInsertOrUppdateSQL("delete from T_txBind");
                            db.RunDelOrInsertOrUppdateSQL("update tb_Bind set l_mark=0");
                            MessageBox.Show("已经删除托盘绑定数据" + count.ToString() + "条！");
                        }
                    }
                    break;
                case "首条":
                    string cmdfirst = string.Format("select distinct(l_tuopanCode) from t_txbind where id_flag = {0}", min_id_flag);
                    this.LoadPosition(cmdfirst);
                    id_flag = min_id_flag;
                    break;
                case "上一条":
                    if (id_flag > min_id_flag)
                    {
                        string cmdStr = string.Format("select id_flag,boxcode,bottlecode from tb_bind where id_flag = {0}", id_flag - 1);

                        this.LoadPosition(cmdStr);
                        id_flag -= 1;
                    }
                    break;
                case "下一条":
                    if (id_flag < max_id_flag)
                    {
                        string cmdlastStr = string.Format("select id_flag,boxcode,bottlecode from tb_bind where id_flag = {0}", id_flag + 1);
                        this.LoadPosition(cmdlastStr);
                        id_flag += 1;
                    }
                    break;
                case "最后":
                    if (id_flag < max_id_flag)
                    {
                        string cmdlastStr = string.Format("select id_flag,boxcode,bottlecode from tb_bind where id_flag = {0}", max_id_flag);
                        this.LoadPosition(cmdlastStr);
                        id_flag = max_id_flag;
                    }
                    break;
                case "退出":
                    this.Close();
                    break;
                default:
                    break;
            }
        }

        private static void DelTPBind(string tpNo)
        {
            DataBase db = new DataBase();
            if (tpNo.Length == 7 && tpNo.Substring(0, 1).ToLower() == "t")
            {
                string sCountCmd = "select count(L_BoxCode) from t_txbind where L_TuoPanCode = '" + tpNo + "'";
                int count = db.RunSelectCountSQL(sCountCmd);
                //如果该托盘号绑定过
                if (count > 0)
                {
                    //找出该托盘号绑定的所有箱号
                    DataSet dst = new DataSet();
                    dst = db.RunDataSetSQL("select L_BoxCode from t_txbind where L_TuoPanCode = '" + tpNo + "'", "t_txbind");
                    string strConnect = ConfigurationManager.AppSettings["sql_connstr"];     //连接数据库字符串
                    using (SqlConnection connection = new SqlConnection(strConnect))
                    {
                        connection.Open();
                        //修改操作
                        SqlCommand cmdUpdate = new SqlCommand(null, connection);
                        cmdUpdate.CommandTimeout = 1200000;
                        cmdUpdate.CommandType = CommandType.Text;
                        cmdUpdate.CommandText = "update tb_Bind set l_mark=0 where boxcode = @boxcode";
                        cmdUpdate.Parameters.Add("@boxcode", SqlDbType.VarChar, 50);
                        cmdUpdate.Prepare();
                        //删除操作
                        SqlCommand delCommand = new SqlCommand(null, connection);
                        delCommand.CommandTimeout = 1200000;
                        delCommand.CommandType = CommandType.Text;
                        delCommand.CommandText = "delete from t_txbind where L_BoxCode = @L_BoxCode";
                        delCommand.Parameters.Add("@L_BoxCode", SqlDbType.VarChar, 50);
                        delCommand.Prepare();

                        //执行绑定操作
                        for (int i = 0; i < count; i++)
                        {
                            using (SqlTransaction myTrans = connection.BeginTransaction())
                            {
                                cmdUpdate.Transaction = myTrans;
                                delCommand.Transaction = myTrans;
                                string boxcode = dst.Tables["t_txbind"].Rows[i]["L_BoxCode"].ToString();
                                cmdUpdate.Parameters["@boxcode"].Value = boxcode; //
                                delCommand.Parameters["@L_BoxCode"].Value = boxcode;
                                try
                                {
                                    cmdUpdate.ExecuteNonQuery();
                                    delCommand.ExecuteNonQuery();
                                    myTrans.Commit();

                                    //ScanAlarm();
                                }
                                catch (Exception ex)
                                {
                                    myTrans.Rollback();    //回滚
                                    connection.Close();
                                    connection.Dispose();
                                    MessageBox.Show("托盘解除绑定过程发生错误，请重新该操作！" + ex.Message);
                                }
                            }
                        }
                    }

                    string delCmd = "delete from t_txbind where L_TuoPanCode = '" + tpNo + "'";
                    db.RunDelOrInsertOrUppdateSQL(delCmd);
                    MessageBox.Show("已删除绑定数据：" + count.ToString() + "条。");
                }
                else
                {
                    MessageBox.Show("该托盘号没有绑定数据！");
                }
            }
            else
            {
                MessageBox.Show("请输入正确的托盘号");
            }
        }

        #region 查询
        //private void LocalCheck()
        //{
        //    try
        //    {
        //        if (this.txt_tpNo.Text.Trim().Length == 0)
        //        {
        //            DataBase db = new DataBase();
        //            string cmdString = string.Format("select distinct(l_tuopanCode) from t_txbind");
        //            dst = new DataSet();
        //            //根据查询条件重新填充DataSet dst
        //            dst.Clear();
        //            dst = db.RunDataSetSQL(cmdString, "t_txbind");
        //            dgdList.DataSource = dst.Tables["t_txbind"];
        //            dtData = dst.Tables["t_txbind"];
        //        }
        //        else
        //        {
        //            DataBase db = new DataBase();
        //            string cmdString = string.Format("select l_tuopanCode,L_BoxCode from t_txbind where l_tuopanCode = '{0}'", this.txt_tpNo.Text.Trim());
        //            dst = new DataSet();
        //            //根据查询条件重新填充DataSet dst
        //            dst.Clear();
        //            dst = db.RunDataSetSQL(cmdString, "t_txbind");
        //            dgdList.DataSource = dst.Tables["t_txbind"];
        //            dtData = dst.Tables["t_txbind"];
        //        }

        //    }
        //    catch (Exception es)
        //    {
        //        MessageBox.Show(es.ToString());
        //    }
        //}
        #endregion

        #region 将信息加入列表框
        private void AddToListBox(string bCode)
        {
            //			try
            //			{
            //				string[] strArr = bCode.Split(new char[]{','});
            //				for(int i=0;i<strArr.Length;i++)
            //				{
            //					if(strArr[i].Trim().Length>0)
            //					{
            //						listBox1.Items.Add(strArr[i]);
            //					}
            //				}
            //			}
            //			catch
            //			{
            //			}
        }
        #endregion

        #region ExecuteTable
        private DataTable ExecuteTable(string command, string tableName)
        {
            DataTable result = null;
            try
            {
                DataSet ds = _clc.ExecuteDataSet(command, tableName);
                result = ds.Tables[tableName];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return result;
        }
        #endregion

        private void LoadPosition(string positionStr)
        {
            DataBase db = new DataBase();
            dst = new DataSet();
            dst.Clear();
            dst = db.RunDataSetSQL(positionStr, "t_txbind");
            dgdList.DataSource = dst.Tables["t_txbind"];
            dtData = dst.Tables["t_txbind"];
            SetDataGrid();
        }

        #region LoadData()

        public void LoadData()
        {
            try
            {
                if (this.txt_tpNo.Text.Trim().Length == 0)
                {
                    DataBase db = new DataBase();
                    string cmdString1 = "truncate table t_txbindTemp";
                    string cmdString2 = "insert into t_txbindTemp select distinct l_tuopancode from t_txbind";
                    string cmdString3 = "select l_tuopancode,id_flag from t_txbindTemp ";
                    dst = new DataSet();
                    //根据查询条件重新填充DataSet dst
                    dst.Clear();
                    db.RunDelOrInsertOrUppdateSQL(cmdString1);
                    db.RunDelOrInsertOrUppdateSQL(cmdString2);
                    dst = db.RunDataSetSQL(cmdString3, "t_txbindTemp");
                    dgdList.DataSource = dst.Tables["t_txbindTemp"];
                    dtData = dst.Tables["t_txbindTemp"];
                }
                else
                {
                    DataBase db = new DataBase();
                    string cmdString = string.Format("select l_tuopanCode,L_BoxCode from t_txbind where l_tuopanCode = '{0}'", this.txt_tpNo.Text.Trim());
                    dst = new DataSet();
                    //根据查询条件重新填充DataSet dst
                    dst.Clear();
                    dst = db.RunDataSetSQL(cmdString, "t_txbind");
                    dgdList.DataSource = dst.Tables["t_txbind"];
                    dtData = dst.Tables["t_txbind"];
                }

            }
            catch (Exception es)
            {
                MessageBox.Show(es.ToString());
            }

        }
        #endregion

        #region SetDataGrid()
        public void SetDataGrid()
        {
            //			LoadData();
            //定义一个DataGrid表样式
            try
            {
                DataGridTableStyle ts = new DataGridTableStyle();
                string[] HeadText = new string[] { "托盘号","箱号"};
                int numCols = dtData.Columns.Count + 0;
                DataGridTextBoxColumn aCol;

                for (int i = 0; i < numCols; i++)
                {
                    aCol = new DataGridTextBoxColumn();
                    aCol.MappingName = dtData.Columns[i].ColumnName;
                    aCol.HeaderText = HeadText[i].ToString();
                    aCol.NullText = "";
                    aCol.ReadOnly = true;
                    switch (i)
                    {
                        case 0:
                            aCol.Width = 150;

                            break;
                        case 1:
                            aCol.Width = 120;

                            break;
                    }
                    ts.GridColumnStyles.Add(aCol);
                }
                ts.AlternatingBackColor = Color.Black;
                ts.BackColor = Color.Black;
                ts.ForeColor = Color.Lime;
                ts.AllowSorting = false;
                ts.MappingName = dtData.TableName;
                dgdList.TableStyles.Clear();
                dgdList.TableStyles.Add(ts);
                DataView dv = dtData.DefaultView;
                dv.AllowNew = false;
                dv.AllowDelete = false;
                dgdList.DataSource = dv;
            }
            catch (Exception es)
            {
                MessageBox.Show("设置数据显示格式时出错！" + es.ToString());
            }
        }
        #endregion
       
       
    }
}
