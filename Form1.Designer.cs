namespace GifCreator {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.picMain = new System.Windows.Forms.PictureBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlImages = new System.Windows.Forms.Panel();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.tbFrameDelay = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cB_Forward = new System.Windows.Forms.CheckBox();
            this.btnFastSave = new System.Windows.Forms.Button();
            this.cBremoveStatic = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // picMain
            // 
            this.picMain.Location = new System.Drawing.Point(0, 0);
            this.picMain.Name = "picMain";
            this.picMain.Size = new System.Drawing.Size(1062, 569);
            this.picMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMain.TabIndex = 1;
            this.picMain.TabStop = false;
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.Controls.Add(this.picMain);
            this.pnlMain.Location = new System.Drawing.Point(0, 1);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1065, 572);
            this.pnlMain.TabIndex = 3;
            // 
            // pnlImages
            // 
            this.pnlImages.Location = new System.Drawing.Point(0, 593);
            this.pnlImages.Name = "pnlImages";
            this.pnlImages.Size = new System.Drawing.Size(843, 103);
            this.pnlImages.TabIndex = 4;
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(974, 610);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 26);
            this.btnPreview.TabIndex = 3;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(985, 639);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(59, 26);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "gif";
            // 
            // tbFrameDelay
            // 
            this.tbFrameDelay.Location = new System.Drawing.Point(883, 612);
            this.tbFrameDelay.Name = "tbFrameDelay";
            this.tbFrameDelay.Size = new System.Drawing.Size(80, 22);
            this.tbFrameDelay.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(880, 592);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Frame Delay";
            // 
            // cB_Forward
            // 
            this.cB_Forward.AutoSize = true;
            this.cB_Forward.Location = new System.Drawing.Point(974, 591);
            this.cB_Forward.Name = "cB_Forward";
            this.cB_Forward.Size = new System.Drawing.Size(81, 21);
            this.cB_Forward.TabIndex = 8;
            this.cB_Forward.Text = "Forward";
            this.cB_Forward.UseVisualStyleBackColor = true;
            // 
            // btnFastSave
            // 
            this.btnFastSave.Location = new System.Drawing.Point(877, 640);
            this.btnFastSave.Name = "btnFastSave";
            this.btnFastSave.Size = new System.Drawing.Size(80, 26);
            this.btnFastSave.TabIndex = 9;
            this.btnFastSave.Text = "Fast Save";
            this.btnFastSave.UseVisualStyleBackColor = true;
            this.btnFastSave.Click += new System.EventHandler(this.btnFastSave_Click);
            // 
            // cBremoveStatic
            // 
            this.cBremoveStatic.AutoSize = true;
            this.cBremoveStatic.Location = new System.Drawing.Point(877, 672);
            this.cBremoveStatic.Name = "cBremoveStatic";
            this.cBremoveStatic.Size = new System.Drawing.Size(121, 21);
            this.cBremoveStatic.TabIndex = 10;
            this.cBremoveStatic.Text = "Remove Static";
            this.cBremoveStatic.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 702);
            this.Controls.Add(this.btnFastSave);
            this.Controls.Add(this.cBremoveStatic);
            this.Controls.Add(this.cB_Forward);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbFrameDelay);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.pnlImages);
            this.Controls.Add(this.pnlMain);
            this.Name = "Form1";
            this.Text = "Form1";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picMain;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlImages;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.TextBox tbFrameDelay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cB_Forward;
        private System.Windows.Forms.Button btnFastSave;
        private System.Windows.Forms.CheckBox cBremoveStatic;
    }
}

