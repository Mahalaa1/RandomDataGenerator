/**       
 *--------------------------------------------------------------------
 * 	   File name: Program.cs
 * 	Project name: RandomDataGenerator
 *--------------------------------------------------------------------
 * Author’s name and email:	 Austin Mahala, mahalaa1@etsu.edu
 *          Course-Section:  CSCI-2910-970
 *           Creation Date:	 5-20-2023
 * -------------------------------------------------------------------
 */

using System;
using System.Linq.Expressions;

namespace RandomDataGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            List<Person> people = new List<Person>();
            
            do
            {
                Console.WriteLine("Select an option from the menu by entering the number next to the desired option.\n");
                Console.WriteLine("1: Create a Person object.");
                Console.WriteLine("2: Display all people objects that have been created.");
                Console.WriteLine("3: Remove a Person object from the list.");
                Console.WriteLine("4: Get a random last name to display.");
                Console.WriteLine("5: Get and display a random SSN.");
                Console.WriteLine("6: Get a random phone number and display it.");

                int userMenu = int.Parse(Console.ReadLine());

                switch (userMenu)
                {
                    case 1:
                        people.Add(new Person());
                        break;

                    case 2:
                        foreach (Person person in people)
                        {
                            person.AddDependent(new Dependent());
                            Console.WriteLine(person);
                        }
                        break;

                    case 3:
                        if (people.Count == 0)
                        {
                            Console.WriteLine("You have no data to remove. You must create people before you can remove one.");
                        }
                        else
                        {
                            Remove(people);
                        }
                        break;

                    case 4:
                        Random lastName = new Random();
                        Console.WriteLine((LastName)lastName.Next(Enum.GetNames(typeof(LastName)).Length));
                        break;

                    case 5:
                        Random personSSN = new Random();
                        Person randomSSN = people[personSSN.Next(people.Count())];
                        Console.WriteLine(randomSSN.SSN);
                        break;

                    case 6:
                        Console.WriteLine("Choose a separator");
                        string seperator = Console.ReadLine();
                        Phone randomPhone = new Phone();
                        string[] words = randomPhone.ToString().Split('-');
                        Console.WriteLine($"{words[0]}{seperator}{words[1]}{seperator}{words[2]}");
                        break;

                    case 0:
                        exit = true;
                        Console.WriteLine("Thank you for using RandomDataGenerator!");
                        System.Environment.Exit(0);
                        break;
                }
                    
            } 
            while (exit == false);
        }

        // For option 3
        private static void Remove(List<Person> list)
        {
            Console.WriteLine("Who would you like to remove?");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {list[i].FirstName} {list[i].LastName}");
            }

            Console.Write("Remove Number: ");
            int numToRemove = int.Parse(Console.ReadLine());
            list.RemoveAt(numToRemove - 1);
        }
    }
}