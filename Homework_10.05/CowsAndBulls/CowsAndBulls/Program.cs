using System;
using System.Collections.Generic;
using System.Linq;

namespace CowsAndBulls
{
    class Program
    {
        static void Main(string[] args)
        {

            var variants = new List<Numbers>();
            for (int i = 0; i < 10000; i++)
                variants.Add(new Numbers { Value = $"{i:0000}", Bulls = 0, Cows = 0 }); //Заполняем массив вариантов четырёхзначными цифрами от 0000 до 9999

            var guess = variants[new Random().Next(0, variants.Count)];
            Console.WriteLine($"My guess is {guess}");
            List<Numbers> guesses = new List<Numbers>();
            int bulls = 0;
            int cows = 0;
            string number = "";
            int round = 1;
            while (bulls != 4)
            {
                Console.WriteLine($"Round {round}");
                Console.WriteLine($"Variants left {variants.Count}");
                Console.WriteLine($"My guess is {guess.Value}");
                GetBullsAndCows(ref bulls, ref cows);
                if (bulls == 4)
                {
                    Console.WriteLine($"I won, the number is {number}");
                    break;
                }
                guess.Bulls = bulls;
                guess.Cows = cows;
                guesses.Add(guess);
                CountBullsAndCows(bulls, cows, guess, ref variants);
                //foreach (var s in variants)
                //{
                //    Console.WriteLine(s);
                //}
                guess = variants[new Random().Next(0, variants.Count)];
                round++;
            }

        }

        public static void GetBullsAndCows(ref int bulls, ref int cows)
        {
            Console.WriteLine("How many bulls?");
            bulls = int.Parse(Console.ReadLine());
            Console.WriteLine("And many cows?");
            cows = int.Parse(Console.ReadLine());
        }

        public static void CountBullsAndCows(int bulls, int cows, Numbers lastGuess, ref List<Numbers> numbers)
        {

            if (bulls == 0 && cows == 0)
            {
                //Удалить цифры, в которых есть цифры из последней догадки
                foreach (var o in numbers.ToList())
                    if (o.Value.Contains(lastGuess.Value[0]) || o.Value.Contains(lastGuess.Value[1]) || o.Value.Contains(lastGuess.Value[2]) || o.Value.Contains(lastGuess.Value[3]))
                        numbers.Remove(o);
                return;
            }
            if (bulls == 0)
            {
                //Удалить на том же месте, та же цифра А ОСТАЛЬНЫМ НАЗНАЧИТЬ КОЛИЧЕСТВО БЫКОВ И КОРОВ ПОЛЬЗОВАТЕЛЯ
                foreach (var o in numbers.ToList())//прохожусь по каждому числу
                    for (int i = 0; i < 3; i++)//по каждой цифре числа
                        if (o.Value[i] == lastGuess.Value[i])
                            numbers.Remove(o);
                foreach (var el in numbers)
                {
                    el.Bulls = bulls;
                    el.Cows = cows;
                }

                //Удалить все, в которых быков меньше чем в последней догадке
                foreach (var o in numbers.Where(o => o.Bulls < lastGuess.Bulls).ToList())
                    numbers.Remove(o);
            }
            if (cows == 0)
            {
                #region fail
                ////Удалить все, где одна и та же цифра, не на том месте, где в догадке
                //foreach (var o in numbers.ToList())//прохожусь по каждому числу
                //    for (int i = 0; i < 3; i++)//по каждой цифре числа
                //        if (lastGuess.Value[i] != o.Value[i])
                //            numbers.Remove(o);

                //foreach (var el in numbers)
                //{
                //    el.Bulls += bulls;
                //    el.Cows += cows;
                //}
                ////Удалить все, в которых быков меньше чем в последней догадке
                //foreach (var o in numbers.Where(o => o.Bulls < lastGuess.Bulls).ToList())
                //    numbers.Remove(o);
                #endregion

            }
           

            numbers.Remove(lastGuess);
        }

    }
}
