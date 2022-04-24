using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Diagnostics;

namespace Zadanie_2
{
    class Program
    {
        static string filename = Directory.GetCurrentDirectory() + "\\sorted.dat";
        static public Stopwatch myStopwatch = new Stopwatch();      
        static void Swap(int[] array, int i, int j)
        {
            int glass = array[i];
            array[i] = array[j];
            array[j] = glass;
        }
        static public void ShakerSort(int[] array)
        {
            myStopwatch.Restart();
            string g = new string('_', 80);
            Console.WriteLine("\n" + g);
            Console.WriteLine("\nСортировка шейкером: ");
            int left = 0,
                right = array.Length - 1;
            long count_switch = 0, //счетчик обменов
                count_compare = 0;//счетчик сравнений    

            while (left <= right)
            {
                for (int i = left; i < right; i++)
                {
                    count_compare++;
                    if (array[i] < array[i + 1])
                    {
                        Swap(array, i, i + 1);
                        count_switch++;
                    }
                }
                right--;

                for (int i = right; i > left; i--)
                {
                    count_compare++;
                    if (array[i - 1] < array[i])
                    {
                        Swap(array, i - 1, i);
                        count_switch++;
                    }
                }
                left++;
            }
            foreach (int value in array)
            {
                Console.Write($"{value} ");
            }
            myStopwatch.Stop();
            TimeSpan first3 = myStopwatch.Elapsed;
            using (StreamWriter streamwriter = new StreamWriter(filename, true))
            {
                streamwriter.Write("\nОтсортированный массив методом шейкера: \n");
                for (int i = 0; i < array.Length; i++)
                {
                    streamwriter.Write(array[i] + " ");
                }
                streamwriter.Write("\n");
                streamwriter.Write($"\n\nВремя работы: {first3} Кол - во обменов: { count_switch}. Кол - во сравнений: { count_compare}");
            }
            Console.WriteLine("\nДанные о сортировке шейкером: ");
            Console.WriteLine($"\nВремя работы: {first3}");
            Console.WriteLine($"\nКол-во обменов: {count_switch}. Кол-во сравнений: {count_compare}");
            Console.WriteLine("\n" + g);
        }
        static public void BubbleSort(int[] array)
        {
            myStopwatch.Restart();
            string g = new string('_', 80);
            Console.WriteLine("\n" + g);
            Console.WriteLine("\nСортировка пузырьком: ");
            long count_switch = 0, //счетчик обменов
                count_compare = 0;//счетчик сравнений         
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    count_compare++;
                    if (array[j] < array[j + 1])
                    {
                        count_switch++;
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;

                    }

                }

            }
            foreach (int value in array)
            {
                Console.Write($"{value} ");
            }
            myStopwatch.Stop();
            TimeSpan first2 = myStopwatch.Elapsed;
            using (StreamWriter streamwriter = new StreamWriter(filename, true))
            {
                streamwriter.Write("\nОтсортированный массив методом пузырька: \n");
                for (int i = 0; i < array.Length; i++)
                {
                    streamwriter.Write(array[i] + " ");
                }
                streamwriter.Write("\n");
                streamwriter.Write($"\n\nВремя работы: {first2} Кол - во обменов: { count_switch}. Кол - во сравнений: { count_compare}");
            }
            Console.WriteLine("\nДанные о сортировке пузырьком: ");
            Console.WriteLine($"\nВремя работы: {first2}");
            Console.WriteLine($"\nКол-во обменов: {count_switch}. Кол-во сравнений: {count_compare}");
            Console.WriteLine("\n" + g);
        }
        static public void InsertionSort(int[] array)
        {
            myStopwatch.Start();
            string g = new string('_', 80);
            Console.WriteLine("\n" + g);
            Console.WriteLine("\nСортировка вставками: ");
            long count_switch = 0, //счетчик обменов
                count_compare = 0;//счетчик сравнений

            for (int i = 1; i < array.Length; i++)
            {
                int cur = array[i];
                int j = i;
                count_compare++;
                while (j > 0 && cur > array[j - 1])
                {
                    array[j] = array[j - 1];
                    j--;
                    count_switch++;
                }
                array[j] = cur;
            }

            foreach (int value in array)
            {
                Console.Write($"{value} ");
            }           
            myStopwatch.Stop();
            TimeSpan first = myStopwatch.Elapsed;
            using (StreamWriter streamwriter = new StreamWriter(filename, false))
            {
                streamwriter.Write("Отсортированный массив методом вставки: \n");
                for (int i = 0; i < array.Length; i++)
                {
                    streamwriter.Write(array[i] + " ");
                }
                streamwriter.Write("\n");
                streamwriter.Write($"\n\nВремя работы: {first} Кол - во обменов: { count_switch}. Кол - во сравнений: { count_compare}");
            }
            Console.WriteLine("\nДанные о сортировке вставками: ");
            Console.WriteLine($"\nВремя работы: {first}");
            Console.WriteLine($"\nКол-во обменов: {count_switch}. Кол-во сравнений: {count_compare}");
            Console.WriteLine("\n" + g);
        }
        static public void ShellSort(int[] array)
        {
            myStopwatch.Restart();
            string g = new string('_', 80);
            Console.WriteLine("\n" + g);
            Console.WriteLine("\nСортировка Шелла: ");
            long count_switch = 0, //счетчик обменов
                count_compare = 0;//счетчик сравнений
            int step = array.Length / 2;
            while (step > 0)
            {
                int i, j;
                for (i = step; i < array.Length; i++)
                {
                    count_compare++;
                    int value = array[i];
                    for (j = i - step; (j >= 0) && (array[j] < value); j -= step)
                    {
                        array[j + step] = array[j];
                        count_switch++;
                    }
                    array[j + step] = value;
                }
                step /= 2;
            }
            foreach (int value in array)
            {
                Console.Write($"{value} ");
            }
            myStopwatch.Stop();
            TimeSpan first4 = myStopwatch.Elapsed;
            using (StreamWriter streamwriter = new StreamWriter(filename, true))
            {
                streamwriter.Write("\nОтсортированный массив методом Шелла: \n");
                for (int i = 0; i < array.Length; i++)
                {
                    streamwriter.Write(array[i] + " ");
                }
                streamwriter.Write("\n");
                streamwriter.Write($"\n\nВремя работы: {first4} Кол - во обменов: { count_switch}. Кол - во сравнений: { count_compare}");
            }
            Console.WriteLine("\nДанные о сортировке Шелла: ");
            Console.WriteLine($"\nВремя работы: {first4}");
            Console.WriteLine($"\nКол-во обменов: {count_switch}. Кол-во сравнений: {count_compare}");
            Console.WriteLine("\n" + g);
        }
        static public void SelectionSort(int[] array)
        {

            myStopwatch.Restart();
            string g = new string('_', 80);
            Console.WriteLine("\n" + g);
            Console.WriteLine("\nСортировка выбором: ");
            long count_switch = 0, //счетчик обменов
                count_compare = 0;//счетчик сравнений

            for (int i = 0; i < array.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] > array[min])
                    {
                        count_switch++;
                        min = j;
                    }
                }
                count_compare++;
                int dummy = array[i];
                array[i] = array[min];
                array[min] = dummy;
                min = i;
            }
            foreach (int value in array)
            {
                Console.Write($"{value} ");
            }
            myStopwatch.Stop();
            TimeSpan first5 = myStopwatch.Elapsed;
            using (StreamWriter streamwriter = new StreamWriter(filename, true))
            {
                streamwriter.Write("\nОтсортированный массив методом выбора: \n");
                for (int i = 0; i < array.Length; i++)
                {
                    streamwriter.Write(array[i] + " ");
                }
                streamwriter.Write("\n");
                streamwriter.Write($"\n\nВремя работы: {first5} Кол - во обменов: { count_switch}. Кол - во сравнений: { count_compare}");
            }
            Console.WriteLine("\nДанные о сортировке выбором: ");
            Console.WriteLine($"\nВремя работы: {first5}");
            Console.WriteLine($"\nКол-во обменов: {count_switch}. Кол-во сравнений: {count_compare}");
            Console.WriteLine("\n" + g);
        }
        static void Main(string[] args)
        {
            
            int n = 100000;
            int[] array = new int[n];
            int[] array2 = new int[n];
            int[] array3 = new int[n];
            int[] array4 = new int[n];
            int[] array5 = new int[n];
            int[] array6 = new int[n];
            Random r = new Random();
            Console.WriteLine("Исходный массив: ");
            for (int i = 0; i < n; i++) // массив заполнения случ. числами
            {
                array[i] = r.Next(100000);
                array2[i] = array[i];
                array3[i] = array[i];
                array4[i] = array[i];
                array5[i] = array[i];
                array6[i] = array[i];
                Console.Write(array[i] + " ");
            }            
            InsertionSort(array2);
            BubbleSort(array3);
            ShakerSort(array4);
            ShellSort(array5);
            SelectionSort(array6);           
        }
    }
}
