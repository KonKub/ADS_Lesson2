using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    class Program
    {
        static int[] Arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 1000 };

        public class TestCase
        {
            public int Value { get; set; }
            public int ExpectedInd { get; set; }
            public Exception ExpectedException { get; set; }
        }

        static void TestBinarySearch(TestCase testCase)
        {
            try
            {
                var actual = BinarySearch(Arr, testCase.Value);

                if (actual == testCase.ExpectedInd)
                {
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
            catch
            {
                if (testCase.ExpectedException != null)
                {
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
        }

        public static int BinarySearch(int[] inputArray, int searchValue)
        {
            int min = 0;
            int max = inputArray.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (searchValue == inputArray[mid])
                {
                    return mid;
                }
                else if (searchValue < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }

        static void Main(string[] args)
        {
            //int Ind;
            //Ind = BinarySearch(Arr, 9);
            //Console.WriteLine(Ind);

            var testCase1 = new TestCase()
            {
                Value = 6,
                ExpectedInd = 5,
                ExpectedException = null
            };
            var testCase2 = new TestCase()
            {
                Value = 1,
                ExpectedInd = 0,
                ExpectedException = null
            };
            var testCase3 = new TestCase()
            {
                Value = 1000,
                ExpectedInd = 9,
                ExpectedException = null
            };

            var testCase4 = new TestCase()
            {
                Value = 5000,
                ExpectedInd = -1,
                ExpectedException = null
            };

            TestBinarySearch(testCase1);
            TestBinarySearch(testCase2);
            TestBinarySearch(testCase3);
            TestBinarySearch(testCase4);

            Console.ReadKey();
        }
    }
}
