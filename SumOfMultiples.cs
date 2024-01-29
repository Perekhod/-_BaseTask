/*
Найти сумму всех положительных чисел меньше 1000 кратных 3 или 5.
*/

using System;

class SumOfMultiples
{
    static void Main()
    {
        int sum = 0;

        for (int i = 1; i < 1000; i++)
        {
            if (i % 3 == 0 || i % 5 == 0)
            {
                sum += i;
            }
        }

        Console.WriteLine($"Сумма всех положительных чисел меньше 1000, кратных 3 или 5: {sum}");
    }
}