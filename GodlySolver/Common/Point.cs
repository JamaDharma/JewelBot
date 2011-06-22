/*
 * Created by SharpDevelop.
 * User: JD
 * Date: 21.06.2011
 * Time: 9:20
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Dynamic;

namespace GodlySolver
{
	public class Point
	{
		public readonly int X;
		public readonly int Y;
	
		public Point(int x, int y) {
			this.X = x;
			this.Y = y;
		}
		
		public static bool operator ==(Point left, Point right) {
	            return left.X == right.X && left.Y == right.Y;
	        }
		public static bool operator !=(Point left, Point right) {
	            return !(left == right);
	        }
		
		public static bool operator >(Point left, Point right) {
			return left.X != right.X ? left.X > right.X : left.Y > right.Y;
	        }
		public static bool operator <(Point left, Point right) {
			return left.X != right.X ? left.X < right.X : left.Y < right.Y;
	        }		
	
		public static Point operator +(Point left, Vector right) {
			return new Point(left.X + right.X, left.Y + right.Y);
		}
	
		public static Point operator -(Point left, Vector right) {
			return new Point(left.X - right.X, left.Y - right.Y);
		}
		
		public override bool Equals(object obj) {
	            if (!(obj is Point)) return false;
	            Point comp = (Point)obj;
	            return comp.X == this.X && comp.Y == this.Y;
	        }
		
		public override int GetHashCode() {
			return (X<<4) ^ Y;
	        }
		
		public override string ToString()
		{
			return string.Format("({0}, {1})", X, Y);
		}
		
	}
}
