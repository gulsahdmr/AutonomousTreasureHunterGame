using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2
{
    public class Agac : HareketsizEngel
    {
        public Agac(int genislik, int yukseklik, Control.ControlCollection controls) : base(genislik, yukseklik, controls) { }

        protected override string GetWinterImagePath()
        {
            return @"C:\Users\Gülşah\Desktop\kısagac.jpg";
        }

        protected override string GetSummerImagePath()
        {
            return @"C:\Users\Gülşah\Desktop\yazagac.jpg";
        }
        public override Size GetObjectSize()
        {
            int[] boyutlar = { 2, 3, 4, 5 };
            int rastgeleIndex = rnd.Next(boyutlar.Length);
            int boyutX = boyutlar[rastgeleIndex] * 20;
            int boyutY = boyutX;
            return new Size(boyutX, boyutY);
        }
    }
}
