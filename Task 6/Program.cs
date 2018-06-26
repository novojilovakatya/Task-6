using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_6
{
    class Program
    {
        /// <summary>
        /// Проверка ввода натуральных чисел
        /// </summary>
        /// <returns>Натуральное число</returns>
        public static int ReadPositive()
        {
            int k = 0; bool ok;
            do
            {
                ok = int.TryParse(Console.ReadLine(), out k);
                if (!ok || k <= 0) Console.WriteLine("Неправильный ввод. Ожидалось натуральное число. Пожалуйста, повторите ввод");
            }
            while (!ok || k <= 0);
            return k;
        }

        /// <summary>
        /// Проверка ввода дробных чисел
        /// </summary>
        /// <returns>Целое дробных</returns>
        public static double ReadDoubly()
        {
            double k = 0; bool ok;
            do
            {
                ok = double.TryParse(Console.ReadLine(), out k);
                if (!ok) Console.WriteLine("Неправильный ввод. Ожидалось дробное число. Пожалуйста, повторите ввод");
            }
            while (!ok);
            return k;
        }


        /// <summary>
        /// Расчет k-того элемента последовательности
        /// </summary>
        /// <param name="stock">Последовательность с найденными элементами</param>
        /// <param name="k">Номер элемента последовательности</param>
        /// <param name="m">Требуемое кол-во элеметов, больших l</param>
        /// <param name="l">Значение из условия</param>
        /// <param name="numL">Кол-во элементов больших l</param>
        /// <returns>Последовательность</returns>
        static double[] AK(ref double[] stock, int k, int m, double L, ref int numL)
        {
            double res = 0;
            // Вычисляем элемент последовательности
            if (k == 1)
                res = stock[0];
            else if (k == 2)
                res = stock[1];
            else if (k == 3)
                res = stock[2];
            else
                res = (7.0 / 3.0 * AK(ref stock, k - 1, m, L, ref numL)[k - 2] + stock[k - 3]) / 2 * stock[k - 4];
            // Проверяем на доп условие 
            // если нашли достаточное кол-во элементов заканчиваем
            if (numL >= m)
                return stock;
            // иначе продолжаем
            stock[k-1] = res;
            if (stock[k-1] > L)
                numL++;

            return stock;
        }


        static void Main(string[] args)
        {
            // Вводим все значения
            Console.WriteLine("Введите требуемое количество элементов для нахождения");
            int n = ReadPositive();
            double[] stock = new double[n + 1];
            Console.WriteLine("Введите первый элемент последовательности");
            stock[0] = ReadDoubly();
            Console.WriteLine("Введите второй элемент последовательности");
            stock[1] = ReadDoubly();
            Console.WriteLine("Введите третий элемент последовательности");
            stock[2] = ReadDoubly();
            Console.WriteLine("Введите количество элементов, которые нужно найти больших L");
            int m = ReadPositive();
            Console.WriteLine("Введите значение L");
            double L = ReadDoubly();

            // Составляем последовательность
            int numL = 0;
            stock = AK(ref stock, n, m, L, ref numL);

            // Выводим результат
            Console.WriteLine("Результат: ");
            int i = 0;
            if (numL >= m)
            {
                Console.WriteLine("Причина остановки: найдены M элементов, которые больше L");
                while (numL > -1)
                {
                    Console.Write("{0} ", stock[i]);
                    i++;
                    if (stock[i] > L) numL--;
                }
            }
            else
            {
                Console.WriteLine("Причина остановки: найдены N элементов");
                for (i = 0; i < n; i++)
                    Console.Write("{0} ", stock[i]);
                Console.WriteLine();
            }


            Console.ReadLine();
        }
    }
}
