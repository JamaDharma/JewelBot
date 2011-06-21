/*
 * Created by SharpDevelop.
 * User: JD
 * Date: 21.06.2011
 * Time: 8:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace Solver
{

	/// <summary>
	/// Description of GeoScan.
	/// </summary>
	public class GeoScanner
	{
		Board _board;
		HashSet<Move> _deposits = new HashSet<Move>();
		
		public GeoScanner(Board board)
		{
			_board = board;
		}
		
		void Add(Point f, Point p1, Point p2)
		{
			if(_board.SameColour(f, p2))
				_deposits.Add(new Move(p1, p2));
		}
		void AddMiddle(Point f, Point p, Vector off)
		{
			Add(f, p, p + off.Mirror());
			Add(f, p, p - off.Mirror());
		}
		void AddLeft(Point f, Point p, Vector off)
		{
			AddMiddle(f, p, off);
			Add(f, p, p - off);
		}
		void AddRight(Point f, Point p, Vector off)
		{
			AddMiddle(f, p, off);
			Add(f, p, p + off);
		}		
		void Scan(Point first, Vector offset)
		{
			Func<Vector, bool> check = 
				of => _board.SameColour(first,first+of);
			
			if(check(offset))
			{
				AddLeft(first, first-offset, offset);
				AddRight(first, first+2*offset, offset);
			}
			if(check(2*offset))
				AddMiddle(first, first+offset, offset);
		}
		
		void HorizontalMark()
		{
			for(int i = 0; i < 8; i++)
				for(int j = 0; j < 8; j ++)
			{
				Scan(new Point(i,j), Offset.Horizontal);
				Scan(new Point(i,j), Offset.Vertical);
			}
					
		}
		
		public IEnumerable<Move> GetDeposits()
		{
			_deposits.Clear();
			HorizontalMark();
			return _deposits;
		}
	}
}
