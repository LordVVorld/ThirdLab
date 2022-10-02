using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdLab
{
    public class TLModel
    {
        public class Point
        {
            public double X { get; set; }
            public double Y { get; set; }

            public Point(double x, double y)
            {
                X = x; Y = y; 
            }

            public static Point operator *(Point point, double scalar) => new Point(point.X * scalar, point.Y * scalar);
            public static Point operator *(Point point, int scalar) => new Point(point.X * scalar, point.Y * scalar);
            public static Point operator *(Point point, long scalar) => new Point(point.X * scalar, point.Y * scalar);
            public static Point operator *(Point point, short scalar) => new Point(point.X * scalar, point.Y * scalar);

            public static bool operator ==(Point left, Point right)
            {
                if (left.X != right.X || left.Y != right.Y)
                {
                    return false;
                }
                return true;
            }

            public static bool operator !=(Point left, Point right)
            {
                if (left.X != right.X || left.Y != right.Y)
                {
                    return true;
                }
                return false;
            }
        }

        public class Points
        {
            public List<Point> Collection { get; set; }
            public int Count { get { return Collection.Count; } }

            public Points(List<Point> points)
            {
                Collection = points;
            }

            public static Points operator+(Points points, Point vector)
            {
                points.Collection.ForEach(point =>
                {
                    point.X += vector.X;
                    point.Y += vector.Y;
                });
                return points;
            }

            public static Points operator -(Points points, Point vector)
            {
                points.Collection.ForEach(point =>
                {
                    point.X -= vector.X;
                    point.Y -= vector.Y;
                });
                return points;
            }

            public static Points operator *(Points points, double scalar)
            {
                points.Collection.ForEach(point => { point *= scalar; });
                return new Points(points.Collection);
            }
            public static Points operator *(Points points, int scalar)
            {
                points.Collection.ForEach(point => { point *= scalar; });
                return new Points(points.Collection);
            }
            public static Points operator *(Points points, long scalar)
            {
                points.Collection.ForEach(point => { point *= scalar; });
                return new Points(points.Collection);
            }
            public static Points operator *(Points points, short scalar)
            {
                points.Collection.ForEach(point => { point *= scalar; });
                return new Points(points.Collection);
            }


            public static bool operator ==(Points left, Points right)
            {
                if (left.Count != right.Count)
                {
                    return false;
                }
                foreach (var point in left.Collection)
                {
                    if (!right.Collection.Contains(point))
                    {
                        return false;
                    }
                }
                return true;
            }

            public static bool operator !=(Points left, Points right)
            {
                if (left.Count != right.Count)
                {
                    return true;
                }
                foreach (var point in left.Collection)
                {
                    if (!right.Collection.Contains(point))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

    }
}
