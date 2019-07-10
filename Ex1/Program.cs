using System;

namespace Homework
{
    class Program
    {
        private static void Main()
        {
            //Задание 1:
            //Реализовать интерфейс IComparable у класса Клиент. Сравнивать клиентов по общему количеству средств на всех счетах.
            //
            //Задание 2:
            //Реализовать неизменяемую структуру - простая дробь (x/y).
            //Числитель и знаменатель - целые числа. Знаменатель - всегда положительный.
            //Ноль - 0 / y. Реализовать операции сложения, вычитания, умножения, деления.
            //Реализовать интерфейс IComparable. Создать массив из N случайных дробей, отсортировать по возрастанию.
            //Найти сумму всех дробей.
            //*Сделать дробь не сокращаемой.Т.е. 2 / 4-> 1 / 2, 50 / 15-> 10 / 3, 0 / 7-> 0 / 1 и т.д

            var rnd = new Random();
            var n = 2;
            const int maxValue = 10;

            var array = new SimpleFraction[n];

            for (int i = 0; i < n; i++)
            {
                array[i] = new SimpleFraction(rnd.Next(maxValue), rnd.Next(0, maxValue));
                Console.WriteLine(array[i]);
            }

            var sumOfFractions = new SimpleFraction(0, 1);

            for (int i = 0; i < n; i++)
            {
                sumOfFractions += array[i];
            }

            Console.WriteLine($"Сумма всех дробей = {sumOfFractions}");
        }
    }
}