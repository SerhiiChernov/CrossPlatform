namespace Lab3;

public class Vector
{
    public int X { get; set; }
    public int Y { get; set; }

    public Vector(int x, int y)
    {
        X = x;
        Y = y;
    }

    // Для перевірки рівності координат
    public override bool Equals(object obj)
    {
        Vector v = obj as Vector;
        if (v == null) return false;
        return X == v.X && Y == v.Y;
    }

    public override int GetHashCode()
    {
        return (X, Y).GetHashCode();
    }
}