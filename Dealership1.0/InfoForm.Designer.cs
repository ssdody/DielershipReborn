﻿namespace Dealership1._0
{
    partial class ExtrasInfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExtrasInfoForm));
            this.CarInfoTextbox = new System.Windows.Forms.TextBox();
            this.CopyToClipboardButton = new System.Windows.Forms.Button();
            this.TopMostButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CarInfoTextbox
            // 
            this.CarInfoTextbox.BackColor = System.Drawing.SystemColors.WindowText;
            this.CarInfoTextbox.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CarInfoTextbox.ForeColor = System.Drawing.SystemColors.Window;
            this.CarInfoTextbox.Location = new System.Drawing.Point(3, 21);
            this.CarInfoTextbox.Multiline = true;
            this.CarInfoTextbox.Name = "CarInfoTextbox";
            this.CarInfoTextbox.ReadOnly = true;
            this.CarInfoTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.CarInfoTextbox.Size = new System.Drawing.Size(364, 603);
            this.CarInfoTextbox.TabIndex = 1;
            this.CarInfoTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CarInfoTextbox_KeyDown);
            // 
            // CopyToClipboardButton
            // 
            this.CopyToClipboardButton.BackColor = System.Drawing.Color.Transparent;
            this.CopyToClipboardButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CopyToClipboardButton.Image = global::Dealership1._0.Properties.Resources.icons8_copy_24;
            this.CopyToClipboardButton.Location = new System.Drawing.Point(332, -2);
            this.CopyToClipboardButton.Name = "CopyToClipboardButton";
            this.CopyToClipboardButton.Size = new System.Drawing.Size(24, 23);
            this.CopyToClipboardButton.TabIndex = 3;
            this.CopyToClipboardButton.UseVisualStyleBackColor = false;
            this.CopyToClipboardButton.Click += new System.EventHandler(this.CopyToClipboardButton_Click);
            // 
            // TopMostButton
            // 
            this.TopMostButton.BackColor = System.Drawing.Color.Transparent;
            this.TopMostButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.TopMostButton.Image = global::Dealership1._0.Properties.Resources.icons8_pin_24;
            this.TopMostButton.Location = new System.Drawing.Point(302, -2);
            this.TopMostButton.Name = "TopMostButton";
            this.TopMostButton.Size = new System.Drawing.Size(24, 23);
            this.TopMostButton.TabIndex = 2;
            this.TopMostButton.UseVisualStyleBackColor = false;
            this.TopMostButton.Click += new System.EventHandler(this.TopMostButton_Click);
            // 
            // ExtrasInfoForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(359, 627);
            this.Controls.Add(this.CopyToClipboardButton);
            this.Controls.Add(this.TopMostButton);
            this.Controls.Add(this.CarInfoTextbox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.ForeColor = System.Drawing.SystemColors.Window;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1000, 1000);
            this.Name = "ExtrasInfoForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Информация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox CarInfoTextbox;
        private System.Windows.Forms.Button TopMostButton;
        private System.Windows.Forms.Button CopyToClipboardButton;
    }
}