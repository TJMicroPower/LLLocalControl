using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace LocalControl
{
	/// <summary>
	/// ChangeMima 的摘要说明。
	/// </summary>
	public class ChangeMima : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox txt_newmima;
		private System.Windows.Forms.TextBox txt_newmimaqr;
		private System.Windows.Forms.Button btn_gaiok;
		private System.Windows.Forms.TextBox txt_mima;
		private System.Windows.Forms.TextBox txt_yhm;
		private System.Windows.Forms.Button btn_dengok;

		private string yhm="";
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button btn_lujing;
		private System.Windows.Forms.TextBox txt_lujing;
		private System.Windows.Forms.Label label5;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ChangeMima()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeMima));
            this.label1 = new System.Windows.Forms.Label();
            this.txt_newmima = new System.Windows.Forms.TextBox();
            this.txt_newmimaqr = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_gaiok = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_mima = new System.Windows.Forms.TextBox();
            this.txt_yhm = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_dengok = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_lujing = new System.Windows.Forms.TextBox();
            this.btn_lujing = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(304, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "输入新密码";
            // 
            // txt_newmima
            // 
            this.txt_newmima.Location = new System.Drawing.Point(424, 40);
            this.txt_newmima.Name = "txt_newmima";
            this.txt_newmima.Size = new System.Drawing.Size(100, 21);
            this.txt_newmima.TabIndex = 1;
            // 
            // txt_newmimaqr
            // 
            this.txt_newmimaqr.Location = new System.Drawing.Point(424, 80);
            this.txt_newmimaqr.Name = "txt_newmimaqr";
            this.txt_newmimaqr.Size = new System.Drawing.Size(100, 21);
            this.txt_newmimaqr.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(304, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "再次输入";
            // 
            // btn_gaiok
            // 
            this.btn_gaiok.Enabled = false;
            this.btn_gaiok.Location = new System.Drawing.Point(104, 104);
            this.btn_gaiok.Name = "btn_gaiok";
            this.btn_gaiok.Size = new System.Drawing.Size(75, 23);
            this.btn_gaiok.TabIndex = 4;
            this.btn_gaiok.Text = "确 定";
            this.btn_gaiok.Click += new System.EventHandler(this.btn_gaiok_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_gaiok);
            this.groupBox1.Location = new System.Drawing.Point(296, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 136);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "修改密码";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(272, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "用户名";
            // 
            // txt_mima
            // 
            this.txt_mima.Location = new System.Drawing.Point(144, 80);
            this.txt_mima.Name = "txt_mima";
            this.txt_mima.PasswordChar = '*';
            this.txt_mima.Size = new System.Drawing.Size(100, 21);
            this.txt_mima.TabIndex = 8;
            // 
            // txt_yhm
            // 
            this.txt_yhm.Location = new System.Drawing.Point(144, 40);
            this.txt_yhm.Name = "txt_yhm";
            this.txt_yhm.Size = new System.Drawing.Size(100, 21);
            this.txt_yhm.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "密码";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_dengok);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(16, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(248, 136);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "登录";
            // 
            // btn_dengok
            // 
            this.btn_dengok.Location = new System.Drawing.Point(104, 104);
            this.btn_dengok.Name = "btn_dengok";
            this.btn_dengok.Size = new System.Drawing.Size(75, 23);
            this.btn_dengok.TabIndex = 4;
            this.btn_dengok.Text = "确 定";
            this.btn_dengok.Click += new System.EventHandler(this.btn_dengok_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txt_lujing);
            this.groupBox3.Controls.Add(this.btn_lujing);
            this.groupBox3.Location = new System.Drawing.Point(16, 176);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(528, 136);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "设置要调用的喷码程序";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(24, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(440, 23);
            this.label5.TabIndex = 2;
            this.label5.Text = "设置要启动的程序的路径及其包括后缀的文件名";
            // 
            // txt_lujing
            // 
            this.txt_lujing.Location = new System.Drawing.Point(24, 64);
            this.txt_lujing.Name = "txt_lujing";
            this.txt_lujing.Size = new System.Drawing.Size(480, 21);
            this.txt_lujing.TabIndex = 1;
            // 
            // btn_lujing
            // 
            this.btn_lujing.Location = new System.Drawing.Point(232, 104);
            this.btn_lujing.Name = "btn_lujing";
            this.btn_lujing.Size = new System.Drawing.Size(75, 23);
            this.btn_lujing.TabIndex = 0;
            this.btn_lujing.Text = "设   置";
            this.btn_lujing.Click += new System.EventHandler(this.btn_lujing_Click);
            // 
            // ChangeMima
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(552, 349);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txt_mima);
            this.Controls.Add(this.txt_yhm);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_newmimaqr);
            this.Controls.Add(this.txt_newmima);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.Name = "ChangeMima";
            this.Text = "更改密码";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void btn_dengok_Click(object sender, System.EventArgs e)
		{
			if(txt_yhm.Text.Trim().Length!=0 && txt_mima.Text.Trim().Length!=0)
			{
				SqlConnection conn = new SqlConnection("server = 192.168.0.6;database = ll_server;uid=sa;pwd=jwysoft;");
				try
				{
					
					SqlCommand cmd = new SqlCommand();
					cmd = conn.CreateCommand();
					conn.Open();
					cmd.CommandText = string.Format("select userName from tb_wlineuser where userName = '{0}'",txt_yhm.Text.Trim());
					string userName = cmd.ExecuteScalar().ToString();
					conn.Close();
					if(userName !="")
					{
						conn.Open();
						SqlCommand cmd1 = new SqlCommand();
						cmd1 = conn.CreateCommand();
						cmd1.CommandText = string.Format("select passWord from tb_wlineuser where userName = '{0}'",userName);
						string passWord = cmd1.ExecuteScalar().ToString();
						conn.Close();
						if(passWord == txt_mima.Text.Trim())
						{
							yhm = userName;
							this.btn_gaiok.Enabled = true;
						}
						else
						{
							MessageBox.Show("用户名和密码不符，请重新输入！");
						}
					}
				}
				catch
				{
					conn.Close();
					MessageBox.Show("和服务器的连接失败，请检查网络连接！");
				}
			}
		}

		private void btn_gaiok_Click(object sender, System.EventArgs e)
		{
			 
			if(this.txt_newmima.Text.Trim().Length !=0 && this.txt_newmimaqr.Text.Trim().Length != 0)
			{
				SqlConnection conn = new SqlConnection("server = 192.168.0.6;database = ll_server;uid=sa;pwd=jwysoft;");
				try
				{
					if(this.txt_newmima.Text.Trim() == this.txt_newmimaqr.Text.Trim())
					{
						conn.Open();
						SqlCommand cmd = new SqlCommand();
						cmd = conn.CreateCommand();
						cmd.CommandText = string.Format("update tb_wlineuser set passWord = '{0}' where userName ='{1}'",this.txt_newmimaqr.Text.Trim(),yhm);
						cmd.ExecuteNonQuery();
						MessageBox.Show("密码修改成功！");
						this.txt_newmimaqr.Text="";
						this.txt_newmima.Text="";
						this.btn_gaiok.Enabled = false;
						conn.Close();
					}
				}
				catch
				{
					conn.Close();
					MessageBox.Show("密码修改失败，请检查到服务器的连接！");
				}
			}
		}

		private void btn_lujing_Click(object sender, System.EventArgs e)
		{
			try
			{
				DataBase db = new DataBase();
				string update = "update tb_lujing set l_lujing = '"+txt_lujing.Text.Trim()+"'";
				db.RunDelOrInsertOrUppdateSQL(update);
				MessageBox.Show("路径设置成功！");
			}
			catch(Exception es)
			{
				MessageBox.Show(es.ToString());
			}
		}

		
	}
}
