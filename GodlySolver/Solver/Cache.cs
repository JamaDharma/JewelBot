/*
 * Created by SharpDevelop.
 * User: JD
 * Date: 21.06.2011
 * Time: 18:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Numerics;

namespace GodlySolver
{
	public class Cache
	{
		Dictionary<BigInteger, Solution> [] _dct = new Dictionary<BigInteger, Solution>[20];
		
		public Cache()
		{
			for(int i =0; i<20; i++)
				_dct[i] = new Dictionary<BigInteger, Solution>();
		}
		
		public Solution Get(int level, BigInteger bcode)
		{
			Solution result;
			if(_dct[level].TryGetValue(bcode, out result))
				return result.Copy();
			return null;
		}
		
		public void Add(int level, BigInteger bcode, Solution sln)
		{
			_dct[level].Add(bcode,sln.Copy());
		}
		
		public void Clear()
		{
			for(int i =0; i<20; i++)
				_dct[i].Clear();
		}
	}
}
