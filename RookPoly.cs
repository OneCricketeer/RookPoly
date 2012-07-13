using System;
using System.Collections;
using System.Text;

namespace ConsoleApplications.RookPolynomial
{
     public class RookPoly
    {
        Board board = new Board();
        
        // Calculates and returns the rook polynomial for the given board matrix
        public static Polynomial solve(Board board)
        {
            if (board.Count == 0)
                return new Polynomial();
            int[] intersect = board.greatestIntersection;
            Polynomial x = new Polynomial(0, 1);
            return board.deleteCell(intersect[0], intersect[1]) + x * board.deleteRowCol(intersect[0], intersect[1]);

        }

        // Caller to the static solve
        public Polynomial solve()
        {
            return RookPoly.solve(this.board);
        }

        // Prints the board based on a 0-1 matrix with 1 being valid tiles
        public static string printBoard(int[][] board)
        {
            #region Initializataion

            Board b = new Board(board);
            StringBuilder sb = new StringBuilder();
            int width = b.Width, height = b.Height;
            int row = 0, col = 0;
            int maxDimension = width > height ? width : height;
            int frontOffset = 0, backOffset = 0;
            string tile = " ";
            b.tilesToKeep = new ArrayList();

            #endregion Initialization

            #region Shrink

            // Test if the bottom and top row are all zeros and readjust
            while (b.allZeroRow(height - 1))
            {
                if (height == 0)
                    return "";
                else if (height > 0)
                    height--;
            }

            //            while (b.allZeroRow(row))
            //                            {
            //                    height--;
            //                                row++;
            //                            }

            //                row = height;

            #endregion Shrink

            //                frontOffset = getFrontOffset(0);
            //                backOffset = getBackOffset(0);
            //                buildRow(board[0]);
            //                borderPrinter(sb, width, frontOffset, backOffset);

            //                frontOffset = 0;

            #region Outerloop (Row)

            for (row = 0; row < height; row++)
            {

                if (b.tilesToKeep.Count > 0 && row > 1)
                    b.tilesToKeep.RemoveRange(0, b.tilesToKeep.Count);
                try
                {
                    b.buildRow(board[row]);
                    if (row != 0)
                        b.buildRow(board[row - 1]);
                }
                catch (IndexOutOfRangeException)
                {
                    //                        buildRow(board[row]);
                    b.buildRow(board[row + 1]);
                    //                        throw;
                }

                int prev = b.getFrontOffset(row - 1);
                int curr = b.getFrontOffset(row);
                frontOffset = (prev < curr) ? prev : curr;
                //                    frontOffset = getFrontOffset(row);
                backOffset = b.getBackOffset(row);

                //                    Console.Write("{0,2}: ", row);
                //                    sb.AppendFormat("{0,2}: ", row);
                //                    if (!allZero(row))
                b.borderPrinter(sb, width, frontOffset, backOffset);
                //                    sb.AppendFormat("    ");

                #region Innerloop (Column)

                for (col = 0; col < width - backOffset; col++)
                {
                    #region |   | Printer

                    try
                    {
                        // A lot of condensing happened here
                        if (b.isSurrounded(row, col))
                            sb.AppendFormat("| {0} ", "X");
                        else if (board[row][col - 1] == 1 || board[row][col] == 1)
                            sb.AppendFormat("| {0} ", tile);
                        else
                            sb.AppendFormat("  {0} ", tile);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        try
                        {
                            if (board[row][col] == 0)
                                sb.AppendFormat("  {0} ", tile);
                            else
                                sb.AppendFormat("| {0} ", tile);
                        }
                        catch (Exception)
                        {

                        }
                    }

                    #endregion |   | Printer
                }

                #endregion Innerloop (Column)

                // end of the row
                if (!b.allZeroRow(row))
                    sb.AppendLine("|");
                else
                    sb.AppendLine();

                // try
                // {
                //     width = board[row - 1].Length;
                // }
                // catch (IndexOutOfRangeException) { width = board[row].Length; }

                // borderPrinter(sb, width, frontOffset, getBackOffset(row));
                // Console.WriteLine();
            }

            #endregion Outerloop (Row)

            if (b.tilesToKeep.Count > 0)
                b.tilesToKeep.RemoveRange(0, b.tilesToKeep.Count);
            b.buildRow(board[row - 1]);
            // Console.Write("{0,2}: ", row);
            // sb.AppendFormat("{0,2}: ", row);
            b.borderPrinter(sb, width, frontOffset, b.getBackOffset(row));
            return sb.ToString();
        }
    }
}
