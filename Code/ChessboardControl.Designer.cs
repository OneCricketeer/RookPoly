namespace ConsoleApplications.RookPolynomial
{
    partial class ChessboardControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ChessboardControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.DoubleBuffered = true;
            this.Name = "ChessboardControl";
            this.Size = new System.Drawing.Size(401, 401);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ChessboardControl_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ChessboardControl_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
