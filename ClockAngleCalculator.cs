using System;

class ClockAngleCalculator
{
    private const int clocksOnTheClock = 12;

    static void Main()
    {
        Console.Write("Введите часы: ");
        int hours = int.Parse(Console.ReadLine());

        Console.Write("Введите минуты: ");
        int minutes = int.Parse(Console.ReadLine());

        double angle = CalculateClockAngle(hours, minutes);

        Console.WriteLine($"Угол между часовой и минутной стрелками: {angle} градусов");
    }

    static double CalculateClockAngle(int hours, int minutes)
    {
        // Приводим часы к 12-часовому формату
        hours = hours % clocksOnTheClock;

        // Вычисляем угол по формуле
        double angle = Math.Abs(30 * hours - (11.0 / 2) * minutes);

        // Ограничиваем угол до значения от 0 до 180 градусов
        angle = Math.Min(angle, 360 - angle);

        return angle;
    }
}
