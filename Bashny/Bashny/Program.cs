using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Bashny
{
    public class Program
    {

        static void Main(string[] args)
        {
            char x = 'A', y = 'B', z = 'C';
            int k, h;
          //  Console.WriteLine("Задача о Ханойских башнях");
          //  Console.WriteLine("\nВведите количество колец: ");
          //  k = int.Parse(Console.ReadLine());

          //  h = hanoj(k, x, y, z);//запуск алгоритма Ханойских башен
           
            WriteFile(Line(x, z, y)); //запись результатов измерений времени в файл
          //  Console.WriteLine($"\nКоличество перекладываний равно {h}");
        }

        //Описание функции перемещения колец с A на C через B
        public static int hanoj(int n, char A, char B, char C)
        {
            int num;
            if (n == 1)
            { 
                Console.WriteLine($"\n   {A} -> {C}");
                num = 1;
            }
            else
            {
                num = hanoj(n - 1, A, C, B);
                Console.WriteLine($"\n   {A} -> {C}");
                num++;
                num += hanoj(n - 1, B, A, C);
               
            }
             
            return num;
        }
       
        public static string[] Line(char A, char B, char C)//замеры времени
        {
            Stopwatch stopWatch = new Stopwatch(); // секундомер
            double time;
            TimeSpan testTime;
            List<string> result = new List<string>();
            for (int i = 1; i <= 20; i ++)
            {
                stopWatch.Reset();
                stopWatch.Start();
                int h = hanoj(i ,A, B, C);
                stopWatch.Stop(); // остановить секундомер
                testTime = stopWatch.Elapsed;
                time = testTime.TotalMilliseconds;
                result.Add(time.ToString());
                Console.WriteLine(i.ToString());
                
                WriteFile(result.ToArray());
            }
            return result.ToArray();
        }

        public static void WriteFile(string[] result) //запись результатов измерений времени в файл
        {
            string path = @"C:\Users\Sasacompik\OneDrive\Рабочий стол\Алгоритм и анализ сложности";
            CreateFolder(path);
            string fileName ="result.txt";
            string fullName = Path.Combine(path, fileName);
         //   File.Delete(fullName);
            File.AppendAllLines(fullName, result);
        }
        static void CreateFolder(string path)
        {
            if (!File.Exists(path))
                Directory.CreateDirectory(path);
        }
    }
}
