using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2
{
    public class Altin : Hazine
    {
        public Altin(int genislik, int yukseklik, Control.ControlCollection controls) : base(genislik, yukseklik, controls) { }

        protected override string GetImagePath()
        {
            return @"C:\Users\Gülşah\Downloads\cikartmalar-hazine-sandigi.jpg.jpg";
        }
    }
}