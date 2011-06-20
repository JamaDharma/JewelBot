/*
 * Created by SharpDevelop.
 * User: JD
 * Date: 20.06.2011
 * Time: 11:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NUnit.Framework;

namespace Solver
{
	[TestFixture]
	public class ExplosionsTest
	{
		[Test]
		public void OneRange()
		{
			var explosions = new Explosions();
			
			explosions.AddRange(1,1,1,3);
			Assert.AreEqual(30, explosions.Harvest());
			explosions.Clear();

			explosions.AddRange(2,1,2,4);
			Assert.AreEqual(60, explosions.Harvest());
			explosions.Clear();

			explosions.AddRange(3,1,3,6);
			Assert.AreEqual(120, explosions.Harvest());
			explosions.Clear();
			
			explosions.AddRange(4,2,7,2);
			Assert.AreEqual(60, explosions.Harvest());
			explosions.Clear();
		}
		
		[Test]
		public void TwoRange_Independend()
		{
			var explosions = new Explosions();
			
			explosions.AddRange(1,1,1,3);
			explosions.AddRange(2,1,2,4);
			Assert.AreEqual(90, explosions.Harvest());
			explosions.Clear();

			explosions.AddRange(2,1,2,4);
			explosions.AddRange(4,2,7,2);
			Assert.AreEqual(120, explosions.Harvest());
			explosions.Clear();
		}
		
		[Test]
		public void TwoRange_Dependend()
		{
			var explosions = new Explosions();
			
			explosions.AddRange(1,1,1,3);
			explosions.AddRange(1,1,3,1);
			Assert.AreEqual(90, explosions.Harvest());
			explosions.Clear();

			explosions.AddRange(2,1,2,3);
			explosions.AddRange(1,1,4,1);
			Assert.AreEqual(120, explosions.Harvest());
			explosions.Clear();
		}
		
		[Test]
		public void Complex()
		{
			var explosions = new Explosions();
			
			explosions.AddRange(1,1,1,3);
			explosions.AddRange(1,3,3,3);
			explosions.AddRange(3,3,3,5);
			Assert.AreEqual(150, explosions.Harvest());
			explosions.Clear();

			explosions.AddRange(1,1,1,3);
			explosions.AddRange(2,1,2,3);
			explosions.AddRange(3,1,3,3);
			explosions.AddRange(1,1,3,1);
			explosions.AddRange(1,2,3,2);
			explosions.AddRange(1,3,3,3);
			Assert.AreEqual(210, explosions.Harvest());
			explosions.Clear();
		}	}
}
