using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileIOHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // 1 задание

           Console.WriteLine("Введите полный путь до файла с числами фибоначи: ");
            var path = Console.ReadLine();

            if (string.IsNullOrEmpty(path))
            { 
                path = @"D:\c#Homework\fibonacci.txt"; 
                Console.WriteLine($"Путь по умолчанию : {path}");
            }

            try
            {
                List<string> list = new List<string>();
                if (File.Exists(path))
                {
                    using (StreamReader streamReader = new StreamReader(path))
                    {
                        string textFromFile = streamReader.ReadToEnd();
                        int[] arrayNumber = textFromFile.Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => int.Parse(x)).ToArray();

                        foreach (var number in arrayNumber)
                        {
                            list.Add(number.ToString());
                        }
                        for (int i = arrayNumber.Length - 1; i < arrayNumber.Length * 2 - 1; i++)
                        {
                            list.Add(Convert.ToString((Convert.ToInt32(list[i - 1]) + Convert.ToInt32(list[i]))));
                        }
                    }

                    using (StreamWriter streamWriter = new StreamWriter(path, false, System.Text.Encoding.Default))
                    {
                        string text = "";
                        foreach (var n in list)
                        {
                            text += n + " ";
                        }
                        streamWriter.WriteAsync(text);
                        Console.WriteLine("Запись завершена");
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }



            // 2 задание


            /*var inputFilePath = @"D:\c#Homework\INPUT.txt";
            var outputFilePath = @"D:\c#Homework\OUTPUT.txt";

            try
            {
                int sum = 0;
                int[] numbers;
                if (File.Exists(inputFilePath))
                {
                    using (StreamReader streamReader = new StreamReader(inputFilePath))
                    {
                        string textFromFile = streamReader.ReadToEnd();
                        numbers = textFromFile.Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => int.Parse(x)).ToArray();
                        foreach (var number in numbers)
                        {
                            sum += number;
                        }
                    }
                    if (File.Exists(outputFilePath))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(outputFilePath))
                        {
                            streamWriter.WriteAsync(sum.ToString());
                        }
                    }
                }
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }*/

        }
    }
}
