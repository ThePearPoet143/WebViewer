using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace WebView.Utility
{
    public class DoubletF
    {
        public float X, Y;


        #region Constructors

        public DoubletF()
        {
            X = Y = 0;
        }

        public DoubletF(float x, float y)
        {
            X = x;
            Y = y;
        }

        public DoubletF(double x, double y)
        {
            X = (float)x;
            Y = (float)y;
        }

        public DoubletF(DoubletF d)
        {
            X = d.X;
            Y = d.Y;
        }

        public DoubletF(Point p)
        {
            X = (float)p.X;
            Y = (float)p.Y;
        }

        public DoubletF(PointF p)
        {
            X = p.X;
            Y = p.Y;
        }

        public DoubletF(Size s)
        {
            X = (float)s.Width;
            Y = (float)s.Height;
        }

        public DoubletF(SizeF s)
        {
            X = s.Width;
            Y = s.Height;
        }

        public DoubletF(string s)
        {
            string[] args = s.Split(',');
            if (args.Length != 2)
                throw new Exception("Illegal DoubletF construction string");
            X = float.Parse(args[0].Trim());
            Y = float.Parse(args[1].Trim());
        }

        public DoubletF(string x, string y)
        {
            X = float.Parse(x.Trim());
            Y = float.Parse(y.Trim());
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

        public static bool operator ==(DoubletF lhs, DoubletF rhs)
        {
            return
                lhs.X == rhs.X
                && lhs.Y == rhs.Y;
        }

        public static bool operator !=(DoubletF lhs, DoubletF rhs)
        {
            return
                lhs.X != rhs.X
                || lhs.Y != rhs.Y;
        }

        public static DoubletF operator +(DoubletF lhs, DoubletF rhs)
        {
            DoubletF result = new DoubletF(lhs);
            result.X += rhs.X;
            result.Y += rhs.Y;
            return result;
        }

        public static DoubletF operator +(DoubletF lhs, float rhs)
        {
            DoubletF result = new DoubletF(lhs);
            result.X += rhs;
            result.Y += rhs;
            return result;
        }

        public static DoubletF operator +(DoubletF lhs, double rhs)
        {
            DoubletF result = new DoubletF(lhs);
            result.X += (float)rhs;
            result.Y += (float)rhs;
            return result;
        }

        public static DoubletF operator -(DoubletF lhs, DoubletF rhs)
        {
            DoubletF result = new DoubletF(lhs);
            result.X -= rhs.X;
            result.Y -= rhs.Y;
            return result;
        }

        public static DoubletF operator -(DoubletF lhs, float rhs)
        {
            DoubletF result = new DoubletF(lhs);
            result.X -= rhs;
            result.Y -= rhs;
            return result;
        }

        public static DoubletF operator -(DoubletF lhs, double rhs)
        {
            DoubletF result = new DoubletF(lhs);
            result.X -= (float)rhs;
            result.Y -= (float)rhs;
            return result;
        }

        public static DoubletF operator *(DoubletF lhs, DoubletF rhs)
        {
            DoubletF result = new DoubletF(lhs);
            result.X *= rhs.X;
            result.Y *= rhs.Y;
            return result;
        }

        public static DoubletF operator *(DoubletF lhs, float rhs)
        {
            DoubletF result = new DoubletF(lhs);
            result.X *= rhs;
            result.Y *= rhs;
            return result;
        }

        public static DoubletF operator *(DoubletF lhs, double rhs)
        {
            DoubletF result = new DoubletF(lhs);
            result.X *= (float)rhs;
            result.Y *= (float)rhs;
            return result;
        }

        public static DoubletF operator /(DoubletF lhs, DoubletF rhs)
        {
            DoubletF result = new DoubletF(lhs);
            result.X /= rhs.X;
            result.Y /= rhs.Y;
            return result;
        }

        public static DoubletF operator /(DoubletF lhs, float rhs)
        {
            DoubletF result = new DoubletF(lhs);
            result.X /= rhs;
            result.Y /= rhs;
            return result;
        }

        public static DoubletF operator /(DoubletF lhs, double rhs)
        {
            DoubletF result = new DoubletF(lhs);
            result.X /= (float)rhs;
            result.Y /= (float)rhs;
            return result;
        }

        #endregion

        #region Conversions

        public PointF ToPointF()
        {
            return new PointF(X, Y);
        }

        public Point ToPoint()
        {
            return new Point((int)X, (int)Y);
        }

        public SizeF ToSizeF()
        {
            return new SizeF(X, Y);
        }

        public Size ToSize()
        {
            return new Size((int)X, (int)Y);
        }

        public Doublet ToDoublet()
        {
            return new Doublet((int)X, (int)Y);
        }

        public DoubletF Truncate()
        {
            return new DoubletF(
                (float)Math.Truncate((double)X),
                (float)Math.Truncate((double)Y));
        }

        public DoubletF Ceiling()
        {
            return new DoubletF(
                Math.Ceiling(X),
                Math.Ceiling(Y));
        }

        public DoubletF Floor()
        {
            return new DoubletF(
                Math.Floor(X),
                Math.Floor(Y));
        }

        public DoubletF Round()
        {
            return new DoubletF(
                Math.Round(X, MidpointRounding.AwayFromZero),
                Math.Round(Y, MidpointRounding.AwayFromZero));
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

        public string ToString(int precision)
        {
            string template = ("{0:Fx}, {1:Fx}").Replace("x", precision.ToString());
            return string.Format(template, X, Y);
        }

        #endregion

        #region Limits

        public float Min()
        {
            return (X < Y) ? X : Y;
        }

        public float Max()
        {
            return (X > Y) ? X : Y;
        }

        public void UpperLimit(float limit)
        {
            if (X > limit)
                X = limit;
            if (Y > limit)
                Y = limit;
        }

        public void UpperLimit(DoubletF limit)
        {
            if (X > limit.X)
                X = limit.X;
            if (Y > limit.Y)
                Y = limit.Y;
        }

        public void LowerLimit(float limit)
        {
            if (X < limit)
                X = limit;
            if (Y < limit)
                Y = limit;
        }

        public void LowerLimit(DoubletF limit)
        {
            if (X < limit.X)
                X = limit.X;
            if (Y < limit.Y)
                Y = limit.Y;
        }

        #endregion
    }
}