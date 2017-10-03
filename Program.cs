using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupCSharp
{
    class Program
    {
        public static int CheckNums(string input)
        {
            int validatedInt = 0;

            while (!Int32.TryParse(input, out validatedInt))
            {
                Console.WriteLine("\nPlease enter a number\n");
                input = Console.ReadLine();
            }

            return validatedInt;
        }

        static void Main(string[] args)
        {
            string userInput = "";
            int menuChoice = 0;
            int subChoice = 0;
            Stack<string> myStack = new Stack<string>();
            Queue<string> myQueue = new Queue<string>();
            Dictionary<string, int> myDictionary = new Dictionary<string, int>();


            do
            {
                Console.WriteLine("1. Stack");
                Console.WriteLine("2. Queue");
                Console.WriteLine("3. Dictionary");
                Console.WriteLine("4. Exit\n");

                userInput = Console.ReadLine();
                menuChoice = CheckNums(userInput);
                Console.WriteLine();

                switch (menuChoice)
                {
                    case 1:
                        ManipulateStructure handleStack = new ManipulateStructure();
                        subChoice = 0;
                        while (subChoice != 7)
                        {
                            subChoice = handleStack.Menu("Stack");
                            handleStack.modifyStack(subChoice, ref myStack);
                        }
                        break;
                    case 2:
                        ManipulateStructure handleQueue = new ManipulateStructure();
                        subChoice = 0;
                        while (subChoice != 7)
                        {
                            subChoice = handleQueue.Menu("Queue");
                            handleQueue.modifyQueue(subChoice, ref myQueue);
                        }
                        break;
                    case 3:
                        ManipulateStructure handleDictionary = new ManipulateStructure();
                        subChoice = 0;
                        while (subChoice != 7)
                        {
                            subChoice = handleDictionary.Menu("Dictionary");
                            handleDictionary.modifyDictionary(subChoice, ref myDictionary);
                        }
                        break;
                    case 4:
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Please choose one of the menu options");
                        break;
                }

            } while (menuChoice != 4);
        }
    }
}
