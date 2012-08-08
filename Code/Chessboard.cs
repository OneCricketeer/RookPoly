using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Collections.Generic;

namespace ConsoleApplications.RookPolynomial
{
    public class Chessboard : ICloneable
    {
        public int[][] board { get; set; }
        public Polynomial polynomial;

        // Initialization of the board matrix
        public Chessboard()
        {

            // 0 = "hole" or invalid tile
            // 1 = valid tile to place a rook
            this.board = new int[][]
                 {
                    new int[] {1, 1, 1, 1},
                    new int[] {1, 1, 1, 1},
                    new int[] {1, 1, 1, 1},
                    new int[] {1, 1, 1, 1},

//                    new int[] {1, 1, 1, 1, 1, 1, 1, 0},
//                    new int[] {1, 1, 1, 1, 1, 1, 1, 0},
//                    new int[] {1, 1, 1, 1, 1, 1, 1, 0},
//                    new int[] {1, 1, 1, 1, 1, 1, 1, 0},
//                    new int[] {1, 1, 1, 1, 1, 1, 1, 0},
//                    new int[] {1, 1, 1, 1, 1, 1, 1, 0},
//                    new int[] {1, 1, 1, 1, 1, 1, 1, 0},
//                    new int[] {0, 0, 0, 0, 0, 0, 0, 0},
//                    new int[] {0, 0, 0, 0, 0, 0, 0, 0, 1},
//                    new int[] {1, 0, 0, 1, 1, 1, 1, 1, 1},
//                    new int[] {1, 0, 0, 1, 1, 1, 1, 0, 0},
//                    new int[] {0, 1, 0, 0, 0, 0, 0, 0, 0},
//                    new int[] {1, 0, 1, 1, 1, 0, 0, 1, 1},
//                    new int[] {1, 1, 0, 0, 1, 1, 1, 0, 1},
                 };
        }

        public Chessboard(int[][] board)
        {
            this.board = board;
        }

        #region <Fields>
        public ArrayList tilesToKeep;

        // Returns the number of valid tiles on the board
        public int Count
        {
            get
            {
                int count = 0;
                foreach (int[] row in board)
                {
                    foreach (int col in row)
                    {
                        if (col == 1)
                            count++;
                    }
                }
                return count;
            }
        }

        // Returns a list of the rows with the greatest number of valid tiles in descending order
        public ArrayList greatestRows
        {
            get
            {
                ArrayList rows = new ArrayList();
                int thisRowCount = 0, prevRowCount = 0;
                for (int r = 0; r < board.Length; r++)
                {
                    foreach (int col in board[r])
                    {
                        if (col == 1)
                            thisRowCount++;
                    }

                    if (thisRowCount > prevRowCount || rows.Count == 0)
                        rows.Insert(0, r);
                    else
                        rows.Add(r);

                    prevRowCount = thisRowCount;
                    thisRowCount = 0;
                }

                return rows.Count == 0 ? new ArrayList() { 0 } : rows;
            }
        }

        // Returns a list of the columns with the greatest number of valid tiles in descending order
        public ArrayList greatestCols
        {
            get
            {
                ArrayList cols = new ArrayList();
                int thisColCount = 0, prevColCount = 0;
                for (int c = 0; c < Width; c++)
                {
                    for (int r = 0; r < Height; r++)
                    {
                        try
                        {
                            if (board[r][c] == 1)
                                thisColCount++;
                        }
                        catch (IndexOutOfRangeException) { continue; }
                    }
                    if (thisColCount > prevColCount || cols.Count == 0)
                        cols.Insert(0, c);
                    else
                        cols.Add(c);

                    prevColCount = thisColCount;
                    thisColCount = 0;
                }

                return cols.Count == 0 ? new ArrayList() { 0 } : cols;
            }

        }

        // Calculates and returns [row, column] of a cross on the board with the greatest number of valid tiles. 
        public int[] greatestIntersection
        {
            get
            {
                ArrayList rows = greatestRows;
                ArrayList cols = greatestCols;
                int[] intersect = new int[] { 0, 0 };

                foreach (int row in rows)
                {
                    foreach (int col in cols)
                    {
                        if (isValid(row, col))
                        {
                            return new int[] { row, col };
                        }
                    }
                }

                return intersect;
            }

        }

        // Returns the "height" of the board
        public int Height
        {
            get { return board.Length; }
        }

        // Returns the "width" of the board
        public int Width
        {
            get
            {
                int maxWidth = 0;
                foreach (int[] row in board)
                {
                    if (row.Length > maxWidth)
                        maxWidth = row.Length;
                }
                return maxWidth;
            }
        }

        #endregion <Fields>

        #region <Polynomial methods>
        // Deletes the cell at (row, col) and recursively reduces the board 
        // Returns a RookPolynomial of the board 
        public Polynomial deleteCell(int row, int col)
        {
            Chessboard newboard = new Chessboard(DeepCopy(board));
            //            Board newboard = (Board)this.Clone();
            newboard.board[row][col] = 0;

            // base case : the entire board is zero, return 1
            if (newboard.Count == 0)
                return new Polynomial();
            // base case 2 : there is one cell left, return 1 + x
            else if (newboard.Count == 1)
                return new Polynomial(1, 1);
            // else, recurse using deleteCell + x * deleteRowCol
            else
            {
//                newboard.shrink(); Console.WriteLine("C\n{0}", newboard);
                int[] intersect = newboard.greatestIntersection;
                Polynomial x = new Polynomial(0, 1);
                return newboard.deleteCell(intersect[0], intersect[1]) + x * newboard.deleteRowCol(intersect[0], intersect[1]);
            }
        }

        // Deletes the cross centered at (row, col) and recursively reduces the board
        // Returns a RookPolynomial of the board
        public Polynomial deleteRowCol(int row, int col)
        {
            Chessboard newboard = new Chessboard(DeepCopy(board));
            //            Board newboard = (Board)this.Clone();
            int maxDim = Width > Height ? Width : Height;
            for (int i = 0; i < maxDim; i++)
            {
                try
                {
                    newboard.board[row][i] = 0;
                    newboard.board[i][col] = 0;
                }
                catch (IndexOutOfRangeException) { continue; }

            }

            // base case : the entire board is zero, return 1
            if (newboard.Count == 0)
                return new Polynomial();
            // base case 2 : there is one cell left, return 1 + x
            else if (newboard.Count == 1)
                return new Polynomial(1, 1);
            // else, recurse using deleteCell + x * deleteRowCol
            else
            {
//                newboard.shrink(); Console.WriteLine("RC\n{0}", newboard);
                int[] intersect = newboard.greatestIntersection;
                Polynomial x = new Polynomial(0, 1);
                return newboard.deleteCell(intersect[0], intersect[1]) + x * newboard.deleteRowCol(intersect[0], intersect[1]);
            }

        }
        #endregion

        #region <Methods used purely for printing>

        // Returns true is the tile at (row, col) is valid
        public bool isValid(int row, int col)
        {
            try
            {
                return board[row][col] == 1;
            }
            catch (IndexOutOfRangeException) { return false; }
        }

        // Returns true if an entire row is invalid
        public bool allZeroRow(int row)
        {
            try // Tests to see if the parameter is out of bounds for the board
            {
                if (board[row].Length == 0)
                    return true;
            }
            // Adjusts the call according to which bound is out
            catch (IndexOutOfRangeException) { return row < 0 ? allZeroRow(row + 1) : allZeroRow(row - 1); }

            bool b = false;

            foreach (int c in board[row])
            {
                b = c == 0;
                if (!b) break; // break on the first 1
            }

            return b;
        }

        // Returns true if an entire column is invalid
        public bool allZeroCol(int col)
        {
            bool b = false;

            for (int r = 0; r < Height; r++)
            {
                try
                {
                    b = board[r][col] == 0;
                    if (!b) break; // break on the first 1
                }
                // Adjusts the call according to which bound is out
                catch (IndexOutOfRangeException) { return col < 0 ? allZeroCol(col + 1) : allZeroCol(col - 1); }
            }
            return b;
        }

        // Returns the number of trailing 0's in a row on the board matrix 
        public int getBackOffset(int row)
        {
            int offset = 0;

            try
            {
                if (allZeroRow(row))
                    return board[row].Length;
                for (int i = board[row].Length - 1; board[row][i] == 0 && i > 0; i--)
                {
                    offset++;
                }
            }
            catch (IndexOutOfRangeException) { return row < 0 ? getBackOffset(row + 1) : getBackOffset(row - 1); }
            return offset;
        }

        // Returns the number of leading 0's in a row on the board matrix
        public int getFrontOffset(int row)
        {
            try
            {
                int offset = 0;
                if (allZeroRow(row))
                    return board[row].Length;
                for (int i = 0; board[row][i] == 0 && i < board[row].Length; i++)
                {
                    offset++;
                }
                return offset;
            }
            catch (IndexOutOfRangeException)
            {
                return row < 0 ? getFrontOffset(row + 1) : getFrontOffset(row - 1);
            }
        }

        // Returns true if the cell at (row, col) 
        public bool isSurrounded(int row, int col)
        {
            bool b = false;

            try
            {
                if (board[row][col] == 0)
                {
                    if (board[row][col - 1] == 1 && board[row][col + 1] == 1)
                        b = true;
                    if (board[row - 1][col] == 0 || board[row + 1][col] == 0)
                        b = false;
                }
                else
                    return false;
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
            return b;
        }

        // Builds an arraylist of the tile borders to keep during printing
        public void buildRow(int[] row)
        {
            for (int i = 0; i < row.Length; i++)
            {
                if (row[i] == 1)
                {
                    if (!tilesToKeep.Contains(i))
                        tilesToKeep.Add(i);
                }
            }
        }

        #region +--+ Printer
        public void borderPrinter(StringBuilder sb, int d, int frontOffset, int backOffset)
        {
            for (int item = 0; item <= d; item++)
            {
                if (tilesToKeep.Contains(item))
                {
                    sb.AppendFormat("+---");
                }
                else if (tilesToKeep.Contains(item - 1))
                {
                    if (!tilesToKeep.Contains(item))
                        sb.AppendFormat("+   ");
                }
                else
                    sb.AppendFormat("    ");
            }
            sb.AppendLine();
        }
        #endregion +--+ Printer

        public override string ToString()
        {
            return RookPoly.printBoard(this.board);
        }
        #endregion <Printing methods>

        // Unused
        // Shrinks the board by copying the board matrix to a new matrix
        // The outer all-zero rows and columns are to be ignored when copying
        public void shrink()
        {
//            foreach (int[] r in board)
//            {
//                foreach (int c in r)
//                {
//                    Console.Write(c);
//                }
//                Console.WriteLine();
//            }
            List<int[]> newboard = new List<int[]>();

            int width = Width;
            int height = Height;
            int startRow = 0, startCol = 0;

            while (allZeroCol(startCol)) startCol++; // reduce left
            while (allZeroCol(width)) width--; // reduce right
            while (allZeroRow(startRow)) startRow++; // reduce top
            while (allZeroRow(height)) height--; // reduce bottom
   
            for (int i = 0; i < height - startRow; i++)
            {
                int length = width - startCol == 0 ? 1 : width - startCol;
                newboard.Add(new int[length]);
            }

            Console.WriteLine("Start = [{0}][{1}]", startRow, startCol);
            Console.WriteLine("Width = {0}", newboard[0].Length);
            Console.WriteLine("Height = {0}", height);

            for (int i = startRow, r = 0; i <= newboard.Count; i++, r++)
            {
                for (int j = startCol, c = 0; j <= newboard[0].Length; j++, c++)
                {
                    try
                    {
                        int t =  board[i][j];
                        newboard[r][c] = t;
                    }
                    catch (Exception)
                    {
//                        Console.WriteLine("board[{0}][{1}] is out of bounds", i, j);
                        continue;
                    }
//                    Array.Copy(board[i], i, (int[])reduced[r], r, width - startCol - 1);
                }
            }
            foreach (int[] r in newboard)
            {
                foreach (int col in r)
                {
                    Console.Write(col);
                }
                Console.WriteLine();
            }
        }

        // Copied from online. 
        // Creates a deep copy instead of a shallow copy... not quite sure what that means, but it works
        public static T DeepCopy<T>(T item)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            formatter.Serialize(stream, item);
            stream.Seek(0, SeekOrigin.Begin);
            T result = (T)formatter.Deserialize(stream);
            stream.Close();
            return result;
        }

        public object Clone()
        {
            return new Chessboard(this.board);
        }
    }
}