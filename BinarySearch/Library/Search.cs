using System;

namespace Library {
    public static class Search {
        public static int Binary(IComparable[] array, IComparable target) {
            if (array.Length == 0) {
                return -1;
            }

            if (target.CompareTo(array[0]) < 0 ||
                target.CompareTo(array[array.Length-1]) > 0) {
                return -1;
            }

            var low = 0;
            var high = array.Length - 1;

            while (low <= high) {
                var mid = (int)((Int64)(high + low) / (Int64)2);
                var midVal = array[mid];
                var relation = midVal.CompareTo(target);

                if (relation < 0) {
                    low = mid + 1;
                } else if (relation > 0) {
                    high = mid - 1;
                } else if (mid != low) {
                    high = mid;
                } else {
                    return mid;
                }
            }
            
            return -1;
        }

        public static int Linear(IComparable[] array, IComparable target) {
            for (int i=0; i<array.Length; i++) {
                if (array[i].CompareTo(target) == 0) {
                    return i;
                }
            }
            return -1;
        }
    }
}