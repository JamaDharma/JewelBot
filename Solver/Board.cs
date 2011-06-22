/*
 * Created by SharpDevelop.
 * User: JD
 * Date: 20.06.2011
 * Time: 6:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Solver
{
	public class Board
	{
		public static void WalkMap(Action<Point> work)
		{
			for(int i = 0; i<8; i++)
				for(int j = 0; j<8; j++)
					work(new Point(i,j));
		}
		
		public static void WalkMap(Action<int, int> work)
		{
			for(int i = 0; i<8; i++)
				for(int j = 0; j<8; j++)
					work(i,j);
		}
		
		byte[,] _map;
		
		public Board(byte[,] map)
		{
			_map=map;
		}

		public byte this[Point p]
		{
			get{ return _map[p.X,p.Y];}
			set{ _map[p.X,p.Y] = value;}
		}

		public byte this[int i, int j]
		{
			get{ return _map[i,j];}
			set{ _map[i,j] = value;}
		}
		
		public bool SameColour(Point p1, Point p2)
		{
			return SameColour(p1.X, p1.Y, p2.X, p2.Y);
		}

		public bool SameColour(int i1, int j1, int i2, int j2)
		{
			if(i1>=0 && i1 <8)
				if(j1>=0 && j1 <8)
					return SameColour (_map[i1,j1], i2, j2);
			return false;
		}
		
		public bool SameColour(byte colour, Point p)
		{
			return SameColour (colour, p.X, p.Y);
		}
		
		public bool SameColour(byte colour, int x, int y)
		{
			if(colour>0)
				if(x>=0 && x <8)
					if(y>=0 && y <8)
						return colour == _map[x,y];
			return false;
		}
		
		
		public Board Copy()
		{
			byte[,] t = new byte[8,8];
			Array.Copy(_map,t, _map.Length);
			return new Board(t);
		}
	}
}
