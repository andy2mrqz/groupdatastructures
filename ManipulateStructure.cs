using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupCSharp
{
    class ManipulateStructure
    {
        public ManipulateStructure()
        {
        }

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

                userInput = Console.ReadLine();
                menuChoice = Program.CheckNums(userInput);
                Console.WriteLine();

                if (menuChoice >= 1 && menuChoice <= 7)
                {
                    return menuChoice;
                }
                else
                {
                    Console.WriteLine("Please choose one of the menu options");
                }

            } while (menuChoice != 7);

            return 0;
        }

        private string item = "";

        public string ToAdd()
        {
            string item = "";
            Console.WriteLine("Which item would you like to add?");
            item = Console.ReadLine();
            Console.WriteLine();
            return item;
        }

        public string ToDelete()
        {
            string item = "";
            Console.WriteLine("Which item would you like to delete?");
            item = Console.ReadLine();
            Console.WriteLine();
            return item;
        }

        public void Clear()
        {

        }

        public void Search()
        {

        }

        public void modifyStack(int operation, ref Stack<string> stack)
        {
            switch (operation)
            {
                case 1:
                    item = ToAdd();
                    stack.Push(item);
                    break;
                case 2:
                    stack.Clear();
                    for (int i = 1; i <= 2000; i++)
                    {
                        stack.Push("New Entry " + i);
                    }
                    break;
                case 3:
                    foreach (string value in stack)
                    {
                        Console.WriteLine(value);
                    }
                    Console.WriteLine();
                    break;
                case 4:
                    item = ToDelete();
                    if (stack.Contains(item))
                    {
                        Stack<string> newStack = new Stack<string>();
                        for (int numItems = 0; numItems < (stack.Count - 1); numItems++)
                        {
                            if (stack.Peek() != item)
                            {
                                newStack.Push(stack.Pop());
                            }
                            else
                            {
                                stack.Pop();
                            }
                        }
                        stack = newStack;
                    } else
                    {
                        Console.WriteLine("Your stack does not contain that item!!");
                    }
                    break;
                case 5:
                    stack.Clear();
                    break;
                case 6:
                    Search();
                    break;
            }
        }

        public void modifyQueue(int operation, ref Queue<string> queue)
        {
            switch (operation)
            {
                case 1:
                    item = ToAdd();
                    queue.Enqueue(item);
                    break;
                case 2:
                    queue.Clear();
                    for (int i = 1; i <= 2000; i++)
                    {
                        queue.Enqueue("New Entry " + i);
                    }
                    break;
                case 3:
                    foreach (string value in queue)
                    {
                        Console.WriteLine(value);
                    }
                    Console.WriteLine();
                    break;
                case 4:
                    item = ToDelete();
                    if (queue.Contains(item))
                    {
                        
                    } else
                    {
                        Console.WriteLine("Your queue does not contain that item!!");
                    }
                    break;
                case 5:
                    queue.Clear();
                    break;
                case 6:
                    Search();
                    break;
            }
        }

        public void modifyDictionary(int operation, ref Dictionary<string, int> dictionary)
        {
            switch (operation)
            {
                case 1:
                    item = ToAdd();
                    dictionary.Add(item, 1);
                    break;
                case 2:
                    dictionary.Clear();
                    for (int i = 1; i <= 2000; i++)
                    {
                        dictionary.Add("New Entry " + i, i);
                    }
                    break;
                case 3:
                    foreach (KeyValuePair<string, int> pair in dictionary)
                    {
                        Console.WriteLine(pair.Key);
                    }
                    Console.WriteLine();
                    break;
                case 4:
                    item = ToDelete();
                    if (dictionary.ContainsKey(item))
                    {
                        dictionary.Remove(item);
                    } else
                    {
                        Console.WriteLine("Your dictionary does not contain that item!!");
                    }
                    break;
                case 5:
                    dictionary.Clear();
                    break;
                case 6:
                    Search();
                    break;
            }
        }
    }
}
