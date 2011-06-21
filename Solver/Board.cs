/*
 * Created by SharpDevelop.
 * User: JD
 * Date: 20.06.2011
 * Time: 6:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Solver
{
	public class Board
	{
		public static void WalkMap(Action<int, int> work)
		{
			for(int i = 0; i<8; i++)
				for(int j = 0; j<8; j++)
					work(i,j);
		}
		
		byte[,] _map;
		public byte this[int i, int j]
		{
			get{ return _map[i,j];}
			set{ _map[i,j] = value;}
		}
		
		public Board(byte[,] map)
		{
			_map=map;
		}

		public bool SameColour(Point p1, Point p2)
		{
			return SameColour(p1.X, p1.Y, p2.X, p2.Y);
		}

		public bool SameColour(int i1, int j1, int i2, int j2)
		{
			if(i1>=0 && i1 <8)
				if(j1>=0 && j1 <8)
					if(i2>=0 && i2 <8)
						if(j2>=0 && j2 <8)
							if(_map[i2,j2]>0)
								return _map[i1,j1] == _map[i2,j2];
			return false;
		}
		
	}
}
