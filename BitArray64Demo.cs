using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.BitArray64
{
    class BitArray64Demo
    {
        static void Main(string[] args)
        {
            BitArray64 test = new BitArray64(4534543);
            BitArray64 test1 = new BitArray64(54545454545);
            Console.WriteLine(test);

            foreach (var bit in test)
            {
                Console.Write(bit);
            }
            Console.WriteLine();

            Console.WriteLine(test.Equals(test1));
            Console.WriteLine(test != test1);
            Console.WriteLine(test.GetHashCode());
            Console.WriteLine(test1.GetHashCode());
        }
    }
}
