using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Homework_17_05
{
    public class Task1
    {
        private string PATH { get; set; } = @"C:\";
        private readonly string TEXT_EXTENSIONS = ".txt;.json;.xml;";// Для примера взял эти три формата
        private int DirectoryLlv { get; set; } = 0;

        public void Execute()
        {

            while (true)
            {
                Console.Clear();
                string[] directoryFileContents = Directory.GetFiles(PATH);
                string[] directoryFoldersContents = Directory.GetDirectories(PATH);
                foreach (var folder in directoryFoldersContents)
                    Console.WriteLine($"FOLDER - {folder}");
                foreach (var file in directoryFileContents)
                    Console.WriteLine($"FILE - {file}");

                Console.WriteLine("Waiting for your command");
                var input = Console.ReadLine().Split(' ');
                string command = input[0];
                try
                {

                
                switch (command)
                {

                    case "cd":
                        {
                            if (input[1] == "..")
                            {
                                //Откат на одну директорию назад
                                //Если упёрся в корень - сыпать ошибки
                                var directories = PATH.Trim().Split(@"\").ToList();
                                foreach (var dir in directories.ToList())
                                    if (String.IsNullOrWhiteSpace(dir) || String.IsNullOrEmpty(dir))
                                        directories.Remove(dir);
                                if (directories.Count() == 1)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Can't exit the root");
                                    Console.ReadLine();
                                }
                                else //Протестить
                                {
                                    PATH = "";
                                    DirectoryLlv -= 1;
                                    for (int i = 0; i < directories.Count() - 1; i++)
                                    {

                                        PATH += directories[i];
                                        PATH += "\\";

                                    }
                                }
                            }
                            else
                            {
                                string directory = "";
                                for (int i = 1; i < input.Length; i++) //Совмещение пути на случай папок и файлов с пробелами в названии
                                {
                                    if (DirectoryLlv >= 1)
                                        directory += "\\";
                                    directory += input[i];
                                }
                                //Проверяем, есть ли такой путь в директориях или файлах
                                //Если есть в директориях - переходим туда
                                //Если есть в файлах, открываем его
                                if (directoryFoldersContents.Contains(PATH + directory))
                                {
                                    if (DirectoryLlv >= 1)
                                        PATH += "\\";
                                    PATH += input[1];
                                    DirectoryLlv += 1;
                                }
                                else if (directoryFileContents.Contains(PATH + directory))
                                {
                                    string sr = new StreamReader(PATH + directory).ReadToEnd();
                                    if (TEXT_EXTENSIONS.Split(';').Contains(Path.GetExtension(PATH + directory)))
                                        Console.WriteLine(sr);
                                    else
                                    {
                                        using (MemoryStream stream = new MemoryStream())
                                        {
                                            new BinaryFormatter().Serialize(stream, sr);
                                            Console.WriteLine(Convert.ToBase64String(stream.ToArray()));
                                        }
                                    }
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("No such file or directory");
                                    Console.ReadLine();
                                }
                            }
                            break;
                        }
                    case "exit":
                        {
                            Process.GetCurrentProcess().Kill();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("No such command");
                            Console.ReadLine();
                            break;
                        }

                }
                }
                catch(Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine($"Не удалось получить доступ к папке. Причина - {ex.Message}");
                    Console.ReadLine();
                }
            }
        }
    }
}
