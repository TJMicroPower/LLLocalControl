using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Configuration;
using System.IO;
using System.Data.SqlClient;
using Microsoft.Win32;
using System.Threading;
using EncryptionAndDecryption;

namespace LocalControl
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		#region 类生成的变量及方法
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton tb_start;
		private System.Windows.Forms.ToolBarButton tb_stop;
		private System.Windows.Forms.ToolBarButton tb_noMake;
		private System.Windows.Forms.ToolBarButton tb_control;
		private System.Windows.Forms.ToolBarButton tb_noBanding;
		private System.Windows.Forms.ToolBarButton tb_upload;
		private System.Windows.Forms.ToolBarButton tb_update;
		private System.Windows.Forms.ToolBarButton tb_setPort;
		private System.Windows.Forms.ToolBarButton tb_lockAndFree;
		private System.Windows.Forms.ToolBarButton txt_queding;
		private System.Windows.Forms.TextBox txt_mimakuang;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ToolBarButton txt_yichang;
		private System.Windows.Forms.ToolBarButton tb_query;
		private System.Windows.Forms.ToolBarButton tb_spcz;
		private System.Windows.Forms.ToolBarButton tb_zhuangong;
		private System.Windows.Forms.ToolBarButton tb_exit;
		private System.Windows.Forms.ToolBarButton tb_powerOff;
		private System.Windows.Forms.ToolBarButton tb_reStart;
		private System.Windows.Forms.ToolBarButton tb_zhuxiao;
		private System.Windows.Forms.DataGrid dgdList;
		private bool b=false;

        //private Thread t_information=null;
	

		private DataTable dtData;
		private DataSet dst;
        private System.Windows.Forms.ToolBarButton tb_CheckOnMainServer;
		private System.Windows.Forms.Label lbl_information;
		private System.Windows.Forms.Button btn_gmima;
		private System.Windows.Forms.Button btn_jiesuo;
		private System.Windows.Forms.TextBox txt_jiesuo;
		private BindingManagerBase bmData;


	
		public Form1()
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
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		
		#endregion

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.tb_start = new System.Windows.Forms.ToolBarButton();
            this.tb_stop = new System.Windows.Forms.ToolBarButton();
            this.tb_noMake = new System.Windows.Forms.ToolBarButton();
            this.tb_control = new System.Windows.Forms.ToolBarButton();
            this.tb_noBanding = new System.Windows.Forms.ToolBarButton();
            this.tb_upload = new System.Windows.Forms.ToolBarButton();
            this.tb_update = new System.Windows.Forms.ToolBarButton();
            this.txt_yichang = new System.Windows.Forms.ToolBarButton();
            this.tb_setPort = new System.Windows.Forms.ToolBarButton();
            this.tb_spcz = new System.Windows.Forms.ToolBarButton();
            this.tb_query = new System.Windows.Forms.ToolBarButton();
            this.tb_zhuangong = new System.Windows.Forms.ToolBarButton();
            this.tb_powerOff = new System.Windows.Forms.ToolBarButton();
            this.tb_reStart = new System.Windows.Forms.ToolBarButton();
            this.tb_zhuxiao = new System.Windows.Forms.ToolBarButton();
            this.tb_lockAndFree = new System.Windows.Forms.ToolBarButton();
            this.tb_exit = new System.Windows.Forms.ToolBarButton();
            this.txt_queding = new System.Windows.Forms.ToolBarButton();
            this.tb_CheckOnMainServer = new System.Windows.Forms.ToolBarButton();
            this.txt_mimakuang = new System.Windows.Forms.TextBox();
            this.dgdList = new System.Windows.Forms.DataGrid();
            this.lbl_information = new System.Windows.Forms.Label();
            this.btn_gmima = new System.Windows.Forms.Button();
            this.btn_jiesuo = new System.Windows.Forms.Button();
            this.txt_jiesuo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgdList)).BeginInit();
            this.SuspendLayout();
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 418);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(1030, 22);
            this.statusBar1.SizingGrip = false;
            this.statusBar1.TabIndex = 0;
            this.statusBar1.Text = "statusBar1";
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Width = 1030;
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
            this.imageList1.Images.SetKeyName(32, "");
            this.imageList1.Images.SetKeyName(33, "");
            this.imageList1.Images.SetKeyName(34, "");
            this.imageList1.Images.SetKeyName(35, "");
            this.imageList1.Images.SetKeyName(36, "");
            this.imageList1.Images.SetKeyName(37, "");
            this.imageList1.Images.SetKeyName(38, "");
            this.imageList1.Images.SetKeyName(39, "");
            this.imageList1.Images.SetKeyName(40, "");
            this.imageList1.Images.SetKeyName(41, "");
            this.imageList1.Images.SetKeyName(42, "");
            this.imageList1.Images.SetKeyName(43, "");
            this.imageList1.Images.SetKeyName(44, "");
            // 
            // toolBar1
            // 
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.tb_start,
            this.tb_stop,
            this.tb_noMake,
            this.tb_control,
            this.tb_noBanding,
            this.tb_upload,
            this.tb_update,
            this.txt_yichang,
            this.tb_setPort,
            this.tb_spcz,
            this.tb_query,
            this.tb_zhuangong,
            this.tb_powerOff,
            this.tb_reStart,
            this.tb_zhuxiao,
            this.tb_lockAndFree,
            this.tb_exit,
            this.txt_queding,
            this.tb_CheckOnMainServer});
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.imageList1;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(1030, 41);
            this.toolBar1.TabIndex = 9;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // tb_start
            // 
            this.tb_start.ImageIndex = 0;
            this.tb_start.Name = "tb_start";
            this.tb_start.Text = "启动";
            // 
            // tb_stop
            // 
            this.tb_stop.Enabled = false;
            this.tb_stop.ImageIndex = 9;
            this.tb_stop.Name = "tb_stop";
            this.tb_stop.Text = "停止";
            // 
            // tb_noMake
            // 
            this.tb_noMake.Enabled = false;
            this.tb_noMake.ImageIndex = 3;
            this.tb_noMake.Name = "tb_noMake";
            this.tb_noMake.Text = "生成号码";
            // 
            // tb_control
            // 
            this.tb_control.Enabled = false;
            this.tb_control.ImageIndex = 12;
            this.tb_control.Name = "tb_control";
            this.tb_control.Text = "现场控制";
            // 
            // tb_noBanding
            // 
            this.tb_noBanding.Enabled = false;
            this.tb_noBanding.ImageIndex = 6;
            this.tb_noBanding.Name = "tb_noBanding";
            this.tb_noBanding.Text = "号码绑定";
            this.tb_noBanding.Visible = false;
            // 
            // tb_upload
            // 
            this.tb_upload.Enabled = false;
            this.tb_upload.ImageIndex = 11;
            this.tb_upload.Name = "tb_upload";
            this.tb_upload.Text = "上传";
            // 
            // tb_update
            // 
            this.tb_update.ImageIndex = 1;
            this.tb_update.Name = "tb_update";
            this.tb_update.Text = "信息更新";
            // 
            // txt_yichang
            // 
            this.txt_yichang.Enabled = false;
            this.txt_yichang.ImageIndex = 6;
            this.txt_yichang.Name = "txt_yichang";
            this.txt_yichang.Text = "异常箱号";
            this.txt_yichang.Visible = false;
            // 
            // tb_setPort
            // 
            this.tb_setPort.ImageIndex = 37;
            this.tb_setPort.Name = "tb_setPort";
            this.tb_setPort.Text = "端口设置";
            // 
            // tb_spcz
            // 
            this.tb_spcz.Enabled = false;
            this.tb_spcz.ImageIndex = 38;
            this.tb_spcz.Name = "tb_spcz";
            this.tb_spcz.Text = "碎瓶重装";
            // 
            // tb_query
            // 
            this.tb_query.Enabled = false;
            this.tb_query.ImageIndex = 8;
            this.tb_query.Name = "tb_query";
            this.tb_query.Text = "查询";
            // 
            // tb_zhuangong
            // 
            this.tb_zhuangong.Enabled = false;
            this.tb_zhuangong.ImageIndex = 42;
            this.tb_zhuangong.Name = "tb_zhuangong";
            this.tb_zhuangong.Text = "专供设置";
            this.tb_zhuangong.Visible = false;
            // 
            // tb_powerOff
            // 
            this.tb_powerOff.ImageIndex = 30;
            this.tb_powerOff.Name = "tb_powerOff";
            this.tb_powerOff.Text = "关机";
            // 
            // tb_reStart
            // 
            this.tb_reStart.ImageIndex = 23;
            this.tb_reStart.Name = "tb_reStart";
            this.tb_reStart.Text = "重启";
            // 
            // tb_zhuxiao
            // 
            this.tb_zhuxiao.ImageIndex = 22;
            this.tb_zhuxiao.Name = "tb_zhuxiao";
            this.tb_zhuxiao.Text = "注销";
            // 
            // tb_lockAndFree
            // 
            this.tb_lockAndFree.ImageIndex = 32;
            this.tb_lockAndFree.Name = "tb_lockAndFree";
            this.tb_lockAndFree.Text = "解除锁定";
            // 
            // tb_exit
            // 
            this.tb_exit.Enabled = false;
            this.tb_exit.ImageIndex = 10;
            this.tb_exit.Name = "tb_exit";
            this.tb_exit.Text = "退出";
            // 
            // txt_queding
            // 
            this.txt_queding.Enabled = false;
            this.txt_queding.ImageIndex = 36;
            this.txt_queding.Name = "txt_queding";
            this.txt_queding.Text = "确定";
            // 
            // tb_CheckOnMainServer
            // 
            this.tb_CheckOnMainServer.Enabled = false;
            this.tb_CheckOnMainServer.ImageIndex = 43;
            this.tb_CheckOnMainServer.Name = "tb_CheckOnMainServer";
            this.tb_CheckOnMainServer.Text = "检索";
            this.tb_CheckOnMainServer.Visible = false;
            // 
            // txt_mimakuang
            // 
            this.txt_mimakuang.Location = new System.Drawing.Point(719, 11);
            this.txt_mimakuang.Name = "txt_mimakuang";
            this.txt_mimakuang.PasswordChar = '*';
            this.txt_mimakuang.Size = new System.Drawing.Size(56, 21);
            this.txt_mimakuang.TabIndex = 11;
            this.txt_mimakuang.Text = "111111";
            this.txt_mimakuang.Visible = false;
            // 
            // dgdList
            // 
            this.dgdList.AlternatingBackColor = System.Drawing.Color.White;
            this.dgdList.BackColor = System.Drawing.Color.White;
            this.dgdList.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgdList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgdList.CaptionBackColor = System.Drawing.Color.Teal;
            this.dgdList.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.dgdList.CaptionForeColor = System.Drawing.Color.White;
            this.dgdList.DataMember = "";
            this.dgdList.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgdList.FlatMode = true;
            this.dgdList.Font = new System.Drawing.Font("Tahoma", 8F);
            this.dgdList.ForeColor = System.Drawing.Color.Black;
            this.dgdList.GridLineColor = System.Drawing.Color.Silver;
            this.dgdList.HeaderBackColor = System.Drawing.Color.Black;
            this.dgdList.HeaderFont = new System.Drawing.Font("Tahoma", 8F);
            this.dgdList.HeaderForeColor = System.Drawing.Color.White;
            this.dgdList.LinkColor = System.Drawing.Color.Purple;
            this.dgdList.Location = new System.Drawing.Point(0, 41);
            this.dgdList.Name = "dgdList";
            this.dgdList.ParentRowsBackColor = System.Drawing.Color.Gray;
            this.dgdList.ParentRowsForeColor = System.Drawing.Color.White;
            this.dgdList.SelectionBackColor = System.Drawing.Color.Maroon;
            this.dgdList.SelectionForeColor = System.Drawing.Color.White;
            this.dgdList.Size = new System.Drawing.Size(1030, 119);
            this.dgdList.TabIndex = 13;
            // 
            // lbl_information
            // 
            this.lbl_information.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_information.ForeColor = System.Drawing.Color.Red;
            this.lbl_information.Location = new System.Drawing.Point(1016, 8);
            this.lbl_information.Name = "lbl_information";
            this.lbl_information.Size = new System.Drawing.Size(8, 24);
            this.lbl_information.TabIndex = 15;
            // 
            // btn_gmima
            // 
            this.btn_gmima.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_gmima.Location = new System.Drawing.Point(918, 9);
            this.btn_gmima.Name = "btn_gmima";
            this.btn_gmima.Size = new System.Drawing.Size(56, 24);
            this.btn_gmima.TabIndex = 17;
            this.btn_gmima.Text = "改密码";
            this.btn_gmima.Visible = false;
            this.btn_gmima.Click += new System.EventHandler(this.btn_gmima_Click);
            // 
            // btn_jiesuo
            // 
            this.btn_jiesuo.Location = new System.Drawing.Point(794, 11);
            this.btn_jiesuo.Name = "btn_jiesuo";
            this.btn_jiesuo.Size = new System.Drawing.Size(51, 23);
            this.btn_jiesuo.TabIndex = 19;
            this.btn_jiesuo.Text = "解 锁";
            this.btn_jiesuo.Visible = false;
            this.btn_jiesuo.Click += new System.EventHandler(this.btn_jiesuo_Click);
            // 
            // txt_jiesuo
            // 
            this.txt_jiesuo.Location = new System.Drawing.Point(851, 11);
            this.txt_jiesuo.Name = "txt_jiesuo";
            this.txt_jiesuo.PasswordChar = '*';
            this.txt_jiesuo.Size = new System.Drawing.Size(61, 21);
            this.txt_jiesuo.TabIndex = 20;
            this.txt_jiesuo.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1030, 440);
            this.Controls.Add(this.txt_jiesuo);
            this.Controls.Add(this.btn_jiesuo);
            this.Controls.Add(this.btn_gmima);
            this.Controls.Add(this.lbl_information);
            this.Controls.Add(this.dgdList);
            this.Controls.Add(this.txt_mimakuang);
            this.Controls.Add(this.toolBar1);
            this.Controls.Add(this.statusBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "微派科技现场喷码与控制系统";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgdList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region 程序主入口点
		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}
		#endregion
		
		#region 设置ToolBar的状态
		private void SetToolBarState(bool bState)
		{
			toolBar1.Buttons[0].Enabled = bState;
			toolBar1.Buttons[1].Enabled = !bState;
			toolBar1.Buttons[2].Enabled = !bState;
			toolBar1.Buttons[3].Enabled = !bState;
			toolBar1.Buttons[4].Enabled = !bState;
			toolBar1.Buttons[5].Enabled = !bState;
//			toolBar1.Buttons[6].Enabled = !bState;
			toolBar1.Buttons[7].Enabled = !bState;
			toolBar1.Buttons[9].Enabled = !bState;
			toolBar1.Buttons[10].Enabled = !bState;
			toolBar1.Buttons[11].Enabled = !bState;
			toolBar1.Buttons[16].Enabled = !bState;
			
		}
		#endregion

		#region 获得子窗体的状态
		private bool GetInstanceState(string name)
		{
			//获得frmMain子窗体的数量
			int i = this.MdiChildren.Length;
			//循环判断是否有名为name的子窗体实例
			for(i=0;i<MdiChildren.Length;i++)
			{
				if(MdiChildren[i].Name == name)
				{
					MdiChildren[i].Focus();
					return true;
				}
			}
			return false;
			
		}
		#endregion

		#region 窗体的Load（）事件

		private void Form1_Load(object sender, System.EventArgs e)
		{
            #region 生产环境代码            
            EncryptionAndDecryption.Class1 c1 = new Class1();
            if (c1.ResultOfEandD() == "81A8908DEB754BCC59C4E3D67EEAF95")
            {
                string strDirectory = ConfigurationManager.AppSettings["fpath"];
                if (!Directory.Exists(strDirectory))
                {
                    Directory.CreateDirectory(strDirectory);
                }
                this.FormBorderStyle = FormBorderStyle.None;
                this.TopMost = true;
            }
            else
            {
                MessageBox.Show("请插入加密锁");
                this.Dispose();
            }
            #endregion

            #region 测试代码           
            //string strDirectory = ConfigurationManager.AppSettings["fpath"];
            //    if (!Directory.Exists(strDirectory))
            //    {
            //        Directory.CreateDirectory(strDirectory);
            //    }
            //    this.FormBorderStyle = FormBorderStyle.None;
            //    this.TopMost = true;           
            #endregion

            #region 限制生产线数量
            //DataBaseForServer db = new DataBaseForServer();
            //int lineNo=0;
            //int maxLine=0;
            //string ln = ConfigurationManager.AppSettings["banzu"].ToString();
            //try
            //{

            //lineNo = int.Parse(ln);
            //string CommandText = "select l_maxLine from tb_wmaxLine";
            //maxLine = int.Parse(db.RunSelectResultsSQL(CommandText));
            //}
            //catch
            //{
            //    //MessageBox.Show("网络错误！");
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.TopMost = true;
            //this.toolBar1.Enabled = false;
            //this.txt_jiesuo.Visible = true;
            //    //this.btn_jiesuo.Visible = true;
            //}
            //if(lineNo<=maxLine)//判断生产线数量
            //{

            //    try
            //    {
            //        string CommandText1 = string.Format("select count(*) from tb_wlineNo where l_lineNo = '{0}'",ln);
            //        int result = db.RunSelectCountSQL(CommandText1);
            //        if(result==0)//判断班组号是否已经注册
            //        {
            //            string CommandText2 = string.Format("insert into tb_wlineNo(l_lineNo) values('{0}')",ln);
            //            db.RunDelOrInsertOrUppdateSQL(CommandText2);

            //            string strDirectory = ConfigurationManager.AppSettings["fpath"];


            //            #region //设置开机自动运行 可以使用，但没有调试过
            //            //			RegistryKey key6 = GetRegistr();
            //            //			if(key6.GetValue("myForm","default").ToString() =="default")
            //            //			{
            //            //				
            //            //			}
            //            //			else
            //            //			{
            //            //				//获得文件的当前路径
            //            //				string dir = Directory.GetCurrentDirectory();
            //            //				//获取可执行文件的全部路径
            //            //				string exeDir = dir+"\\LocalControl.exe";
            //            //				//在Run键中写入一个新的值
            //            //				key6.SetValue("myForm",exeDir);
            //            //				
            //            //			}

            //            #endregion
            //            this.FormBorderStyle = FormBorderStyle.None;
            //            this.TopMost = true;
            //        }
            //        else
            //        {
            //            MessageBox.Show("生产线号已被注册！");
            //            this.FormBorderStyle = FormBorderStyle.None;
            //            this.TopMost = true;
            //            this.toolBar1.Enabled = false;
            //            this.txt_jiesuo.Visible = true;
            //            this.btn_jiesuo.Visible = true;
            //        }
            //    }
            //    catch
            //    {
            //        MessageBox.Show("网络错误！");
            //        this.FormBorderStyle = FormBorderStyle.None;
            //        this.TopMost = true;
            //        this.toolBar1.Enabled = false;
            //        this.txt_jiesuo.Visible = true;
            //        this.btn_jiesuo.Visible = true;
            //    }


            //}
            //else
            //{
            //    MessageBox.Show("生产线数量不能超过"+maxLine.ToString()+"条！");
            //    this.FormBorderStyle = FormBorderStyle.None;
            //    this.TopMost = true;
            //    this.toolBar1.Enabled = false;
            //    this.txt_jiesuo.Visible = true;
            //    this.btn_jiesuo.Visible = true;
            //} 
            #endregion
        }
        #endregion

        #region GetRegistr()
        private static RegistryKey GetRegistr()
		{
			//获取Run键
			RegistryKey key1 = Registry.LocalMachine;
			RegistryKey key2 = key1.CreateSubKey("SOFTWARE");
			RegistryKey key3 = key2.CreateSubKey("Microsoft");
			RegistryKey key4 = key3.CreateSubKey("Windows");
			RegistryKey key5 = key4.CreateSubKey("CurrentVersion");
			RegistryKey key6 = key5.CreateSubKey("Run");
			return key6;
		}
		#endregion

		#region LoadData()
		public void LoadData()
		{
			try
			{
				//从WebService重新填充DataSet dst
				dst = new DataSet();
				dst.Clear();
				SenInformation.Service1 si = new LocalControl.SenInformation.Service1();
				dst = si.SenInformation();
				int aa = dst.Tables["tb_wgonggao"].Rows.Count;
				dgdList.DataSource = dst.Tables["tb_wgonggao"];
				dtData = dst.Tables["tb_wgonggao"];//初始化要显示的表

			}
			catch
			{
				
			}
			
		}


		#endregion
		
		#region SetDataGrid()
		public void SetDataGrid()
		{
			LoadData();
			//定义一个DataGrid表样式
			try
			{
				DataGridTableStyle ts = new DataGridTableStyle();
				string []HeadText = new string[]{"公告号","                                           信息内容","发布时间"}; 
				int numCols = dtData.Columns.Count;
				DataGridTextBoxColumn aCol;
				for(int i=0;i<numCols;i++)
				{
					aCol = new DataGridTextBoxColumn();
					aCol.MappingName = dtData.Columns[i].ColumnName;
					aCol.HeaderText = HeadText[i].ToString();
					aCol.NullText = "";
					aCol.ReadOnly = true;
					switch(i)
					{
						case 0:					
							aCol.Width = 35;
							break;
						case 1:
							aCol.Width = 800;
							break;
						case 2:
							aCol.Width = 80;
							break;
					}
					ts.GridColumnStyles.Add(aCol);
				}
			
				ts.AlternatingBackColor = Color.Black;
				ts.BackColor = Color.Black;
				ts.ForeColor = Color.LimeGreen;
				ts.AllowSorting = false;
				ts.MappingName = dtData.TableName;
				dgdList.TableStyles.Clear();
				dgdList.TableStyles.Add(ts);
				DataView dv = dtData.DefaultView;
				dv.AllowNew = false;
				dv.AllowDelete = false;
				dgdList.DataSource = dv;
				bmData = this.BindingContext[dst,"tb_wgonggao"];
			}
			
			catch(Exception es)
			{
				MessageBox.Show(es.ToString());
			}
				
		
		}
		#endregion
		
		#region toolBar点击事件
		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
            DataBaseForServer db = new DataBaseForServer();
            int []buttonsIndex = new int[9]{2,3,4,5,6,7,8,10,17};
			string [] buttonsText = new string[]{"生成号码","现场控制","上传","信息更新","异常箱号","端口设置","碎瓶重装","专供设置","检索"};
			string textClick = e.Button.Text;
			this.SetButtonsVisible(false);
			switch(e.Button.Text)
			{
				case "启动":
					SetToolBarState(false);
					this.SetButtonsVisible(true);
//					if(GetInstanceState("Info"))
//					{
//						return;
//					}
//					else
//					{
//						Info ifo = new Info();
//						ifo.MdiParent = this;
//						ifo.Show();
//						ifo.Dock = System.Windows.Forms.DockStyle.Top;
//					}
					break;
				case "停止":
					if(this.MdiChildren.Length==0)
					{
						SetToolBarState(true);
					}
					break;
				case "解除锁定":
					this.txt_mimakuang.Visible = true;
					this.toolBar1.Buttons[17].Enabled = true;
					toolBar1.Buttons[8].Enabled = true;
					this.TopMost = false;
					b = false;
					
					break;
				case "锁定计算机":
					this.FormBorderStyle = FormBorderStyle.None;
					this.TopMost = true;
					this.toolBar1.Buttons[15].Text = "解除锁定";
					toolBar1.Buttons[18].Enabled =false;
					toolBar1.Buttons[8].Enabled = false;
					
					break;
				case "生成号码":
					if(GetInstanceState("FrmGenCode"))
					{
						return; 
					}
					else
					{
						FrmGenCode fgc = new FrmGenCode();
						fgc.MdiParent = this;
						fgc.Show();
						fgc.Dock = System.Windows.Forms.DockStyle.Top;
					}
					
					break;
				case "现场控制":
					if(GetInstanceState("FrmLocalControl"))
					{
						return;
					}
					else
					{
						FrmLocalControl flc = new FrmLocalControl();
						flc.MdiParent = this;
						flc.Show();
						flc.Dock = System.Windows.Forms.DockStyle.Top;
					}
					break;
				case "号码绑定":
					if(GetInstanceState("FrmSPCZ"))
					{
						return;
					}
					else
					{
						FrmSPCZ fcz = new FrmSPCZ();
						fcz.MdiParent = this;
						fcz.Show();
						fcz.Dock = System.Windows.Forms.DockStyle.Top;
					}
					break;
				case "上传":
					if(GetInstanceState("FrmDataExportAndUp"))
					{
						return;
					}
					else
					{
						FrmDataExportAndUp feau = new FrmDataExportAndUp();
						feau.MdiParent = this;
						feau.Show();
						feau.Dock = System.Windows.Forms.DockStyle.Top;
					}
					break;
				case "信息更新":
////					if(GetInstanceState("FrmProductSet"))
////					{
////						return;
////					}
////					else
////					{
////						FrmProductSet fps = new FrmProductSet();
////						fps.MdiParent = this;
////						fps.Show();
////						fps.Dock = System.Windows.Forms.DockStyle.Top;
//						
//						LoadData();
//						SetDataGrid();
//						
//
////					}
					InsertIntoProductSet();
					InsertIntoZGproduct();
					LoadData();
					SetDataGrid();
					this.lbl_information.Text = "";
					
					
					break;
                //case "异常箱号":
                //    if(GetInstanceState("FrmAddBox"))
                //    {
                //        return;
                //    }
                //    else
                //    {
                //        FrmAddBox fab = new FrmAddBox();
                //        fab.MdiParent = this;
                //        fab.Show();
                //        fab.Dock = System.Windows.Forms.DockStyle.Top;
                //    }
                //    break;
				case "碎瓶重装":
					if(GetInstanceState("FrmSPCZ"))
					{
						return;
					}
					else
					{
						FrmSPCZ fsz = new  FrmSPCZ();
						fsz.MdiParent = this;
						fsz.Show();
						fsz.Dock = System.Windows.Forms.DockStyle.Top;
					}
					break;
				case "查询":
					if(GetInstanceState("FrmDataCheck"))
					{
						return;
					}
					else
					{
						FrmDataCheck fdc = new FrmDataCheck();
						fdc.MdiParent = this;
						fdc.Show();
						fdc.Dock = System.Windows.Forms.DockStyle.Top;
					}
					break;
				case "专供设置":
                    MessageBox.Show("专供设置功能已取消，可以点击信息更新按钮，直接从服务器获得专供信息！");
                    //if(GetInstanceState("FrmZGProduct"))
                    //{
                    //    return;
                    //}
                    //else
                    //{
                    //    FrmZGProduct fzp = new  FrmZGProduct();
                    //    fzp.MdiParent = this;
                    //    fzp.Show();
                    //    fzp.Dock = System.Windows.Forms.DockStyle.Top;
                    //}
					break;
				case "关机":
					if(MessageBox.Show("请确认是否真的要关机？","提示",MessageBoxButtons.YesNo)==DialogResult.Yes)
					{
                        //string lineNo = ConfigurationManager.AppSettings["banzu"].ToString();
						try
						{
                            //string CommandText1 = string.Format("delete from tb_wlineNo where l_lineNo = '{0}'",lineNo);
                            //db.RunDelOrInsertOrUppdateSQL(CommandText1);
							
							this.Close();
							ComputerManager.PowerOff();
						}
						catch
                        {
                            //MessageBox.Show("网络错误！该生产线注册未撤销，请检查网络连接然后重新点击退出，不能强制退出！");
						}
						
						
					}
					break;
				case "重启":
					if(MessageBox.Show("请确认是否真的要重启？","提示",MessageBoxButtons.YesNo)==DialogResult.Yes)
					{
                        //string lineNo = ConfigurationManager.AppSettings["banzu"].ToString();
						try
						{
                            //string CommandText2 = string.Format("delete from tb_wlineNo where l_lineNo = '{0}'",lineNo);
                            //db.RunDelOrInsertOrUppdateSQL(CommandText2);
							this.Close();
							ComputerManager.Reboot();
							
						}
						catch
						{
                            //MessageBox.Show("网络错误！该生产线注册未撤销，请检查网络连接然后重新点击退出，不能强制退出！");
						}
						
					}
					break;
				case "注销":
					if(MessageBox.Show("请确认是否真的要注销？","提示",MessageBoxButtons.YesNo)==DialogResult.Yes)
					{
                        //string lineNo = ConfigurationManager.AppSettings["banzu"].ToString();
						try
						{
                            //string CommandText3 = string.Format("delete from tb_wlineNo where l_lineNo = '{0}'",lineNo);
                            //db.RunDelOrInsertOrUppdateSQL(CommandText3);
							
							this.Close();
							ComputerManager.LogoOff();
						}
						catch
						{
                            //MessageBox.Show("网络错误！该生产线注册未撤销，请检查网络连接然后重新点击退出，不能强制退出！");
						}
						
					}
					break;
				case "端口设置":
					if(GetInstanceState("FrmComSet"))
					{
						return;
					}
					else
					{
						FrmComSet fcs = new FrmComSet();
						fcs.MdiParent = this;
						fcs.Show();
						fcs.Dock = System.Windows.Forms.DockStyle.Top;
					}
					break;
				case "退出":
					this.txt_mimakuang.Visible = true;
					this.toolBar1.Buttons[17].Enabled = true;
					b = true;
					break;
				case "确定":
					try
					{
                        //string CommandText5 = "select passWord from tb_wlineuser";
                        //string passWord = db.RunSelectResultsSQL(CommandText5);
                        string passWord = "11234";
						if(b==true && this.txt_mimakuang.Text.Trim() == passWord)
						{
							this.Closing -= new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
                            this.Close();
							//删除班组号在数据中的注册
                            //string lineNo = ConfigurationManager.AppSettings["banzu"].ToString();
							
                            //try
                            //{
                            //    string CommandText6 = string.Format("delete from tb_wlineNo where l_lineNo = '{0}'",lineNo);
                            //    db.RunDelOrInsertOrUppdateSQL(CommandText6);
                            //    this.Close();
                            //}
                            //catch
                            //{
                            //    MessageBox.Show("网络错误！该生产线注册未撤销，请检查网络连接然后重新点击退出，不能强制退出！");
                            //}
							
						}
                        else if (this.txt_mimakuang.Text.Trim() == passWord)
                        {
                            this.FormBorderStyle = FormBorderStyle.FixedDialog;
                            this.toolBar1.Buttons[15].Text = "锁定计算机";
                            this.txt_mimakuang.Text = "123";
                            this.toolBar1.Buttons[17].Enabled = false;
                            this.txt_mimakuang.Visible = false;
                            toolBar1.Buttons[18].Enabled = true;

                        }
                        else
                        {
                            MessageBox.Show("只有授权人员才可以解除锁定！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
					}
					catch
					{
                        //MessageBox.Show("和服务器的连接失败，请检查网络连接！");
					}
					break;
				case "检索":
					if(GetInstanceState("CheckFileOnMainServer"))
					{
						return;
					}
					else
					{
						CheckFileOnMainServer cfoms = new CheckFileOnMainServer();
						cfoms.MdiParent = this;
						cfoms.Show();
						cfoms.Dock = System.Windows.Forms.DockStyle.Top;
					}
					break;
			}
		}
		#endregion

		#region 向本地数据库插入WebService中的产品设置信息
		private void InsertIntoProductSet()
		{
			try
			{
				DataSet dstnew = new DataSet();
				DataBase db = new DataBase();
				SenInformation.Service1 sif = new  LocalControl.SenInformation.Service1();
				dstnew = sif.SendProductSet();
				int cnt = dstnew.Tables["tb_productset"].Rows.Count;
				if(cnt>0)
				{
					db.RunDelOrInsertOrUppdateSQL("delete from tb_productset");
					for(int i=0;i<cnt;i++)
					{
						string productcode = dstnew.Tables["tb_productset"].Rows[i][1].ToString();
//						string selectS = string.Format("select productcode from tb_productset where productcode = '{0}'",productcode);
//						if(db.RunSelectResultsSQL(selectS)=="")
//						{
							string productname = dstnew.Tables["tb_productset"].Rows[i][2].ToString();
							string insertStr = string.Format("insert into tb_productset values('{0}','{1}')",productcode,productname);
							db.RunDelOrInsertOrUppdateSQL(insertStr);
//						}
					}
				}
			}
			catch
			{}
			
		}
		#endregion

		#region 向本地Info数据库插入WebService中的信息
		private void InsertIntoInfot()
		{
			try
			{
				DataSet dstnew = new DataSet();
				DataBase db = new DataBase();
				SenInformation.Service1 sif = new  LocalControl.SenInformation.Service1();
				dstnew = sif.SenInformation();
				int cnt = dstnew.Tables["serverinfo"].Rows.Count;
				if(cnt>0)
				{
					string deleteStr = "delete from info";
					db.RunDelOrInsertOrUppdateSQL(deleteStr);
					for(int i=0;i<cnt;i++)
					{
						string info = dstnew.Tables["serverinfo"].Rows[i][1].ToString();
						
//						string selectS = string.Format("select info from info where info = '{0}'",info);
//						if(db.RunSelectResultsSQL(selectS)=="")
//						{
							string insertStr = string.Format("insert into info values('{0}','{1}')",info,DateTime.Now.ToString());
							db.RunDelOrInsertOrUppdateSQL(insertStr);
//						}
					}
				}
			}
			catch
			{}
			
		}
		#endregion

		#region 向本地tb_zgproduct数据库插入WebService中的产品设置信息
		private void InsertIntoZGproduct()
		{
			try
			{
				DataSet dstnew = new DataSet();
				DataBase db = new DataBase();
				SenInformation.Service1 sif = new  LocalControl.SenInformation.Service1();
				dstnew = sif.SendZgProduct();
				int cnt = dstnew.Tables["tb_wzgpSet"].Rows.Count;
				if(cnt>0)
				{
					db.RunDelOrInsertOrUppdateSQL("delete from tb_zgproduct");
					for(int i=0;i<cnt;i++)
					{
						string productcode = dstnew.Tables["tb_wzgpSet"].Rows[i][1].ToString();
						string productname = dstnew.Tables["tb_wzgpSet"].Rows[i][2].ToString();
						string salerid = dstnew.Tables["tb_wzgpSet"].Rows[i][3].ToString();
//						string selectS = string.Format("select productcode from tb_zgproduct where productcode = '{0}'",productcode);
//						if(db.RunSelectResultsSQL(selectS)=="")
//						{
							string insertStr = string.Format("insert into tb_zgproduct values('{0}','{1}','{2}')",productcode,productname,salerid);
							db.RunDelOrInsertOrUppdateSQL(insertStr);
//						}
					}
				}
			}
			catch
			{}
			
		}
		#endregion

		#region 新信息提醒
		private void NewInformation()
		{
			try
			{
				while(true)
				{
				
					SenInformation.Service1 sif = new LocalControl.SenInformation.Service1();
					DateTime dt = sif.maxTime();
					DataBase db = new DataBase();
					DateTime localdt = DateTime.Parse(db.RunSelectResultsSQL("select max(infoDate) from info"));
					if(dt>localdt)
					{
						this.lbl_information.Text = "NEW!";
						Thread.Sleep(600000);
						
					}
					
					
					Thread.Sleep(5000);
				}
			}
			catch
			{
				
			}
		}
		#endregion

		#region 设置主控程序运行后的按钮可见性
		private void SetButtonsVisible(bool bState)
		{
			toolBar1.Buttons[2].Enabled = bState;
			toolBar1.Buttons[3].Enabled = bState;
			toolBar1.Buttons[5].Enabled = bState;
//			toolBar1.Buttons[6].Enabled = bState;
			toolBar1.Buttons[7].Enabled = bState;
			toolBar1.Buttons[9].Enabled = bState;
			toolBar1.Buttons[11].Enabled = bState;
		}
		#endregion

		#region 窗体的Closing（）事件
		private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel = true;
		}

		#endregion
		
		#region 截获非法关机
		private void Form1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.Modifiers==Keys.Alt  &&  e.KeyCode==Keys.F4)   
			{   
				MessageBox.Show("不能非法关闭窗口！");  
				
			}
			if(e.KeyCode==Keys.ControlKey && e.Modifiers==Keys.Alt &&  e.KeyCode==Keys.Delete)
			{
				MessageBox.Show("不能非法关闭窗口！");  
				Form1 fm1 = new Form1();
				fm1.ShowDialog();
			}
			
		}

		#endregion

		private void btn_gmima_Click(object sender, System.EventArgs e)//激光线
		{
			if(GetInstanceState("ChangeMima"))
			{
				return;
			}
			else
			{
				ChangeMima fcs = new ChangeMima();
				fcs.MdiParent = this;
				fcs.Show();
				fcs.Dock = System.Windows.Forms.DockStyle.Top;
			}
		}

		private void btn_jiesuo_Click(object sender, System.EventArgs e)
		{
            DataBaseForServer db = new DataBaseForServer();
            try
			{
				string CommandText = "select passWord from tb_wlineUser";
                string passWord = db.RunSelectResultsSQL(CommandText);
				if(this.txt_jiesuo.Text.Trim()==passWord)
				{
					this.toolBar1.Enabled = true;
					this.txt_jiesuo.Visible = false;
					this.btn_jiesuo.Visible = false;
				}
			}
			catch(Exception es)
			{
				MessageBox.Show(es.ToString());
			}
		}

		#region 使输入不起作用 不需要调用
//		protected   override   bool   ProcessCmdKey(ref   Message   msg,Keys   keyData)   
//		{   
//			switch(keyData)   
//			{   
//				case(System.Windows.Forms.Keys)(262144+115):   
//					MessageBox.Show("不能非法关闭窗口！");   
//					break;   
//			}   
//			return  true;   
//		}
		#endregion
	}
}
