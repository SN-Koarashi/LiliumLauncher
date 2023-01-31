namespace XCoreNET
{
    partial class minecraftVersionSelector
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkLoader = new System.Windows.Forms.CheckBox();
            this.chkSnapshot = new System.Windows.Forms.CheckBox();
            this.chkRelease = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radNoInstalled = new System.Windows.Forms.RadioButton();
            this.radInstalled = new System.Windows.Forms.RadioButton();
            this.radAll = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.panelMain);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(544, 311);
            this.panel1.TabIndex = 1;
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.groupBox2);
            this.panelMain.Controls.Add(this.groupBox1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelMain.Location = new System.Drawing.Point(397, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(147, 311);
            this.panelMain.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkLoader);
            this.groupBox2.Controls.Add(this.chkSnapshot);
            this.groupBox2.Controls.Add(this.chkRelease);
            this.groupBox2.Location = new System.Drawing.Point(4, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(136, 91);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "版本過濾器";
            // 
            // chkLoader
            // 
            this.chkLoader.AutoSize = true;
            this.chkLoader.Location = new System.Drawing.Point(7, 67);
            this.chkLoader.Name = "chkLoader";
            this.chkLoader.Size = new System.Drawing.Size(84, 16);
            this.chkLoader.TabIndex = 2;
            this.chkLoader.Text = "模組載入器";
            this.chkLoader.UseVisualStyleBackColor = true;
            this.chkLoader.Click += new System.EventHandler(this.chkLoader_Click);
            // 
            // chkSnapshot
            // 
            this.chkSnapshot.AutoSize = true;
            this.chkSnapshot.Location = new System.Drawing.Point(7, 45);
            this.chkSnapshot.Name = "chkSnapshot";
            this.chkSnapshot.Size = new System.Drawing.Size(60, 16);
            this.chkSnapshot.TabIndex = 1;
            this.chkSnapshot.Text = "快照版";
            this.chkSnapshot.UseVisualStyleBackColor = true;
            this.chkSnapshot.Click += new System.EventHandler(this.chkSnapshot_Click);
            // 
            // chkRelease
            // 
            this.chkRelease.AutoSize = true;
            this.chkRelease.Checked = true;
            this.chkRelease.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRelease.Location = new System.Drawing.Point(7, 23);
            this.chkRelease.Name = "chkRelease";
            this.chkRelease.Size = new System.Drawing.Size(60, 16);
            this.chkRelease.TabIndex = 0;
            this.chkRelease.Text = "正式版";
            this.chkRelease.UseVisualStyleBackColor = true;
            this.chkRelease.Click += new System.EventHandler(this.chkRelease_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radNoInstalled);
            this.groupBox1.Controls.Add(this.radInstalled);
            this.groupBox1.Controls.Add(this.radAll);
            this.groupBox1.Location = new System.Drawing.Point(4, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(136, 92);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "狀態過濾器";
            // 
            // radNoInstalled
            // 
            this.radNoInstalled.AutoSize = true;
            this.radNoInstalled.Location = new System.Drawing.Point(7, 65);
            this.radNoInstalled.Name = "radNoInstalled";
            this.radNoInstalled.Size = new System.Drawing.Size(95, 16);
            this.radNoInstalled.TabIndex = 2;
            this.radNoInstalled.Text = "僅顯示未安裝";
            this.radNoInstalled.UseVisualStyleBackColor = true;
            this.radNoInstalled.Click += new System.EventHandler(this.radNoInstalled_Click);
            // 
            // radInstalled
            // 
            this.radInstalled.AutoSize = true;
            this.radInstalled.Location = new System.Drawing.Point(7, 43);
            this.radInstalled.Name = "radInstalled";
            this.radInstalled.Size = new System.Drawing.Size(95, 16);
            this.radInstalled.TabIndex = 1;
            this.radInstalled.Text = "僅顯示已安裝";
            this.radInstalled.UseVisualStyleBackColor = true;
            this.radInstalled.Click += new System.EventHandler(this.radInstalled_Click);
            // 
            // radAll
            // 
            this.radAll.AutoSize = true;
            this.radAll.Checked = true;
            this.radAll.Location = new System.Drawing.Point(7, 21);
            this.radAll.Name = "radAll";
            this.radAll.Size = new System.Drawing.Size(71, 16);
            this.radAll.TabIndex = 0;
            this.radAll.TabStop = true;
            this.radAll.Text = "全部顯示";
            this.radAll.UseVisualStyleBackColor = true;
            this.radAll.Click += new System.EventHandler(this.radAll_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(397, 311);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // minecraftVersionSelector
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(544, 311);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(560, 350);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(560, 350);
            this.Name = "minecraftVersionSelector";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "版本選擇器";
            this.Load += new System.EventHandler(this.minecraftVersionSelector_Load);
            this.Resize += new System.EventHandler(this.minecraftVersionSelector_Resize);
            this.panel1.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radNoInstalled;
        private System.Windows.Forms.RadioButton radInstalled;
        private System.Windows.Forms.RadioButton radAll;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkSnapshot;
        private System.Windows.Forms.CheckBox chkRelease;
        private System.Windows.Forms.CheckBox chkLoader;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}