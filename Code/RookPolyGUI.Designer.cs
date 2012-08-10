using System.Windows.Forms;
namespace ConsoleApplications.RookPolynomial
{
    partial class RookPolyGUI
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
            Application.Exit();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.instructions = new System.Windows.Forms.Label();
            this.solveButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.chessBoardDisplay1 = new ConsoleApplications.RookPolynomial.ChessBoardDisplay();
            this.chessboardControl1 = new ConsoleApplications.RookPolynomial.ChessboardControl();
            this.SuspendLayout();
            // 
            // instructions
            // 
            this.instructions.AutoSize = true;
            this.instructions.Location = new System.Drawing.Point(70, 9);
            this.instructions.Name = "instructions";
            this.instructions.Padding = new System.Windows.Forms.Padding(80, 0, 80, 0);
            this.instructions.Size = new System.Drawing.Size(404, 13);
            this.instructions.TabIndex = 4;
            this.instructions.Text = "Click on the board to toggle valid places for a rook";
            this.instructions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // solveButton
            // 
            this.solveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solveButton.Location = new System.Drawing.Point(12, 438);
            this.solveButton.Name = "solveButton";
            this.solveButton.Size = new System.Drawing.Size(530, 52);
            this.solveButton.TabIndex = 8;
            this.solveButton.Text = "Solve";
            this.solveButton.UseVisualStyleBackColor = true;
            this.solveButton.Click += new System.EventHandler(this.solveButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 513);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(250, 0, 250, 0);
            this.label2.Size = new System.Drawing.Size(535, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "label1";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chessBoardDisplay1
            // 
            this.chessBoardDisplay1.BackColor = System.Drawing.SystemColors.Control;
            this.chessBoardDisplay1.Location = new System.Drawing.Point(12, 408);
            this.chessBoardDisplay1.Name = "chessBoardDisplay1";
            this.chessBoardDisplay1.Size = new System.Drawing.Size(24, 24);
            this.chessBoardDisplay1.TabIndex = 9;
            this.chessBoardDisplay1.Visible = false;
            // 
            // chessboardControl1
            // 
            this.chessboardControl1.BackColor = System.Drawing.SystemColors.Control;
            this.chessboardControl1.Location = new System.Drawing.Point(73, 25);
            this.chessboardControl1.Name = "chessboardControl1";
            this.chessboardControl1.Size = new System.Drawing.Size(401, 401);
            this.chessboardControl1.TabIndex = 6;
            this.chessboardControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chessboardControl1_MouseClick);
            this.chessboardControl1.MouseLeave += new System.EventHandler(this.chessboardControl1_MouseLeave);
            // 
            // RookPolyGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 503);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chessBoardDisplay1);
            this.Controls.Add(this.solveButton);
            this.Controls.Add(this.chessboardControl1);
            this.Controls.Add(this.instructions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RookPolyGUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rook Polynomial Solver";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label instructions;
        private ChessboardControl chessboardControl1;
        private System.Windows.Forms.Button solveButton;
        private ChessBoardDisplay chessBoardDisplay1;
        private Label label2;
    }
}