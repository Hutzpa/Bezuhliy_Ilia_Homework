using System;
using System.Linq;

namespace LinqHomework
{
    public class Task1
    {
        public void Execute()
        {
            //Я малость упоролся и только на середине понял, что сделал всё в одну строку, решил для общей стилистики сделать всё в таком же стиле

            //.Trim() для строки вида "baaa; aabb; aaa; xabbx; abb; ccc; dapbb; zh" у меня почему-то не захотел работать.

            Console.WriteLine("1. Выведите все числа от 10 до 50 через запятую.");
            Console.WriteLine(string.Join(",", Enumerable.Range(10, 41)));
            Console.WriteLine("_________________________________________________");

            Console.WriteLine("2. Выведите только те числа от 10 до 50, которые можно разделить на 3.");
            Enumerable.Range(10, 41).Where(o => o % 3 == 0).ToList().ForEach(Console.WriteLine);
            Console.WriteLine("_________________________________________________");

            Console.WriteLine("3. Выведите слово «Linq» 10 раз.");
            Enumerable.Repeat("Linq", 10).ToList().ForEach(Console.WriteLine);
            Console.WriteLine("_________________________________________________");

            Console.WriteLine("4. Вывести все слова с буквой «а» в строку «aaa; abb; ccc; dap»."); //Не понял, нужно ли взять откуда-то эту строку, или написать свою,потому возьму из набора данных
            string toSelectFrom = "Punitive law and criminal law doctrine.";
            toSelectFrom.Split(' ').Where(o => o.ToLower().Contains('a')).ToList().ForEach(o => { Console.Write($"{o};"); });
            Console.WriteLine("_________________________________________________");

            Console.WriteLine("5. Выведите количество букв «а» в словах с этой буквой в строке «aaa; abb; ccc; dap» через запятую");
            //string toCount = "aaa; abb; ccc; dap"; //Не знал что методы можно применять к голой строке, решил попробовать, оказывается можно
            "aaa; abb; ccc; dap".Split(';').Where(o => o.Contains('a')).ToList().ForEach(o => { Console.WriteLine($"The string {o} contains {o.Count(l => l == 'a')} 'a' letters"); });
            Console.WriteLine("_________________________________________________");

            Console.WriteLine("6. Выведите true, если слово «abb» существует в строке «aaa; xabbx; abb; ccc; dap», в противном случае - false.");
            "aaa; xabbx; abb; ccc; dap".Trim().Split(';').ToList().ForEach(o => { Console.WriteLine(o.Contains("abb") ? o + " contains abb" : ""); });
            Console.WriteLine("_________________________________________________");

            Console.WriteLine("7. Найдите самое длинное слово в строке «aaa; xabbx; abb; ccc; dap»");
            Console.WriteLine("aaa; xabbx; abb; ccc; dap".Trim().Split(';').OrderBy(o => o.Length).Last());
            Console.WriteLine("_________________________________________________");

            Console.WriteLine("8. Вычислить среднюю длину слова в строке «aaa; xabbx; abb; ccc; dap»");
            Console.WriteLine("aaa; xabbx; abb; ccc; dap".Trim().Split(';').Average(o => o.Trim().Length));
            Console.WriteLine("_________________________________________________");

            Console.WriteLine("9. Выведите самое короткое слово в перевернутом виде в строке «aaa; xabbx; abb; ccc; dap; zh».\n");
            "aaa; xabbx; abb; ccc; dap; zh".Split(';').OrderBy(o => o.Trim().Length).First().ToCharArray().Reverse().ToList().ForEach(o => { Console.Write(o); });
            Console.WriteLine("\n_________________________________________________");

            Console.WriteLine("10. Выведите true, если в первом слове, начинающемся с «aa», все буквы - «b», в противном случае - false «baaa; aabb; aaa; xabbx; abb; ccc; dap; zh»");
            "baaa; aabb; aaa; xabbx; abb; ccc; dap; zh".Split(';')
                .Where(o => o.Trim()[0] == 'a' && o.Trim()[1] == 'a' && o.Trim().EndsWith(Cheat.MakeString('b', o.Trim().Length - 2)))
                .ToList().ForEach(o => { Console.WriteLine($"{o} is true"); });
            Console.WriteLine("\n_________________________________________________");
            Console.WriteLine("11. Выведите последнее слово в последовательности, за исключением первых двух элементов, заканчивающихся на «bb».");
            "baaa; aabb; aaa; xabbx; abb; ccc; dapbb; zh".Split(';').Where(o => o.EndsWith("bb")).Skip(2).ToList().ForEach(Console.WriteLine);

        }
    }
}
