/*
 * Created by SharpDevelop.
 * User: JD
 * Date: 23.06.2011
 * Time: 11:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using GodlySolver;

namespace Arena
{
	class Program
	{

		public static void Main(string[] args)
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
			
			List<Competitor> competitors = new List<Competitor>(){
				new Competitor(new GenericStrategy(1,1), "Greed level:1 moves:1     : ", 0),
				new Competitor(new GenericStrategy(2,1), "Strategy level:2 moves:1  : ", 0),
				new Competitor(new GenericStrategy(2,2), "Strategy level:2 moves:2  : ", 0),
				new Competitor(new GenericStrategy(3,1), "Strategy level:3 moves:1  : ", 0),
				new Competitor(new GenericStrategy(3,2), "Strategy level:3 moves:2  : ", 0),
				new Competitor(new GenericStrategy(3,3), "Strategy level:3 moves:3  : ", 0),
			};
			
			while(true)
			{
				
				for(int i = 0; i<10 ; i++)
				{
					var board = new Board(map);
					Game.CreateReal(board).CarefulRun();
					foreach(var c in competitors)
						c.Score += c.Strategy.Test(board.Copy());
				}
				
				
				foreach(var c in competitors)
					Console.WriteLine(c.Comment+c.Score);
				Console.WriteLine();
			}

		}
	}
}