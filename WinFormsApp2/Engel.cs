using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WinFormsApp2;

public abstract class Engel
{
    protected Random rnd = new Random();
    protected CollisionManager collisionManager;
    protected int genislik;
    protected int yukseklik;
    protected Control.ControlCollection controls;

    public Engel(int genislik, int yukseklik, Control.ControlCollection controls)
    {
        this.genislik = genislik;
        this.yukseklik = yukseklik;
        this.controls = controls;
        this.collisionManager = CollisionManager.Instance;
    }

    public abstract void PlaceObject();


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
}
