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

namespace Solver
{
	public class Solution
	{
		public int Score = 0;
		public Stack<Move> Moves = new Stack<Move>();
	}
	/// <summary>
	/// Description of Solver.
	/// </summary>
	public class Solver
	{
		Board _board;
		public Solver(Board board)
		{
			_board = board;
		}
		
		public Solution Solve()
		{
			int score = new Game(_board).Run();
			var moves = new GeoScanner(_board).GetDeposits();

			Move bestMove = null;
			Solution bestSolution = new Solution();
			foreach(var move in moves)
			{
				Board t = _board.Copy();
				move.MoveBoard(t);
				var sol = new Solver(t).Solve();
				if(sol.Score > bestSolution.Score)
				{
					bestSolution = sol;
					bestMove = move;
				}
			}
			
			bestSolution.Score += score;
			if((object)bestMove != null)
				bestSolution.Moves.Push(bestMove);
			
			return bestSolution;
		}
	}
}
