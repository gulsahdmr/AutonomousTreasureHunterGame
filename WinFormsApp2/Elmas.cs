using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2
{
    public class Elmas : Hazine
    {
        public Elmas(int genislik, int yukseklik, Control.ControlCollection controls) : base(genislik, yukseklik, controls) { }

        protected override string GetImagePath()
        {
            return @"C:\Users\Gülşah\Downloads\elmass.jpg";
        }
    }
}