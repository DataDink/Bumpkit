namespace Demonstrations
{
    partial class Demonstrations
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
            this.btnOpen = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._rotateOverflow = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this._rotateFit = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this._stretch = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this._scaleToOverflow = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this._scaleToFit = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._textGen = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this._gifGeneration = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this._edgeDetection = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this._pixelManipulation = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._gifGeneration)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(12, 12);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(792, 23);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Run Demonstrations";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._rotateOverflow);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this._rotateFit);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this._stretch);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this._scaleToOverflow);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this._scaleToFit);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(792, 148);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Transform Demonstrations";
            // 
            // _rotateOverflow
            // 
            this._rotateOverflow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._rotateOverflow.Location = new System.Drawing.Point(633, 19);
            this._rotateOverflow.Name = "_rotateOverflow";
            this._rotateOverflow.Size = new System.Drawing.Size(150, 100);
            this._rotateOverflow.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(630, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(153, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Rotate (overflow)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _rotateFit
            // 
            this._rotateFit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._rotateFit.Location = new System.Drawing.Point(477, 19);
            this._rotateFit.Name = "_rotateFit";
            this._rotateFit.Size = new System.Drawing.Size(150, 100);
            this._rotateFit.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(474, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Rotate (fit)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _stretch
            // 
            this._stretch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._stretch.Location = new System.Drawing.Point(321, 19);
            this._stretch.Name = "_stretch";
            this._stretch.Size = new System.Drawing.Size(150, 100);
            this._stretch.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(318, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Stretch";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _scaleToOverflow
            // 
            this._scaleToOverflow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._scaleToOverflow.Location = new System.Drawing.Point(165, 19);
            this._scaleToOverflow.Name = "_scaleToOverflow";
            this._scaleToOverflow.Size = new System.Drawing.Size(150, 100);
            this._scaleToOverflow.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(162, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Scale To Fit (overflow)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _scaleToFit
            // 
            this._scaleToFit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._scaleToFit.Location = new System.Drawing.Point(9, 19);
            this._scaleToFit.Name = "_scaleToFit";
            this._scaleToFit.Size = new System.Drawing.Size(150, 100);
            this._scaleToFit.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Scale To Fit (fit)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._textGen);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this._gifGeneration);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this._edgeDetection);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this._pixelManipulation);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(12, 195);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(792, 148);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Unsafe Context Demonstrations";
            // 
            // _textGen
            // 
            this._textGen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._textGen.Location = new System.Drawing.Point(477, 19);
            this._textGen.Name = "_textGen";
            this._textGen.Size = new System.Drawing.Size(150, 100);
            this._textGen.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(474, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(153, 23);
            this.label6.TabIndex = 6;
            this.label6.Text = "Text Effects (Borders)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _gifGeneration
            // 
            this._gifGeneration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._gifGeneration.Location = new System.Drawing.Point(321, 19);
            this._gifGeneration.Name = "_gifGeneration";
            this._gifGeneration.Size = new System.Drawing.Size(150, 100);
            this._gifGeneration.TabIndex = 5;
            this._gifGeneration.TabStop = false;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(318, 122);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(153, 23);
            this.label8.TabIndex = 4;
            this.label8.Text = "Gif Generation (Animations)";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _edgeDetection
            // 
            this._edgeDetection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._edgeDetection.Location = new System.Drawing.Point(165, 19);
            this._edgeDetection.Name = "_edgeDetection";
            this._edgeDetection.Size = new System.Drawing.Size(150, 100);
            this._edgeDetection.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(162, 122);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(153, 23);
            this.label9.TabIndex = 2;
            this.label9.Text = "Edge Detection";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _pixelManipulation
            // 
            this._pixelManipulation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._pixelManipulation.Location = new System.Drawing.Point(9, 19);
            this._pixelManipulation.Name = "_pixelManipulation";
            this._pixelManipulation.Size = new System.Drawing.Size(150, 100);
            this._pixelManipulation.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(6, 122);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(153, 23);
            this.label10.TabIndex = 0;
            this.label10.Text = "Fast Pixel Manipulation";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Demonstrations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 354);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOpen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Demonstrations";
            this.Text = "Demonstrations";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._gifGeneration)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel _scaleToFit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel _scaleToOverflow;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel _rotateOverflow;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel _rotateFit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel _stretch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox _gifGeneration;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel _edgeDetection;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel _pixelManipulation;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel _textGen;
    }
}

