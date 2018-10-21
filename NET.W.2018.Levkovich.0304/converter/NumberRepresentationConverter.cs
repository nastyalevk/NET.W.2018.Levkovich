using System;
using System.Runtime.InteropServices;

namespace NumberRepresentationConverter
{
    /// <summary>
    /// Public class, that represent number in binary notation. 
    /// </summary>
    public static class NumberRepresentationConverter
     {
         #region Constant
          
            private const int BITS_IN_BYTE = 8;

            #endregion


         #region Public methods

            /// <summary>
            /// Convert double to string IEEE 754 format.
            /// </summary>
            /// <param name="number"> Value to convert. </param>
            /// <returns> String representation in IEEE 754 format. </returns>
            public static string DoubleToBinaryString(this double number)
            {
                var tmp = new DoubleToLongStruct(number);
                var tmp2 = tmp.Long64bits;
                var result = new char[64];
                for (var i = BITS_IN_BYTE * 8 - 1; i >= 0; i--)
                {
                    result[i] = (tmp2 & 1) == 0 ? '0' : '1';
                    tmp2 >>= 1;
                }

                var results = new string(result);
                return results;
            }

            #endregion


         #region Struct
        
            [StructLayout(LayoutKind.Explicit)]
            private struct DoubleToLongStruct
            {
                [FieldOffset(0)]
                private readonly long long64bits;
            
                [FieldOffset(0)]
                private double double64bits;
            
                public DoubleToLongStruct(double number)
                    : this()
                {
                    this.Double64bits = number;
                }
            
                public long Long64bits => this.long64bits;
            
                public double Double64bits
                {
                    get => this.double64bits;
                    set => this.double64bits = value;
                }
            }

            #endregion
    }
}

