namespace Graphics_lab_2
{
    partial class Form2
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
            this.HelpPicture = new System.Windows.Forms.PictureBox();
            this.HelpGist = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.L = new System.Windows.Forms.CheckBox();
            this.A = new System.Windows.Forms.CheckBox();
            this.B = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.HelpPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGist)).BeginInit();
            this.SuspendLayout();
            // 
            // HelpPicture
            // 
            this.HelpPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HelpPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HelpPicture.Location = new System.Drawing.Point(13, 13);
            this.HelpPicture.Name = "HelpPicture";
            this.HelpPicture.Size = new System.Drawing.Size(300, 400);
            this.HelpPicture.TabIndex = 0;
            this.HelpPicture.TabStop = false;
            this.HelpPicture.Click += new System.EventHandler(this.HelpPicture_Click);
            // 
            // HelpGist
            // 
            this.HelpGist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HelpGist.Location = new System.Drawing.Point(319, 213);
            this.HelpGist.Name = "HelpGist";
            this.HelpGist.Size = new System.Drawing.Size(255, 200);
            this.HelpGist.TabIndex = 1;
            this.HelpGist.TabStop = false;
            this.HelpGist.Click += new System.EventHandler(this.HelpGist_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(581, 213);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(40, 21);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "R";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(581, 241);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(41, 21);
            this.checkBox2.TabIndex = 7;
            this.checkBox2.Text = "G";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(581, 269);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(39, 21);
            this.checkBox3.TabIndex = 8;
            this.checkBox3.Text = "B";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // L
            // 
            this.L.AutoSize = true;
            this.L.Checked = true;
            this.L.CheckState = System.Windows.Forms.CheckState.Checked;
            this.L.Location = new System.Drawing.Point(320, 13);
            this.L.Name = "L";
            this.L.Size = new System.Drawing.Size(38, 21);
            this.L.TabIndex = 9;
            this.L.Text = "L";
            this.L.UseVisualStyleBackColor = true;
            this.L.CheckedChanged += new System.EventHandler(this.L_CheckedChanged);
            // 
            // A
            // 
            this.A.AutoSize = true;
            this.A.Checked = true;
            this.A.CheckState = System.Windows.Forms.CheckState.Checked;
            this.A.Location = new System.Drawing.Point(320, 40);
            this.A.Name = "A";
            this.A.Size = new System.Drawing.Size(39, 21);
            this.A.TabIndex = 10;
            this.A.Text = "A";
            this.A.UseVisualStyleBackColor = true;
            this.A.CheckedChanged += new System.EventHandler(this.A_CheckedChanged);
            // 
            // B
            // 
            this.B.AutoSize = true;
            this.B.Checked = true;
            this.B.CheckState = System.Windows.Forms.CheckState.Checked;
            this.B.Location = new System.Drawing.Point(320, 67);
            this.B.Name = "B";
            this.B.Size = new System.Drawing.Size(39, 21);
            this.B.TabIndex = 11;
            this.B.Text = "B";
            this.B.UseVisualStyleBackColor = true;
            this.B.CheckedChanged += new System.EventHandler(this.B_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(320, 161);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 46);
            this.button1.TabIndex = 12;
            this.button1.Text = "Save!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.B);
            this.Controls.Add(this.A);
            this.Controls.Add(this.L);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.HelpGist);
            this.Controls.Add(this.HelpPicture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.Text = "RayTracer";
            ((System.ComponentModel.ISupportInitialize)(this.HelpPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox HelpPicture;
        private System.Windows.Forms.PictureBox HelpGist;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox L;
        private System.Windows.Forms.CheckBox A;
        private System.Windows.Forms.CheckBox B;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}