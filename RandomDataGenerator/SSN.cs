/**       
 *--------------------------------------------------------------------
 * 	   File name: SSN.cs
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
    public class SSN
    {
        public string Number { get; init; }

        public SSN()
        {
            Number = InvalidSSN();
        }

        public string InvalidSSN()
        {
            // SSN has three sets of digits. Format is XXX-XX-XXXX

            // To store value
            string invalidSocial = "";
            Random rand = new Random();

            // First three digits
            string nineHundreds = rand.Next(900, 1000).ToString();
            var firstDigits = new string[] { "000", "666", nineHundreds};

            // Creating invalid SSN groups according to https://secure.ssa.gov/poms.nsf/lnx/0110201035
            string areaNumber = firstDigits[rand.Next(3)];
            string groupNumber = "00";
            string serialNumber = "0000";

            invalidSocial = string.Concat(areaNumber, groupNumber, serialNumber);
            return invalidSocial;
        }

        public override string ToString()
        {
            string ssn = Number;
            ssn = ssn.Insert(3, "-");
            ssn = ssn.Insert(6, "-");

            return ssn;
        }
    }
}
