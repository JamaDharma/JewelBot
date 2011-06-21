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
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Solver
{

	class Exploder
	{
		static readonly Size HOffset = new Size(0,1);
		static readonly Size VOffset = new Size(1,0);
		
		Board _board;
		Explosions _explosions;
		
		public Exploder(Board board)
		{
			_board = board;
			_explosions = new Explosions();
		}

		int Walk(Point start, Size offset)
		{
			Point next = start+offset;
			if(_board.SameColour(start,next))
				return 1 + Walk(next, offset);
			return 1;
		}
		int Mark(Point start, Size offset)
		{
			int count = Walk(start, offset);
			if(count >= 3)
				_explosions.AddRange(start.X, start.Y, start.X+offset.Width*(count-1), start.Y+offset.Height*(count-1));
			return count;
		}
		void HorizontalMark()
		{
			for(Point curr = new Point(0,0); curr.X < 8; curr.X++)
				for(curr.Y=0;curr.Y < 6; curr.Y+=Mark(curr, HOffset))
					;
		}
		void VerticallMark()
		{
			for(Point curr = new Point(0,0); curr.Y < 8; curr.Y++)
				for(curr.X=0;curr.X < 6; curr.X+=Mark(curr, VOffset))
					;
		}
		void UpdateBoard()
		{
			foreach(var p in _explosions.Range)
				_board[p.X, p.Y] = 0;
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
