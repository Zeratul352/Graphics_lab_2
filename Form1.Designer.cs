namespace Graphics_lab_2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Filter = new System.Windows.Forms.PictureBox();
            this.Source = new System.Windows.Forms.PictureBox();
            this.Result = new System.Windows.Forms.PictureBox();
            this.OpenPicture = new System.Windows.Forms.OpenFileDialog();
            this.ConvertButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.FilterGist = new System.Windows.Forms.PictureBox();
            this.SourceGist = new System.Windows.Forms.PictureBox();
            this.ResultGist = new System.Windows.Forms.PictureBox();
            this.FilterGistRed = new System.Windows.Forms.CheckBox();
            this.ResultGistRed = new System.Windows.Forms.CheckBox();
            this.SourceGistRed = new System.Windows.Forms.CheckBox();
            this.FilterGistGreen = new System.Windows.Forms.CheckBox();
            this.ResultGistGreen = new System.Windows.Forms.CheckBox();
            this.SourceGistGreen = new System.Windows.Forms.CheckBox();
            this.FilterGistBlue = new System.Windows.Forms.CheckBox();
            this.ResultGistBlue = new System.Windows.Forms.CheckBox();
            this.SourceGistBlue = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.SquareFulter = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Filter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Source)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilterGist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SourceGist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultGist)).BeginInit();
            this.SuspendLayout();
            // 
            // Filter
            // 
            this.Filter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Filter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Filter.Location = new System.Drawing.Point(12, 12);
            this.Filter.Name = "Filter";
            this.Filter.Size = new System.Drawing.Size(300, 400);
            this.Filter.TabIndex = 0;
            this.Filter.TabStop = false;
            this.Filter.Click += new System.EventHandler(this.pictureBox1_Click);
            this.Filter.DoubleClick += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Source
            // 
            this.Source.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Source.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Source.Location = new System.Drawing.Point(318, 12);
            this.Source.Name = "Source";
            this.Source.Size = new System.Drawing.Size(300, 400);
            this.Source.TabIndex = 1;
            this.Source.TabStop = false;
            this.Source.DoubleClick += new System.EventHandler(this.Source_Click);
            this.Source.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Source_MouseClick);
            // 
            // Result
            // 
            this.Result.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Result.Cursor = System.Windows.Forms.Cursors.No;
            this.Result.Location = new System.Drawing.Point(624, 12);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(300, 400);
            this.Result.TabIndex = 2;
            this.Result.TabStop = false;
            // 
            // OpenPicture
            // 
            this.OpenPicture.FileName = "openFileDialog1";
            // 
            // ConvertButton
            // 
            this.ConvertButton.Location = new System.Drawing.Point(931, 13);
            this.ConvertButton.Name = "ConvertButton";
            this.ConvertButton.Size = new System.Drawing.Size(170, 38);
            this.ConvertButton.TabIndex = 3;
            this.ConvertButton.Text = "Use!";
            this.ConvertButton.UseVisualStyleBackColor = true;
            this.ConvertButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(931, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 34);
            this.button1.TabIndex = 4;
            this.button1.Text = "Save!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // FilterGist
            // 
            this.FilterGist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FilterGist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FilterGist.Location = new System.Drawing.Point(13, 419);
            this.FilterGist.Name = "FilterGist";
            this.FilterGist.Size = new System.Drawing.Size(255, 200);
            this.FilterGist.TabIndex = 5;
            this.FilterGist.TabStop = false;
            this.FilterGist.Click += new System.EventHandler(this.FilterGist_Click);
            // 
            // SourceGist
            // 
            this.SourceGist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SourceGist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SourceGist.Location = new System.Drawing.Point(318, 419);
            this.SourceGist.Name = "SourceGist";
            this.SourceGist.Size = new System.Drawing.Size(255, 200);
            this.SourceGist.TabIndex = 6;
            this.SourceGist.TabStop = false;
            this.SourceGist.Click += new System.EventHandler(this.SourceGist_Click);
            // 
            // ResultGist
            // 
            this.ResultGist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ResultGist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ResultGist.Location = new System.Drawing.Point(624, 419);
            this.ResultGist.Name = "ResultGist";
            this.ResultGist.Size = new System.Drawing.Size(255, 200);
            this.ResultGist.TabIndex = 7;
            this.ResultGist.TabStop = false;
            this.ResultGist.Click += new System.EventHandler(this.ResultGist_Click);
            // 
            // FilterGistRed
            // 
            this.FilterGistRed.AutoSize = true;
            this.FilterGistRed.Checked = true;
            this.FilterGistRed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FilterGistRed.Location = new System.Drawing.Point(272, 418);
            this.FilterGistRed.Name = "FilterGistRed";
            this.FilterGistRed.Size = new System.Drawing.Size(40, 21);
            this.FilterGistRed.TabIndex = 8;
            this.FilterGistRed.Text = "R";
            this.FilterGistRed.UseVisualStyleBackColor = true;
            // 
            // ResultGistRed
            // 
            this.ResultGistRed.AutoSize = true;
            this.ResultGistRed.Checked = true;
            this.ResultGistRed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ResultGistRed.Location = new System.Drawing.Point(884, 419);
            this.ResultGistRed.Name = "ResultGistRed";
            this.ResultGistRed.Size = new System.Drawing.Size(40, 21);
            this.ResultGistRed.TabIndex = 9;
            this.ResultGistRed.Text = "R";
            this.ResultGistRed.UseVisualStyleBackColor = true;
            // 
            // SourceGistRed
            // 
            this.SourceGistRed.AutoSize = true;
            this.SourceGistRed.Checked = true;
            this.SourceGistRed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SourceGistRed.Location = new System.Drawing.Point(579, 419);
            this.SourceGistRed.Name = "SourceGistRed";
            this.SourceGistRed.Size = new System.Drawing.Size(40, 21);
            this.SourceGistRed.TabIndex = 10;
            this.SourceGistRed.Text = "R";
            this.SourceGistRed.UseVisualStyleBackColor = true;
            // 
            // FilterGistGreen
            // 
            this.FilterGistGreen.AutoSize = true;
            this.FilterGistGreen.Location = new System.Drawing.Point(272, 445);
            this.FilterGistGreen.Name = "FilterGistGreen";
            this.FilterGistGreen.Size = new System.Drawing.Size(41, 21);
            this.FilterGistGreen.TabIndex = 11;
            this.FilterGistGreen.Text = "G";
            this.FilterGistGreen.UseVisualStyleBackColor = true;
            this.FilterGistGreen.CheckedChanged += new System.EventHandler(this.FilterGistGreen_CheckedChanged);
            // 
            // ResultGistGreen
            // 
            this.ResultGistGreen.AutoSize = true;
            this.ResultGistGreen.Location = new System.Drawing.Point(883, 447);
            this.ResultGistGreen.Name = "ResultGistGreen";
            this.ResultGistGreen.Size = new System.Drawing.Size(41, 21);
            this.ResultGistGreen.TabIndex = 12;
            this.ResultGistGreen.Text = "G";
            this.ResultGistGreen.UseVisualStyleBackColor = true;
            // 
            // SourceGistGreen
            // 
            this.SourceGistGreen.AutoSize = true;
            this.SourceGistGreen.Location = new System.Drawing.Point(579, 446);
            this.SourceGistGreen.Name = "SourceGistGreen";
            this.SourceGistGreen.Size = new System.Drawing.Size(41, 21);
            this.SourceGistGreen.TabIndex = 13;
            this.SourceGistGreen.Text = "G";
            this.SourceGistGreen.UseVisualStyleBackColor = true;
            // 
            // FilterGistBlue
            // 
            this.FilterGistBlue.AutoSize = true;
            this.FilterGistBlue.Location = new System.Drawing.Point(272, 472);
            this.FilterGistBlue.Name = "FilterGistBlue";
            this.FilterGistBlue.Size = new System.Drawing.Size(39, 21);
            this.FilterGistBlue.TabIndex = 14;
            this.FilterGistBlue.Text = "B";
            this.FilterGistBlue.UseVisualStyleBackColor = true;
            // 
            // ResultGistBlue
            // 
            this.ResultGistBlue.AutoSize = true;
            this.ResultGistBlue.Location = new System.Drawing.Point(883, 475);
            this.ResultGistBlue.Name = "ResultGistBlue";
            this.ResultGistBlue.Size = new System.Drawing.Size(39, 21);
            this.ResultGistBlue.TabIndex = 15;
            this.ResultGistBlue.Text = "B";
            this.ResultGistBlue.UseVisualStyleBackColor = true;
            // 
            // SourceGistBlue
            // 
            this.SourceGistBlue.AutoSize = true;
            this.SourceGistBlue.Location = new System.Drawing.Point(579, 475);
            this.SourceGistBlue.Name = "SourceGistBlue";
            this.SourceGistBlue.Size = new System.Drawing.Size(39, 21);
            this.SourceGistBlue.TabIndex = 16;
            this.SourceGistBlue.Text = "B";
            this.SourceGistBlue.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(931, 378);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(170, 34);
            this.button2.TabIndex = 17;
            this.button2.Text = "OpenExtraWindow";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(931, 99);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(170, 36);
            this.button3.TabIndex = 18;
            this.button3.Text = "IgnoreLCorrection";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(931, 183);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(170, 36);
            this.button4.TabIndex = 19;
            this.button4.Text = "IgnoreBCorrection";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(931, 141);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(170, 36);
            this.button5.TabIndex = 20;
            this.button5.Text = "IgnoreACorrection";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // SquareFulter
            // 
            this.SquareFulter.Location = new System.Drawing.Point(931, 226);
            this.SquareFulter.Name = "SquareFulter";
            this.SquareFulter.Size = new System.Drawing.Size(170, 36);
            this.SquareFulter.TabIndex = 21;
            this.SquareFulter.Text = "UseSquareFilter";
            this.SquareFulter.UseVisualStyleBackColor = true;
            this.SquareFulter.Click += new System.EventHandler(this.SquareFulter_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(930, 268);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(170, 36);
            this.button6.TabIndex = 22;
            this.button6.Text = "UseCircleFilter";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(930, 310);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(170, 36);
            this.button7.TabIndex = 23;
            this.button7.Text = "RemoveFilter";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(26, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 29);
            this.label1.TabIndex = 24;
            this.label1.Text = "Source";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(332, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 29);
            this.label2.TabIndex = 25;
            this.label2.Text = "Target";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 630);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.SquareFulter);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.SourceGistBlue);
            this.Controls.Add(this.ResultGistBlue);
            this.Controls.Add(this.FilterGistBlue);
            this.Controls.Add(this.SourceGistGreen);
            this.Controls.Add(this.ResultGistGreen);
            this.Controls.Add(this.FilterGistGreen);
            this.Controls.Add(this.SourceGistRed);
            this.Controls.Add(this.ResultGistRed);
            this.Controls.Add(this.FilterGistRed);
            this.Controls.Add(this.ResultGist);
            this.Controls.Add(this.SourceGist);
            this.Controls.Add(this.FilterGist);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ConvertButton);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.Source);
            this.Controls.Add(this.Filter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Redactor";
            ((System.ComponentModel.ISupportInitialize)(this.Filter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Source)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilterGist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SourceGist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultGist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Filter;
        private System.Windows.Forms.PictureBox Source;
        private System.Windows.Forms.PictureBox Result;
        private System.Windows.Forms.OpenFileDialog OpenPicture;
        private System.Windows.Forms.Button ConvertButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PictureBox FilterGist;
        private System.Windows.Forms.PictureBox SourceGist;
        private System.Windows.Forms.PictureBox ResultGist;
        private System.Windows.Forms.CheckBox FilterGistRed;
        private System.Windows.Forms.CheckBox ResultGistRed;
        private System.Windows.Forms.CheckBox SourceGistRed;
        private System.Windows.Forms.CheckBox FilterGistGreen;
        private System.Windows.Forms.CheckBox ResultGistGreen;
        private System.Windows.Forms.CheckBox SourceGistGreen;
        private System.Windows.Forms.CheckBox FilterGistBlue;
        private System.Windows.Forms.CheckBox ResultGistBlue;
        private System.Windows.Forms.CheckBox SourceGistBlue;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button SquareFulter;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

