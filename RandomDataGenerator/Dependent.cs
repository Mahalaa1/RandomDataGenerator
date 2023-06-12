using System;
using System.Collections.Generic;
using System.Linq;
/**       
 *--------------------------------------------------------------------
 * 	   File name: Dependent.cs
 * 	Project name: RandomDataGenerator
 *--------------------------------------------------------------------
 * Author’s name and email:	 Austin Mahala, mahalaa1@etsu.edu
 *          Course-Section:  CSCI-2910-970
 *           Creation Date:	 5-20-2023
 * -------------------------------------------------------------------
 */

using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RandomDataGenerator
{
    public class Dependent : Person
    {
        public Dependent() : base()
        {
            Random rand = new Random();
            int ageinDays = rand.Next(0, 3650);
            TimeSpan age = new TimeSpan(ageinDays, 0, 0, 0);
            DateTime currentDate = DateTime.Now;
            BirthDate = currentDate.Subtract(age);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
