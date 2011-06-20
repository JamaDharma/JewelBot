/*
 * Created by SharpDevelop.
 * User: JD
 * Date: 20.06.2011
 * Time: 6:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solver
{

	class Exploder
	{
		
		Board _board;
		Explosions _explosions;
		
		public Exploder(Board board)
		{
			_board = board;
			_explosions = new Explosions();
		}

		int Walk(int i0, int j0, int di, int dj)
		{
			if(_board.SameColour(i0,j0,i0+di,j0+dj))
				return 1 + Walk(i0+di, j0+dj, di, dj);
			return 1;
		}
		void HorizontalMark()
		{
			for(int i =0; i<8;i++)
				for(int j=0; j<6;)
			{
				int count = Walk(i,j,0,1);
				if(count >= 3)
					_explosions.AddRange(i, j, i, j+count-1);
				j+=count;
			}
		}
		void VerticallMark()
		{
			for(int j =0; j<8;j++)
				for(int i=0; i<6;)
			{
				int count = Walk(i,j,1,0);
				if(count >= 3)
					_explosions.AddRange(i, j, i+count-1, j);
				i+=count;
			}
		}
		void UpdateBoard()
		{
			foreach(var t in _explosions.Range)
				_board[t.Item1, t.Item2] = 0;
		}


		public int Explode()
		{
			_explosions.Clear();
			HorizontalMark();
			VerticallMark();
			UpdateBoard();
			return _explosions.Harvest();
		}
		
	
	}
}
