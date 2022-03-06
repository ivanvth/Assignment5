using System;
using Library;
using NUnit.Framework;
using PersonNS;

namespace Tests {
    [TestFixture]
    public class Test {
        [SetUp]
        public void Init() {
            gen = new Generator();
        }

        private Generator gen;

        [Test]
        public void TestTooLow() {
            var arr = gen.NextArray(5, 5);
            Assert.AreEqual(-1, Search.Binary(arr, -1));
            Assert.AreEqual(-1, Search.Binary(arr, -10));
            Assert.AreEqual(-1, Search.Binary(arr, -100));
            Assert.AreEqual(-1, Search.Binary(arr, -1000));
        }

        [Test]
        public void TestTooHigh() {
            var arr = gen.NextArray(5, 5);
            Assert.AreEqual(-1, Search.Binary(arr, 10));
            Assert.AreEqual(-1, Search.Binary(arr, 100));
            Assert.AreEqual(-1, Search.Binary(arr, 1000));
            Assert.AreEqual(-1, Search.Binary(arr, 10000));
        }
        
        [Test]
        public void TestElement() {
            var arr = gen.NextArray(5, 5);
            foreach (int n in arr) {
                Assert.AreNotEqual(-1, Search.Binary(arr, n));
            }
        }

        [Test]
        public void TestEmptyArray() {
            var arr = new System.IComparable[0];
            for (int i=-100; i<=100; i++) {
                Assert.AreEqual(-1, Search.Binary(arr, i));
            }
        }

        [Test]
        public void TestPerson() {
            Person[] arr = new Person[] {
                new Person("Alpha", 21),
                new Person("Beta", 22),
                new Person("Cigar", 23),
                new Person("Dudu", 24),
                new Person("Erica", 25),
            };
            System.Array.Sort(arr);

            Person testPerson1 = new Person("Dudu", 24);
            Person testPerson2 = new Person("Erica", 25);
            Person testPerson3 = new Person("Alpha", 21);

            Assert.AreEqual(3, Search.Binary(arr, testPerson1));
            Assert.AreEqual(4, Search.Binary(arr, testPerson2));
            Assert.AreEqual(0, Search.Binary(arr, testPerson3));
        }

        [Test]
        [TestCase(4)]
        [TestCase(16)]
        [TestCase(128)]
        [TestCase(1024)]
        [TestCase(10000)]
        public void TestRunningTime(int arraySize) {
            // Arrange
            ComparisonCountedInt[] arr = (ComparisonCountedInt[]) gen.NextCCIArray(arraySize, arraySize);
            ComparisonCountedInt testCCI = arr[3];
            int maxSearch = 1 + ((int)Math.Ceiling(Math.Log(arraySize, 2.0)));

            // Act
            int count = ComparisonCountedInt.CountComparisons(arr);

            // Assert
            Assert.LessOrEqual(ComparisonCountedInt.CountComparisons(arr) - count, maxSearch+2);
        }

        [Test]
        [TestCase(8)]
        [TestCase(100)]
        [TestCase(1000)]
        [TestCase(10000)]
        public void TestLinearIndexEqualsBinaryIndex(int arraySize) {
            // Arrange
            var arr = gen.NextArray(arraySize, arraySize);

            // Act
            var binaryIndex = Search.Binary(arr, arr[7]);
            var linearIndex = Search.Linear(arr, arr[7]);

            // Assert
            Assert.AreEqual(binaryIndex, linearIndex);
        }
    }
}
