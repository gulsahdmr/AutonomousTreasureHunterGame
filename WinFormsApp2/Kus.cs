using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace WinFormsApp2
{
    public class Kus : HareketliEngel
    {
        public Kus(int genislik, int yukseklik, Control.ControlCollection controls) : base(genislik, yukseklik, controls) { }

        protected override string GetImagePath()
        {

            return @"C:\Users\Gülşah\Downloads\kus.jpeg";
        }

        int startX, startY;

        public override void PlaceObject()
        {

            do
            {
                startX = rnd.Next(genislik);
                startY = rnd.Next(yukseklik);
            } while (startX <= 15 || startY <= 15 || startX >= genislik - 15 || startY >= yukseklik - 15 || Math.Abs(startX - (genislik / 2)) <= 15);

            Size boyut = GetObjectSize();

            List<Point> occupiedSquaresForCurrentObject = GetOccupiedSquares(startX, startY, boyut.Width / 20, boyut.Height / 20);

            if (!collisionManager.IsCollision(occupiedSquaresForCurrentObject))
            {
                PictureBox pb = new PictureBox();
                pb.Location = new Point(startX * 20, startY * 20);
                pb.Size = boyut;
                pb.SizeMode = PictureBoxSizeMode.StretchImage;

                // Nesne türüne göre görseli ekle (alt sınıflarda bu ayrıntılar belirlenebilir)
                pb.ImageLocation = GetImagePath();

                controls.Add(pb);

                collisionManager.AddOccupiedSquares(occupiedSquaresForCurrentObject);
            }
            else
            {
                PlaceObject(); // Recursive call is unnecessary, consider refactoring
            }
        }

        private int toplamHareketAdimi = 0;
        private int maksimumHareketAdimi = 6;
        private bool asagiHareket = true;
        private int adimSayisi = 0;

        public void Move()
        {
            int hareketMiktari = 1; // Her adımda kaç birim ilerleyeceğini belirtir

            // Arının hareket ettiği alanı kontrol et
            if ((startY >= 0 && startY + 5 <= genislik) && (startY >= 0 && startY + 5 <= yukseklik))
            {
                // Sağa hareket
                if (toplamHareketAdimi < maksimumHareketAdimi && asagiHareket)
                {
                    startY = Math.Min(startY + hareketMiktari, genislik - 5);
                    toplamHareketAdimi += hareketMiktari;
                    adimSayisi++;

                    if (toplamHareketAdimi == maksimumHareketAdimi)
                    {
                        // Sağa hareket tamamlandı, sola hareketi başlat
                        asagiHareket = false;
                    }
                }
                // Sola hareket
                else if (toplamHareketAdimi > 0 && !asagiHareket)
                {
                    startY = Math.Max(startY - hareketMiktari, 0);
                    toplamHareketAdimi -= hareketMiktari;
                    adimSayisi++;

                    if (toplamHareketAdimi == 0)
                    {
                        // Sola hareket tamamlandı, sağa hareketi başlat
                        asagiHareket = true;
                    }
                }
            }

            // Arının PictureBox'ının konumunu güncelle
            foreach (Control control in controls)
            {
                if (control is PictureBox pictureBox && pictureBox.Tag?.ToString() == "Ari")
                {
                    pictureBox.Location = new Point(startX * 20, startY * 20);
                }
            }
        }



        public override Size GetObjectSize()
        {
            return new Size(2 * 20, 2 * 20);
        }

    }

}
