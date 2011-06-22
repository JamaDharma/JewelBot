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

	public class Vector
	{
		public readonly int X;
		public readonly int Y;

		public Vector(int x, int y) {
			this.X = x;
			this.Y = y;
		}

		public static Vector operator +(Vector left, Vector right) {
			return new Vector(left.X + right.X, left.Y + right.Y);
		}

		public static Vector operator -(Vector left, Vector right) {
			return new Vector(left.X - right.X, left.Y - right.Y);
		}
		
		public static Vector operator -(Vector v) {
			return new Vector(-v.X, -v.Y);
		}
		
		public static Vector operator *(Vector left,int right) {
			return new Vector(left.X * right, left.Y * right);
		}
		
		public static Vector operator *(int left, Vector right) {
			return new Vector(right.X * left, right.Y * left);
		}

		public Vector Mirror()
		{
			return new Vector(Y, X);
		}
	}
}
