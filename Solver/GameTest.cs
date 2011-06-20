/*
 * Created by SharpDevelop.
 * User: JD
 * Date: 21.06.2011
 * Time: 2:08
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NUnit.Framework;

namespace Solver
{
	[TestFixture]
	public class GameTest
	{
		[Test]
		public void Nothing()
		{
			byte[,] map = new byte[,]{
				{1,2,3,4,5,6,1,2},
				{3,4,5,6,1,2,3,4},
				{5,6,1,2,3,4,5,6},
				{1,2,3,4,5,6,1,2},
				{3,4,5,6,1,2,3,4},
				{5,6,1,2,3,4,5,6},
				{1,2,3,4,5,6,1,2},
				{3,4,5,6,1,2,3,4},
			};
			byte[,] mapRes = new byte[,]{
				{1,2,3,4,5,6,1,2},
				{3,4,5,6,1,2,3,4},
				{5,6,1,2,3,4,5,6},
				{1,2,3,4,5,6,1,2},
				{3,4,5,6,1,2,3,4},
				{5,6,1,2,3,4,5,6},
				{1,2,3,4,5,6,1,2},
				{3,4,5,6,1,2,3,4},
			};			
			var game = new Game(map);
			
			int score = game.Run();
			
			Assert.AreEqual(0,score);
			Board.WalkMap((i,j)=>Assert.AreEqual(mapRes[i,j], game.Board[i,j], "i:"+i+" j:"+j));
		}
		[Test]
		public void One()
		{
			byte[,] map = new byte[,]{
				{1,2,3,4,5,6,1,2},
				{3,4,5,6,1,2,3,4},
				{5,6,1,2,3,4,5,6},
				{1,2,3,4,5,6,1,2},
				{3,4,5,6,1,2,3,4},
				{5,6,1,2,3,4,5,6},
				{1,2,3,4,5,6,1,2},
				{3,3,3,6,1,2,3,4},
			};
			byte[,] mapRes = new byte[,]{
				{0,0,0,4,5,6,1,2},
				{1,2,3,6,1,2,3,4},
				{3,4,5,2,3,4,5,6},
				{5,6,1,4,5,6,1,2},
				{1,2,3,6,1,2,3,4},
				{3,4,5,2,3,4,5,6},
				{5,6,1,4,5,6,1,2},
				{1,2,3,6,1,2,3,4},
			};			
			var game = new Game(map);
			
			int score = game.Run();
			
			Assert.AreEqual(30,score);
			Board.WalkMap((i,j)=>Assert.AreEqual(mapRes[i,j], game.Board[i,j], "i:"+i+" j:"+j));
		}
		[Test]
		public void Two()
		{
			byte[,] map = new byte[,]{
				{1,2,3,4,5,6,1,2},
				{3,4,5,6,1,2,3,4},
				{5,6,1,2,3,4,5,6},
				{1,2,3,4,5,6,1,2},
				{3,4,5,6,1,2,3,4},
				{5,6,1,2,3,4,5,6},
				{1,5,5,4,5,6,1,2},
				{3,3,3,5,5,2,3,4},
			};
			byte[,] mapRes = new byte[,]{
				{0,0,0,0,0,6,1,2},
				{1,0,0,4,5,2,3,4},
				{3,2,3,6,1,4,5,6},
				{5,4,5,2,3,6,1,2},
				{1,6,1,4,5,2,3,4},
				{3,2,3,6,1,4,5,6},
				{5,4,5,2,3,6,1,2},
				{1,6,1,4,5,2,3,4},
			};			
			var game = new Game(map);
			
			int score = game.Run();
			
			Assert.AreEqual(150,score);
			Board.WalkMap((i,j)=>Assert.AreEqual(mapRes[i,j], game.Board[i,j], "i:"+i+" j:"+j));
		}
		[Test]
		public void Three()
		{
			byte[,] map = new byte[,]{
				{1,2,3,4,5,6,1,2},
				{3,4,5,6,1,5,5,4},
				{5,6,1,2,3,4,5,6},
				{1,2,3,4,5,6,1,2},
				{3,4,5,6,1,2,3,4},
				{5,6,1,2,3,4,5,6},
				{1,5,5,4,5,6,1,2},
				{3,3,3,5,5,2,3,4},
			};
			byte[,] mapRes = new byte[,]{
				{0,0,0,0,0,0,0,2},
				{1,0,0,4,0,6,1,4},
				{3,2,3,6,1,4,5,6},
				{5,4,5,2,3,6,1,2},
				{1,6,1,4,5,2,3,4},
				{3,2,3,6,1,4,5,6},
				{5,4,5,2,3,6,1,2},
				{1,6,1,4,5,2,3,4},
			};			
			var game = new Game(map);
			
			int score = game.Run();
			
			Assert.AreEqual(240,score);
			Board.WalkMap((i,j)=>Assert.AreEqual(mapRes[i,j], game.Board[i,j], "i:"+i+" j:"+j));
		}
	}
}
