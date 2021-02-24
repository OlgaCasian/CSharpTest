using System;
using System.IO;

namespace ConsoleAppSinglyLinkedList
{
    partial class Program
    {

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
