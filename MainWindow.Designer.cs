namespace Universal_SaveData_Chapter_Tool
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.savedatapathsbox = new System.Windows.Forms.ComboBox();
            this.addpathbut = new System.Windows.Forms.Button();
            this.delpathbut = new System.Windows.Forms.Button();
            this.filelistbox = new System.Windows.Forms.CheckedListBox();
            this.filelistupdate = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.UpdateFilelist = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.aboutbut = new System.Windows.Forms.Button();
            this.delselectfilesbut = new System.Windows.Forms.Button();
            this.delselectpartbut = new System.Windows.Forms.Button();
            this.selectnumberbut = new System.Windows.Forms.Button();
            this.selectallbut = new System.Windows.Forms.Button();
            this.partslistbox = new System.Windows.Forms.ComboBox();
            this.loadbut = new System.Windows.Forms.Button();
            this.savebut = new System.Windows.Forms.Button();
            this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.filelistupdate.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.splitContainer1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(530, 47);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "目录";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 17);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.savedatapathsbox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.addpathbut);
            this.splitContainer1.Panel2.Controls.Add(this.delpathbut);
            this.splitContainer1.Size = new System.Drawing.Size(524, 27);
            this.splitContainer1.SplitterDistance = 440;
            this.splitContainer1.TabIndex = 3;
            // 
            // savedatapathsbox
            // 
            this.savedatapathsbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.savedatapathsbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.savedatapathsbox.FormattingEnabled = true;
            this.savedatapathsbox.Location = new System.Drawing.Point(0, 0);
            this.savedatapathsbox.MaxDropDownItems = 80;
            this.savedatapathsbox.Name = "savedatapathsbox";
            this.savedatapathsbox.Size = new System.Drawing.Size(440, 20);
            this.savedatapathsbox.TabIndex = 0;
            this.savedatapathsbox.SelectedIndexChanged += new System.EventHandler(this.savedatapathsbox_SelectedIndexChanged);
            // 
            // addpathbut
            // 
            this.addpathbut.Location = new System.Drawing.Point(2, -1);
            this.addpathbut.Name = "addpathbut";
            this.addpathbut.Size = new System.Drawing.Size(26, 23);
            this.addpathbut.TabIndex = 1;
            this.addpathbut.Text = "+";
            this.addpathbut.UseVisualStyleBackColor = true;
            this.addpathbut.Click += new System.EventHandler(this.addpathbut_Click);
            // 
            // delpathbut
            // 
            this.delpathbut.Location = new System.Drawing.Point(34, -1);
            this.delpathbut.Name = "delpathbut";
            this.delpathbut.Size = new System.Drawing.Size(27, 23);
            this.delpathbut.TabIndex = 2;
            this.delpathbut.Text = "-";
            this.delpathbut.UseVisualStyleBackColor = true;
            this.delpathbut.Click += new System.EventHandler(this.delpathbut_Click);
            // 
            // filelistbox
            // 
            this.filelistbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filelistbox.ContextMenuStrip = this.filelistupdate;
            this.filelistbox.FormattingEnabled = true;
            this.filelistbox.Items.AddRange(new object[] {
            "感谢使用Universal SaveData Chapter Tool!",
            "Universal SaveData Chapter Tool v2.23.9.28 中秋节更新！！",
            "项目链接 https://github.com/TeaRed-LeafFall/UniversalSaveDataChapterTool",
            "原作者 github.com/TeaRed-LeafFall",
            "===",
            "茶红落叶 祝你中秋节快乐!",
            "太平风物，团圆安康!",
            "===",
            "简易的操作指示：",
            "请加载对应游戏的存档位置（选择注册，打开文件夹或者拖动文件夹到窗口）",
            "如果加载完成了将会保存已经被集合记录的文件夹（在SaveDataPaths.txt）",
            "操作非常简单，基本无需教程"});
            this.filelistbox.Location = new System.Drawing.Point(12, 45);
            this.filelistbox.Name = "filelistbox";
            this.filelistbox.ScrollAlwaysVisible = true;
            this.filelistbox.Size = new System.Drawing.Size(510, 324);
            this.filelistbox.TabIndex = 1;
            this.filelistbox.DragDrop += new System.Windows.Forms.DragEventHandler(this.Folder_DragDrop);
            this.filelistbox.DragEnter += new System.Windows.Forms.DragEventHandler(this.Folder_DragEnter);
            this.filelistbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.filelistbox_KeyDown);
            // 
            // filelistupdate
            // 
            this.filelistupdate.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UpdateFilelist});
            this.filelistupdate.Name = "filelistupdate";
            this.filelistupdate.Size = new System.Drawing.Size(169, 28);
            // 
            // UpdateFilelist
            // 
            this.UpdateFilelist.Name = "UpdateFilelist";
            this.UpdateFilelist.Size = new System.Drawing.Size(168, 24);
            this.UpdateFilelist.Text = "更新文件列表";
            this.UpdateFilelist.Click += new System.EventHandler(this.UpdateFilelist_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.aboutbut);
            this.groupBox2.Controls.Add(this.delselectfilesbut);
            this.groupBox2.Controls.Add(this.delselectpartbut);
            this.groupBox2.Controls.Add(this.selectnumberbut);
            this.groupBox2.Controls.Add(this.selectallbut);
            this.groupBox2.Controls.Add(this.partslistbox);
            this.groupBox2.Controls.Add(this.loadbut);
            this.groupBox2.Controls.Add(this.savebut);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 382);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(530, 124);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "操作";
            // 
            // aboutbut
            // 
            this.aboutbut.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.aboutbut.ForeColor = System.Drawing.SystemColors.ControlText;
            this.aboutbut.Location = new System.Drawing.Point(286, 43);
            this.aboutbut.Name = "aboutbut";
            this.aboutbut.Size = new System.Drawing.Size(75, 23);
            this.aboutbut.TabIndex = 7;
            this.aboutbut.Text = "关于";
            this.aboutbut.UseVisualStyleBackColor = true;
            this.aboutbut.Click += new System.EventHandler(this.aboutbut_Click);
            // 
            // delselectfilesbut
            // 
            this.delselectfilesbut.ForeColor = System.Drawing.Color.Red;
            this.delselectfilesbut.Location = new System.Drawing.Point(6, 75);
            this.delselectfilesbut.Name = "delselectfilesbut";
            this.delselectfilesbut.Size = new System.Drawing.Size(177, 23);
            this.delselectfilesbut.TabIndex = 6;
            this.delselectfilesbut.Text = "!删除目前文件夹的选中文件!";
            this.delselectfilesbut.UseVisualStyleBackColor = true;
            this.delselectfilesbut.Click += new System.EventHandler(this.delselectfilesbut_Click);
            // 
            // delselectpartbut
            // 
            this.delselectpartbut.ForeColor = System.Drawing.Color.Red;
            this.delselectpartbut.Location = new System.Drawing.Point(202, 75);
            this.delselectpartbut.Name = "delselectpartbut";
            this.delselectpartbut.Size = new System.Drawing.Size(159, 23);
            this.delselectpartbut.TabIndex = 5;
            this.delselectpartbut.Text = "!删除目前选中章文件夹!";
            this.delselectpartbut.UseVisualStyleBackColor = true;
            this.delselectpartbut.Click += new System.EventHandler(this.delselectpartbut_Click);
            // 
            // selectnumberbut
            // 
            this.selectnumberbut.Location = new System.Drawing.Point(189, 43);
            this.selectnumberbut.Name = "selectnumberbut";
            this.selectnumberbut.Size = new System.Drawing.Size(93, 23);
            this.selectnumberbut.TabIndex = 4;
            this.selectnumberbut.Text = "选带数字的";
            this.selectnumberbut.UseVisualStyleBackColor = true;
            this.selectnumberbut.Click += new System.EventHandler(this.selectnumberbut_Click);
            // 
            // selectallbut
            // 
            this.selectallbut.Location = new System.Drawing.Point(130, 43);
            this.selectallbut.Name = "selectallbut";
            this.selectallbut.Size = new System.Drawing.Size(53, 23);
            this.selectallbut.TabIndex = 3;
            this.selectallbut.Text = "全选";
            this.selectallbut.UseVisualStyleBackColor = true;
            this.selectallbut.Click += new System.EventHandler(this.selectallbut_Click);
            // 
            // partslistbox
            // 
            this.partslistbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.partslistbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.partslistbox.FormattingEnabled = true;
            this.partslistbox.Location = new System.Drawing.Point(3, 17);
            this.partslistbox.MaxDropDownItems = 80;
            this.partslistbox.Name = "partslistbox";
            this.partslistbox.Size = new System.Drawing.Size(524, 20);
            this.partslistbox.Sorted = true;
            this.partslistbox.TabIndex = 2;
            // 
            // loadbut
            // 
            this.loadbut.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.loadbut.Location = new System.Drawing.Point(69, 43);
            this.loadbut.Name = "loadbut";
            this.loadbut.Size = new System.Drawing.Size(55, 23);
            this.loadbut.TabIndex = 1;
            this.loadbut.Text = "读取";
            this.loadbut.UseVisualStyleBackColor = true;
            this.loadbut.Click += new System.EventHandler(this.loadbut_Click);
            // 
            // savebut
            // 
            this.savebut.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.savebut.ForeColor = System.Drawing.SystemColors.ControlText;
            this.savebut.Location = new System.Drawing.Point(3, 43);
            this.savebut.Name = "savebut";
            this.savebut.Size = new System.Drawing.Size(57, 23);
            this.savebut.TabIndex = 0;
            this.savebut.Text = "保存";
            this.savebut.UseVisualStyleBackColor = true;
            this.savebut.Click += new System.EventHandler(this.savebut_Click);
            // 
            // MainWindow
            // 
            this.AcceptButton = this.aboutbut;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(530, 506);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.filelistbox);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(401, 545);
            this.Name = "MainWindow";
            this.Text = "Universal SaveData Chapter Tool v2.23.9.28 中秋节更新！！";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.groupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.filelistupdate.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button delpathbut;
        private System.Windows.Forms.Button addpathbut;
        private System.Windows.Forms.ComboBox savedatapathsbox;
        private System.Windows.Forms.CheckedListBox filelistbox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button loadbut;
        private System.Windows.Forms.Button savebut;
        private System.Windows.Forms.Button delselectfilesbut;
        private System.Windows.Forms.Button delselectpartbut;
        private System.Windows.Forms.Button selectnumberbut;
        private System.Windows.Forms.Button selectallbut;
        private System.Windows.Forms.ComboBox partslistbox;
        private System.Windows.Forms.Button aboutbut;
        private System.Windows.Forms.FolderBrowserDialog folderDialog;
        private System.Windows.Forms.ContextMenuStrip filelistupdate;
        private System.Windows.Forms.ToolStripMenuItem UpdateFilelist;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}