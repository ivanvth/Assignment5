using System;
using Library;

namespace TUI {
    internal class MainClass {
        private static void PrintArray(object[] array) {
            Console.WriteLine("Test Array: {0}", Show.Array(array));
        }

        private static void TestArray(IComparable[] array) {
            MainClass.PrintArray(array);

            for (var i = 0; i <= 11; i++) {
                var result = Search.Binary(array, i);
                if (result == -1) {
                    Console.WriteLine("{0} was not found.", i);
                } else {
                    Console.WriteLine("{0} was found in index {1}.", i, result);
                }
            }
        }

        private static void TestCCIArray(IComparable[] array) {
            MainClass.PrintArray(array);

            for (var i=0; i<10; i++) {
                var tempCCI = new ComparisonCountedInt(i);
                var result = Search.Binary(array, tempCCI);
                if (result == -1) {
                    System.Console.WriteLine("{0} was not found.", tempCCI);
                } else {
                    System.Console.WriteLine("{0} was found at index {1}.", tempCCI, result);
                }
            }
        }
        public static void Main(string[] args) {
            var gen = new Generator();

            // MainClass.TestArray(gen.NextArray(10, 10));
            // MainClass.TestArray(gen.NextArray(10, 10));
            // MainClass.TestArray(gen.NextArray(10, 10));

            MainClass.TestCCIArray(gen.NextCCIArray(10, 10));
        }
    }
}