//Singly - Linked List
//                     no tail | with tail

//PushFront(Key)         O(1)
//TopFront()             O(1)
//PopFront()             O(1)
//PushBack(Key)          O(n)      O(1)
//TopBack()              O(n)      O(1)
//PopBack()              O(n)
//Find(Key)              O(n)
//Erase(Key)             O(n)
//IsEmpty()              O(1)
//AddBefore(Node, Key)   O(n)
//AddAfter(Node, Key)    O(1)
//ReverseList()          O(n)

namespace DataStructuresAndAlgorithms.DataStructures.LinkedList;

public class MySinglyLinkedList
{
    Node? Head;

    public class Node
    {
        public int Data;
        public Node? Next;
        public Node(int data)
        {
            Data = data;
        }
    }

    public void PushFront(int data)
    {
        var node = new Node(data);
        node.Next = Head;
        Head = node;
    }

    public void TopFront()
    {
        if (isEmpty())
        {
            Console.WriteLine("LinkedList is empty.");
            return;
        }

        Console.WriteLine($"{nameof(TopFront)}: {Head?.Data}");
    }

    public void PopFront()
    {
        if (isEmpty())
        {
            Console.WriteLine("LinkedList is empty.");
            return;
        }

        Console.WriteLine($"{nameof(PopFront)}: {Head?.Data}");
        Head = Head?.Next;
    }

    public void PushBack(int data)
    {
        var node = new Node(data);

        if (Head == null)
        {
            Head = node;
            return;
        }

        var lastNode = Head;

        while (lastNode.Next != null)
            lastNode = lastNode.Next;

        lastNode.Next = node;
    }

    public void TopBack()
    {
        if (isEmpty())
        {
            Console.WriteLine("LinkedList is empty.");
            return;
        }

        var lastNode = Head;

        while (lastNode?.Next != null)
            lastNode = lastNode.Next;

        Console.WriteLine($"{nameof(TopBack)}: {lastNode?.Data}");
    }

    public void PopBack()
    {
        if (isEmpty())
        {
            Console.WriteLine("LinkedList is empty.");
            return;
        }

        var temp = Head;
        Node? prev = null;

        while (temp?.Next != null)
        {
            prev = temp;
            temp = temp.Next;
        }

        Console.WriteLine($"{nameof(PopBack)}: {temp?.Data}");
        prev.Next = null;
    }

    public void AddAfter(Node givenNode, int data)
    {
        if (givenNode == null)
        {
            Console.WriteLine("givenNode can't be null");
            return;
        }

        var newNode = new Node(data);
        newNode.Next = givenNode.Next;
        givenNode.Next = newNode;
    }

    public void AddBefore(Node givenNode, int data)
    {
        if (givenNode == null)
        {
            Console.WriteLine("givenNode can't be null");
            return;
        }

        var node = new Node(data);

        if (givenNode == Head)
        {
            node.Next = Head;
            Head = node;
            return;
        }
        else
        {
            var temp = Head;
            Node? prev = null;

            while (temp != givenNode)
            {
                prev = temp;
                temp = temp?.Next;
            }

            node.Next = givenNode;
            prev.Next = node;
        }
    }

    public bool Find(int key)
    {
        var node = Head;

        while (node != null)
        {
            if (node.Data == key)
                return true;

            node = node.Next;
        }

        return false;
    }

    public void Erase(int key)
    {
        var temp = Head;
        Node? prev = null;

        if (temp != null && temp.Data == key)
        {
            Head = temp.Next;
            return;
        }

        while (temp != null && temp.Data != key)
        {
            prev = temp;
            temp = temp.Next;
        }

        if (temp == null)
            return;

        if (prev != null)
        {
            prev.Next = temp.Next;
        }
    }

    public void ReverseList()
    {
        Node? prev = null, next = null;
        var current = Head;

        while (current != null)
        {
            next = current.Next;
            current.Next = prev;
            prev = current;
            current = next;
        }

        Head = prev;
    }

    private bool isEmpty()
    {
        return Head is null;
    }

    private void printList()
    {
        var node = Head;
        while (node != null)
        {
            Console.Write($"{node.Data} ");
            node = node.Next;
        }
        Console.WriteLine();
    }

    public void Start()
    {
        var linkedList = new MySinglyLinkedList();
        linkedList.TopFront();
        linkedList.PopFront();
        linkedList.TopBack();
        linkedList.PopBack();
        linkedList.PushBack(1);
        linkedList.PushBack(2);
        linkedList.PushBack(3);
        linkedList.PushBack(4);
        linkedList.PushBack(5);

        Console.WriteLine($"{nameof(PushBack)} [1, 2, 3, 4, 5]:");
        linkedList.printList();

        linkedList.TopFront();
        linkedList.PopFront();
        linkedList.TopFront();
        linkedList.printList();
        linkedList.TopBack();
        linkedList.PopBack();
        linkedList.TopBack();
        linkedList.printList();

        linkedList.PushFront(6);
        Console.WriteLine($"{nameof(PushFront)} [6]:");
        linkedList.printList();

        linkedList.Erase(6);
        Console.WriteLine($"{nameof(Erase)} [6]:");
        linkedList.printList();

        linkedList.PushFront(6);
        Console.WriteLine($"{nameof(PushFront)} [6]:");
        linkedList.printList();

        linkedList.AddAfter(linkedList.Head, 7);
        Console.WriteLine($"{nameof(AddAfter)} head [7]:");
        linkedList.printList();
        linkedList.AddAfter(linkedList.Head, 12);
        Console.WriteLine($"{nameof(AddAfter)} head [12]:");
        linkedList.printList();

        linkedList.AddBefore(linkedList.Head.Next, 10);
        Console.WriteLine($"{nameof(AddBefore)} head.next [10]:");
        linkedList.printList();
        linkedList.AddBefore(linkedList.Head, 15);
        Console.WriteLine($"{nameof(AddBefore)} head [15]:");
        linkedList.printList();

        linkedList.Erase(2);
        Console.WriteLine($"{nameof(Erase)} [2]:");
        linkedList.printList();
        linkedList.Erase(4);
        Console.WriteLine($"{nameof(Erase)} [4]:");
        linkedList.printList();

        Console.WriteLine($"{nameof(Find)} [2]: {linkedList.Find(2)}");
        Console.WriteLine($"{nameof(Find)} [3]: {linkedList.Find(3)}");

        Console.WriteLine($"{nameof(ReverseList)}:");
        linkedList.ReverseList();
        linkedList.printList();
    }
}