/*
 * Created by SharpDevelop.
 * User: JD
 * Date: 21.06.2011
 * Time: 8:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Solver
{
	public class Move
	{
		public Point A {get; private set;}
		public Point B {get; private set;}
		
		public Move(Point a, Point b)
		{
			if (a > b){
				A = a;
				B = b;
			}
			else{
				A = b;
				B = a;
			}
		}
		
		public void MoveBoard(Board board)
		{
			var t = board[A.X,A.Y];
			board[A.X,A.Y] = board[B.X,B.Y];
			board[B.X,B.Y] = t;
		}
				
		public static bool operator ==(Move left, Move right) {
	            return left.A == right.A && left.B == right.B;
	        }
		
		public static bool operator !=(Move left, Move right) {
	            return !(left == right);
	        }
		
				
		public override bool Equals(object obj) {
	            if (!(obj is Move)) return false;
	            Move comp = (Move)obj;
	            return comp.A == this.A && comp.B == this.B;
	        }
		
		public override int GetHashCode() {
			return (A.GetHashCode()<<8) ^ B.GetHashCode();
	        } 
	}
}
