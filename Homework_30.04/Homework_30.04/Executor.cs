using Homework_30._04.Content;
using Homework_30._04.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_30._04
{
    public class Executor<T> where T : ContentFile
    {
        private Parser<T> parser;
        private string rawText;
        public Executor(Parser<T> parser,string text)
        {
            this.parser = parser;
            this.rawText = text;
        }


        public void Print()
        {
            var preparedStrings = parser.PickOut(rawText);
            var parsedString = parser.Parse(preparedStrings);
            parsedString = parsedString.OrderBy(o => o.Weight).ToList();
            foreach(var el in parsedString)
            {
                Console.WriteLine(el.ToString());
            }
            
        }
    }
}
