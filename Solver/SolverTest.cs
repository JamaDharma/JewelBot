/*
 * Created by SharpDevelop.
 * User: JD
 * Date: 22.06.2011
 * Time: 6:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NUnit.Framework;

namespace Solver
{
	[TestFixture]
	public class SolverTest
	{
		[Test]
		public void Empty()
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
			var sln = new Solver(new Board(map)).Solve();
			
			Assert.AreEqual(0,sln.Score);
		}

		[Test]
		public void Horizontal()
		{
			byte[,] map = new byte[,]{
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,1,0,0},
				{0,0,0,0,0,2,1,1},
			};

			var sln = new Solver(new Board(map)).Solve();
			
			
			Assert.AreEqual(30,sln.Score);
		}
		
		[Test]
		public void Vertical()
		{
			byte[,] map = new byte[,]{
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,1},
				{0,0,0,0,0,0,1,2},
				{0,0,0,0,0,0,2,1},
			};

			var sln = new Solver(new Board(map)).Solve();
			
			
			Assert.AreEqual(30,sln.Score);
		}	
		
				
		[Test]
		public void Complex()
		{
			byte[,] map = new byte[,]{
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,1,0,0,0},
				{0,0,0,0,2,0,0,0},
				{0,0,0,3,4,0,0,1},
				{0,0,0,5,3,1,1,2},
				{0,0,0,5,3,2,2,1},
			};

			var sln = new Solver(new Board(map)).Solve();
			
			
			Assert.AreEqual(150,sln.Score);
		}
		
		[Test]
		public void Real1()
		{
			byte[,] map = new byte[,]{
			//   0 1 2 3 4 5 6 7
				{4,6,1,1,4,6,3,2,},//0
				{3,5,1,6,2,5,1,6,},//1
				{3,1,2,2,6,2,6,3,},//2
				{6,6,5,4,2,1,6,5,},//3
				{2,5,5,4,6,4,5,2,},//4
				{2,3,3,5,3,5,6,4,},//5
				{4,5,6,2,1,4,6,6,},//6
				{2,2,1,3,4,6,3,4,},//7
			};

			var sln = new Solver(new Board(map)).Solve();
			var rotSln = new[]{
				new Move(new Point(1,4),new Point(2,4)),
				new Move(new Point(6,5),new Point(7,5)),
				new Move(new Point(6,0),new Point(7,0)),
			};
			
			int res = Solver.Result(new Board(map), sln.Moves);
			int rotRes = Solver.Result(new Board(map), rotSln);
			
			Assert.AreEqual(res ,sln.Score);
			Assert.GreaterOrEqual(res, rotRes);
		}
	}
}
