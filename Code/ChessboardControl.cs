using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ConsoleApplications.RookPolynomial
{
    public partial class ChessboardControl : UserControl
    {
        protected int rows = 0;
        protected int cols = 0;
        protected float xOffset = 0;
        protected float yOffset = 0;
        protected float TILE_SIZE = 20.0F;
        protected string polynomial;
        protected Chessboard board { get; set; }

        public ChessboardControl()
        {
            InitializeComponent();

        }
        public ChessboardControl(int rows, int cols)
            : this()
        {
            this.board = new Chessboard(rows, cols);
            this.rows = rows;
            this.cols = cols;
            this.TILE_SIZE = rows > cols ? (float)(this.Height / rows) : (float)(this.Width / cols * 1.0F);
            //            this.Size = new Size((int)TILE_SIZE * rows, (int)TILE_SIZE * cols);
        }

        public void setup(int rows, int cols)
        {
            this.board = new Chessboard(rows, cols);
            //            board.init();
            this.rows = rows;
            this.cols = cols;
            this.TILE_SIZE = rows > cols ? this.Height / rows : this.Width / cols;
        }

        public void setup(Chessboard board)
        {
            this.board = board;
            this.TILE_SIZE = board.Height > board.Width ? this.Height / board.Height : this.Width / board.Width;
        }

        private void ChessboardControl_MouseClick(object sender, MouseEventArgs e)
        {
            double row = Math.Floor((e.Y - yOffset)/ TILE_SIZE) ;
            double col = Math.Floor((e.X - xOffset)/ TILE_SIZE) ;
            int num;
            try
            {
                num = this.board[(int)row][(int)col];

                if (e.Button.Equals(MouseButtons.Left))
                {
                    if (-1 <= num && num <= 1)
                    {
                        this.board[(int)row][(int)col] *= -1; // If 0, = 0, If 1, = -1
                        this.board[(int)row][(int)col] += 1; // If 0, = 1, If -1, = 0
                    }
                    else
                    {
                        this.board[(int)row][(int)col] = 0;
                    }

                }
                else if (e.Button.Equals(MouseButtons.Right))
                {
                    //                if (num == 0)
                    //                    this.board[(int)row][(int)col] += 2;
                    if (num == 1) this.board[(int)row][(int)col] += 1;
                    else if (num == 2) this.board[(int)row][(int)col] -= 1;
                }
            }
            catch { }
            Refresh();
        }

        private void center(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int r = 0;
            int c = 0;
            if (board != null)
            {
                r = board.Height;
                c = board.Width;

                if (c > r)
                    this.yOffset = (((this.Height / TILE_SIZE) - board.Height) * TILE_SIZE) / 2;
                else if (c < r)
                    this.xOffset = (((this.Width / TILE_SIZE) - board.Width) * TILE_SIZE) / 2;

                g.TranslateTransform(xOffset, yOffset);
            }

        }

        private void ChessboardControl_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = Pens.Black;
            Color fill;
            center(e);
            if (board == null)
                setup(1, 1);
            
            for (float y = 0; y < board.Height; ++y)
            {
                fill = y % 2 == 0 ? Color.Khaki : Color.DarkKhaki;
                for (float x = 0; x < board.Width; ++x)
                {
                    RectangleF drawRect = new RectangleF(x * TILE_SIZE, y * TILE_SIZE, TILE_SIZE, TILE_SIZE);
                    Rectangle cell = new Rectangle((int)drawRect.X, (int)drawRect.Y, (int)drawRect.Width, (int)drawRect.Height);
             
                    fill = fill == Color.Khaki ? Color.Chocolate : Color.Khaki;
                    if (this.board[(int)y][(int)x] >= 1)
                    {
                        g.FillRectangle(new SolidBrush(fill), cell);

                    }
                    if (this.board[(int)y][(int)x] == 2)
                    {
                        g.FillEllipse(new SolidBrush(Color.White), cell);
                    }
                    if (this.board[(int)y][(int)x] != 0)
                        e.Graphics.DrawRectangle(p, cell);
                }
            }
        }

        public String getPolynomial()
        {
            if (polynomial == null)
            {
                ParameterizedThreadStart pt = delegate { RookPoly.solve(board); };
                Thread run = new Thread(pt);
                run.Start();
                while (!run.IsAlive)
                    Thread.Sleep(1);
                run.Join();

                //                RookPoly.solve(board);
                return board.polynomial.ToString();
            }
            else return polynomial;

        }
    }

    public partial class ChessBoardDisplay : ChessboardControl
    {


        public ChessBoardDisplay()
            : base()
        {
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ChessboardDisplay_MouseClick);
        }

        public ChessBoardDisplay(int rows, int cols)
            : base(rows, cols)
        {
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ChessboardDisplay_MouseClick);
        }

        protected override void OnClick(EventArgs e)
        {
            this.polynomial = getPolynomial();
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            Console.WriteLine("Hey");
            if (this.polynomial == null)
                this.polynomial = getPolynomial();
        }

        private void ChessboardDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine("Hey");
            if (this.polynomial == null)
                this.polynomial = getPolynomial();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }


    }
}
