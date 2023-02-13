using DataStructuresAndAlgorithms.DataStructures.Array;
using DataStructuresAndAlgorithms.DataStructures.LinkedList;
using DataStructuresAndAlgorithms.DataStructures.Queue;
using DataStructuresAndAlgorithms.DataStructures.Stack;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, DSA!");
        new MyArray().StartArray();
        new MySinglyLinkedList().Start();
        new MyDoublyLinkedList().Start();
        new MyStackAsArray().Start();
        new MyStackAsLinkedList().Start();
        new MyQueueAsArray().Start();
        new MyCircularQueueAsArray().Start();
        new MyQueueAsLinkedList().Start();
    }
}