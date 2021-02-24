using System;

namespace ConsoleAppSinglyLinkedList
{
    partial class Program
    {
        class SinglyLinkedList
        {
            int count;
            Node head;

            public SinglyLinkedList()
            {
                head = null;
                count = 0;
            }

            public void InsertNodeToEnd(int data)
            {
                Node node = new Node(data);
                count++;
                if (head == null)
                {
                    head = node;
                    return;
                }
                Node last = head;
                
                while (last.next != null)
                {
                    last = last.next;
                }
                last.next = node;
                count++;

            }
            public void PrintList()
            {
                Node pnode = head;

                    for(int i=1; i<count+1; i++)
                    {
                        Console.WriteLine("Node" + i + ":" + pnode.data);
                        pnode = pnode.next;
                    }
            }
            public void DeleteNode(int key)
            {
                Node temp = head;
                Node prev = null;

                if (temp != null && temp.data == key)
                {
                    head = temp.next; 
                    return;

                }
                while (temp != null && temp.data != key)
                {
                    prev = temp;
                    temp = temp.next;
                }
                if (temp == null)
                {
                    return;
                }
                prev.next = temp.next;
                count--;
            }         
        }
    }
}
