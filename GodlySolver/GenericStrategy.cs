/*
 * Created by SharpDevelop.
 * User: JD
 * Date: 23.06.2011
 * Time: 10:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Linq;

namespace GodlySolver
{
	/// <summary>
	/// Description of GenericStrategy.
	/// </summary>
	public class GenericStrategy :IStrategy
	{
		readonly int Level;
		readonly int Moves;
		public GenericStrategy(int level, int moves)
		{
			Level =level;
			Moves = moves;
		}
		
		public int Test(Board board)
		{
			Solver.Cash.Clear();
			int result = 0;
			var solver = new Solver(board);

			for (int i =0; i <12; i+=Moves)
				result += Evaluator.EvaluateReal(board, solver.Solve(Level).Moves.Take(Moves));

			return result;
		}
	}
}
