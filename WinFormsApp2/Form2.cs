using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using System.Windows.Forms;
namespace WinFormsApp2
{
    public partial class Form2 : Form
    {

        private int genislik;
        private int yukseklik;
        private Bitmap haritaImage;
        private PictureBox playerPictureBox = new PictureBox();
        private System.Windows.Forms.Timer timer;
        private Hazine hazine;


        public Form2(int genislik, int yukseklik)
        {
            InitializeComponent();
            this.genislik = genislik;
            this.yukseklik = yukseklik;
            haritaImage = new Bitmap(genislik * 20, yukseklik * 20); // haritaImage alanını başlat

            // Harita çizimini yap ve PictureBox'a yükle
            DrawMap();

            this.KeyPreview = true;
            this.KeyPress += new KeyPressEventHandler(Form2_KeyPress);
            hazine = new Hazine(genislik, yukseklik, Controls);

        }


        private void DrawMap()
        {

            OyuncuyuYerlestir("oyuncu");

            PlaceFixedObstacles();

            // Haritayı çiz
            DrawMapOnBitmap();

            // PictureBox'a haritayı yükle
            PictureBox pb = new PictureBox();
            pb.Image = haritaImage;
            pb.Location = new Point(0, 0);
            pb.SizeMode = PictureBoxSizeMode.AutoSize;
            Controls.Add(pb);
        }

        private void PlaceFixedObstacles()
        {
            const int obstacleCountPerType = 5; // Her engel türünden 5 adet yerleştirilecek

            for (int i = 0; i < obstacleCountPerType; i++)
            {
                Agac agac = new Agac(genislik, yukseklik, Controls);
                agac.PlaceObject();
            }

            for (int i = 0; i < obstacleCountPerType; i++)
            {
                Duvar duvar = new Duvar(genislik, yukseklik, Controls);
                duvar.PlaceObject();
            }

            for (int i = 0; i < obstacleCountPerType; i++)
            {
                Kaya kaya = new Kaya(genislik, yukseklik, Controls);
                kaya.PlaceObject();
            }

            for (int i = 0; i < obstacleCountPerType; i++)
            {
                Dag dag = new Dag(genislik, yukseklik, Controls);
                dag.PlaceObject();
            }


            for (int i = 0; i < 3; i++)
            {
                Kus kus = new Kus(genislik, yukseklik, Controls);
                kus.PlaceObject();
            }


            for (int i = 0; i < 3; i++)
            {
                Altin altin = new Altin(genislik, yukseklik, Controls);
                altin.PlaceObject();
            }

            for (int i = 0; i < 3; i++)
            {
                Gumus gumus = new Gumus(genislik, yukseklik, Controls);
                gumus.PlaceObject();
            }

            for (int i = 0; i < 3; i++)
            {
                Elmas elmas = new Elmas(genislik, yukseklik, Controls);
                elmas.PlaceObject();
            }
            for (int i = 0; i < 3; i++)
            {
                Zumrut zumrut = new Zumrut(genislik, yukseklik, Controls);
                zumrut.PlaceObject();
            }


            for (int i = 0; i < 3; i++)
            {
                Ari ari = new Ari(genislik, yukseklik, Controls);
                ari.PlaceObject();


            }

        }

        private void DrawMapOnBitmap()
        {

            string solTemaDosyaYolu = @"C:\Users\Gülşah\Desktop\sol.jpg";
            string sagTemaDosyaYolu = @"C:\Users\Gülşah\Desktop\sağ.jpg";

            // Sol tema resmini yükle
            Image solTemaImage = Image.FromFile(solTemaDosyaYolu);

            // Sağ tema resmini yükle
            Image sagTemaImage = Image.FromFile(sagTemaDosyaYolu);
            using (Graphics g = Graphics.FromImage(haritaImage))
            {
                Pen pen = new Pen(Color.Black);

                // Haritanın sol tarafını (kış teması) boyayalım
                g.DrawImage(solTemaImage, new Rectangle(0, 0, genislik * 10, yukseklik * 20));

                // Haritanın sağ tarafını (yaz teması) boyayalım
                g.DrawImage(sagTemaImage, new Rectangle(genislik * 10, 0, genislik * 10, yukseklik * 20));

                for (int x = 0; x < genislik; x++)
                {
                    for (int y = 0; y < yukseklik; y++)
                    {
                        g.DrawRectangle(pen, x * 20, y * 20, 20, 20); // Kare boyutu 20x20 olarak varsayıldı
                    }
                }

                // Haritadaki diğer öğeleri ekleyebilirsiniz (örneğin hazine sandıkları ve engeller)
            }
        }




        private List<PointWithObject> occupiedSquares = new List<PointWithObject>(); // Nesnelerin kapladığı kareleri ve üzerlerindeki nesneyi tutacak liste

        private class PointWithObject
        {
            public Point Point { get; set; }
            public Control ObjectControl { get; set; }



        }



        private void Form2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Klavyeden basılan tuşa göre oyuncuyu hareket ettirin
            switch (e.KeyChar)
            {
                case 'w':
                    MovePlayer(Direction.Up);
                    break;
                case 's':
                    MovePlayer(Direction.Down);
                    break;
                case 'a':
                    MovePlayer(Direction.Left);
                    break;
                case 'd':
                    MovePlayer(Direction.Right);
                    break;
                default:
                    break;
            }
        }

        // Oyuncunun hareket yönlerini temsil eden bir enum tanımlayın
        private enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }

        private void MovePlayer(Direction direction)
        {
            // Oyuncunun mevcut konumunu alın
            Point currentPosition = playerPictureBox.Location;

            // Yeni konumu hesaplayın, hareket etme işlemini gerçekleştirin
            switch (direction)
            {
                case Direction.Up:
                    currentPosition.Y -= 20; // Yukarı hareket, 20 birimlik adım
                    break;
                case Direction.Down:
                    currentPosition.Y += 20; // Aşağı hareket, 20 birimlik adım
                    break;
                case Direction.Left:
                    currentPosition.X -= 20; // Sol hareket, 20 birimlik adım
                    break;
                case Direction.Right:
                    currentPosition.X += 20; // Sağ hareket, 20 birimlik adım
                    break;
                default:
                    break;
            }

            // Yeni konumu güncelle
            playerPictureBox.Location = currentPosition;

            // Engellerin olduğu konumları kontrol et
            List<Point> squaresToCheck = GetOccupiedSquares(currentPosition.X / 20, currentPosition.Y / 20, 1, 1);
            if (CollisionManager.Instance.IsCollision(squaresToCheck))
            {
                Console.WriteLine("Collision detected!");
                RemoveTreasureAtPosition(currentPosition);

            }

        }

        private void RemoveTreasureAtPosition(Point position)
        {
            // Hazineyi haritadan kaldır
            Console.WriteLine("Removing treasure at position: " + position.ToString());

            // Pozisyon etrafındaki 1x1 birimlik karelerin konumunu al
            List<Point> surroundingSquare = new List<Point> { position };

            // Hazineyi haritadan kaldır
            foreach (var square in surroundingSquare)
            {
                // Hazineyi bul
                List<PointWithObject> treasuresToRemove = occupiedSquares
                    .Where(treasure => treasure.Point == square && treasure.ObjectControl != null)
                    .ToList();

                // Hazineyi haritadan kaldır
                foreach (var treasure in treasuresToRemove)
                {
                    Controls.Remove(treasure.ObjectControl);
                    occupiedSquares.Remove(treasure);

                    // Hazine nesnesinden de kaldır
                    hazine.treasureLocations.Remove(treasure.Point);

                }
            }
        }







        private void OyuncuyuYerlestir(string tur)
        {
            Random rnd = new Random();

            // Nesnenin başlangıç koordinatları
            int startX = rnd.Next(genislik);
            int startY = rnd.Next(yukseklik);


            do
            {
                startX = rnd.Next(genislik);
                startY = rnd.Next(yukseklik);
            } while (startX <= 15 || startY <= 15 || startX >= genislik - 15 || startY >= yukseklik - 15 | Math.Abs(startX - (genislik / 2)) <= 15);

            // Nesnenin boyutunu rastgele olarak belirle
            Size boyut = GetObjectSize(tur, rnd);

            // Nesnenin kapladığı kareleri belirle
            List<Point> occupiedSquaresForCurrentObject = new List<Point>();
            occupiedSquaresForCurrentObject = GetOccupiedSquares(startX, startY, boyut.Width / 20, boyut.Height / 20);


            // Çakışmayı kontrol et
            bool isCollision = false;
            foreach (var square in occupiedSquaresForCurrentObject)
            {
                if (occupiedSquares.Any(x => x.Point == square && x.ObjectControl != null))
                {
                    isCollision = true;
                    break;
                }
            }


            // Eğer çakışma yoksa, nesneyi oluştur ve kapladığı kareleri güncelle
            if (!isCollision)
            {
                PictureBox pb = new PictureBox();
                pb.Location = new Point(startX * 20, startY * 20); // Kare boyutu 20x20 olarak varsayıldı
                pb.Size = boyut; // Nesne boyutunu rastgele belirledik
                pb.SizeMode = PictureBoxSizeMode.StretchImage;

                // Nesne türüne göre görseli ekle



                if (tur == "oyuncu")
                {
                    pb.ImageLocation = @"C:\Users\Gülşah\Downloads\karakter.jpeg";
                    playerPictureBox = pb; // Oyuncu PictureBox'ını kaydet
                }


                Controls.Add(pb);

                // Kapladığı kareleri güncelle
                foreach (var square in occupiedSquaresForCurrentObject)
                {
                    occupiedSquares.Add(new PointWithObject { Point = square, ObjectControl = pb });
                }
            }
            else
            {
                // Eğer çakışma varsa, yeni bir nokta seç
                OyuncuyuYerlestir(tur);
            }
        }





        // Nesnenin kapladığı kareleri belirleme metodunu güncelle
        private List<Point> GetOccupiedSquares(int startX, int startY, int width, int height)
        {
            List<Point> squares = new List<Point>();

            for (int x = startX; x < startX + width; x++)
            {
                for (int y = startY; y < startY + height; y++)
                {
                    squares.Add(new Point(x, y));
                }
            }

            return squares;
        }


        private Size GetObjectSize(string tur, Random rnd)
        {
            Size boyut;

            if (tur == "agac")
            {
                int[] boyutlar = { 2, 3, 4, 5 };
                int rastgeleIndex = rnd.Next(boyutlar.Length);
                int boyutX = boyutlar[rastgeleIndex] * 20;
                int boyutY = boyutX;
                boyut = new Size(boyutX, boyutY);
            }
            else if (tur == "kaya")
            {
                int[] boyutlar = { 2, 3 };
                int rastgeleIndex = rnd.Next(boyutlar.Length);
                int boyutX = boyutlar[rastgeleIndex] * 20;
                int boyutY = boyutX;
                boyut = new Size(boyutX, boyutY);
            }
            else if (tur == "dag")
            {
                boyut = new Size(15 * 20, 15 * 20);
            }
            else if (tur == "duvar")
            {
                boyut = new Size(10 * 20, 20);
            }
            else
            {
                // Varsayılan boyutlar
                boyut = new Size(40, 40);
            }

            return boyut;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
