using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            var customers = new List<Customer>
                    {
    new Customer(1, "Tawana Shope", new DateTime(2017, 7, 15), 15.8),
    new Customer(2, "Danny Wemple", new DateTime(2016, 2, 3), 88.54),
    new Customer(3, "Margert Journey", new DateTime(2017, 11, 19), 0.5),
    new Customer(4, "Tyler Gonzalez", new DateTime(2017, 5, 14), 184.65),
    new Customer(5, "Melissa Demaio", new DateTime(2016, 9, 24), 241.33),
    new Customer(6, "Cornelius Clemens", new DateTime(2016, 4, 2), 99.4),
    new Customer(7, "Silvia Stefano", new DateTime(2017, 7, 15), 40),
    new Customer(8, "Margrett Yocum", new DateTime(2017, 12, 7), 62.2),
    new Customer(9, "Clifford Schauer", new DateTime(2017, 6, 29), 89.47),
    new Customer(10, "Norris Ringdahl", new DateTime(2017, 1, 30), 13.22),
    new Customer(11, "Delora Brownfield", new DateTime(2011, 10, 11), 0),
    new Customer(12, "Sparkle Vanzile", new DateTime(2017, 7, 15), 12.76),
    new Customer(13, "Lucina Engh", new DateTime(2017, 3, 8), 19.7),
    new Customer(14, "Myrna Suther", new DateTime(2017, 8, 31), 13.9),
    new Customer(15, "Fidel Querry", new DateTime(2016, 5, 17), 77.88),
    new Customer(16, "Adelle Elfrink", new DateTime(2017, 11, 6), 183.16),
    new Customer(17, "Valentine Liverman", new DateTime(2017, 1, 18), 13.6),
    new Customer(18, "Ivory Castile", new DateTime(2016, 4, 21), 36.8),
    new Customer(19, "Florencio Messenger", new DateTime(2017, 10, 2), 36.8),
    new Customer(20, "Anna Ledesma", new DateTime(2017, 12, 29), 0.8)
            };

            Console.WriteLine("a.	Найти потребителя, который зарегистрировался раньше всех");
            var theFirst = customers.OrderBy(o => o.RegistrationDate).First();
            Console.WriteLine($"Name {theFirst.Name}, id - {theFirst.Id}, reg date - {theFirst.RegistrationDate}");

            Console.WriteLine("b.	Написать метод, который считает среднее арифметическое всех балансов всех потребителей");
            var avg = customers.Average(o => o.Balance);
            Console.WriteLine(avg);

            Console.WriteLine("c.	Написать метод, который позволит фильтровать потребителей по дате регистрации (от X до Y). Если нет результата по фильтру - выводить сообщение No results");
            FilterDate(new DateTime(2011, 10, 11), new DateTime(2016, 4, 2), customers);


            Console.WriteLine("d.	Написать метод, который позволяет фильтровать потребителей по Id-шникам");
            FilterId(8, customers);

            Console.WriteLine("e.	Написать метод, который позволяет фильтровать потребителей по части имени не учитывая регистр");
            FilterName("vory", customers);

            Console.WriteLine("f.	Написать метод, который выведет на экран, в хронологическом порядке, потребителей которые зарегистрировались в один месяц, при этом в одной такой группе они должны быть отсортированы в алфавитном порядке");
            F(customers);

            Console.WriteLine("g.	Написать метод, который отсортирует потребителей по заданному полю и направлению (ascending, descending) [ремарка - рефлексия в помощь]");
            Sort("Name", "descending", customers);

            Console.WriteLine("h.	Написать метод, который выведет на экран имена всех потребителей в коллекции через запятую");
            foreach (var name in customers.Select(o => o.Name))
                Console.Write($"{name},");
        }


        public static void FilterDate(DateTime from, DateTime to, List<Customer> customers)
        {
            var filtered = customers.Where(o => o.RegistrationDate >= from && o.RegistrationDate <= to).ToList();
            if (!filtered.Any())
                Console.WriteLine("No result");
            else
                foreach (var theFirst in filtered)
                    Console.WriteLine($"Name {theFirst.Name}, id - {theFirst.Id}, reg date - {theFirst.RegistrationDate}");
        }

        public static void FilterId(int id, List<Customer> customers)
        {
            var res = customers.FirstOrDefault(o => o.Id == id);
            if (res == null)
                Console.WriteLine("No result");
            else
                Console.WriteLine($"Name {res.Name}, id - {res.Id}, reg date - {res.RegistrationDate}");
        }

        public static void FilterName(string name, List<Customer> customers)
        {
            var res = customers.FirstOrDefault(o => o.Name.ToLower().Contains(name));
            if (res == null)
                Console.WriteLine("No result");
            else
                Console.WriteLine($"Name {res.Name}, id - {res.Id}, reg date - {res.RegistrationDate}");
        }

        public static void F(List<Customer> customers)
        {
            for (int i = 1; i <= 12; i++)
            {
                Console.WriteLine($"The {i} month");
                foreach (var cust in customers.Where(o => o.RegistrationDate.Month == i).OrderBy(o => o.Name).ToList())
                {
                    Console.WriteLine($"Name {cust.Name}, id - {cust.Id}, reg date - {cust.RegistrationDate}");
                }
            }
        }

        public static void Sort(string fieldName, string sortType, List<Customer> customers)
        {
            var sorted = customers.OrderBy(p => typeof(Customer).GetProperty(fieldName).GetValue(p)).ToList();
            if (sortType == "ascending") { }
            else
                sorted.Reverse();
            foreach (var res in sorted)
                Console.WriteLine($"Name {res.Name}, id - {res.Id}, reg date - {res.RegistrationDate}");
        }

    }
}
