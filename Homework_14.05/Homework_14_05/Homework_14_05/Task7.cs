using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Homework_14_05
{
    public class Task7
    {

        /// <summary>
        /// Task 7a
        /// </summary>
        public void FindSubstring()
        {
            string data = "blalbalтекст123пкушу";
            var regex = new Regex(@"(\w*\d*)");
            MatchCollection matches = regex.Matches(data);
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                    Console.WriteLine(match.Value);
            }
        }

        /// <summary>
        /// Task 7b
        /// </summary>
        public void ValidatePassword()
        {
            string password = "Pas1word";
            string validationRule = @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$";
            if (Regex.IsMatch(password, validationRule))
                Console.WriteLine("Password is valid");
            else
                Console.WriteLine("Password invalid");

        }

        /// <summary>
        /// Task 7c
        /// </summary>
        public void ValidatePostCode()
        {
            string code = "123-456";
            if (Regex.IsMatch(code, @"\d{3}-\d{3}"))
                Console.WriteLine("Code is valid");
            else
                Console.WriteLine("Code is invalid");
        }

        /// <summary>
        /// Task 7d
        /// </summary>
        public void ValidatePhoneNumber()
        {
            if (Regex.IsMatch("+380-98-123-45-67", @"\d{3}-\d{2}-\d{3}-\d{2}-\d{2}"))
                Console.WriteLine("Phone is valid");
            else
                Console.WriteLine("Phone is invalid");
        }

        /// <summary>
        /// Task 7e
        /// </summary>
        public void ReplacePhoneNumbers()
        {
            string number = "+380-98-123-45-67";
            string replaceWith = "XXX";
            var regex = new Regex(@"\d+");
            Console.WriteLine(regex.Replace(number, replaceWith));
        }
    }
}

