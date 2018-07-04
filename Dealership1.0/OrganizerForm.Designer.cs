namespace Dealership1._0
{
    partial class OrganizerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrganizerForm));
            this.StartButton = new System.Windows.Forms.Button();
            this.TaskLabel = new System.Windows.Forms.Label();
            this.TaskTextbox = new System.Windows.Forms.TextBox();
            this.StopButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ElapsedTimeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ElapsedTimeNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartButton.ForeColor = System.Drawing.SystemColors.Window;
            this.StartButton.Image = ((System.Drawing.Image)(resources.GetObject("StartButton.Image")));
            this.StartButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.StartButton.Location = new System.Drawing.Point(12, 379);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 32);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start";
            this.StartButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartTimerButton_Click);
            // 
            // TaskLabel
            // 
            this.TaskLabel.AutoSize = true;
            this.TaskLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaskLabel.ForeColor = System.Drawing.SystemColors.Window;
            this.TaskLabel.Location = new System.Drawing.Point(234, 17);
            this.TaskLabel.Name = "TaskLabel";
            this.TaskLabel.Size = new System.Drawing.Size(49, 21);
            this.TaskLabel.TabIndex = 1;
            this.TaskLabel.Text = "Tasks";
            // 
            // TaskTextbox
            // 
            this.TaskTextbox.BackColor = System.Drawing.SystemColors.WindowText;
            this.TaskTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TaskTextbox.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaskTextbox.ForeColor = System.Drawing.SystemColors.Window;
            this.TaskTextbox.Location = new System.Drawing.Point(12, 52);
            this.TaskTextbox.Multiline = true;
            this.TaskTextbox.Name = "TaskTextbox";
            this.TaskTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TaskTextbox.Size = new System.Drawing.Size(461, 303);
            this.TaskTextbox.TabIndex = 2;
            // 
            // StopButton
            // 
            this.StopButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.StopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StopButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StopButton.ForeColor = System.Drawing.SystemColors.Window;
            this.StopButton.Image = ((System.Drawing.Image)(resources.GetObject("StopButton.Image")));
            this.StopButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.StopButton.Location = new System.Drawing.Point(398, 379);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 32);
            this.StopButton.TabIndex = 3;
            this.StopButton.Text = "Stop";
            this.StopButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitButton.ForeColor = System.Drawing.SystemColors.Window;
            this.ExitButton.Location = new System.Drawing.Point(464, 1);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(20, 25);
            this.ExitButton.TabIndex = 4;
            this.ExitButton.Text = "X";
            this.ExitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(183, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "        ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(246, 391);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "мин.";
            // 
            // ElapsedTimeNumericUpDown
            // 
            this.ElapsedTimeNumericUpDown.BackColor = System.Drawing.SystemColors.WindowText;
            this.ElapsedTimeNumericUpDown.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElapsedTimeNumericUpDown.ForeColor = System.Drawing.SystemColors.Window;
            this.ElapsedTimeNumericUpDown.Increment = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.ElapsedTimeNumericUpDown.Location = new System.Drawing.Point(186, 379);
            this.ElapsedTimeNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ElapsedTimeNumericUpDown.Name = "ElapsedTimeNumericUpDown";
            this.ElapsedTimeNumericUpDown.Size = new System.Drawing.Size(55, 30);
            this.ElapsedTimeNumericUpDown.TabIndex = 8;
            this.ElapsedTimeNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.ElapsedTimeNumericUpDown, "Интервал между известията (в минути)");
            this.ElapsedTimeNumericUpDown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // OrganizerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(485, 423);
            this.Controls.Add(this.ElapsedTimeNumericUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.TaskTextbox);
            this.Controls.Add(this.TaskLabel);
            this.Controls.Add(this.StartButton);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "OrganizerForm";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OrganizerForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OrganizerForm_FormClosing);
            this.Load += new System.EventHandler(this.OrganizerForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OrganizerForm_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.ElapsedTimeNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label TaskLabel;
        private System.Windows.Forms.TextBox TaskTextbox;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown ElapsedTimeNumericUpDown;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}