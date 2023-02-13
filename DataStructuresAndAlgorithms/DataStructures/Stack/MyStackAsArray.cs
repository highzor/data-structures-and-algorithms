//push()      O(1)
//pop()       O(1)
//top()       O(1)

namespace DataStructuresAndAlgorithms.DataStructures.Stack;

public class MyStackAsArray
{
    private int[] stack;
    private int top;
    private int max;

    public MyStackAsArray(int size)
    {
        stack = new int[size];
        top = -1;
        max = size;
    }

    public MyStackAsArray() { }

    public void Push(int data)
    {
        if (isFull())
        {
            Console.WriteLine($"{nameof(Push)}: Stack overflow");
            return;
        }

        Console.WriteLine($"{nameof(Push)}: {data} is pushed to the stack");
        stack[++top] = data;
    }

    public void Top()
    {
        if (isEmpty())
        {
            Console.WriteLine("Stack is empty");
            return;
        }

        Console.WriteLine($"{nameof(Top)}: {stack[top]} is topped");
    }

    public void Pop()
    {
        if (isEmpty())
        {
            Console.WriteLine("Stack is empty");
            return;
        }

        Console.WriteLine($"{nameof(Pop)}: {stack[top--]} is popped");
    }

    private bool isEmpty()
    {
        return top < 1;
    }

    private bool isFull()
    {
        return top == max - 1;
    }

    private void printStack()
    {
        if (isEmpty())
        {
            Console.WriteLine($"{nameof(printStack)}: Stack is empty");
            return;
        }

        for (var i = 0; i <= top; i++)
        {
            Console.Write($"{stack[i]} ");
        }
        Console.WriteLine();
    }

    public void Start()
    {
        var stack = new MyStackAsArray(5);
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