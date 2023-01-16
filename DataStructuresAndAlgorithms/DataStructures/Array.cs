//Constant - time access:

//array_addr + elem_size × (i − first_index)

//Times for Common Operations:
//            Add Remove

//Beginning   O(n) O(n)
//End         O(1) O(1)
//Middle      O(n) O(n)

namespace DataStructuresAndAlgorithms.DataStructures;

internal class Array
{
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
}
