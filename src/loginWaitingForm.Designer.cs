namespace LiliumLauncher
{
    partial class loginWaitingForm
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
            this.labelWaiting = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.progressWaiting = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            //
            // labelWaiting
            //
            this.labelWaiting.Location = new System.Drawing.Point(12, 15);
            this.labelWaiting.Name = "labelWaiting";
            this.labelWaiting.Size = new System.Drawing.Size(360, 40);
            this.labelWaiting.TabIndex = 0;
            //
            // progressWaiting
            //
            this.progressWaiting.Location = new System.Drawing.Point(15, 62);
            this.progressWaiting.MarqueeAnimationSpeed = 30;
            this.progressWaiting.Name = "progressWaiting";
            this.progressWaiting.Size = new System.Drawing.Size(357, 12);
            this.progressWaiting.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressWaiting.TabIndex = 1;
            //
            // btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(283, 86);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(89, 27);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // loginWaitingForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 125);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.progressWaiting);
            this.Controls.Add(this.labelWaiting);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "loginWaitingForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label labelWaiting;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ProgressBar progressWaiting;
    }
}
