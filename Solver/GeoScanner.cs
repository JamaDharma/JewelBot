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
		
		Action<Vector>  Add(byte colour, Point p)
		{
			return off => {
				var p2 = p + off;
				if(_board.SameColour(colour, p2))
					_deposits.Add(new Move(p, p2));
			};
		}
		void AddMiddle(byte colour, Point p, Vector off)
		{
			var adder = Add(colour, p + off);
			adder(off.Mirror());
			adder(-off.Mirror());
		}
		void AddLeft(byte colour, Point p, Vector off)
		{
			var adder = Add(colour, p - off);
			adder(off.Mirror());
			adder(-off.Mirror());
			adder(-off);
		}
		void AddRight(byte colour, Point p, Vector off)
		{
			var adder = Add(colour, p + 2*off);
			adder(off.Mirror());
			adder(-off.Mirror());
			adder(off);
		}		
		void Scan(Point first, Vector offset)
		{
			var colour = _board[first];
			
			if(_board.SameColour(colour, first + offset))
			{
				AddLeft(colour, first, offset);
				AddRight(colour, first, offset);
			}
			if(_board.SameColour(colour, first + 2*offset))
				AddMiddle(colour, first, offset);
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
