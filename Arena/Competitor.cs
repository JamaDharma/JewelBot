/*
 * Created by SharpDevelop.
 * User: JD
 * Date: 23.06.2011
 * Time: 11:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using GodlySolver;

namespace Arena
{
	class Competitor
	{
		public IStrategy Strategy;
		public string Comment;
		public int Score;
		
		public Competitor(IStrategy strategy, string comment, int score)
		{
			this.Strategy = strategy;
			this.Comment = comment;
			this.Score = score;
		}
	}
}
