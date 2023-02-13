//Enqueue()         O(1)
//Dequeue()         O(1)
//IsFull()          O(1)
//IsEmpty()         O(1)

namespace DataStructuresAndAlgorithms.DataStructures.Queue;

public class MyCircularQueueAsArray
{
    private int[] queue;
    private int front;
    private int rear;
    private int max;
    private int count;

    public MyCircularQueueAsArray(int size)
    {
        queue = new int[size];
        front = 0;
        rear = -1;
        max = size;
    }

    public MyCircularQueueAsArray() { }

    public void Enqueue(int data)
    {
        if (isFull())
        {
            Console.WriteLine($"{nameof(Enqueue)}: Queue is overflow");
            return;
        }

        rear = (rear + 1) % max;
        queue[rear] = data;
        count++;

        Console.WriteLine($"{nameof(Enqueue)}: {queue[rear]} is enqueued");
    }

    public void Dequeue()
    {
        if (isEmpty())
        {
            Console.WriteLine($"{nameof(Dequeue)}: Queue is empty");
            return;
        }

        Console.WriteLine($"{nameof(Dequeue)}: {queue[front]} is dequeued");
        front = (front + 1) % max;
        count--;
    }

    private void printQueue()
    {
        if (isEmpty())
        {
            Console.WriteLine($"{nameof(printQueue)}: Queue is empty");
            return;
        }

        var i = front;
        var j = 0;

        for (; j < count;)
        {
            Console.Write($"{queue[i]} <- ");
            i = (i + 1) % max;
            j++;
        }

        Console.WriteLine();
    }

    private bool isFull()
    {
        return count == max;
    }

    private bool isEmpty()
    {
        return count == 0;
    }

    public void Start()
    {
        var queue = new MyCircularQueueAsArray(5);
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
        queue.Enqueue(7);
        queue.printQueue();
        queue.Enqueue(8);
        queue.printQueue();
        queue.Enqueue(9); //error
        queue.printQueue();
        queue.Dequeue();
        queue.Enqueue(9); //success
        queue.printQueue();
    }
}
