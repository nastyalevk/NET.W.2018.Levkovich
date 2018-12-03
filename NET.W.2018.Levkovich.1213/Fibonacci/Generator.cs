using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    public class Generator<T>
    {
        public List<T> seq { get; set; }

        public Generator(T firstEl, T secondEl, Func<T, T, T> formula)
        {
            if (formula == null)
            { throw new ArgumentNullException(); }
            if (firstEl == null)
            { throw new ArgumentNullException(); }
            if (secondEl == null)
            { throw new ArgumentNullException(); }
            seq = new List<T> { };
            seq.Add(firstEl);
            seq.Add(secondEl);
            int n = 10;
            for (int i = 2; i < n; i++)
            {
                seq.Add(formula(seq[i - 1], seq[i - 2]));
            }
        }
        public Generator(T firstEl, T secondEl, int elCount, Func<T, T, T> formula)
        {
            if (formula == null)
            { throw new ArgumentNullException(); }
            if (firstEl == null)
            { throw new ArgumentNullException(); }
            if (secondEl == null)
            { throw new ArgumentNullException(); }
            seq = new List<T> { };
            seq.Add(firstEl);
            seq.Add(secondEl);
            int n = elCount;
            for (int i = 2; i < n; i++)
            {
                seq.Add(formula(seq[i - 1], seq[i - 2]));
            }
        }

    }
}
