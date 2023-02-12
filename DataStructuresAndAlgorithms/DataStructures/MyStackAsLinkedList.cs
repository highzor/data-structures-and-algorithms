//push()      O(1)
//pop()       O(1)
//top()       O(1)

namespace DataStructuresAndAlgorithms.DataStructures;

public class MyStackAsLinkedList
{
    StackNode? Root;
    public class StackNode 
    {
        public int Data;
        public StackNode? Next;

        public StackNode(int data)
        {
            Data = data;
        }
    }

    public void Push(int data)
    {
        var newNode = new StackNode(data);

        if (isEmpty())
        {
            Root = newNode;
            Console.WriteLine($"{nameof(Push)}: {Root.Data} is pushed to the stack");
            return;
        }

        var temp = Root;
        Root = newNode;
        newNode.Next = temp;

        Console.WriteLine($"{nameof(Push)}: {Root.Data} is pushed to the stack");
    }

    public void Top()
    {
        if (isEmpty())
        {
            Console.WriteLine($"{nameof(Top)}: Stack is empty");
            return;
        }

        Console.WriteLine($"{nameof(Top)}: {Root?.Data} is topped");
    }

    public void Pop()
    {
        if (isEmpty())
        {
            Console.WriteLine("Stack is empty");
            return;
        }

        Console.WriteLine($"{nameof(Pop)}: {Root?.Data} is popped");
        Root = Root?.Next;
    }

    private bool isEmpty()
    {
        return Root is null;
    }

    private void printStack()
    {
        var node = Root;
        while (node != null)
        {
            Console.Write($"{node.Data} ");
            node = node.Next;
        }
        Console.WriteLine();
    }

    public void Start()
    {
        var stack = new MyStackAsLinkedList();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        stack.Push(4);
        stack.Push(5);
        stack.printStack();
        stack.Top();
        stack.printStack();
        stack.Pop();
        stack.printStack();
        stack.Push(6);
        stack.Top();
        stack.printStack();
    }
}