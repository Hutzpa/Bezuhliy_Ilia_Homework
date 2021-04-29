using Homework_30._04.Content;
using Homework_30._04.Parsers;
using System;

namespace Homework_30._04
{
    class Program
    {
        static void Main(string[] args)
        {
            String text = @"Text:file.txt(6B);Some string content
Image:img.bmp(19MB);1920х1080
Text:data.txt(12B);Another string
Text:data1.txt(7B);Yet another string
Movie:logan.2017.mkv(19GB);1920х1080;2h12m";
            Console.WriteLine("Text files:");
            new Executor<TextContentFile>(new TextParser(), text).Print();
            Console.WriteLine("Movies:");
            new Executor<MovieContentFile>(new MovieParser(), text).Print();
            Console.WriteLine("Images:");
            new Executor<ImageContentFile>(new ImageParser(), text).Print();
            
        }
    }
}
