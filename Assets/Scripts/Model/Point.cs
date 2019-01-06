using System;

[System.Serializable]
public struct Point
{
    public int x;
    public int y;

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public static Point operator +(Point a, Point b) => new Point(a.x + b.x, a.y + b.y);

    public static Point operator -(Point a, Point b) => new Point(a.x - b.x, a.y - b.y);

    public static bool operator ==(Point a, Point b) => a.x == b.x && a.y == b.y;

    public static bool operator !=(Point a, Point b) => !(a == b);

    public override bool Equals(object obj)
    {
        if (obj is Point p)
        {
            return x == p.x && y == p.y;
        }
        return false;
    }

    public bool Equals(Point p) => x == p.x && y == p.y;

    public override int GetHashCode()
    {
        return ShiftAndWrap(x.GetHashCode(), 2) ^ y.GetHashCode();
    }

    private int ShiftAndWrap(int value, int positions)
    {
        positions = positions & 0x1F;

        // Save the existing bit pattern, but interpret it as an unsigned integer.
        uint number = BitConverter.ToUInt32(BitConverter.GetBytes(value), 0);
        // Preserve the bits to be discarded.
        uint wrapped = number >> (32 - positions);
        // Shift and wrap the discarded bits.
        return BitConverter.ToInt32(BitConverter.GetBytes((number << positions) | wrapped), 0);
    }

    public override string ToString() => string.Format("({0}, {1})", x, y);
}

