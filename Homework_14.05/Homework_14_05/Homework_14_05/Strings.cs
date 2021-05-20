using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Homework_14_05
{
    public class Strings
    {
        public Task7 Task7 { get; set; }

        public Strings()
        {
            Task7 = new Task7();
        }
        /// <summary>
        /// Task 1
        /// </summary>
        public void PrintNumbersInAString(string value)
        {
            foreach (var symbol in value)
                if (Char.IsDigit(symbol))
                    Console.WriteLine(symbol);
        }

        /// <summary>
        /// Task 2
        /// </summary>
        public void RoundToTwoAfterComa(double firstNumber, double secondNumber) => Console.WriteLine(Math.Round((firstNumber / secondNumber), 2).ToString());

        /// <summary>
        /// Task 3
        /// </summary>
        public void ReadNumberFromAConsole()
        {
            Console.WriteLine("Write some number");
            string raw = Console.ReadLine();
            int converted = 0;
            try
            {
                converted = Int32.Parse(raw);
                Console.WriteLine(converted);
            }
            catch (Exception)
            {
                var regex = Regex.Match(raw, @"(\d+),(\d+)(\w{1})(\d+)");
                Console.WriteLine($"The number you wrote is {regex.Groups[1]},{regex.Groups[2]}*10^{regex.Groups[4]}");
            }


        }

        /// <summary>
        /// Task 4
        /// </summary>
        public void ReadDateAndTimeISO8601()
        {
            Console.WriteLine(DateTime.UtcNow.ToString("O", CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Task 5
        /// </summary>
        public void ParseTheDate()
        {
            string value = @"2016 21-07";
            var regex = Regex.Match(value, @"(\d{4})(\s)(\d+)-(\d+)");
            var dt = new DateTime(int.Parse(regex.Groups[1].Value), int.Parse(regex.Groups[4].Value), int.Parse(regex.Groups[3].Value));
            Console.WriteLine(dt);
        }

        /// <summary>
        /// Task 6
        /// </summary>
        public void CountTheSum()
        {
            string value = "5,6,7,8,9";
            var arr = value.Split(',');
            int sum = 0;
            foreach (var num in arr)
                sum += int.Parse(num);
            Console.WriteLine(sum);

        }

        /// <summary>
        /// Task 8
        /// </summary>
        public void MakeNameUppercase()
        {
            var names = new List<string> { "иван иванов", "светлана иванова-петренко" };
            char[] separator = new[] { ' ', '-'};
            foreach (var name in names)
            {
                foreach (var word in name.Split(separator))
                {
                    Console.Write(word[0].ToString().ToUpper() + word.Substring(1,word.Length-1)+" ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Task 9
        /// </summary>
        public void FromBase64()
        {
            string baseString = "0JXRgdC70Lgg0YLRiyDRh9C40YLQsNC10YjRjCDRjdGC0L7RgiDRgtC10LrRgdGCLCDQt9C90LDRh9C40YIg0LfQsNC00LDQvdC40LUg0LLRi9C/0L7Qu9C90LXQvdC+INCy0LXRgNC90L4gOik=";
            Console.WriteLine(System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(baseString)));
        }
    }
}
