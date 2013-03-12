//Define a class BitArray64 to hold 64 bit values inside an ulong value. Implement 
//    IEnumerable<int> and Equals(…), GetHashCode(), [], == and !=.

using System;
using System.Collections.Generic;
using System.Collections; //IMPORTANT TO BE ADDED
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.BitArray64
{
    public class BitArray64 : IEnumerable<int>
    {

        //--------FIELDS-----------//
        //public int[] bitArray = new int[64];//array that holds the bits
        private ulong uLongNumber;


        //--------PROPETRIE-------------//
        public ulong ULongNumber
        {
            get { return this.uLongNumber; }
            set { this.uLongNumber = value; }
        }


        //-----------CONSTRUCTOR-------------//
        public BitArray64(object longNumber)
        {


            ulong checher;
            if (ulong.TryParse(longNumber.ToString(), out checher))
            {
                this.ULongNumber = checher;
            }
            else
            {
                throw new ArgumentException("ulong");
            }
        }


        //-----------IEnumerable IMPLEMENTATION-----------------//

        public IEnumerator<int> GetEnumerator() //implement foreach
        {
            for (int i = 63; i >= 0; i--)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator(); //generic version of the method
        }
        

        //-----------IMPEMENT EQUALS---------------//
        public override bool Equals(object obj)
        {
            BitArray64 bitArray = obj as BitArray64; //casting

            if (bitArray == null)
            {
                return false;
            }

            if (!Object.Equals(this.ULongNumber, bitArray.ULongNumber))
            {
                return false;
            }

            return true;
        }


        //--------------GetHashCode IMPLEMENTATION---------------//
        public override int GetHashCode()
        {
            return this.ULongNumber.GetHashCode();
        }


        //------------- [] IMPLEMENTATION ---------------//
        public int this[int index]
        {
            get
            {
                if (index > 63 || index < 0)
              {
		            throw new ArgumentException("index");
 	            }
                return Convert.ToInt32((((ulong)1 << index) & this.ULongNumber) >> index);
            }
        }

        //-------------- == AND != IMPLEMENTATION--------------//
        public static bool operator ==(BitArray64 first, BitArray64 second)
        {
            return Object.Equals(first, second);
        }

        public static bool operator !=(BitArray64 first, BitArray64 second)
        {
            return !Object.Equals(first, second);
        }


        //--------------ToString IMPLEMENTATION---------------//
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 63; i >= 0; i--)
            {
                sb.Append(this[i]);
            }
            return sb.ToString();
        }
    }
}
