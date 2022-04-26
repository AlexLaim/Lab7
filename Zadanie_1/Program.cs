using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Zadanie_1
{
    public enum types
    {
        Т,
        С
    }

    public enum actions
    {
        add,
        del,
        upd
    }

    public struct Item
    {
        public Item(string Name, types Types, int Age, int Exp)
        {
            this.Name = Name;
            this.Type = Types;
            this.Age = Age;
            this.Exp = Exp;
        }
       

        public String Name;
        public types Type;
        public int Age;
        public int Exp;



        public void Print()
        {
            Console.WriteLine($"|{this.Name,-24}|{this.Type,-12}|{this.Age,-20}|{this.Exp,-15}|");
        }
    }
    public struct Action
    {
        public actions Act;
        public string Name;
        public DateTime Time;

        public Action(actions act, string name, DateTime time)
        {
            this.Act = act;
            this.Name = name;
            this.Time = time;
        }

        public void Print()
        {
            if (Act == actions.add)
            {
                Console.WriteLine($"{this.Time} - Добавлена запись '{this.Name}' ");
            }
            else if (Act == actions.del)
            {
                Console.WriteLine($"{this.Time} - Удалена запись '{this.Name}' ");
            }
            else if (Act == actions.upd)
            {
                Console.WriteLine($"{this.Time} - Обновлена запись '{this.Name}' ");
            }
        }
    }


  

    class Program
    {

        static public void InsertionSort(List<Item> list)
        {         
                for (int i = 1; i < list.Count; i++)
                {
                    int j;
                    var buf = list[i];
                    for (j = i - 1; j >= 0; j--)
                    {
                        if (list[i].Name.CompareTo(list[j].Name) == 1)
                        {

                            break;
                        }

                        list[j + 1] = list[j];
                    }
                    list[j + 1] = buf;
                }           
        }
        static void Main()
         {
                List<Item> list = new List<Item>();
                List<Action> list3 = new List<Action>();
                string filename = Directory.GetCurrentDirectory() + "\\lab.dat";


                //Считывание файла

                //---> БИНАРНЫЙ

                //using (BinaryReader reader = new BinaryReader(File.Open(filename, FileMode.OpenOrCreate)))
                //{

                //    while (reader.PeekChar() > -1)
                //    {

                //        string[] Array2 = reader.ReadString().Split();
                //        string Name = Array2[0];
                //        types Type;
                //        if (Array2[1].Equals("С"))
                //        {
                //            Type = types.С;
                //        }
                //        else if (Array2[1].Equals("Т"))
                //        {
                //            Type = types.Т;
                //        }
                //        else Type = (types)int.Parse(Array2[1]);
                //        int Age = int.Parse(Array2[2]);
                //        int Exp = int.Parse(Array2[3]);
                //        list.Add(new Item(Name, Type, Age, Exp));
                //    }
                //}

                //---> ОБЫЧНЫЙ

                using (StreamReader streamreader = new StreamReader(File.Open(filename, FileMode.OpenOrCreate)))
                {
                    while (streamreader.Peek() > -1)
                    {
                        string[] Array2 = streamreader.ReadLine().Split();
                        string Name = Array2[0];
                        types Type;
                        if (Array2[1].Equals("С"))
                        {
                            Type = types.С;
                        }
                        else if (Array2[1].Equals("Т"))
                        {
                            Type = types.Т;
                        }
                        else Type = (types)int.Parse(Array2[1]);
                        int Age = int.Parse(Array2[2]);
                        int Exp = int.Parse(Array2[3]);
                        list.Add(new Item(Name, Type, Age, Exp));
                    }
                }





                bool flag = true;
                while (flag)
                {
                    Console.WriteLine("Меню:");
                    Console.WriteLine("1 – Просмотр таблицы\n2 – Добавить запись\n3 – Удалить запись\n4 – Обновить запись\n5 – Поиск записей\n6 – Просмотреть лог\n7 - Сортировка\n8 - Выход");
                    Console.WriteLine("Выберите действие:");
                    switch (Console.ReadLine().Trim())
                    {
                        case "1":
                            Console.WriteLine(new String('-', 76));
                            Console.WriteLine($"{"|Состав спортклуба:",-75}|");
                            Console.WriteLine(new String('-', 76));
                            Console.WriteLine($"{"|ФИО:",-25}|{"Тип: ",-12}|{"Год рождения:",-20}|{"Опыт (лет):",-15}|");
                            Console.WriteLine(new String('-', 76));
                            foreach (Item item in list)
                            {
                                item.Print();
                                Console.WriteLine(new String('-', 76));
                            }
                            Console.WriteLine($"{"|Перечисляемый тип: Т - тренер, С - спортсмен",-75}|");
                            Console.WriteLine(new String('-', 76));
                            break;
                        case "2":
                            string Name = string.Empty;
                            int Age, Exp;
                            types Types;
                            Console.WriteLine("Введите данные:");
                            for (; ; )
                            {
                                Console.WriteLine("ФИО:");
                                Name = Console.ReadLine();

                                //---> ПРОВЕРКА НА НАЛИЧИЕ ЦИФР В СТРОКЕ
                                //foreach (var symbol in Name)
                                //    if (!char.IsDigit(symbol))
                                //    {
                                //        flag2 = false;


                                //    }
                                //    else
                                //    {
                                //        Console.WriteLine("Не корректные данные, введите ФИО еще раз.");
                                //        break;
                                //    }

                                // --->ПРОВЕРКА СТРОКИ, КОТОРАЯ СОСТОИТ ТОЛЬКО ИЗ БУКВ
                                if (Regex.IsMatch(Name, @"^([a-zA-Zа-яА-Я]+|\s)+$"))
                                {

                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Некорректные данные, введите ФИО еще раз.");
                                }
                            }

                            //---> ПРОВЕРКА СТРОКИ, КОТОРАЯ СОСТОИТ ТОЛЬКО ИЗ ЦИФР
                            //if (Regex.IsMatch(Name, @"^[0-9]+$"))
                            //{
                            //    flag2 = false;
                            //}
                            //else
                            //{
                            //    Console.WriteLine("Некорректные данные, введите ФИО еще раз.");
                            //}
                            for (; ; )
                            {
                                try
                                {
                                    Console.WriteLine("Тип деятельности: Т-тренер - 0, С-спортсмен - 1");
                                    int del2 = int.Parse(Console.ReadLine());
                                    Types = (types)del2;
                                    if (del2 == 0 || del2 == 1)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Некорректные данные, введите тип деятельности еще раз.");
                                    }
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Некорректные данные, пожалуйста введите числовое значение!");
                                }
                            }

                            for (; ; )
                            {
                                try
                                {
                                    Console.WriteLine("Введите год рождения:");
                                    Age = int.Parse(Console.ReadLine());
                                    if (Age >= 0)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Некорректные данные, введите год рождения еще раз.");
                                    }
                                }
                                catch 
                                {
                                    Console.WriteLine("Некорректные данные, пожалуйста введите числовое значение!");
                                }
                            }

                            for (; ; )
                            {
                                try
                                {
                                    Console.WriteLine("Введите опыт работы(лет):");
                                    Exp = int.Parse(Console.ReadLine());
                                    if (Exp >= 0)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Некорректные данные, введите опыт работы еще раз.");
                                    }
                                }
                                catch 
                                {
                                    Console.WriteLine("Некорректные данные, пожалуйста введите числовое значение!");
                                }
                            }
                            Item value = new(Name, Types, Age, Exp);
                            list.Add(value);
                            DateTime time = DateTime.Now;
                            string name = Name;
                            actions act = actions.add;
                            Action val = new(act, name, time);
                            list3.Add(val);
                            break;
                        case "3":
                            int num;
                            Console.WriteLine("Введите номер записи которую хотите удалить:");
                            for (; ; )
                            {
                                try
                                {
                                    Console.WriteLine("Кол-во записей: " + list.Count);
                                    num = int.Parse(Console.ReadLine());
                                    if (num > 0)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Некорректные данные, введите номер еще раз.");
                                    }
                                }
                                catch 
                                {
                                    Console.WriteLine("Некорректные данные, пожалуйста введите числовое значение!");
                                }
                            }
                            time = DateTime.Now;
                            name = list[num - 1].Name;
                            act = actions.del;
                            val = new(act, name, time);
                            list3.Add(val);
                            list.RemoveAt(num - 1);
                            break;
                        case "4":
                            Console.WriteLine("Введите номер записи которую хотите обновить:");

                            int num2;
                            for (; ; )
                            {
                                try
                                {
                                    Console.WriteLine("Кол-во записей: " + list.Count);
                                    num2 = int.Parse(Console.ReadLine());
                                    if (num2 > 0 & num2 <= list.Count)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Некорректные данные, введите номер еще раз.");
                                    }
                                }
                                catch
                                {
                                    Console.WriteLine("Некорректные данные, пожалуйста введите числовое значение!");
                                }
                            }
                            //while (num2 > list.Count)
                            //{
                            //    Console.WriteLine("Введено неверное значение");
                            //    Console.WriteLine("Введите номер записи которую хотите обновить:");
                            //    Console.WriteLine("Кол-во записей: " + list.Count);
                            //    num2 = int.Parse(Console.ReadLine());
                            //}
                            time = DateTime.Now;
                            name = list[num2 - 1].Name;
                            act = actions.upd;
                            val = new(act, name, time);
                            list3.Add(val);
                            string Name2 = string.Empty;
                            types Types2;
                            int Age2, Exp2;
                            Console.WriteLine("Введите данные:");

                            for (; ; )
                            {
                                Console.WriteLine("ФИО:");
                                Name2 = Console.ReadLine();

                                if (Regex.IsMatch(Name2, @"^([a-zA-Zа-яА-Я]+|\s)+$"))
                                {

                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Некорректные данные, введите ФИО еще раз.");
                                }
                            }

                            for (; ; )
                            {
                                try
                                {
                                    Console.WriteLine("Тип деятельности: Т-тренер - 0, С-спортсмен - 1");
                                    int del2 = int.Parse(Console.ReadLine());
                                    Types2 = (types)del2;
                                    if (del2 == 0 || del2 == 1)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Некорректные данные, введите тип деятельности еще раз.");
                                    }
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Некорректные данные, пожалуйста введите числовое значение!");
                                }
                            }

                            for (; ; )
                            {
                                try
                                {
                                    Console.WriteLine("Введите год рождения:");
                                    Age2 = int.Parse(Console.ReadLine());
                                    if (Age2 >= 0)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Некорректные данные, введите год рождения еще раз.");
                                    }
                                }
                                catch 
                                {
                                    Console.WriteLine("Некорректные данные, пожалуйста введите числовое значение!");
                                }
                            }

                            for (; ; )
                            {
                                try
                                {
                                    Console.WriteLine("Введите опыт работы(лет):");
                                    Exp2 = int.Parse(Console.ReadLine());
                                    if (Exp2 >= 0)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Некорректные данные, введите опыт работы еще раз.");
                                    }
                                }
                                catch 
                                {
                                    Console.WriteLine("Некорректные данные, пожалуйста введите числовое значение!");
                                }
                            }
                            list[num2 - 1] = new Item(Name2, Types2, Age2, Exp2);

                            break;

                        case "5":
                            Console.WriteLine("Введите тип поиска: ");
                            Console.WriteLine("1 - поиск по ФИО \n2 - поиск по году рождения \n3 - по типу деятельности (Т-тренер, С-спортсмен)");
                            int del;
                            for (; ; )
                            {
                                try
                                {
                                    del = int.Parse(Console.ReadLine());
                                    if (del == 1 || del == 2 || del == 3)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Некорректные данные, пожалуйста введите числовое значение от 1 до 3!");
                                    }
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Некорректные данные, пожалуйста введите числовое значение!");
                                }
                            }
                            string var = string.Empty;
                            int var2;
                            types var3;
                            List<Item> list2 = new List<Item>();
                            switch (del)
                            {
                                case 1:
                                    for (; ; )
                                    {
                                        Console.WriteLine("Введите ФИО:");
                                        var = Console.ReadLine();

                                        if (Regex.IsMatch(var, @"^([a-zA-Zа-яА-Я]+|\s)+$"))
                                        {

                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Некорректные данные, введите ФИО еще раз.");
                                        }
                                    }
                                    foreach (Item item in list)
                                    {
                                        if (item.Name.Equals(var))
                                            list2.Add(item);
                                    }
                                    Console.WriteLine(new String('-', 76));
                                    Console.WriteLine($"{"|Состав спортклуба:",-75}|");
                                    Console.WriteLine(new String('-', 76));
                                    Console.WriteLine($"{"|ФИО:",-25}|{"Тип: ",-12}|{"Год рождения:",-20}|{"Опыт (лет):",-15}|");
                                    Console.WriteLine(new String('-', 76));
                                    foreach (Item item in list2)
                                    {
                                        item.Print();
                                        Console.WriteLine(new String('-', 76));
                                    }
                                    Console.WriteLine($"{"|Перечисляемый тип: Т - тренер, С - спортсмен",-75}|");
                                    Console.WriteLine(new String('-', 76));
                                    break;
                                case 2:
                                    for (; ; )
                                    {
                                        try
                                        {
                                            Console.WriteLine("Введите год рождения:");
                                            var2 = int.Parse(Console.ReadLine());
                                            if (var2 >= 0)
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Некорректные данные, введите год рождения еще раз.");
                                            }
                                        }
                                        catch 
                                        {
                                            Console.WriteLine("Некорректные данные, пожалуйста введите числовое значение!");
                                        }
                                    }
                                    foreach (Item item in list)
                                    {
                                        if (item.Age.Equals(var2))
                                            list2.Add(item);
                                    }
                                    Console.WriteLine(new String('-', 76));
                                    Console.WriteLine($"{"|Состав спортклуба:",-75}|");
                                    Console.WriteLine(new String('-', 76));
                                    Console.WriteLine($"{"|ФИО:",-25}|{"Тип: ",-12}|{"Год рождения:",-20}|{"Опыт (лет):",-15}|");
                                    Console.WriteLine(new String('-', 76));
                                    foreach (Item item in list2)
                                    {
                                        item.Print();
                                        Console.WriteLine(new String('-', 76));
                                    }
                                    Console.WriteLine($"{"|Перечисляемый тип: Т - тренер, С - спортсмен",-75}|");
                                    Console.WriteLine(new String('-', 76));
                                    break;
                                case 3:
                                    for (; ; )
                                    {
                                        try
                                        {
                                            Console.WriteLine("Тип деятельности: Т-тренер - 0, С-спортсмен - 1");
                                            int del2 = int.Parse(Console.ReadLine());
                                            var3 = (types)del2;
                                            if (del2 == 0 || del2 == 1)
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Некорректные данные, введите тип деятельности еще раз.");
                                            }
                                        }
                                        catch (FormatException)
                                        {
                                            Console.WriteLine("Некорректные данные, пожалуйста введите числовое значение!");
                                        }
                                    }
                                    foreach (Item item in list)
                                    {
                                        if (item.Type.Equals(var3))
                                            list2.Add(item);
                                    }
                                    Console.WriteLine(new String('-', 76));
                                    Console.WriteLine($"{"|Состав спортклуба:",-75}|");
                                    Console.WriteLine(new String('-', 76));
                                    Console.WriteLine($"{"|ФИО:",-25}|{"Тип: ",-12}|{"Год рождения:",-20}|{"Опыт (лет):",-15}|");
                                    Console.WriteLine(new String('-', 76));
                                    foreach (Item item in list2)
                                    {
                                        item.Print();
                                        Console.WriteLine(new String('-', 76));
                                    }
                                    Console.WriteLine($"{"|Перечисляемый тип: Т - тренер, С - спортсмен",-75}|");
                                    Console.WriteLine(new String('-', 76));
                                    break;
                            }
                            break;
                        case "6":
                            try
                            {
                                foreach (Action logs in list3)
                                {
                                    logs.Print();
                                }
                                if (list3.Count == 0)
                                {
                                    Console.WriteLine("Лог пуст!");
                                }
                                TimeSpan varr = list3[1].Time - list3[0].Time;
                                for (int i = 2; i < list3.Count; i++)
                                {
                                    TimeSpan varr2 = list3[i].Time - list3[i - 1].Time;
                                    if (varr2 > varr)
                                    {
                                        varr = varr2;
                                    }
                                }

                                Console.WriteLine();
                                Console.WriteLine($"{varr} - Самый долгий период бездействия пользователя");
                            }
                            catch (ArgumentOutOfRangeException)
                            {

                            }

                            break;
                        case "7":
                        for(int i = 0; i < list.Count; i++)
                        {
                            InsertionSort(list);
                        }
                        //Compare(list);
                        
                        
                        break;
                        case "8":
                            //Сохранение файла
                            File.WriteAllText(filename, string.Empty);
                            for (int i = 0; i < list.Count; i++)
                            {
                                // ---> ПРОВЕРКА НА ЧЕТНОСТЬ

                                //if (i % 2 == 0)
                                //{
                                //using (BinaryWriter writer = new BinaryWriter(File.Open(filename, FileMode.Append)))
                                //{
                                //    writer.Write($"{list[i].Name} {list[i].Type} {list[i].Age} {list[i].Exp}");
                                //}
                                //}

                                //---> ПРОВЕРКА НА НЕЧЕТНОСТЬ

                                //else if (i % 2 == 1)
                                //{
                                using (StreamWriter streamwriter = new StreamWriter(File.Open(filename, FileMode.Append)))
                                {
                                    streamwriter.WriteLine($"{list[i].Name} {list[i].Type} {list[i].Age} {list[i].Exp}");
                                }
                                //}
                            }

                            //Закрытие программы

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

