using System;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace RefactorMe
{
    class Renderer
    {
        static float x, y;
        static Graphics graphics;

        public static void Initialization(Graphics newGraphics)
        {
            graphics = newGraphics;
            graphics.SmoothingMode = SmoothingMode.None;
            graphics.Clear(Color.Black);
        }

        public static void SetPosition(float x0, float y0)
        {
            x = x0;
            y = y0;
        }

        public static void MakeIt(Pen pen, double length, double angle)
        {
            //Делает шаг длиной length в направлении angle и рисует пройденную траекторию
            var x1 = (float)(x + length * Math.Cos(angle));
            var y1 = (float)(y + length * Math.Sin(angle));

            graphics.DrawLine(pen, x, y, x1, y1);

            x = x1;
            y = y1;
        }

        public static void Change(double length, double angle)
        {
            x = (float)(x + length * Math.Cos(angle));
            y = (float)(y + length * Math.Sin(angle));
        }
    }

    public class ImpossibleSquare
    {
        private const float V   = 0.375f;
        private const float V1  = 0.04f;
        private const float V2  = 2f;
        private const int D = 2;
        private const int V3 = 4;

        public static void Draw(int width, int hight, double rotationAngle, Graphics graphics)
        {
            // ugolPovorota пока не используется, но будет использоваться в будущем
            Renderer.Initialization(graphics);

            var sz = Math.Min(width, hight);

            float x0, y0;
            NewMethodRenderer(width, hight, sz, out x0, out y0);

            Renderer.SetPosition(x0, y0);

            //Рисуем 1-ую сторону
            RendererFirstSize(sz);
            RendererFirstChange(sz);

            //Рисуем 2-ую сторону
            RendererSecondSize(sz);
            RendererSecondChange(sz);

            //Рисуем 3-ю сторону
            RendererThirdSize(sz);
            RendererThirdChange(sz);

            //Рисуем 4-ую сторону
            RendererFouthSize(sz);
            RendererFouthChange(sz);
        }

        private static void NewMethodRenderer(int width, int hight, int sz, out float x0, out float y0)
        {
            var lengthDiagonal = Math.Sqrt(D) * (sz * V + sz * V1) / D;
            x0 = (float)(lengthDiagonal * Math.Cos(Math.PI / V3 + Math.PI)) + width / V2;
            y0 = (float)(lengthDiagonal * Math.Sin(Math.PI / V3 + Math.PI)) + hight / V2;
        }

        private static void RendererFouthChange(int sz)
        {
            Renderer.Change(sz * V1, Math.PI / D - Math.PI);
            Renderer.Change(sz * V1 * Math.Sqrt(D), Math.PI / D + 3 * Math.PI / V3);
        }

        private static void RendererFouthSize(int sz)
        {
            Renderer.MakeIt(Pens.Yellow, sz * V, Math.PI / D);
            Renderer.MakeIt(Pens.Yellow, sz * V1 * Math.Sqrt(D), Math.PI / D + Math.PI / V3);
            Renderer.MakeIt(Pens.Yellow, sz * V, Math.PI / D + Math.PI);
            Renderer.MakeIt(Pens.Yellow, sz * V - sz * V1, Math.PI / D + Math.PI / D);
        }

        private static void RendererThirdChange(int sz)
        {
            Renderer.Change(sz * V1, Math.PI - Math.PI);
            Renderer.Change(sz * V1 * Math.Sqrt(D), Math.PI + 3 * Math.PI / V3);
        }

        private static void RendererThirdSize(int sz)
        {
            Renderer.MakeIt(Pens.Yellow, sz * V, Math.PI);
            Renderer.MakeIt(Pens.Yellow, sz * V1 * Math.Sqrt(D), Math.PI + Math.PI / V3);
            Renderer.MakeIt(Pens.Yellow, sz * V, Math.PI + Math.PI);
            Renderer.MakeIt(Pens.Yellow, sz * V - sz * V1, Math.PI + Math.PI / D);
        }

        private static void RendererSecondChange(int sz)
        {
            Renderer.Change(sz * V1, -Math.PI / D - Math.PI);
            Renderer.Change(sz * V1 * Math.Sqrt(D), -Math.PI / D + 3 * Math.PI / V3);
        }

        private static void RendererSecondSize(int sz)
        {
            Renderer.MakeIt(Pens.Yellow, sz * V, -Math.PI / D);
            Renderer.MakeIt(Pens.Yellow, sz * V1 * Math.Sqrt(D), -Math.PI / D + Math.PI / V3);
            Renderer.MakeIt(Pens.Yellow, sz * V, -Math.PI / D + Math.PI);
            Renderer.MakeIt(Pens.Yellow, sz * V - sz * V1, -Math.PI / D + Math.PI / D);
        }

        private static void RendererFirstChange(int sz)
        {
            Renderer.Change(sz * V1, -Math.PI);
            Renderer.Change(sz * V1 * Math.Sqrt(D), 3 * Math.PI / V3);
        }

        private static void RendererFirstSize(int sz)
        {
            Renderer.MakeIt(Pens.Yellow, sz * V, 0);
            Renderer.MakeIt(Pens.Yellow, sz * V1 * Math.Sqrt(D), Math.PI / V3);
            Renderer.MakeIt(Pens.Yellow, sz * V, Math.PI);
            Renderer.MakeIt(Pens.Yellow, sz * V - sz * V1, Math.PI / D);
        }
    }
}