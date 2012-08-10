using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ConsoleApplications.RookPolynomial
{
    public partial class RookPolyGUI : Form
    {
        private int rows;
        private int cols;
        private Chessboard board;
        Padding p;

        public RookPolyGUI()
        {
            InitializeComponent();
        }

        public RookPolyGUI(int rows, int cols)
            : this()
        {
            this.rows = rows;
            this.cols = cols;
            this.board = new Chessboard(rows, cols);
            //            this.chessboardControl1.setup(rows, cols);
            //            this.chessBoardDisplay1.setup(rows, cols);
            this.chessboardControl1.setup(board);
            this.chessBoardDisplay1.setup(board);
            this.chessBoardDisplay1.MouseClick += new MouseEventHandler(chessboardControl1_MouseClick);
            p = label2.Padding;
        }

        private void solveButton_Click(object sender, EventArgs e)
        {
            this.label2.Text = chessBoardDisplay1.getPolynomial();
//            this.label2.Visible = true;
//            centerLabel();

            solveButton.Text = chessBoardDisplay1.getPolynomial();
        }

        private void centerLabel()
        {
            if (this.label2.Text.Length > 10)
                this.label2.Padding = new Padding(p.Left - 2 * this.label2.Text.Length, p.Top, p.Right, p.Bottom);
            //            Console.WriteLine();
        }

        private void chessboardControl1_MouseClick(object sender, MouseEventArgs e)
        {
            chessBoardDisplay1.Refresh();
        }

        private void chessBoardDisplay1_MouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine("Listen");
            // Begin the solve the rook polynomial
            label2.Text = "Wait";

            //            ParameterizedThreadStart pt = delegate { RookPoly.solve(board); };
            //            Thread run = new Thread(pt);
            //            run.Start();
            //            while (!run.IsAlive)
            //                Thread.Sleep(1);
            //            run.Join();

            this.label2.Text = chessBoardDisplay1.getPolynomial();
        }

        private void chessboardControl1_MouseLeave(object sender, EventArgs e)
        {
//            solveButton.Text = "Solve";
        }
    }
}
