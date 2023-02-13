namespace DataStructuresAndAlgorithms.DataStructures.Queue;

public class MyQueueAsLinkedList
{
    QNode? Front;
    QNode? Rear;

    public class QNode
    {
        public int Data;
        public QNode? Next;

        public QNode(int data)
        {
            Data = data;
        }
    }

    public void Enqueue(int data)
    {
        var newNode = new QNode(data);

        if (isEmpty())
        {
            Front = Rear = newNode;
            Console.WriteLine($"{nameof(Enqueue)}: {Rear.Data} is enqueued");
            return;
        }

        Rear.Next = newNode;
        Rear = newNode;
        Console.WriteLine($"{nameof(Enqueue)}: {Rear.Data} is enqueued");
    }

    public void Dequeue()
    {
        if (isEmpty())
        {
            Console.WriteLine($"{nameof(Dequeue)}: Queue is empty");
            return;
        }

        Console.WriteLine($"{nameof(Dequeue)}: {Front?.Data} is dequeued");

        Front = Front?.Next;

        if (Front == null)
            Rear = null;
    }

    private bool isEmpty()
    {
        return Rear is null;
    }

    private void printQueue()
    {
        var node = Front;

        while (node != null)
        {
            Console.Write($"{node.Data} <- ");
            node = node.Next;
        }

        Console.WriteLine();
    }

    public void Start()
    {
        var queue = new MyQueueAsLinkedList();
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
        queue.Dequeue();
        queue.Dequeue();
        queue.Dequeue();
        queue.Dequeue();
        queue.Dequeue();
        queue.Dequeue();
        queue.printQueue();
        queue.Enqueue(3);
        queue.Enqueue(4);
        queue.printQueue();
    }
}
