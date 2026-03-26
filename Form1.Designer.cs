namespace SimpleCalculator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtCalculate = new TextBox();
            txtResult = new TextBox();
            lblTop = new Label();
            btnCalculate = new Button();
            btnOne = new Button();
            btnTwo = new Button();
            btnThree = new Button();
            btnFour = new Button();
            btnFive = new Button();
            btnSix = new Button();
            btnSeven = new Button();
            btnEight = new Button();
            btnNine = new Button();
            btnZero = new Button();
            btnAdd = new Button();
            btnSubtract = new Button();
            btnMultiply = new Button();
            btnDivide = new Button();
            btnC = new Button();
            btnCE = new Button();
            btnDel = new Button();
            SuspendLayout();
            // 
            // txtCalculate
            // 
            txtCalculate.BorderStyle = BorderStyle.FixedSingle;
            txtCalculate.Font = new Font("Pretendard JP Variable SemiBold", 24F, FontStyle.Bold);
            txtCalculate.Location = new Point(54, 120);
            txtCalculate.Name = "txtCalculate";
            txtCalculate.ReadOnly = true;
            txtCalculate.Size = new Size(580, 65);
            txtCalculate.TabIndex = 0;
            // 
            // txtResult
            // 
            txtResult.BorderStyle = BorderStyle.FixedSingle;
            txtResult.Font = new Font("Pretendard JP Variable SemiBold", 24F, FontStyle.Bold, GraphicsUnit.Point, 128);
            txtResult.Location = new Point(54, 221);
            txtResult.Name = "txtResult";
            txtResult.Size = new Size(580, 65);
            txtResult.TabIndex = 1;
            txtResult.Text = "0";
            // 
            // lblTop
            // 
            lblTop.AutoSize = true;
            lblTop.Font = new Font("Pretendard JP Variable SemiBold", 18F, FontStyle.Bold, GraphicsUnit.Point, 128);
            lblTop.Location = new Point(54, 41);
            lblTop.Name = "lblTop";
            lblTop.Size = new Size(300, 43);
            lblTop.TabIndex = 2;
            lblTop.Text = "Simple Calculator";
            // 
            // btnCalculate
            // 
            btnCalculate.Font = new Font("Pretendard JP Variable", 24F, FontStyle.Bold, GraphicsUnit.Point, 128);
            btnCalculate.Location = new Point(523, 854);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(117, 99);
            btnCalculate.TabIndex = 3;
            btnCalculate.Text = "=";
            btnCalculate.UseVisualStyleBackColor = true;
            btnCalculate.Click += btnCalculate_Click;
            // 
            // btnOne
            // 
            btnOne.Font = new Font("Pretendard JP Variable", 24F, FontStyle.Bold, GraphicsUnit.Point, 128);
            btnOne.Location = new Point(60, 717);
            btnOne.Name = "btnOne";
            btnOne.Size = new Size(117, 99);
            btnOne.TabIndex = 4;
            btnOne.Text = "1";
            btnOne.UseVisualStyleBackColor = true;
            btnOne.Click += btnNum_Click;
            // 
            // btnTwo
            // 
            btnTwo.Font = new Font("Pretendard JP Variable", 24F, FontStyle.Bold, GraphicsUnit.Point, 128);
            btnTwo.Location = new Point(211, 717);
            btnTwo.Name = "btnTwo";
            btnTwo.Size = new Size(117, 99);
            btnTwo.TabIndex = 5;
            btnTwo.Text = "2";
            btnTwo.UseVisualStyleBackColor = true;
            btnTwo.Click += btnNum_Click;
            // 
            // btnThree
            // 
            btnThree.Font = new Font("Pretendard JP Variable", 24F, FontStyle.Bold, GraphicsUnit.Point, 128);
            btnThree.Location = new Point(367, 717);
            btnThree.Name = "btnThree";
            btnThree.Size = new Size(117, 99);
            btnThree.TabIndex = 6;
            btnThree.Text = "3";
            btnThree.UseVisualStyleBackColor = true;
            btnThree.Click += btnNum_Click;
            // 
            // btnFour
            // 
            btnFour.Font = new Font("Pretendard JP Variable", 24F, FontStyle.Bold, GraphicsUnit.Point, 128);
            btnFour.Location = new Point(60, 582);
            btnFour.Name = "btnFour";
            btnFour.Size = new Size(117, 99);
            btnFour.TabIndex = 7;
            btnFour.Text = "4";
            btnFour.UseVisualStyleBackColor = true;
            btnFour.Click += btnNum_Click;
            // 
            // btnFive
            // 
            btnFive.Font = new Font("Pretendard JP Variable", 24F, FontStyle.Bold, GraphicsUnit.Point, 128);
            btnFive.Location = new Point(211, 582);
            btnFive.Name = "btnFive";
            btnFive.Size = new Size(117, 99);
            btnFive.TabIndex = 8;
            btnFive.Text = "5";
            btnFive.UseVisualStyleBackColor = true;
            btnFive.Click += btnNum_Click;
            // 
            // btnSix
            // 
            btnSix.Font = new Font("Pretendard JP Variable", 24F, FontStyle.Bold, GraphicsUnit.Point, 128);
            btnSix.Location = new Point(367, 582);
            btnSix.Name = "btnSix";
            btnSix.Size = new Size(117, 99);
            btnSix.TabIndex = 9;
            btnSix.Text = "6";
            btnSix.UseVisualStyleBackColor = true;
            btnSix.Click += btnNum_Click;
            // 
            // btnSeven
            // 
            btnSeven.Font = new Font("Pretendard JP Variable", 24F, FontStyle.Bold, GraphicsUnit.Point, 128);
            btnSeven.Location = new Point(60, 446);
            btnSeven.Name = "btnSeven";
            btnSeven.Size = new Size(117, 99);
            btnSeven.TabIndex = 10;
            btnSeven.Text = "7";
            btnSeven.UseVisualStyleBackColor = true;
            btnSeven.Click += btnNum_Click;
            // 
            // btnEight
            // 
            btnEight.Font = new Font("Pretendard JP Variable", 24F, FontStyle.Bold, GraphicsUnit.Point, 128);
            btnEight.Location = new Point(211, 446);
            btnEight.Name = "btnEight";
            btnEight.Size = new Size(117, 99);
            btnEight.TabIndex = 11;
            btnEight.Text = "8";
            btnEight.UseVisualStyleBackColor = true;
            btnEight.Click += btnNum_Click;
            // 
            // btnNine
            // 
            btnNine.Font = new Font("Pretendard JP Variable", 24F, FontStyle.Bold, GraphicsUnit.Point, 128);
            btnNine.Location = new Point(367, 446);
            btnNine.Name = "btnNine";
            btnNine.Size = new Size(117, 99);
            btnNine.TabIndex = 12;
            btnNine.Text = "9";
            btnNine.UseVisualStyleBackColor = true;
            btnNine.Click += btnNum_Click;
            // 
            // btnZero
            // 
            btnZero.Font = new Font("Pretendard JP Variable", 24F, FontStyle.Bold, GraphicsUnit.Point, 128);
            btnZero.Location = new Point(211, 854);
            btnZero.Name = "btnZero";
            btnZero.Size = new Size(117, 99);
            btnZero.TabIndex = 13;
            btnZero.Text = "0";
            btnZero.UseVisualStyleBackColor = true;
            btnZero.Click += btnNum_Click;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Pretendard JP Variable", 24F, FontStyle.Bold, GraphicsUnit.Point, 128);
            btnAdd.Location = new Point(523, 717);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(117, 99);
            btnAdd.TabIndex = 14;
            btnAdd.Text = "+";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnSubtract
            // 
            btnSubtract.Font = new Font("Pretendard JP Variable", 24F, FontStyle.Bold, GraphicsUnit.Point, 128);
            btnSubtract.Location = new Point(523, 582);
            btnSubtract.Name = "btnSubtract";
            btnSubtract.Size = new Size(117, 99);
            btnSubtract.TabIndex = 15;
            btnSubtract.Text = "-";
            btnSubtract.UseVisualStyleBackColor = true;
            btnSubtract.Click += btnSubtract_Click;
            // 
            // btnMultiply
            // 
            btnMultiply.Font = new Font("Pretendard JP Variable", 24F, FontStyle.Bold, GraphicsUnit.Point, 128);
            btnMultiply.Location = new Point(523, 446);
            btnMultiply.Name = "btnMultiply";
            btnMultiply.Size = new Size(117, 99);
            btnMultiply.TabIndex = 16;
            btnMultiply.Text = "×";
            btnMultiply.UseVisualStyleBackColor = true;
            btnMultiply.Click += btnMuliply_Click;
            // 
            // btnDivide
            // 
            btnDivide.Font = new Font("Pretendard JP Variable", 24F, FontStyle.Bold, GraphicsUnit.Point, 128);
            btnDivide.Location = new Point(523, 314);
            btnDivide.Name = "btnDivide";
            btnDivide.Size = new Size(117, 99);
            btnDivide.TabIndex = 17;
            btnDivide.Text = "÷";
            btnDivide.UseVisualStyleBackColor = true;
            btnDivide.Click += btnDivide_Click;
            // 
            // btnC
            // 
            btnC.Font = new Font("Pretendard JP Variable", 24F, FontStyle.Bold, GraphicsUnit.Point, 128);
            btnC.Location = new Point(60, 314);
            btnC.Name = "btnC";
            btnC.Size = new Size(117, 99);
            btnC.TabIndex = 18;
            btnC.Text = "C";
            btnC.UseVisualStyleBackColor = true;
            btnC.Click += btnC_Click;
            // 
            // btnCE
            // 
            btnCE.Font = new Font("Pretendard JP Variable", 24F, FontStyle.Bold, GraphicsUnit.Point, 128);
            btnCE.Location = new Point(211, 314);
            btnCE.Name = "btnCE";
            btnCE.Size = new Size(117, 99);
            btnCE.TabIndex = 19;
            btnCE.Text = "CE";
            btnCE.UseVisualStyleBackColor = true;
            btnCE.Click += btnCE_Click;
            // 
            // btnDel
            // 
            btnDel.Font = new Font("Pretendard JP Variable", 24F, FontStyle.Bold, GraphicsUnit.Point, 128);
            btnDel.Location = new Point(367, 314);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(117, 99);
            btnDel.TabIndex = 20;
            btnDel.Text = "Del";
            btnDel.UseVisualStyleBackColor = true;
            btnDel.Click += btnDel_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(693, 1029);
            Controls.Add(btnDel);
            Controls.Add(btnCE);
            Controls.Add(btnC);
            Controls.Add(btnDivide);
            Controls.Add(btnMultiply);
            Controls.Add(btnSubtract);
            Controls.Add(btnAdd);
            Controls.Add(btnZero);
            Controls.Add(btnNine);
            Controls.Add(btnEight);
            Controls.Add(btnSeven);
            Controls.Add(btnSix);
            Controls.Add(btnFive);
            Controls.Add(btnFour);
            Controls.Add(btnThree);
            Controls.Add(btnTwo);
            Controls.Add(btnOne);
            Controls.Add(btnCalculate);
            Controls.Add(lblTop);
            Controls.Add(txtResult);
            Controls.Add(txtCalculate);
            Name = "Form1";
            Text = "Simple Calculator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCalculate;
        private TextBox txtResult;
        private Label lblTop;
        private Button btnCalculate;
        private Button btnOne;
        private Button btnTwo;
        private Button btnThree;
        private Button btnFour;
        private Button btnFive;
        private Button btnSix;
        private Button btnSeven;
        private Button btnEight;
        private Button btnNine;
        private Button btnZero;
        private Button btnAdd;
        private Button btnSubtract;
        private Button btnMultiply;
        private Button btnDivide;
        private Button btnC;
        private Button btnCE;
        private Button btnDel;
    }
}
