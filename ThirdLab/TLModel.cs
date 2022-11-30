using DynamicData;
using DynamicData.Kernel;
using System;
using System.Collections.Generic;

namespace ThirdLab
{
    public class TLModel
    {
        private static Point examplePoint = new Point(2, 5, 1);
        private static Points examplePointSet = new Points(
            new List<Point>{
                new Point(2, 5, 1),
                new Point(1, 1, 3),
                new Point(4, 3, 7)
            });

        public class Point
        {
            public double X { get; set; }
            public double Y { get; set; }
            public double Z { get; set; }

            public Point(double x, double y, double z)
            {
                X = x;
                Y = y;
                Z = z;
            }

            public static Point operator *(Point point, double scalar) => new Point(point.X * scalar, point.Y * scalar, point.Z * scalar);
            public static Point operator *(Point point, int scalar) => new Point(point.X * scalar, point.Y * scalar, point.Z * scalar);
            public static Point operator *(Point point, long scalar) => new Point(point.X * scalar, point.Y * scalar, point.Z * scalar);
            public static Point operator *(Point point, short scalar) => new Point(point.X * scalar, point.Y * scalar, point.Z * scalar);

            public static bool operator ==(Point left, Point right)
            {
                if (left.X != right.X || left.Y != right.Y || left.Z != right.Z)
                {
                    return false;
                }
                return true;
            }

            public static bool operator !=(Point left, Point right)
            {
                if (left.X != right.X || left.Y != right.Y || left.Z != right.Z)
                {
                    return true;
                }
                return false;
            }

            public override string ToString() => $"({X};{Y};{Z})";
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
                    point.Z += vector.Z;
                });
                return points;
            }

            public static Points operator -(Points points, Point vector)
            {
                points.Collection.ForEach(point =>
                {
                    point.X -= vector.X;
                    point.Y -= vector.Y;
                    point.Z -= vector.Z;
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

            public override string ToString()
            {
                string result = "{";
                foreach (var point in Collection)
                {
                    result += point.ToString() + ",";
                }
                result += "}";
                return result;
            }
        }

        public static string PointMultiply(double scalar) => (examplePoint * scalar).ToString();
        public static string PointSetMultiply(double scalar) => (examplePointSet * scalar).ToString();
        public static bool PointEqualityCheck(string point) => examplePoint == StringToPoint(point);
        public static bool PointSetEqualityCheck(string pointSet) => examplePointSet == StringToPointSet(pointSet);
        public static bool PointUnEqualityCheck(string point) => examplePoint != StringToPoint(point);
        public static bool PointSetUnEqualityCheck(string pointSet) => examplePointSet != StringToPointSet(pointSet);
        public static string PointSetOffset(string point, bool isAddition)
        {
            return isAddition ?
                (examplePointSet + StringToPoint(point)).ToString():
                (examplePointSet - StringToPoint(point)).ToString();
        }

        static Point StringToPoint(string value)
        {
            if (value is null)
            {
                throw new Exception("Не задано значение точки.");
            }
            string[] values = value.Split(new char[] { '(', ';', ')' }, StringSplitOptions.RemoveEmptyEntries);
            if (values.Length != 3)
            {
                throw new Exception("Некорректно задано значение точки.");
            }
            Dictionary<int, char> indexedCoords = new Dictionary<int, char>()
            {
                { 0, 'X'},
                { 1, 'Y'},
                { 2, 'Z'}
            };
            bool[] coordsValidity = new bool[3];
            double[] coords = new double[3];
            for (int index = 0; index < 3; index++)
            {
                coordsValidity[index] = double.TryParse(values[index], out coords[index]);
                if (!coordsValidity[index])
                {
                    throw new Exception($"Некорректное значение {indexedCoords[index]}.");
                }
            }
            return new Point(coords[0], coords[1], coords[2]);
        }

        static Points StringToPointSet(string value)
        {
            if (value is null)
            {
                throw new Exception("Не задано значение множества.");
            }
            
            string[] values = value.Split(new char[] { '{', ',', '}' }, StringSplitOptions.RemoveEmptyEntries);
            List<Point> points = new List<Point>();
            for (int index = 0; index < values.Length; index++)
            {
                try
                {
                    points.Add(StringToPoint(values[index]));
                }
                catch (Exception e)
                {
                    throw new Exception($"Точка {index}. {e.Message}");
                }
            }
            return new Points(points);
        }
    }
}
