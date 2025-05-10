using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    namespace WinFormsApp2
    {
        public class Dag : HareketsizEngel
        {
            public Dag(int genislik, int yukseklik, Control.ControlCollection controls) : base(genislik, yukseklik, controls) { }

            protected override string GetWinterImagePath()
            {
                return @"C:\Users\Gülşah\Desktop\kışdag.jpg";
            }

            protected override string GetSummerImagePath()
            {
                return @"C:\Users\Gülşah\Desktop\yazdağ.jpg";
            }

            public override Size GetObjectSize()
            {
                return new Size(15 * 20, 15 * 20);
            }

        }

    }

