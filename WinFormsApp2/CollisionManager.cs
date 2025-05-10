using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public class CollisionManager
    {
        private static CollisionManager instance;
        private List<Point> occupiedSquares;

        private CollisionManager()
        {
            occupiedSquares = new List<Point>();
        }

        public static CollisionManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new CollisionManager();
                return instance;
            }
        }

        public void AddOccupiedSquares(List<Point> squares)
        {
            occupiedSquares.AddRange(squares);
        }

        public bool IsCollision(List<Point> squares)
        {
            return squares.Any(square => occupiedSquares.Contains(square));
        }
    }
}
