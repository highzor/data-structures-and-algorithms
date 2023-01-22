﻿//Singly - Linked List
//                     no tail | with tail

//PushFront(Key)         O(1)
//TopFront()             O(1)
//PopFront()             O(1)
//PushBack(Key)          O(n)      O(1)
//TopBack()              O(n)      O(1)
//PopBack()              O(n)
//Find(Key)              O(n)
//Erase(Key)             O(n)
//Empty()                O(1)
//AddBefore(Node, Key)   O(n)
//AddAfter(Node, Key)    O(1)

namespace DataStructuresAndAlgorithms.DataStructures;
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

    public void PushAfter(Node prevNode, int data)
    {
        if (prevNode == null)
        {
            Console.WriteLine("prevNode can't be null");
            return;
        }

        var newNode = new Node(data);
        newNode.Next = prevNode.Next;
        prevNode.Next = newNode;
    }

    public bool Search(int key)
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

    public void Delete(int key)
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
        linkedList.PushBack(1);
        linkedList.PushBack(2);
        linkedList.PushBack(3);

        Console.WriteLine($"PushBack [1, 2, 3]:");
        linkedList.printList();

        linkedList.PushFront(4);

        Console.WriteLine($"PushFront [4]:");
        linkedList.printList();

        linkedList.PushAfter(linkedList.Head, 7);
        Console.WriteLine($"PushAfter head [7]:");
        linkedList.printList();

        linkedList.Delete(2);
        Console.WriteLine($"Delete [2]:");
        linkedList.printList();

        Console.WriteLine($"Search [2]: {linkedList.Search(2)}");
        Console.WriteLine($"Search [3]: {linkedList.Search(3)}");
    }
}

