/*
 * Created by SharpDevelop.
 * User: JD
 * Date: 23.06.2011
 * Time: 0:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NUnit.Framework;

namespace GodlySolver
{
	[TestFixture]
	public class FillerTest
	{
		private void check(Point p, byte[,] res, Board board)
		{
			Assert.GreaterOrEqual(board[p], 1);
			Assert.LessOrEqual(board[p], 6);
			if(res[p.X,p.Y] > 0)
				Assert.AreEqual(res[p.X,p.Y], board[p]);
		}
		
		[Test]
		public void Nothing()
		{
			byte[,] map = new byte[,]{
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
			};
			byte[,] mapRes = new byte[,]{
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
			};

			var board = new Board(map);
			
			new Filler(board).Implode();
			
			Board.WalkMap(p=>check(p,mapRes,board));
		}
		[Test]
		public void Everything()
		{
			byte[,] map = new byte[,]{
				{1,1,1,1,1,1,1,1},
				{1,1,1,1,1,1,1,1},
				{1,1,1,1,1,1,1,1},
				{1,1,1,1,1,1,1,1},
				{1,1,1,1,1,1,1,1},
				{1,1,1,1,1,1,1,1},
				{1,1,1,1,1,1,1,1},
				{1,1,1,1,1,1,1,1},
			};
			byte[,] mapRes = new byte[,]{
				{1,1,1,1,1,1,1,1},
				{1,1,1,1,1,1,1,1},
				{1,1,1,1,1,1,1,1},
				{1,1,1,1,1,1,1,1},
				{1,1,1,1,1,1,1,1},
				{1,1,1,1,1,1,1,1},
				{1,1,1,1,1,1,1,1},
				{1,1,1,1,1,1,1,1},
			};

			var board = new Board(map);
			
			new Filler(board).Implode();
			
			Board.WalkMap(p=>check(p,mapRes,board));
		}
		[Test]
		public void Complex()
		{
			byte[,] map = new byte[,]{
				{1,0,0,0,5,5,0,0},
				{1,0,0,0,1,2,1,0},
				{1,0,0,0,0,0,0,0},
				{1,0,0,0,0,0,0,3},
				{4,0,0,0,0,0,0,1},
				{0,0,0,0,0,0,0,0},
				{0,0,1,0,0,1,0,0},
				{0,0,0,0,0,0,0,0},
			};
			byte[,] mapRes = new byte[,]{
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{1,0,0,0,0,0,0,0},
				{1,0,0,0,0,0,0,0},
				{1,0,0,0,0,5,0,0},
				{1,0,0,0,5,2,0,3},
				{4,0,1,0,1,1,1,1},
			};	

			var board = new Board(map);
			
			new Filler(board).Implode();
			
			Board.WalkMap(p=>check(p,mapRes,board));
		}
	}
}
