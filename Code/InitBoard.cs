using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ConsoleApplications.RookPolynomial
{
    public partial class InitBoard : Form
    {
        private int rows;
        private int cols;
        private bool validRows, validCols;

        public InitBoard()
        {
            InitializeComponent();
            rowStar.Visible = true;
            colStar.Visible = true;
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("{0} {1}", validRows, validCols);

            if (validCols && validRows)
            {
                RookPolyGUI solver = new RookPolyGUI(rows, cols);
                solver.Show();
                this.Visible = false;
            }
        }

        private void rowBox_TextChanged(object sender, EventArgs e)
        {
            string text = rowBox.Text;
            validRows = Int32.TryParse(text, out rows);
            rowStar.Visible = validRows && rows > 0 ? false : true;
            validRows = !rowStar.Visible;
        }

        private void colBox_TextChanged(object sender, EventArgs e)
        {
            string text = colBox.Text;
            validCols = Int32.TryParse(text, out cols);
            colStar.Visible = validCols && cols > 0 ? false : true;
            validCols = !colStar.Visible;
        }
    }
}
