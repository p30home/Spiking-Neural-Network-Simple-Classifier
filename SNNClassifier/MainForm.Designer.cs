namespace SNNClassifier
{
    partial class MainForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.PicClassifier1 = new System.Windows.Forms.PictureBox();
            this.PicClassifier2 = new System.Windows.Forms.PictureBox();
            this.lbl0 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.ButtonTrain = new System.Windows.Forms.Button();
            this.ButtonTest = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.PicInput = new System.Windows.Forms.PictureBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicClassifier1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicClassifier2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicInput)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(6, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(112, 19);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 80);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Location = new System.Drawing.Point(112, 105);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(100, 80);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox4.Location = new System.Drawing.Point(6, 105);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(100, 80);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 1;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // PicClassifier1
            // 
            this.PicClassifier1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PicClassifier1.Location = new System.Drawing.Point(10, 19);
            this.PicClassifier1.Name = "PicClassifier1";
            this.PicClassifier1.Size = new System.Drawing.Size(266, 237);
            this.PicClassifier1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicClassifier1.TabIndex = 1;
            this.PicClassifier1.TabStop = false;
            this.PicClassifier1.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // PicClassifier2
            // 
            this.PicClassifier2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PicClassifier2.Location = new System.Drawing.Point(282, 19);
            this.PicClassifier2.Name = "PicClassifier2";
            this.PicClassifier2.Size = new System.Drawing.Size(264, 237);
            this.PicClassifier2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicClassifier2.TabIndex = 1;
            this.PicClassifier2.TabStop = false;
            this.PicClassifier2.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // lbl0
            // 
            this.lbl0.AutoSize = true;
            this.lbl0.ForeColor = System.Drawing.Color.Red;
            this.lbl0.Location = new System.Drawing.Point(125, 259);
            this.lbl0.Name = "lbl0";
            this.lbl0.Size = new System.Drawing.Size(26, 13);
            this.lbl0.TabIndex = 2;
            this.lbl0.Text = "Win";
            this.lbl0.Visible = false;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.ForeColor = System.Drawing.Color.Red;
            this.lbl1.Location = new System.Drawing.Point(399, 259);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(26, 13);
            this.lbl1.TabIndex = 2;
            this.lbl1.Text = "Win";
            this.lbl1.Visible = false;
            // 
            // ButtonTrain
            // 
            this.ButtonTrain.Location = new System.Drawing.Point(12, 311);
            this.ButtonTrain.Name = "ButtonTrain";
            this.ButtonTrain.Size = new System.Drawing.Size(75, 23);
            this.ButtonTrain.TabIndex = 3;
            this.ButtonTrain.Text = "Train";
            this.ButtonTrain.UseVisualStyleBackColor = true;
            this.ButtonTrain.Click += new System.EventHandler(this.ButtonTrain_Click);
            // 
            // ButtonTest
            // 
            this.ButtonTest.Location = new System.Drawing.Point(93, 311);
            this.ButtonTest.Name = "ButtonTest";
            this.ButtonTest.Size = new System.Drawing.Size(75, 23);
            this.ButtonTest.TabIndex = 4;
            this.ButtonTest.Text = "Classify";
            this.ButtonTest.UseVisualStyleBackColor = true;
            this.ButtonTest.Click += new System.EventHandler(this.ButtonTest_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PicClassifier1);
            this.groupBox1.Controls.Add(this.PicClassifier2);
            this.groupBox1.Controls.Add(this.lbl0);
            this.groupBox1.Controls.Add(this.lbl1);
            this.groupBox1.Location = new System.Drawing.Point(3, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(561, 293);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Result";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.PicInput);
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.pictureBox3);
            this.groupBox2.Controls.Add(this.pictureBox4);
            this.groupBox2.Location = new System.Drawing.Point(570, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(493, 293);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Input";
            // 
            // PicInput
            // 
            this.PicInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PicInput.Location = new System.Drawing.Point(218, 19);
            this.PicInput.Name = "PicInput";
            this.PicInput.Size = new System.Drawing.Size(264, 237);
            this.PicInput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicInput.TabIndex = 1;
            this.PicInput.TabStop = false;
            this.PicInput.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(174, 311);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.TabIndex = 7;
            this.progressBar1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 377);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ButtonTest);
            this.Controls.Add(this.ButtonTrain);
            this.Name = "Form1";
            this.Text = "Little Zhenik";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicClassifier1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicClassifier2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicInput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox PicClassifier1;
        private System.Windows.Forms.PictureBox PicClassifier2;
        private System.Windows.Forms.Label lbl0;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Button ButtonTrain;
        private System.Windows.Forms.Button ButtonTest;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox PicInput;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

