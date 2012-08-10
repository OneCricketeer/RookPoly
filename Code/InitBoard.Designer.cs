namespace ConsoleApplications.RookPolynomial
{
    partial class InitBoard
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
            this.label1 = new System.Windows.Forms.Label();
            this.rowBox = new System.Windows.Forms.TextBox();
            this.rowsLabel = new System.Windows.Forms.Label();
            this.colsLabel = new System.Windows.Forms.Label();
            this.colBox = new System.Windows.Forms.TextBox();
            this.generateButton = new System.Windows.Forms.Button();
            this.rowStar = new System.Windows.Forms.Label();
            this.colStar = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please enter the max\n number of rows and columns for the chessboard";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.UseCompatibleTextRendering = true;
            // 
            // rowBox
            // 
            this.rowBox.Location = new System.Drawing.Point(62, 95);
            this.rowBox.Name = "rowBox";
            this.rowBox.Size = new System.Drawing.Size(73, 20);
            this.rowBox.TabIndex = 1;
            this.rowBox.TextChanged += new System.EventHandler(this.rowBox_TextChanged);
            // 
            // rowsLabel
            // 
            this.rowsLabel.AutoSize = true;
            this.rowsLabel.Location = new System.Drawing.Point(20, 98);
            this.rowsLabel.Name = "rowsLabel";
            this.rowsLabel.Size = new System.Drawing.Size(40, 13);
            this.rowsLabel.TabIndex = 2;
            this.rowsLabel.Text = "Rows: ";
            // 
            // colsLabel
            // 
            this.colsLabel.AutoSize = true;
            this.colsLabel.Location = new System.Drawing.Point(145, 98);
            this.colsLabel.Name = "colsLabel";
            this.colsLabel.Size = new System.Drawing.Size(53, 13);
            this.colsLabel.TabIndex = 3;
            this.colsLabel.Text = "Columns: ";
            // 
            // colBox
            // 
            this.colBox.Location = new System.Drawing.Point(199, 95);
            this.colBox.Name = "colBox";
            this.colBox.Size = new System.Drawing.Size(73, 20);
            this.colBox.TabIndex = 4;
            this.colBox.TextChanged += new System.EventHandler(this.colBox_TextChanged);
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(110, 135);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(75, 23);
            this.generateButton.TabIndex = 5;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // rowStar
            // 
            this.rowStar.AutoSize = true;
            this.rowStar.ForeColor = System.Drawing.Color.Red;
            this.rowStar.Location = new System.Drawing.Point(51, 92);
            this.rowStar.Name = "rowStar";
            this.rowStar.Size = new System.Drawing.Size(11, 13);
            this.rowStar.TabIndex = 6;
            this.rowStar.Text = "*";
            this.rowStar.Visible = false;
            // 
            // colStar
            // 
            this.colStar.AutoSize = true;
            this.colStar.ForeColor = System.Drawing.Color.Red;
            this.colStar.Location = new System.Drawing.Point(188, 92);
            this.colStar.Name = "colStar";
            this.colStar.Size = new System.Drawing.Size(11, 13);
            this.colStar.TabIndex = 7;
            this.colStar.Text = "*";
            this.colStar.Visible = false;
            // 
            // InitBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 183);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.colsLabel);
            this.Controls.Add(this.rowsLabel);
            this.Controls.Add(this.rowBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rowStar);
            this.Controls.Add(this.colStar);
            this.Controls.Add(this.colBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "InitBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rook Polynomial Initializer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox rowBox;
        private System.Windows.Forms.Label rowsLabel;
        private System.Windows.Forms.Label colsLabel;
        private System.Windows.Forms.TextBox colBox;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Label rowStar;
        private System.Windows.Forms.Label colStar;
    }
}