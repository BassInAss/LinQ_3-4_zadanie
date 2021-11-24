using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace zad4OAP
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter sw = new StreamWriter("info2.txt");
            sw.WriteLine("Иванов Сергей Николаевич ПР-21 4,2");
            sw.WriteLine("Петров Игорь Юрьевич ПР-21 3,5");
            sw.WriteLine("Семёнов Михаил Алексеевич ПР-32 3,8");
            sw.WriteLine("Пиманов Александр Дмитриевич ПР-32 4,1");
            sw.WriteLine("Иванов Иван Петрович ПР-21 4,7");
            sw.WriteLine("Усольцев Александр Дмитриевич ПР-21 4,3");
            sw.Close();


            StreamReader sr = new StreamReader("info2.txt");
            List<string[]> students = new List<string[]>();
            while (!sr.EndOfStream)
            {
                string temp = sr.ReadLine();
                students.Add(temp.Split(' '));
            }

            //var gr2 = students.GroupBy(p => p[4]).Select(g => new { Name = g.Key, Count = g.Count(), Students = g.Select(p => p) });

            try
            {
                var gr1 = students.GroupBy(g => g[3]).Select(g => new { name = g.Key, std = g.Where(x => x[4].StartsWith("4")), count = g.Count() - 1 });

                foreach (var group in gr1)
                {
                    Console.WriteLine($"{group.name} : {group.count}");

                    foreach (var x in group.std)
                        Console.WriteLine(string.Join(" ", x));
                    Console.WriteLine();
                }
            }
            catch
            {
                Console.WriteLine("Неверные входные параметры студента");
            }


        }
    }
}
