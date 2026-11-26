/*
 * =================================================================================================
 * AI GENERATION NOTICE
 * =================================================================================================
 * This file was edited and refactored by AI.
 * Model: Gemini
 * Prompt used:
 * "Popraw responsywność okna, aby pola poszczególne elementy były skalowalne przy zmianie rozmiaru 
 * okna. Dodaj komentarze, w komentarzach opisz poszczególne elementy i wskaż zmiany, które 
 * wprowadziłeś (po angielsku) dodatkowo u góry kodu zamieść komentarz, że te plik został edytowany 
 * przez ai (podaj konkretny model i prompta, który został użyty do wygenerowania tego pliku)."
 * =================================================================================================
 */

namespace AppUI
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
            // CHANGE: Added TableLayoutPanel to ensure both PictureBoxes scale equally (50%/50%) without overlapping.
            imageTableLayoutPanel = new TableLayoutPanel();

            ((System.ComponentModel.ISupportInitialize)originalImageBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)processedImageBox).BeginInit();
            imageTableLayoutPanel.SuspendLayout();
            SuspendLayout();

            // 
            // asmButton - Radio button to select the Assembly (ASM) processing implementation.
            // Remains anchored to Top-Left (default) as part of the fixed-width control sidebar.
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
            // cppButton - Radio button to select the C++ processing implementation (default selected).
            // Remains anchored to Top-Left (default) as part of the fixed-width control sidebar.
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
            // selectFileButton - Button that opens a file dialog to load an input image.
            // Remains anchored to Top-Left so sidebar controls stay aligned on resize.
            // 
            selectFileButton.Location = new Point(12, 88);
            selectFileButton.Name = "selectFileButton";
            selectFileButton.Size = new Size(147, 52);
            selectFileButton.TabIndex = 3;
            selectFileButton.Text = "Select image";
            selectFileButton.UseVisualStyleBackColor = true;
            selectFileButton.Click += selectFileButton_Click;

            // 
            // startButton - Button that triggers the Gaussian noise processing algorithm.
            // Remains anchored to Top-Left below the file selection button.
            // 
            startButton.Location = new Point(12, 146);
            startButton.Name = "startButton";
            startButton.Size = new Size(147, 52);
            startButton.TabIndex = 4;
            startButton.Text = "Start";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;

            // 
            // label1 - Static header label displaying "Wynik programu:" (Program result).
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 201);
            label1.Name = "label1";
            label1.Size = new Size(122, 20);
            label1.TabIndex = 5;
            label1.Text = "Wynik programu:";

            // 
            // label2 - Auxiliary label for program output messages.
            // CHANGE: Shifted Y position slightly (from 221 to 245) to prevent overlapping with timeLabel.
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 245);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 6;

            // 
            // timeLabel - Dynamic label displaying the execution time of the selected algorithm.
            // Kept at (12, 221) right under label1.
            // 
            timeLabel.AutoSize = true;
            timeLabel.Location = new Point(12, 221);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new Size(0, 20);
            timeLabel.TabIndex = 10;

            // 
            // imageTableLayoutPanel - Responsive 2-column grid container for side-by-side image previews.
            // CHANGE: Created this container and anchored it to all four sides (Top, Bottom, Left, Right)
            // so both PictureBoxes grow and shrink proportionally when the form is resized.
            // 
            imageTableLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            imageTableLayoutPanel.ColumnCount = 2;
            imageTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            imageTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            imageTableLayoutPanel.Controls.Add(originalImageBox, 0, 0);
            imageTableLayoutPanel.Controls.Add(processedImageBox, 1, 0);
            imageTableLayoutPanel.Location = new Point(165, 12);
            imageTableLayoutPanel.Name = "imageTableLayoutPanel";
            imageTableLayoutPanel.RowCount = 1;
            imageTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            imageTableLayoutPanel.Size = new Size(623, 395);
            imageTableLayoutPanel.TabIndex = 11;

            // 
            // originalImageBox - PictureBox displaying the source (unprocessed) image.
            // CHANGE: Replaced fixed Location/Size with DockStyle.Fill inside imageTableLayoutPanel,
            // added right margin for spacing, and set SizeMode to Zoom so images scale proportionally.
            // 
            originalImageBox.BorderStyle = BorderStyle.FixedSingle;
            originalImageBox.Dock = DockStyle.Fill;
            originalImageBox.Margin = new Padding(0, 0, 10, 0);
            originalImageBox.Name = "originalImageBox";
            originalImageBox.SizeMode = PictureBoxSizeMode.Zoom;
            originalImageBox.TabIndex = 7;
            originalImageBox.TabStop = false;

            // 
            // processedImageBox - PictureBox displaying the output image after applying Gaussian noise.
            // CHANGE: Replaced fixed Location/Size with DockStyle.Fill inside imageTableLayoutPanel,
            // added left margin for spacing, and set SizeMode to Zoom so images scale proportionally.
            // 
            processedImageBox.BorderStyle = BorderStyle.FixedSingle;
            processedImageBox.Dock = DockStyle.Fill;
            processedImageBox.Margin = new Padding(10, 0, 0, 0);
            processedImageBox.Name = "processedImageBox";
            processedImageBox.SizeMode = PictureBoxSizeMode.Zoom;
            processedImageBox.TabIndex = 8;
            processedImageBox.TabStop = false;

            // 
            // pathLabel - Label displaying the file path of the currently selected image.
            // CHANGE: Anchored to Bottom | Left | Right, disabled AutoSize, enabled AutoEllipsis,
            // and moved to Y=415 so it stays pinned below the scaling image container without clipping.
            // 
            pathLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pathLabel.AutoEllipsis = true;
            pathLabel.Location = new Point(165, 415);
            pathLabel.Name = "pathLabel";
            pathLabel.Size = new Size(623, 23);
            pathLabel.TabIndex = 9;
            pathLabel.Text = "Wybrany plik: brak";

            // 
            // Form1 - Main application window.
            // CHANGE: Added MinimumSize (650x380) to prevent UI controls from overlapping or clipping
            // when the user shrinks the window.
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 451);
            MinimumSize = new Size(650, 380);
            Controls.Add(timeLabel);
            Controls.Add(pathLabel);
            Controls.Add(imageTableLayoutPanel);
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
            imageTableLayoutPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // UI Control Declarations
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
        private TableLayoutPanel imageTableLayoutPanel; // Added responsive container for image boxes
    }
}