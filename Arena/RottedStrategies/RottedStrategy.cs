/*
 * Created by SharpDevelop.
 * User: JD
 * Date: 23.06.2011
 * Time: 11:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Linq;
using GodlySolver;
using JewelBot;

namespace Arena.RottedStrategies
{

	/// <summary>
	/// Description of RottedStrategy.
	/// </summary>
	public class RottedStrategy :IStrategy
	{
		int Moves;
		public RottedStrategy(int moves)
		{
			Moves = moves;
		}
		
		public int Test(Board board)
		{
			int result = 0;
			var solver = JewelBot.Solver.GetBestMoveSequence(board.ToCoin());

			for (int i =0; i <12; i+=Moves)
				result += Evaluator.EvaluateReal(board, 
				                                 JewelBot.Solver.GetBestMoveSequence(board.ToCoin())
				                                 .Take(Moves)
				                                 .Select(m=>m.Convert()));

			return result;
		}
	}
}
