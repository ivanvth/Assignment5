using System;

namespace Library
{
    public class ComparisonCountedInt : IComparable
    {
        public ComparisonCountedInt(int n) {
            N = n;
            Compared = 0;
        }
        public int N;
        private int Compared;
        private int ComparisonCount { 
            get { return Compared; } 
        }

        public static int CountComparisons(ComparisonCountedInt[] array) {
            int sum = 0;
            foreach (ComparisonCountedInt cci in array) {
                System.Console.WriteLine(sum + " + " + cci.Compared);
                sum += cci.ComparisonCount;
            }
            return sum;
        }

        public int CompareTo(Object other)
        {
            Compared++;
            if (other is null) {
                return -1;
            }

            if (other is ComparisonCountedInt cci) {
                return this.N - cci.N;
            } else {
                throw new ArgumentException("Object is not a ComparisonCountedInt " + other.GetType() + ":: " + other);
            }
            
        }

        public override string ToString() {
            return $"CCI {N}";
        }
    }
}