using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

namespace LocalControl
{
	/// <summary>
	/// CheckFileOnMainServer ��ժҪ˵����
	/// </summary>
	public class CheckFileOnMainServer : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.TextBox txt_yanzheng;
		private System.Windows.Forms.Button btn_yanzheng;
		private System.Windows.Forms.TextBox txt_wenjian;
		private System.Windows.Forms.Button btn_chech;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btn_delete;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button btn_copy;
		private System.Windows.Forms.Button button4;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Button btn_Exit;
		private System.Data.SqlClient.SqlConnection sqlConnection1;

		private string wenjianAllName = "";

		public CheckFileOnMainServer()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CheckFileOnMainServer));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.txt_yanzheng = new System.Windows.Forms.TextBox();
			this.btn_yanzheng = new System.Windows.Forms.Button();
			this.txt_wenjian = new System.Windows.Forms.TextBox();
			this.btn_chech = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.button4 = new System.Windows.Forms.Button();
			this.btn_delete = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.label1 = new System.Windows.Forms.Label();
			this.btn_copy = new System.Windows.Forms.Button();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.btn_Exit = new System.Windows.Forms.Button();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(8, 32);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(232, 384);
			this.pictureBox1.TabIndex = 10;
			this.pictureBox1.TabStop = false;
			// 
			// listBox1
			// 
			this.listBox1.HorizontalScrollbar = true;
			this.listBox1.ItemHeight = 12;
			this.listBox1.Location = new System.Drawing.Point(272, 248);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(240, 76);
			this.listBox1.Sorted = true;
			this.listBox1.TabIndex = 15;
			// 
			// txt_yanzheng
			// 
			this.txt_yanzheng.Location = new System.Drawing.Point(272, 112);
			this.txt_yanzheng.Name = "txt_yanzheng";
			this.txt_yanzheng.Size = new System.Drawing.Size(216, 21);
			this.txt_yanzheng.TabIndex = 14;
			this.txt_yanzheng.Text = "";
			// 
			// btn_yanzheng
			// 
			this.btn_yanzheng.Location = new System.Drawing.Point(280, 144);
			this.btn_yanzheng.Name = "btn_yanzheng";
			this.btn_yanzheng.Size = new System.Drawing.Size(128, 23);
			this.btn_yanzheng.TabIndex = 13;
			this.btn_yanzheng.Text = "��֤�Ƿ����ظ��ļ�";
			this.btn_yanzheng.Click += new System.EventHandler(this.btn_yanzheng_Click);
			// 
			// txt_wenjian
			// 
			this.txt_wenjian.Location = new System.Drawing.Point(272, 48);
			this.txt_wenjian.Name = "txt_wenjian";
			this.txt_wenjian.Size = new System.Drawing.Size(216, 21);
			this.txt_wenjian.TabIndex = 12;
			this.txt_wenjian.Text = "";
			// 
			// btn_chech
			// 
			this.btn_chech.Location = new System.Drawing.Point(312, 80);
			this.btn_chech.Name = "btn_chech";
			this.btn_chech.Size = new System.Drawing.Size(128, 23);
			this.btn_chech.TabIndex = 11;
			this.btn_chech.Text = "ѡ����Ҫ�����ļ�";
			this.btn_chech.Click += new System.EventHandler(this.btn_chech_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(264, 224);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(256, 112);
			this.groupBox1.TabIndex = 16;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "�ظ��ļ��б�";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.button4);
			this.groupBox2.Controls.Add(this.btn_delete);
			this.groupBox2.Location = new System.Drawing.Point(264, 24);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(256, 192);
			this.groupBox2.TabIndex = 17;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "�ļ�����";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(152, 120);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(88, 23);
			this.button4.TabIndex = 7;
			this.button4.Text = "�����ظ��ļ�";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// btn_delete
			// 
			this.btn_delete.Location = new System.Drawing.Point(88, 160);
			this.btn_delete.Name = "btn_delete";
			this.btn_delete.Size = new System.Drawing.Size(88, 23);
			this.btn_delete.TabIndex = 6;
			this.btn_delete.Text = "ɾ���ظ��ļ�";
			this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Teal;
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(952, 23);
			this.label1.TabIndex = 18;
			// 
			// btn_copy
			// 
			this.btn_copy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_copy.ForeColor = System.Drawing.Color.DarkGreen;
			this.btn_copy.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btn_copy.ImageIndex = 8;
			this.btn_copy.ImageList = this.imageList1;
			this.btn_copy.Location = new System.Drawing.Point(536, 40);
			this.btn_copy.Name = "btn_copy";
			this.btn_copy.Size = new System.Drawing.Size(392, 48);
			this.btn_copy.TabIndex = 19;
			this.btn_copy.Text = "   ����������ϴ������з������쳣���ڴ˿��Լ�����ϴ��ĳ����ڷ��������Ƿ��Ѿ�����";
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// button2
			// 
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.ForeColor = System.Drawing.Color.DarkGreen;
			this.button2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.button2.ImageIndex = 8;
			this.button2.ImageList = this.imageList1;
			this.button2.Location = new System.Drawing.Point(536, 96);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(264, 32);
			this.button2.TabIndex = 20;
			this.button2.Text = "���ϴ����ļ����Ŀ¼ΪC:\\dataout\\";
			// 
			// button3
			// 
			this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button3.ForeColor = System.Drawing.Color.DarkGreen;
			this.button3.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.button3.ImageIndex = 8;
			this.button3.ImageList = this.imageList1;
			this.button3.Location = new System.Drawing.Point(536, 136);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(392, 64);
			this.button3.TabIndex = 21;
			this.button3.Text = "   �����֤�����ļ��������������Ѿ����ڣ����ɾ���ظ��ļ���   �ɡ�Ϊ�����������ɾ��ǰ����Ƚ����ļ��ı��ݡ������������ѯϵͳ����Ա";
			// 
			// btn_Exit
			// 
			this.btn_Exit.Location = new System.Drawing.Point(696, 256);
			this.btn_Exit.Name = "btn_Exit";
			this.btn_Exit.Size = new System.Drawing.Size(120, 23);
			this.btn_Exit.TabIndex = 22;
			this.btn_Exit.Text = "�˳�";
			this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "workstation id=\"WANGJB-IBM\";packet size=4096;user id=sa;data source=\"WANGJB-IBM\\W" +
				"ANGJB2005\";persist security info=True;initial catalog=ll_db;password=jwysoft";
			// 
			// CheckFileOnMainServer
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(952, 344);
			this.Controls.Add(this.btn_Exit);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.btn_copy);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.txt_yanzheng);
			this.Controls.Add(this.txt_wenjian);
			this.Controls.Add(this.btn_yanzheng);
			this.Controls.Add(this.btn_chech);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.pictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "CheckFileOnMainServer";
			this.Text = "CheckFileOnMainServer";
			this.Load += new System.EventHandler(this.CheckFileOnMainServer_Load);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btn_chech_Click(object sender, System.EventArgs e)
		{
			this.openFileDialog1.ShowDialog();
			wenjianAllName = this.openFileDialog1.FileName;
			this.txt_wenjian.Text = System.IO.Path.GetFileName(wenjianAllName);
			
		}

		private void btn_yanzheng_Click(object sender, System.EventArgs e)
		{
			string fname = @"d:\UpLoadFile\"+this.txt_wenjian.Text.Trim();
			CheckUpLoadFile.Service1 cs = new LocalControl.CheckUpLoadFile.Service1();
			if(cs.CheckUploadfile(fname)>=1)
			{
				this.txt_yanzheng.Text = "���ݿ����Ѵ����ظ�����";
				this.listBox1.Items.Add(@"C:\dataout\"+this.txt_wenjian.Text.Trim());
			}
			if(cs.CheckUploadfile(fname)==0)
			{
				this.txt_yanzheng.Text ="���ݿ���û���ظ�����";
				this.listBox1.Items.Clear();
			}
			if(cs.CheckUploadfile(fname)==-1)
			{
				this.txt_yanzheng.Text = "��ѯ�ڼ䷢���쳣�������ļ����Ƿ���ȷ�������Ƿ��쳣��";
			}
		}

		private void btn_delete_Click(object sender, System.EventArgs e)
		{
			if(MessageBox.Show("ȷʵҪɾ��ѡ�е��ļ���ȷ���Ѿ����������ļ�����","��ʾ",System.Windows.Forms.MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				File.Delete(@"C:\dataout\"+this.txt_wenjian.Text.Trim());
				this.listBox1.Items.Clear();
				MessageBox.Show("�ļ�ɾ���ɹ���");
			}
		}

		private void CheckFileOnMainServer_Load(object sender, System.EventArgs e)
		{
		
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(Directory.Exists(@"c:\�����ϴ���������ݱ���\"))
				{
					File.Copy(wenjianAllName,@"c:\�����ϴ���������ݱ���\"+this.txt_wenjian.Text.Trim(),true);
				}
				else
				{
					Directory.CreateDirectory(@"c:\�����ϴ���������ݱ���\");
					File.Copy(wenjianAllName,@"c:\�����ϴ���������ݱ���\"+this.txt_wenjian.Text.Trim(),true);
				}
				MessageBox.Show("�����ļ����ݳɹ���");
			}
			catch(Exception es)
			{
				MessageBox.Show("���ݱ��ݹ��̷���������ȷ���ڱ���ǰû������ļ����ı���"+es.ToString());
			}
		}

		private void btn_Exit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
