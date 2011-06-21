/*
 * Created by SharpDevelop.
 * User: JD
 * Date: 21.06.2011
 * Time: 8:47
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Linq;
using NUnit.Framework;

namespace Solver
{
	[TestFixture]
	public class GeoScannerTest
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
			var scanner = new GeoScanner(new Board(map));
			
			var deposits = scanner.GetDeposits();
			
			Assert.AreEqual(0,deposits.Count());
		}
		
		[Test]
		public void Horizontal1()
		{
			byte[,] map = new byte[,]{
				{1,2,3,4,5,6,1,2},
				{3,4,5,6,1,2,3,4},
				{5,6,1,2,3,4,5,6},
				{1,2,3,4,5,6,1,2},
				{3,4,5,6,1,2,3,4},
				{5,6,1,2,3,4,5,6},
				{1,2,3,4,5,6,1,2},
				{3,3,5,6,1,2,3,4},
			};
			var scanner = new GeoScanner(new Board(map));
			
			var deposits = scanner.GetDeposits();
			
			Assert.AreEqual(1,deposits.Count());
		}
		
		[Test]
		public void HorizontalEmpty3()
		{
			byte[,] map1 = new byte[,]{
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,5,0,0},
				{0,5,0,5,5,0,0,0},
				{0,0,5,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
			};
			byte[,] map2 = new byte[,]{
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,5,0,0,0,0,0},
				{0,0,0,5,5,0,5,0},
				{0,0,0,0,0,5,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
			};
			var scanner = new GeoScanner(new Board(map1));
			
			var deposits = scanner.GetDeposits();
			
			Assert.AreEqual(3,deposits.Count());

			scanner = new GeoScanner(new Board(map2));
			
			deposits = scanner.GetDeposits();
			
			Assert.AreEqual(3,deposits.Count());
		}
		
		[Test]
		public void HorizontalEmpty1()
		{
			byte[,] map1 = new byte[,]{
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,5,0,0},
				{0,5,0,5,0,5,0,0},
				{0,0,5,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
			};
			byte[,] map2 = new byte[,]{
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,5,5,0,0,5,0,0},
				{0,5,0,0,5,0,5,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
			};
			var scanner = new GeoScanner(new Board(map1));
			
			var deposits = scanner.GetDeposits();
			
			Assert.AreEqual(1,deposits.Count());

			scanner = new GeoScanner(new Board(map2));
			
			deposits = scanner.GetDeposits();
			
			Assert.AreEqual(1,deposits.Count());
		}

		[Test]
		public void VerticalEmpty1()
		{
			byte[,] map1 = new byte[,]{
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,4,0,0},
				{0,5,0,3,4,5,0,0},
				{0,0,3,0,0,4,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
			};
			byte[,] map2 = new byte[,]{
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,5,5,0,0,4,0,0},
				{0,5,0,0,5,0,4,0},
				{0,0,0,0,0,4,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0},
			};
			var scanner = new GeoScanner(new Board(map1));
			
			var deposits = scanner.GetDeposits();
			
			Assert.AreEqual(1,deposits.Count());

			scanner = new GeoScanner(new Board(map2));
			
			deposits = scanner.GetDeposits();
			
			Assert.AreEqual(1,deposits.Count());
		}

		[Test]
		public void EmptyLots()
		{
			byte[,] map = new byte[,]{
				{0,0,0,0,0,0,0,0},
				{0,0,0,1,0,0,0,0},
				{0,0,1,0,1,5,0,0},
				{0,5,0,1,0,0,5,0},
				{0,0,5,1,0,5,0,0},
				{0,0,1,0,1,0,0,0},
				{0,0,0,1,0,0,0,0},
				{0,0,0,0,0,0,0,0},
			};

			var scanner = new GeoScanner(new Board(map));
			
			var deposits = scanner.GetDeposits();
			
			Assert.AreEqual(9,deposits.Count());
		}
		
		[Test]
		public void Clear()
		{
			byte[,] map = new byte[,]{
				{1,2,3,4,5,6,1,2},
				{3,4,5,6,1,2,3,4},
				{5,6,1,2,3,4,5,6},
				{1,2,3,4,5,6,1,2},
				{3,4,5,6,1,2,3,4},
				{5,6,1,2,3,4,5,6},
				{1,2,3,4,5,6,1,2},
				{3,3,5,6,1,2,3,4},
			};
			var scanner = new GeoScanner(new Board(map));
			
			var deposits = scanner.GetDeposits();
			
			Assert.AreEqual(1,scanner.GetDeposits().Count());
		}
		
		[Test]
		public void Move()
		{
			byte[,] map = new byte[,]{
				{1,2,3,4,5,6,1,2},
				{3,4,5,6,1,2,3,4},
				{5,6,1,2,3,4,5,6},
				{1,2,3,4,5,6,1,2},
				{3,4,5,6,1,2,3,4},
				{5,6,1,2,3,4,5,6},
				{1,2,3,4,5,6,1,2},
				{3,3,5,6,1,2,3,4},
			};
			byte[,] mapRes = new byte[,]{
				{1,2,3,4,5,6,1,2},
				{3,4,5,6,1,2,3,4},
				{5,6,1,2,3,4,5,6},
				{1,2,3,4,5,6,1,2},
				{3,4,5,6,1,2,3,4},
				{5,6,1,2,3,4,5,6},
				{1,2,5,4,5,6,1,2},
				{3,3,3,6,1,2,3,4},
			};
			
			var b = new Board(map);
			
			var scanner = new GeoScanner(b);
			
			foreach(var m in scanner.GetDeposits())
				m.MoveBoard(b);
			
			Board.WalkMap((i,j)=>Assert.AreEqual(mapRes[i,j], b[i,j], "i:"+i+" j:"+j));

		}
	}
}
