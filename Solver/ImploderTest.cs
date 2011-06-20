/*
 * Created by SharpDevelop.
 * User: JD
 * Date: 20.06.2011
 * Time: 13:47
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NUnit.Framework;

namespace Solver
{
	[TestFixture]
	public class ImploderTest
	{
		
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
			var game = new Game(map);
			
			game.Implode();
			
			Board.WalkMap((i,j)=>Assert.AreEqual(mapRes[i,j], game.Board[i,j], "i:"+i+" j:"+j));
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
			var game = new Game(map);
			
			game.Implode();
			
			Board.WalkMap((i,j)=>Assert.AreEqual(mapRes[i,j], game.Board[i,j], "i:"+i+" j:"+j));
		}
		[Test]
		public void SimpleEmpty()
		{
			byte[,] map = new byte[,]{
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,1,2,1,0,0,0},
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
				{0,0,1,2,1,0,0,0},
			};			
			var game = new Game(map);
			
			game.Implode();
			
			Board.WalkMap((i,j)=>Assert.AreEqual(mapRes[i,j], game.Board[i,j], "i:"+i+" j:"+j));
		}
		[Test]
		public void SimpleFull()
		{
			byte[,] map = new byte[,]{
				{1,1,1,1,1,1,1,1},
				{1,1,1,1,1,1,1,1},
				{1,1,1,2,1,1,1,1},
				{1,1,1,1,1,1,1,1},
				{1,1,0,0,0,1,1,1},
				{1,1,1,1,1,1,1,1},
				{1,1,1,1,1,1,1,1},
				{1,1,1,1,1,1,1,1},
			};
			byte[,] mapRes = new byte[,]{
				{1,1,0,0,0,1,1,1},
				{1,1,1,1,1,1,1,1},
				{1,1,1,1,1,1,1,1},
				{1,1,1,2,1,1,1,1},
				{1,1,1,1,1,1,1,1},
				{1,1,1,1,1,1,1,1},
				{1,1,1,1,1,1,1,1},
				{1,1,1,1,1,1,1,1},
			};			
			var game = new Game(map);
			
			game.Implode();
			
			Board.WalkMap((i,j)=>Assert.AreEqual(mapRes[i,j], game.Board[i,j], "i:"+i+" j:"+j));
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
			var game = new Game(map);
			
			game.Implode();
			
			Board.WalkMap((i,j)=>Assert.AreEqual(mapRes[i,j], game.Board[i,j], "i:"+i+" j:"+j));
		}

		[Test]
		public void Chess()
		{
			byte[,] map = new byte[,]{
				{0,0,0,3,0,0,0,0},
				{0,0,4,0,0,0,0,0},
				{0,5,0,1,0,0,0,0},
				{6,0,2,0,0,0,0,0},
				{0,3,0,4,0,0,0,0},
				{4,0,3,0,0,0,0,0},
				{0,2,0,0,0,0,0,0},
				{1,0,0,0,0,0,0,0},			};
			byte[,] mapRes = new byte[,]{
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{6,5,4,3,0,0,0,0},
				{4,3,2,1,0,0,0,0},
				{1,2,3,4,0,0,0,0},
			};
			var game = new Game(map);
			
			game.Implode();
			
			Board.WalkMap((i,j)=>Assert.AreEqual(mapRes[i,j], game.Board[i,j], "i:"+i+" j:"+j));
		}
	}
}
