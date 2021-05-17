using Homework_30._04.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Homework_30._04.Parsers
{
    public class ImageParser : Parser<ImageContentFile>
    {

        public override List<ImageContentFile> Parse(List<string[]> text)
        {
            List<ImageContentFile> data = new List<ImageContentFile>();
            foreach (var str in text)
            {
                var weight = Regex.Match(str[3], @"(\d+)(\w+)");
                var resolution = Regex.Match(str[5], @"(\d+)(\w{1})(\d+)");
                data.Add(new ImageContentFile
                {
                    FileName = str[1],
                    FileExtension = str[2],
                    Weight = int.Parse(weight.Groups[1].Value),
                    WeightMark = weight.Groups[2].Value.ToString(),
                    Width=int.Parse(resolution.Groups[1].Value),
                    Height= int.Parse(resolution.Groups[3].Value)
                });
            }
            return data;
        }

        public override List<string[]> PickOut(string text)  //Я не горд этим решением, но сейчас полночь, а я хочу спать
        {
            char[] separator = new[] { ':', '.', '(', ')', ';' };
            var strings = text.Split("\n");
            string stringType;
            List<string[]> readyStrings = new List<string[]>();
            for (int i = 0; i < strings.Length; i++)
            {
                stringType = strings[i].Split(separator)[0];
                if (stringType == "Image") 
                {
                    var preparedString = strings[i].Split(separator);
                    readyStrings.Add(new[] { preparedString[0], preparedString[1], preparedString[2], preparedString[3], preparedString[4], preparedString[5] });
                }
            }
            return readyStrings;
        }
    }
}
