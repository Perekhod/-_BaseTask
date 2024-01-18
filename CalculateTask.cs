using System;

namespace CalculateTask
{
    internal class CalculateTask
    {

        public static double Calculate(string userInput)
        {
            var     parts           = userInput.Split(' ');
            double  initialSum      = double.   Parse(parts[0]);        // Исходная сумма
            double  interestRate    = double.   Parse(parts[1]) / 100;  // Процентная ставка в долях
            int     depositTerm     = int.      Parse(parts[2]);        // Срок вклада в месяцах

            double  monthlyRate     = interestRate / 12;                // Ежемесячная процентная ставка

            // Поскольку использование циклов запрещено, применяем формулу сложных процентов
            double finalSum         = initialSum * Math.Pow(1 + monthlyRate, depositTerm);

            return finalSum;
        }
        static void Main(string[] args)
        {

        }
    }
}
