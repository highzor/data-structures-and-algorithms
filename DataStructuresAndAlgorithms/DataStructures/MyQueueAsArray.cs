//Enqueue()         O(1)
//Dequeue()         O(1)
//IsFull()          O(1)
//IsEmpty()         O(1)

namespace DataStructuresAndAlgorithms.DataStructures;

public class MyQueueAsArray
{
    private int[] queue;
    private int front;
    private int rear;
    private int max;

    public MyQueueAsArray(int size)
    {
        queue = new int[size];
        front = 0;
        rear = -1;
        max = size;
    }

    public MyQueueAsArray() {}

    public void Enqueue(int data)
    {
        if (isFull())
        {
            Console.WriteLine($"{nameof(Enqueue)}: Queue overflow");
            return;
        }

        Console.WriteLine($"{nameof(Enqueue)}: {data} is enqueued");
        queue[++rear] = data;
    }

    public void Dequeue()
    {
        if (isEmpty())
        {
            Console.WriteLine($"{nameof(Dequeue)}: Queue is empty");
            return;
        }

        Console.WriteLine($"{nameof(Dequeue)}: {queue[front++]} is dequeued");
    }

    private void printQueue()
    {
        if (isEmpty())
        {
            Console.WriteLine($"{nameof(printQueue)}: Queue is empty");
            return;
        }

        for (var i = front; i <= rear; i++)
        {
            Console.Write($"{queue[i]} <- ");
        }
        Console.WriteLine();
    }

    private bool isFull()
    {
        return rear == max - 1;
    }

    private bool isEmpty()
    {
        return front == rear + 1;
    }

    public void Start()
    {
        var queue = new MyQueueAsArray(5);
        queue.printQueue();
        queue.Dequeue();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);
        queue.printQueue();
        queue.Dequeue();
        queue.printQueue();
        queue.Dequeue();
        queue.printQueue();
        queue.Enqueue(6);
        queue.printQueue();
    }
}