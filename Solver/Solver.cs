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
		public static int Count = 0;
		public static int Limit = 3;

		public static int Result(Board board, IEnumerable<Move> moves)
		{
			var game = new Game(board);
			int score = game.Run();
			foreach(var move in moves)
			{
				move.MoveBoard(board);
				score+=game.Run();
			}
			return score;
		}
		
		Board _board;
		
		public Solver(Board board)
		{
			_board = board;
		}
		
		public Solution Solve()
		{
			return Solve(0);
		}
		public Solution Solve(int deepness)
		{
			Count++;
			deepness++;
			int score = new Game(_board).Run();
			Solution bestSolution = new Solution();
			
			if(deepness > Limit)
			{
				bestSolution.Score += score;
				return bestSolution;
			}
			
			var moves = new GeoScanner(_board).GetDeposits();

			Move bestMove = null;
			foreach(var move in moves)
			{
				Board t = _board.Copy();
				move.MoveBoard(t);
				var sol = new Solver(t).Solve(deepness);
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
