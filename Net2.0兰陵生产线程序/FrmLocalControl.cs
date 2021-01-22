using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading;
using System.IO;
using System.Text;
using ComWithImaje;
using PowerData;
using LinxPrinter;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace LocalControl
{
	/// <summary>
	/// 本版本取消了和喷码机的通信。生产开始后，将需要喷印的信息写入数据库中，由喷码机自己调用，然后将喷印成功的号码写入数据库中。
	/// 程序依据此表中的号码顺序和箱号码邦定。
	/// </summary>
	public class FrmLocalControl : System.Windows.Forms.Form
	{
		#region 变量
		
		#region 窗体内的变量
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.ToolBarButton toolBarButton4;
		private string conn_str = ConfigurationManager.AppSettings["sql_connstr"].Trim();
		private string banzu = ConfigurationManager.AppSettings["banzu"].Trim();
		private string _channelalarm = ConfigurationManager.AppSettings["channelalarm"].Trim();
		private string _channelnum = ConfigurationManager.AppSettings["channelnum"].Trim();
		//ComWithImaje.ComToPrint _ctp = new ComToPrint("com2");
		ComPrinter _Cp = null;
//		ComWithImaje.ComToADAM _ctadam = new ComToADAM("com1","01");
//		ComWithImaje.ComToScaner _cts = new ComToScaner("com3");
		ComWithImaje.ComToADAM _ctadam = null;
        //ComWithImaje.ComToScaner _cts = null;
		ComWithImaje.BindQueue _cbQueue = null;
		string _statusInitialize = ConfigurationManager.AppSettings["initialstatus"].Trim();
		ClassLocalControl _clc = null;
		bool _alarmStatus = false;
		bool _systemReset = false;
		string _voltageHigh = "1";
		string _voltageLow = "0";
		Thread _thImaje = null;
		//Thread _thADAM = null;
        //Thread _thScan = null;			
		int _pingCounter = 1;
		private System.Windows.Forms.ComboBox comboBox_productStyle;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox comboBox_productName;
		#endregion
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox_shebeiNo;
		private System.Windows.Forms.TextBox textBox_banzu;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		#region linx变量
		//private string _comm = "com2";
		private string _comm = "";
		
		#endregion
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private System.Windows.Forms.StatusBarPanel statusBarPanel3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton radioButton_normal;
		private System.Windows.Forms.RadioButton radioButton_zhuangong;

		string _salerID = string.Empty;
		string _productID = string.Empty;
		private System.Windows.Forms.ToolBarButton toolBarButton9;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ToolBarButton toolBarButton13;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox comBox_productSeriel;
		private System.Windows.Forms.TextBox txt_leftNoCount;

		private Thread t_LeftNoCount = null;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.PictureBox pictureBox1;

		
		private System.Windows.Forms.TextBox textBox_pihao;
		private System.Windows.Forms.TextBox txt_timeShow;
		private System.Windows.Forms.Label label7;

		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.PictureBox ptb_jindu;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.TextBox txt_gouzaoNo;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Timer timer1;

		private Thread fillPrintThread;
		private System.Windows.Forms.Button button_testPrinter;
		private Thread scanBottleSerial;
		private System.Windows.Forms.Label label11;
		private int bottleSerialNo =0;
		private System.Windows.Forms.Button btn2;
		private System.Windows.Forms.Button btn1;

        //private long abc = 123456789001;
		private System.Windows.Forms.Button button_clearAlartInformation;

		private int countPerBox = 6;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Button btn_Qidong;
        private System.Windows.Forms.Button btn_Jeishu;
		private System.IO.Ports.SerialPort serialPort_Scaner;

		private Process proc = null;
        private string textOfComBox2 = "";
        private TextBox txt_lastPingCode;
        private TextBox txt_boxcode;
        private System.IO.Ports.SerialPort serialPort_Adam;
        private TextBox txt_countOfTP;
        private Label label12;
        private Label lbl_TPCode;
        private string boxCodeLegth = "";
        private string tpCodeLength = "";
        private Hashtable tpCodeHasTable;
        private Label lbl_tpCount;
        private Thread t_tpBind = null;
        //private bool haoMaGouZao = true;
        #endregion

		#region 窗体构造函数
		public FrmLocalControl()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			_clc = new ClassLocalControl();
			_clc.ConnectString = this.conn_str;
			CommonClass._connstr = this.conn_str;
			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}
		#endregion
		
		#region 清理所有正在使用的资源。
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
		#endregion

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLocalControl));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton4 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton9 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton13 = new System.Windows.Forms.ToolBarButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.comboBox_productStyle = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_productName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_shebeiNo = new System.Windows.Forms.TextBox();
            this.textBox_banzu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_pihao = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_tpCount = new System.Windows.Forms.Label();
            this.lbl_TPCode = new System.Windows.Forms.Label();
            this.txt_countOfTP = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btn_Jeishu = new System.Windows.Forms.Button();
            this.btn_Qidong = new System.Windows.Forms.Button();
            this.radioButton_zhuangong = new System.Windows.Forms.RadioButton();
            this.radioButton_normal = new System.Windows.Forms.RadioButton();
            this.btn2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_timeShow = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comBox_productSeriel = new System.Windows.Forms.ComboBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txt_leftNoCount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt_gouzaoNo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btn1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ptb_jindu = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button_testPrinter = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.button_clearAlartInformation = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.serialPort_Scaner = new System.IO.Ports.SerialPort(this.components);
            this.txt_lastPingCode = new System.Windows.Forms.TextBox();
            this.txt_boxcode = new System.Windows.Forms.TextBox();
            this.serialPort_Adam = new System.IO.Ports.SerialPort(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_jindu)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox1.ForeColor = System.Drawing.Color.Lime;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(0, 236);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(1213, 292);
            this.listBox1.TabIndex = 0;
            // 
            // toolBar1
            // 
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.toolBarButton1,
            this.toolBarButton4,
            this.toolBarButton9,
            this.toolBarButton13});
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.imageList1;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(1213, 41);
            this.toolBar1.TabIndex = 1;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.ImageIndex = 0;
            this.toolBarButton1.Name = "toolBarButton1";
            this.toolBarButton1.Text = "喷码开始";
            this.toolBarButton1.ToolTipText = "先点击喷码开始或监控开始，对系统没有影响";
            // 
            // toolBarButton4
            // 
            this.toolBarButton4.ImageIndex = 2;
            this.toolBarButton4.Name = "toolBarButton4";
            this.toolBarButton4.Text = "监控开始";
            // 
            // toolBarButton9
            // 
            this.toolBarButton9.ImageIndex = 7;
            this.toolBarButton9.Name = "toolBarButton9";
            this.toolBarButton9.Text = "清空箱数";
            this.toolBarButton9.Visible = false;
            // 
            // toolBarButton13
            // 
            this.toolBarButton13.ImageIndex = 10;
            this.toolBarButton13.Name = "toolBarButton13";
            this.toolBarButton13.Text = "退出";
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
            // 
            // comboBox_productStyle
            // 
            this.comboBox_productStyle.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "40"});
            this.comboBox_productStyle.Location = new System.Drawing.Point(104, 24);
            this.comboBox_productStyle.Name = "comboBox_productStyle";
            this.comboBox_productStyle.Size = new System.Drawing.Size(56, 20);
            this.comboBox_productStyle.TabIndex = 2;
            this.comboBox_productStyle.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "产品规格：1x";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(384, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "产品名称";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBox_productName
            // 
            this.comboBox_productName.Location = new System.Drawing.Point(448, 24);
            this.comboBox_productName.Name = "comboBox_productName";
            this.comboBox_productName.Size = new System.Drawing.Size(256, 20);
            this.comboBox_productName.TabIndex = 7;
            this.comboBox_productName.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(8, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "生产日期";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarForeColor = System.Drawing.Color.DarkGreen;
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(104, 56);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(88, 21);
            this.dateTimePicker1.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(200, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 23);
            this.label4.TabIndex = 10;
            this.label4.Text = "设备号";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox_shebeiNo
            // 
            this.textBox_shebeiNo.Location = new System.Drawing.Point(256, 56);
            this.textBox_shebeiNo.Name = "textBox_shebeiNo";
            this.textBox_shebeiNo.ReadOnly = true;
            this.textBox_shebeiNo.Size = new System.Drawing.Size(56, 21);
            this.textBox_shebeiNo.TabIndex = 11;
            // 
            // textBox_banzu
            // 
            this.textBox_banzu.Location = new System.Drawing.Point(376, 56);
            this.textBox_banzu.Name = "textBox_banzu";
            this.textBox_banzu.Size = new System.Drawing.Size(48, 21);
            this.textBox_banzu.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(320, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 23);
            this.label5.TabIndex = 12;
            this.label5.Text = "班组号";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox_pihao
            // 
            this.textBox_pihao.Location = new System.Drawing.Point(480, 56);
            this.textBox_pihao.Name = "textBox_pihao";
            this.textBox_pihao.Size = new System.Drawing.Size(64, 21);
            this.textBox_pihao.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(440, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 23);
            this.label6.TabIndex = 14;
            this.label6.Text = "批号";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 214);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2,
            this.statusBarPanel3});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(1213, 22);
            this.statusBar1.SizingGrip = false;
            this.statusBar1.TabIndex = 16;
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Text = "箱数";
            this.statusBarPanel1.Width = 40;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.statusBarPanel2.Name = "statusBarPanel2";
            // 
            // statusBarPanel3
            // 
            this.statusBarPanel3.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.statusBarPanel3.Name = "statusBarPanel3";
            this.statusBarPanel3.Width = 1073;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_tpCount);
            this.groupBox1.Controls.Add(this.lbl_TPCode);
            this.groupBox1.Controls.Add(this.txt_countOfTP);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.btn_Jeishu);
            this.groupBox1.Controls.Add(this.btn_Qidong);
            this.groupBox1.Controls.Add(this.radioButton_zhuangong);
            this.groupBox1.Controls.Add(this.radioButton_normal);
            this.groupBox1.Controls.Add(this.btn2);
            this.groupBox1.ForeColor = System.Drawing.Color.DarkGreen;
            this.groupBox1.Location = new System.Drawing.Point(8, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(912, 48);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // lbl_tpCount
            // 
            this.lbl_tpCount.AutoSize = true;
            this.lbl_tpCount.Location = new System.Drawing.Point(845, 22);
            this.lbl_tpCount.Name = "lbl_tpCount";
            this.lbl_tpCount.Size = new System.Drawing.Size(47, 12);
            this.lbl_tpCount.TabIndex = 30;
            this.lbl_tpCount.Text = "label13";
            // 
            // lbl_TPCode
            // 
            this.lbl_TPCode.AutoSize = true;
            this.lbl_TPCode.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_TPCode.ForeColor = System.Drawing.Color.Crimson;
            this.lbl_TPCode.Location = new System.Drawing.Point(754, 17);
            this.lbl_TPCode.Name = "lbl_TPCode";
            this.lbl_TPCode.Size = new System.Drawing.Size(79, 20);
            this.lbl_TPCode.TabIndex = 29;
            this.lbl_TPCode.Text = "1234567";
            this.lbl_TPCode.Click += new System.EventHandler(this.lbl_TPCode_Click);
            // 
            // txt_countOfTP
            // 
            this.txt_countOfTP.Location = new System.Drawing.Point(722, 15);
            this.txt_countOfTP.Name = "txt_countOfTP";
            this.txt_countOfTP.Size = new System.Drawing.Size(29, 21);
            this.txt_countOfTP.TabIndex = 28;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(655, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 27;
            this.label12.Text = "每托盘箱数";
            // 
            // btn_Jeishu
            // 
            this.btn_Jeishu.Location = new System.Drawing.Point(560, 16);
            this.btn_Jeishu.Name = "btn_Jeishu";
            this.btn_Jeishu.Size = new System.Drawing.Size(88, 23);
            this.btn_Jeishu.TabIndex = 26;
            this.btn_Jeishu.Text = "结束喷码程序";
            this.btn_Jeishu.Visible = false;
            this.btn_Jeishu.Click += new System.EventHandler(this.btn_Jeishu_Click);
            // 
            // btn_Qidong
            // 
            this.btn_Qidong.Location = new System.Drawing.Point(464, 16);
            this.btn_Qidong.Name = "btn_Qidong";
            this.btn_Qidong.Size = new System.Drawing.Size(88, 23);
            this.btn_Qidong.TabIndex = 25;
            this.btn_Qidong.Text = "启动喷码程序";
            this.btn_Qidong.Visible = false;
            this.btn_Qidong.Click += new System.EventHandler(this.btn_Qidong_Click);
            // 
            // radioButton_zhuangong
            // 
            this.radioButton_zhuangong.Location = new System.Drawing.Point(104, 16);
            this.radioButton_zhuangong.Name = "radioButton_zhuangong";
            this.radioButton_zhuangong.Size = new System.Drawing.Size(80, 24);
            this.radioButton_zhuangong.TabIndex = 1;
            this.radioButton_zhuangong.Text = "专供酒";
            this.radioButton_zhuangong.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton_normal
            // 
            this.radioButton_normal.Location = new System.Drawing.Point(16, 16);
            this.radioButton_normal.Name = "radioButton_normal";
            this.radioButton_normal.Size = new System.Drawing.Size(80, 24);
            this.radioButton_normal.TabIndex = 0;
            this.radioButton_normal.Text = "普通酒";
            this.radioButton_normal.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // btn2
            // 
            this.btn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn2.ForeColor = System.Drawing.Color.DarkGreen;
            this.btn2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn2.ImageIndex = 8;
            this.btn2.ImageList = this.imageList1;
            this.btn2.Location = new System.Drawing.Point(192, 16);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(264, 24);
            this.btn2.TabIndex = 24;
            this.btn2.Text = "查询产品名称，系统支持全文模糊查询。";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_timeShow);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.comBox_productSeriel);
            this.groupBox2.Controls.Add(this.comboBox_productStyle);
            this.groupBox2.Controls.Add(this.textBox_banzu);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBox_pihao);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.comboBox_productName);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBox_shebeiNo);
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.ForeColor = System.Drawing.Color.DarkGreen;
            this.groupBox2.Location = new System.Drawing.Point(8, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(712, 96);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            // 
            // txt_timeShow
            // 
            this.txt_timeShow.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txt_timeShow.Location = new System.Drawing.Point(624, 56);
            this.txt_timeShow.Name = "txt_timeShow";
            this.txt_timeShow.ReadOnly = true;
            this.txt_timeShow.Size = new System.Drawing.Size(72, 21);
            this.txt_timeShow.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Location = new System.Drawing.Point(176, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 23);
            this.label9.TabIndex = 16;
            this.label9.Text = "产品系列";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comBox_productSeriel
            // 
            this.comBox_productSeriel.Items.AddRange(new object[] {
            "34",
            "36",
            "38",
            "39",
            "40.5",
            "40",
            "41",
            "42",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "60",
            "61",
            "62",
            "65"});
            this.comBox_productSeriel.Location = new System.Drawing.Point(240, 24);
            this.comBox_productSeriel.Name = "comBox_productSeriel";
            this.comBox_productSeriel.Size = new System.Drawing.Size(136, 20);
            this.comBox_productSeriel.TabIndex = 17;
            this.comBox_productSeriel.TextChanged += new System.EventHandler(this.comBox_productSeriel_TextChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(584, 48);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.TabIndex = 28;
            this.pictureBox2.TabStop = false;
            // 
            // txt_leftNoCount
            // 
            this.txt_leftNoCount.Enabled = false;
            this.txt_leftNoCount.Location = new System.Drawing.Point(96, 32);
            this.txt_leftNoCount.Name = "txt_leftNoCount";
            this.txt_leftNoCount.Size = new System.Drawing.Size(72, 21);
            this.txt_leftNoCount.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.ForeColor = System.Drawing.Color.DarkGreen;
            this.label8.Location = new System.Drawing.Point(24, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 16);
            this.label8.TabIndex = 20;
            this.label8.Text = "原始瓶号：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txt_gouzaoNo);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txt_leftNoCount);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.ForeColor = System.Drawing.Color.DarkGreen;
            this.groupBox3.Location = new System.Drawing.Point(728, 88);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(192, 96);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "剩余号码";
            // 
            // txt_gouzaoNo
            // 
            this.txt_gouzaoNo.Enabled = false;
            this.txt_gouzaoNo.Location = new System.Drawing.Point(96, 64);
            this.txt_gouzaoNo.Name = "txt_gouzaoNo";
            this.txt_gouzaoNo.Size = new System.Drawing.Size(72, 21);
            this.txt_gouzaoNo.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.ForeColor = System.Drawing.Color.DarkGreen;
            this.label10.Location = new System.Drawing.Point(24, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 16);
            this.label10.TabIndex = 22;
            this.label10.Text = "可用瓶号：";
            // 
            // btn1
            // 
            this.btn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn1.ForeColor = System.Drawing.Color.DarkGreen;
            this.btn1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn1.ImageIndex = 8;
            this.btn1.ImageList = this.imageList1;
            this.btn1.Location = new System.Drawing.Point(200, 8);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(163, 32);
            this.btn1.TabIndex = 18;
            this.btn1.Text = "请先点击监控开始！";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(448, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(472, 32);
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(16, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(280, 23);
            this.label7.TabIndex = 25;
            // 
            // ptb_jindu
            // 
            this.ptb_jindu.Image = ((System.Drawing.Image)(resources.GetObject("ptb_jindu.Image")));
            this.ptb_jindu.Location = new System.Drawing.Point(304, 192);
            this.ptb_jindu.Name = "ptb_jindu";
            this.ptb_jindu.Size = new System.Drawing.Size(216, 16);
            this.ptb_jindu.TabIndex = 27;
            this.ptb_jindu.TabStop = false;
            this.ptb_jindu.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // button_testPrinter
            // 
            this.button_testPrinter.Location = new System.Drawing.Point(720, 192);
            this.button_testPrinter.Name = "button_testPrinter";
            this.button_testPrinter.Size = new System.Drawing.Size(104, 23);
            this.button_testPrinter.TabIndex = 28;
            this.button_testPrinter.Text = "模拟喷码机工作";
            this.button_testPrinter.Click += new System.EventHandler(this.button3_Click);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(840, 192);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 23);
            this.label11.TabIndex = 29;
            // 
            // button_clearAlartInformation
            // 
            this.button_clearAlartInformation.Location = new System.Drawing.Point(528, 192);
            this.button_clearAlartInformation.Name = "button_clearAlartInformation";
            this.button_clearAlartInformation.Size = new System.Drawing.Size(112, 24);
            this.button_clearAlartInformation.TabIndex = 30;
            this.button_clearAlartInformation.Text = "清除报警消息";
            this.button_clearAlartInformation.Click += new System.EventHandler(this.button1_Click_3);
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Control;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.ForeColor = System.Drawing.Color.Red;
            this.textBox4.Location = new System.Drawing.Point(664, 200);
            this.textBox4.MaxLength = 327670;
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(24, 8);
            this.textBox4.TabIndex = 31;
            // 
            // serialPort_Scaner
            // 
            this.serialPort_Scaner.PortName = "COM2";
            this.serialPort_Scaner.ReceivedBytesThreshold = 7;
            this.serialPort_Scaner.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_Scaner_DataReceived);
            // 
            // txt_lastPingCode
            // 
            this.txt_lastPingCode.Font = new System.Drawing.Font("宋体", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_lastPingCode.Location = new System.Drawing.Point(936, 110);
            this.txt_lastPingCode.Name = "txt_lastPingCode";
            this.txt_lastPingCode.Size = new System.Drawing.Size(254, 99);
            this.txt_lastPingCode.TabIndex = 32;
            this.txt_lastPingCode.Text = "123456";
            // 
            // txt_boxcode
            // 
            this.txt_boxcode.Font = new System.Drawing.Font("宋体", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_boxcode.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txt_boxcode.Location = new System.Drawing.Point(936, 11);
            this.txt_boxcode.Name = "txt_boxcode";
            this.txt_boxcode.Size = new System.Drawing.Size(254, 99);
            this.txt_boxcode.TabIndex = 33;
            this.txt_boxcode.Text = "123456";
            // 
            // FrmLocalControl
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1213, 528);
            this.Controls.Add(this.txt_boxcode);
            this.Controls.Add(this.txt_lastPingCode);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.button_clearAlartInformation);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.button_testPrinter);
            this.Controls.Add(this.ptb_jindu);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.toolBar1);
            this.Controls.Add(this.listBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmLocalControl";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "微派科技现场控制系统";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FrmLocalControl_Closing);
            this.Load += new System.EventHandler(this.FrmLocalControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_jindu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region 观察tb_bindcnt的数据
		private void GetBoxCount()
		{
			try
			{
				string ndate = DateTime.Now.ToString("yyyy-MM-dd");
                //string command = string.Format("select * from tb_bindcnt where in_date='{0}'",ndate);
                string command = string.Format("select * from tb_bindcnt");//20111008wangjb.绑定数量应该在数据上传后删除，不应该：判断不是当日的产量就将其删除
				DataSet ds = CommonClass.ExecuteDataSet(command,"tb_bindcnt");
				DataTable dt = ds.Tables["tb_bindcnt"];
				if(dt.Rows.Count>0)
				{
						SetStatusBar(dt.Rows[0]["in_cnt"].ToString());					
				}
				else
				{
					string cmd = "delete from tb_bindcnt";
					CommonClass.ExcuteNonQuery(cmd);
					SetStatusBar("0");
				}
			}
            catch (Exception es)
            {
                ErrMsgInsert(es.Message);
                SetStatusBar("0");

			}
		}
		#endregion

		
        #region 窗体初始化 读取串口设置信息、初始化喷码机和条码枪并启动线程、从tb_jiustyle获取上次生产时的酒是普通酒还是专供酒，并显示相应的酒名称。如果tb_status有保存的上次生产信息，则将相应的具体信息填写到对应的box中。从tb_bind中获取箱的数量。

		private void FrmLocalControl_Load(object sender, System.EventArgs e)
		{
			try
			{
                

                t_LeftNoCount = new Thread(new ThreadStart(InvokeLeftNoCount));
				t_LeftNoCount.IsBackground = true;
                //t_LeftNoCount.Start();
                

                boxCodeLegth = ConfigurationManager.AppSettings["boxCodeLength"];
                tpCodeLength = ConfigurationManager.AppSettings["tpCodeLength"];
				string command_1 = "select * from com_set";
				DataSet ds = CommonClass.ExecuteDataSet(command_1,"com_set");
				DataTable dt = ds.Tables["com_set"];
                if (dt.Rows.Count > 0)
                {
                    string scanCom = dt.Rows[0]["scancom"].ToString();
                    string adamCom = dt.Rows[0]["adamcom"].ToString();
                    string printCom = dt.Rows[0]["printcom"].ToString();
                    this._ctadam = new ComToADAM(this.serialPort_Adam, "01");
                    //this._cts = new ComToScaner(scanCom);
                    this._comm = printCom;
                    //取消了和喷码机的通信
                    //					_Cp = new ComPrinter(this._comm,this._settings,this._iPtr,this._timeout,this._eor);
                    //					if(_Cp.OpenCom())
                    //					{
                    //						listBox1.Items.Add("喷码机初始化成功");
                    //					}
                    //					else
                    //						listBox1.Items.Add("喷码机初始化失败");

                    //取消了以前的条码枪初始化方法
                    //if (this._cts.InitScaner())
                    //{
                    //    listBox1.Items.Add("条码枪初始化成功");
                    //    if (this._thScan == null)
                    //    {
                    //        _thScan = new Thread(new ThreadStart(DoScan));
                    //        _thScan.Start();
                    //    }
                    //}
                    serialPort_Scaner.PortName = scanCom;
                    if (!serialPort_Scaner.IsOpen)
                    {
                        try
                        {
                            serialPort_Scaner.Open();
                            listBox1.Items.Add(scanCom + "条码枪初始化成功！");
                        }
                        catch (Exception es)
                        {
                            SetText(es.Message);
                        }
                    }
                    int i_style = GetJiuStyle();
                    if (i_style == 0)//普通酒
                    {
                        radioButton_normal.Checked = true;
                        AddProductName();
                        this._salerID = string.Empty;
                        this._productID = string.Empty;
                    }
                    else
                    {
                        radioButton_zhuangong.Checked = true;
                        AddZGProductName();
                    }
                    //察看状态表，是否有上次的保存信息
                    FillStatus();
                }
                else
                {
                    MessageBox.Show("请首先进行端口设置");
                }
                GetBoxCount();//如果tb_bindCnt表里有数据，则将绑定的数量显示在窗口，否则"delete from tb_bindcnt
				//radioButton1.Checked = true;
				//statusBar1.Panels[1].Text = "0";

                this.timer1.Start();
				
			}
            catch (Exception es)
            {
                ErrMsgInsert(es.Message);
                MessageBox.Show(es.ToString());
			}
		}
		#endregion

		#region 验证箱号码是否重复
		private bool UniqueBox(string bCode)
		{
			bool result = false;
            try
            {
                int cnt = -1;
                //				string delCommand = string.Format("delete from tb_bottle where barcode='{0}'",bottleCode);				
                //				result = _clc.DeleteBottleCode(delCommand);
                string selCommand = string.Format("select count(boxcode) as cnt from tb_bind where boxcode='{0}'", bCode);
                DataSet ds = _clc.ExecuteDataSet(selCommand, "tb_bind");
                DataTable dt = ds.Tables["tb_bind"];
                if (dt.Rows.Count > 0)
                {
                    cnt = int.Parse(dt.Rows[0]["cnt"].ToString());
                }
                result = ((cnt == 0) ? true : false);
            }
            catch (Exception es)
            {
                ErrMsgInsert(es.Message);
            }
			return result;
		}
		#endregion

		#region 条码枪扫描线程 该线程已经取消。目前条码枪的扫描用serialPort控件的DataRecieve事件
        //private void DoScan()
        //{
        //    while(true)
        //    {
        //        try
        //        {
        //            byte[] by = _cts.ReadByte;
        //            if(by!=null)
        //            {
        //                if(by.Length>0)
        //                {
        //                    int rLen = 0;
        //                    string box = System.Text.Encoding.ASCII.GetString(by).Trim();
        //                    for(int i=0;i<box.Length;i++)
        //                    {
        //                        if((box[i]>='0')&&(box[i]<='9'))
        //                        {
        //                            continue;
        //                        }
        //                        else
        //                        {
        //                            rLen = i;
        //                            break;
        //                        }
        //                    }
        //                    box = box.Substring(0,rLen);
        //                    if(box.Length==12)
        //                    {
        //                        if(UniqueBox(box))
        //                        {
        //                            WriteBoxToQueue(box);
        //                            string bindStr = GetBindString();
        //                            if(bindStr.ToLower()!="null")
        //                            {
        //                                int n = WriteBindStrToDB(bindStr,comboBox_productName.Text.Trim());//所有的酒绑定数据都写入tb_bind
        //                                if(n>0)
        //                                {
        //                                    if(radioButton_zhuangong.Checked)//如果是专供酒，则向专供酒表tb_zgbox中写入箱号
        //                                    {
        //                                        WriteZGBox(box);
        //                                    }
        //                                }
        //                                SetText("绑定数据："+bindStr);
        //                                ScanAlarm();
        //                                int m_cnt = int.Parse(statusBar1.Panels[1].Text.Trim())+1;
        //                                statusBar1.Panels[1].Text = m_cnt.ToString();
        //                            }
        //                        }
        //                    }
        //                }						
        //            }					
        //        }
        //        catch (Exception es)
        //        {
        //            ErrMsgInsert(es.Message);
        //            break;
        //        }
        //    }
        //    SetText("条码枪线程退出");
        //}
		#endregion

		#region 将专供酒的箱号写入数据库内
		private void WriteZGBox(string boxcode)
		{
			try
			{
				string command = string.Format("insert into tb_zgbox(salerid,productid,in_date,boxcode,thd) values('{0}','{1}','{2}','{3}','{4}')",this._salerID,this._productID,DateTime.Now.ToString("yyyy-MM-dd"),boxcode,DateTime.Now.ToString("yyyyMMddHHmmss"));
				CommonClass.ExcuteNonQuery(command);
			}
            catch (Exception es)
            {
                ErrMsgInsert(es.Message);
                return;
			}
		}
		#endregion

		#region 获取上次酒的类型
		private int GetJiuStyle()
		{
			int result = 0;
			try
			{
				string command = "select * from tb_jiustyle";				
                DataTable dt =	ExecuteTable(command,"tb_jiustyle");
				if(dt.Rows.Count>0)
				{
					result = int.Parse(dt.Rows[0]["jiustyle"].ToString());
					this._salerID = dt.Rows[0]["salerID"].ToString();
					this._productID = dt.Rows[0]["productid"].ToString();
				}
				else
				{
					result = 0;
					this._salerID = string.Empty;
					this._productID = string.Empty;
				}
			}
            catch (Exception es)
            {
                ErrMsgInsert(es.Message);
                
			}
			return result;
		}
		#endregion

		#region 向comboBox内添加产品名称
		private void AddProductName()
		{
			comboBox_productName.Items.Clear();
			string command = "select distinct productname from tb_productset";
			string tableName = "tb_productset";
			DataTable dt = ExecuteTable(command,tableName);
			if(dt.Rows.Count>0)
			{				
				for(int i=0;i<dt.Rows.Count;i++)
				{
					comboBox_productName.Items.Add(dt.Rows[i]["productname"]).ToString();
				}
				dt.Clear();		
			}
		}
		#endregion

		#region 向comboBox内添加专供产品名称
		private void AddZGProductName()
		{
			comboBox_productName.Items.Clear();
			string command = "select distinct productname from tb_zgproduct";
			string tableName = "tb_zgproduct";
			DataTable dt = ExecuteTable(command,tableName);
			if(dt.Rows.Count>0)
			{				
				for(int i=0;i<dt.Rows.Count;i++)
				{
					comboBox_productName.Items.Add(dt.Rows[i]["productname"]).ToString();
				}
				dt.Clear();		
			}
		}
		#endregion

		#region 向窗体内填写相应的信息
		private void FillStatus()
		{
			string command = "select * from tb_status";
			DataSet ds = CommonClass.ExecuteDataSet(command,"tb_status");
			DataTable dt =ds.Tables["tb_status"];
			if(dt.Rows.Count>0)
			{
				string c_cnt = dt.Rows[0]["c_cnt"].ToString();
				string product = dt.Rows[0]["product"].ToString();
//				string banzu = dt.Rows[0]["banzu"].ToString();
				string label = dt.Rows[0]["label"].ToString();
				string pinguan = dt.Rows[0]["pinguan"].ToString();
				comboBox_productStyle.SelectedIndex = comboBox_productStyle.Items.IndexOf(c_cnt);
				comboBox_productName.SelectedIndex = comboBox_productName.Items.IndexOf(product);
				textBox_shebeiNo.Text = banzu;
				textBox_banzu.Text = label;
				textBox_pihao.Text = pinguan;
			}
			dt.Clear();
			ds.Clear();
		}
		#endregion

		#region 操作入口

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			string txtButton = e.Button.Text;
			switch(txtButton)
			{
				case "喷码开始":
					
					PrintOn();
					break;
				case "监控开始":
					MonitorOn();
					break;
//				case "数据查询"://数据查询功能上移到了主窗体中，由于号码生成已经修改可确保唯一，因此，清空箱数的功能取消了
//					CheckDT();
//					break;
//				case "清空箱数":
//					if(MessageBox.Show("请确认是否真的清除箱数?","友情提示",MessageBoxButtons.YesNo)==DialogResult.Yes)
//					{
//						ClearBoxNum();
//					}
//					break;
				case "退出":
					this.pictureBox1.Visible = false;
					DataBase db = new DataBase();
					db.RunDelOrInsertOrUppdateSQL("delete from bottleSerial");
                    if (scanBottleSerial != null)
                    {
                        scanBottleSerial.Abort();
                    }
					this.Close();
                    this.Dispose();
					break;
//				case "系统复位":
//					SystemInit();
//					break;
				default:
					break;

			}
			//textBox1.Focus();
		}

		#endregion

		#region 清空箱数
		private void ClearBoxNum()
		{
//			try
//			{
//				string cmd = "delete from tb_bindcnt";
//				CommonClass.ExcuteNonQuery(cmd);
//				statusBar1.Panels[1].Text = "0";
//			}
//			catch
//			{
//			}
		}
		#endregion

		#region 数据查询
		private void CheckDT()
		{
			FrmDataCheck fdc = new FrmDataCheck();
			fdc.ShowDialog();
		}
		#endregion

		#region 系统复位
//		private void SystemInit()
//		{
//			try
//			{
//				if(_cbQueue!=null)
//				{
//					_cbQueue.Clear();
//				}	
//				listBox1.Items.Clear();
//				if(this._ctp.InitPrint())
//				{
//					listBox1.Items.Add("喷码机初始化成功");
//					if(PrintBottleCode())
//					{
//						ModifyParam();
//					}
//					else
//					{
//						MessageBox.Show("数据库内已经没有号码");
//					}
//				}
//				else
//					listBox1.Items.Add("喷码机初始化失败");				
//				this._systemReset = true;
//				this._pingCounter = 0;													
//			}
//			catch
//			{
//			}
//		}
		#endregion

		#region 监控开始

		private void MonitorOn()
        {
            #region 已废弃的原始代码
            //if (this._ctadam.InitADAM4055())
            //{
            //    //此行在原版本中也是被注释掉的				this._thADAM = new Thread(new ThreadStart(PoolADAM));
            //    //此行在原版本中也是被注释掉的				_thADAM.Start();
            //    toolBar1.Buttons[1].Enabled = false;

            //}
            //else
            //{
            //    listBox1.Items.Add("模块监控失败");
            //}
            #endregion
            try
            {
                try
                {
                    string command_1 = "select * from com_set";
                    DataSet ds = CommonClass.ExecuteDataSet(command_1, "com_set");
                    DataTable dt = ds.Tables["com_set"];
                    if (dt.Rows.Count > 0)
                    {
                        string adamCom = dt.Rows[0]["adamcom"].ToString();
                        serialPort_Adam.PortName = adamCom;
                        if (serialPort_Adam.IsOpen)
                        {
                            serialPort_Adam.Close();
                            Thread.Sleep(1000);
                            serialPort_Adam.Open();
                            if (serialPort_Adam.IsOpen)
                            {
                                SetText("监控模块打开成功！");
                            }
                        }
                        else
                        {
                            serialPort_Adam.Open();
                            if (serialPort_Adam.IsOpen)
                            {
                                toolBar1.Buttons[1].Enabled = false;
                                SetText("监控模块打开成功！");
                            }

                        }
                    }
                }
                catch (Exception es)
                {
                    MessageBox.Show(es.Message);
                }
            }
            catch
            {

            }
		}
		#endregion

		#region 轮循监控过程已废弃
		private void PoolADAM()
		{
			while(true)
			{
				try
				{
					if(!this._systemReset)
					{
						string statusA = GetADAMStatus();
						//Thread.Sleep(50);
						//string statusB = GetADAMStatus();
						//WriteInfo(statusA);
						if(statusA!=this._statusInitialize)
						{
							//						Thread.Sleep(500);
							//						string statusC = GetADAMStatus();
							//						if(statusC==statusA)
							//						{
							if(!_alarmStatus)
							{
								if(AlarmON(this._channelalarm))//报警
								{
									this._alarmStatus = true;
									//listBox1.Items.Add(statusA);
									//WriteInfo(statusA);
								}
								else
									break;
							}
							//						}
						}
						else
						{
							if(this._alarmStatus)
							{
								if(AlarmOFF(this._channelalarm))
								{
									this._alarmStatus = false;									
								}
								else
									break;
							}
						}
					}
					else
					{
						if(this._alarmStatus)
						{
							if(AlarmOFF(this._channelalarm))
							{
								this._alarmStatus = false;
							}
							else
								break;
						}
						this._systemReset = false;
					}
					Thread.Sleep(1000);
				}
                catch (Exception es)
                {
                    ErrMsgInsert(es.Message);
                    break;
				}
			}
			SetText("监控已经终止");
		}
		#endregion

		#region 报警 
        private bool AlarmON(string channel)
        {

            bool result = false;
            try
            {
                Monitor.Enter(_ctadam);
                _ctadam.WriteDataOutCommand(channel, this._voltageHigh);
                result = _ctadam.DataOutState;
            }
            catch (Exception es)
            {
                ErrMsgInsert(es.Message);
                MessageBox.Show(es.ToString());
            }
            finally
            {
                Monitor.Exit(_ctadam);
            }
            return result;
        }
		#endregion

		#region ExecuteTable
		private DataTable ExecuteTable(string command,string tableName)
		{
			DataTable result = null;
			try
			{
				DataSet ds = _clc.ExecuteDataSet(command,tableName);
				result = ds.Tables[tableName];								
			}
            catch (Exception es)
            {
                ErrMsgInsert(es.Message);
                MessageBox.Show(es.ToString());
			}
			return result;
		}
		#endregion

		#region 关闭报警
		private bool AlarmOFF(string channel)
		{			
			bool result = false;			
			try
			{
				Monitor.Enter(_ctadam);
				_ctadam.WriteDataOutCommand(channel,this._voltageLow);
				result = _ctadam.DataOutState;
			}
            catch (Exception es)
            {
                ErrMsgInsert(es.Message);
                
			}
			finally
			{
				Monitor.Exit(_ctadam);
			}
			return result;
		}
		#endregion

		#region 获取模块的状态
		private string GetADAMStatus()
		{
			string result = "";
            try
            {
                Monitor.Enter(_ctadam);
                if (_ctadam.WriteDataInCommand())
                {
                    result = _ctadam.DataInState;
                }
            }
            catch (Exception es)
            {
                ErrMsgInsert(es.Message);
            }
			finally
			{
				Monitor.Exit(_ctadam);
			}
			return result;
		}
		#endregion

		#region 状态确认  未用
		private bool VerifyStatus()
		{
			bool result = false;
            try
            {
                string status1 = GetADAMStatus();
                Thread.Sleep(5);
                string status2 = GetADAMStatus();
                result = ((status1 == status2) ? true : false);
            }
            catch (Exception es)
            {
                ErrMsgInsert(es.Message);
            }
			return result;

		}
		#endregion

		#region 喷码开始

        private void PrintOn()//点击“喷码开始”按钮后调用的唯一函数
        {

            if (comboBox_productStyle.Text.Trim().Length > 0 && comboBox_productName.Text.Trim().Length > 0 && txt_countOfTP.Text.Trim().Length > 0)
            {
                #region 检查程序界面需要填写的信息是否完整
                string locBz = textBox_shebeiNo.Text.Trim();
                if (locBz.Length != 2)
                {
                    MessageBox.Show("设备号必须是2位数字");
                    return;
                }
                else
                {
                    try
                    {
                        int ibz = int.Parse(locBz);
                    }
                    catch
                    {
                        MessageBox.Show("班组必须是2位数字");
                        return;
                    }
                }

                string loctby = textBox_banzu.Text.Trim();
                if (loctby.Length != 2)
                {
                    MessageBox.Show("班组号必须是2位数字");
                    return;
                }
                else
                {
                    try
                    {
                        int ibz = int.Parse(loctby);
                    }
                    catch
                    {
                        MessageBox.Show("班组号必须是2位数字");
                        return;
                    }
                }


                string locpgh = textBox_pihao.Text.Trim();
                if (locpgh.Length != 4)
                {
                    MessageBox.Show("批号必须是4位数字");
                    return;
                }
                else
                {
                    try
                    {
                        int ibz = int.Parse(locpgh);
                    }
                    catch
                    {
                        MessageBox.Show("批号必须是4位数字");
                        return;
                    }
                }
                int i_style = 0;
                if (radioButton_normal.Checked)
                {
                    this._salerID = string.Empty;
                    this._productID = string.Empty;
                    i_style = 0;
                }
                else
                {
                    if (radioButton_zhuangong.Checked)
                    {
                        i_style = 1;
                    }
                }
                #endregion

                #region 将酒是普通酒还是专供酒类型写入数据库表tb_jiuStyle中.将酒的详细信息写入tb_status中
                InsertJiuStyle(i_style);//将酒是普通酒还是专供酒类型写入数据库表tb_jiuStyle中
                InsertStatus(comboBox_productStyle.Text, comboBox_productName.Text, locBz, loctby, locpgh);//将酒的详细信息写入tb_status中
                countPerBox = int.Parse(comboBox_productStyle.Text.ToString().Trim());
                #endregion

                #region 设置控件的Eanble属性
                textBox_shebeiNo.Enabled = false;
                textBox_banzu.Enabled = false;
                textBox_pihao.Enabled = false;
                comboBox_productName.Enabled = false;
                radioButton_normal.Enabled = false;
                radioButton_zhuangong.Enabled = false;
                this.comBox_productSeriel.Enabled = false;
                dateTimePicker1.Enabled = false;
                #endregion



                #region  检查号码生成日期和号码数量,在列表框中提示相应信息
                DataBase db = new DataBase();
                string o_dt = db.RunSelectResultsSQL("select g_date from tb_glog");//号码生成日期
                int noCount = db.RunSelectCountSQL("select count(*) from tb_bottle");
                int okNoCount = db.RunSelectCountSQL("select count(bottleCode) from tb_thirdline where selected_flag =0");
                this.listBox1.Items.Add("号码库报告：");
                this.listBox1.Items.Add("原始号码数量：" + noCount);
                this.listBox1.Items.Add("原始号码生成日期：" + o_dt);
                this.listBox1.Items.Add("已经构造好，可供生产使用的号码数量：" + okNoCount);
                this.listBox1.Items.Add("如果要重新生成号码，请运行号码生成程序！");
                //号码生成日期和号码数量检查结束
                #endregion

                #region 询问是否要正式生产，若选择是，则判断原始瓶号表中是否有号码，若有，则进行构造号码，完毕后扫描发送给喷码机的号码并写入队列。若选择否，则等待。
                if (MessageBox.Show("要开始正式生产吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    textOfComBox2 = comboBox_productName.Text;
                    #region 初始化队列
                    this._cbQueue = new BindQueue(countPerBox);
                    //初始化bottleSerial表
                    db.RunDelOrInsertOrUppdateSQL("delete from bottleSerial");
                    #endregion



                    //################################################
                    toolBar1.Buttons[0].Enabled = false;
                    comboBox_productStyle.Enabled = false;
                    this.pictureBox1.Visible = true;
                    //将构造的第一行信息写入数据库tb_info，                          //品管号-4位
                    string biaozhi = "";
                    biaozhi = "日期" + dateTimePicker1.Value.ToString("yyyyMMdd") + "批号" + textBox_pihao.Text.Trim();
                    //先清空tb_info表
                    db.RunDelOrInsertOrUppdateSQL("delete from tb_info");
                    //插入当天的生产信息
                    string insertTotb_info = string.Format("insert into tb_info(info) values('{0}')", biaozhi);
                    db.RunDelOrInsertOrUppdateSQL(insertTotb_info);
                    if (db.RunSelectCountSQL("select count(*) from tb_bottle") > 0)//如果原始瓶号表中有数据，则构造生产用号码
                    {
                        SetJD(true);//显示进度条

                        //将第三行数据插入tb_thirdLine中
                        string dStr = "delete from tb_thirdLine";
                        db.RunDelOrInsertOrUppdateSQL(dStr);//先清空tb_thirdLine表中的数据
                        fillPrintThread = new Thread(new ThreadStart(FillPrinter));// 将构造后的瓶号码插入数据库tb_thirdLine,完毕后，开始扫描喷码成功的bottle_serial表，将这些号码写入队列中_wangjb
                        fillPrintThread.IsBackground = true;
                        fillPrintThread.Start();
                        Thread.Sleep(100);
                        this.listBox1.Items.Add("已做好喷码准备...");


                    }
                    else //如果原始瓶号表中无数据，则直接开始生产
                    {
                        #region 启动两个扫描线程
                        //启动数据库扫描线程，察看是否有发送成功的号码，如果有，则写入绑定队列

                        scanBottleSerial = new Thread(new ThreadStart(ScanBottleSerialMethod));
                        if (scanBottleSerial.IsAlive == false)
                        {
                            scanBottleSerial.Start();
                            Thread.Sleep(10);
                        }
                        //启动托盘HashTable表中是否有托盘号
                        tpCodeHasTable = new Hashtable();
                        t_tpBind = new Thread(new ThreadStart(ScanHashTable));
                        if (t_tpBind.IsAlive == false)
                        {
                            t_tpBind.Start();
                        }
                        #endregion
                        this.listBox1.Items.Add("已做好喷码准备...");

                    }
                    SetLeftNoText(db.RunSelectCountSQL("select count(barcode) from tb_bottle").ToString());

                   

                    #region 启动喷码机程序
                    try
                    {
                        string lujing = db.RunSelectResultsSQL("select l_lujing from tb_lujing");
                        if (lujing.Length > 0)
                        {
                            proc = Process.Start(lujing);
                            //this.btn_Jeishu.Visible = true;
                            this.btn_Qidong.Visible = false;
                            //MessageBox.Show("喷码程序启动成功！");
                        }
                        else
                        {
                            MessageBox.Show("喷码程序路径尚未设置，请到更改密码界面进行设置！");
                        }
                    }
                    catch (Exception es)
                    {
                        ErrMsgInsert(es.Message);
                        MessageBox.Show(es.Message);
                    }
                    #endregion
                }
                #endregion

                //this.btn_Qidong.Visible = true;
            }
            else
            {
                MessageBox.Show("请进行相应的选择,检查每托盘的箱数量是否填写！");
            }
        }
		#endregion

		#region 写入酒的类型
		private void InsertJiuStyle(int i_style)
		{
			string cmd = "delete from tb_jiustyle";
			CommonClass.ExcuteNonQuery(cmd);
			string command = string.Format("insert into tb_jiustyle(jiustyle,salerid,productid) values({0},'{1}','{2}')",i_style,this._salerID,this._productID);
			CommonClass.ExcuteNonQuery(command);
		}
		#endregion

		#region 将窗体上的信息写入数据库
		private void InsertStatus(string c_cnt,string product,string banzu,string lab,string pinguan)
		{			
			string cmd = "delete from tb_status";
			CommonClass.ExcuteNonQuery(cmd);
			string command = string.Format("insert into tb_status(c_cnt,product,banzu,label,pinguan) values('{0}','{1}','{2}','{3}','{4}')",c_cnt,product,banzu,lab,pinguan);
			CommonClass.ExcuteNonQuery(command);
		}
		#endregion

		#region 从数据库内取出要喷印的数据
		private string GetBottleCode()
		{
			string result = "";
            try
            {
                string command = "select top 1 * from tb_bottle order by newid()";//取得tb_bottle中的随机一条数据
                //				ClassLocalControl clc = new ClassLocalControl();
                //				clc.ConnectString = this.conn_str;
                SqlDataReader sdr = _clc.GetBottleCode(command);
                if (sdr != null)
                {
                    if (sdr.Read())
                        result = sdr["barcode"].ToString().Trim();
                    sdr.Close();
                }
            }
            catch (Exception es)
            {
                ErrMsgInsert(es.Message);
            }
			return result;
		}

		#endregion

		#region 从数据库内删除刚取出的数据
		private int DeleteBottleCode(string bottleCode)
		{
			int result = 0;
            try
            {
                string delCommand = string.Format("delete from tb_bottle where barcode='{0}'", bottleCode);
                //				ClassLocalControl clc = new ClassLocalControl();
                //				clc.ConnectString = this.conn_str;
                result = _clc.DeleteBottleCode(delCommand);
            }
            catch (Exception es)
            {
                ErrMsgInsert(es.Message);
            }
			return result;
		}

		#endregion

		#region 向界面输出信息
		private void WriteInfo(string info)
		{
			if(listBox1.Items.Count>20)
			{
				listBox1.Items.Clear();
			}
			listBox1.Items.Add(info);
		}

		#endregion

		#region 向队列内写入新瓶号函数
		private void WriteBottleToQueue(string bottle)
		{
            //Monitor.Enter(_cbQueue);
			if(this._cbQueue==null)
			{
				_cbQueue = new BindQueue(countPerBox);
			}
			_cbQueue.NewBottle = bottle;
            //Monitor.Exit(_cbQueue);
		}
		#endregion

		#region 向队列内写入新箱号
		private void WriteBoxToQueue(string box)
		{
			
            Monitor.Enter(_cbQueue);
            try
            {
                if (this._cbQueue == null)
                {
                    _cbQueue = new BindQueue(int.Parse(comboBox_productStyle.Text.Trim()));
                }
                _cbQueue.NewBox = box;
            }
            catch (Exception es)
            {
                ErrMsgInsert(es.Message);
            }
			finally
			{
				Monitor.Exit(_cbQueue);
			}
		}
		#endregion

		#region 从队列中取出绑定数据
        private string GetBindString()
        {
            Monitor.Enter(_cbQueue);
            try
            {
                return _cbQueue.BindData;
            }
            catch (Exception es)
            {
                ErrMsgInsert(es.Message);
                return "null";
            }
            finally
            {
                Monitor.Exit(_cbQueue);
            }

        }
		#endregion

		#region 测试：将数据写入文件内以进行验证
//		private void WriteToFile(string info)
//		{
//			string FileName = @"c:\txt2007.txt";
//			StreamWriter sw = new StreamWriter(FileName,true);
//			sw.WriteLine(info);
//			sw.Close();
//		}
		#endregion

		#region 向数据库内写入绑定后的数据
		private int WriteBindStrToDB(string bindStr,string productname)
		{
			int result = 0;
            try
            {
                string[] strArr = bindStr.Split(new char[] { '#' });
                string box = strArr[0].Trim();
                string bottle = strArr[1].Trim();
                string command = string.Format("insert into tb_bind(boxcode,bottlecode,productname,pdate) values('{0}','{1}','{2}','{3}')", box, bottle, productname, DateTime.Now.ToString("yyyy-MM-dd"));
                result = _clc.WriteBindStr(command);
            }
            catch (Exception es)
            {
                ErrMsgInsert(es.Message);
            }
			return result;
		}
		#endregion


		#region 验证是否某箱酒的第一瓶,如果是报警
		private void FirstVerify(int counter,int countPerBox)
		{
			if((counter%countPerBox)==1 )
			{
//				if(this._pingStart)
//				{
					
					AlarmON(this._channelnum);//测试注释
					
//				}
			}
			else
			{
//				if(!_pingStart)
//				{
//					this.ptb_jindu.Visible = false;
					AlarmOFF(this._channelnum);		//测试注释			
//					this._pingStart = true;
//				}
			}
		}
		#endregion
		
		#region 喷码时需要修改的一些参数，
		private void ModifyParam()
		{
//			int countPerBox = int.Parse(this.comboBox1.Text.Trim());
			FirstVerify(this._pingCounter,countPerBox);//验证是否是每箱的第一瓶
			this._pingCounter++;
			if(_pingCounter>countPerBox)
			{
				_pingCounter=1;
				
			}
			
		}
		#endregion

		#region 将构造后的瓶号码插入数据库tb_thirdLine
		private void FillPrinter()
		{
			try
			{
				DataBase db = new DataBase();
				int bottleCount = db.RunSelectCountSQL("select count(*) from tb_bottle");
				if(bottleCount>0)
				{
					Show("数据正在构造中，请构造完毕后再进行生产！");  //程序界面中的设备号就是配置文件中的banzu值（this.banzu），textBox2是班组号
					string makeInfo = dateTimePicker1.Value.ToString("yyMMdd") + this.banzu + textBox_banzu.Text.Trim();
					string sConn = ConfigurationManager.AppSettings["sql_connstr"];
					SqlConnection conn = new SqlConnection(sConn);
					conn.Open();

					DataSet dst = new DataSet();
					dst = db.RunDataSetSQL("select barcode from tb_bottle order by newid()","tb_bottle");
					int rowsCount = dst.Tables["tb_bottle"].Rows.Count;

                    //SqlCommand deleCmd = new SqlCommand();
                    SqlCommand insertCmd = new SqlCommand(null,conn);
                    insertCmd.CommandType = CommandType.Text;
                    insertCmd.CommandText = "insert into tb_thirdLine(bottleCode) values (@bottleCodeFirst)";
                    insertCmd.Parameters.Add("@bottleCodeFirst", SqlDbType.VarChar,50);
                    //deleCmd = conn.CreateCommand();
                    insertCmd.Prepare();
                    //insertCmd.ExecuteNonQuery();
                    
                    for (int i = 0; i < rowsCount; i++)
					{  
						//选择dst中的一条数据
						string info = dst.Tables["tb_bottle"].Rows[i][0].ToString();
  					    //构造数据
						StringBuilder sb = new StringBuilder(info.PadLeft(6, '0'));
						sb.Insert(0, makeInfo);
						//将构造好的第三行数据插入tb_thirdLine表中
                        insertCmd.Parameters["@bottleCodeFirst"].Value = sb.ToString();
                        //insertCmd.CommandText = string.Format("insert into tb_thirdLine(bottleCode) values ('{0}') ", sb.ToString());
						insertCmd.ExecuteNonQuery();
						
					}

					Show("号码已经构造完毕！");
                    #region 启动两个扫描线程
                    //启动数据库扫描线程，察看是否有发送成功的号码，如果有，则写入绑定队列

                    scanBottleSerial = new Thread(new ThreadStart(ScanBottleSerialMethod));
                    if (scanBottleSerial.IsAlive == false)
                    {
                        scanBottleSerial.Start();
                        Thread.Sleep(10);
                    }
                    //启动托盘HashTable表中是否有托盘号
                    tpCodeHasTable = new Hashtable();
                    t_tpBind = new Thread(new ThreadStart(ScanHashTable));
                    if (t_tpBind.IsAlive == false)
                    {
                        t_tpBind.Start();
                    }
                    #endregion
                    //显示信息
                    SetLeftNoText(db.RunSelectCountSQL("select count(barcode) from tb_bottle").ToString());
                    SetGouzaoText(db.RunSelectCountSQL("select count(bottleCode) from tb_thirdLine where selected_flag =0").ToString());
                    
                    //conn.Close();
					//将tb_bottle中的数据清空
                    SqlCommand lastdelCmd = new SqlCommand();
                    lastdelCmd = conn.CreateCommand();
                    lastdelCmd.CommandText = "delete from tb_bottle";
                    lastdelCmd.ExecuteNonQuery();
					conn.Close();
                    SetJD(false);
				}
                //Thread.Sleep(3600000);
			}
            catch (Exception es)
            {
                ErrMsgInsert(es.Message);
                MessageBox.Show(es.ToString());
                SetJD(false);
                SetText("号码构造过程发生错误，请退出程序，重新生成号码，然后开始生产！");
			}
		}
		
		#endregion

        #region 扫描HashTable，查看是否有托盘号
        private void ScanHashTable()
        {
            while (true)
            {
                if (tpCodeHasTable.Count > 0)
                {
                    string tpCode = tpCodeHasTable["1"].ToString();
                    tpCodeHasTable.Clear();
                    TuoPanBindProc(tpCode);
                    Thread.Sleep(1000);
                }
            }
        }
        #endregion

        #region 扫描tb_bottleSerial表，并将取出的号码写入队列
        private void ScanBottleSerialMethod()
		{
			while(true)
			{
				DataBase db = new DataBase();
				int n = db.RunSelectCountSQL("select count(*) from bottleSerial");
				if(n>0)
				{
					Thread.Sleep(10);
					string info = db.RunSelectResultsSQL("select bottle from bottleSerial where id_flag in (select min(id_flag) from bottleSerial)").ToString();
					if(info.Trim().Length ==16 )
					{
						this.WriteBottleToQueue(info);
						string deleteStr = string.Format("delete from bottleSerial where bottle = '{0}'",info);
						Thread.Sleep(10);
						db.RunDelOrInsertOrUppdateSQL(deleteStr);
						ModifyParam();//实时更新发送给喷码机的瓶号数量，并验证是否是每箱的第一瓶
					}

				}
				Thread.Sleep(100);
                //int n1 = db.RunSelectCountSQL("select count(*) from tb_errTable");
                //if(n1>0)
                //{
					
                //    Thread.Sleep(10);
                //    string errText = db.RunSelectResultsSQL("select errText from tb_errTable where id_flag in (select min(id_flag) from tb_errTable)" ).ToString();
                //    this.textBox4.Text = "喷码机有报警消息："+errText;
                //    Thread.Sleep(10);
                //    db.RunDelOrInsertOrUppdateSQL(string.Format("delete from tb_errTable where errText = '{0}'",errText));
                //}
                //Thread.Sleep(20);
			}
		}
		#endregion

		
		/// <summary>
		/// 重复发送过程
		/// </summary>
	

		#region 由酒系列检索酒名称
		private void comBox_productSeriel_TextChanged(object sender, System.EventArgs e)
		{
			try
			{
				if(this.radioButton_normal.Checked == true)
				{

					DataBase db = new DataBase();
					string cmdStr = "select productname from tb_productset where productname like '%" +this.comBox_productSeriel.Text.Trim() + "%'";
					DataSet dst = new DataSet();
					dst = db.RunDataSetSQL(cmdStr,"tb_productset");
					string contStr = "select count(*) from tb_productset where productname like '%" +this.comBox_productSeriel.Text.Trim() + "%'";
					int count  = db.RunSelectCountSQL(contStr);
					this.comboBox_productName.Text = "";
					this.comboBox_productName.Items.Clear();
					for(int i=0;i<count;i++)
					{
					
						this.comboBox_productName.Items.Add(dst.Tables["tb_productset"].Rows[i][0]);
					}
				}
				if(this.radioButton_zhuangong.Checked == true)
				{

					DataBase db = new DataBase();
					string cmdStr = "select productname from tb_zgproduct where productname like '%" +this.comBox_productSeriel.Text.Trim() + "%'";
					DataSet dst = new DataSet();
					dst = db.RunDataSetSQL(cmdStr,"tb_zgproduct");
					string contStr = "select count(*) from tb_zgproduct where productname like '%" +this.comBox_productSeriel.Text.Trim() + "%'";
					int count  = db.RunSelectCountSQL(contStr);
					this.comboBox_productName.Text = "";
					this.comboBox_productName.Items.Clear();
					for(int i=0;i<count;i++)
					{
					
						this.comboBox_productName.Items.Add(dst.Tables["tb_zgproduct"].Rows[i][0]);
					}
				}

			}
            catch (Exception es)
            {
                ErrMsgInsert(es.Message);
                MessageBox.Show(es.ToString());
			}
		}
		#endregion

		#region 关闭窗体时需要关闭各个线程和串口

		private void FrmLocalControl_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
            if (t_tpBind != null)
            {
                t_tpBind.Abort();
            }
			if(this._thImaje!=null)
			{
				this._Cp.CloseCom();
				_thImaje.Abort();				
			}

			string aa =toolBar1.Buttons[3].Text;
			if(!toolBar1.Buttons[1].Enabled)
			{
				AlarmOFF("6");
				AlarmOFF("7");
			}
			if(this._ctadam!=null)
			{
				this._ctadam.Close();
			}

            //if(this._thScan!=null)
            //{
            //    this._cts.Close();
            //    _thScan.Abort();
            //}
			if(this.t_LeftNoCount != null)
			this.t_LeftNoCount.Abort();
			
			if(this.fillPrintThread !=null)
			{
				fillPrintThread.Abort();
			}
			if(this.scanBottleSerial != null)
			{
				this.scanBottleSerial.Abort();
			}
            if (serialPort_Scaner.IsOpen)
            {
                serialPort_Scaner.Close();
            }
			this.pictureBox1.Visible = false;
            try
            {
                if (proc != null)
                {
                    proc.Kill();
                    this.btn_Qidong.Visible = true;
                    this.btn_Jeishu.Visible = false;
                    //MessageBox.Show("喷码程序已经停止！");
                }
            }
            catch (Exception es)
            {
                ErrMsgInsert(es.Message);
                //MessageBox.Show(es.Message);
            }
		}
		#endregion

		private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//textBox1.Focus();
		}

		
		private void ScanAlarm()
		{
			AlarmON("7");
			Thread.Sleep(400);
			AlarmOFF("7");
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{			
//			AlarmON("7");
//			Thread.Sleep(10000);
//			AlarmOFF("7");
//			timer1.Stop();
		}


		private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
		{
//			if(((CheckBox)sender).Checked)
//			{
//				if(((CheckBox)sender).Text == "普通酒")
//				{
			if(radioButton_normal.Checked)
			{
				AddProductName();
				this._salerID = string.Empty;
				this._productID = string.Empty;
			}
//				}
//				else
//				{
//					if(((CheckBox)sender).Text == "专供酒")
//					{
//						AddZGProductName();
//					}
//				}
//			}
		}

		private void comboBox2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(radioButton_zhuangong.Checked)
			{
				GetListInfo();
			}
		}

		#region 获取专供酒的经销商和产品编号
		private void GetListInfo()
		{
			string command = string.Format("select * from tb_zgproduct where productname='{0}'",comboBox_productName.Text.Trim());
			string tbName = "tb_zgproduct";
			DataTable dt = ExecuteTable(command,tbName);
			if(dt.Rows.Count>0)
			{
				this._salerID = dt.Rows[0]["salerid"].ToString();
				this._productID = dt.Rows[0]["productcode"].ToString();
			}
		}
		#endregion

		private void radioButton2_CheckedChanged(object sender, System.EventArgs e)
		{
			if(radioButton_zhuangong.Checked)
			{
				this._salerID = string.Empty;
				this._productID = string.Empty;
				AddZGProductName();				
			}
		}	

      

        private void InvokeLeftNoCount()
        {
            MethodInvoker mi = new MethodInvoker(LeftNoCount);
            while (true)
            {
                Thread.Sleep(1000);
                Invoke(mi);
                Thread.Sleep(50000);
            }
        }
        /// <summary>
        /// 剩余的原始瓶号
        /// </summary>
		private void LeftNoCount()
		{
			DataBase db = new DataBase();
			SetLeftNoText(db.RunSelectCountSQL("select count(barcode) from tb_bottle").ToString());
            SetGouzaoText(db.RunSelectCountSQL("select count(bottleCode) from tb_thirdLine where selected_flag =0").ToString());
		}

		

		private void timer1_Tick_1(object sender, System.EventArgs e)
		{
			
			this.txt_timeShow.Text = DateTime.Now.ToLongTimeString();
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
            if (MessageBox.Show("本操作用来模拟喷码机对数据库的操作，点击本按钮如果系统所有操作正常（报警灯和条码枪工作正常），而喷码机接入后不正常，则请检查喷码机自己开发的程序！是否需要进行调试？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
				DataBase db = new DataBase();
				//取出瓶号
                string bottle = db.RunSelectResultsSQL("select bottlecode from tb_thirdLine where id_flag in(select min(id_flag) from tb_thirdline where selected_flag =0)");
				//删除瓶号
                db.RunDelOrInsertOrUppdateSQL("update tb_thirdLine set selected_flag =1 where bottlecode =" + "'" + bottle + "'");
				//插入瓶号
				string insertStr = string.Format("insert into bottleSerial(bottle,myTimes) values('{0}','{1}')",bottle,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
				db.RunDelOrInsertOrUppdateSQL(insertStr);
				bottleSerialNo++;
				this.label11.Text = "第"+bottleSerialNo.ToString()+"瓶";
                listBox1.Items.Add(bottle);
            }
		}

      

        private void button1_Click_3(object sender, System.EventArgs e)
        {
            this.textBox4.Text = "";
        }

		
		#region 显示构造数据信息
		private delegate void ShowDelegate(string strshow);
		public void Show(string strshow)
		{

			string[] xinxi = new string[]{strshow};
			if (this.label7.InvokeRequired)
			{
				
				this.label7.BeginInvoke(new ShowDelegate(Show),xinxi);
			}
			else
			{
				this.label7.Text = xinxi[0].ToString();
			}
		}
		#endregion

		private void btn_Qidong_Click(object sender, System.EventArgs e)
		{
			try
			{
				DataBase db = new DataBase();
				string lujing = db.RunSelectResultsSQL("select l_lujing from tb_lujing");
				if(lujing.Length>0)
				{
					proc=Process.Start(lujing);
					this.btn_Jeishu.Visible=true;
					this.btn_Qidong.Visible=false;
					MessageBox.Show("喷码程序启动成功！");
				}
				else
				{
					MessageBox.Show("喷码程序路径尚未设置，请到更改密码界面进行设置！");
				}
			}
            catch (Exception es)
            {
                ErrMsgInsert(es.Message);
                MessageBox.Show(es.Message);
			}
		}

		private void btn_Jeishu_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(proc!=null)
				{
					proc.Kill();
					this.btn_Qidong.Visible=true;
					this.btn_Jeishu.Visible=false;
					MessageBox.Show("喷码程序已经停止！");
				}
			}
            catch (Exception es)
            {
                ErrMsgInsert(es.Message);
                MessageBox.Show(es.Message);
			}
		}

        #region 处理托盘绑定
        private void TuoPanBindProc(string tpBindCode)
        {
            //验证托盘号码是否已经存在
            if (!UniqueTPBox(tpBindCode))
            {
                
                DataBase db = new DataBase();
                int boxCount = int.Parse(this.txt_countOfTP.Text.Trim());  //一托盘多少箱
                //1.先查询出未绑定的数量
                int NotBindBoxCount = db.RunSelectCountSQL("select count(*) from tb_Bind where l_mark=0");
                //2 判断bt_Bind表中的未绑定的箱数量是否大于指定箱数箱。
                if (NotBindBoxCount >= boxCount)
                {
                    SetTPCode(tpBindCode);
                    ScanAlarm();
                    ScanAlarm();
                    ScanAlarm();
                    ScanAlarm();
                    ScanAlarm();
                    ScanAlarm();
                    ScanAlarm();
                    ScanAlarm();
                    ScanAlarm();
                    ScanAlarm();
                    DataSet ds = db.RunDataSetSQL("select id_flag,boxcode from tb_Bind where l_mark=0 order by id_flag", "tb_Bind");   //查询出所有未绑定的数据
                    string strConnect = ConfigurationManager.AppSettings["sql_connstr"];     //连接数据库字符串
                    using (SqlConnection connection = new SqlConnection(strConnect))
                    {
                        connection.Open();
                        //添加操作
                        SqlCommand cmdAdd = new SqlCommand(null, connection);
                        cmdAdd.CommandTimeout = 1200000;

                        cmdAdd.CommandType = CommandType.Text;
                        cmdAdd.CommandText = "insert into T_txBind(L_Boxcode,L_Tuopancode) values(@L_Boxcode,@L_Tuopancode)";
                        cmdAdd.Parameters.Add("@L_TuoPanCode", SqlDbType.NVarChar, 50);
                        cmdAdd.Parameters.Add("@L_BoxCode", SqlDbType.NVarChar, 50);
                        cmdAdd.Prepare();

                        //修改操作
                        SqlCommand cmdUpdate = new SqlCommand(null, connection);
                        cmdUpdate.CommandTimeout = 1200000;
                        cmdUpdate.CommandType = CommandType.Text;
                        cmdUpdate.CommandText = "update tb_Bind set l_mark=1 where id_flag=@id_flag";
                        cmdUpdate.Parameters.Add("@id_flag", SqlDbType.Int);
                        cmdUpdate.Prepare();

                        //执行绑定操作
                        for (int i = 0; i < boxCount; i++)
                        {
                            using (SqlTransaction myTrans = connection.BeginTransaction())
                            {
                                cmdUpdate.Transaction = myTrans;
                                cmdAdd.Transaction = myTrans;
                                string l_Boxcode = ds.Tables["tb_Bind"].Rows[i]["boxcode"].ToString();
                                string l_Tuopancode = tpBindCode;
                                string id_flag = ds.Tables["tb_Bind"].Rows[i]["id_flag"].ToString();
                                cmdAdd.Parameters["@L_TuoPanCode"].Value = l_Tuopancode;//托盘编号
                                cmdAdd.Parameters["@L_BoxCode"].Value = l_Boxcode;//箱编号
                                cmdUpdate.Parameters["@id_flag"].Value = id_flag; //托盘ID

                                try
                                {
                                    cmdAdd.ExecuteNonQuery();
                                    cmdUpdate.ExecuteNonQuery();
                                    myTrans.Commit();
                                    
                                    //ScanAlarm();
                                }
                                catch (Exception ex)
                                {
                                    myTrans.Rollback();    //回滚
                                    connection.Close();
                                    connection.Dispose();
                                    MessageBox.Show("托盘绑定过程发生错误，请重新扫描托盘标签进行数据绑定" + ex.Message);
                                }
                            }
                        }
                        int distinctCount = db.RunSelectCountSQL("select count(distinct l_tuopancode) from t_txbind");
                        SetTPCount("托盘数："+distinctCount.ToString());

                    }

                }
            }
        }
        #endregion

        private void serialPort_Scaner_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                //Thread.Sleep(200);
                string readBarcode = "";
                string boxBindCode = "";
                string tpBindCode="";
                //readBarcode = ReadBarCode();
                readBarcode = serialPort_Scaner.ReadTo("\r");
               
               

                if (readBarcode.Substring(0, 1).ToLower() == "t")//如果扫描得到的是托盘号码int.Parse(tpCodeLength)
                {
                    tpBindCode = readBarcode.Substring(0, int.Parse(tpCodeLength));
                    if (!tpCodeHasTable.ContainsValue(tpBindCode))
                    {
                        tpCodeHasTable.Add("1", tpBindCode);
                        Thread.Sleep(10);
                    }
                }
                else
                {
                    if (readBarcode.Length >= int.Parse(boxCodeLegth) && readBarcode.Substring(0,2) != "69")//如果读到的是箱号码
                    {
                        boxBindCode = readBarcode.Substring(0, int.Parse(boxCodeLegth));
                        if (UniqueBox(boxBindCode))
                        {
                            WriteBoxToQueue(boxBindCode);
                            string bindStr = GetBindString();
                            if (bindStr.ToLower() != "null")
                            {
                                int n = WriteBindStrToDB(bindStr, textOfComBox2.Trim());//所有的酒绑定数据都写入tb_bind
                                if (n > 0)
                                {
                                    if (radioButton_zhuangong.Checked)//如果是专供酒，则向专供酒表tb_zgbox中写入箱号
                                    {
                                        WriteZGBox(boxBindCode);
                                    }
                                }
                                SetText("绑定数据：" + bindStr);//123456789012#16,16,16,16,16,16,
                                ScanAlarm();
                                try
                                {
                                    //countPerBox 
                                    int setStartIndex = int.Parse(boxCodeLegth) + (17 * countPerBox) - 6;
                                    string lastBoxCode = bindStr.Substring(setStartIndex, 6);
                                    string boxCode = bindStr.Substring(6, 6);
                                    SetLastBoxCode(lastBoxCode);
                                    SetBoxCode(boxCode);

                                    int m_cnt = int.Parse(statusBar1.Panels[1].Text.Trim()) + 1;
                                    SetStatusBar(m_cnt.ToString());
                                    DataBase db = new DataBase();
                                    SetGouzaoText(db.RunSelectCountSQL("select count(bottleCode) from tb_thirdLine where selected_flag =0").ToString());
                                }
                                catch (Exception es)
                                {
                                    ErrMsgInsert(es.Message);
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        #region 串口接收数据的函数
        private string ReadBarCode()
        {
            string result = string.Empty;
            try
            {
                byte[] barCodeByte = ComReceive();
                result = FromASCIIByteArray(barCodeByte);
            }
            catch
            {

            }
            return result;
        }
        public static string FromASCIIByteArray(byte[] characters)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            //string constructedString = encoding.GetString(characters, 0, characters.Length - 1);
            string constructedString = encoding.GetString(characters, 0, characters.Length);
            return constructedString;
        }
        private byte[] ComReceive()
        {

            byte[] result = new byte[int.Parse(boxCodeLegth)];

            try
            {
                int locReaded = 0;
                do
                {
                    int locRecCnt = this.serialPort_Scaner.Read(result, locReaded, result.Length - locReaded);
                    locReaded += locRecCnt;
                    int IList = result[locReaded - 1];
                }

                while (locReaded != int.Parse(boxCodeLegth));
            }
            catch
            {
            }
            return result;
        }
        #endregion

        /// <summary>
        /// 数据验证,存在返回True
        /// </summary>
        /// <returns></returns>
        private bool UniqueTPBox(string tpCode)
        {
            DataBase db = new DataBase();
            string cmdStr = "select count(L_TuoPanCode) from T_txBind where L_TuoPanCode='" + tpCode + "'";
            int result = db.RunSelectCountSQL(cmdStr);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 判断字符串是否是正整数
        /// </summary>
        public static bool IsInt(string inString)
        {
            Regex regex = new Regex("^[0-9]*[1-9][0-9]*$");
            return regex.IsMatch(inString.Trim());
        }
        

        #region 设置输出信息
        delegate void SetTextCallback(string text);
        private void SetText(string text)
        {
            try
            {
                if (this.listBox1.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetText);
                    this.Invoke(d, new object[] { text });
                }
                else
                {
                    if (this.listBox1.Items.Count>120)
                    {
                        listBox1.Items.Clear();
                    }
                    this.listBox1.Items.Add(text);
                    //this.listBox1.Focus();
                }
            }
            catch (Exception es)
            {
                ErrMsgInsert(es.Message);
                return;
            }
        }
        delegate void SetstatusBarCallback(string text);

        private void SetStatusBar(string text)
        {
            try
            {
                if (this.statusBar1.InvokeRequired)
                {
                    SetstatusBarCallback d = new SetstatusBarCallback(SetStatusBar);
                    this.Invoke(d, new object[] { text });
                }
                else
                {
                    statusBar1.Panels[1].Text = text;
                }
            }
            catch (Exception es)
            {
                ErrMsgInsert(es.Message);
                return;
            }
        }

        delegate void SetGouzaoTexttCallback(string text);
        private void SetGouzaoText(string text)
        {
            try
            {
                if (this.txt_gouzaoNo.InvokeRequired)
                {
                    SetGouzaoTexttCallback d = new SetGouzaoTexttCallback(SetGouzaoText);
                    this.Invoke(d, new object[] { text });
                }
                else
                {
                    this.txt_gouzaoNo.Text = text;
                }
            }
            catch (Exception es)
            {
                ErrMsgInsert(es.Message);
                return;
            }
        }

        delegate void SetLeftNoTextCallback(string text);
        private void SetLeftNoText(string text)
        {
            try
            {
                if (this.txt_leftNoCount.InvokeRequired)
                {
                    SetLeftNoTextCallback d = new SetLeftNoTextCallback(SetLeftNoText);
                    this.Invoke(d, new object[] { text });
                }
                else
                {
                    this.txt_leftNoCount.Text = text;
                }
            }
            catch (Exception es)
            {
                ErrMsgInsert(es.Message);
                return;
            }
        }

        delegate void SetLastBoxCodeCallback(string text);
        private void SetLastBoxCode(string text)
        {
            try
            {
                if (this.txt_lastPingCode.InvokeRequired)
                {
                    SetLastBoxCodeCallback d = new SetLastBoxCodeCallback(SetLastBoxCode);
                    this.Invoke(d, new object[] { text });
                }
                else
                {
                    this.txt_lastPingCode.Text = text;
                }
            }
            catch (Exception es)
            {
                ErrMsgInsert(es.Message);
                return;
            }
        }

        delegate void SetBoxCodeCallback(string text);
        private void SetBoxCode(string text)
        {
            try
            {
                if (this.txt_boxcode.InvokeRequired)
                {
                    SetBoxCodeCallback d = new SetBoxCodeCallback(SetBoxCode);
                    this.Invoke(d, new object[] { text });
                }
                else
                {
                    this.txt_boxcode.Text = text;
                    this.listBox1.Focus();
                }
            }
            catch(Exception es)
            {
                ErrMsgInsert(es.Message);
                return;
            }
        }
        delegate void SetTPCodeCallback(string text);
        private void SetTPCode(string text)
        {
            try
            {
                if (lbl_TPCode.InvokeRequired)
                {
                    SetTPCodeCallback d = new SetTPCodeCallback(SetTPCode);
                    this.Invoke(d, new object[] { text });
                }
                else
                {
                    lbl_TPCode.Text = text;
                    //this.listBox1.Focus();
                }
            }
            catch (Exception es)
            {
                ErrMsgInsert(es.Message);
                return;
            }
        }

        delegate void SetJDCallback(bool b);
        private void SetJD(bool b)
        {
            try
            {
                if (this.ptb_jindu.InvokeRequired)
                {
                    SetJDCallback d = new SetJDCallback(SetJD);
                    this.Invoke(d, new object[] { b });
                }
                else
                {
                    ptb_jindu.Visible = b;
                }
            }
            catch (Exception es)
            {
                ErrMsgInsert(es.Message);
                return;
            }
        }

        delegate void SetTPCountCallback(string s);
        private void SetTPCount(string s)
        {
            try
            {
                if (this.lbl_tpCount.InvokeRequired)
                {
                    SetTPCountCallback d = new SetTPCountCallback(SetTPCount);
                    this.Invoke(d, new object[] { s });
                }
                else
                {
                    lbl_tpCount.Text = s;
                }
            }
            catch (Exception es)
            {
                ErrMsgInsert(es.Message);
                return;
            }
        }
        #endregion

        #region 设置线程间插入到数据库操作
        delegate void SetInsertTextCallback(string commandText);
        private void SetInsertText(string commandText)
        {
            DataBase db = new DataBase();
            try
            {
                if (this.listBox1.InvokeRequired)
                {
                    SetInsertTextCallback d = new SetInsertTextCallback(SetInsertText);
                    this.Invoke(d, new object[] { commandText });
                }
                else
                {
                    db.RunDelOrInsertOrUppdateSQL(commandText);
                }
            }
            catch (Exception es)
            {
                ErrMsgInsert(es.Message);
            }
        }
        #endregion

        #region 写入异常日志
        private void ErrMsgInsert(string errMsg)
        {
            DataBase db = new DataBase();
            string commandStr = string.Format("insert into tb_errLog(errMsg) values('{0}')", errMsg);
            db.RunDelOrInsertOrUppdateSQL(commandStr);
        }
        #endregion

        private void lbl_TPCode_Click(object sender, EventArgs e)
        {
            TPBindView fv = new TPBindView();
            fv.ShowDialog();
        }

      



       
    }
}
