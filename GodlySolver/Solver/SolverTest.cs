/*
 * Created by SharpDevelop.
 * User: JD
 * Date: 22.06.2011
 * Time: 6:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;
using NUnit.Framework;

namespace GodlySolver
{
	[TestFixture]
	public class SolverTest
	{
		        
		public static T time<T>(Func<T> func, Func<String> comment)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            try
            {
                return func();
            }
            finally
            {
                sw.Stop();
                Console.WriteLine(comment() + ": " + sw.Elapsed);
            }
        }
		
		[SetUp]
		public void SetUp()
		{
			Solver.Cash.Clear();
		}
		
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
		public void Real1_3()
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

			Solver.Limit = 3;

			var sln = new Solver(new Board(map)).Solve();
			var rotSln = new[]{
				new Move(new Point(1,4),new Point(2,4)),
				new Move(new Point(6,5),new Point(7,5)),
				new Move(new Point(6,0),new Point(7,0)),
			};
			
			int res = Evaluator.EvaluateLite(new Board(map), sln.Moves);
			int rotRes = Evaluator.EvaluateLite(new Board(map), rotSln);

			Assert.AreEqual(420, res);
			Assert.AreEqual(res ,sln.Score);
			Assert.GreaterOrEqual(res, rotRes);
			Assert.AreEqual(3, sln.Moves.Count);
		}
		[Test]
		public void Real1_4()
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

			Solver.Limit = 4;

			var sln = new Solver(new Board(map)).Solve();
			
			int res = Evaluator.EvaluateLite(new Board(map), sln.Moves);

			Assert.AreEqual(570, res);
			Assert.AreEqual(res ,sln.Score);
			Assert.AreEqual(4, sln.Moves.Count);
		}
		[Test]
		public void Real1_5()
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

			Solver.Limit = 5;
			var sln = new Solver(new Board(map)).Solve();
			
			int res = Evaluator.EvaluateLite(new Board(map), sln.Moves);

			Assert.AreEqual(690, res);
			Assert.AreEqual(res ,sln.Score);
			Assert.AreEqual(5, sln.Moves.Count);
		}	
		[Test]
		public void Real1_6()
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

			Solver.Limit = 6;
			var sln = new Solver(new Board(map)).Solve();
			
			int res = Evaluator.EvaluateLite(new Board(map), sln.Moves);
			
			Assert.AreEqual(720, res);
			Assert.AreEqual(res ,sln.Score);
			Assert.AreEqual(6, sln.Moves.Count);
		}		
				
		[Test]
		[Ignore]
		public void Bad()
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

			Func<Solution> work = () => new Solver(new Board(map)).Solve();
			for(int i = 0; i<5; i++)
			{
				Solver.Count = 0;
				Solver.Limit = i;
				Solver.Cash.Clear();
				time(work, () => string.Format("limit: {0}  count:{1}  ", Solver.Limit, Solver.Count));
			}
			
			Assert.Fail();
		}
	}
}
