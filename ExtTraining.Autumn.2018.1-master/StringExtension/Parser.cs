using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringExtension
{
    public static class Parser
    {
        #region Public
        public static long ToDecimal(this string source, int @base)
        {

            if (@base < 2 || @base > 16)
            {
                throw new ArgumentException();
            }

            long result = 0;
            for (int i = 0; i < source.Length; i++)
            {
                int tmp;
                if (StringElement(source, i) < '0' || StringElement(source, i) > '9')
                {
                    tmp = char.ToUpper(StringElement(source, i)) - 'A' + 10;
                    if (tmp >= @base)
                    {
                        throw new ArgumentException();
                    }
                }
                else
                {
                    tmp = StringElement(source, i) - '0';
                    if (tmp >= @base)
                    {
                        throw new ArgumentException();
                    }
                }
                result = (long)Math.Pow(@base, source.Length - i - 1) * tmp + result;

            }

            if (result > int.MaxValue)
            {
                throw new OverflowException();
            }

            return result;
        }

        #endregion

        #region Private

        private static char StringElement(string number, int index)
        {
            char ch = number[index];
            return ch;
        }

        #endregion
       
    }
}
