using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    namespace WinFormsApp2
    {
        public class Duvar : HareketsizEngel
        {
            public Duvar(int genislik, int yukseklik, Control.ControlCollection controls) : base(genislik, yukseklik, controls) { }

            protected override string GetWinterImagePath()
            {
                return @"C:\Users\Gülşah\Downloads\kısduvar.jpg";
            }

            protected override string GetSummerImagePath()
            {
                return @"C:\Users\Gülşah\Downloads\yazduvar.jpg";
            }

            public override Size GetObjectSize()
            {
                return new Size(10 * 20, 20);
            }
        }
    }

