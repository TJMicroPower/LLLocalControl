using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
using System.Text;
namespace LocalControl
{
	/// <summary>
	/// FrmSPCZ ��ժҪ˵����
	/// </summary>
	public class FrmSPCZ : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton toolBarButton4;
		private System.Windows.Forms.ToolBarButton toolBarButton5;
		private System.Windows.Forms.ToolBarButton toolBarButton6;
		private System.Windows.Forms.ToolBarButton toolBarButton7;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txt_boxCode;
		Hashtable _ht = new Hashtable();
		private System.Windows.Forms.ComboBox comboBox_productName;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox cmB_productStyle;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rad_zhuanGong;
		private System.Windows.Forms.RadioButton rad_puTong;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ComboBox comBox_bottleNo;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Button lbl_salesId;
		private System.Windows.Forms.TextBox txt_salesId;
		private System.Windows.Forms.Button btn_removeAll;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txt_bzNo;
        private System.IO.Ports.SerialPort serialPort_Scaner;

        string adamCom = "";
        private string scanCom = "";
		private bool b = false;
        ComWithImaje.ComToADAM _ctadam = null;
        private Label label_showInfo;
        private ListBox list_deletedBoxCode;
        private Label label9;
        private Button btn_boxCodeSGDel;
        private Button txt_rePakage;
        //ComWithImaje.ComToScaner _cts = null;
        Hashtable hasList;
        private ToolBarButton toolBarButton1;
        string boxCodeLegth;
		public FrmSPCZ()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSPCZ));
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.toolBarButton4 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton5 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton6 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton7 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_boxCode = new System.Windows.Forms.TextBox();
            this.comboBox_productName = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmB_productStyle = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rad_puTong = new System.Windows.Forms.RadioButton();
            this.rad_zhuanGong = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.comBox_bottleNo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbl_salesId = new System.Windows.Forms.Button();
            this.txt_salesId = new System.Windows.Forms.TextBox();
            this.btn_removeAll = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_bzNo = new System.Windows.Forms.TextBox();
            this.serialPort_Scaner = new System.IO.Ports.SerialPort(this.components);
            this.label_showInfo = new System.Windows.Forms.Label();
            this.txt_rePakage = new System.Windows.Forms.Button();
            this.list_deletedBoxCode = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_boxCodeSGDel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolBar1
            // 
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.toolBarButton4,
            this.toolBarButton5,
            this.toolBarButton6,
            this.toolBarButton7,
            this.toolBarButton1});
            this.toolBar1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.imageList1;
            this.toolBar1.Location = new System.Drawing.Point(0, 24);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(155, 41);
            this.toolBar1.TabIndex = 3;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // toolBarButton4
            // 
            this.toolBarButton4.ImageIndex = 6;
            this.toolBarButton4.Name = "toolBarButton4";
            this.toolBarButton4.Text = "��װ";
            this.toolBarButton4.Visible = false;
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
            this.toolBarButton7.ImageIndex = 7;
            this.toolBarButton7.Name = "toolBarButton7";
            this.toolBarButton7.Text = "�˳�";
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.ImageIndex = 6;
            this.toolBarButton1.Name = "toolBarButton1";
            this.toolBarButton1.Text = "ɾ�����̰�";
            this.toolBarButton1.Visible = false;
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
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(192, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 23);
            this.label3.TabIndex = 18;
            this.label3.Text = "��Ʒ����";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("����", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(8, 248);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(502, 244);
            this.listBox1.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(192, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 23);
            this.label2.TabIndex = 15;
            this.label2.Text = "ƿ����:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Location = new System.Drawing.Point(256, 155);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(72, 21);
            this.textBox2.TabIndex = 16;
            this.textBox2.Enter += new System.EventHandler(this.textBox2_Enter);
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(8, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 13;
            this.label1.Text = "�����:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_boxCode
            // 
            this.txt_boxCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_boxCode.Location = new System.Drawing.Point(80, 155);
            this.txt_boxCode.Name = "txt_boxCode";
            this.txt_boxCode.Size = new System.Drawing.Size(104, 21);
            this.txt_boxCode.TabIndex = 14;
            this.txt_boxCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // comboBox_productName
            // 
            this.comboBox_productName.Location = new System.Drawing.Point(264, 120);
            this.comboBox_productName.Name = "comboBox_productName";
            this.comboBox_productName.Size = new System.Drawing.Size(336, 20);
            this.comboBox_productName.TabIndex = 19;
            this.comboBox_productName.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyMMdd";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(496, 155);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(64, 21);
            this.dateTimePicker1.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Teal;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1032, 23);
            this.label4.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(8, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 23);
            this.label8.TabIndex = 25;
            this.label8.Text = "ϵ��";
            // 
            // cmB_productStyle
            // 
            this.cmB_productStyle.Items.AddRange(new object[] {
            "38",
            "40.5",
            "40",
            "41",
            "42",
            "52",
            "61",
            "65"});
            this.cmB_productStyle.Location = new System.Drawing.Point(48, 88);
            this.cmB_productStyle.Name = "cmB_productStyle";
            this.cmB_productStyle.Size = new System.Drawing.Size(96, 20);
            this.cmB_productStyle.TabIndex = 26;
            this.cmB_productStyle.TextChanged += new System.EventHandler(this.cmB_productStyle_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rad_puTong);
            this.groupBox1.Controls.Add(this.rad_zhuanGong);
            this.groupBox1.Location = new System.Drawing.Point(576, 144);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(128, 40);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            // 
            // rad_puTong
            // 
            this.rad_puTong.Checked = true;
            this.rad_puTong.Location = new System.Drawing.Point(8, 8);
            this.rad_puTong.Name = "rad_puTong";
            this.rad_puTong.Size = new System.Drawing.Size(48, 24);
            this.rad_puTong.TabIndex = 1;
            this.rad_puTong.TabStop = true;
            this.rad_puTong.Text = "��ͨ";
            // 
            // rad_zhuanGong
            // 
            this.rad_zhuanGong.Location = new System.Drawing.Point(64, 8);
            this.rad_zhuanGong.Name = "rad_zhuanGong";
            this.rad_zhuanGong.Size = new System.Drawing.Size(56, 24);
            this.rad_zhuanGong.TabIndex = 0;
            this.rad_zhuanGong.Text = "ר��";
            this.rad_zhuanGong.CheckedChanged += new System.EventHandler(this.rad_zhuanGong_CheckedChanged);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.DarkGreen;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button1.ImageIndex = 8;
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point(160, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(800, 32);
            this.button1.TabIndex = 28;
            this.button1.Text = "  �ڡ���Ʒϵ�С�����ѡ�������������Ƶ�����һ�������֣��Ϳ���������ġ���Ʒ���ơ�������ʾ��Ӧ�����ƣ�ϵͳ֧��ȫ��ģ����ѯ��";
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Location = new System.Drawing.Point(448, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 23);
            this.label7.TabIndex = 29;
            this.label7.Text = "����";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(720, 152);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 24);
            this.button2.TabIndex = 30;
            this.button2.Text = "���ƿ��";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(816, 152);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(96, 24);
            this.button3.TabIndex = 31;
            this.button3.Text = "ɾ��ƿ��";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // comBox_bottleNo
            // 
            this.comBox_bottleNo.Items.AddRange(new object[] {
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
            this.comBox_bottleNo.Location = new System.Drawing.Point(112, 120);
            this.comBox_bottleNo.Name = "comBox_bottleNo";
            this.comBox_bottleNo.Size = new System.Drawing.Size(72, 20);
            this.comBox_bottleNo.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(8, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 23);
            this.label5.TabIndex = 33;
            this.label5.Text = "��Ʒ���1x";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Location = new System.Drawing.Point(616, 120);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 23);
            this.label10.TabIndex = 36;
            this.label10.Text = "�����̴���:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_salesId
            // 
            this.lbl_salesId.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_salesId.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbl_salesId.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lbl_salesId.ImageIndex = 8;
            this.lbl_salesId.ImageList = this.imageList1;
            this.lbl_salesId.Location = new System.Drawing.Point(160, 80);
            this.lbl_salesId.Name = "lbl_salesId";
            this.lbl_salesId.Size = new System.Drawing.Size(599, 32);
            this.lbl_salesId.TabIndex = 39;
            this.lbl_salesId.Text = "  �����ר����Ʒ��ѡ���Ʒ���ƺ��ھ����̴������˫����꣬�������ʾ�ò�Ʒ��Ӧ�ľ����̴���";
            // 
            // txt_salesId
            // 
            this.txt_salesId.Location = new System.Drawing.Point(712, 120);
            this.txt_salesId.Name = "txt_salesId";
            this.txt_salesId.Size = new System.Drawing.Size(96, 21);
            this.txt_salesId.TabIndex = 40;
            this.txt_salesId.DoubleClick += new System.EventHandler(this.txt_salesId_DoubleClick);
            // 
            // btn_removeAll
            // 
            this.btn_removeAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_removeAll.Location = new System.Drawing.Point(928, 152);
            this.btn_removeAll.Name = "btn_removeAll";
            this.btn_removeAll.Size = new System.Drawing.Size(75, 24);
            this.btn_removeAll.TabIndex = 41;
            this.btn_removeAll.Text = "����б�";
            this.btn_removeAll.Click += new System.EventHandler(this.btn_removeAll_Click);
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(336, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 23);
            this.label6.TabIndex = 42;
            this.label6.Text = "�����";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_bzNo
            // 
            this.txt_bzNo.Location = new System.Drawing.Point(392, 155);
            this.txt_bzNo.Name = "txt_bzNo";
            this.txt_bzNo.Size = new System.Drawing.Size(48, 21);
            this.txt_bzNo.TabIndex = 43;
            // 
            // serialPort_Scaner
            // 
            this.serialPort_Scaner.PortName = "COM2";
            this.serialPort_Scaner.ReceivedBytesThreshold = 12;
            this.serialPort_Scaner.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_Scaner_DataReceived);
            // 
            // label_showInfo
            // 
            this.label_showInfo.AutoSize = true;
            this.label_showInfo.Font = new System.Drawing.Font("����", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_showInfo.ForeColor = System.Drawing.Color.Red;
            this.label_showInfo.Location = new System.Drawing.Point(316, 194);
            this.label_showInfo.Name = "label_showInfo";
            this.label_showInfo.Size = new System.Drawing.Size(0, 16);
            this.label_showInfo.TabIndex = 44;
            // 
            // txt_rePakage
            // 
            this.txt_rePakage.Font = new System.Drawing.Font("����", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_rePakage.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txt_rePakage.Location = new System.Drawing.Point(170, 195);
            this.txt_rePakage.Name = "txt_rePakage";
            this.txt_rePakage.Size = new System.Drawing.Size(128, 40);
            this.txt_rePakage.TabIndex = 45;
            this.txt_rePakage.Text = "��  װ";
            this.txt_rePakage.UseVisualStyleBackColor = true;
            this.txt_rePakage.Click += new System.EventHandler(this.txt_rePakage_Click);
            // 
            // list_deletedBoxCode
            // 
            this.list_deletedBoxCode.FormattingEnabled = true;
            this.list_deletedBoxCode.ItemHeight = 12;
            this.list_deletedBoxCode.Location = new System.Drawing.Point(516, 247);
            this.list_deletedBoxCode.Name = "list_deletedBoxCode";
            this.list_deletedBoxCode.Size = new System.Drawing.Size(504, 244);
            this.list_deletedBoxCode.TabIndex = 46;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(514, 223);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(149, 12);
            this.label9.TabIndex = 47;
            this.label9.Text = "��ɾ�������ǩ�����б�";
            // 
            // btn_boxCodeSGDel
            // 
            this.btn_boxCodeSGDel.Location = new System.Drawing.Point(12, 209);
            this.btn_boxCodeSGDel.Name = "btn_boxCodeSGDel";
            this.btn_boxCodeSGDel.Size = new System.Drawing.Size(132, 23);
            this.btn_boxCodeSGDel.TabIndex = 49;
            this.btn_boxCodeSGDel.Text = "���ǩ�����ֹ�ɾ��";
            this.btn_boxCodeSGDel.UseVisualStyleBackColor = true;
            this.btn_boxCodeSGDel.Click += new System.EventHandler(this.btn_boxCodeSGDel_Click);
            // 
            // FrmSPCZ
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1032, 517);
            this.Controls.Add(this.btn_boxCodeSGDel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.list_deletedBoxCode);
            this.Controls.Add(this.txt_rePakage);
            this.Controls.Add(this.label_showInfo);
            this.Controls.Add(this.txt_bzNo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_removeAll);
            this.Controls.Add(this.txt_salesId);
            this.Controls.Add(this.lbl_salesId);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.comBox_bottleNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmB_productStyle);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.comboBox_productName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_boxCode);
            this.Controls.Add(this.toolBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSPCZ";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "��ƿ��װ";
            this.Load += new System.EventHandler(this.FrmSPCZ_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region �������
        private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        {
            string buttonTxt = e.Button.Text.Trim();
            switch (buttonTxt)
            {
                case "���":
                    Add();
                    break;
                case "��װ":
                    RePackage();
                    break;
                case "�˳�":
                    FrmClose();
                    break;
                default:
                    break;
            }
        }
		#endregion

		#region �˳�
		private void FrmClose()
		{
			this.Close();
		}
		#endregion

		#region �����ƿ��
		private void Add()
		{
			string bottleCode = textBox2.Text.Trim();
			if(bottleCode.Length>0)
			{	
				if(UniqueBottle(bottleCode))
				{
					listBox1.Items.Add(bottleCode);
				}
				else
				{
					MessageBox.Show("�����ظ�����");
				}
				textBox2.Clear();
			}
			else
			{
				MessageBox.Show("������ƿ���룡");
			}
		}
		#endregion

		#region �ж��Ƿ��ظ�����
		private bool UniqueBottle(string bCode)
		{
			bool result = false;
			if(_ht.Contains(bCode))
				result = false;
			else
			{
				result = true;
				_ht.Add(bCode,bCode);
			}
			return result;
		}
		#endregion

		#region ��װ,��������д��tb_bind,�����ר���ƣ������д��ר������tb_zgbox,����tb_bindcnt�е�����
		private void RePackage()
		{
			try
			{
				DataBase db = new DataBase();
				string boxCode = txt_boxCode.Text.Trim();
				string productName = comboBox_productName.Text;
				int cnt = listBox1.Items.Count;
				#region �жϻ��������Ƿ�����
				if(boxCode.Length!=12)
				{
					MessageBox.Show("��������ȷ������룡");
					return;
				}
				if(productName.Length<=0)
				{
					MessageBox.Show("�������Ʒ���ƣ�");
					return;
				}

				if(cnt<=0)
				{
					MessageBox.Show("��ƿ���룬���ܽ�����װ��");
					return;
				}
				if(this.comBox_bottleNo.Text.Trim().Length==0)
				{
					MessageBox.Show("��ѡ��ÿ��Ƶİ�װ������");
					return;
				}
				if(this.listBox1.Items.Count != int.Parse(this.comBox_bottleNo.Text.Trim()))
				{
					MessageBox.Show("ƿ��������������õĲ���ȣ����飡");
					return;
				}
				if(CheckBoxCode(boxCode))
				{
					MessageBox.Show("����������ݿ����Ѿ����ڣ�");
					return;
				}
				#endregion
				#region ����ͨ�ƽ��в���
				
				string bottleList = "";
				for(int i=0;i<listBox1.Items.Count;i++)
				{
					bottleList += listBox1.Items[i].ToString()+",";
				}
				//�������ݲ���󶨱���
				string insertTotb_bind = string.Format("insert into tb_bind(boxcode,bottlecode,productname,pdate) values('{0}','{1}','{2}','{3}')",this.txt_boxCode.Text.Trim(),
					bottleList,this.comboBox_productName.Text.Trim(),DateTime.Now.ToString("yyyy-MM-dd"));
				db.RunDelOrInsertOrUppdateSQL(insertTotb_bind);
				this.listBox1.Items.Clear();
				#endregion
				#region ��ר���ƽ��в���
				if(this.rad_zhuanGong.Checked ==true)//�����ר����
				{
					if(this.txt_salesId.Text.Trim().Length==0)
					{
						MessageBox.Show("����д�����̴��룡������������ϲ�ȫ��������ר����ά������д������������Ϣ��");
						return;
					}
					//�ɲ�Ʒ���Ƶõ���Ʒ����
					string selectProductName = string.Format("select productcode from tb_product where productname = '{0}'",this.comboBox_productName.Text.Trim());
					string productcode = db.RunSelectResultsSQL(selectProductName);
					//����ŵ����ݲ��뵽ר���Ʊ�tb_zgbox
					string insertTotb_zgbox = string.Format("insert into tb_zgbox(salerid,productid,in_date,boxcode,thd) values('{0}','{1}','{2}','{3}','{4}')",
						this.txt_salesId.Text.Trim(),productcode,DateTime.Now.ToString("yyyy-MM-dd"),this.txt_boxCode.Text.Trim(),DateTime.Now.ToString("yyyyMMddHHmmss"));
					db.RunDelOrInsertOrUppdateSQL(insertTotb_zgbox);
					this.listBox1.Items.Clear();
				}
				#endregion

				#region ���²��� ��Ŀǰû��ʹ�ã���Ϊ��tb_bind������insert�Ĵ�������
				//				string selectBindCountStr = string.Format("select incnt from tb_bindcnt where in_date = '{0}'",DateTime.Now.ToString("yyyy-MM-dd"));
				//				if(db.RunSelectResultsSQL(selectBindCountStr).ToString()!="")
				//				{
				//					int bindCount = int.Parse(db.RunSelectResultsSQL(selectBindCountStr).ToString());
				//			
				//					if(bindCount!=0)
				//					{
				//						string updateStr = string.Format("update tb_bindcnt set in_cnt = {0} where in_date = '{1}'",bindCount+=1,DateTime.Now.ToString("yyyy-MM-dd"));
				//						db.RunDelOrInsertOrUppdateSQL(updateStr);
				//					}
				//				}
				#endregion
				SetLable("��ƿ��װ�ɹ���");
				txt_boxCode.Focus();
				
				#region ��Щ�������Ѿ�������Ŀǰ�ǽ���������д�뱾�����ݿ⣬����ֱ���ϴ���wangjb2008.4.20

				//			if(DBPackage(boxCode,bottleList,productName)) 
				//			{
				//				MessageBox.Show("��ƿ��װ��ϣ�");
				//				listBox1.Items.Clear();
				//				textBox1.Clear();
				//				textBox2.Clear();
				//				//textBox3.Clear();
				//				_ht.Clear();
				//			}
				//			else
				//				MessageBox.Show("��װʧ�ܣ�");	
				#endregion
			}
			catch(Exception es)
			{
				MessageBox.Show("����ʧ�ܣ�"+es.ToString());
			}
		}
		#endregion
		
		#region ��ȡ�����̴���
		private string GetListInfowang(string productName)
		{
			string salesId = "";
			try
			{
				string command = string.Format("select salerid from tb_zgproduct where productname='{0}'",productName);
				DataBase db = new DataBase();
				salesId = db.RunSelectResultsSQL(command);
				return salesId;
			}
			catch
			{
				return salesId;
			}
		}
		#endregion
		
		#region ��װ���ݿ����
        //private bool DBPackage(string boxCode,string bList,string productName)
        //{
        //    bool result = false;
        //    try
        //    {
        //        WebSPCZ.WebSPCZ wcz = new LocalControl.WebSPCZ.WebSPCZ();
        //        result = wcz.SPCZ(boxCode,bList,productName);
        //    }
        //    catch
        //    {
        //    }
        //    return result;
        //}
		#endregion

		#region ��comboBox����Ӳ�Ʒ����
		private void AddProductName()
		{
			comboBox_productName.Items.Clear();
			string command = "select distinct productname from tb_productset";
			string tableName = "tb_productset";
			DataSet ds = CommonClass.ExecuteDataSet(command,tableName);
			DataTable dt = ds.Tables[tableName];
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

		/// <summary>
		/// ����true��ʾ���ظ����
		/// </summary>
		/// <param name="bCode"></param>
		/// <returns></returns>
		#region ��֤������Ƿ��ظ�
		private bool CheckBoxCode(string bCode)
		{
			bool result = false;
			try
			{
				DataBase db = new DataBase();
				string cmdStr = string.Format("select count(*) from tb_bind where boxcode = '{0}'",bCode);
				if(db.RunSelectCountSQL(cmdStr)==0)
				{
					result = false;
				}
				else
				{
					result = true;
				}
				return result;
			}
			catch
			{
				return result;
			}
			
		}
		#endregion

		private void FrmSPCZ_Load(object sender, System.EventArgs e)
		{
            boxCodeLegth = ConfigurationManager.AppSettings["boxCodeLength"];
            hasList = new Hashtable();
            CommonClass._connstr = ConfigurationManager.AppSettings["sql_connstr"];
			AddProductName();
			if(this.rad_puTong.Checked == true)
			{
				this.txt_salesId.ReadOnly = true;
			}
			if(this.rad_zhuanGong.Checked == true)
			{
				this.txt_salesId.ReadOnly = false;
			}

            string command_1 = "select * from com_set";
            DataSet ds = CommonClass.ExecuteDataSet(command_1, "com_set");
            DataTable dt = ds.Tables["com_set"];
            if (dt.Rows.Count > 0)
            {
                scanCom = dt.Rows[0]["scancom"].ToString();
                //adamCom = dt.Rows[0]["adamcom"].ToString();
                //this._ctadam = new ComWithImaje.ComToADAM(this.serialPort_Scaner, "01");

                //---------
                //this._ctadam.InitADAM4055();
                //---------
                serialPort_Scaner.PortName = scanCom;
                if (!serialPort_Scaner.IsOpen)
                {
                    try
                    {
                        serialPort_Scaner.Open();
                        //listBox1.Items.Add(scanCom + "����ǹ��ʼ���ɹ���");
                    }
                    catch (Exception es)
                    {
                        SetText(es.Message);
                    }
                }
            }

		}

		private void textBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar==0x0d)
			{
				if(txt_boxCode.Text.Trim().Length!=12)
				{
					MessageBox.Show("��������Ϊ12λ");
					txt_boxCode.Focus();
				}
				else
				{
					textBox2.Focus();
				}
			}
		}

		private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txt_boxCode.Focus();
		}

		private void textBox2_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar == 0x0d)
			{
				if(b==false)
				{
					if(this.txt_bzNo.Text.Length!=2)
					{
						MessageBox.Show("����ű�����2λ����");
						return;
					}
					else
					{
						try
						{
							int bzNo=int.Parse(txt_bzNo.Text.Trim());
						}
						catch
						{
							MessageBox.Show("����ű�����2λ����");
							return;
						}
					}
					if(MessageBox.Show("��ȷ���Ѿ���ȷѡ������ͨ�ƻ���ר����","��ʾ",MessageBoxButtons.YesNo,MessageBoxIcon.Information)==DialogResult.Yes)
					{
					
						string bottleCode = dateTimePicker1.Value.ToString("yyMMdd")+ConfigurationManager.AppSettings["banzu"]+this.txt_bzNo.Text.Trim()+textBox2.Text.Trim();
						if(textBox2.Text.Trim().Length!=6)
						{
							MessageBox.Show("ƿ��������ű���Ϊ6λ");					
						}
						else
						{
							if(UniqueBottle(bottleCode))
							{
								listBox1.Items.Add(bottleCode);
								textBox2.Clear();
							}
						}
						textBox2.Focus();
						b = true;
					}
				
				}
				else
				{
					if(this.txt_bzNo.Text.Length!=2)
					{
						MessageBox.Show("����ű�����2λ����");
						return;
					}
					else
					{
						try
						{
							int bzNo=int.Parse(txt_bzNo.Text.Trim());
						}
						catch
						{
							MessageBox.Show("����ű�����2λ����");
							return;
						}
					}
					string bottleCode = dateTimePicker1.Value.ToString("yyMMdd")+ConfigurationManager.AppSettings["banzu"]+this.txt_bzNo.Text.Trim()+textBox2.Text.Trim();
					if(textBox2.Text.Trim().Length!=6)
					{
						MessageBox.Show("ƿ��������ű���Ϊ6λ");					
					}
					else
					{
						if(UniqueBottle(bottleCode))
						{
							listBox1.Items.Add(bottleCode);
							textBox2.Clear();
						}
					}
					textBox2.Focus();
				}
			}
		}

		private void textBox2_Enter(object sender, System.EventArgs e)
		{
			
		}

		private void cmB_productStyle_TextChanged(object sender, System.EventArgs e)
		{
			if(this.rad_puTong.Checked ==true)
			{
				this.SelectProductName("tb_productset",this.cmB_productStyle.Text.Trim());
			}
			if(this.rad_zhuanGong.Checked == true)
			{
				this.SelectProductName("tb_zgproduct",this.cmB_productStyle.Text.Trim());
			}
			
		}
		
		#region ��tb_productset �� tb_zgproduct���м�����Ʒ���ƣ���䵽comboBox1��
		private void SelectProductName(string tb_name,string cmbText)
		{
			try
			{
				DataBase db = new DataBase();
				string cmdStr = "select productname from "+tb_name + "  where productname like '%" +cmbText + "%'";
				DataSet dst = new DataSet();
				dst = db.RunDataSetSQL(cmdStr,"tb_productset");
				string contStr = "select count(*) from " +tb_name + "  where productname like '%" +cmbText + "%'";
				int count  = db.RunSelectCountSQL(contStr);
				this.comboBox_productName.Text = "";
				this.comboBox_productName.Items.Clear();
				for(int i=0;i<count;i++)
				{
					
					this.comboBox_productName.Items.Add(dst.Tables["tb_productset"].Rows[i][0]);
				}
			}
			catch(Exception es)
			{
				MessageBox.Show(es.ToString());
			}
		}
		#endregion

		private void button2_Click(object sender, System.EventArgs e)
		{
			
			if(b==false)
			{
				if(MessageBox.Show("��ȷ���Ѿ���ȷѡ������ͨ�ƻ���ר����","��ʾ",MessageBoxButtons.YesNo,MessageBoxIcon.Information)==DialogResult.Yes)
				{
					if(this.txt_bzNo.Text.Length!=2)
					{
						MessageBox.Show("����ű�����2λ����");
						return;
					}
					else
					{
						try
						{
							int bzNo=int.Parse(txt_bzNo.Text.Trim());
						}
						catch
						{
							MessageBox.Show("����ű�����2λ����");
							return;
						}
					}
					string bottleCode = dateTimePicker1.Value.ToString("yyMMdd")+ConfigurationManager.AppSettings["banzu"]+this.txt_bzNo.Text.Trim()+textBox2.Text.Trim();
					if(textBox2.Text.Trim().Length!=6)
					{
						MessageBox.Show("ƿ��������ű���Ϊ6λ");					
					}
					
					else
					{
						if(UniqueBottle(bottleCode))
						{
							listBox1.Items.Add(bottleCode);
							textBox2.Clear();
						}
					}
					textBox2.Focus();
					b = true;
				}
			}
			else
			{
				if(this.txt_bzNo.Text.Length!=2)
				{
					MessageBox.Show("����ű�����2λ����");
					return;
				}
				else
				{
					try
					{
						int bzNo=int.Parse(txt_bzNo.Text.Trim());
					}
					catch
					{
						MessageBox.Show("����ű�����2λ����");
						return;
					}
				}
				string bottleCode = dateTimePicker1.Value.ToString("yyMMdd")+ConfigurationManager.AppSettings["banzu"]+this.txt_bzNo.Text.Trim()+textBox2.Text.Trim();
				if(textBox2.Text.Trim().Length!=6)
				{
					MessageBox.Show("ƿ��������ű���Ϊ6λ");					
				}
				else
				{
					if(UniqueBottle(bottleCode))
					{
						listBox1.Items.Add(bottleCode);
						textBox2.Clear();
					}
				}
				textBox2.Focus();
			}
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			if(this.listBox1.SelectedIndices.Count==0)
			{
				MessageBox.Show("��ѡ��Ҫɾ����ƿ�ţ�");
			}
			else
			{
				this.listBox1.Items.RemoveAt(this.listBox1.SelectedIndex);
			}
		}

		private void txt_salesId_DoubleClick(object sender, System.EventArgs e)
		{
			this.txt_salesId.Text = GetListInfowang(this.comboBox_productName.Text.Trim());
		}

		private void rad_zhuanGong_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.rad_zhuanGong.Checked==true)
			{
				this.txt_salesId.ReadOnly = false;
			}
			else
			{
				this.txt_salesId.ReadOnly = true;
			}
		}

		private void btn_removeAll_Click(object sender, System.EventArgs e)
		{
			this.listBox1.Items.Clear();
		}

		private void button2_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar == 0x0d)
			{
				if(b==false)
				{
					if(MessageBox.Show("��ȷ���Ѿ���ȷѡ������ͨ�ƻ���ר����","��ʾ",MessageBoxButtons.YesNo,MessageBoxIcon.Information)==DialogResult.Yes)
					{
					
						string bottleCode = dateTimePicker1.Value.ToString("yyMMdd")+ConfigurationManager.AppSettings["banzu"]+"00"+textBox2.Text.Trim();
						if(textBox2.Text.Trim().Length!=6)
						{
							MessageBox.Show("ƿ��������ű���Ϊ6λ");					
						}
						else
						{
							if(UniqueBottle(bottleCode))
							{
								listBox1.Items.Add(bottleCode);
								textBox2.Clear();
							}
						}
						textBox2.Focus();
						b = true;
					}
				
				}
				else
				{
                    string bottleCode = dateTimePicker1.Value.ToString("yyMMdd") + ConfigurationManager.AppSettings["banzu"] + "00" + textBox2.Text.Trim();
					if(textBox2.Text.Trim().Length!=6)
					{
						MessageBox.Show("ƿ��������ű���Ϊ6λ");					
					}
					else
					{
						if(UniqueBottle(bottleCode))
						{
							listBox1.Items.Add(bottleCode);
							textBox2.Clear();
						}
					}
					textBox2.Focus();
				}
			}

		
		}
        #region ��֤�ַ����Ƿ�������
        private bool CheckStringToInt(string boxCode)
        {
            int result = 0;
            if (int.TryParse(boxCode, out result))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        private void serialPort_Scaner_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            int boxCodeLegth = int.Parse(ConfigurationManager.AppSettings["boxCodeLength"]);
            string box = "";
            //string readBoxCode = serialPort_Scaner.ReadLine();
            string readBoxCode = serialPort_Scaner.ReadTo("\r");
            //MessageBox.Show(readBoxCode);
            if (readBoxCode.Length >= boxCodeLegth && readBoxCode.Substring(0,2) != "69")
            {
                box = readBoxCode.Substring(0, boxCodeLegth);

                SetText(box);

                //����ż������ݴ����ݿ���ɾ��

                DataBase db = new DataBase();
                string checkStr = string.Format("select boxcode from tb_bind where boxcode = '{0}'", box);
                string boxcodeStr = db.RunSelectResultsSQL(checkStr);
                if (boxcodeStr == "")
                {
                    SetLable("������ڰ󶨱��в����ڣ�");
                    InsertToHt(box);
                }
                else
                {
                    //									if(UniqueBox(box))//UniqueBox����true��ʾboxerr����û���ظ�ֵ
                    //									{
                    //										WriteBoxToDB(box);
                    //										WriteInfo("�Ѿ��������д���쳣��ű�"+box);
                    //										ScanAlarm();	//��������									
                    //									}

                    try
                    {
                        string deleteStr = string.Format("delete from tb_bind where boxcode = '{0}'", box);
                        db.RunDelOrInsertOrUppdateSQL(deleteStr);//ɾ���󶨱��еļ�¼
                        string selectBindCountStr = string.Format("select in_cnt from tb_bindcnt where in_date = '{0}'", DateTime.Now.ToString("yyyy-MM-dd"));
                        int bindCount = int.Parse(db.RunSelectResultsSQL(selectBindCountStr).ToString()) + 0;
                        if (bindCount != 0)
                        {
                            string updateStr = string.Format("update tb_bindcnt set in_cnt = {0} where in_date = '{1}'", bindCount - 1, DateTime.Now.ToString("yyyy-MM-dd"));
                            db.RunDelOrInsertOrUppdateSQL(updateStr);//���²���
                        }
                        SetLable("��¼�Ѿ��Ӱ󶨱���ɾ��,����ǣ� " + box + "���ڿ���ֱ������ƿ�ŵĺ���λ������ƿ��װ��");
                    }
                    catch
                    {
                        MessageBox.Show("�������е����ڲ��ǵ������ڣ�����ϵ����Ա���д���");
                    }
                    //
                }
                if (InsertToHt(box))
                {
                    SetListDelete(box);
                }
            }
            else
            {
                MessageBox.Show("����ǹ���ص�ֵ�쳣����������ǹ��");
            }
        }

        delegate void SetListDeleteCallback(string text);
        private void SetListDelete(string text)
        {
            try
            {
                if (this.list_deletedBoxCode.InvokeRequired)
                {
                    SetListDeleteCallback d = new SetListDeleteCallback(SetListDelete);
                    this.Invoke(d, new object[] { text });
                }
                else
                {
                    list_deletedBoxCode.Items.Add(text);
                    textBox2.Focus();
                }
            }
            catch (Exception es)
            {
                ErrMsgInsert(es.Message);
                return;
            }
        }
        
        delegate void SetTextCallback(string text);
        private void SetText(string text)
        {
            try
            {
                if (this.txt_boxCode.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetText);
                    this.Invoke(d, new object[] { text });
                }
                else
                {
                    txt_boxCode.Text = text;
                    textBox2.Focus();
                }
            }
            catch (Exception es)
            {
                ErrMsgInsert(es.Message);
                return;
            }
        }
        delegate void SetLableCallback(string text);
        private void SetLable(string text)
        {
            try
            {
                if (this.label_showInfo.InvokeRequired)
                {
                    SetLableCallback d = new SetLableCallback(SetLable);
                    this.Invoke(d, new object[] { text });
                }
                else
                {
                    label_showInfo.Text=text;
                    textBox2.Focus();
                }
            }
            catch (Exception es)
            {
                ErrMsgInsert(es.Message);
                return;
            }
        }
        #region д���쳣��־
        private void ErrMsgInsert(string errMsg)
        {
            DataBase db = new DataBase();
            string commandStr = string.Format("insert into tb_errLog(errMsg) values('{0}')", errMsg);
            db.RunDelOrInsertOrUppdateSQL(commandStr);
        }
        #endregion

        private void txt_rePakage_Click(object sender, EventArgs e)
        {
            RePackage();
        }

        private void btn_boxCodeSGDel_Click(object sender, EventArgs e)
        {
            int boxCodeLegth = int.Parse(ConfigurationManager.AppSettings["boxCodeLength"]);
            string box = "";
            string readBoxCode = txt_boxCode.Text.Trim();
            //MessageBox.Show(readBoxCode);
            if (readBoxCode.Length >= boxCodeLegth)
            {
                box = readBoxCode.Substring(0, boxCodeLegth);
                //����ż������ݴ����ݿ���ɾ��

                DataBase db = new DataBase();
                string checkStr = string.Format("select boxcode from tb_bind where boxcode = '{0}'", box);
                string boxcodeStr = db.RunSelectResultsSQL(checkStr);
                if (boxcodeStr == "")
                {
                    SetLable("������ڰ󶨱��в����ڣ�");
                    InsertToHt(box);
                }
                else
                {
                    try
                    {
                        string deleteStr = string.Format("delete from tb_bind where boxcode = '{0}'", box);
                        db.RunDelOrInsertOrUppdateSQL(deleteStr);//ɾ���󶨱��еļ�¼
                        string selectBindCountStr = string.Format("select in_cnt from tb_bindcnt where in_date = '{0}'", DateTime.Now.ToString("yyyy-MM-dd"));
                        int bindCount = int.Parse(db.RunSelectResultsSQL(selectBindCountStr).ToString()) + 0;
                        if (bindCount != 0)
                        {
                            string in_date = db.RunSelectResultsSQL("select in_date from tb_bindcnt");
                            if (in_date == DateTime.Now.ToString("yyyy-MM-dd"))
                            {
                                string updateStr = string.Format("update tb_bindcnt set in_cnt = {0} where in_date = '{1}'", bindCount - 1, DateTime.Now.ToString("yyyy-MM-dd"));
                                db.RunDelOrInsertOrUppdateSQL(updateStr);//���²���
                                SetLable("��¼�Ѿ��Ӱ󶨱���ɾ��,����ǣ� " + box + "���ڿ���ֱ������ƿ�ŵĺ���λ������ƿ��װ��");
                            }
                            else
                            {
                                SetLable("��¼�Ѿ��Ӱ󶨱���ɾ��,����ǣ� " + box + "���ڿ���ֱ������ƿ�ŵĺ���λ������ƿ��װ�����ǲ������ǵ��յģ�û�б����£�");
                            }
                        }
                        
                    }
                    catch(Exception es)
                    {
                        MessageBox.Show("�������е����ڲ��ǵ������ڣ�����ϵ����Ա���д�����ϸ��Ϣ��"+es.Message);
                    }
                }
                if (InsertToHt(box))
                {
                    list_deletedBoxCode.Items.Add(box);
                }
            }
            else
            {
                MessageBox.Show("�������������볤��");
            }
        }
        #region �����ݲ����ϣ��
        private bool InsertToHt(string boxCode)
        {
            bool result = false;
            if (!hasList.ContainsValue(boxCode))
            {
                hasList.Add(boxCode, boxCode);
                result = true;
            }
            return result;
        }
        #endregion
        #region ���ڽ������ݵĺ���
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
            string constructedString = encoding.GetString(characters, 0, characters.Length - 1);
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
    }
}
