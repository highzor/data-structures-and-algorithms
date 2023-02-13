//Constant - time access:

//array_addr + elem_size × (i − first_index)

//Times for Common Operations:
//            Add Remove

//Beginning   O(n) O(n)
//End         O(1) O(1)
//Middle      O(n) O(n)

namespace DataStructuresAndAlgorithms.DataStructures.Array;

internal class MyArray
{
    public void StartArray()
    {
        Traverse(getArray());
        Traverse(InsertAtPosition(getArray(), 1, "grapes"));
        Traverse(RemoveAtPosition(getArray(), 2));
    }

    public static void CreateOneDimensionalArray()
    {
        int[] intArray1 = new int[5];
        int[] intArray2 = new int[5] { 1, 2, 3, 4, 5 };
        int[] intArray3 = { 1, 2, 3, 4, 5 };

        //Initialization of an Array after Declaration

        int[] intArray4;
        intArray4 = new int[5] { 1, 2, 3, 4, 5 };

        //int[] intArray1 = new int[]; error
        //int[] intArray4;
        //intArray4 = { 1, 2, 3 }; error
    }

    public static void CreateMultidimensionalArray()
    {
        // Two-dimensional array
        int[,] intArray = new int[,]
        {
                { 1, 2 },
                { 3, 4 },
                { 5, 6 },
                { 7, 8 }
        };

        // The same array with dimensions 
        // specified 4 row and 2 column.
        int[,] intArray2 = new int[4, 2]
        {
            { 1, 2 },
            { 3, 4 },
            { 5, 6 },
            { 7, 8 }
        };

        // Three-dimensional array.
        int[,,] intArray3 = new int[,,]
        {
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            }
        };

        // The same array with dimensions 
        // specified 1, 3 and 3.

        int[,,] intArray4 = new int[1, 3, 3]
        {
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            }
        };
    }

    public static void CreateJaggedArray()
    {
        int[][] intArray1 = new int[2][];
        intArray1[0] = new int[5] { 1, 3, 5, 7, 9 };
        intArray1[1] = new int[4] { 2, 4, 6, 8 };

        int[][] intArray2 =
        {
            new int[] { 1, 3, 5, 7, 9 },
            new int[] { 2, 4, 6, 8 }
        };
    }

    /// <summary>
    /// Complexity: O(n)
    /// </summary>
    public static void Traverse(string[] array)
    {
        Console.Write("{");
        foreach (var item in array)
        {
            Console.Write($"{item}, ");
        }
        Console.WriteLine("}");
    }

    /// <summary>
    /// Complexity: O(n)
    /// </summary>
    public static string[] InsertAtPosition(string[] array, int position, string item)
    {
        for (var i = array.Length - 1; i > position; i--)
        {
            array[i] = array[i - 1];
        }

        array[position] = item;

        return array;
    }

    /// <summary>
    /// Complexity: O(n)
    /// </summary>
    public static string[] RemoveAtPosition(string[] array, int position)
    {
        for (var i = position; i < array.Length - 1; i++)
        {
            array[i] = array[i + 1];
        }

        return array;
    }

    private static string[] getArray()
    {
        var array = new string[6];
        array[0] = "apple";
        array[1] = "mango";
        array[2] = "peach";
        array[3] = "orange";
        array[4] = "banana";
        return array;
    }
}
