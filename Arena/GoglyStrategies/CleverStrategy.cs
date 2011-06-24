/*
 * Created by SharpDevelop.
 * User: JD
 * Date: 23.06.2011
 * Time: 11:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Linq;
using GodlySolver;

namespace Arena.GoglyStrategies
{
		

	
	/// <summary>
	/// Description of CleverStrategy.
	/// </summary>
	public class CleverStrategy : IStrategy
	{
		readonly int Level;
		readonly int Moves;
		
		public CleverStrategy(int level, int moves)
		{
			this.Level = level;
			this.Moves = moves;
		}
		
		public int Test(Board board)
		{
			int result = 0;
			var solver = new Solver(board);
	
			for (int i =0; i <12/Level; i++)
				for (int j = 0; j < Level; j+=Moves)
					result += Evaluator.EvaluateReal(board, solver.Solve(Level-j).Moves.Take(Moves));
	
			return result;
		}

	}
}
