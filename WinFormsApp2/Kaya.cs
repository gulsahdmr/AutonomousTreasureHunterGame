using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



    namespace WinFormsApp2
    {
        public class Kaya : HareketsizEngel
        {
            public Kaya(int genislik, int yukseklik, Control.ControlCollection controls) : base(genislik, yukseklik, controls) { }

            protected override string GetWinterImagePath()
            {
                return @"C:\Users\Gülşah\Desktop\kayakıs.jpg";
            }

            protected override string GetSummerImagePath()
            {
                return @"C:\Users\Gülşah\Desktop\kayayazz.jpeg";
            }

            public override Size GetObjectSize()
            {
                // Kaya'nın boyutlarına göre boyut döndür
                int[] boyutlar = { 2, 3 };
                int rastgeleIndex = rnd.Next(boyutlar.Length);
                int boyutX = boyutlar[rastgeleIndex] * 20;
                int boyutY = boyutX;
                return new Size(boyutX, boyutY);
            }



        }
    }

