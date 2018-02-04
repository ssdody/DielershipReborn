namespace Dealership1._0
{
    partial class InfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoForm));
            this.CarInfoTextbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // CarInfoTextbox
            // 
            this.CarInfoTextbox.BackColor = System.Drawing.SystemColors.WindowText;
            this.CarInfoTextbox.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CarInfoTextbox.ForeColor = System.Drawing.SystemColors.Window;
            this.CarInfoTextbox.Location = new System.Drawing.Point(18, 12);
            this.CarInfoTextbox.Multiline = true;
            this.CarInfoTextbox.Name = "CarInfoTextbox";
            this.CarInfoTextbox.ReadOnly = true;
            this.CarInfoTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.CarInfoTextbox.Size = new System.Drawing.Size(672, 603);
            this.CarInfoTextbox.TabIndex = 1;
            this.CarInfoTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CarInfoTextbox_KeyDown);
            // 
            // InfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(702, 627);
            this.Controls.Add(this.CarInfoTextbox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.ForeColor = System.Drawing.SystemColors.Window;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InfoForm";
            this.Text = "Информация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox CarInfoTextbox;
    }
}