using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WinFormsApp2;

public class Karakter
{
    protected Random rnd = new Random();
    protected CollisionManager collisionManager;
    protected int genislik;
    protected int yukseklik;
    protected Control.ControlCollection controls;
    private PictureBox pb;


    public Karakter(int genislik, int yukseklik, Control.ControlCollection controls)
    {
        this.genislik = genislik;
        this.yukseklik = yukseklik;
        this.controls = controls;
        this.collisionManager = CollisionManager.Instance;
        Hazine hazine = new Hazine(genislik, yukseklik, controls);
        List<Point> hazinelerinKonumlari = hazine.treasureLocations;


    }


    public void PlaceObject()
    {
        int startX, startY;
        do
        {
            startX = rnd.Next(genislik);
            startY = rnd.Next(yukseklik);
        } while (startX <= 15 || startY <= 15 || startX >= genislik - 15 || startY >= yukseklik - 15 || Math.Abs(startX - (genislik / 2)) <= 15);

        Size boyut = GetObjectSize();

        List<Point> occupiedSquaresForCurrentObject = GetOccupiedSquares(startX, startY, boyut.Width / 20, boyut.Height / 20);

        if (!collisionManager.IsCollision(occupiedSquaresForCurrentObject))
        {
            pb = new PictureBox();
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



    public void EnKisaYoluBul(Point karakterKonumu, List<Point> hazineKonumlari)
    {
        while (hazineKonumlari.Count > 0)
        {
            Point enYakinHazineKonumu = hazineKonumlari[0];
            double enKisaMesafe = MesafeHesapla(karakterKonumu, hazineKonumlari[0]);

            // Tüm hazine konumları arasında dolaşarak en kısa mesafeyi bulun
            for (int i = 1; i < hazineKonumlari.Count; i++)
            {
                double mesafe = MesafeHesapla(karakterKonumu, hazineKonumlari[i]);
                if (mesafe < enKisaMesafe)
                {
                    enKisaMesafe = mesafe;
                    enYakinHazineKonumu = hazineKonumlari[i];
                }
            }

            // Karakterin yeni konumunu en yakın hazineye ayarlayın
            pb.Location = new Point(enYakinHazineKonumu.X * 20, enYakinHazineKonumu.Y * 20);

            // Yeni karakter konumunu güncelleyin
            karakterKonumu = enYakinHazineKonumu;

            // Bu hazineyi listeden kaldırın
            hazineKonumlari.Remove(enYakinHazineKonumu);
        }
    }




    private double MesafeHesapla(Point nokta1, Point nokta2)
    {
        int deltaX = nokta2.X - nokta1.X;
        int deltaY = nokta2.Y - nokta1.Y;
        return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
    }




    protected List<Point> GetOccupiedSquares(int startX, int startY, int widthInSquares, int heightInSquares)
    {
        return Enumerable.Range(startX, widthInSquares)
            .SelectMany(x => Enumerable.Range(startY, heightInSquares).Select(y => new Point(x, y)))
            .ToList();
    }



    public virtual Size GetObjectSize()
    {
        // Hazine boyutunu burada belirleyin
        return new Size(40, 40);
    }

    protected string GetImagePath()
    {

        return @"C:\Users\EZGI\OneDrive\Masaüstü\prolab1resim\ariresmi.png";
    }

    // Oyuncunun hareket yönlerini temsil eden bir enum tanımlayın
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    // Oyuncuyu hareket ettiren bir metod tanımlayın
    public void MovePlayer(Direction direction)
    {
        // Oyuncunun mevcut konumunu alın
        Point currentPosition = pb.Location;

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

    }


}
