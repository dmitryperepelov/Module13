using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task13_6_2
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

            var fileName = args[0];
            var itemsQnt = args.Length > 1 ? int.TryParse(args[1], out int qnt) ? qnt : 10 : 10;

            var dictionary = new Dictionary<string, int>();

            using (var reader = new StreamReader(fileName))
            {
                string str;
                while ((str = reader.ReadLine()) != null)
                {
                    str = new string(str.Where(c => !char.IsPunctuation(c)).ToArray());
                    foreach(var word in str.ToLower().Split(" "))
                    {
                        if (!dictionary.ContainsKey(word))
                            dictionary.Add(word, 1);
                        else
                            dictionary[word]++;
                    }
                }
            }

            dictionary.Remove("");
            var list = dictionary.ToList();

            list.Sort((p1, p2) => p1.Value.CompareTo(p2.Value));
            list.Reverse();

            for (int i = 0; i < itemsQnt; i++)
                Console.WriteLine($"{list[i].Key}: {list[i].Value}");

            Console.ReadKey();
        }
    }
}