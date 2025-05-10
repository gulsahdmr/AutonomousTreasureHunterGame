using System.Windows.Forms;

public class HareketsizEngel : Engel
{
    public HareketsizEngel(int genislik, int yukseklik, Control.ControlCollection controls) : base(genislik, yukseklik, controls) { }

    public override void PlaceObject()
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
            PictureBox pb = new PictureBox();
            pb.Location = new Point(startX * 20, startY * 20);
            pb.Size = boyut;
            pb.SizeMode = PictureBoxSizeMode.StretchImage;


            // Nesne türüne göre görseli ekle (alt sınıflarda bu ayrıntılar belirlenebilir)

            if (startX < genislik / 2)
            { pb.ImageLocation = GetWinterImagePath(); }

            else
            { pb.ImageLocation = GetSummerImagePath(); }



            controls.Add(pb);

            collisionManager.AddOccupiedSquares(occupiedSquaresForCurrentObject);
        }
        else
        {
            PlaceObject(); // Recursive call is unnecessary, consider refactoring
        }
    }

    protected virtual string GetWinterImagePath()
    {
        return ""; // Varsayılan olarak boş bir yol döndür
    }


    protected virtual string GetSummerImagePath()
    {
        return ""; // Varsayılan olarak boş bir yol döndür
    }
}
