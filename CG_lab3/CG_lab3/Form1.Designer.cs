namespace CG_lab3
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
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label_kernel_size = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label_kernel_size_2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.button7 = new System.Windows.Forms.Button();
            this.rbr = new System.Windows.Forms.CheckBox();
            this.rbg = new System.Windows.Forms.CheckBox();
            this.rbb = new System.Windows.Forms.CheckBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(652, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 41);
            this.button1.TabIndex = 0;
            this.button1.Text = "Load";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(49, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(557, 378);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(652, 86);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 27);
            this.button2.TabIndex = 3;
            this.button2.Text = "blur";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(758, 86);
            this.trackBar1.Maximum = 200;
            this.trackBar1.Minimum = 3;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(129, 56);
            this.trackBar1.TabIndex = 4;
            this.trackBar1.Value = 3;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(788, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "kernel size";
            // 
            // label_kernel_size
            // 
            this.label_kernel_size.AutoSize = true;
            this.label_kernel_size.Location = new System.Drawing.Point(903, 91);
            this.label_kernel_size.Name = "label_kernel_size";
            this.label_kernel_size.Size = new System.Drawing.Size(0, 17);
            this.label_kernel_size.TabIndex = 6;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(652, 153);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 29);
            this.button3.TabIndex = 7;
            this.button3.Text = "gaussian";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label_kernel_size_2
            // 
            this.label_kernel_size_2.AutoSize = true;
            this.label_kernel_size_2.Location = new System.Drawing.Point(903, 153);
            this.label_kernel_size_2.Name = "label_kernel_size_2";
            this.label_kernel_size_2.Size = new System.Drawing.Size(0, 17);
            this.label_kernel_size_2.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(788, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "kernel size";
            // 
            // trackBar2
            // 
            this.trackBar2.LargeChange = 2;
            this.trackBar2.Location = new System.Drawing.Point(758, 148);
            this.trackBar2.Maximum = 199;
            this.trackBar2.Minimum = 3;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(129, 56);
            this.trackBar2.SmallChange = 2;
            this.trackBar2.TabIndex = 8;
            this.trackBar2.TickFrequency = 2;
            this.trackBar2.Value = 3;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(652, 189);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 11;
            this.textBox1.Text = "0";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(652, 217);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 28);
            this.button4.TabIndex = 12;
            this.button4.Text = "hist";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(768, 217);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(96, 28);
            this.button5.TabIndex = 13;
            this.button5.Text = "equalize";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(652, 251);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(100, 32);
            this.button6.TabIndex = 14;
            this.button6.Text = "rgb hist";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(12, 400);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(180, 180);
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(198, 400);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(180, 180);
            this.pictureBox3.TabIndex = 16;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(384, 400);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(180, 180);
            this.pictureBox4.TabIndex = 17;
            this.pictureBox4.TabStop = false;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(768, 251);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(96, 32);
            this.button7.TabIndex = 18;
            this.button7.Text = "equalize";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // rbr
            // 
            this.rbr.AutoSize = true;
            this.rbr.Location = new System.Drawing.Point(706, 289);
            this.rbr.Name = "rbr";
            this.rbr.Size = new System.Drawing.Size(35, 21);
            this.rbr.TabIndex = 19;
            this.rbr.Text = "r";
            this.rbr.UseVisualStyleBackColor = true;
            // 
            // rbg
            // 
            this.rbg.AutoSize = true;
            this.rbg.Location = new System.Drawing.Point(747, 289);
            this.rbg.Name = "rbg";
            this.rbg.Size = new System.Drawing.Size(38, 21);
            this.rbg.TabIndex = 20;
            this.rbg.Text = "g";
            this.rbg.UseVisualStyleBackColor = true;
            // 
            // rbb
            // 
            this.rbb.AutoSize = true;
            this.rbb.Location = new System.Drawing.Point(791, 289);
            this.rbb.Name = "rbb";
            this.rbb.Size = new System.Drawing.Size(38, 21);
            this.rbb.TabIndex = 21;
            this.rbb.Text = "b";
            this.rbb.UseVisualStyleBackColor = true;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Location = new System.Drawing.Point(570, 400);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(180, 180);
            this.pictureBox5.TabIndex = 22;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Location = new System.Drawing.Point(758, 400);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(180, 180);
            this.pictureBox6.TabIndex = 23;
            this.pictureBox6.TabStop = false;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(652, 316);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(100, 42);
            this.button8.TabIndex = 24;
            this.button8.Text = "brightness hist";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(768, 316);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(96, 42);
            this.button9.TabIndex = 25;
            this.button9.Text = "equalize";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(652, 365);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(100, 23);
            this.button10.TabIndex = 26;
            this.button10.Text = "linear";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 612);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.rbb);
            this.Controls.Add(this.rbg);
            this.Controls.Add(this.rbr);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label_kernel_size_2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label_kernel_size);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_kernel_size;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label_kernel_size_2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.CheckBox rbr;
        private System.Windows.Forms.CheckBox rbg;
        private System.Windows.Forms.CheckBox rbb;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
    }
}

