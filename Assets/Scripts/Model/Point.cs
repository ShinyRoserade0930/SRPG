using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Point : IEquatable<Point>
{
    public int x;
    public int y;

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public static Point operator +(Point a, Point b)
    {
        return new Point(a.x + b.x, a.y + b.y);
    }

    public static Point operator -(Point a, Point b)
    {
        return new Point(a.x - b.x, a.y - b.y);
    }

    public static bool operator ==(Point a, Point b)
    {
        return a.x == b.x && a.y == b.y;
    }

    public static bool operator !=(Point a, Point b)
    {
        return !(a == b);
    }

    public override bool Equals(object obj)
    {
        if (obj is Point p)
        {
            return x == p.x && y == p.y;
        }
        return false;
    }

    public bool Equals(Point p)
    {
        return x == p.x && y == p.y;
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + x.GetHashCode();
            hash = hash * 23 + y.GetHashCode();
            return hash;
        }
    }

    public override string ToString()
    {
        return string.Format("({0},{1})", x, y);
    }

    public static implicit operator Vector2(Point p)
    {
        return new Vector2(p.x, p.y);
    }
}
