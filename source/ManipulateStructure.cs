/*
 * Andrew Marquez, Evan McDaniel, Nick Trowbridge, Riley Wells
 * 
 * This program receivs information from Program.cs, which will prompt the user to run operations on stacks, queues, or dictionaries.
 * It also prompts which data structure the user would like to manipulate, then moves on to this file to show menus with operations that
 * can be performed.  Users can add items, display the contents, remove individual items, or clear the data structure completely.
 * It also can tell you how fast each data structure searches for a particular item.
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace GroupCSharp
{
    class ManipulateStructure
    {
        //Constructor method to instantiate the object
        public ManipulateStructure()
        {
        }

        //Shows the menu and uses the "type" parameter to be specific about which data structure we are working with
        public int Menu(string type)
        {
            string userInput = "";
            int menuChoice = 0;

            do
            {
                Console.WriteLine("1. Add one item to " + type);
                Console.WriteLine("2. Add Huge List of Items to " + type);
                Console.WriteLine("3. Display " + type);
                Console.WriteLine("4. Delete from " + type);
                Console.WriteLine("5. Clear " + type);
                Console.WriteLine("6. Search " + type);
                Console.WriteLine("7. Return to Main Menu\n");

                //Get the menu choice from the user
                userInput = Console.ReadLine();
                menuChoice = Program.CheckNums(userInput);
                Console.WriteLine();

                //Returns the menu choice to Program.cs so it can call the appropriate manipulation method
                if (menuChoice >= 1 && menuChoice <= 7)
                {
                    return menuChoice;
                }
                //Makes sure a valid menu option is pressed
                else
                {
                    Console.WriteLine("Please choose one of the menu options");
                }

            } while (menuChoice != 7);

            //This will never get used, but the method is type "int" so all code paths must return a value
            return 0;
        }

        private string item = "";

        //This method prompts for items the user would like to add to a data structure
        public string ToAdd()
        {
            string sToAdd;
            Console.WriteLine("Which item would you like to add?");
            sToAdd = Console.ReadLine();
            Console.WriteLine();
            return sToAdd;
        }

        //This method prompts for items the user would like to delete from a data structure
        public string ToDelete()
        {
            string sToDelete;
            Console.WriteLine("Which item would you like to delete?");
            sToDelete = Console.ReadLine();
            Console.WriteLine();
            return sToDelete;
        }

        /*All manipulations for the stack structure are contained in a switch here.
          It receives the data structure and the menu choice that was selected above */
        public void modifyStack(int operation, Stack<string> stack)
        {
            switch (operation)
            {
                case 1:  //Add an item
                    item = ToAdd();
                    stack.Push(item);
                    break;
                case 2: //Add a huge list of items
                    stack.Clear();
                    for (int i = 1; i <= 2000; i++)
                    {
                        stack.Push("New Entry " + i);
                    }
                    break;
                case 3: //Display the contents of the stack
                    foreach (string value in stack)
                    {
                        Console.WriteLine(value);
                    }
                    Console.WriteLine();
                    break;
                case 4: //Remove an item from the stack

                    item = ToDelete();

                    //If the stack does not contain the item, let the user know
                    if (!stack.Contains(item))
                    {
                        Console.WriteLine("Your stack does not contain this item, so it couldn't be removed!");
                        break;
                    }

                    //Make a new stack to store the popped-off values, and a string to hold the items as they are popped off
                    Stack<string> tempStack = new Stack<string>();
                    string tempValue = "";

                    //Runs through the stack.  Pushes the item to the new stack if it's not to be removed, otherwise, it's popped off and gone 4ever
                    for (int i = 0; i < stack.Count; i++)
                    {
                        tempValue = stack.Pop();
                        
                        if (tempValue != item)
                        {
                            tempStack.Push(tempValue);
                        }
                    }
                    //Readds the values from the temporary stack to the original stack
                    for (int j = 0; j < tempStack.Count; j++)
                    {
                        stack.Push(tempStack.Pop());
                    }

                    break;

                case 5: //Clear the stack
                    stack.Clear();
                    break;

                case 6: //Search for an item and display the amount of time taken to find it (or not find it)
                    
                    //Prompt for item to find
                    Console.WriteLine("Please enter value to search for:");
                    string sSearchStackFor = Console.ReadLine();

                    //Make and start a stopwatch
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    
                    //Ask if the stack contains the item to search for
                    if (stack.Contains(sSearchStackFor))
                    {
                        sw.Stop();  //Stop the stopwatch, then display the time it took in nanoseconds
                        Console.WriteLine("\r\nStack DOES contain " + sSearchStackFor);
                        Console.WriteLine("Time to search: " + sw.Elapsed.TotalMilliseconds * 1000000 + " nanoseconds");
                        Console.WriteLine("\r\nPress any key to continue.");
                        Console.ReadKey();
                    }
                    else
                    {
                        sw.Stop();  //Stop the stopwatch, then display the time it took in nanoseconds
                        Console.WriteLine("\r\nStack does NOT contain " + sSearchStackFor);
                        Console.WriteLine("Time to search: " + sw.Elapsed.TotalMilliseconds * 1000000 + " nanoseconds");
                        Console.WriteLine("\r\nPress any key to continue.");
                        Console.ReadKey();
                    }
                    break;
            }
        }

        /*All manipulations for the queue structure are contained in a switch here.
          It receives the data structure and the menu choice that was selected above */
        public void modifyQueue(int operation, Queue<string> queue)
        {
            switch (operation)
            {
                case 1: //Add an item
                    item = ToAdd();
                    queue.Enqueue(item);
                    break;
                case 2:  //Add a huge list of items
                    queue.Clear();
                    for (int i = 1; i <= 2000; i++)
                    {
                        queue.Enqueue("New Entry " + i);
                    }
                    break;
                case 3: //Display the contents of the queue
                    foreach (string value in queue)
                    {
                        Console.WriteLine(value);
                    }
                    Console.WriteLine();
                    break;
                case 4:  //Remove an item from the queue

                    item = ToDelete();

                    //Checks if the item is in the queue
                    if (queue.Contains(item))
                    {
                        //Makes a temporary queue to store the values
                        Queue<string> qHoldQue = new Queue<string>();

                        //Runs through the queue and dequeues the item if it matches the item to remove
                        while (queue.Count > 0)
                        {
                            if (queue.Peek() == item)
                            {
                                queue.Dequeue();
                                break;
                            }
                            qHoldQue.Enqueue(queue.Dequeue());
                        }

                        //Adds the items back onto the queue at the end
                        while (qHoldQue.Count > 0)
                        {
                            queue.Enqueue(qHoldQue.Dequeue());
                        }
                    }
                    else
                    {
                        Console.WriteLine("Your queue does not contain that item!!\n");
                    }
                    break;
                case 5:  //Clear the queue
                    queue.Clear();
                    break;
                case 6:  //Search for an item and display the amount of time to find it (or not)

                    //Get item to search for
                    Console.WriteLine("Please enter key to search for:");
                    string sSearchQueueFor = Console.ReadLine();

                    //Make and start a stopwatch
                    Stopwatch sw = new Stopwatch();
                    sw.Start();

                    //Ask if the stack contains the item to search for
                    if (queue.Contains(sSearchQueueFor))
                    {
                        sw.Stop(); //Stop the stopwatch and display the search time in nanoseconds
                        Console.WriteLine("\r\nQueue DOES contain " + sSearchQueueFor);
                        Console.WriteLine("Time to search: " + sw.Elapsed.TotalMilliseconds * 1000000 + " nanoseconds");
                        Console.WriteLine("\r\nPress any key to continue.");
                        Console.ReadKey();
                    }
                    else
                    {
                        sw.Stop(); //Stop the stopwatch and display the search time in nanoseconds
                        Console.WriteLine("\r\nQueue does NOT contain " + sSearchQueueFor);
                        Console.WriteLine("Time to search: " + sw.Elapsed.TotalMilliseconds * 1000000 + " nanoseconds");
                        Console.WriteLine("\r\nPress any key to continue.");
                        Console.ReadKey();
                    }
                    break;
            }
        }

        /*All manipulations for the queue structure are contained in a switch here.
          It receives the data structure and the menu choice that was selected above */
        public void modifyDictionary(int operation, Dictionary<string, int> dictionary)
        {
            switch (operation)
            {
                case 1:  //Add an item to the dictionary
                    item = ToAdd();
                    dictionary.Add(item, 1);
                    break;

                case 2:  //Add a huge list of items to the dictionary
                    dictionary.Clear();
                    for (int i = 1; i <= 2000; i++)
                    {
                        dictionary.Add("New Entry " + i, i);
                    }
                    break;

                case 3:  //Display the contents of the dictionary
                    foreach (KeyValuePair<string, int> pair in dictionary)
                    {
                        Console.WriteLine(pair.Key);
                    }
                    Console.WriteLine();
                    break;

                case 4: //Delete an item from the dictionary
                    
                    //Get the item to delete
                    item = ToDelete();

                    //Check if the dictionary contains the item
                    if (dictionary.ContainsKey(item))
                    {
                        dictionary.Remove(item); //Remove it
                    }
                    else //Say it doesn't contain it
                    {
                        Console.WriteLine("Your dictionary does not contain that item!!");
                    }
                    break;

                case 5: //Clear the whole thing
                    dictionary.Clear();
                    break;

                case 6: //Search for an item and return if it was found and the elapsed time
                    
                    Console.WriteLine("Please enter key to search for:");
                    string sSearchDictionaryFor = Console.ReadLine();

                    //Make and start a stopwatch
                    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                    sw.Start();

                    //Ask if the dictionary  contains the item to search for
                    if (dictionary.ContainsKey(sSearchDictionaryFor))
                    {
                        sw.Stop();  //Stop the stopwatch and display the search time in nanoseconds
                        Console.WriteLine("\r\nDictionary DOES contain " + sSearchDictionaryFor);
                        Console.WriteLine("Time to search: " + sw.Elapsed.TotalMilliseconds*1000000 + " nanoseconds");
                        Console.WriteLine("\r\nPress any key to continue.");
                        Console.ReadKey();
                    }
                    else
                    {
                        sw.Stop();  //Stop the stopwatch and display the search time in nanoseconds
                        Console.WriteLine("\r\nDictionary does NOT contain " + sSearchDictionaryFor);
                        Console.WriteLine("Time to search: " + sw.Elapsed.TotalMilliseconds * 1000000 + " nanoseconds");
                        Console.WriteLine("\r\nPress any key to continue.");
                        Console.ReadKey();
                    }
                    break;
            }
        }
    }
}
