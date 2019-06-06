namespace Volser_Extractor_V2
{
    partial class frmMain
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
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnExtract = new System.Windows.Forms.Button();
            this.txtDisplay = new System.Windows.Forms.TextBox();
            this.openFileDialogBox = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(13, 13);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(437, 76);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "BROWSE";
            this.btnBrowse.UseVisualStyleBackColor = true;
            // 
            // btnExtract
            // 
            this.btnExtract.Location = new System.Drawing.Point(13, 294);
            this.btnExtract.Name = "btnExtract";
            this.btnExtract.Size = new System.Drawing.Size(437, 76);
            this.btnExtract.TabIndex = 1;
            this.btnExtract.Text = "EXTRACT";
            this.btnExtract.UseVisualStyleBackColor = true;
            // 
            // txtDisplay
            // 
            this.txtDisplay.Location = new System.Drawing.Point(13, 96);
            this.txtDisplay.Multiline = true;
            this.txtDisplay.Name = "txtDisplay";
            this.txtDisplay.Size = new System.Drawing.Size(437, 192);
            this.txtDisplay.TabIndex = 2;
            // 
            // openFileDialogBox
            // 
            this.openFileDialogBox.FileName = "openFileDialog1";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 382);
            this.Controls.Add(this.txtDisplay);
            this.Controls.Add(this.btnExtract);
            this.Controls.Add(this.btnBrowse);
            this.Name = "frmMain";
            this.Text = "Volser Extractor & File Creator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnExtract;
        private System.Windows.Forms.TextBox txtDisplay;
        private System.Windows.Forms.OpenFileDialog openFileDialogBox;
    }
}

