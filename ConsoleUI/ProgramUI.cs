using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace ConsoleUI
{
    class ProgramUI
    {
        GreetingRepo Repo { get; set; }
        public ProgramUI(GreetingRepo GreetingRepo)
        {
            Repo = GreetingRepo;
        }
        public void Commands()
        {
            bool done = false;
            while (!done)
            {
                Console.WriteLine();
                Console.WriteLine("Welcome to the Komodo Insurance Greetings Manager!");
                Console.WriteLine("Type 'Help' for a list of commands");
                string commands = Console.ReadLine();
                if (commands == "Help" || commands == "help")
                {
                    Console.WriteLine("Type 'Add' to add a Greeting, Type 'Greeting' to modify a greeting, Type 'List' to see a list of all registered greetings, Type 'Done' to exit the program.");
                }
                else if (commands == "Add" || commands == "add")
                {
                    Console.WriteLine("Please provide the consumer's first name.");
                    string first = Console.ReadLine();
                    Console.WriteLine("Please provide the consumer's last name.");
                    string last = Console.ReadLine();
                    Console.WriteLine("Please type '1' if the consumer is a past customer, type '2' if the consumer is currently a customer, or type '3' if the consumer has never been a customer.");
                    int stat = int.Parse(Console.ReadKey().KeyChar.ToString());
                    GreetingPoco Greeting = new GreetingPoco(first, last, stat);
                    Repo.AddGreeting(Greeting);
                }
                else if (commands == "Greeting" || commands == "greeting")
                {
                    bool subDone = false;
                    while (!subDone)
                    {
                        Console.WriteLine("Type the id of the consumer you wish to modify, you can get ids from list view.");
                        int id = int.Parse(Console.ReadKey().KeyChar.ToString());
                        Console.WriteLine("Type 'Name' to change their name, 'Type' to change their relationship to Komodo Insurance, 'Remove' to delete a consumer, or 'Done' to return to the main menu.");
                        string comm = Console.ReadLine();
                        if (comm == "Name" || comm == "name")
                        {
                            Console.WriteLine("Type '1' to change their first name or '2' to change their last name");
                            int num = int.Parse(Console.ReadKey().KeyChar.ToString());
                            Console.WriteLine("Type the name you wish to change it to.");
                            string nombre = Console.ReadLine();
                            Repo.UpdateName(nombre, num, id);
                        }
                        else if (comm == "Done" || comm == "done")
                        {
                            subDone = true;
                        }
                        else if (comm == "Type" || comm == "type")
                        {
                            Console.WriteLine("Please type '1' if the consumer is a past customer, type '2' if the consumer is currently a customer, or type '3' if the consumer has never been a customer.");
                            int num = int.Parse(Console.ReadKey().KeyChar.ToString());
                        }
                        else if (comm == "Remove" || comm == "remove")
                        {
                            Console.WriteLine("Are you sure you want to remove " + Repo._Greetings[id].fullname + "?");
                            Console.WriteLine("Type 'Confirm' if so");
                            string confirm = Console.ReadLine();
                            if (confirm == "Confirm" || confirm == "confirm")
                            {
                                Repo.RemoveGreeting(id);
                            }
                        }

                    }
                }
                else if (commands == "List" || commands == "list")
                {

                    List<GreetingPoco> _Greetings = Repo.GetList();
                    string list = "";
                    for (int i = 0; i < _Greetings.Count; i++)
                    {
                        list += "ID: " + i + " Name: " + _Greetings[i].fullname + " Status: " + _Greetings[i].type + " Email: " + _Greetings[i].email;
                        Console.WriteLine(list);
                    }

                }
                else if (commands == "Done" || commands == "done")
                {
                    done = true;
                }
            }
        }
    }
}
