using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace LocalControl
{
	/// <summary>
	/// FrmComSet 的摘要说明。
	/// </summary>
	public class FrmComSet : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.ComboBox comboBox3;
		private string connStr = ConfigurationManager.AppSettings["sql_connstr"];
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox1;
		//ClassLocalControl _clc = new ClassLocalControl();
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmComSet()
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
			this.label1 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.comboBox3 = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label1.Location = new System.Drawing.Point(8, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 23);
			this.label1.TabIndex = 5;
			this.label1.Text = "条码扫描口:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.Items.AddRange(new object[] {
														   "COM1",
														   "COM2",
														   "COM3",
														   "COM4"});
			this.comboBox1.Location = new System.Drawing.Point(104, 48);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(88, 20);
			this.comboBox1.TabIndex = 6;
			// 
			// label2
			// 
			this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label2.Location = new System.Drawing.Point(8, 88);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 23);
			this.label2.TabIndex = 7;
			this.label2.Text = "模块通讯口:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label3.Location = new System.Drawing.Point(8, 128);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(88, 23);
			this.label3.TabIndex = 9;
			this.label3.Text = "喷码通讯口:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(16, 176);
			this.button1.Name = "button1";
			this.button1.TabIndex = 11;
			this.button1.Text = "确认";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(112, 176);
			this.button2.Name = "button2";
			this.button2.TabIndex = 12;
			this.button2.Text = "退出";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// comboBox2
			// 
			this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox2.Items.AddRange(new object[] {
														   "COM1",
														   "COM2",
														   "COM3",
														   "COM4"});
			this.comboBox2.Location = new System.Drawing.Point(104, 88);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(88, 20);
			this.comboBox2.TabIndex = 13;
			// 
			// comboBox3
			// 
			this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox3.Items.AddRange(new object[] {
														   "COM1",
														   "COM2",
														   "COM3",
														   "COM4"});
			this.comboBox3.Location = new System.Drawing.Point(104, 128);
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new System.Drawing.Size(88, 20);
			this.comboBox3.TabIndex = 14;
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.Teal;
			this.label4.Dock = System.Windows.Forms.DockStyle.Top;
			this.label4.Location = new System.Drawing.Point(0, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(776, 23);
			this.label4.TabIndex = 15;
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(0, 32);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(232, 176);
			this.groupBox1.TabIndex = 16;
			this.groupBox1.TabStop = false;
			// 
			// FrmComSet
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(776, 216);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.comboBox3);
			this.Controls.Add(this.comboBox2);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "FrmComSet";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "串口设置";
			this.Load += new System.EventHandler(this.FrmComSet_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void FrmComSet_Load(object sender, System.EventArgs e)
		{
			//_clc.ConnectString = this.connStr;
			CommonClass._connstr = this.connStr;
			string command_a = "select * from com_set";
			DataSet ds = CommonClass.ExecuteDataSet(command_a,"com_set");
			DataTable dt = ds.Tables["com_set"];
			if(dt.Rows.Count>0)
			{
				comboBox1.SelectedIndex = comboBox1.Items.IndexOf(dt.Rows[0]["scancom"].ToString());
				comboBox2.SelectedIndex = comboBox2.Items.IndexOf(dt.Rows[0]["adamcom"].ToString());
				comboBox3.SelectedIndex = comboBox3.Items.IndexOf(dt.Rows[0]["printcom"].ToString());
			}
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			string scanCom = comboBox1.Text;
			if(scanCom.Length<=0)
			{
				MessageBox.Show("请选择条码扫描口");
				return;
			}
			string adamCom = comboBox2.Text;
			if(adamCom.Length<=0)
			{
				MessageBox.Show("请选择模块通讯口");
				return;
			}
			string printCom = comboBox3.Text;
			if(printCom.Length<=0)
			{
				MessageBox.Show("请选择喷码通讯口");
				return;
			}
			string command_1 = "delete from com_set";
			CommonClass.ExcuteNonQuery(command_1);
			string command_2 = string.Format("insert into com_set(scancom,adamcom,printcom) values('{0}','{1}','{2}')",scanCom,adamCom,printCom);
			int ret = CommonClass.ExcuteNonQuery(command_2);
			if(ret>0)
			{
				MessageBox.Show("设置串口成功");
			}
			else
				MessageBox.Show("串口设置失败");

		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
