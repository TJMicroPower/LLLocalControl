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
	/// FrmDataExportAndUp ��ժҪ˵����
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
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
		}

		/// <summary>
		/// ������������ʹ�õ���Դ��
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

		#region Windows ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
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
            this.toolBarButton1.Text = "���ݵ���";
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
            this.toolBarButton4.Text = "�����ϴ�";
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
            this.toolBarButton7.Text = "�˳�";
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
            this.button1.Text = "    ע����ע����ʾ���Ƿ���ר���Ƶ���������У���ѡ�ǣ�����ѡ��";
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
            this.Text = "���ݵ������ϴ�";
            this.Load += new System.EventHandler(this.FrmDataExportAndUp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region ��ʼ�������ַ���

		private void FrmDataExportAndUp_Load(object sender, System.EventArgs e)
		{
			ClassDataExportAndUpload._connstr = ConfigurationManager.AppSettings["sql_connstr"];
            
		}
		#endregion

		#region �������

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			string buttonTxt = e.Button.Text;
			switch(buttonTxt)
			{
				case "���ݵ���"://0��3
                    toolBar1.Buttons[0].Enabled = false;
					Export();
                    Thread.Sleep(500);
					ZGExport();
                    Thread.Sleep(500);
					TPExport();
                    toolBar1.Buttons[0].Enabled = true;
					break;
				case "�����ϴ�":
                    toolBar1.Buttons[3].Enabled = false;
					DataUpload();
                   
                    toolBar1.Buttons[3].Enabled = true;
					break;
				case "ר���Ƶ���":
					ZGExport();
					break;
				case "�˳�":
					this.Close();
					break;
				default:
					break;
			}
		}
		#endregion

		#region �����ϴ�
		private void DataUpload()
		{
			Hashtable locQueue = GetFileQueue();
			if(locQueue.Count>0)
			{
				if(UpToServer(locQueue))
				{
					string cmd = "delete from tb_bindcnt";
                    CommonClass.ExcuteNonQuery(cmd);
					statusBar1.Panels[0].Text = "���ݿ�������Ѿ���գ�";
					MessageBox.Show("�ϴ���ϣ����ݿ�������Ѿ���գ�");
				}
				else
				{
					MessageBox.Show("�����쳣���������磡");
				}
				
			}
			else
			{
				MessageBox.Show("û�������ϴ�");
			}
		}
		#endregion

		#region ���ļ�ͨ��webservice�ϴ���������,�������漸������
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
					//MessageBox.Show("�����쳣���������磡");
					result = false;
					break;
				}
			}
			return result;
		}
		#endregion
		
		#region ɾ��ĳ���ļ�
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

		#region �����ݵ������ڵ�����ֶ��óɳɹ���־
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
		
		#region ���ļ�ͨ��webservice�ϴ���������
		private bool FileUpload(string fName,string type)
		{
			bool result = false;
            try
            {
                FileUpAndDown.FileUp fup = new FileUp(fName);
                byte[] by = fup.GetFileByte();
                if (by != null)
                {//�˴�����webService
                    WebFileUpload.Service1 fs = new WebFileUpload.Service1();
                    string ssss = System.IO.Path.GetFileName(fName);
                    result = fs.FileUpLoad(by, System.IO.Path.GetFileName(fName), type);
                }
                else
                {
                    result = true;//���߽��ø�ֵ������webserviceִ�гɹ�֮��,ע������ļ�û��ʵ������,ҲӦ���ǳɹ���־
                }
            }
            catch
            {
            }
			return result;
		}
		#endregion
        
        #region �����ݱ��ڵ���δ�ϴ����ļ�����
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

		#region ��������
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

		#region ר���Ƶ���
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
					if(WriteQueueToDB(fList,"��"))
					{
						string cmd = "delete from tb_zgbox";
						ClassDataExportAndUpload.ExcuteNonQuery(cmd);
					}
					MessageBox.Show("ר���Ƶ������");
				}
				else
					MessageBox.Show("��ר������Ҫ����");
			}
			catch
			{
			}
		}
		#endregion

        #region ���̵���
        private void TPExport()
        {
            try
            {
                DataBase db = new DataBase();
                //�鿴�������ݿ������Ƿ��д��ϴ������̰�����
                DataSet localDataSet = db.RunDataSetSQL("select id_flag,L_Tuopancode,L_Boxcode,L_upLoadMark,L_BindDataTime from T_txBind where L_upLoadMark=0", "T_txBind");   //��ѯ��T_txBind��������δ�ϴ�������
                int rowsCount = db.RunSelectCountSQL("select count(*) from T_txBind where L_upLoadMark=0");
                if (rowsCount > 0)
                {
                    string localStrConnect = ConfigurationManager.AppSettings["sql_connstr"];     //�������ݿ��ַ���
                    string serverStrConnect = ConfigurationManager.AppSettings["connectToServer"];
                    SqlConnection localConnection = new SqlConnection(localStrConnect);
                    localConnection.Open();
                    SqlConnection serverConnection = new SqlConnection(serverStrConnect);
                    serverConnection.Open();
                    //������ɾ������
                    SqlCommand cmdServerDel = new SqlCommand(null, serverConnection);
                    cmdServerDel.CommandTimeout = 12000000;
                    cmdServerDel.CommandType = CommandType.Text;
                    cmdServerDel.CommandText = "delete from T_txBindServer where L_TuoPanCode = @L_TuoPanCode";

                    cmdServerDel.Parameters.Add("@L_TuoPanCode", SqlDbType.NVarChar, 50);
                    cmdServerDel.Prepare();
                    //��������Ӳ���
                    SqlCommand cmdServerAdd = new SqlCommand(null, serverConnection);
                    cmdServerAdd.CommandTimeout = 12000000;
                    cmdServerAdd.CommandType = CommandType.Text;
                    cmdServerAdd.CommandText = "insert into T_txBindServer(L_TuoPanCode,L_BoxCode,L_UpLoadMark,L_BindDataTime) values (@L_TuoPanCode,@L_BoxCode,@L_UpLoadMark,@L_BindDataTime)";

                    cmdServerAdd.Parameters.Add("@L_TuoPanCode", SqlDbType.NVarChar, 50);
                    cmdServerAdd.Parameters.Add("@L_BoxCode", SqlDbType.NVarChar, 50);
                    cmdServerAdd.Parameters.Add("@L_UpLoadMark", SqlDbType.Int);
                    cmdServerAdd.Parameters.Add("@L_BindDataTime", SqlDbType.DateTime);
                    cmdServerAdd.Prepare();

                    //�����޸Ĳ���
                    SqlCommand cmdLocalUpdate = new SqlCommand(null, localConnection);
                    cmdLocalUpdate.CommandTimeout = 12000000;
                    cmdLocalUpdate.CommandType = CommandType.Text;
                    cmdLocalUpdate.CommandText = "update T_txBind set L_UpLoadMark=1 where id_flag=@id_flag";

                    cmdLocalUpdate.Parameters.Add("@id_flag", SqlDbType.Int);
                    cmdLocalUpdate.Prepare();
                    //����ɾ������
                    string selectTPCmd = "select count(distinct l_tuopancode) from t_txbind";
                    int tpCount = db.RunSelectCountSQL(selectTPCmd);
                    DataSet dstTP = new DataSet();
                    dstTP = db.RunDataSetSQL("select distinct l_tuopancode from t_txbind", "t_txbind");
                    for(int j=0;j<tpCount;j++)
                    {
                        string l_tuopanCode = dstTP.Tables["t_txbind"].Rows[j]["l_tuopancode"].ToString();
                        cmdServerDel.Parameters["@L_TuoPanCode"].Value = l_tuopanCode;//���̱��
                        //1���ӷ�������ɾ�������ϴ������̱��
                        cmdServerDel.ExecuteNonQuery();
                    }
                    //ִ�а󶨲���
                    for (int i = 0; i < rowsCount; i++)
                    {
                        string L_Tuopancode = localDataSet.Tables["T_txBind"].Rows[i]["L_TuoPanCode"].ToString(); //���̱��
                        string L_Boxcode = localDataSet.Tables["T_txBind"].Rows[i]["L_BoxCode"].ToString(); //����
                        int L_UpLoadMark = 0;         //�ϴ���־ 0:δ�ϴ���1�����ϴ�
                        string id_flag = localDataSet.Tables["T_txBind"].Rows[i]["id_flag"].ToString();   //
                        string L_BindDataTime = localDataSet.Tables["T_txBind"].Rows[i]["L_BindDataTime"].ToString();

                        

                        cmdServerAdd.Parameters["@L_TuoPanCode"].Value = L_Tuopancode;//���̱��
                        cmdServerAdd.Parameters["@L_BoxCode"].Value = L_Boxcode;//����
                        cmdServerAdd.Parameters["@L_UpLoadMark"].Value = L_UpLoadMark;//��־�Ƿ����ϴ�
                        cmdServerAdd.Parameters["@L_BindDataTime"].Value = L_BindDataTime;
                       
                        cmdLocalUpdate.Parameters["@id_flag"].Value = id_flag; //��ID
                        try
                        {
                            //�Ƚ��Ѿ����ڵ����̺�ɾ��
                            //cmdServerDel.ExecuteNonQuery();
                            //Thread.Sleep(100);
                            //�������ϴ���������
                            //2�������ݲ�����������ݿ�*********************
                            cmdServerAdd.ExecuteNonQuery();
                            //Thread.Sleep(100);
                            ////3���������ϴ����������ݵı�ʶ��Ϊ���ϴ�*********************
                            cmdLocalUpdate.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            localConnection.Close();
                            localConnection.Dispose();
                            serverConnection.Close();
                            serverConnection.Dispose();
                            MessageBox.Show("�����������ӣ���ϸ������Ϣ��"+ex.Message, "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    localConnection.Close();
                    serverConnection.Close();
                    //4��ɾ�������ϴ��ɹ�������********************************
                    db.RunDelOrInsertOrUppdateSQL("delete from T_txBind where L_UpLoadMark=1");
                    MessageBox.Show("���ε������̰�����" + rowsCount.ToString() + "����");

                }
                else
                {
                    MessageBox.Show("û��Ҫ�ϴ�����������", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception es)
            {
                MessageBox.Show("�����������ӣ���ϸ������Ϣ��" + es.Message);
            }
        }
        #endregion

        #region ���ݵ���
        private void Export()
		{
			try
			{
				string command = "select productname,pdate,count(productname) as cnt from tb_bind group by productname,pdate";
				string tableName = "tb_bind";
                //mQ�������˲�Ʒ�������������ڡ�������������������
                Queue mQ = new Queue();
				mQ.Enqueue("productname");
				mQ.Enqueue("pdate");
				mQ.Enqueue("cnt");
				Queue fileQueue = DataExport(command,tableName,mQ);
				Thread.Sleep(1500);
				if(fileQueue.Count>0)
				{
					if(WriteQueueToDB(fileQueue,"����"))
					{
						string command_a = "select * from tb_bind";					
						Queue mQ_a = new Queue();
						mQ_a.Enqueue("boxcode");
						mQ_a.Enqueue("bottlecode");
						mQ_a.Enqueue("productname");
						Queue fileList = DataExport(command_a,tableName,mQ_a);
						if(fileList.Count>0)
						{
							if(WriteQueueToDB(fileList,"��"))
							{
								string delCmd = "delete from tb_bind";
								int cnt = DeleteDataBind(delCmd);
							}
						}
						MessageBox.Show("���ݵ�����ϣ�");
					}
				}
				else
					MessageBox.Show("û��������Ҫ����");
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
		#endregion

		#region �����ݴӰ󶨱������
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

		#region �������ڵ��ļ���д�����ݿ�
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

		#region ����ͨ�����ݵ�����д���ı��ļ�
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
