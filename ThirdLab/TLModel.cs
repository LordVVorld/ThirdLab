using DynamicData;
using System;
using System.Collections.Generic;

namespace ThirdLab
{
    public class TLModel
    {
        private static readonly Point examplePoint = new Point(2, 5, 1);
        private static readonly Points examplePointSet = new Points(
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

            public override bool Equals(object obj)
            {
                return obj is Point point &&
                       X == point.X &&
                       Y == point.Y &&
                       Z == point.Z;
            }

            public override int GetHashCode()
            {
                int hashCode = -307843816;
                hashCode = hashCode * -1521134295 + X.GetHashCode();
                hashCode = hashCode * -1521134295 + Y.GetHashCode();
                hashCode = hashCode * -1521134295 + Z.GetHashCode();
                return hashCode;
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
                List<Point> collection = new List<Point>();
                foreach (var point in points.Collection)
                {
                    collection.Add(
                        new Point(
                            point.X + vector.X,
                            point.Y + vector.Y,
                            point.Z + vector.Z)
                        );
                }
                return new Points(collection);
            }

            public static Points operator -(Points points, Point vector)
            {
                List<Point> collection = new List<Point>();
                foreach (var point in points.Collection)
                {
                    collection.Add(
                        new Point(
                            point.X - vector.X,
                            point.Y - vector.Y,
                            point.Z - vector.Z)
                        );
                }
                return new Points(collection);
            }

            public static Points operator *(Points points, double scalar)
            {
                List<Point> collection = new List<Point>();
                foreach (var point in points.Collection)
                {
                    collection.Add(point * scalar);
                }
                return new Points(collection);
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
                    result += point.ToString() + ".";
                }
                result = result.Remove(result.LastIndexOf('.')) + "}";
                return result;
            }

            public override bool Equals(object obj)
            {
                return obj is Points points &&
                       EqualityComparer<List<Point>>.Default.Equals(Collection, points.Collection) &&
                       Count == points.Count;
            }

            public override int GetHashCode()
            {
                int hashCode = 1676771821;
                hashCode = hashCode * -1521134295 + EqualityComparer<List<Point>>.Default.GetHashCode(Collection);
                hashCode = hashCode * -1521134295 + Count.GetHashCode();
                return hashCode;
            }
        }

        public static string PointMultiply(string scalar)
        {
            if(!double.TryParse(scalar, out double value))
            {
                throw new Exception("Некорректно задан скаляр");
            };
            return (examplePoint * value).ToString();
        }
            
        public static string PointSetMultiply(string scalar)
        {
            if (!double.TryParse(scalar, out double value))
            {
                throw new Exception("Некорректно задан скаляр");
            };
            return (examplePointSet * value).ToString();
        }

        public static bool PointEqualityCheck(string point)
        {
            PointValidation(point);
            return examplePoint == StrToPoint(point);
        }

        public static bool PointSetEqualityCheck(string pointSet)
        {
            PointSetValidation(pointSet);
            return examplePointSet == StrToPointSet(pointSet);
        }

        public static bool PointUnEqualityCheck(string point)
        {
            PointValidation(point);
            return examplePoint != StrToPoint(point);
        }
        
        public static bool PointSetUnEqualityCheck(string pointSet)
        {
            PointSetValidation(pointSet);
            return examplePointSet != StrToPointSet(pointSet);
        }

        public static string PointSetOffset(string point, bool isAddition)
        {
            PointValidation(point);
            return (isAddition ?
                (examplePointSet + StrToPoint(point)) :
                (examplePointSet - StrToPoint(point))
            ).ToString();
        }

        static Point StrToPoint(string point)
        {
            string[] values = point.Split(new char[] { '(', ';', ')' },
                                          StringSplitOptions.RemoveEmptyEntries);
            double[] coords = new double[3];
            for (int index = 0; index < 3; index++)
            {
                coords[index] = double.Parse(values[index]);
            }
            return new Point(coords[0], coords[1], coords[2]);
        }

        static Points StrToPointSet(string pointSet)
        {
            string[] points = pointSet.Split(new char[] { '{', '.', '}' },
                                             StringSplitOptions.RemoveEmptyEntries);
            List<Point> pointList = new List<Point>();
            foreach (var point in points)
            {
                pointList.Add(StrToPoint(point));
            }
            return new Points(pointList);
        }
    
        static void PointValidation(string point)
        {
            if (point is null)
            {
                throw new Exception("Не задано значение точки.");
            }

            string[] coords = point.Split(new char[] { '(', ';', ')' }, StringSplitOptions.RemoveEmptyEntries);
            if (coords.Length != 3)
            {
                throw new Exception("Некорректно задано значение точки.");
            }

            Dictionary<int, char> indexedCoords = new Dictionary<int, char>()
            {
                { 0, 'X'},
                { 1, 'Y'},
                { 2, 'Z'}
            };
            for (int index = 0; index < 3; index++)
            {
                if(!double.TryParse(coords[index], out double value))
                {
                    throw new Exception($"Некорректное значение {indexedCoords[index]}.");
                }
            }
        }

        static void PointSetValidation(string pointSet)
        {
            if (pointSet is null)
            {
                throw new Exception("Не задано значение множества.");
            }
            string[] points = pointSet.Split(new char[] { '{', '.', '}' },
                                             StringSplitOptions.RemoveEmptyEntries);
            foreach (var point in points)
            {
                try
                {
                    PointValidation(point);
                }
                catch (Exception e)
                {
                    int index = points.IndexOf(point) + 1;
                    throw new Exception($"Точка {index}. {e.Message}");
                }
            }
        }
    }
}