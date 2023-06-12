/**       
 *--------------------------------------------------------------------
 * 	   File name: Phone.cs
 * 	Project name: RandomDataGenerator
 *--------------------------------------------------------------------
 * Author’s name and email:	 Austin Mahala, mahalaa1@etsu.edu
 *          Course-Section:  CSCI-2910-970
 *           Creation Date:	 5-20-2023
 * -------------------------------------------------------------------
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomDataGenerator
{
    public class Phone
    {
        public string Number { get; init; }

        public Phone(char separator = '-')
        {
            Number = Format();
        }

        public string Format(char separator = '-')
        {
            string completeNumber = "";
            int[] randomDigits = new int[10];
            Random randomPhone = new Random();
            
            // Filling with random digits
            for(int i = 0; i < randomDigits.Length; i++)
            {
                randomDigits[i] = randomPhone.Next(10);
            }

            // Phone number cannot begin with zero or one. Defaults to a value between 2 and 10
            if(randomDigits[0] == 0 || randomDigits[0] == 1) 
            {
                randomDigits[0] = randomPhone.Next(2, 10);
            }

            foreach(int i in randomDigits)
            {
                completeNumber = completeNumber + i;
            }

            completeNumber = completeNumber.Insert(3, separator.ToString()).Insert(7, separator.ToString());

            return completeNumber;
        }

        public override string ToString()
        {
            return Number;
        }
    }
}
