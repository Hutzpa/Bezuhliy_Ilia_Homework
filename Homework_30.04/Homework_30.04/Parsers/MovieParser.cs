using Homework_30._04.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Homework_30._04.Parsers
{
    public class MovieParser : Parser<MovieContentFile>
    {
        public override List<MovieContentFile> Parse(List<string[]> text)
        {
            List<MovieContentFile> data = new List<MovieContentFile>();
            foreach (var str in text)
            {
                var weight = Regex.Match(str[4], @"(\d+)(\w+)");
                var resolution = Regex.Match(str[6], @"(\d+)(\w{1})(\d+)");
                var duration = Regex.Match(str[7], @"(\d+)(\w)(\d+)(\w+)");
                data.Add(new MovieContentFile
                {

                    FileName = str[1] + "." + str[2],
                    FileExtension = str[3],
                    Weight = int.Parse(weight.Groups[1].Value),
                    WeightMark = weight.Groups[2].Value.ToString(),
                    Width = int.Parse(resolution.Groups[1].Value),
                    Height = int.Parse(resolution.Groups[3].Value),
                    //Duration = TimeSpan.Parse($"{duration.Groups[1]}:{duration.Groups[3]}"),
                    Duration = new TimeSpan(int.Parse(duration.Groups[1].Value), int.Parse(duration.Groups[3].Value),0)
                });
            }
            return data;
        }

        public override List<string[]> PickOut(string text) //Я не горд этим решением, но сейчас полночь, а я хочу спать
        {
            char[] separator = new[] { ':', '.', '(', ')', ';' };
            var strings = text.Split("\n");
            string stringType;
            List<string[]> readyStrings = new List<string[]>();
            for (int i = 0; i < strings.Length; i++)
            {
                stringType = strings[i].Split(separator)[0];
                if (stringType == "Movie")
                {
                    var preparedString = strings[i].Split(separator);
                    readyStrings.Add(new[] { preparedString[0], preparedString[1], preparedString[2], preparedString[3], preparedString[4], preparedString[5], preparedString[6], preparedString[7] });
                }
            }

            return readyStrings;
        }
    }
}
