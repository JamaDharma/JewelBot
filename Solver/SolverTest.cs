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
	}
}
