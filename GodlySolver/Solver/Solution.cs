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
	public class Solution
	{
		public int Score;
		public Stack<Move> Moves;
		
		public Solution()
			: this(0, new Stack<Move>())
		{
		}
		
		public Solution(int score)
			: this(score, new Stack<Move>())
		{
		}
		
		public Solution(int score, Stack<Move> moves)
		{
			Score = score;
			Moves = moves;
		}
		
		public Solution Copy()
		{
			return new Solution(Score, new Stack<Move>(Moves));
		}
	}
}
