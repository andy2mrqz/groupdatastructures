/*
 * Andrew Marquez, Evan McDaniel, Nick Trowbridge, Riley Wells
 * 
 * This program will prompt the user to run operations on stacks, queues, or dictionaries.  It prompts which data structure
 * the user would like to manipulate, then moves onto the ManipulateStructure.cs file to show menus with operations that can be
 * performed there.  Users can add items, display the contents, remove individual items, or clear the data structure completely.
 * It also can tell you how fast each data structure searches for a particular item.
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupCSharp
{
    class Program
    {
        //Ensures valid input of integers
        public static int CheckNums(string input)
        {
            int validatedInt = 0;

            /*If the input can be parsed to an integer, it outputs it and returns.
              If not, it prompts for a number */
            while (!Int32.TryParse(input, out validatedInt))
            {
                Console.WriteLine("\nPlease enter a number\n");
                input = Console.ReadLine();
            }

            return validatedInt;
        }

        static void Main(string[] args)
        {
            //Variable Declarations
            string userInput = "";
            int menuChoice = 0;
            int subChoice = 0;
            Stack<string> myStack = new Stack<string>();
            Queue<string> myQueue = new Queue<string>();
            Dictionary<string, int> myDictionary = new Dictionary<string, int>();


            do
            {
                //Display the menu
                Console.WriteLine("1. Stack");
                Console.WriteLine("2. Queue");
                Console.WriteLine("3. Dictionary");
                Console.WriteLine("4. Exit\n");

                //Get the menu choice from the user
                userInput = Console.ReadLine();
                menuChoice = CheckNums(userInput);
                Console.WriteLine();

                //Given the menu choice, a switch will show the menu for each data structure
                switch (menuChoice)
                {
                    case 1: //Stack
                        ManipulateStructure handleStack = new ManipulateStructure();
                        subChoice = 0;
                        //Remains in stack menu until they select to return to the main menu
                        while (subChoice != 7)
                        {
                            //Retrieves menu choice from the stack menu
                            subChoice = handleStack.Menu("Stack");
                            //Goes to that particular menu item for the stack manipulation
                            handleStack.modifyStack(subChoice, myStack);
                        }
                        break;
                    case 2: //Queue
                        ManipulateStructure handleQueue = new ManipulateStructure();
                        subChoice = 0;
                        //Remains in queue menu until they select to return to the main menu
                        while (subChoice != 7)
                        {
                            //Retrieves menu choice from the queue menu
                            subChoice = handleQueue.Menu("Queue");
                            //Goes to that particular menu item for the queue manipulation
                            handleQueue.modifyQueue(subChoice, myQueue);
                        }
                        break;
                    case 3: //Dictionary
                        ManipulateStructure handleDictionary = new ManipulateStructure();
                        subChoice = 0;
                        //Remains in dictionary menu until they select to return to the main menu
                        while (subChoice != 7)
                        {
                            //Retrieves menu choice from the dictionary menu
                            subChoice = handleDictionary.Menu("Dictionary");
                            //Goes to that particular menu item for the dictionary manipulation
                             handleDictionary.modifyDictionary(subChoice, myDictionary);
                        }
                        break;
                    case 4: //Exit
                        Console.WriteLine("Goodbye!");
                        break;
                    default: //Invalid menu number
                        Console.WriteLine("Please choose one of the menu options");
                        break;
                }

            } while (menuChoice != 4);
        }
    }
}
