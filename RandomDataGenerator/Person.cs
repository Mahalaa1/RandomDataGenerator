/**       
 *--------------------------------------------------------------------
 * 	   File name: Person.cs
 * 	Project name: RandomDataGenerator
 *--------------------------------------------------------------------
 * Author’s name and email:	 Austin Mahala, mahalaa1@etsu.edu
 *          Course-Section:  CSCI-2910-970
 *           Creation Date:	 5-20-2023
 * -------------------------------------------------------------------
 */


using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace RandomDataGenerator
{
    public class Person
    {
        // Fields
        private string[] _arrayOfFirstNames = { "Bob", "Bill", "Anthony", "Sue", "Sally", "John", "Jill", "Adam", "Thomas", "Jim" };
        private Dependent[] _dependents = new Dependent[10];
        private string _firstName;
        private string _lastName;
        private DateTime _birthDate;
        private SSN _ssn;
        private Phone phone;

        // Properties

        // Init works similarly to the set keyword, but it is a safer way to create immutable objects.
        public string FirstName { get ; init; }

        public string LastName { get; init; }

        public DateTime BirthDate { get; init; }
        
        public SSN SSN { get; init; }

        public Phone Phone { get; init; }

        public Dependent Dependent { get; init; }
       

        // Constructor
        public Person() 
        {

            Random rand = new Random();

            // Name --------------------------------------------------------------------------------------

            // Random first names from the array
            FirstName = _arrayOfFirstNames[rand.Next(_arrayOfFirstNames.Length)];

            // Assigning a last name from the LastName enum
            var lastNameArray = RandomDataGenerator.LastName.GetValues(typeof(LastName));
            var generatedLastName = (LastName)lastNameArray.GetValue(rand.Next(lastNameArray.Length));
            LastName = generatedLastName.ToString();

            // End of name -------------------------------------------------------------------------------



            // Age ----------------------------------------------------------------------------------

            int ageinDays = rand.Next(6570, 29220);
            TimeSpan age = new TimeSpan(ageinDays, 0, 0, 0);
            DateTime currentDate = DateTime.Now;
            BirthDate = currentDate.Subtract(age);

            // End of Age --------------------------------------------------------------------------


            // Retrieves random invalid social security number
            SSN = new SSN();

            // Retrieves random numbers in phone number format
            Phone = new Phone();

            // Retrieves dependent information
            // Dependent child = new Dependent();
            // AddDependent(child);
        }

        // Gives the age of the person in years
        public int Age()
        {
            TimeSpan yearsOfAge = DateTime.Now - BirthDate;
            return yearsOfAge.Days / 365;
        }

        public void AddDependent(Dependent dependent)
        {
            _dependents[1] = dependent;
        }

        public override string ToString()
        {
            string msg = "";
            msg += $"-----------------------------------------\n";
            msg += $"Name:\t\t {FirstName} {LastName}\n";
            msg += $"BirthDate:\t {BirthDate.ToShortDateString()}\n";
            msg += $"Age:\t\t {Age()}\n";
            msg += $"SSN:\t\t {SSN} \n";
            msg += $"Phone Number:\t {Phone}\n";
            msg += $"Dependents:\t {_dependents[1].FirstName}\n";
            msg += $"-----------------------------------------\n\n";

            return msg;
        }
    }
}
