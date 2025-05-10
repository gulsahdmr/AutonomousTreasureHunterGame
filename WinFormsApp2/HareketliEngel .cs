using static System.Windows.Forms.AxHost;

public class HareketliEngel : Engel
{

    private PictureBox pb = new PictureBox();

    public HareketliEngel(int genislik, int yukseklik, Control.ControlCollection controls) : base(genislik, yukseklik, controls)
    {

    }

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


            pb.ImageLocation = GetImagePath();





            controls.Add(pb);

            collisionManager.AddOccupiedSquares(occupiedSquaresForCurrentObject);
        }
        else
        {
            PlaceObject(); // Recursive call is unnecessary, consider refactoring
        }
    }


    protected virtual string GetImagePath()
    {
        return ""; // Hareketli engel için görsel yolunu döndür
    }

}
