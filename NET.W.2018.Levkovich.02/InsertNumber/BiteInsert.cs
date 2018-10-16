using System;

namespace _1
{
    public class BiteInsert
    {
        public static int maxLength = 32;
        public static int InsertNumber(int firstNumber, int secondNumber, int i, int j)
        {
            if (i > j)
            {
                throw new ArgumentException("Argument i can't be more than j");
            }
            if (j > maxLength || j < 0)
            {
                throw new ArgumentOutOfRangeException("Argument j can't be more than max size");
            }
            if (i > maxLength || i < 0)
            {
                throw new ArgumentOutOfRangeException("Argument i can't be less than 0");
            }

            if ((firstNumber == 0) && (secondNumber == 0))
            {
                return 0;
            }
            for (int n = 0; n < maxLength && i <= j; n++)
            {
                int firstNBit = ReadBit(firstNumber, i);
                int secondNbit = ReadBit(secondNumber, n);
                if (!(firstNBit == secondNbit))
                {
                    if (firstNBit == 0)
                        firstNumber |= 1 << i;
                }

                i++;
            }
            return firstNumber;
        }
        public static int ReadBit(int v, int bit)
        {
            return (v >> bit) & 1;
        }
    }
}
