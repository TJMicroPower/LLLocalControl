using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Threading;
using FileExAndIm;
using System.Data;
using FileUpAndDown;
using System.Data.SqlClient;
using System.Diagnostics;
namespace LocalControl
{
	/// <summary>
	/// FrmDataExportAndUp 的摘要说明。
	/// </summary>
	public class FrmDataExportAndUp : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.ToolBarButton toolBarButton2;
		private System.Windows.Forms.ToolBarButton toolBarButton3;
		private System.Windows.Forms.ToolBarButton toolBarButton4;
        
		private string _fPath = ConfigurationManager.AppSettings["fpath"];
        private int _countPerFile = int.Parse(ConfigurationManager.AppSettings["countperfile"].Trim());
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ToolBarButton toolBarButton5;
		private System.Windows.Forms.ToolBarButton toolBarButton6;
		private System.Windows.Forms.ToolBarButton toolBarButton7;
        private System.Windows.Forms.Button button1;
		private System.ComponentModel.IContainer components;
        
		public FrmDataExportAndUp()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDataExportAndUp));
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton4 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton5 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton6 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton7 = new System.Windows.Forms.ToolBarButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolBar1
            // 
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.toolBarButton1,
            this.toolBarButton2,
            this.toolBarButton3,
            this.toolBarButton4,
            this.toolBarButton5,
            this.toolBarButton6,
            this.toolBarButton7});
            this.toolBar1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.imageList1;
            this.toolBar1.Location = new System.Drawing.Point(0, 24);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(952, 41);
            this.toolBar1.TabIndex = 0;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.ImageIndex = 11;
            this.toolBarButton1.Name = "toolBarButton1";
            this.toolBarButton1.Text = "数据导出";
            // 
            // toolBarButton2
            // 
            this.toolBarButton2.Name = "toolBarButton2";
            this.toolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // toolBarButton3
            // 
            this.toolBarButton3.Name = "toolBarButton3";
            this.toolBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // toolBarButton4
            // 
            this.toolBarButton4.ImageIndex = 16;
            this.toolBarButton4.Name = "toolBarButton4";
            this.toolBarButton4.Text = "数据上传";
            // 
            // toolBarButton5
            // 
            this.toolBarButton5.Name = "toolBarButton5";
            this.toolBarButton5.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // toolBarButton6
            // 
            this.toolBarButton6.Name = "toolBarButton6";
            this.toolBarButton6.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // toolBarButton7
            // 
            this.toolBarButton7.ImageIndex = 10;
            this.toolBarButton7.Name = "toolBarButton7";
            this.toolBarButton7.Text = "退出";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            this.imageList1.Images.SetKeyName(9, "");
            this.imageList1.Images.SetKeyName(10, "");
            this.imageList1.Images.SetKeyName(11, "");
            this.imageList1.Images.SetKeyName(12, "");
            this.imageList1.Images.SetKeyName(13, "");
            this.imageList1.Images.SetKeyName(14, "");
            this.imageList1.Images.SetKeyName(15, "");
            this.imageList1.Images.SetKeyName(16, "");
            this.imageList1.Images.SetKeyName(17, "");
            this.imageList1.Images.SetKeyName(18, "");
            this.imageList1.Images.SetKeyName(19, "");
            this.imageList1.Images.SetKeyName(20, "");
            this.imageList1.Images.SetKeyName(21, "");
            this.imageList1.Images.SetKeyName(22, "");
            this.imageList1.Images.SetKeyName(23, "");
            this.imageList1.Images.SetKeyName(24, "");
            this.imageList1.Images.SetKeyName(25, "");
            this.imageList1.Images.SetKeyName(26, "");
            this.imageList1.Images.SetKeyName(27, "");
            this.imageList1.Images.SetKeyName(28, "");
            this.imageList1.Images.SetKeyName(29, "");
            this.imageList1.Images.SetKeyName(30, "");
            this.imageList1.Images.SetKeyName(31, "");
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 134);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(960, 22);
            this.statusBar1.SizingGrip = false;
            this.statusBar1.TabIndex = 1;
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Width = 960;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Teal;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(960, 23);
            this.label1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.DarkGreen;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.ImageIndex = 8;
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point(0, 72);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(856, 40);
            this.button1.TabIndex = 14;
            this.button1.Text = "    注：请注意提示，是否有专供酒导出，如果有，则选是，无则选否。";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmDataExportAndUp
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(960, 156);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.toolBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDataExportAndUp";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "数据导出并上传";
            this.Load += new System.EventHandler(this.FrmDataExportAndUp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region 初始化连接字符串

		private void FrmDataExportAndUp_Load(object sender, System.EventArgs e)
		{
			ClassDataExportAndUpload._connstr = ConfigurationManager.AppSettings["sql_connstr"];
            
		}
		#endregion

		#region 操作入口

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			string buttonTxt = e.Button.Text;
			switch(buttonTxt)
			{
				case "数据导出"://0，3
                    toolBar1.Buttons[0].Enabled = false;
					Export();
                    Thread.Sleep(500);
					ZGExport();
                    Thread.Sleep(500);
					TPExport();
                    toolBar1.Buttons[0].Enabled = true;
					break;
				case "数据上传":
                    toolBar1.Buttons[3].Enabled = false;
					DataUpload();
                   
                    toolBar1.Buttons[3].Enabled = true;
					break;
				case "专供酒导出":
					ZGExport();
					break;
				case "退出":
					this.Close();
					break;
				default:
					break;
			}
		}
		#endregion

		#region 数据上传
		private void DataUpload()
		{
			Hashtable locQueue = GetFileQueue();
			if(locQueue.Count>0)
			{
				if(UpToServer(locQueue))
				{
					string cmd = "delete from tb_bindcnt";
                    CommonClass.ExcuteNonQuery(cmd);
					statusBar1.Panels[0].Text = "数据库计数器已经清空！";
					MessageBox.Show("上传完毕，数据库计数器已经清空！");
				}
				else
				{
					MessageBox.Show("网络异常，请检查网络！");
				}
				
			}
			else
			{
				MessageBox.Show("没有数据上传");
			}
		}
		#endregion

		#region 将文件通过webservice上传到服务器,包含下面几个函数
		private bool UpToServer(Hashtable myQueue)
		{
			bool result = false;
			foreach(object obj in myQueue.Keys)
			{
				string type = myQueue[obj].ToString();
				string locFName = obj.ToString();
				if(FileUpload(locFName,type))
				{
					if(UpdateToSuccess(locFName))
					{
						DeleteFile(locFName);	
						if(!result)
                            result = true;
					}
				}
				else
				{
					//MessageBox.Show("网络异常，请检查网络！");
					result = false;
					break;
				}
			}
			return result;
		}
		#endregion
		
		#region 删除某个文件
		private void DeleteFile(string fName)
		{
			if(File.Exists(fName))
			{
                string abc = Path.GetFileNameWithoutExtension(fName);
                string movePath = @"D:\DataOutReaded\" + abc + ".readed";
                File.Move(fName, movePath);
                //File.Delete(fName);
			}
		}
		#endregion

		#region 将数据导出表内的相关字段置成成功标志
		private bool UpdateToSuccess(string fName)
		{
			bool result = false;
			try
			{
				string command = string.Format("update tb_exportfile set upload_flag=1 where fName='{0}'",fName);
				int cnt = ClassDataExportAndUpload.ExcuteNonQuery(command);
				if(cnt>0)
					result = true;
			}
			catch
			{
			}
			return result;
		}
		#endregion
		
		#region 将文件通过webservice上传到服务器
		private bool FileUpload(string fName,string type)
		{
			bool result = false;
            try
            {
                FileUpAndDown.FileUp fup = new FileUp(fName);
                byte[] by = fup.GetFileByte();
                if (by != null)
                {//此处调用webService
                    WebFileUpload.Service1 fs = new WebFileUpload.Service1();
                    string ssss = System.IO.Path.GetFileName(fName);
                    result = fs.FileUpLoad(by, System.IO.Path.GetFileName(fName), type);
                }
                else
                {
                    result = true;//或者将该赋值语句放在webservice执行成功之后,注意如果文件没有实际内容,也应该是成功标志
                }
            }
            catch
            {
            }
			return result;
		}
		#endregion
        
        #region 从数据表内导出未上传的文件队列
        private Hashtable GetFileQueue()
		{
			Hashtable result = new Hashtable();
			try
			{
				string command = "select * from tb_exportfile where upload_flag=0";
				DataSet ds = ClassDataExportAndUpload.ExecuteDataSet(command,"tb_exportfile");
				DataTable dt = ds.Tables["tb_exportfile"];
				if(dt.Rows.Count>0)
				{
					for(int i=0;i<dt.Rows.Count;i++)
					{
						//result.Enqueue(dt.Rows[i]["fName"].ToString());
						result.Add(dt.Rows[i]["fName"].ToString(),dt.Rows[i]["type"].ToString());
					}
				}
			}
			catch
			{
			}
			return result;
		}
		#endregion

		#region ExecuteDataSet
		private DataSet ExecuteDataSet(string command,string tableName)
		{
			DataSet ds = null;
			try
			{
				ds = ClassDataExportAndUpload.ExecuteDataSet(command,tableName);
			}
			catch
			{
			}
			return ds;
		}
		#endregion

		#region 导出数据
		private Queue DataExport(string command,string tableName,Queue mQ)
		{
			Queue result = null;
			try
			{				
				DataSet ds = ExecuteDataSet(command,tableName);
				result = WriteToTxtFile(ds,mQ,"#",tableName);
			}
			catch
			{
			}
			return result;
		}
		#endregion

		#region 专供酒导出
		private void ZGExport()
		{
			try
			{
				string command_1 = "select * from tb_zgbox";
				Queue queue = new Queue();
				queue.Enqueue("salerid");
				queue.Enqueue("productid");
				queue.Enqueue("boxcode");
				queue.Enqueue("in_date");
				queue.Enqueue("thd");
				Queue fList = DataExport(command_1,"tb_zgbox",queue);
				if(fList.Count>0)
				{
					if(WriteQueueToDB(fList,"箱"))
					{
						string cmd = "delete from tb_zgbox";
						ClassDataExportAndUpload.ExcuteNonQuery(cmd);
					}
					MessageBox.Show("专供酒导出完毕");
				}
				else
					MessageBox.Show("无专供酒需要导出");
			}
			catch
			{
			}
		}
		#endregion

        #region 托盘导出
        private void TPExport()
        {
            try
            {
                DataBase db = new DataBase();
                //查看本地数据库里面是否有待上传的托盘绑定数据
                DataSet localDataSet = db.RunDataSetSQL("select id_flag,L_Tuopancode,L_Boxcode,L_upLoadMark,L_BindDataTime from T_txBind where L_upLoadMark=0", "T_txBind");   //查询出T_txBind表中所有未上传的数据
                int rowsCount = db.RunSelectCountSQL("select count(*) from T_txBind where L_upLoadMark=0");
                if (rowsCount > 0)
                {
                    string localStrConnect = ConfigurationManager.AppSettings["sql_connstr"];     //连接数据库字符串
                    string serverStrConnect = ConfigurationManager.AppSettings["connectToServer"];
                    SqlConnection localConnection = new SqlConnection(localStrConnect);
                    localConnection.Open();
                    SqlConnection serverConnection = new SqlConnection(serverStrConnect);
                    serverConnection.Open();
                    //服务器删除操作
                    SqlCommand cmdServerDel = new SqlCommand(null, serverConnection);
                    cmdServerDel.CommandTimeout = 12000000;
                    cmdServerDel.CommandType = CommandType.Text;
                    cmdServerDel.CommandText = "delete from T_txBindServer where L_TuoPanCode = @L_TuoPanCode";

                    cmdServerDel.Parameters.Add("@L_TuoPanCode", SqlDbType.NVarChar, 50);
                    cmdServerDel.Prepare();
                    //服务器添加操作
                    SqlCommand cmdServerAdd = new SqlCommand(null, serverConnection);
                    cmdServerAdd.CommandTimeout = 12000000;
                    cmdServerAdd.CommandType = CommandType.Text;
                    cmdServerAdd.CommandText = "insert into T_txBindServer(L_TuoPanCode,L_BoxCode,L_UpLoadMark,L_BindDataTime) values (@L_TuoPanCode,@L_BoxCode,@L_UpLoadMark,@L_BindDataTime)";

                    cmdServerAdd.Parameters.Add("@L_TuoPanCode", SqlDbType.NVarChar, 50);
                    cmdServerAdd.Parameters.Add("@L_BoxCode", SqlDbType.NVarChar, 50);
                    cmdServerAdd.Parameters.Add("@L_UpLoadMark", SqlDbType.Int);
                    cmdServerAdd.Parameters.Add("@L_BindDataTime", SqlDbType.DateTime);
                    cmdServerAdd.Prepare();

                    //本地修改操作
                    SqlCommand cmdLocalUpdate = new SqlCommand(null, localConnection);
                    cmdLocalUpdate.CommandTimeout = 12000000;
                    cmdLocalUpdate.CommandType = CommandType.Text;
                    cmdLocalUpdate.CommandText = "update T_txBind set L_UpLoadMark=1 where id_flag=@id_flag";

                    cmdLocalUpdate.Parameters.Add("@id_flag", SqlDbType.Int);
                    cmdLocalUpdate.Prepare();
                    //本地删除操作
                    string selectTPCmd = "select count(distinct l_tuopancode) from t_txbind";
                    int tpCount = db.RunSelectCountSQL(selectTPCmd);
                    DataSet dstTP = new DataSet();
                    dstTP = db.RunDataSetSQL("select distinct l_tuopancode from t_txbind", "t_txbind");
                    for(int j=0;j<tpCount;j++)
                    {
                        string l_tuopanCode = dstTP.Tables["t_txbind"].Rows[j]["l_tuopancode"].ToString();
                        cmdServerDel.Parameters["@L_TuoPanCode"].Value = l_tuopanCode;//托盘编号
                        //1、从服务器上删除即将上传的托盘编号
                        cmdServerDel.ExecuteNonQuery();
                    }
                    //执行绑定操作
                    for (int i = 0; i < rowsCount; i++)
                    {
                        string L_Tuopancode = localDataSet.Tables["T_txBind"].Rows[i]["L_TuoPanCode"].ToString(); //托盘编号
                        string L_Boxcode = localDataSet.Tables["T_txBind"].Rows[i]["L_BoxCode"].ToString(); //箱编号
                        int L_UpLoadMark = 0;         //上传标志 0:未上传，1：已上传
                        string id_flag = localDataSet.Tables["T_txBind"].Rows[i]["id_flag"].ToString();   //
                        string L_BindDataTime = localDataSet.Tables["T_txBind"].Rows[i]["L_BindDataTime"].ToString();

                        

                        cmdServerAdd.Parameters["@L_TuoPanCode"].Value = L_Tuopancode;//托盘编号
                        cmdServerAdd.Parameters["@L_BoxCode"].Value = L_Boxcode;//箱编号
                        cmdServerAdd.Parameters["@L_UpLoadMark"].Value = L_UpLoadMark;//标志是否已上传
                        cmdServerAdd.Parameters["@L_BindDataTime"].Value = L_BindDataTime;
                       
                        cmdLocalUpdate.Parameters["@id_flag"].Value = id_flag; //表ID
                        try
                        {
                            //先将已经存在的托盘号删除
                            //cmdServerDel.ExecuteNonQuery();
                            //Thread.Sleep(100);
                            //将数据上传至服务器
                            //2、将数据插入服务器数据库*********************
                            cmdServerAdd.ExecuteNonQuery();
                            //Thread.Sleep(100);
                            ////3、将本都上传的托盘数据的标识改为已上传*********************
                            cmdLocalUpdate.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            localConnection.Close();
                            localConnection.Dispose();
                            serverConnection.Close();
                            serverConnection.Dispose();
                            MessageBox.Show("请检查网络连接！详细错误信息："+ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    localConnection.Close();
                    serverConnection.Close();
                    //4、删除本地上传成功的数据********************************
                    db.RunDelOrInsertOrUppdateSQL("delete from T_txBind where L_UpLoadMark=1");
                    MessageBox.Show("本次导出托盘绑定数据" + rowsCount.ToString() + "条。");

                }
                else
                {
                    MessageBox.Show("没有要上传的托盘数据", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception es)
            {
                MessageBox.Show("请检查网络连接！详细错误信息：" + es.Message);
            }
        }
        #endregion

        #region 数据导出
        private void Export()
		{
			try
			{
				string command = "select productname,pdate,count(productname) as cnt from tb_bind group by productname,pdate";
				string tableName = "tb_bind";
                //mQ里面存放了产品名车、生产日期、数量三个变量的名称
                Queue mQ = new Queue();
				mQ.Enqueue("productname");
				mQ.Enqueue("pdate");
				mQ.Enqueue("cnt");
				Queue fileQueue = DataExport(command,tableName,mQ);
				Thread.Sleep(1500);
				if(fileQueue.Count>0)
				{
					if(WriteQueueToDB(fileQueue,"产量"))
					{
						string command_a = "select * from tb_bind";					
						Queue mQ_a = new Queue();
						mQ_a.Enqueue("boxcode");
						mQ_a.Enqueue("bottlecode");
						mQ_a.Enqueue("productname");
						Queue fileList = DataExport(command_a,tableName,mQ_a);
						if(fileList.Count>0)
						{
							if(WriteQueueToDB(fileList,"绑定"))
							{
								string delCmd = "delete from tb_bind";
								int cnt = DeleteDataBind(delCmd);
							}
						}
						MessageBox.Show("数据导出完毕！");
					}
				}
				else
					MessageBox.Show("没有数据需要导出");
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
		#endregion

		#region 将数据从绑定表内清空
		private int DeleteDataBind(string command)
		{
			int result = 0;
			try
			{
				result = ClassDataExportAndUpload.ExcuteNonQuery(command);
			}
			catch
			{
			}
			return result;
		}
		#endregion

		#region 将队列内的文件名写入数据库
		private bool WriteQueueToDB(Queue _mq,string strType)
		{
			bool result = false;
			int cnt = 0;
			object[] obj = _mq.ToArray();
			try
			{
				if(obj.Length>0)
				{
					for(int i=0;i<obj.Length;i++)
					{
						string fName = obj[i].ToString();
						string command = string.Format("insert into tb_exportfile(fName,upload_flag,type) values('{0}',0,'{1}')",fName,strType);
						cnt += ClassDataExportAndUpload.ExcuteNonQuery(command);					
					}
				}
				else
				{
				}
			}
			catch
			{
			}
			result = (cnt==obj.Length)?true:false;
			return result;
		}

		#endregion

		#region 数据通过数据导出类写入文本文件
		private Queue WriteToTxtFile(DataSet ds,Queue mQ,string splite,string tableName)
		{
			Queue result = null;
			try
			{
				string machine_id = ConfigurationManager.AppSettings["banzu"];
				FileExAndIm.FileExport ff = new FileExAndIm.FileExport(machine_id,this._countPerFile,this._fPath);	
				ff.SetColumn = mQ;
				ff.SetSpliteChar = splite;
				ff.SetTableName = tableName;
				ff.SetDataSet = ds;
				ff.ExportData();
				if(ff.GetExportStatus)
				{
					try
					{
						result = ff.GetFileQueue;
					}
					catch
					{					
					}				
				}
			}
			catch
			{
			}
			return result;
		}
		#endregion

      

       
	}
}
