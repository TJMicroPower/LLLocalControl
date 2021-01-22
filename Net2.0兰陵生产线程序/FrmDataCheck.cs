using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace LocalControl
{
	/// <summary>
	/// FrmDataCheck 的摘要说明。
	/// </summary>
	public class FrmDataCheck : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private string conn_str = ConfigurationManager.AppSettings["sql_connstr"].Trim();
		ClassLocalControl _clc = null;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ToolBarButton toolBarButton2;
		private System.Windows.Forms.ToolBarButton toolBarButton3;
		private System.Windows.Forms.ToolBarButton toolBarButton4;
		private System.Windows.Forms.ToolBarButton toolBarButton5;
		private System.Windows.Forms.DataGrid dgdList;
		private System.ComponentModel.IContainer components;


		private DataTable dtData;
		private DataSet dst;
		private int id_flag = 0 ;
		private int min_id_flag = 0;
		private System.Windows.Forms.ToolBarButton toolBarButton6;
		private System.Windows.Forms.Button button1;
		private int max_id_flag = 0; 
		

		public FrmDataCheck()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDataCheck));
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton4 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton5 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton6 = new System.Windows.Forms.ToolBarButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgdList = new System.Windows.Forms.DataGrid();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgdList)).BeginInit();
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
            this.toolBarButton6});
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
            this.toolBarButton1.ImageIndex = 8;
            this.toolBarButton1.Name = "toolBarButton1";
            this.toolBarButton1.Text = "查询";
            // 
            // toolBarButton2
            // 
            this.toolBarButton2.ImageIndex = 21;
            this.toolBarButton2.Name = "toolBarButton2";
            this.toolBarButton2.Text = "首条";
            // 
            // toolBarButton3
            // 
            this.toolBarButton3.ImageIndex = 15;
            this.toolBarButton3.Name = "toolBarButton3";
            this.toolBarButton3.Text = "上一条";
            // 
            // toolBarButton4
            // 
            this.toolBarButton4.ImageIndex = 16;
            this.toolBarButton4.Name = "toolBarButton4";
            this.toolBarButton4.Text = "下一条";
            // 
            // toolBarButton5
            // 
            this.toolBarButton5.ImageIndex = 20;
            this.toolBarButton5.Name = "toolBarButton5";
            this.toolBarButton5.Text = "最后";
            // 
            // toolBarButton6
            // 
            this.toolBarButton6.ImageIndex = 9;
            this.toolBarButton6.Name = "toolBarButton6";
            this.toolBarButton6.Text = "退出";
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
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(8, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "箱号";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(56, 80);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(168, 21);
            this.textBox1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Teal;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(992, 23);
            this.label3.TabIndex = 9;
            // 
            // dgdList
            // 
            this.dgdList.AlternatingBackColor = System.Drawing.Color.White;
            this.dgdList.BackColor = System.Drawing.Color.White;
            this.dgdList.BackgroundColor = System.Drawing.Color.Silver;
            this.dgdList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgdList.CaptionBackColor = System.Drawing.Color.Teal;
            this.dgdList.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.dgdList.CaptionForeColor = System.Drawing.Color.White;
            this.dgdList.DataMember = "";
            this.dgdList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgdList.FlatMode = true;
            this.dgdList.Font = new System.Drawing.Font("Tahoma", 9F);
            this.dgdList.ForeColor = System.Drawing.Color.Black;
            this.dgdList.GridLineColor = System.Drawing.Color.Silver;
            this.dgdList.HeaderBackColor = System.Drawing.Color.Black;
            this.dgdList.HeaderFont = new System.Drawing.Font("Tahoma", 8F);
            this.dgdList.HeaderForeColor = System.Drawing.Color.White;
            this.dgdList.LinkColor = System.Drawing.Color.Purple;
            this.dgdList.Location = new System.Drawing.Point(0, 112);
            this.dgdList.Name = "dgdList";
            this.dgdList.ParentRowsBackColor = System.Drawing.Color.Gray;
            this.dgdList.ParentRowsForeColor = System.Drawing.Color.White;
            this.dgdList.SelectionBackColor = System.Drawing.Color.Maroon;
            this.dgdList.SelectionForeColor = System.Drawing.Color.White;
            this.dgdList.Size = new System.Drawing.Size(992, 400);
            this.dgdList.TabIndex = 11;
            this.dgdList.Navigate += new System.Windows.Forms.NavigateEventHandler(this.dgdList_Navigate);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.DarkGreen;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.ImageIndex = 8;
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point(240, 80);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(728, 24);
            this.button1.TabIndex = 12;
            this.button1.Text = "输入箱号查询得到记录后，可以直接点击上一条，下一条察看相应的记录，注意此时搜索框中的箱号还是原来的，并没有变化！";
            // 
            // FrmDataCheck
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(992, 512);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgdList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmDataCheck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "数据查询";
            ((System.ComponentModel.ISupportInitialize)(this.dgdList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region 程序入口
		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			string buttonTxt = e.Button.Text;
			switch(buttonTxt)
			{
				case "查询":
//					LocalCheck();//以前的查询
					LoadData();
					SetDataGrid();
					break;
				case "首条":
					string cmdfirst = string.Format("select id_flag,boxcode,bottlecode from tb_bind where id_flag = {0}",min_id_flag);
					this.LoadPosition(cmdfirst);
					id_flag = min_id_flag;
					break;
				case "上一条":
					if(id_flag>min_id_flag)
					{
						string cmdStr = string.Format("select id_flag,boxcode,bottlecode from tb_bind where id_flag = {0}",id_flag-1);
						
						this.LoadPosition(cmdStr);
						id_flag -=1;
					}
					break;
				case "下一条":
					if(id_flag<max_id_flag)
					{
						string cmdlastStr = string.Format("select id_flag,boxcode,bottlecode from tb_bind where id_flag = {0}",id_flag+1);
						this.LoadPosition(cmdlastStr);
						id_flag +=1;
					}
					break;
				case "最后":
					if(id_flag<max_id_flag)
					{
						string cmdlastStr = string.Format("select id_flag,boxcode,bottlecode from tb_bind where id_flag = {0}",max_id_flag);
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
		#endregion

		#region 查询
		private void LocalCheck()
		{
			try
			{
				string boxcode = textBox1.Text.Trim();
				if(boxcode.Length<=0)
				{
					MessageBox.Show("请输入箱号码！");
				}
				else
				{
					string command = string.Format("select * from tb_bind where boxcode='{0}'",boxcode);
					string tableName = "tb_bind";
					DataTable dt = ExecuteTable(command,tableName);
					if(dt.Rows.Count>0)
					{
						string bottlecode = dt.Rows[0]["bottlecode"].ToString();
						AddToListBox(bottlecode);
					}
					else
					{
						MessageBox.Show("对不起，无此箱号");
					}
				}
			}
			catch
			{
				MessageBox.Show("系统异常,请重新查询");
			}
		}
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
		private DataTable ExecuteTable(string command,string tableName)
		{
			DataTable result = null;
			try
			{
				DataSet ds = _clc.ExecuteDataSet(command,tableName);
				result = ds.Tables[tableName];								
			}
			catch(Exception ex)
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
			dst = db.RunDataSetSQL(positionStr,"tb_bind");
			dgdList.DataSource = dst.Tables["tb_bind"];
			dtData = dst.Tables["tb_bind"];
			SetDataGrid();
		}

		#region LoadData()
		
		public void  LoadData()
		{
			try
			{
				if(this.textBox1.Text.Trim().Length==0)
				{
					MessageBox.Show("请输入箱号！");
				}
				else
				{
					DataBase db = new DataBase();
					string selectid_flag = string.Format("select id_flag from tb_bind where boxcode = '{0}'",this.textBox1.Text.Trim());
					string select_minid_flag = "select min(id_flag) from tb_bind";
					string select_maxid_flag = "select max(id_flag) from tb_bind";
					if(db.RunSelectResultsSQL(selectid_flag).ToString()=="")
					{
						MessageBox.Show("您所查询的箱号不存在，请检查是否输入有误！");
					}
					else
					{
						string cmdString = string.Format("select id_flag,boxcode,bottlecode from tb_bind where boxcode = '{0}'",this.textBox1.Text.Trim());
						dst = new DataSet();
						//根据查询条件重新填充DataSet dst
						dst.Clear();
						dst = db.RunDataSetSQL(cmdString,"tb_bind");
						dgdList.DataSource = dst.Tables["tb_bind"];
						dtData = dst.Tables["tb_bind"];
						id_flag = int.Parse(db.RunSelectResultsSQL(selectid_flag).ToString());
						min_id_flag = int.Parse(db.RunSelectResultsSQL(select_minid_flag).ToString());
						max_id_flag = int.Parse(db.RunSelectResultsSQL(select_maxid_flag).ToString());
					}
					
				}
			}
			catch(Exception es)
			{
				MessageBox.Show(es.ToString());
			}
			
		}
		#endregion
		
		#region SetDataGrid()
		public  void SetDataGrid()
		{
//			LoadData();
			//定义一个DataGrid表样式
			try
			{
				DataGridTableStyle ts = new DataGridTableStyle();
				string []HeadText = new string[]{"顺序号","箱号","             瓶号"}; 
				int numCols = dtData.Columns.Count+0;
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
							aCol.Width = 50;
						
							break;
						case 1:
							aCol.Width = 120;
						
							break;
						case 2:
							aCol.Width = 780;
						
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
			catch(Exception es)
			{
				MessageBox.Show("设置数据显示格式时出错！"+es.ToString());
			}
		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
			
		}

		private void dgdList_Navigate(object sender, System.Windows.Forms.NavigateEventArgs ne)
		{
		
		}
	}
}
