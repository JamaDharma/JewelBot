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
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Solver
{
	class Explosions
	{
		int count = 0;
		Dictionary<Point, int> _lia = new Dictionary<Point, int>();
		
		public IEnumerable<Point> Range
		{
			get{return _lia.Keys;}
		}
		
		public void AddRange(int i1, int j1, int i2, int j2)
		{
			var range = new List<Point>();
			for (int i = i1; i<=i2; i++)
				for (int j = j1; j<=j2; j++)
					range.Add(new Point(i,j));
			
			var toSubstitute = range.Where(_lia.ContainsKey)
				.Select(t=>_lia[t]).Distinct();
			
			_lia.Where(e=>toSubstitute.Contains(e.Value))
				.Select(e=>e.Key).ToList()
				.ForEach(k=>_lia[k]=count);
			
			range.ForEach(k=>_lia[k]=count);
			count++;
		}
		
		public int Harvest()
		{
			var powers = new int[count];
			foreach(int id in _lia.Values)
				powers[id]++;
			return powers.Where(power=>power>0)
				.Aggregate(0,(score,power)=>score+(power-2)*30);
		}
		
		public void Clear()
		{
			count =0;
			_lia.Clear();
		}
		
	}
}
