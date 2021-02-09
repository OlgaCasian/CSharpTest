using System;
using System.IO;

namespace ConsoleAppSinglyLinkedList
{
    class Program
    {
        class Node
        {
            public int data;
            public Node next;

            public Node(int x)
            {
                data = x;
                next = null;
            }
        }
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

                while(pnode != null)
                {
                    for(int i=1; i<count+1; i++)
                    {
                        Console.WriteLine("Node" + i + ":" + pnode.data);
                        pnode = pnode.next;
                    }
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
            }         
        }

        static void Main(string[] args)
        {
             // Send the file path as a command line argument on execution
            if(args.Length != 0)
            {
                string inputPath = args[0];
            } 
            else 
            { 
                Console.WriteLine("Please provide the path to the file with node data:");
                string inputPath = Console.ReadLine();

                /* 
                 * TO DO: Check if inputPath have a correct and secure format
                 * * use Regex to validate the path
                 * * consider an alternative System.IO.Directory.Exists(path) method
                 * For now I assume the inputPath is right
                */

                FileStream TextFile = new FileStream(inputPath, FileMode.Open, FileAccess.Read, FileShare.Read);
                StreamReader TextReader = new StreamReader(TextFile);
                string content;           
                SinglyLinkedList newList = new SinglyLinkedList();

                while (!TextReader.EndOfStream)
                {
                    /*
                     * TO DO: remove blanc spaces before and between characters and set string to lowercase
                     */
                    content = TextReader.ReadLine();

                    if (content[0] == 'i')
                    {      
                        newList.InsertNodeToEnd(Int32.Parse((content.Substring(2)).ToString()));
                    } 
                    else if (content[0] == 'd')
                    {
                        newList.DeleteNode(Int32.Parse((content.Substring(2)).ToString()));

                    }
                    else
                    {
                        Console.WriteLine("\n!!!Please provide correct comand 'i' or 'd' in your data file");
                        return;
                    }
                }
                newList.PrintList();
                TextFile.Close();
            }
            /*
             * TO DO: Implement garbage collection for the memory
             */
        }
    }
}
