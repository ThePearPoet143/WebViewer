using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace WebView.Utility
{
    public class Doublet
    {
        public int X, Y;


        #region Constructors

        public Doublet()
        {
            X = Y = 0;
        }

        public Doublet(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Doublet(float x, float y)
        {
            X = (int)x;
            Y = (int)y;
        }

        public Doublet(double x, double y)
        {
            X = (int)x;
            Y = (int)y;
        }

        public Doublet(Doublet d)
        {
            X = d.X;
            Y = d.Y;
        }

        public Doublet(DoubletF d)
        {
            X = (int)d.X;
            Y = (int)d.Y;
        }

        public Doublet(Point p)
        {
            X = p.X;
            Y = p.Y;
        }

        public Doublet(Size s)
        {
            X = s.Width;
            Y = s.Height;
        }

        public Doublet(string s)
        {
            string[] args = s.Split(',');
            if (args.Length != 2)
                throw new Exception("Illegal Doublet construction string");
            X = int.Parse(args[0].Trim());
            Y = int.Parse(args[1].Trim());
        }

        public Doublet(string x, string y)
        {
            X = int.Parse(x.Trim());
            Y = int.Parse(y.Trim());
        }

        #endregion

        #region Operators

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public static bool operator ==(Doublet lhs, Doublet rhs)
        {
            return
                lhs.X == rhs.X
                && lhs.Y == rhs.Y;
        }

        public static bool operator !=(Doublet lhs, Doublet rhs)
        {
            return
                lhs.X != rhs.X
                || lhs.Y != rhs.Y;
        }

        public static Doublet operator +(Doublet lhs, Doublet rhs)
        {
            Doublet result = new Doublet(lhs);
            result.X += rhs.X;
            result.Y += rhs.Y;
            return result;
        }

        public static Doublet operator +(Doublet lhs, int rhs)
        {
            Doublet result = new Doublet(lhs);
            result.X += rhs;
            result.Y += rhs;
            return result;
        }

        public static Doublet operator -(Doublet lhs, Doublet rhs)
        {
            Doublet result = new Doublet(lhs);
            result.X -= rhs.X;
            result.Y -= rhs.Y;
            return result;
        }

        public static Doublet operator -(Doublet lhs, int rhs)
        {
            Doublet result = new Doublet(lhs);
            result.X -= rhs;
            result.Y -= rhs;
            return result;
        }

        public static Doublet operator *(Doublet lhs, Doublet rhs)
        {
            Doublet result = new Doublet(lhs);
            result.X *= rhs.X;
            result.Y *= rhs.Y;
            return result;
        }

        public static Doublet operator *(Doublet lhs, int rhs)
        {
            Doublet result = new Doublet(lhs);
            result.X *= rhs;
            result.Y *= rhs;
            return result;
        }

        public static Doublet operator /(Doublet lhs, Doublet rhs)
        {
            Doublet result = new Doublet(lhs);
            result.X /= rhs.X;
            result.Y /= rhs.Y;
            return result;
        }

        public static Doublet operator /(Doublet lhs, int rhs)
        {
            Doublet result = new Doublet(lhs);
            result.X /= rhs;
            result.Y /= rhs;
            return result;
        }

        #endregion

        #region Conversions

        public Point ToPoint()
        {
            return new Point(X, Y);
        }

        public Size ToSize()
        {
            return new Size(X, Y);
        }

        public DoubletF ToDoubletF()
        {
            return new DoubletF(this.X, this.Y);
        }

        public static bool Exists(object obj)
        {
            if (obj == null)
                return false;
            return true;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}", X, Y);
        }

        #endregion

        #region Limits

        public int Min()
        {
            return (X < Y) ? X : Y;
        }

        public int Max()
        {
            return (X > Y) ? X : Y;
        }

        public void UpperLimit(int limit)
        {
            if (X > limit)
                X = limit;
            if (Y > limit)
                Y = limit;
        }

        public void UpperLimit(Doublet limit)
        {
            if (X > limit.X)
                X = limit.X;
            if (Y > limit.Y)
                Y = limit.Y;
        }

        public void LowerLimit(int limit)
        {
            if (X < limit)
                X = limit;
            if (Y < limit)
                Y = limit;
        }

        public void LowerLimit(Doublet limit)
        {
            if (X < limit.X)
                X = limit.X;
            if (Y < limit.Y)
                Y = limit.Y;
        }

        #endregion
    }
}