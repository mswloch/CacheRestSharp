using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheRestSharp.Helpers
{
    public class Triple<T,K,L>
    {
        public T A { get; set; }
        public K B { get; set; }
        public L C { get; set; }

        public Triple() { }
        public Triple(T a, K b, L c)
        {
            A = a;
            B = b;
            C = c;
        }
    }
}
