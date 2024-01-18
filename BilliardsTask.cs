/*
 Реализуйте метод для расчета угла отскока шарика от стены. Считайте, что угол падения равен углу отражения
то есть можно пренебречь всеми физическими эффектами, связанными с кручением шаров, трением шара об стенку и т.п.
 */


using System;

namespace Billiards
{
    public static class BilliardsTask
    {
        public static double BounceWall(double directionRadians, double wallInclinationRadians)
        {
            // Угол падения относительно нормали к стене
            double angleOfIncidence = directionRadians - wallInclinationRadians;

            // Угол отражения относительно нормали к стене равен уголу падения
            // Угол отскока относительно горизонтали
            double angleOfReflection = wallInclinationRadians - angleOfIncidence;

            return angleOfReflection;
        }
    }
}
