using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
namespace LocalControl
{
	/// <summary>
	/// FrmZGProduct 的摘要说明。
	/// </summary>
	public class FrmZGProduct : System.Windows.Forms.Form
	{
		string _productcode = string.Empty;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.ToolBarButton toolBarButton2;
		private System.Windows.Forms.ToolBarButton toolBarButton3;
		private System.Windows.Forms.ToolBarButton toolBarButton4;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox3;
		private MyComponent.CListView cListView1;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ToolBarButton toolBarButton5;
		private System.Windows.Forms.ToolBarButton toolBarButton6;
		private System.Windows.Forms.ToolBarButton toolBarButton7;
		private System.Windows.Forms.ImageList imageList1;
		private System.ComponentModel.IContainer components;

		public FrmZGProduct()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmZGProduct));
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton4 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton5 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton6 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton7 = new System.Windows.Forms.ToolBarButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cListView1 = new MyComponent.CListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
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
            this.toolBar1.Location = new System.Drawing.Point(0, 36);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(1613, 47);
            this.toolBar1.TabIndex = 3;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.ImageIndex = 3;
            this.toolBarButton1.Name = "toolBarButton1";
            this.toolBarButton1.Text = "添加";
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
            this.toolBarButton4.ImageIndex = 10;
            this.toolBarButton4.Name = "toolBarButton4";
            this.toolBarButton4.Text = "删除";
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
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(7, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(960, 144);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "产品属性";
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Location = new System.Drawing.Point(160, 84);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(200, 28);
            this.textBox3.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(13, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 34);
            this.label3.TabIndex = 8;
            this.label3.Text = "经销商编号:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(360, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 34);
            this.label2.TabIndex = 6;
            this.label2.Text = "产品名称:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Location = new System.Drawing.Point(493, 36);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(440, 28);
            this.textBox2.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(13, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 34);
            this.label1.TabIndex = 4;
            this.label1.Text = "产品代码:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(147, 36);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(200, 28);
            this.textBox1.TabIndex = 5;
            // 
            // cListView1
            // 
            this.cListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader1});
            this.cListView1.FullRowSelect = true;
            this.cListView1.GridLines = true;
            this.cListView1.Location = new System.Drawing.Point(0, 264);
            this.cListView1.MultiSelect = false;
            this.cListView1.Name = "cListView1";
            this.cListView1.Size = new System.Drawing.Size(960, 300);
            this.cListView1.TabIndex = 5;
            this.cListView1.UseCompatibleStateImageBehavior = false;
            this.cListView1.View = System.Windows.Forms.View.Details;
            this.cListView1.Click += new System.EventHandler(this.cListView1_Click);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "产品代码";
            this.columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "产品名称";
            this.columnHeader4.Width = 200;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "经销商编号";
            this.columnHeader1.Width = 80;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Teal;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(976, 34);
            this.label4.TabIndex = 6;
            // 
            // FrmZGProduct
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(10, 21);
            this.ClientSize = new System.Drawing.Size(976, 384);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cListView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmZGProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "专供酒设置";
            this.Load += new System.EventHandler(this.FrmZGProduct_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region 程序入口
		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			string buttonTxt = e.Button.Text.Trim();
			switch(buttonTxt)
			{
				case "添加":
					Add();
					break;
				case "删除":
					Delete();
					break;
				case "退出":
					this.Close();
					break;
				default:
					break;
			}
		}
		#endregion

		#region 添加
		private void Add()
		{
			string productcode = textBox1.Text.Trim();
			string productname = textBox2.Text.Trim();
			string salerid = textBox3.Text.Trim();
			if((productname=="")||(productcode=="")||(salerid==""))
			{
				MessageBox.Show("请将信息输入完整");
				return;
			}
			else
			{
				if(!Exists("productcode",productcode))
				{
					if(!Exists("productname",productname))
					{
						if(AddNewRecord(productcode,productname,salerid)>0)
						{
							Queue myQueue = new Queue();
							myQueue.Enqueue(productcode);
							myQueue.Enqueue(productname);
							myQueue.Enqueue(salerid);
							AddOneRow(myQueue);
							ClearText();
						}
					}
					else
						MessageBox.Show("产品名称重复");
				}
				else
					MessageBox.Show("产品代码重复");
			}
		}
		#endregion

		#region 清除textBox的信息
		private void ClearText()
		{
			textBox1.Clear();
			textBox2.Clear();
			textBox3.Clear();
		}
		#endregion

		#region 验证是否有重复的输入信息
		private bool Exists(string colName,string strInfo)
		{
			bool result = false;
			try
			{
				string command = string.Format("select count(*) as cnt from tb_zgproduct where {0}='{1}'",colName.Trim(),strInfo.Trim());
				result = CommonClass.Exists(command,"cnt");
			}
			catch
			{
			}
			return result;
		}

		#endregion

		#region 向列表内加入一行
		private void AddOneRow(Queue myQueue)
		{
			ListViewOperator.AddOneRow(ref cListView1,myQueue);
		}
		#endregion

		#region 添加新记录
		private int AddNewRecord(string productcode,string productname,string salerid)
		{
			int result = 0;
			try
			{
				string command = string.Format("insert into tb_zgproduct(productcode,productname,salerid) values('{0}','{1}','{2}')",productcode,productname,salerid);
				result = CommonClass.ExcuteNonQuery(command);
			}
			catch
			{
			}
			return result;
		}
		#endregion

		#region 删除
		private void Delete()
		{			
			if(this._productcode.Length>0)
			{
				if(MessageBox.Show("请确认是否真的删除?","友情提示",MessageBoxButtons.YesNo)==DialogResult.Yes)
				{
					if(DeleteRecord(this._productcode))
					{
						DeleteOneRow();
					}
					else
						MessageBox.Show("删除数据出现异常");
				}
			}
			else
				MessageBox.Show("请选择要删除的记录");
			this._productcode = String.Empty;
		}
		#endregion

		#region 删除数据库内的记录
		private bool DeleteRecord(string productcode)
		{
			bool result = false;
			try
			{
				string command = string.Format("delete from tb_zgproduct where productcode='{0}'",productcode);
				int cnt = CommonClass.ExcuteNonQuery(command);
				result = ((cnt>0)?true:false);
			}
			catch
			{
			}
			return result;
		}
		#endregion

		#region 删除显示列表内的选项
		private void DeleteOneRow()
		{
			ListViewOperator.DeleteOneRow(ref cListView1);
		}
		#endregion

		#region listview click事件

		private void cListView1_Click(object sender, System.EventArgs e)
		{
			cListView1.MySelectIndex = 0;
			this._productcode = cListView1.GetMySelectIndexString();
		}
		#endregion

		private void FrmZGProduct_Load(object sender, System.EventArgs e)
		{
			if(CommonClass._connstr.Length==0)
			{
				CommonClass._connstr = ConfigurationManager.AppSettings["sql_connstr"].Trim();
			}
			if(ListViewOperator._connStr.Length==0)
			{
				ListViewOperator._connStr = ConfigurationManager.AppSettings["sql_connstr"].Trim();
			}
			cListView1.Items.Clear();
			string command = "select productcode as 产品代码,productname as 产品名称,salerid as 经销商编号 from tb_zgproduct";
			ListViewOperator.GetViewList(ref cListView1,command,CommandType.Text,new Hashtable());	
		}
	}
}
