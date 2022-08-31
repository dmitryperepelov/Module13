using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Task13_6_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length == 0 || !File.Exists(args[0]))
            {
                Console.WriteLine("Файл не найден");
                Console.ReadKey();
                return;
            }

            Console.Write("Количество итераций: ");
            var iterationQnt = Console.ReadLine();
            int.TryParse(iterationQnt, out var iteration);

            var filePath = args[0];
            var list = new List<string>();
            var linkedList = new LinkedList<string>();

            double listTime = 0;
            double linkedListTime = 0;

            for (int i = 0; i < Math.Max(iteration, 100); i++)
            {
                listTime += InsertToListProfiling(filePath, list);
                linkedListTime += InsertToLinkedListProfiling(filePath, linkedList);
                list = new List<string>();
                linkedList = new LinkedList<string>();
            }

            Console.WriteLine($"List: {listTime} ms");
            Console.WriteLine($"LinkedList: {linkedListTime} ms");
            Console.ReadKey();
        }

        private static double InsertToListProfiling(string filePath, List<string> list)
        {
            var sw = new Stopwatch();
            sw.Start();
            using (var reader = new StreamReader(filePath))
            {
                string str;
                while ((str = reader.ReadLine()) != null)
                {
                    list.Add(str);
                }
            }
            return sw.Elapsed.TotalMilliseconds;
        }

        private static double InsertToLinkedListProfiling(string filePath, LinkedList<string> linkedList)
        {
            var sw = new Stopwatch();
            sw.Start();
            using (var reader = new StreamReader(filePath))
            {
                string str;
                while ((str = reader.ReadLine()) != null)
                {
                    linkedList.AddLast(str);
                }
            }
            return sw.Elapsed.TotalMilliseconds;
        }
    }
}