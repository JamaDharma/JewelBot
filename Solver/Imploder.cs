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

namespace Solver
{
	class Imploder
	{
		readonly Board _board;
		
		public Imploder(Board board)
		{
			_board=board;
		}
		
		int FindFirstI(int j, int i0, Func<int, bool> p)
		{
			for(int i = i0; i >= 0; i--)
				if(p(_board[i,j]))
					return i;
			return -1;
		}
		
		void ImplodeColumn(int j)
		{
			int floor = FindFirstI(j, 7, c => c == 0);
			int ceiling = FindFirstI(j, floor, c => c != 0);
			
			for(int i = ceiling; i >= 0; i--)
				if(_board[i,j] != 0)
			{
					_board[floor,j] = _board[i,j];
					_board[i,j] = 0;
					floor--;
			}
		}
		
		public void Implode()
		{
			for(int j = 0; j<8; j++)
				ImplodeColumn(j);
		}
	}
}
