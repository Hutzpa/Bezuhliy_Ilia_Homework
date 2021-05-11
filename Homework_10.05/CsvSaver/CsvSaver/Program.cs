using System;
using System.IO;
using System.Reflection;

namespace CsvSaver
{
    class Program
    {
        static void Main(string[] args)
        {
            char SEPARATOR = ',';
            string FileName = "Example.csv";
            Console.WriteLine("Write fields you want to save to csv");
            string[] fields = Console.ReadLine().Split(SEPARATOR);
            if (File.Exists(FileName))
                File.Delete(FileName);
            foreach(var person in PersonList.GetListPerson())
            {
                foreach(var field in fields)
                    File.AppendAllText(FileName, GetPropertyValue(field, person) != null  ? $"{field} - {GetPropertyValue(field, person)};" : "");
                
                File.AppendAllText(FileName, "\n");
            }
        }
         public static object GetPropertyValue(string property, Person person) => typeof(Person).GetProperty(property).GetValue(person);

    }
}
