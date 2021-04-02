using System;
using System.Collections.Generic;
using System.IO;

namespace PNYVULab1
{

    class Program
    {
        static void Main(string[] args)
        {
            string[] lines_from_the_file = File.ReadAllLines("Lines_for_laba_1.txt");
            if (lines_from_the_file.Length == 0)
            {
                Console.WriteLine("Файл пуст");
            }
            else
            {
                LenghtSorting(lines_from_the_file);
                AlphabetSorting(lines_from_the_file);
                CommonParts(lines_from_the_file);
            }
        }

        public static void LenghtSorting(string[] lines_from_the_file) //метод для сортировки по длине
            {
                string temp;
            for (int i = 0; i < lines_from_the_file.Length - 1; i++)
            {
                for (int j = i + 1; j < lines_from_the_file.Length; j++)
                {
                    if (lines_from_the_file[i].Length > lines_from_the_file[j].Length) //с помощью оператора if сортируем строки посредством перебора всех строк
                    {                                                                 
                        temp = lines_from_the_file[i];
                        lines_from_the_file[i] = lines_from_the_file[j];
                        lines_from_the_file[j] = temp;
                        File.WriteAllLines(@"C:\Users\Виктория\source\repos\PNVUYLab1\Sorting_lines_by_length.txt", lines_from_the_file); //запись отсортированных строк в файл

                    }
                }
            }
            System.IO.File.AppendAllText(@"C:\Users\Виктория\source\repos\PNVUYLab1\Sorting_lines_by_length.txt", "Строки отсортированы по длине");
        }
        public static void AlphabetSorting(string[] lines_from_the_file) //метод для сортировки по алфавиту
        {
            Array.Sort(lines_from_the_file);
            File.WriteAllLines(@"C:\Users\Виктория\source\repos\PNVUYLab1\Sorting_lines_alphabetically.txt", lines_from_the_file); //запись отсортированных строк в файл
            System.IO.File.AppendAllText(@"C:\Users\Виктория\source\repos\PNVUYLab1\Sorting_lines_alphabetically.txt", "Строки отсортированы по алфавиту");
        }
        public static void CommonParts(string[] lines) //метод для нахождения общих частей в строках
        {
            LenghtSorting(lines);

          
            int Parts_Count = 0; //нахождение размерности массива подстрок
            for (int i = lines[0].Length; i >= 0; i--)
            {
                Parts_Count += i;
            }
            string[] Parts = new string[Parts_Count];

           
            int count = 0;
            for (int i = 1; i <= lines[0].Length; i++) //заполняем массив подстрок, выбирая самую короткую строку,
            {                                          //чтобы взять из нее все возможные общие части
                for (int j = 0; j <= lines[0].Length - i; j++)
                {
                    Parts[count] = lines[0].Substring(j, i); //substring извлекает подстроку из данного экземпляра.
                    count++;
                }
            }
            //проверяем на вхождение общих частей
            List<string> commonParts = new List<string>(); //list<string>-простейший список однотипных объектов
            for (int j = 0; j < count; j++)
            {
                bool boolean_variable = true;
                for (int i = 0; i < commonParts.Count; i++)
                {
                    if (Parts[j] == commonParts[i])
                    {
                        boolean_variable = false;
                        break;
                    }
                }
                if (boolean_variable)
                {
                    for (int i = 1; i < lines.Length; i++)
                    {
                        if (lines[i].Contains(Parts[j])) //contains возвращает значение, указывающее, встречается ли указанный символ внутри этой строки.
                        {
                            continue;
                        }
                        boolean_variable = false;
                        break;
                    }
                    if (boolean_variable)
                    {
                        commonParts.Add(Parts[j]); //add добавляет объект в конец коллекции List<T>.
                    }
                }
            }
            File.WriteAllLines(@"C:\Users\Виктория\source\repos\PNVUYLab1\Finding_common_parts.txt", commonParts);
            System.IO.File.AppendAllText(@"C:\Users\Виктория\source\repos\PNVUYLab1\Finding_common_parts.txt", "Общие части выведены");
        }
    }
}
