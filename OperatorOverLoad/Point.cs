using System;

class Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public static Point operator +(Point a, Point b)
    {
        return new Point(a.X + b.X, a.Y + b.Y);
    }

    public static Point operator -(Point a, Point b)
    {
        return new Point(a.X - b.X, a.Y - b.Y);
    }
    public static bool operator ==(Point a, Point b)
    {
        return a.X == b.X && a.Y == b.Y;
    }

    public static bool operator !=(Point a, Point b)
    {
        return !(a == b);
    }

    // كمان لازم override Equals و GetHashCode
    public override bool Equals(object obj)
    {
        if (obj is Point p)
            return this == p;
        return false;
    }

    public override int GetHashCode()
    {
        return X ^ Y;
    }

    public override string ToString()
    {
        return $"({X}, {Y})";
    }
}

class Program
{
    static void Main()
    {
        Point p1 = new Point(3, 4);
        Point p2 = new Point(1, 2);

        Point sum = p1 + p2;
        Point diff = p1 - p2;

        Console.WriteLine("Sum: " + sum);     
        Console.WriteLine("Diff: " + diff);    
    }
}