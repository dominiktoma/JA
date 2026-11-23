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
            asmButton = new RadioButton();
            cppButton = new RadioButton();
            selectFileButton = new Button();
            startButton = new Button();
            label1 = new Label();
            label2 = new Label();
            originalImageBox = new PictureBox();
            processedImageBox = new PictureBox();
            pathLabel = new Label();
            timeLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)originalImageBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)processedImageBox).BeginInit();
            SuspendLayout();
            // 
            // asmButton
            // 
            asmButton.AutoSize = true;
            asmButton.Location = new Point(12, 12);
            asmButton.Name = "asmButton";
            asmButton.Size = new Size(61, 24);
            asmButton.TabIndex = 1;
            asmButton.Text = "ASM";
            asmButton.UseVisualStyleBackColor = true;
            asmButton.CheckedChanged += asmButton_CheckedChanged;
            // 
            // cppButton
            // 
            cppButton.AutoSize = true;
            cppButton.Checked = true;
            cppButton.Location = new Point(12, 33);
            cppButton.Name = "cppButton";
            cppButton.Size = new Size(59, 24);
            cppButton.TabIndex = 2;
            cppButton.TabStop = true;
            cppButton.Text = "C++";
            cppButton.UseVisualStyleBackColor = true;
            cppButton.CheckedChanged += cppButton_CheckedChanged;
            // 
            // selectFileButton
            // 
            selectFileButton.Location = new Point(12, 88);
            selectFileButton.Name = "selectFileButton";
            selectFileButton.Size = new Size(147, 52);
            selectFileButton.TabIndex = 3;
            selectFileButton.Text = "Select image";
            selectFileButton.UseVisualStyleBackColor = true;
            selectFileButton.Click += selectFileButton_Click;
            // 
            // startButton
            // 
            startButton.Location = new Point(12, 146);
            startButton.Name = "startButton";
            startButton.Size = new Size(147, 52);
            startButton.TabIndex = 4;
            startButton.Text = "Start";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 201);
            label1.Name = "label1";
            label1.Size = new Size(122, 20);
            label1.TabIndex = 5;
            label1.Text = "Wynik programu:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 221);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 6;
            // 
            // originalImageBox
            // 
            originalImageBox.BorderStyle = BorderStyle.FixedSingle;
            originalImageBox.Location = new Point(165, 12);
            originalImageBox.Name = "originalImageBox";
            originalImageBox.Size = new Size(301, 290);
            originalImageBox.TabIndex = 7;
            originalImageBox.TabStop = false;
            // 
            // processedImageBox
            // 
            processedImageBox.BorderStyle = BorderStyle.FixedSingle;
            processedImageBox.Location = new Point(487, 12);
            processedImageBox.Name = "processedImageBox";
            processedImageBox.Size = new Size(301, 290);
            processedImageBox.TabIndex = 8;
            processedImageBox.TabStop = false;
            // 
            // pathLabel
            // 
            pathLabel.AutoSize = true;
            pathLabel.Location = new Point(165, 305);
            pathLabel.Name = "pathLabel";
            pathLabel.Size = new Size(131, 20);
            pathLabel.TabIndex = 9;
            pathLabel.Text = "Wybrany plik: brak";
            // 
            // timeLabel
            // 
            timeLabel.AutoSize = true;
            timeLabel.Location = new Point(12, 221);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new Size(0, 20);
            timeLabel.TabIndex = 10;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 451);
            Controls.Add(timeLabel);
            Controls.Add(pathLabel);
            Controls.Add(processedImageBox);
            Controls.Add(originalImageBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(startButton);
            Controls.Add(selectFileButton);
            Controls.Add(cppButton);
            Controls.Add(asmButton);
            Name = "Form1";
            Text = "Gaussian noise app";
            ((System.ComponentModel.ISupportInitialize)originalImageBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)processedImageBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private RadioButton asmButton;
        private RadioButton cppButton;
        private Button selectFileButton;
        private Button startButton;
        private Label label1;
        private Label label2;
        private PictureBox originalImageBox;
        private PictureBox processedImageBox;
        private Label pathLabel;
        private Label timeLabel;
    }
}
