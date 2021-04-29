using Homework_30._04.Content;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Homework_30._04.Parsers
{
    public class TextParser : Parser<TextContentFile>
    {
        public override List<TextContentFile> Parse(List<string[]> text)
        {
            List<TextContentFile> data = new List<TextContentFile>();
            foreach (var str in text)
            {
                var match = Regex.Match(str[3], @"(\d+)(\w+)");
                data.Add(new TextContentFile
                {
                    Type = FileType.Text,
                    FileName = str[1],
                    FileExtension = str[2],
                    Weight = int.Parse(match.Groups[1].Value),
                    WeightMark = match.Groups[2].Value.ToString(),
                    Content = str[5]
                });
            }
            return data;
        }

        public override List<string[]> PickOut(string text)//Я не горд этим решением, но сейчас полночь, а я хочу спать
        {
            char[] separator = new[] { ':', '.', '(', ')', ';' };
            var strings = text.Split("\n");
            string stringType;
            List<string[]> readyStrings = new List<string[]>();
            for (int i = 0; i < strings.Length; i++)
            {
                stringType = strings[i].Split(separator)[0];
                if (stringType == "Text")
                {
                    var preparedString = strings[i].Split(separator);
                    readyStrings.Add(new[] { preparedString[0], preparedString[1], preparedString[2], preparedString[3], preparedString[4], preparedString[5] });
                }
            }
            return readyStrings;
        }
    }
}
