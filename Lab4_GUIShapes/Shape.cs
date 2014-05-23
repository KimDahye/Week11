using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Lab4_GUIShapes
{
    [Serializable]
    class Shape
    {
        public virtual void Show(Graphics g)
        {
        }
    }

    [Serializable]
    class Rectangle : Shape
    {
        protected Point LeftTop;
        protected Point RightBottom;

        public Rectangle()
            : this(0, 0)
        {
        }

        public Rectangle(int Left, int Top)
            : this(Left, Top, Left + 100, Top + 100)
        {
        }

        public Rectangle(int Left, int Top, int Right, int Bottom)
        {
            this.LeftTop = new Point(Left, Top);
            this.RightBottom = new Point(Right, Bottom);
        }

        public override void Show(Graphics g)
        {
            g.FillRectangle(Brushes.SkyBlue,
                LeftTop.X, LeftTop.Y,
                RightBottom.X - LeftTop.X,
                RightBottom.Y - LeftTop.Y);

            g.DrawRectangle(Pens.Black,
                LeftTop.X, LeftTop.Y,
                RightBottom.X - LeftTop.X,
                RightBottom.Y - LeftTop.Y);
        }
    }

    [Serializable]
    class Square : Rectangle
    {
        public Square(int Left, int Top, int Width) 
            : base(Left, Top, Left + Width, Top + Width)
        {
        }
        
        public override void Show(Graphics g)
        {
            g.FillRectangle(Brushes.Cyan,
                LeftTop.X, LeftTop.Y,
                RightBottom.X - LeftTop.X,
                RightBottom.Y - LeftTop.Y);

            g.DrawRectangle(Pens.Black,
                LeftTop.X, LeftTop.Y,
                RightBottom.X - LeftTop.X,
                RightBottom.Y - LeftTop.Y);
        }
    }

    [Serializable]
    class Circle : Shape
    {
        private Point center;
        private float radius;

        public Circle(Point center, float radius)
        {
            this.center = center;
            this.radius = radius;
        }

        public override void Show(Graphics g)
        {
            g.FillEllipse(Brushes.Coral, 
                center.X - radius, center.Y - radius, radius * 2, radius * 2);
            g.DrawEllipse(Pens.Black, 
                center.X - radius, center.Y - radius, radius * 2, radius * 2);
        }

    }

    [Serializable]
    class Triangle : Shape
    {
        private Point[] points = new Point[3];

        public Triangle(Point pt1, Point pt2, Point pt3)
        {
            points[0] = pt1;
            points[1] = pt2;
            points[2] = pt3;
        }

        public override void Show(Graphics g)
        {
            g.FillPolygon(Brushes.DarkKhaki, points);
            g.DrawPolygon(Pens.Black, points);
        }

    }
}



