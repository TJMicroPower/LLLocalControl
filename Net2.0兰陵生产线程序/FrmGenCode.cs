using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ComWithImaje;
using PowerData;
using FileExAndIm;

namespace LocalControl
{
	/// <summary>
	/// FrmGenCode 的摘要说明。
	/// </summary>
    public class FrmGenCode : System.Windows.Forms.Form
    {
        private System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.ToolBarButton toolBarButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_noCount;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel1;
        private string conn_str = ConfigurationManager.AppSettings["sql_connstr"];
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolBarButton toolBarButton2;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private ComboBox comboBox_codeCount;
        private int codeCount = 30000;
        /// <summary>
        /// 号码是否是当日生成。true-是；false-否。
        /// </summary>
        private bool todayCode = false;

        public FrmGenCode()
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
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGenCode));
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_noCount = new System.Windows.Forms.TextBox();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox_codeCount = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolBar1
            // 
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.toolBarButton1,
            this.toolBarButton2});
            this.toolBar1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.imageList1;
            this.toolBar1.Location = new System.Drawing.Point(0, 24);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(954, 41);
            this.toolBar1.TabIndex = 0;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.ImageIndex = 3;
            this.toolBarButton1.Name = "toolBarButton1";
            this.toolBarButton1.Text = "号码产生";
            // 
            // toolBarButton2
            // 
            this.toolBarButton2.ImageIndex = 7;
            this.toolBarButton2.Name = "toolBarButton2";
            this.toolBarButton2.Text = "退出";
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
            this.label1.Location = new System.Drawing.Point(33, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "生成数量：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox_noCount
            // 
            this.textBox_noCount.Location = new System.Drawing.Point(288, 44);
            this.textBox_noCount.Name = "textBox_noCount";
            this.textBox_noCount.Size = new System.Drawing.Size(100, 21);
            this.textBox_noCount.TabIndex = 2;
            this.textBox_noCount.Text = "30000";
            this.textBox_noCount.Visible = false;
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 184);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(954, 22);
            this.statusBar1.SizingGrip = false;
            this.statusBar1.TabIndex = 3;
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Width = 954;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Teal;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(954, 23);
            this.label2.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.DarkGreen;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button1.ImageIndex = 8;
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point(280, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(493, 32);
            this.button1.TabIndex = 15;
            this.button1.Text = "注：生成号码没有任何限制，只要数量不够了，随时可以生成。选择数量即可。";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.comboBox_codeCount);
            this.groupBox1.Location = new System.Drawing.Point(8, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(934, 78);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            // 
            // comboBox_codeCount
            // 
            this.comboBox_codeCount.FormattingEnabled = true;
            this.comboBox_codeCount.Items.AddRange(new object[] {
            "10000",
            "15000",
            "20000",
            "30000",
            "35000",
            "40000",
            "45000",
            "50000"});
            this.comboBox_codeCount.Location = new System.Drawing.Point(111, 31);
            this.comboBox_codeCount.Name = "comboBox_codeCount";
            this.comboBox_codeCount.Size = new System.Drawing.Size(142, 20);
            this.comboBox_codeCount.TabIndex = 0;
            this.comboBox_codeCount.Text = "30000";
            this.comboBox_codeCount.SelectedIndexChanged += new System.EventHandler(this.comboBox_codeCount_SelectedIndexChanged);
            // 
            // FrmGenCode
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(954, 206);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.textBox_noCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolBar1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmGenCode";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "瓶号码生成";
            this.Load += new System.EventHandler(this.FrmGenCode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private void FrmGenCode_Load(object sender, System.EventArgs e)
        {
            CommonClass._connstr = ConfigurationManager.AppSettings["sql_connstr"];
        }

        delegate void SetTextCallback();
        private void SetText()
        {
            try
            {
                if (this.comboBox_codeCount.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetText);
                    this.Invoke(d, new object[] { });
                }
                else
                {
                    codeCount = int.Parse(comboBox_codeCount.SelectedText);
                }
            }
            catch (Exception es)
            {
                return;
            }
        }

        private void Code_G()
        {
            //int cnmt = int.Parse(textBox_noCount.Text.Trim());//生成号码的数量
            //SetText();
            
            try
            {
                DataBase db = new DataBase();
                string tempStr = db.RunSelectResultsSQL("select l_maxCode from tb_glog").ToString();
                int starCode = 0;
                if (tempStr.Length > 0)
                {
                    starCode = int.Parse(tempStr);//生成号码的起始值
                }
                SqlParameter[] sp = new SqlParameter[3];
                sp[0] = new SqlParameter("@cnt", SqlDbType.Int);
                sp[0].Direction = ParameterDirection.Input;
                sp[0].Value = codeCount;
                sp[1] = new SqlParameter("@dt", SqlDbType.VarChar, 10);
                sp[1].Value = DateTime.Now.ToString("yyyy-MM-dd");
                sp[2] = new SqlParameter("@maxCode", SqlDbType.Int);
                if (todayCode)//bCode 号码是否是当日生成
                {
                    sp[2].Value = starCode + 1;
                }
                else
                {
                    sp[2].Value = -1;
                }
                PowerData.SqlDataOperator ps = new SqlDataOperator(this.conn_str);
                ps.ExecuteNonQuery("gen_bottlecode", CommandType.StoredProcedure, sp);
                SetStatusBar("");
                string tempStr1 = db.RunSelectResultsSQL("select barCode from tb_bottle where id_flag = (select min(id_flag) from tb_bottle)").ToString();
                db.RunDelOrInsertOrUppdateSQL(string.Format("update tb_glog set l_maxCode = '{0}'",tempStr1));
                SetStatusBar("号码生成完毕！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("请重新输入数据再次产生号码" + ex.ToString());
            }

        }

        private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        {
            switch (e.Button.Text)
            {
                case "号码产生":
                    try
                    {
                        bool g_allow = false;
                        string command = "select g_date from tb_glog";
                        DataSet ds = CommonClass.ExecuteDataSet(command, "tb_glog");
                        DataTable dt = ds.Tables["tb_glog"];
                        if (dt.Rows.Count > 0)
                        {
                            string o_dt = dt.Rows[0]["g_date"].ToString().Trim();
                            string n_dt = DateTime.Now.ToString("yyyy-MM-dd");
                            if (o_dt == n_dt)
                            {
                                if (MessageBox.Show("本天已经生成过号码,是否继续生成?", "友情提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    g_allow = true;
                                    todayCode = true;
                                }

                            }
                            else
                            {
                                g_allow = true;
                                todayCode = false;
                            }
                        }
                        else
                        {
                            g_allow = true;
                            todayCode = false;
                        }

                        if (g_allow)
                        {
                            //int cnt = int.Parse(textBox_noCount.Text.Trim());

                            codeCount = int.Parse(comboBox_codeCount.SelectedText);


                            Thread myTh = new Thread(new ThreadStart(Code_G));
                            myTh.Start();
                            SetStatusBar("号码产生过程中，请耐心等待...");

                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        MessageBox.Show("请输入数字");
                    }
                    break;
                case "退出":
                    this.Close();
                    break;
            }
        }

        delegate void SetstatusBarCallback(string text);
        /// <summary>
        /// statusBar1.Panels[0].Text = text
        /// </summary>
        /// <param name="text"></param>
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
                    statusBar1.Panels[0].Text = text;
                }
            }
            catch (Exception es)
            {
                string s = es.ToString();
                return;
            }
        }

        private void comboBox_codeCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            codeCount = int.Parse(comboBox_codeCount.SelectedItem.ToString());
        }
    }
}


