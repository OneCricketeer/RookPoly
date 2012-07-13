using System;
using System.Collections;
using System.Text;

namespace ConsoleApplications.RookPolynomial
{
    public class Polynomial
    {
        ArrayList polynom = new ArrayList();

        #region Constructors
        /// <summary>
        /// Default constructor of 1
        /// </summary>
        public Polynomial()
        {
            polynom.Add(1);
        }

        /// <summary>
        /// Constructor for #
        /// </summary>
        /// <param name="x"></param>
        public Polynomial(int x)
        {
            polynom.Add(x);
        }

        /// <summary>
        /// Constructor for # + #x
        /// </summary>
        /// <param name="x"></param>
        /// <param name="x2"></param>
        public Polynomial(int x, int x2)
        {
            polynom.Add(x);
            polynom.Add(x2);
        }

        /// <summary>
        /// Constructor for # + #x + #x^2
        /// </summary>
        /// <param name="x"></param>
        /// <param name="x2"></param>
        /// <param name="x3"></param>
        public Polynomial(int x, int x2, int x3)
        {
            polynom.Add(x);
            polynom.Add(x2);
            polynom.Add(x3);
        }

        /// <summary>
        /// Constructor for # + #x + #x^2 + #x^3
        /// </summary>
        /// <param name="x"></param>
        /// <param name="x2"></param>
        /// <param name="x3"></param>
        /// <param name="x4"></param>
        public Polynomial(int x, int x2, int x3, int x4)
        {
            polynom.Add(x);
            polynom.Add(x2);
            polynom.Add(x3);
            polynom.Add(x4);
        }


        /// <summary>
        /// Constructor for # + #x + #x^2 + #x^3 + ...
        /// </summary>
        /// <param name="args"></param>
        public Polynomial(ArrayList args)
        {
            foreach (int x in args)
            {
                polynom.Add(x);
            }
        }
        #endregion

        public int Count { get { return polynom.Count; } }

        // Returns the coefficient of x^(exp) 
        public int this[int exp]
        {
            get
            {
                return (int)polynom[exp];
            }
            set
            {
                polynom[exp] = value;
            }
        }

        // Returns the sum of the polynomials in (arr)
        public static Polynomial sum(ArrayList arr)
        {
            int index = 0;
            Polynomial sum = (Polynomial)arr[index];
            for (index = 1; index < arr.Count; index++)
            {
                Polynomial curr = (Polynomial)arr[index];
                sum += curr;
            }
            return sum;
        }

        // "Exponentiates" the polynomial by (exp)
        private void exponentiateBy(int exp)
        {
            for (int i = 0; i < exp; i++)
            {
                polynom.Insert(0, 0);
            }
        }

        #region Operators
        // Plus operator: constant + Polynomial
        public static Polynomial operator +(int c, Polynomial ply)
        {
            ply[0] += c;
            return ply;
        }

        // Plus operator: Polynomial + constant
        public static Polynomial operator +(Polynomial ply, int c)
        {
            return c + ply;
        }

        // Plus operator: Polynomial + Polynomial
        public static Polynomial operator +(Polynomial ply1, Polynomial ply2)
        {
            ArrayList xs = new ArrayList();
            for (int i = 0, j = 0; i < ply1.Count || j < ply2.Count; i++, j++)
            {
                try
                {
                    xs.Add(ply1[i] + ply2[j]);
                }
                catch (ArgumentOutOfRangeException)
                {
                    // xs.Add(0);
                    if (i >= ply1.Count)
                        xs.Add(ply2[j]);
                    else if (j >= ply2.Count)
                        xs.Add(ply1[i]);
                }


            }
            //            xs.RemoveAt(0);
            Polynomial newply = new Polynomial(xs);
            return newply;
        }

        // Multiply operator: constant * Polynomial
        public static Polynomial operator *(int c, Polynomial ply)
        {
            ArrayList xs = new ArrayList();
            // xs.Add(1);
            for (int exp = 0; exp < ply.Count; exp++)
            {
                xs.Add(ply[exp] * c);
            }

            // xs.RemoveAt(0);
            return new Polynomial(xs);
        }

        // Multiply operator: Polynomial * constant
        public static Polynomial operator *(Polynomial ply, int c)
        {
            return c * ply;
        }

        // Multiply operator: Polynomial * Polynomial
        public static Polynomial operator *(Polynomial ply1, Polynomial ply2)
        {
            ArrayList xs = new ArrayList();

            for (int exp = 0; exp < ply1.Count; exp++)
            {
                int coeff = ply1[exp];

                // Multiply out the coefficients
                if (exp == 0)
                {
                    if (coeff == 1)
                        xs.Add(ply2);
                    else
                        xs.Add(coeff * ply2);
                }
                else
                {
                    Polynomial next = coeff * ply2;
                    next.exponentiateBy(exp);
                    xs.Add(next);
                }
            }
            Polynomial newply = sum(xs); // Add them together... but, wait, this is multiply O.o
            return newply;
        }

        #endregion

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            int exp = 0;
            foreach (int coeff in polynom)
            {
                if (coeff == 0)
                {
                    exp++;
                    continue;
                }
                if (exp == 0)
                    sb.AppendFormat("{0}", coeff);
                else if (exp == 1)
                {
                    if (coeff == 1)
                        sb.AppendFormat("x");
                    else
                        sb.AppendFormat("{0}x", coeff);
                }
                else
                {
                    if (coeff == 1)
                        sb.AppendFormat("x^{0}", exp);
                    else
                        sb.AppendFormat("{0}x^{1}", coeff, exp);
                }
                sb.Append(" + ");
                exp++;
            }
            return sb.Remove(sb.Length - 3, 3).ToString();
        }
    }
}
