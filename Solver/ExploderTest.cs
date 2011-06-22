/*
 * Created by SharpDevelop.
 * User: JD
 * Date: 20.06.2011
 * Time: 6:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Net;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;

namespace Solver
{
	[TestFixture]
	public class ExploderTest
	{
		[Test]
		public void Horizontal()
		{
			byte[,] map = new byte[,]{
				{1,2,5,0,0,2,0,0},
				{3,4,6,0,0,1,5,0},
				{0,0,0,0,0,1,3,1},
				{0,0,2,2,2,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,1,1,1,0,1,0,1},
				{0,0,0,0,0,0,0,0},
				{1,2,1,0,1,1,1,0},
			};
			byte[,] mapRes = new byte[,]{
				{1,2,5,0,0,2,0,0},
				{3,4,6,0,0,1,5,0},
				{0,0,0,0,0,1,3,1},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,1,0,1},
				{0,0,0,0,0,0,0,0},
				{1,2,1,0,0,0,0,0},
			};			
			var game = new Game(new Board(map));
			
			int score = game.Explode();
			
			Assert.AreEqual(90, score);
			
			Board.WalkMap((i,j)=>Assert.AreEqual(mapRes[i,j], game.Board[i,j]));
		}
		[Test]
		public void Whicked()
		{
			byte[,] map = new byte[,]{
				{0,0,0,0,3,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,4,4,4,0,0,0},
				{0,0,4,4,4,0,0,0},
				{0,0,0,0,4,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
			};
			byte[,] mapRes = new byte[,]{
				{0,0,0,0,3,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
			};			
			var game = new Game(new Board(map));
			
			int score = game.Explode();
			
			Assert.AreEqual(150, score);
			
			Board.WalkMap((i,j)=>Assert.AreEqual(mapRes[i,j], game.Board[i,j]));
		}
		[Test]
		public void Corners()
		{
			byte[,] map = new byte[,]{
				{4,4,4,5,0,1,1,1},
				{4,0,0,0,0,0,0,1},
				{4,0,0,5,0,0,0,1},
				{0,0,0,4,4,0,0,0},
				{0,0,0,4,4,0,0,0},
				{3,0,0,0,0,0,0,2},
				{3,0,0,0,0,0,0,2},
				{3,3,3,0,0,2,2,2},
			};
			byte[,] mapRes = new byte[,]{
				{0,0,0,5,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,5,0,0,0,0},
				{0,0,0,4,4,0,0,0},
				{0,0,0,4,4,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
			};			
			var game = new Game(new Board(map));
			
			int score = game.Explode();
			
			Assert.AreEqual(360, score);
			
			Board.WalkMap((i,j)=>Assert.AreEqual(mapRes[i,j], game.Board[i,j]));
		}
	}
}
