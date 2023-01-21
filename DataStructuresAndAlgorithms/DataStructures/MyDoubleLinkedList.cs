//Doubly - Linked List
//                     no tail | with tail

//PushFront(Key)         O(1)
//TopFront()             O(1)
//PopFront()             O(1)
//PushBack(Key)          O(n)      O(1)
//TopBack()              O(n)      O(1)
//PopBack()              O(n)      O(1)
//Find(Key)              O(n)
//Erase(Key)             O(n)
//Empty()                O(1)
//AddBefore(Node, Key)   O(n)      O(1)
//AddAfter(Node, Key)    O(1)

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.DataStructures;

public class LinkedListEnumerator<T> : IEnumerator<T>
{
    private Node<T> current;

    public LinkedListEnumerator(Node<T> current)
    {
        this.current = current;
    }

    public T Current => current.Data;

    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
        if (current == null) return false;
        current = current.Next;
        return (current != null);
    }

    public void Dispose()
    {

    }

    public void Reset()
    {
        throw new NotImplementedException();
    }
}
public class Node<T>
{
    public Node<T> Next;
    public Node<T> Prev;
    public T Data;

    public Node(T value)
    {
        Next = null;
        Prev = null;
        Data = value;
    }
}

public class MyDoubleLinkedList<T> : IEnumerable<T>
{
    public Node<T> Head;

    public MyDoubleLinkedList()
    {
        Head = new Node<T>(default(T));
    }

    public void InsertFront(MyDoubleLinkedList<T> linkedList, T data)
    {
        var newNode = new Node<T>(data);
        newNode.Next = linkedList.Head.Next;
        newNode.Prev = linkedList.Head;

        if (linkedList.Head != null)
        {
            linkedList.Head.Next.Prev = newNode;
        }

        linkedList.Head.Next = newNode;
    }

    public void InsertLast(MyDoubleLinkedList<T> linkedList, T data)
    {
        var newNode = new Node<T>(data);

        if (linkedList.Head == null)
        {
            newNode.Prev = null;
            linkedList.Head = newNode;
            return;
        }

        var lastNode = getLastNode(linkedList);
        lastNode.Next = newNode;
        newNode.Prev = lastNode;
    }

    public void InsertAfter(Node<T> node, T data)
    {
        if (node == null)
        {
            Console.WriteLine("error, node can't be null");
            return;
        }

        var newNode = new Node<T>(data);
        newNode.Next = node.Next;
        newNode.Prev = node;
        node.Next = newNode;
        if (newNode.Next != null)
        {
            newNode.Next.Prev = newNode;
        }
    }

    public void DeleteNodebyKey(MyDoubleLinkedList<T> linkedList, T key)
    {
        var temp = linkedList.Head;

        if (temp != null && (temp.Data != null ? !temp.Data.Equals(key) : false))
        {
            linkedList.Head = temp.Next;
            linkedList.Head.Prev = null;
        }

        while (temp != null && (temp.Data != null ? !temp.Data.Equals(key) : true))
        {
            temp = temp.Next;
        }

        if (temp == null)
            return;

        if (temp.Next != null)
        {
            temp.Next.Prev = temp.Prev;
        }

        if (temp.Prev != null)
        {
            temp.Prev.Next = temp.Next;
        }
    }

    public static void StartMyDoubleLinkedList()
    {
        var linkedList = new MyDoubleLinkedList<string>();
        linkedList.InsertLast(linkedList, "apple");
        linkedList.InsertLast(linkedList, "mango");
        linkedList.InsertLast(linkedList, "peach");
        linkedList.InsertLast(linkedList, "orange");
        linkedList.InsertLast(linkedList, "banana");

        Console.WriteLine($"{nameof(linkedList.InsertLast)} result:");
        linkedList.ToList().ForEach(i => Console.WriteLine($"{i}"));
        Console.WriteLine("________");

        linkedList.InsertFront(linkedList, "grapes");
        Console.WriteLine($"{nameof(linkedList.InsertFront)} 'grapes' result:");
        linkedList.ToList().ForEach(i => Console.WriteLine($"{i}"));
        Console.WriteLine("________");

        var node = linkedList.getNodeByKey(linkedList, "orange");
        linkedList.InsertAfter(node, "potato");
        Console.WriteLine($"{nameof(linkedList.InsertAfter)} 'potato' after 'orange' result:");
        linkedList.ToList().ForEach(i => Console.WriteLine($"{i}"));
        Console.WriteLine("________");

        linkedList.DeleteNodebyKey(linkedList, "potato");
        Console.WriteLine($"{nameof(linkedList.DeleteNodebyKey)} 'potato' result:");
        linkedList.ToList().ForEach(i => Console.WriteLine($"{i}"));
        Console.WriteLine("________");
    }

    private Node<T> getLastNode(MyDoubleLinkedList<T> linkedList)
    {
        var temp = linkedList.Head;
        while (temp.Next != null)
        {
            temp = temp.Next;
        }

        return temp;
    }

    private Node<T> getNodeByKey(MyDoubleLinkedList<T> linkedList, T key)
    {
        var temp = linkedList.Head;
        while (temp != null && (temp.Data != null ? !temp.Data.Equals(key) : true))
        {
            temp = temp.Next;
        }

        return temp;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new LinkedListEnumerator<T>(Head);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    bool Compare<T>(T x, T y) where T : class
    {
        return x == y;
    }
}
