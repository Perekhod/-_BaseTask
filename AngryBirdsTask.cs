/*
 В файле AngryBirdsTask реализуйте функцию расчета угла прицеливания,в зависимости от начальной
скорости снаряда и дальности до цели. Если решения не существует, метод должен возвращать double.NaN
 */

using System;

namespace AngryBirds
{
    public static class AngryBirdsTask
    {
        public static double FindSightAngle(double v, double distance)
        {
            const double g = 9.8; // ускорение свободного падения
            double argument = (g * distance) / (v * v);

            // Проверка на возможность достижения цели
            if (argument > 1 || argument < 0)
                return double.NaN;

            return 0.5 * Math.Asin(argument);
        }
    }
}
