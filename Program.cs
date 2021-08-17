using System;

namespace UnderstandingArrays
{
    class Program
    {
        static void Main()
        {
            SimpleArrays();
            UseArrayInitializationSyntax();
            DeclareImplicitArrays();
            ArrayOfObjects();
            UseRectangularArray();
            UseJaggedArray();
            SystemArrayFunctionality();

            Console.ReadLine();
        }

        static void SimpleArrays()
        {
            Console.WriteLine("******************************** Simple Array Creation ********************************");
            // Create and fill an array of 7 Integers
            int[] ints1 = new int[7];
            // Now print each value.
            foreach (int i in ints1)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();

            int[] ints2 = new int[7];
            for (int i = 0; i < ints2.Length; i++)
            {
                ints2[i] = (int)Math.Pow(i, 2);
            }
            for (int i = 0; i < ints2.Length - 1; i++)
            {
                Console.Write($"{ints2[i]}, ");
            }
            Console.Write(ints2[ints2.Length - 1]);
        }

        static void UseArrayInitializationSyntax()
        {
            Console.WriteLine("\n\n******************************** Array initialization syntaxn *******************************");
            // Array initialization syntax using the new keyword.
            string[] stringArray = new string[] { "one", "two", "three" };
            Console.WriteLine("stringArray has {0} elements", stringArray.Length);

            // Array initialization syntax without using the new keyword.
            bool[] boolArray = { false, false, true };
            Console.WriteLine("boolArray has {0} elements", boolArray.Length);

            // Array initialization with new keyword and size.
            int[] intArray = new int[4] { 20, 22, 23, 0 };
            Console.WriteLine("intArray has {0} elements", intArray.Length);

            // OOPS! Mismatch of size and elements!
            //int[] intArray1 = new int[2] { 20, 22, 23, 0 };
            //int[] intArray2 = new int[2] { 202 };
        }

        static void DeclareImplicitArrays()
        {
            Console.WriteLine("\n******************************** Implicit Array Initialization *******************************");
            // a is really int[].
            var a = new[] { 1, 10, 100, 1000 };
            Console.WriteLine("a is a: {0}", a.ToString());

            // b is really double[].
            var b = new[] { 1, 1.5, 2, 2.5 };
            Console.WriteLine("b is a: {0}", b.ToString());

            // c is really string[].
            var c = new[] { "hello", null, "world" };
            Console.WriteLine("c is a: {0}", c.ToString());

            // Error! Mixed types!
            // var d = new[] { 1, "one", 2, "two", false };
        }

        static void ArrayOfObjects()
        {
            Console.WriteLine("\n******************************** Array of Objects *******************************");
            // An array of objects can be anything at all.
            object[] objects = new object[7];
            objects[0] = 7.5F;
            objects[1] = new TimeSpan(82, 45, 45);
            objects[2] = new DateTime(2021, 8, 16);
            objects[3] = 2021;
            objects[4] = new int[] { 5, 9, 12, 13 };
            objects[5] = "Just for test";
            objects[6] = 0.5;
            foreach (object obj in objects)
            {
                // Print the type and value for each item in array.
                Console.WriteLine("Type: {0}, Value: {1}", obj.GetType(), obj);
            }
        }

        static void UseRectangularArray()
        {
            // A rectangular array, which is simply an array of multiple dimensions,
            // where each row is of the same length
            Console.WriteLine("\n******************************** Rectangular multidimensional array ********************************");
            // A rectangular multidimensional array.
            int[,] myMatrix;
            myMatrix = new int[3, 4];
            // Populate (3 * 4) array.
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    myMatrix[i, j] = i * j;
                }
            }
            // Print (3 * 4) array.
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(myMatrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        static void UseJaggedArray()
        {
            // A jagged arrays contain some number of inner arrays,
            // each of which may have a different upper limit.
            Console.WriteLine("\n******************************** Jagged multidimensional array ********************************");
            // A jagged multidimensional array (i.e., an array of arrays).
            // Here we have an array of 10 different arrays.
            int[][] myJagArray = new int[10][];
            // Create the jagged array.
            for (int i = 0; i < myJagArray.Length; i++)
            {
                myJagArray[i] = new int[i + 2];
            }
            // Print each row (remember, each element is defaulted to zero!).
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < myJagArray[i].Length; j++)
                {
                    Console.Write(myJagArray[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void SystemArrayFunctionality()
        {
            Console.WriteLine("\n******************************** Working with System.Array ********************************");
            int[] intArray = new int[4] { 2021, 1980, 1692, 2008 };
            string[] fruits = new string[] { "Apple", "Apricot", "Pear", "Grape", "Peach", "Cherry", "Watermelon", "Melon" };
            string templateFruit = "Strawberry";
            object year = 1980;
            getIndex(fruits, templateFruit);
            getIndex(fruits, "Watermelon");
            getIndex(intArray, year);

            sortingArray(fruits);
            sortingArray(intArray);
        }

        static int getIndex(object[] source, object template)
        {
            int retVal = Array.BinarySearch(source, template);
            if (retVal >= 0)
                Console.WriteLine("Item index " + retVal.ToString());
            else
                Console.WriteLine("Item not found");

            return retVal;
        }

        static int getIndex(int[] source, object template)
        {
            int retVal = Array.BinarySearch(source, template);
            if (retVal >= 0)
                Console.WriteLine("Item index " + retVal.ToString());
            else
                Console.WriteLine("Item not found");

            return retVal;
        }

        static void sortingArray<T>(T[] source)
        {
            Console.Write("\n\nOriginal Array: ");
            for (int i = 0; i < source.Length - 1; i++)
            {
                Console.Write($"{source[i]}, ");
            }
            Console.Write(source[source.Length - 1]);

            Console.Write("\nSorted Array: ");
            Array.Sort(source);
            for (int i = 0; i < source.Length - 1; i++)
            {
                Console.Write($"{source[i]}, ");
            }
            Console.Write(source[source.Length - 1]);
        }
    }
}