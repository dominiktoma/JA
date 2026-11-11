namespace AppUI
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
            tableLayoutPanel1 = new TableLayoutPanel();
            num2 = new TextBox();
            btn = new Button();
            num1 = new TextBox();
            result = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            asmBtn = new RadioButton();
            cppBtn = new RadioButton();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34.1145821F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65.8854141F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 315F));
            tableLayoutPanel1.Controls.Add(num2, 1, 1);
            tableLayoutPanel1.Controls.Add(btn, 0, 2);
            tableLayoutPanel1.Controls.Add(num1, 0, 1);
            tableLayoutPanel1.Controls.Add(result, 1, 2);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 48.05195F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 51.94805F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 260F));
            tableLayoutPanel1.Size = new Size(700, 338);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // num2
            // 
            num2.Location = new Point(134, 40);
            num2.Name = "num2";
            num2.Size = new Size(107, 23);
            num2.TabIndex = 2;
            // 
            // btn
            // 
            btn.Location = new Point(3, 80);
            btn.Name = "btn";
            btn.Size = new Size(107, 29);
            btn.TabIndex = 1;
            btn.Text = "oblicz";
            btn.UseVisualStyleBackColor = true;
            btn.Click += button1_Click_1;
            // 
            // num1
            // 
            num1.Location = new Point(3, 40);
            num1.Name = "num1";
            num1.Size = new Size(107, 23);
            num1.TabIndex = 3;
            num1.TextChanged += num1_TextChanged;
            // 
            // result
            // 
            result.AutoSize = true;
            result.Location = new Point(134, 77);
            result.Name = "result";
            result.Size = new Size(0, 15);
            result.TabIndex = 4;
            result.Click += label1_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(asmBtn);
            flowLayoutPanel1.Controls.Add(cppBtn);
            flowLayoutPanel1.Location = new Point(3, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(114, 27);
            flowLayoutPanel1.TabIndex = 7;
            // 
            // asmBtn
            // 
            asmBtn.AutoSize = true;
            asmBtn.Checked = true;
            asmBtn.Location = new Point(3, 3);
            asmBtn.Name = "asmBtn";
            asmBtn.Size = new Size(50, 19);
            asmBtn.TabIndex = 6;
            asmBtn.TabStop = true;
            asmBtn.Text = "ASM";
            asmBtn.UseVisualStyleBackColor = true;
            // 
            // cppBtn
            // 
            cppBtn.AutoSize = true;
            cppBtn.Location = new Point(59, 3);
            cppBtn.Name = "cppBtn";
            cppBtn.Size = new Size(49, 19);
            cppBtn.TabIndex = 5;
            cppBtn.Text = "C++";
            cppBtn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button btn;
        private TextBox num1;
        private TextBox num2;
        private Label result;
        private RadioButton cppBtn;
        private RadioButton asmBtn;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}
