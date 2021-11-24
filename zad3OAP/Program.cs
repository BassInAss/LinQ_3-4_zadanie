using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace zad3OAP
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter sw = new StreamWriter("info.txt");
            sw.WriteLine("Иванов Сергей Николаевич ПР-21 4,2");
            sw.WriteLine("Петров Игорь Юрьевич ПР-21 3,5");
            sw.WriteLine("Семёнов Михаил Алексеевич ПР-32 3,8");
            sw.WriteLine("Пиманов Александр Дмитриевич ПР-32 4,1");
            sw.WriteLine("Иванов Иван Петрович ПР-21 4,7");
            sw.WriteLine("Усольцев Александр Дмитриевич ПР-32 4,3");
            sw.Close();


            StreamReader sr = new StreamReader("info.txt");
            List<string[]> students = new List<string[]>();
            while (!sr.EndOfStream)
            {
                string temp = sr.ReadLine();
                students.Add(temp.Split(' '));
            }

            //var stdrework = students.Select(x => $"{string.Join(" ", x.Take(4))} {x[4].Replace(',', '.')}");
            //Здесь я избавлялся от запятых и заменил их точками, но это не пригодилось :)

            try
            {
                var sort = students.OrderBy(x => x[3]); //Сортировка по номеру группы
                var min = students.Min(x => x[4]);
                var max = students.Max(x => x[4]);
                var avver = students.Average(x => double.Parse(x[4]));


                Console.WriteLine($"Максимальный средний балл:  {max}");
                Console.WriteLine($"Минимальный средний балл:  {min}");
                Console.WriteLine($"Среднее значение средних баллов:  {Math.Round(avver, 3)} \n");

                Console.WriteLine("Отсортированный лист:");
                StreamWriter sw2 = new StreamWriter("rez.txt");
                foreach (string[] z in sort)
                {
                    sw2.WriteLine(string.Join(" ", z));
                    Console.WriteLine(string.Join(" ", z));
                }
                sw2.Close();
            }
            catch
            {
                Console.WriteLine("Неверные параметры, прочтенные из файла");
            }



        }
    }
}
