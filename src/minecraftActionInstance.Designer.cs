namespace LiliumLauncher
{
    partial class minecraftActionInstance
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnVersionSelector = new System.Windows.Forms.Button();
            this.textBoxNowVersion = new System.Windows.Forms.TextBox();
            this.chkOpenSpecific = new System.Windows.Forms.CheckBox();
            this.textInstanceName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnIntro = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnJava = new System.Windows.Forms.Button();
            this.textJava = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textJVM = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnVersionSelector);
            this.groupBox1.Controls.Add(this.textBoxNowVersion);
            this.groupBox1.Controls.Add(this.chkOpenSpecific);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(12, 97);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(225, 59);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "以指定版本啟動";
            // 
            // btnVersionSelector
            // 
            this.btnVersionSelector.Enabled = false;
            this.btnVersionSelector.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnVersionSelector.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnVersionSelector.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnVersionSelector.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVersionSelector.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnVersionSelector.Location = new System.Drawing.Point(197, 21);
            this.btnVersionSelector.Name = "btnVersionSelector";
            this.btnVersionSelector.Size = new System.Drawing.Size(22, 25);
            this.btnVersionSelector.TabIndex = 3;
            this.btnVersionSelector.Text = "+";
            this.btnVersionSelector.UseVisualStyleBackColor = true;
            this.btnVersionSelector.Click += new System.EventHandler(this.btnVersionSelector_Click);
            // 
            // textBoxNowVersion
            // 
            this.textBoxNowVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxNowVersion.Enabled = false;
            this.textBoxNowVersion.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxNowVersion.Location = new System.Drawing.Point(64, 22);
            this.textBoxNowVersion.MinimumSize = new System.Drawing.Size(0, 23);
            this.textBoxNowVersion.Name = "textBoxNowVersion";
            this.textBoxNowVersion.ReadOnly = true;
            this.textBoxNowVersion.Size = new System.Drawing.Size(130, 23);
            this.textBoxNowVersion.TabIndex = 1;
            // 
            // chkOpenSpecific
            // 
            this.chkOpenSpecific.AutoSize = true;
            this.chkOpenSpecific.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.chkOpenSpecific.Location = new System.Drawing.Point(7, 24);
            this.chkOpenSpecific.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkOpenSpecific.Name = "chkOpenSpecific";
            this.chkOpenSpecific.Size = new System.Drawing.Size(51, 20);
            this.chkOpenSpecific.TabIndex = 0;
            this.chkOpenSpecific.Text = "開啟";
            this.chkOpenSpecific.UseVisualStyleBackColor = true;
            this.chkOpenSpecific.CheckedChanged += new System.EventHandler(this.chkOpenSpecific_CheckedChanged);
            // 
            // textInstanceName
            // 
            this.textInstanceName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textInstanceName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.textInstanceName.Location = new System.Drawing.Point(7, 44);
            this.textInstanceName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textInstanceName.MinimumSize = new System.Drawing.Size(0, 23);
            this.textInstanceName.Name = "textInstanceName";
            this.textInstanceName.Size = new System.Drawing.Size(207, 23);
            this.textInstanceName.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textInstanceName);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox2.Location = new System.Drawing.Point(12, 13);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(225, 76);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "實例名稱";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "輸入您自身可供辨識的實例名稱";
            // 
            // btnIntro
            // 
            this.btnIntro.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnIntro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnIntro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnIntro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIntro.Location = new System.Drawing.Point(37, 307);
            this.btnIntro.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnIntro.Name = "btnIntro";
            this.btnIntro.Size = new System.Drawing.Size(97, 33);
            this.btnIntro.TabIndex = 4;
            this.btnIntro.Text = "說明";
            this.btnIntro.UseVisualStyleBackColor = true;
            this.btnIntro.Click += new System.EventHandler(this.btnIntro_Click);
            // 
            // btnOK
            // 
            this.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(140, 307);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(97, 33);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "確定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnJava);
            this.groupBox3.Controls.Add(this.textJava);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox3.Location = new System.Drawing.Point(12, 163);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(225, 76);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "自訂 Java 路徑";
            // 
            // btnJava
            // 
            this.btnJava.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnJava.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnJava.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnJava.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJava.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJava.Location = new System.Drawing.Point(194, 44);
            this.btnJava.Name = "btnJava";
            this.btnJava.Size = new System.Drawing.Size(25, 23);
            this.btnJava.TabIndex = 6;
            this.btnJava.Text = "…";
            this.btnJava.UseVisualStyleBackColor = true;
            this.btnJava.Click += new System.EventHandler(this.btnJava_Click);
            // 
            // textJava
            // 
            this.textJava.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textJava.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.textJava.Location = new System.Drawing.Point(10, 44);
            this.textJava.MinimumSize = new System.Drawing.Size(0, 23);
            this.textJava.Name = "textJava";
            this.textJava.ReadOnly = true;
            this.textJava.Size = new System.Drawing.Size(180, 23);
            this.textJava.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "留空表示由啟動器自動判斷";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textJVM);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox4.Location = new System.Drawing.Point(12, 245);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(225, 55);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "JVM 啟動參數";
            // 
            // textJVM
            // 
            this.textJVM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textJVM.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.textJVM.Location = new System.Drawing.Point(10, 22);
            this.textJVM.MinimumSize = new System.Drawing.Size(0, 23);
            this.textJVM.Name = "textJVM";
            this.textJVM.Size = new System.Drawing.Size(209, 23);
            this.textJVM.TabIndex = 0;
            // 
            // minecraftActionInstance
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(251, 349);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnIntro);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(267, 388);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(267, 388);
            this.Name = "minecraftActionInstance";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新增實例";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.minecraftAddInstance_FormClosing);
            this.Load += new System.EventHandler(this.minecraftAddInstance_Load_1);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkOpenSpecific;
        private System.Windows.Forms.TextBox textInstanceName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnIntro;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox textBoxNowVersion;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textJava;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnJava;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textJVM;
        private System.Windows.Forms.Button btnVersionSelector;
    }
}