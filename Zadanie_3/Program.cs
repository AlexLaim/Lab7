using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Diagnostics;

namespace Zadanie_3
{
    class Program
    {
        static string act = string.Empty;
        static string g = new string('_', 80);
        static public Stopwatch ms = new Stopwatch();
        static TimeSpan time;
        static void Main(string[] args)
        {
            bool flag = true;                                 
            while (flag)
            {
                Console.WriteLine("Введите номер работы, которую хотите проверить: 2, 3, 4. Для выхода из программы введите 5");
                act = Console.ReadLine();
                switch (act)
                {
                    case "2":
                        bool flag2 = true;
                        while (flag2)
                        {
                            Console.WriteLine("Введите номер задания: 1-8. Чтобы вернуться назад введите 9");
                            act = Console.ReadLine();
                            switch (act)
                            {
                                case "1":
                                    int a, b, c;
                                    Console.WriteLine("Программа для решения квадратных уравнений вида: ax^2+bx+c=0");
                                    Console.WriteLine("Введите число a: ");
                                    a = int.Parse(Console.ReadLine());
                                    if (a == 0)
                                    {
                                        while (a == 0)
                                        {
                                            Console.WriteLine("Коэффициент а не может быть равен нулю! Введите число отличное от нуля.");
                                            a = int.Parse(Console.ReadLine());
                                        }
                                    }
                                    Console.WriteLine("Введите число b: ");
                                    b = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Введите число c: ");
                                    c = int.Parse(Console.ReadLine());
                                    ms.Start();
                                    double P = Math.Pow(b, 2) - 4 * a * c;
                                    double D = Math.Sqrt(P);
                                    if (P < 0)
                                    {
                                        Console.WriteLine("Уравнение не имеет корней!");
                                        Console.WriteLine("Представим результат в виде комплексных чисел");
                                        double z1 = Math.Sqrt(-P) / 2 * a;
                                        double z2 = -b / 2 * a;
                                        Console.WriteLine($"x1={z2}+{z1}i; \a x2={z2}-{z1}i");
                                    }
                                    if (D == 0)
                                    {
                                        double X1 = -b / 2 * a;
                                        Console.WriteLine($"Уравнение имеет 1 корень: x1 = {X1}");
                                    }
                                    double x1 = (-b - D) / 2 * a;
                                    if (x1 < 0 ^ x1 > 0 & D != 0)
                                    {
                                        Console.WriteLine($"Первый корень уравнения равен: {x1}");
                                    }
                                    double x2 = (-b + D) / 2 * a;
                                    if (x2 < 0 ^ x2 > 0 & D != 0)
                                    {
                                        Console.WriteLine($"Второй корень уравнения равен: {x2}");
                                    }
                                    ms.Stop();
                                    time = ms.Elapsed;
                                    Console.WriteLine($"\nЗатраченное время: {time}");
                                    break;
                                case "2":
                                    int i = 0;
                                    Console.WriteLine("Вычисление числа P по заданной формуле: P/4 = 1 - 1/3 + 1/5 - 1/7 + 1/9 .... +");
                                    Console.WriteLine("Введите кол-во слагаемых");
                                    int Count = int.Parse(Console.ReadLine());
                                    ms.Restart();
                                    double n = 3;
                                    double a2 = 1;
                                    while (i < Count)
                                    {
                                        a2 = a2 - (1 / n) + (1 / (n + 2));
                                        n = n + 4;
                                        i++;
                                    }
                                    double P2 = a2 * 4;
                                    Console.WriteLine($"Значение P = {P2}");
                                    ms.Stop();
                                    time = ms.Elapsed;
                                    Console.WriteLine($"\nЗатраченное время: {time}");
                                    break;
                                case "3":
                                    Console.WriteLine("Найдите кол-во четырехзначных чисел в ряду Фибоначчи");
                                    ms.Restart();
                                    double f0 = 0;
                                    double f1 = 1;
                                    while (f1 < 1000)
                                    {
                                        double f = f0 + f1;
                                        f0 = f1;
                                        f1 = f;
                                    }
                                    int i2 = 0;
                                    while (f1 < 10000)
                                    {
                                        double f = f0 + f1;
                                        f0 = f1;
                                        f1 = f;
                                        i2++;
                                    }
                                    Console.WriteLine($"Кол-во четырехзначных чисел = {i2}");
                                    ms.Stop();
                                    time = ms.Elapsed;
                                    Console.WriteLine($"\nЗатраченное время: {time}");
                                    break;
                                case "4":
                                    static int F(int k)
                                    {
                                        if (k == 0)
                                        {
                                            return 1;
                                        }
                                        else
                                        {
                                            return k * F(k - 1);
                                        }
                                    }
                                    Console.WriteLine("Программа для  вычисления  приближенного  значения  cos(x)  на основе формулы  ряда Тейлора");
                                    Console.WriteLine("Введите значение cos(x)");
                                    int x = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Введите количество слагаемых (q) ");
                                    int q = int.Parse(Console.ReadLine());
                                    if (q == 0)
                                    {
                                        while (q == 0)
                                        {
                                            Console.WriteLine("Количество слагаемых (q) не может быть равно нулю! Введите число отличное от нуля.");
                                            q = int.Parse(Console.ReadLine());
                                        }
                                    }
                                    ms.Restart();
                                    double a3;
                                    double cos = 1;
                                    int b2 = 2;
                                    int z = -1;
                                    int j = 0;
                                    int k = 2;
                                    do
                                    {
                                        a3 = (Math.Pow(x, b2) / F(k));
                                        cos += a3 * z;
                                        b2 += 2;
                                        k += 2;
                                        z *= -1;
                                        j++;
                                    } while (Math.Abs(a3) > q);
                                    Console.WriteLine($"cos(x) =  {cos}");
                                    Console.WriteLine($"Количество учтенных слагаемых: {j} ");
                                    ms.Stop();
                                    time = ms.Elapsed;
                                    Console.WriteLine($"\nЗатраченное время: {time}");
                                    break;
                                case "5":
                                    double x3, y3, z3;
                                    Console.WriteLine("Программа выводящая на экран все комбинации  натуральных  чисел x, y, z,таких что x^3 + y^3 + z^3 = N");
                                    Console.WriteLine("Введите число N");
                                    double N = double.Parse(Console.ReadLine());
                                    ms.Restart();
                                    int j2 = 0;
                                    for (x3 = 0; x3 <= N; x3++)
                                    {

                                        for (y3 = 0; y3 <= N; y3++)
                                        {

                                            for (z3 = 0; z3 <= N; z3++)
                                            {

                                                double sum = x3 * x3 * x3 + y3 * y3 * y3 + z3 * z3 * z3;
                                                if (sum == N)
                                                {
                                                    Console.WriteLine($"{x3}^3+{y3}^3+{z3}^3 = {N}");
                                                    j2++;
                                                }
                                            }
                                        }
                                    }
                                    if (j2 == 0)
                                    {
                                        Console.WriteLine("No such combinations!");
                                    }
                                    ms.Stop();
                                    time = ms.Elapsed;
                                    Console.WriteLine($"\nЗатраченное время: {time}");
                                    break;
                                case "6":
                                    Console.WriteLine("Введите число N = от 1 до 100");
                                    int N2 = int.Parse(Console.ReadLine());
                                    if (N2 < 1 ^ N2 > 100)
                                    {
                                        while (N2 < 1 ^ N2 > 100)
                                        {
                                            Console.WriteLine("Ошибка! Введите число от 1 до 100");
                                            N2 = int.Parse(Console.ReadLine());
                                        }
                                    }
                                    ms.Restart();
                                    if (N2 % 10 == 1 & (N2 > 11 || N2 < 2))
                                    {
                                        Console.WriteLine($"{N2} год");
                                    }
                                    else if (N2 % 10 == 2 || N2 % 10 == 3 || N2 % 10 == 4)
                                    {
                                        Console.WriteLine($"{N2} года");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"{N2} лет");
                                    }
                                    ms.Stop();
                                    time = ms.Elapsed;
                                    Console.WriteLine($"\nЗатраченное время: {time}");
                                    break;
                                case "7":
                                    double a7, b7, c7, x7;
                                    Console.WriteLine("Введите первое вещественное число a:");
                                    a7 = double.Parse(Console.ReadLine());
                                    Console.WriteLine("Введите первое вещественное число b:");
                                    b7 = double.Parse(Console.ReadLine());
                                    Console.WriteLine("Введите первое вещественное число c:");
                                    c7 = double.Parse(Console.ReadLine());
                                    ms.Restart();
                                    if (b7 < c7 & c7 < a7)
                                    {
                                        x7 = a7 - b7;
                                        Console.WriteLine($"Разность максимального и минимального чисел равна: {x7}");
                                    }
                                    else if (c7 < b7 & b7 < a7)
                                    {
                                        x7 = a7 - c7;
                                        Console.WriteLine($"Разность максимального и минимального чисел равна: {x7}");
                                    }
                                    else if (c7 < a7 & a7 < b7)
                                    {
                                        x7 = b7 - c7;
                                        Console.WriteLine($"Разность максимального и минимального чисел равна: {x7}");
                                    }
                                    else if (a7 < c7 & c7 < b7)
                                    {
                                        x7 = b7 - a7;
                                        Console.WriteLine($"Разность максимального и минимального чисел равна: {x7}");
                                    }
                                    else if (b7 < a7 & a7 < c7)
                                    {
                                        x7 = c7 - b7;
                                        Console.WriteLine($"Разность максимального и минимального чисел равна: {x7}");
                                    }
                                    else if (a7 < b7 & b7 < c7)
                                    {
                                        x7 = c7 - a7;
                                        Console.WriteLine($"Разность максимального и минимального чисел равна: {x7}");
                                    }
                                    else if (a7 == b7 && a7 == c7)
                                    {
                                        Console.WriteLine("Все числа равны");
                                    }
                                    else if (a7 == b7 & b7 < c7)
                                    {
                                        x7 = c7 - a7;
                                        Console.WriteLine($"Разность максимального и минимального чисел равна: {x7}");
                                    }
                                    else if (b7 == c7 & b7 < a7)
                                    {
                                        x7 = a7 - c7;
                                        Console.WriteLine($"Разность максимального и минимального чисел равна: {x7}");
                                    }
                                    else if (a7 == c7 & c7 < b7)
                                    {
                                        x7 = b7 - c7;
                                        Console.WriteLine($"Разность максимального и минимального чисел равна: {x7}");
                                    }
                                    ms.Stop();
                                    time = ms.Elapsed;
                                    Console.WriteLine($"\nЗатраченное время: {time}");
                                    break;
                                case "8":
                                    Console.WriteLine("Программа выводит на экран все двузначные числа, сумма цифр которых делится на 5");
                                    ms.Restart();
                                    int i7;
                                    for (i7 = 10; i7 <= 99; i7++)
                                    {
                                        if (((i7 / 10) + (i7 % 10)) % 5 == 0) Console.WriteLine(i7);
                                    }
                                    ms.Stop();
                                    time = ms.Elapsed;
                                    Console.WriteLine($"\nЗатраченное время: {time}");
                                    break;
                                case "9":
                                    flag2 = false;
                                    break;
                                default:
                                    Console.WriteLine("Неизвестное действие.");
                                    break;
                            }
                        }
                        break;
                    case "3":
                        bool flag3 = true;
                        while (flag3)
                        {
                            Console.WriteLine("Введите номер задания: 1-10. Чтобы вернуться назад введите 0");
                            act = Console.ReadLine();
                            switch (act)
                            {
                                case "1":
                                    Console.WriteLine("Программа, которая запрашивает число элементов массива, после чего  создает  массив, заполняет  его  случайными  целыми  числами и выводит его на экран");
                                    Console.WriteLine("Введите кол-во эллементов массива: ");
                                    int x = int.Parse(Console.ReadLine());
                                    int[] myArray = new int[x];
                                    int j = 0;
                                    if (x == 0)
                                    {
                                        while (x == 0)
                                        {
                                            Console.WriteLine("Кол-во эллементов массива не может быть равно нулю! Введите число отличное от нуля.");
                                            x = int.Parse(Console.ReadLine());
                                        }
                                    }
                                    ms.Restart();
                                    Random rand = new Random();
                                    Console.WriteLine("Вывод элементов массива заполненного случайными числами в диапазоне от -30 до 45 ");
                                    for (int i = 0; i < myArray.Length; i++)
                                    {
                                        myArray[i] = rand.Next(-35, 45);
                                        Console.Write("{0}\t", myArray[i], 4);
                                        j++;
                                        while (j == 10)
                                        {
                                            Console.WriteLine();
                                            j = 0;
                                        }
                                    }
                                    Console.WriteLine("________________________________________________________________________________");
                                    Console.WriteLine("Вывод массива в обратном порядке игнорируя отрицательные значения");
                                    for (int i = myArray.Length - 1; i >= 0; i--)
                                    {
                                        if (myArray[i] >= 0)
                                        {

                                            Console.Write("{0}\t", myArray[i], 4);
                                            j++;
                                            while (j == 10)
                                            {
                                                Console.WriteLine();
                                                j = 0;
                                            }
                                        }
                                    }
                                    Console.WriteLine();
                                    ms.Stop();
                                    time = ms.Elapsed;
                                    Console.WriteLine($"\nЗатраченное время: {time}");
                                    break;
                                case "2":
                                    Console.WriteLine("Программа, которая формирует новую строку на основе исходной, в которой после каждого слова в скобках указан  номер  слова  в  предложении.");
                                    Console.WriteLine("Введите текст: ");
                                    string str = Console.ReadLine();
                                    ms.Restart();
                                    str = str.Insert(str.Length, ".");
                                    Console.WriteLine($"Ваш текст: {str}");
                                    Console.WriteLine(g);
                                    Console.WriteLine("Измененный текст с помощью массива: ");
                                    int y = 1, x2 = 1;
                                    for (int i = 0; i < str.Length; i++)
                                    {
                                        if (char.IsLetter(str[i]) && (str[i + 1] == ' ' || str[i + 1] == '-' || str[i + 1] == ',' || str[i + 1] == '.'))
                                        {
                                            Console.Write(str[i] + $"({x2++})");
                                        }
                                        else
                                        {
                                            Console.Write(str[i]);
                                        }
                                    }
                                    Console.WriteLine();
                                    Console.WriteLine(g);
                                    Console.WriteLine("Измененный текст с помощью строки: ");
                                    string[] mas = str.Split(new char[] { ' ' });
                                    for (int i = 0; i < mas.Length; i++)
                                    {
                                        if (mas[i].EndsWith(",") || mas[i].EndsWith("."))
                                        {
                                            mas[i] = mas[i].Insert(mas[i].Length, $"({y++}) ");
                                        }
                                        else if (mas[i] == "-")
                                            mas[i] = "- ";
                                        else
                                        {
                                            mas[i] = mas[i].Insert(mas[i].Length, $"({y++}) ");
                                        }
                                    }
                                    for (int i = 0; i < mas.Length; i++)
                                    {
                                        Console.Write(mas[i]);
                                    }
                                    ms.Stop();
                                    time = ms.Elapsed;
                                    Console.WriteLine($"\nЗатраченное время: {time}");
                                    break;
                                case "3":
                                    Console.WriteLine("Программа циклического сдвига массива на k позиций влево.");
                                    Console.WriteLine("Введите кол-во элементов массива: ");
                                    int x3 = int.Parse(Console.ReadLine());
                                    if (x3 == 0)
                                    {
                                        while (x3 == 0)
                                        {
                                            Console.WriteLine("Кол-во эллементов массива не может быть равно нулю! Введите число отличное от нуля.");
                                            x3 = int.Parse(Console.ReadLine());
                                        }
                                    }
                                    Console.WriteLine("Введите число k элементов на которые будет сдвинут массив (влево): ");
                                    int k = int.Parse(Console.ReadLine());
                                    int[] myArray3 = new int[x3];
                                    if (k == 0)
                                    {
                                        while (k == 0)
                                        {
                                            Console.WriteLine("k = 0. Массив останется без изменений. Введите отличное от 0 число.");
                                            k = int.Parse(Console.ReadLine());
                                        }
                                    }
                                    ms.Restart();
                                    Random rand3 = new Random();
                                    Console.WriteLine("Начальный массив заполненый рандомными значениями до 10-ти: ");
                                    for (int i = 0; i < myArray3.Length; i++)
                                    {
                                        myArray3[i] = rand3.Next(1, 10);
                                        Console.Write(" " + myArray3[i]);
                                    }
                                    Console.WriteLine();
                                    Console.WriteLine("________________________________________________________________________________");
                                    Console.WriteLine("Измененный массив: ");
                                    for (int i = 0; i < k; ++i)
                                    {
                                        int aLast = myArray3[0];
                                        for (int j3 = 0; j3 < x3 - 1; j3++)
                                            myArray3[j3] = myArray3[j3 + 1];
                                        myArray3[x3 - 1] = aLast;
                                    }
                                    for (int i = 0; i < x3; ++i)
                                        Console.Write(" " + myArray3[i]);
                                    Console.WriteLine();
                                    ms.Stop();
                                    time = ms.Elapsed;
                                    Console.WriteLine($"\nЗатраченное время: {time}");
                                    break;
                                case "4":
                                    Console.WriteLine("Программа для поэлементного сложения и вычитания двумерных массивов, а после выводит среднее значение всех эллементов входных массивов.");
                                    int[,] myArray4 = new int[3, 3];
                                    Random rand4 = new Random();
                                    Console.WriteLine("Первый массив: ");
                                    for (int i = 0; i < myArray4.GetLength(0); i++)
                                    {
                                        for (int j4 = 0; j4 < myArray4.GetLength(1); j4++)
                                        {
                                            myArray4[i, j4] = rand4.Next(1, 10);
                                            Console.Write(" " + myArray4[i, j4]);
                                        }
                                        Console.WriteLine();
                                    }
                                    Console.WriteLine(g);

                                    int[,] myArray2 = new int[3, 3];
                                    Console.WriteLine("Второй массив: ");
                                    for (int i = 0; i < myArray2.GetLength(0); i++)
                                    {
                                        for (int j4 = 0; j4 < myArray2.GetLength(1); j4++)
                                        {
                                            myArray2[i, j4] = rand4.Next(1, 10);
                                            Console.Write(" " + myArray2[i, j4]);
                                        }
                                        Console.WriteLine();
                                    }
                                    Console.WriteLine(g);
                                    Console.WriteLine("Введите действие которое вам необходимо: '+','-' или 'Sr' (Среднее значение): ");
                                    string opt = Console.ReadLine();
                                    switch (opt)
                                    {
                                        case "+":
                                            ms.Restart();
                                            Console.WriteLine("Сумма массивов равна: ");
                                            int[,] Sum = new int[3, 3];
                                            for (int i = 0; i < Sum.GetLength(0); i++)
                                            {
                                                for (int j4 = 0; j4 < Sum.GetLength(1); j4++)
                                                {
                                                    Sum[i, j4] = myArray4[i, j4] + myArray2[i, j4];
                                                    Console.Write("  " + Sum[i, j4]);
                                                }
                                                Console.WriteLine();
                                            }
                                            ms.Stop();
                                            time = ms.Elapsed;
                                            Console.WriteLine($"\nЗатраченное время: {time}");
                                            Console.WriteLine(g);
                                            break;
                                        case "-":
                                            ms.Restart();
                                            Console.WriteLine("Разность массивов равна: ");
                                            int[,] Dif = new int[3, 3];
                                            for (int i = 0; i < Dif.GetLength(0); i++)
                                            {
                                                for (int j4 = 0; j4 < Dif.GetLength(1); j4++)
                                                {
                                                    Dif[i, j4] = myArray4[i, j4] - myArray2[i, j4];
                                                    Console.Write("  " + Dif[i, j4]);
                                                }
                                                Console.WriteLine();
                                            }
                                            ms.Stop();
                                            time = ms.Elapsed;
                                            Console.WriteLine($"\nЗатраченное время: {time}");
                                            Console.WriteLine(g);
                                            break;
                                        case "Sr":
                                            ms.Restart();
                                            Console.WriteLine("Среднее значение массивов равно: ");
                                            int[,] Sr = new int[3, 3];
                                            for (int i = 0; i < Sr.GetLength(0); i++)
                                            {
                                                for (int j4 = 0; j4 < Sr.GetLength(1); j4++)
                                                {
                                                    Sr[i, j4] = (myArray4[i, j4] + myArray2[i, j4]) / 2;
                                                    Console.Write("  " + Sr[i, j4]);
                                                }
                                                Console.WriteLine();
                                            }
                                            ms.Stop();
                                            time = ms.Elapsed;
                                            Console.WriteLine($"\nЗатраченное время: {time}");
                                            Console.WriteLine(g);
                                            break;
                                        default:
                                            Console.WriteLine("Программа не может распознать данное действие.");
                                            break;
                                    }
                                    break;
                                case "5":
                                    Console.WriteLine("Программа перемножения двух матриц 5х5");
                                    ms.Restart();
                                    int[,] myArray5 = new int[5, 5];
                                    Random rand5 = new Random();
                                    Console.WriteLine("Первая матрица: ");
                                    for (int i = 0; i < myArray5.GetLength(0); i++)
                                    {
                                        for (int j5 = 0; j5 < myArray5.GetLength(1); j5++)
                                        {
                                            myArray5[i, j5] = rand5.Next(1, 10);
                                            Console.Write(" " + myArray5[i, j5]);
                                        }
                                        Console.WriteLine();
                                    }
                                    Console.WriteLine(g);

                                    int[,] myArray1 = new int[5, 5];
                                    Console.WriteLine("Вторая матрица: ");
                                    for (int i = 0; i < myArray1.GetLength(0); i++)
                                    {
                                        for (int j5 = 0; j5 < myArray1.GetLength(1); j5++)
                                        {
                                            myArray1[i, j5] = rand5.Next(1, 10);
                                            Console.Write(" " + myArray1[i, j5]);
                                        }
                                        Console.WriteLine();
                                    }
                                    Console.WriteLine(g);
                                    Console.WriteLine("Перемножение матриц");
                                    int[,] Mul = new int[5, 5];                        
                                    for (int r = 0; r < myArray5.GetLength(0); r++)
                                    {
                                        for (int c = 0; c < myArray5.GetLength(1); c++)
                                        {
                                            for (int k5 = 0; k5 < myArray5.GetLength(0); k5++)
                                            {
                                                Mul[r, c] += myArray5[r, k5] * myArray1[k5, c];
                                            }
                                        }
                                    }
                                    for (int r = 0; r < myArray5.GetLength(0); r++)
                                    {
                                        for (int c = 0; c < myArray5.GetLength(1); c++)
                                        {
                                            Console.Write(" " + Mul[r, c] + " ");
                                        }
                                        Console.WriteLine();
                                    }
                                    ms.Stop();
                                    time = ms.Elapsed;
                                    Console.WriteLine($"\nЗатраченное время: {time}");
                                    break;
                                case "6":
                                    static int SumIter(int[] myArray)
                                    {

                                        int sum = 0;

                                        for (int i = 0; i < myArray.Length; i++)
                                        {
                                            sum += myArray[i]; // sum = sum + mas[i]
                                        }

                                        return sum;
                                    }
                                    static int MinIter(int[] myArray)
                                    {
                                        int min = myArray[0];
                                        for (int i = 1; i < myArray.Length; i++)
                                        {
                                            if (myArray[i] < min)
                                            {
                                                min = myArray[i];
                                            }
                                        }
                                        return min;
                                    }

                                    //Рекурсия
                                    static int SumRec(int[] myArray, int i = 0)
                                    {
                                        if (i >= myArray.Length)
                                            return 0;
                                        return myArray[i] + SumRec(myArray, i + 1);
                                    }
                                    static int MinRec(int[] myArray, int pos, int min)
                                    {
                                        if (pos == myArray.Length)
                                        {
                                            return min;
                                        }
                                        if (myArray[pos] < min)
                                        {
                                            min = myArray[pos];
                                        }
                                        pos++;
                                        return MinRec(myArray, pos, min);
                                    }
                                    Console.WriteLine("Программа демонстрирующая работу следующих функций: sumIterative, sumRecursive, minIterative, minRecursive");
                                    Console.WriteLine("Введите кол-во элементов массива: ");
                                    int x6 = int.Parse(Console.ReadLine());
                                    if (x6 == 0)
                                    {
                                        while (x6 == 0)
                                        {
                                            Console.WriteLine("Кол-во эллементов массива не может быть равно нулю! Введите число отличное от нуля.");
                                            x6 = int.Parse(Console.ReadLine());
                                        }
                                    }
                                    ms.Restart();
                                    int[] myArray6 = new int[x6];
                                    int j6 = 0;
                                    Random rand6 = new Random();
                                    Console.WriteLine("Массив: ");
                                    for (int i = 0; i < myArray6.Length; i++)
                                    {
                                        myArray6[i] = rand6.Next(1, 10);
                                        Console.Write(" " + myArray6[i]);
                                        j6++;
                                        while (j6 == 5)
                                        {
                                            Console.WriteLine();
                                            j6 = 0;
                                        }
                                    }
                                    Console.WriteLine();
                                    Console.WriteLine(g);
                                    Console.WriteLine("sumIterative = " + SumIter(myArray6));
                                    Console.WriteLine(g);
                                    Console.WriteLine("minIterative = " + MinIter(myArray6));
                                    Console.WriteLine(g);
                                    Console.WriteLine("sumRecursive = " + SumRec(myArray6));
                                    Console.WriteLine(g);
                                    Console.WriteLine("minRecursive = " + MinRec(myArray6, 0, myArray6[0]));
                                    ms.Stop();
                                    time = ms.Elapsed;
                                    Console.WriteLine($"\nЗатраченное время: {time}");
                                    break;
                                case "7":
                                    Console.WriteLine("Программа демонстрирует рекурсивную  функцию  для  нахождения  n-ого  члена  ряда Фибоначчи по формулам, приведенным в лабораторной работе No2");
                                    Console.WriteLine("Введите номер элемента значение которого вы хотите знать.");
                                    int x7 = int.Parse(Console.ReadLine());
                                    if (x7 == 0)
                                    {
                                        while (x7 == 0)
                                        {
                                            Console.WriteLine("Счёт элементов начинается с 1!");
                                            x7 = int.Parse(Console.ReadLine());
                                        }
                                    }
                                    ms.Restart();
                                    double rec(int x7)
                                    {

                                        if (x7 == 1 || x7 == 2)
                                        {
                                            return 1;
                                        }
                                        else
                                        {
                                            return rec(x7 - 1) + rec(x7 - 2);
                                        }
                                    }
                                    Console.WriteLine($"Значение элемента под номером {x7} = {rec(x7)}");
                                    ms.Stop();
                                    time = ms.Elapsed;
                                    Console.WriteLine($"\nЗатраченное время: {time}");
                                    break;
                                case "8":
                                    static double RecDet(int[,] myArray)
                                    {
                                        if (myArray.Length == 1)
                                            return myArray[0, 0];
                                        if (myArray.Length == 4)
                                            return myArray[0, 0] * myArray[1, 1] - myArray[1, 0] * myArray[0, 1];
                                        else
                                        {
                                            double Det = 0;

                                            for (int i = 0; i < myArray.GetLength(0); i++)
                                            {
                                                for (int j = 0; j < myArray.GetLength(1); j++)
                                                {
                                                    int[,] m = Minor(myArray, i, j);
                                                    Det += Math.Pow(-1, i) * myArray[0, i] * RecDet(m);
                                                }
                                            }
                                            return Det;
                                        }
                                    }
                                    static int[,] Minor(int[,] myArray, int col, int lin)
                                    {
                                        int[,] min = new int[myArray.GetLength(0) - 1, myArray.GetLength(1) - 1];
                                        int x = 0, z = 0;
                                        for (int i = 0; i < myArray.GetLength(0); i++)
                                        {
                                            z = 0;
                                            if (i == col)
                                                continue;
                                            for (int j = 0; j < myArray.GetLength(1); j++)
                                            {
                                                if (j == lin)
                                                    continue;
                                                min[x, z] = myArray[i, j];
                                                z++;
                                            }
                                            x++;
                                        }
                                        return min;
                                    }
                                    Console.WriteLine("Программа рекурсивно вычисляющая определитель матрицы.");
                                    Console.WriteLine("Введите двумерный массив вида [N,N]");
                                    Console.WriteLine("Введите N: ");
                                    int N = int.Parse(Console.ReadLine());
                                    ms.Restart();
                                    int[,] myArray8 = new int[N, N];
                                    Random rand8 = new Random();
                                    Console.WriteLine("Ваша матрица: ");
                                    for (int i = 0; i < myArray8.GetLength(0); i++)
                                    {
                                        for (int j8 = 0; j8 < myArray8.GetLength(1); j8++)
                                        {
                                            myArray8[i, j8] = rand8.Next(1, 10);
                                            Console.Write(" " + myArray8[i, j8]);
                                        }
                                        Console.WriteLine();
                                    }
                                    Console.WriteLine(g);
                                    Console.WriteLine("Определитель матрицы равен:" + RecDet(myArray8));
                                    ms.Stop();
                                    time = ms.Elapsed;
                                    Console.WriteLine($"\nЗатраченное время: {time}");
                                    break;
                                case "9":
                                    Console.WriteLine("Программа заполняющая и отображающая на экране двумерный массив 9х9");
                                    Console.WriteLine(g);
                                    ms.Restart();
                                    int[,] myArray9 = new int[9, 9];
                                    int x9 = 1, k9 = 0;
                                    for (int j9 = 0; j9 < 9; j9++)
                                    {
                                        for (int i = 0; i < 9; i++)
                                        {
                                            if ((j9 < i || j9 > myArray9.GetLength(0) - 1 - i) && i < myArray9.GetLength(0) / 2 + 1 || (j9 > i || j9 < myArray9.GetLength(0) - 1 - i) && i >= myArray9.GetLength(0) / 2 + 1)
                                            {
                                                myArray9[i, j9] = x9;
                                                x9++;
                                            }
                                        }
                                    }
                                    for (int i = 0; i < myArray9.GetLength(0); i++)
                                    {
                                        for (int j9 = 0; j9 < myArray9.GetLength(1); j9++)
                                        {
                                            Console.Write("\t" + myArray9[i, j9]);
                                            k9++;
                                            while (k9 == 9)
                                            {
                                                Console.WriteLine();
                                                k9 = 0;
                                            }
                                        }
                                    }
                                    ms.Stop();
                                    time = ms.Elapsed;
                                    Console.WriteLine($"\nЗатраченное время: {time}");
                                    break;
                                case "10":
                                    Console.WriteLine("программа, которая выводит на экран TRUE, если все суммы симметричных элементов массива равны, иначе – FALSE.");
                                    Console.WriteLine("Введите кол-во эллементов массива: ");
                                    int x0 = int.Parse(Console.ReadLine());
                                    int[] myArray0 = new int[x0];
                                    if (x0 == 0)
                                    {
                                        while (x0 == 0)
                                        {
                                            Console.WriteLine("Кол-во эллементов массива не может быть равно нулю! Введите число отличное от нуля.");
                                            x0 = int.Parse(Console.ReadLine());
                                        }
                                    }
                                    if (x0 % 2 == 1)
                                    {
                                        while (x0 % 2 == 1)
                                        {
                                            Console.WriteLine("Кол-во эллементов массива должно быть четным! Введите четное число.");
                                            x0 = int.Parse(Console.ReadLine());
                                        }
                                    }
                                    for (int i = 0; i < myArray0.Length; i++)
                                    {
                                        Console.WriteLine("Задайте значение элемента массива ");
                                        int b = int.Parse(Console.ReadLine());
                                        myArray0[i] = b;
                                    }
                                    ms.Restart();
                                    Console.WriteLine("Исходный массив: ");
                                    int k0 = 0;
                                    for (int i = 0; i < myArray0.Length; i++)
                                    {
                                        Console.Write(" " + myArray0[i]);
                                        k0++;
                                        while (k0 == 10)
                                        {
                                            Console.WriteLine();
                                            k0 = 0;
                                        }
                                    }
                                    Console.WriteLine();
                                    Console.WriteLine(g);
                                    int a = myArray0[0] + myArray0[x0 - 1];  // симметрия {1, 2, 3, 1, 2, 3}  0+5=1+4=2+3
                                                                          //индексы    0  1  2  3  4  5
                                    int o = 0, q1, p = 0;
                                    for (int i = 1; i < myArray0.Length; i++)
                                    {
                                        q1 = myArray0[0 + i] + myArray0[x0 - 1 - i];
                                        if (q1 == a)
                                        {
                                            p++;
                                        }
                                        if (q1 != a)
                                        {
                                            o++;
                                            p--;
                                        }
                                        if (p == 1)
                                        {
                                            Console.WriteLine("True");
                                        }
                                        if (o == 1)
                                        {
                                            Console.WriteLine("False");
                                        }
                                    }
                                    ms.Stop();
                                    time = ms.Elapsed;
                                    Console.WriteLine($"\nЗатраченное время: {time}");
                                    break;
                                case "0":
                                    flag3 = false;
                                    break;
                                default:
                                    Console.WriteLine("Неизвестное действие.");
                                    break;
                            }
                        }
                        break;
                    case "4":
                        bool flag4 = true;
                        while (flag4)
                        {
                            Console.WriteLine("Введите номер задания: 1-9. Чтобы вернуться назад введите 0");
                            act = Console.ReadLine();
                            switch (act)
                            {
                                case "1":
                                    Console.WriteLine("Программа, которая выводит на консоль  все символы, которые входят в текст.");
                                    Console.WriteLine("Введите текст: ");
                                    string str = Console.ReadLine();
                                    str = str.Insert(str.Length, ".");
                                    Console.WriteLine($"Ваш текст: {str}");
                                    Console.WriteLine(g);
                                    ms.Restart();
                                    Console.WriteLine("Вывод каждого символа строки отдельно с помощью массива: ");
                                    char[] mas = str.ToCharArray();
                                    for (int i = 0; i < mas.Length; i++)
                                    {
                                        Console.WriteLine(mas[i]);
                                    }
                                    Console.WriteLine(g);
                                    Console.WriteLine("Вывод каждого символа строки отдельно с помощью строки: ");                                    
                                    for (int i = 0; i < str.LastIndexOf('.') + 1; i++)
                                    {
                                        Console.WriteLine(str[i]);
                                    }
                                    ms.Stop();
                                    time = ms.Elapsed;
                                    Console.WriteLine($"\nЗатраченное время: {time}");
                                    break;
                                case "2":
                                    Console.WriteLine("Программа, которая формирует новую строку на основе исходной, в которой после каждого слова в скобках указан  номер  слова  в  предложении.");
                                    Console.WriteLine("Введите текст: ");
                                    string str2 = Console.ReadLine();
                                    str2 = str2.Insert(str2.Length, ".");
                                    Console.WriteLine($"Ваш текст: {str2}");
                                    Console.WriteLine(g);
                                    ms.Restart();
                                    Console.WriteLine("Измененный текст с помощью массива: ");
                                    int y = 1, x = 1;
                                    for (int i = 0; i < str2.Length; i++)
                                    {
                                        if (char.IsLetter(str2[i]) && (str2[i + 1] == ' ' || str2[i + 1] == '-' || str2[i + 1] == ',' || str2[i + 1] == '.'))
                                        {
                                            Console.Write(str2[i] + $"({x++})");
                                        }
                                        else
                                        {
                                            Console.Write(str2[i]);
                                        }
                                    }
                                    Console.WriteLine();
                                    Console.WriteLine(g);
                                    Console.WriteLine("Измененный текст с помощью строки: ");
                                    string[] mas2 = str2.Split(new char[] { ' ' });
                                    for (int i = 0; i < mas2.Length; i++)
                                    {
                                        if (mas2[i].EndsWith(",") || mas2[i].EndsWith("."))
                                        {
                                            mas2[i] = mas2[i].Insert(mas2[i].Length, $"({y++}) ");
                                        }
                                        else if (mas2[i] == "-")
                                            mas2[i] = "- ";
                                        else
                                        {
                                            mas2[i] = mas2[i].Insert(mas2[i].Length, $"({y++}) ");
                                        }
                                    }
                                    for (int i = 0; i < mas2.Length; i++)
                                    {
                                        Console.Write(mas2[i]);
                                    }
                                    ms.Stop();
                                    time = ms.Elapsed;
                                    Console.WriteLine($"\nЗатраченное время: {time}");
                                    break;
                                case "3":
                                    Console.WriteLine("Программа, которая формирует новую строку на основе исходной, в которой порядок слов меняется.");
                                    Console.WriteLine("Введите текст: ");
                                    string str1 = Console.ReadLine();
                                    ms.Restart();
                                    str1 = str1.Insert(str1.Length, ".");
                                    string[] str3 = str1.Split(" ");
                                    string str4 = str1;
                                    Console.WriteLine($"Ваш текст: {str1}");
                                    Console.WriteLine(g);
                                    string[] mas3 = str1.Split(new char[] { ' ' });
                                    string a = string.Empty;
                                    Console.WriteLine("При помощи строки:");
                                    for (int i = mas3.Length - 1; i >= 0; i--)
                                    {
                                        a += mas3[i] + " ";
                                    }
                                    Console.Write(a);
                                    Console.WriteLine();
                                    Console.WriteLine(g);
                                    Console.WriteLine("При помощи StringBuilder:");
                                    StringBuilder sb = new StringBuilder(str3.Length);
                                    for (int i = str3.Length; i-- != 0;)
                                    {
                                        sb.Append(str3[i]);
                                        Console.Write(str3[i] + " ");
                                    }
                                    Console.WriteLine();
                                    Console.WriteLine(g);
                                    Console.WriteLine("При помощи массива:");
                                    string[] st = str4.Split(new char[] { ' ' });
                                    Array.Reverse(st);
                                    for (int i = 0; i < st.Length; i++)
                                    {
                                        if (i == st.Length - 1)
                                        {
                                            Console.Write(st[i]);
                                        }
                                        else
                                        {
                                            Console.Write(st[i] + ' ');
                                        }
                                    }
                                    ms.Stop();
                                    time = ms.Elapsed;
                                    Console.WriteLine($"\nЗатраченное время: {time}");
                                    break;
                                case "4":
                                    Console.WriteLine("Программа, которая выводит все строки, в которых содержится хотя бы одно слово, оканчивающееся на “.com”, а также номер строки, содержащей наименьшее число пробелов");
                                    int length = 7, number = 1;
                                    string[] s = new string[length];
                                    for (int i = 0; i < s.Length; i++)
                                    {
                                        Console.Write(number + ". ");
                                        Console.WriteLine("Введите строку: ");
                                        s[i] = Console.ReadLine();
                                        number++;
                                        Console.WriteLine(g);
                                    }
                                    ms.Restart();
                                    Console.WriteLine(g);
                                    number = 1;
                                    Console.WriteLine("Ваши строки: ");
                                    foreach (string str5 in s)
                                    {
                                        Console.Write(number + ". ");
                                        Console.WriteLine(str5);
                                        number++;
                                    }
                                    Console.WriteLine(g);
                                    Console.WriteLine("Строки в которых содержится .com с помощью метода регулярных выражений: ");
                                    number = 1;
                                    foreach (string str5 in s)
                                    {
                                        Regex regex = new Regex(@"^.*.*.\.com$", RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);
                                        MatchCollection matches = regex.Matches(str5);
                                        if (matches.Count > 0)
                                        {
                                            foreach (Match match in matches)
                                            {
                                                Console.WriteLine($"{number}.  {match.Value}");
                                            }
                                        }
                                        if (str5.Equals(".com", StringComparison.InvariantCultureIgnoreCase))
                                        {
                                            Console.WriteLine($"{number} {str5}");
                                        }
                                        number++;
                                    }
                                    Console.WriteLine(g);
                                    Console.WriteLine("Строки в которых содержится .com с помощью метода строк: ");
                                    number = 1;
                                    foreach (string str5 in s)
                                    {
                                        if (str5.EndsWith(".com", StringComparison.InvariantCultureIgnoreCase))
                                        {
                                            Console.WriteLine($"{number} {str5}");
                                        }
                                        number++;
                                    }
                                    Console.WriteLine(g);
                                    Console.WriteLine("Строки в которых содержится .com с помощью метода массива: ");
                                    number = 1;
                                    for (int i = 0; i < s.Length; i++)
                                    {
                                        string temp = s[i].ToLower();
                                        for (int j = 0; j < s[i].Length - 3; j++)
                                        {
                                            if (temp[j].Equals('.') & temp[j + 1].Equals('c') & temp[j + 2].Equals('o') & temp[j + 3].Equals('m'))
                                            {
                                                Console.WriteLine($"{number} {temp}");
                                            }
                                        }
                                        number++;
                                    }
                                    Console.WriteLine(g);
                                    Console.WriteLine("Строка в которой содержится меньше всего пробелов: ");                                  
                                    int minindex = 0;
                                    for (int i = 0, space = 100; i < 7; i++)
                                    {
                                        string temp2 = s[i];
                                        for (int j = 0, spaces = 0; j < temp2.Length; j++)
                                            if (temp2[j] == ' ')
                                            {
                                                spaces++;
                                            }
                                            else if (j == temp2.Length - 1)
                                            {
                                                if (spaces < space)
                                                {
                                                    space = spaces;
                                                    spaces = 0;
                                                    minindex = i + 1;
                                                }
                                            }
                                    }
                                    Console.WriteLine($"Номер строки с наименьшим количеством пробелов: {minindex}");
                                    ms.Stop();
                                    time = ms.Elapsed;
                                    Console.WriteLine($"\nЗатраченное время: {time}");
                                    break;
                                case "5":
                                    Console.WriteLine("Программа, находящая в тексте все слова, которые начинаются с большого латинского символа (от A до Z) и заканчиваются 2 цифрами");
                                    Console.WriteLine("Введите текст");
                                    string s5 = Console.ReadLine();
                                    ms.Restart();
                                    Console.WriteLine(g);
                                    Console.WriteLine("Ваш текст: " + s5);
                                    Console.WriteLine(g);
                                    //REGEX
                                    Console.WriteLine("Поиск слов с помощью Regex: ");
                                    //Regex regex = new Regex(@"\b[A-Z]{1}[a-z]*\d{2}\b");
                                    Regex regex5 = new Regex(@"\b[A-Z]{1}.*\d{2}\b");
                                    MatchCollection matches5 = regex5.Matches(s5);
                                    if (matches5.Count > 0)
                                    {
                                        foreach (Match match in matches5)
                                        {
                                            Console.WriteLine(match.Value);
                                        }
                                    }
                                    Console.WriteLine(g);
                                    //ARRAY
                                    Console.WriteLine("Поиск слов с помощью Array: ");
                                    string[] array = s5.Split(" ");

                                    for (int i = 0; i < array.Length; i++)
                                    {
                                        string temp = array[i];
                                        if (Char.IsUpper(temp[0]) && Char.IsNumber(temp[temp.Length - 1]) && Char.IsNumber(temp[temp.Length - 2]))
                                        {
                                            Console.WriteLine(array[i]);
                                        }
                                    }
                                    ms.Stop();
                                    time = ms.Elapsed;
                                    Console.WriteLine($"\nЗатраченное время: {time}");
                                    break;
                                case "6":
                                    Console.WriteLine("Программа которая разбирает строку и заносит в переменные типа int оба операнда и сумму");
                                    Console.WriteLine("Введите строку вида: 15 + 36 = 51 ");
                                    string str6 = Console.ReadLine();
                                    ms.Restart();
                                    Regex num = new Regex(@"-?\d+");
                                    int a6 = 1;
                                    Console.WriteLine(g);
                                    MatchCollection matches6 = num.Matches(str6);
                                    if (matches6.Count > 0)
                                    {
                                        foreach (Match match in matches6)
                                        {
                                            int nums = int.Parse(match.Value);
                                            Console.Write(nums + " --> " + $"{a6} элемент |");
                                            a6++;
                                        }
                                    }
                                    ms.Stop();
                                    time = ms.Elapsed;
                                    Console.WriteLine($"\nЗатраченное время: {time}");
                                    break;
                                case "7":
                                    Console.WriteLine("Дан треклист – массив из 10 строк следующего вида: ");
                                    Console.WriteLine(g);
                                    string[] tracklist = {  "Gentle Giant – Free Hand[06:15]",
                                    "Supertramp – Child Of Vision[07:27]",
                                    "Camel – Lawrence[10:46]",
                                    "Yes – Don’t Kill The Whale[03:55]",
                                    "10CC – Notell Hotel[04:58]",
                                    "Nektar – King Of Twilight[04:16]",
                                    "The Flower Kings – Monsters & Men[21:19]",
                                    "Focus – Le Clochard[01:59]",
                                    "Pendragon – Fallen Dream And Angel[05:23]",
                                    "Kaipa – Remains Of The Day(08:02)"};
                                    foreach (string s7 in tracklist)
                                    {
                                        Console.WriteLine(s7);
                                    }
                                    Console.WriteLine(g);
                                    Console.WriteLine("Программа обрабатывает весь треклист, суммирует время звучания песен, а также отображает самую длинную и самую короткую песню в списке и пару песен с минимальной разницей во времени звучания.");
                                    Console.WriteLine(g);
                                    //ВРЕМЯ ПЕСЕН
                                    int[] durations = new int[tracklist.Length];
                                    int sum2 = 0, sum1 = 0, sec = 0, min = 0, H = 0;
                                    Regex minutes = new Regex(@"(\d{2})(?=:)");
                                    Regex seconds = new Regex(@"(?<=:)(\d{2})");
                                    for (int i = 0; i < tracklist.Length; i++)
                                    {
                                        MatchCollection minut = minutes.Matches(tracklist[i]);
                                        MatchCollection second = seconds.Matches(tracklist[i]);
                                        foreach (Match m in minut)
                                        {
                                            min = int.Parse(m.Value);
                                            sum1 += min;
                                            if (sum1 >= 60)
                                            {
                                                H++;
                                                sum1 = sum1 - 60;
                                            }
                                        }
                                        foreach (Match s7 in second)
                                        {
                                            sec = int.Parse(s7.Value);
                                            sum2 += sec;
                                            if (sum2 >= 60)
                                            {
                                                sum1++;
                                                sum2 = sum2 - 60;
                                            }
                                        }
                                        durations[i] = min * 60 + sec; //НУЖНО ДЛЯ ПРОВЕРКИ МИНИМАЛЬНОЙ РАЗНИЦЫ
                                    }
                                    Console.WriteLine($"Сумма звучания песен = {H} часов, {sum1} минут, {sum2} секунд");
                                    Console.WriteLine(g);
                                    //САМАЯ ДЛИННАЯ И САМАЯ КОРОТКАЯ ПЕСНИ           
                                    string longest = string.Empty;
                                    string shortest = string.Empty;
                                    int minDuration = int.MaxValue, maxDuration = 0, temp7 = 0;
                                    Regex duration = new Regex(@"(\d{2})(?=:)");
                                    for (int i = 0; i < tracklist.Length; i++)
                                    {
                                        MatchCollection dur = duration.Matches(tracklist[i]);
                                        foreach (Match d in dur)
                                        {
                                            temp7 = int.Parse(d.Value);
                                            if (maxDuration < temp7)
                                            {
                                                maxDuration = temp7;
                                                longest = tracklist[i];
                                            }
                                            if (minDuration > temp7)
                                            {
                                                minDuration = temp7;
                                                shortest = tracklist[i];
                                            }
                                        }
                                    }
                                    Console.WriteLine($"Самая короткая песня: {shortest}");
                                    Console.WriteLine($"Самая длинная песня: {longest}");
                                    Console.WriteLine(g);
                                    //ПЕСНИ С МИНИМАЛЬНОЙ РАЗНИЦЕЙ           
                                    int difference = int.MaxValue, firstIndex = 0, secondIndex = 0;
                                    for (int q = 0; q < durations.Length; q++)
                                    {
                                        for (int w = 0; w < durations.Length; w++)
                                        {
                                            if (q == w)
                                            {
                                                continue;
                                            }
                                            if (Math.Abs(durations[q] - durations[w]) < difference)
                                            {
                                                firstIndex = q;
                                                secondIndex = w;
                                                difference = Math.Abs(durations[q] - durations[w]);
                                            }
                                        }
                                    }
                                    Console.WriteLine("Песни с минимальной разницей: {0} и {1}", tracklist[firstIndex], tracklist[secondIndex]);
                                    ms.Stop();
                                    time = ms.Elapsed;
                                    Console.WriteLine($"\nЗатраченное время: {time}");
                                    break;
                                case "8":
                                    Console.WriteLine("Сформировать новую строку из исходной путем удаления из нее всех слов, которые и начинаются, и заканчиваются на один из символов a, o, e, i, u");
                                    Console.WriteLine("Введите текст: ");
                                    string s8 = Console.ReadLine().ToLower();
                                    ms.Restart();
                                    Console.WriteLine("Ваш текст: ");
                                    Console.WriteLine(s8);
                                    Console.WriteLine(g);
                                    //ARRAY
                                    Console.WriteLine("С помощью ARRAY: ");
                                    //char[] charWord = s.ToCharArray();
                                    string[] words = s8.Split(new char[] { ' ', ',', '.' });
                                    foreach (string word in words)
                                    {
                                        char[] charWord = word.ToCharArray();
                                        if (charWord[0] == 'a' || charWord[0] == 'o' || charWord[0] == 'e' || charWord[0] == 'i' || charWord[0] == 'u')
                                        {
                                            s8 = s8.Replace(word, "");
                                        }
                                    }
                                    Console.WriteLine();
                                    Console.WriteLine(s8);
                                    Console.WriteLine();
                                    Console.WriteLine(g);
                                    //STRING
                                    Console.WriteLine("С помощью STRING: ");
                                    foreach (string word in words)
                                    {
                                        if (word[0].Equals('a') || word[0].Equals('o') || word[0].Equals('e') || word[0].Equals('i') || word[0].Equals('u'))
                                        {
                                            s8 = s8.Replace(word, "");
                                        }
                                    }
                                    Console.WriteLine(s8);
                                    ms.Stop();
                                    time = ms.Elapsed;
                                    Console.WriteLine($"\nЗатраченное время: {time}");
                                    break;
                                case "9":
                                    Console.WriteLine("Программа, которая находит все «смайлы» – подстроки вида «:)», «:-)», «)))»");
                                    Console.WriteLine("Введите текст: ");
                                    string s9 = Console.ReadLine();
                                    ms.Restart();
                                    Console.WriteLine("Ваш текст: ");
                                    Console.WriteLine(s9);
                                    Console.WriteLine(g);
                                    Console.WriteLine("Ваши «смайлы»: ");
                                    Regex regex9 = new Regex(@":?-?\)*");
                                    MatchCollection smiles = regex9.Matches(s9);
                                    foreach (Match match in smiles)
                                    {
                                        Console.WriteLine(match.Value);
                                    }
                                    ms.Stop();
                                    time = ms.Elapsed;
                                    Console.WriteLine($"\nЗатраченное время: {time}");
                                    break;                              
                                case "0":
                                    flag4 = false;
                                    break;
                                default:
                                    Console.WriteLine("Неизвестное действие.");
                                    break;
                            }
                        }
                        break;                       
                    case "5":
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Неизвестное действие.");
                        break;
                }
            }
        }
    }
}
