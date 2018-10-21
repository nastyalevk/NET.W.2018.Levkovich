using System;

namespace Logic
{
    using System.Text;

    /// <summary>
    /// Class for work with polynom
    /// </summary>
    public class Polynomial
    {
            #region Fields
     
            private readonly double[] coefficients;
            private int degree;

            #endregion

            #region Property
            /// <summary>
            /// Get the coefficient of polynom
            /// </summary>
            public double[] Coefficients { get; }

            /// <summary>
            /// Get the degree of polynom
            /// </summary>
            public int Degree
            {
                get
                {
                    degree = Coefficients.Length - 1;
                    return degree;
                }
            }

        #endregion

            #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Polynomial"/> class. 
        /// Constructor for polinom
        /// </summary>
        /// <param name="array">
        /// array of coefficients
        /// </param>
        public Polynomial(double[] array)
            {
                if (array == null)
                {
                    throw new ArgumentNullException();
                }

                Coefficients = new double[array.Length];
                Coefficients = array;
            }

        #endregion

            #region Overloaded operations

        /// <summary>
        /// The +.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// Sum of polynomial
        /// </returns>
        public static Polynomial operator +(Polynomial left, Polynomial right)
            {
                double[] larger = new double[left.Degree + 1];
                double[] smaller = new double[right.Degree + 1];
                Array.Copy(left.Coefficients, larger, larger.Length);
                Array.Copy(right.Coefficients, smaller, smaller.Length);
                if (larger.Length < smaller.Length)
                {
                    larger = new double[right.Degree + 1];
                    smaller = new double[left.Degree + 1];
                    Array.Copy(right.Coefficients, larger, larger.Length);
                    Array.Copy(left.Coefficients, smaller, smaller.Length);
                }
                for (int i = 0; i < smaller.Length; i++)
                    larger[i] += smaller[i];
                return new Polynomial(larger);
            }

        /// <summary>
        /// The -.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// Difference of polynomial
        /// </returns>
        public static Polynomial operator -(Polynomial left, Polynomial right)
            {
                double[] larger = new double[left.Degree + 1];
                double[] smaller = new double[right.Degree + 1];
                Array.Copy(left.Coefficients, larger, larger.Length);
                Array.Copy(right.Coefficients, smaller, smaller.Length);
                if (larger.Length < smaller.Length)
                {
                    larger = new double[right.Degree + 1];
                    smaller = new double[left.Degree + 1];
                    Array.Copy(right.Coefficients, larger, larger.Length);
                    Array.Copy(left.Coefficients, smaller, smaller.Length);
                }
                for (int i = 0; i < smaller.Length; i++)
                    larger[i] -= smaller[i];
                if (right.Degree > left.Degree)
                {
                    for (int j = smaller.Length; j < larger.Length; j++)
                    {
                        larger[j] = -larger[j];
                    }
                }
                return new Polynomial(larger);
            }

        /// <summary>
        /// The *.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// Multiplication of polynomial
        /// </returns>
        public static Polynomial operator *(Polynomial left, Polynomial right)
            {
                int length = left.Degree + right.Degree;
                double[] result = new double[length + 1];
                double[] larger = new double[left.Degree + 1];
                double[] smaller = new double[right.Degree + 1];
                Array.Copy(left.Coefficients, larger, larger.Length);
                Array.Copy(right.Coefficients, smaller, smaller.Length);
                if (larger.Length < smaller.Length)
                {
                    larger = new double[right.Degree + 1];
                    smaller = new double[left.Degree + 1];
                    Array.Copy(right.Coefficients, larger, larger.Length);
                    Array.Copy(left.Coefficients, smaller, smaller.Length);
                }
                for (int i = 0; i < smaller.Length; i++)
                {
                    for (int j = 0; j < larger.Length; j++)
                    {
                        for (int k = 0; k < result.Length; k++)
                        {
                            if (i + j == k)
                            {
                                result[k] += (smaller[i] * larger[j]);
                            }
                        }
                    }
                }
                return new Polynomial(result);
            }

        /// <summary>
        /// The /.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// Division of a polynomial by a number
        /// </returns>
        public static Polynomial operator /(Polynomial left, int right)
            {
                double[] result = new double[left.Degree + 1];
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = result[i] / right;
                }
                return new Polynomial(result);
            }

        /// <summary>
        /// The /.
        /// </summary>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <returns>
        /// Division of a number by a polynomial
        /// </returns>
        /// <exception cref="ArgumentException">
        /// </exception>
        public static Polynomial operator /(double right, Polynomial left)
            {
                if (left.Degree != 0)
                    throw new ArgumentException();

                double[] result = new double[1] { right / left.Coefficients[0] };
                return new Polynomial(result);
            }

        /// <summary>
        /// The ==.
        /// </summary>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <returns>
        /// Result of comparison of polynomials
        /// </returns>
        public static bool operator ==(Polynomial right, Polynomial left)
            {
                bool result;
                if (right.Equals(left))
                    result = true;
                else
                    result = false;
                return result;
            }

        /// <summary>
        /// The !=.
        /// </summary>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <returns>
        /// Result of comparison of polynomials
        /// </returns>
        public static bool operator !=(Polynomial right, Polynomial left)
            {
                bool result;
                if (right.Equals(left))
                    result = false;
                else
                    result = true;
                return result;
            }

        #endregion

            #region Overloaded object

            /// <summary>
            /// The equals.
            /// </summary>
            /// <param name="other">
            /// The other.
            /// </param>
            /// <returns>
            /// The <see cref="bool"/>.
            /// </returns>
            public bool Equals(Polynomial other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                if (this.Coefficients.Length != other.Coefficients.Length)
                    return false;
                for (var i = 0; i < this.Coefficients.Length; i++)
                {
                    if (!this.Coefficients[i].Equals(other.Coefficients[i]))
                        return false;
                }
                return true;
            }

            /// <summary>
            /// The equals.
            /// </summary>
            /// <param name="obj">
            /// The obj.
            /// </param>
            /// <returns>
            /// The <see cref="bool"/>.
            /// </returns>
            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;

                return Equals((Polynomial)obj);
            }

            /// <summary>
            /// The get hash code.
            /// </summary>
            /// <returns>
            /// The <see cref="int"/>.
            /// </returns>
            public override int GetHashCode()
            {
                unchecked
                {
                    int hashResult = 397;

                    foreach (var item in this.coefficients)
                    {
                        hashResult += item.GetHashCode();
                    }

                    return hashResult ^ this.Degree;
                }
            }

            /// <summary>
            /// The to string.
            /// </summary>
            /// <returns>
            /// The <see cref="string"/>.
            /// </returns>
            public override string ToString()
        {

            if (Degree == 0)
            {
                string result;
                return result = "f(x)=" + Coefficients;
            }
            else
            {
                StringBuilder result = new StringBuilder("f(x)=" + Coefficients[0] + "x^" + 0);
                for (int i = 1; i < Coefficients.Length; i++)
                {
                    result.Append(" + " + Coefficients[i] + "x^" + i);
                }
                string results = result.ToString();
                return results;
            }
        }


        #endregion

            #region Operations
        /// <summary>
        /// The Addition.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// Sum of polynomial
        /// </returns>
        public static Polynomial Addition(Polynomial left, Polynomial right)
        {
            double[] larger = new double[left.Degree + 1];
            double[] smaller = new double[right.Degree + 1];
            Array.Copy(left.Coefficients, larger, larger.Length);
            Array.Copy(right.Coefficients, smaller, smaller.Length);
            if (larger.Length < smaller.Length)
            {
                larger = new double[right.Degree + 1];
                smaller = new double[left.Degree + 1];
                Array.Copy(right.Coefficients, larger, larger.Length);
                Array.Copy(left.Coefficients, smaller, smaller.Length);
            }
            for (int i = 0; i < smaller.Length; i++)
                larger[i] += smaller[i];
            return new Polynomial(larger);
        }

        /// <summary>
        /// The subtraction.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// Difference of polynomial
        /// </returns>
        public static Polynomial Subtraction (Polynomial left, Polynomial right)
        {
            double[] larger = new double[left.Degree + 1];
            double[] smaller = new double[right.Degree + 1];
            Array.Copy(left.Coefficients, larger, larger.Length);
            Array.Copy(right.Coefficients, smaller, smaller.Length);
            if (larger.Length < smaller.Length)
            {
                larger = new double[right.Degree + 1];
                smaller = new double[left.Degree + 1];
                Array.Copy(right.Coefficients, larger, larger.Length);
                Array.Copy(left.Coefficients, smaller, smaller.Length);
            }
            for (int i = 0; i < smaller.Length; i++)
                larger[i] -= smaller[i];
            if (right.Degree > left.Degree)
            {
                for (int j = smaller.Length; j < larger.Length; j++)
                {
                    larger[j] = -larger[j];
                }
            }
            return new Polynomial(larger);
        }

        /// <summary>
        /// The multiplication.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// Multiplication of polynomial
        /// </returns>
        public static Polynomial Multiplication(Polynomial left, Polynomial right)
        {
            int length = left.Degree + right.Degree;
            double[] result = new double[length + 1];
            double[] larger = new double[left.Degree + 1];
            double[] smaller = new double[right.Degree + 1];
            Array.Copy(left.Coefficients, larger, larger.Length);
            Array.Copy(right.Coefficients, smaller, smaller.Length);
            if (larger.Length < smaller.Length)
            {
                larger = new double[right.Degree + 1];
                smaller = new double[left.Degree + 1];
                Array.Copy(right.Coefficients, larger, larger.Length);
                Array.Copy(left.Coefficients, smaller, smaller.Length);
            }
            for (int i = 0; i < smaller.Length; i++)
            {
                for (int j = 0; j < larger.Length; j++)
                {
                    for (int k = 0; k < result.Length; k++)
                    {
                        if (i + j == k)
                        {
                            result[k] += (smaller[i] * larger[j]);
                        }
                    }
                }
            }
            return new Polynomial(result);
        }

        /// <summary>
        /// The division polynomial on number.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// Division of a polynomial by a number
        /// </returns>
        public static Polynomial Division(Polynomial left, int right)
        {
            double[] result = new double[left.Degree + 1];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = result[i] / right;
            }
            return new Polynomial(result);
        }

        /// <summary>
        /// The division number on polynomial.
        /// </summary>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <returns>
        /// Division of a number by a polynomial
        /// </returns>
        /// <exception cref="ArgumentException">
        /// </exception>
        public static Polynomial Division(double right, Polynomial left)
        {
            if (left.Degree != 0)
                throw new ArgumentException();

            double[] result = new double[1] { right / left.Coefficients[0] };
            return new Polynomial(result);
        }

        #endregion
    }
}

