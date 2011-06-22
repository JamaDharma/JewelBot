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

		int Walk(byte colour, Point start, Vector offset)
		{
			Point next = start+offset;
			if(_board.SameColour(colour, next))
				return 1 + Walk(colour, next, offset);
			return 1;
		}
		int Mark(Point start, Vector offset)
		{
			var colour = _board[start];
			int count = Walk(colour, start, offset);
			if(count >= 3)
				_explosions.AddRange(start, start+offset*(count-1));
			return count;
		}
		void HorizontalMark()
		{
			for(int i = 0; i < 8; i++)
				for(int j = 0; j < 6; j += Mark(new Point(i,j), Offset.Horizontal))
					;
		}
		void VerticallMark()
		{
			for(int j = 0; j < 8; j++)
				for(int i = 0; i < 6; i += Mark(new Point(i,j), Offset.Vertical))
					;
		}
		
		void UpdateBoard()
		{
			foreach(var p in _explosions.Range)
				_board[p] = 0;
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
