using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace задача_03
{

    class Program
    {
        static StreamReader filein = new StreamReader("1.in");
        static StreamWriter fileout = new StreamWriter("2367.out");

        static void Main(string[] args)
        {
            int count = 0;
            int del1 = 0;
            int del2 = 0;
            int[] mass = { };
            int ans;
            Console.WriteLine("Для ввода данных из файла введите 1, для ручного ввода введите 0!");
            int i = Convert.ToInt32(Console.ReadLine());
            if (i == 1)
            {
                fileinput(out count, out del1, out del2, out mass);
            }
            else if (i == 0)
            {
                consoleinput(out count, out del1, out del2, out mass);
            }
            else
            {
                Console.WriteLine("Неверный ввод!");
                Main(args);
            }
            reshenie(count, del1, del2, mass, out ans);

            fileout.Write(ans);
            Console.WriteLine("Чисел кратных " + del1 + " и " + del2 + ": " + ans);
            Console.ReadLine();
        }
        static void fileinput(out int count, out int del1, out int del2, out int[] mass)
        {
            try
            {
                string input1 = filein.ReadLine().Trim();
                while (input1.Contains("  "))
                {
                    input1 = input1.Replace("  ", " ");
                }
                string[] del = input1.Split(' ');
                count = Convert.ToInt32(del[0]);
                del1 = Convert.ToInt32(del[1]);
                del2 = Convert.ToInt32(del[2]);
                if (del1==0 || del2 == 0) { Console.WriteLine("На 0 делить нельзя!"); Console.WriteLine(" Попробуйте ввод из консоли!");
                    consoleinput(out count, out del1, out del2, out mass);
                }
                string input2 = filein.ReadLine();
                mass = new int[count];
                while (input2.Contains("  "))
                {
                    input2 = input2.Replace("  ", " ");
                }
                mass = input2.Split(' ').Select(int.Parse).ToArray();
            }
            catch
            {
                Console.WriteLine("Упс! Данные в файле указаны неверно! Попробуйте ввод из консоли!");
                consoleinput(out count, out del1, out del2, out mass);
            }
            filein.Close();
        }
        static void consoleinput(out int count, out int del1, out int del2, out int[] mass)
        {
            try
            {
                Console.WriteLine("Введите кол-во элементов массива:");
                count = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите делители");
                string del0 = Console.ReadLine().Trim();
                while (del0.Contains("  "))
                {
                    del0 = del0.Replace("  ", " ");
                }
                string[] del = del0.Split(' ');
                if (del.Length != 2) { Console.WriteLine("Данные введены некорректно!"); consoleinput(out count, out del1, out del2, out mass); }
            
                del1 = Convert.ToInt32(del[0]);
                del2 = Convert.ToInt32(del[1]);
                if (del1 == 0 || del2 == 0)
                {
                    Console.WriteLine("На 0 делить нельзя!"); 
                    consoleinput(out count, out del1, out del2, out mass);
                }
                Console.WriteLine("Введите массив чисел длинны " + count);
                string input = Console.ReadLine().Trim();
                while (input.Contains("  "))
                {
                    input = input.Replace("  ", " ");
                }
                mass = input.Split(' ').Select(int.Parse).ToArray();
                if (mass.Length != count) { Console.WriteLine("Данные введены некорректно!"); consoleinput(out count, out del1, out del2, out mass); }
            }
            catch
            {
                Console.WriteLine("Данные введены некорректно!");
                consoleinput(out count, out del1, out del2, out mass);
            }
        }
        static void reshenie(int count, int del1, int del2, int[] mass, out int ans)
        {
            ans = 0;

            for (int i = 0; i < count; i++)
            {
                if (mass[i] % del1 == 0 & mass[i] % del2 == 0) {
                    Console.WriteLine(mass[i]);
                    ans++; }
            }


        }
    }
}
