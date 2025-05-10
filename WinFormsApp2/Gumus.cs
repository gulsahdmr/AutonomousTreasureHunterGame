using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Engel;

namespace WinFormsApp2
{
    public class Gumus : Hazine
    {
        public Gumus(int genislik, int yukseklik, Control.ControlCollection controls) : base(genislik, yukseklik, controls) { }


        protected override string GetImagePath()
        {
            return @"C:\Users\Gülşah\Downloads\gumuss.jpeg";
        }
    }
}
