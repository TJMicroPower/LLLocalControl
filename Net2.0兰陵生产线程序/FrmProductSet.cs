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
	/// FrmProductSet ��ժҪ˵����
	/// </summary>
	public class FrmProductSet : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.ToolBarButton toolBarButton2;
		private System.Windows.Forms.ToolBarButton toolBarButton3;
		private System.Windows.Forms.ToolBarButton toolBarButton4;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox2;		
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.ComponentModel.IContainer components;
		private MyComponent.CListView cListView1;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ToolBarButton toolBarButton5;
		private System.Windows.Forms.ToolBarButton toolBarButton6;
		private System.Windows.Forms.ToolBarButton toolBarButton7;
		private System.Windows.Forms.ImageList imageList1;		
		private string _productcode = string.Empty;

		public FrmProductSet()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FrmProductSet));
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
			this.label2 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.cListView1 = new MyComponent.CListView();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.label3 = new System.Windows.Forms.Label();
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
			this.toolBar1.Location = new System.Drawing.Point(0, 24);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(144, 41);
			this.toolBar1.TabIndex = 2;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// toolBarButton1
			// 
			this.toolBarButton1.ImageIndex = 3;
			this.toolBarButton1.Text = "���";
			// 
			// toolBarButton2
			// 
			this.toolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// toolBarButton3
			// 
			this.toolBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// toolBarButton4
			// 
			this.toolBarButton4.ImageIndex = 10;
			this.toolBarButton4.Text = "ɾ��";
			// 
			// toolBarButton5
			// 
			this.toolBarButton5.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// toolBarButton6
			// 
			this.toolBarButton6.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// toolBarButton7
			// 
			this.toolBarButton7.ImageIndex = 7;
			this.toolBarButton7.Text = "�˳�";
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.textBox2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Location = new System.Drawing.Point(8, 80);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(576, 56);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "��Ʒ����";
			// 
			// label2
			// 
			this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label2.Location = new System.Drawing.Point(216, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 23);
			this.label2.TabIndex = 6;
			this.label2.Text = "��Ʒ����:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox2
			// 
			this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox2.Location = new System.Drawing.Point(296, 24);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(264, 21);
			this.textBox2.TabIndex = 7;
			this.textBox2.Text = "";
			// 
			// label1
			// 
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label1.Location = new System.Drawing.Point(8, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 23);
			this.label1.TabIndex = 4;
			this.label1.Text = "��Ʒ����:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox1
			// 
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox1.Location = new System.Drawing.Point(88, 24);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(120, 21);
			this.textBox1.TabIndex = 5;
			this.textBox1.Text = "";
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "��Ʒ����";
			this.columnHeader1.Width = 140;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "��Ʒ����";
			this.columnHeader2.Width = 300;
			// 
			// cListView1
			// 
			this.cListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						 this.columnHeader3,
																						 this.columnHeader4});
			this.cListView1.FullRowSelect = true;
			this.cListView1.GridLines = true;
			this.cListView1.Location = new System.Drawing.Point(8, 144);
			this.cListView1.MultiSelect = false;
			this.cListView1.Name = "cListView1";
			this.cListView1.Size = new System.Drawing.Size(576, 200);
			this.cListView1.TabIndex = 4;
			this.cListView1.View = System.Windows.Forms.View.Details;
			this.cListView1.Click += new System.EventHandler(this.cListView1_Click);
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "��Ʒ����";
			this.columnHeader3.Width = 120;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "��Ʒ����";
			this.columnHeader4.Width = 200;
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.Teal;
			this.label3.Dock = System.Windows.Forms.DockStyle.Top;
			this.label3.Location = new System.Drawing.Point(0, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(792, 23);
			this.label3.TabIndex = 5;
			// 
			// FrmProductSet
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(792, 352);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cListView1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.toolBar1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "FrmProductSet";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "��Ʒ����";
			this.Load += new System.EventHandler(this.FrmProductSet_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		

		
		

		#region �������

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			string buttonTxt = e.Button.Text.Trim();
			switch(buttonTxt)
			{
				case "���":
					Add();
					break;
				case "ɾ��":
					Delete();
					break;
				case "�˳�":
					this.Close();
					break;
				default:
					break;
			}
		}
		#endregion

		#region ���
		private void Add()
		{
			string productcode = textBox1.Text.Trim();
			string productname = textBox2.Text.Trim();			
			if((productname=="")||(productcode==""))
			{
				MessageBox.Show("�뽫��Ϣ��������");
				return;
			}
			else
			{
				if(!Exists("productcode",productcode))
				{
					if(!Exists("productname",productname))
					{
						if(AddNewRecord(productcode,productname)>0)
						{
							Queue myQueue = new Queue();
							myQueue.Enqueue(productcode);
							myQueue.Enqueue(productname);
							AddOneRow(myQueue);
							ClearText();
						}
					}
					else
						MessageBox.Show("��Ʒ�����ظ�");
				}
				else
					MessageBox.Show("��Ʒ�����ظ�");
			}
		}
		#endregion

		#region ���textBox����Ϣ
		private void ClearText()
		{
			textBox1.Clear();
			textBox2.Clear();
		}
		#endregion

		#region ��֤�Ƿ����ظ���������Ϣ
		private bool Exists(string colName,string strInfo)
		{
			bool result = false;
			try
			{
				string command = string.Format("select count(*) as cnt from tb_productset where {0}='{1}'",colName.Trim(),strInfo.Trim());
				result = CommonClass.Exists(command,"cnt");
			}
			catch
			{
			}
			return result;
		}

		#endregion

		#region ���б��ڼ���һ��
		private void AddOneRow(Queue myQueue)
		{
			ListViewOperator.AddOneRow(ref cListView1,myQueue);
		}
		#endregion

		#region ����¼�¼
		private int AddNewRecord(string productcode,string productname)
		{
			int result = 0;
			try
			{
				string command = string.Format("insert into tb_productset(productcode,productname) values('{0}','{1}')",productcode,productname);
				result = CommonClass.ExcuteNonQuery(command);
			}
			catch
			{
			}
			return result;
		}
		#endregion

		#region ɾ��
		private void Delete()
		{			
			if(this._productcode.Length>0)
			{
				if(MessageBox.Show("��ȷ���Ƿ����ɾ��?","������ʾ",MessageBoxButtons.YesNo)==DialogResult.Yes)
				{
					if(DeleteRecord(this._productcode))
					{
						DeleteOneRow();
					}
					else
						MessageBox.Show("ɾ�����ݳ����쳣");
				}
			}
			else
				MessageBox.Show("��ѡ��Ҫɾ���ļ�¼");
			this._productcode = String.Empty;
		}
		#endregion

		#region ɾ�����ݿ��ڵļ�¼
		private bool DeleteRecord(string productcode)
		{
			bool result = false;
			try
			{
				string command = string.Format("delete from tb_productset where productcode='{0}'",productcode);
				int cnt = CommonClass.ExcuteNonQuery(command);
				result = ((cnt>0)?true:false);
			}
			catch
			{
			}
			return result;
		}
		#endregion

		#region ɾ����ʾ�б��ڵ�ѡ��
		private void DeleteOneRow()
		{
			ListViewOperator.DeleteOneRow(ref cListView1);
		}
		#endregion

		#region listview click�¼�

		private void cListView1_Click(object sender, System.EventArgs e)
		{
			cListView1.MySelectIndex = 0;
			this._productcode = cListView1.GetMySelectIndexString();
		}
		#endregion

		#region ����load�¼�
		private void FrmProductSet_Load(object sender, System.EventArgs e)
		{
            //tpCodeLength = ConfigurationManager.AppSettings["tpCodeLength"].ToString();
            if(CommonClass._connstr.Length==0)
			{
				CommonClass._connstr = ConfigurationManager.AppSettings["sql_connstr"].Trim();
			}
			if(ListViewOperator._connStr.Length==0)
			{
				ListViewOperator._connStr = ConfigurationManager.AppSettings["sql_connstr"].Trim();
			}
			cListView1.Items.Clear();
			string command = "select productcode as ��Ʒ����,productname as ��Ʒ���� from tb_productset";
			ListViewOperator.GetViewList(ref cListView1,command,CommandType.Text,new Hashtable());				
		}
		#endregion
	}
}
