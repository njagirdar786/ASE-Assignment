namespace ASE_Assignment
{
    partial class Form1
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
            this.singleTextBox = new System.Windows.Forms.TextBox();
            this.multiTextBox = new System.Windows.Forms.TextBox();
            this.submitBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // singleTextBox
            // 
            this.singleTextBox.Location = new System.Drawing.Point(12, 347);
            this.singleTextBox.Name = "singleTextBox";
            this.singleTextBox.Size = new System.Drawing.Size(295, 20);
            this.singleTextBox.TabIndex = 0;
            // 
            // multiTextBox
            // 
            this.multiTextBox.Location = new System.Drawing.Point(12, 52);
            this.multiTextBox.Multiline = true;
            this.multiTextBox.Name = "multiTextBox";
            this.multiTextBox.Size = new System.Drawing.Size(295, 272);
            this.multiTextBox.TabIndex = 1;
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(12, 382);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(295, 23);
            this.submitBtn.TabIndex = 2;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox1.Location = new System.Drawing.Point(357, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(315, 393);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // openBtn
            // 
            this.openBtn.Location = new System.Drawing.Point(12, 12);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(139, 23);
            this.openBtn.TabIndex = 4;
            this.openBtn.Text = "Open";
            this.openBtn.UseVisualStyleBackColor = true;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(167, 12);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(140, 23);
            this.saveBtn.TabIndex = 5;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 436);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.openBtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.multiTextBox);
            this.Controls.Add(this.singleTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox singleTextBox;
        private System.Windows.Forms.TextBox multiTextBox;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button openBtn;
        private System.Windows.Forms.Button saveBtn;
    }
}

