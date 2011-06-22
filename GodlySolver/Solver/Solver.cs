﻿/*
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


	/// <summary>
	/// Description of Solver.
	/// </summary>
	public class Solver
	{
		public static int Count = 0;
		public static int Limit = 3;
		public static readonly Cache Cash = new Cache();

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
			return Solve(Limit);
		}
		public Solution Solve(int deepness)
		{
			deepness--;
			int score = new Game(_board).Run();
			if(deepness < 0)
			{
				return new Solution(score);
			}

			var bcode = _board.GetCode();
			Solution bestSolution = Cash.Get(deepness, bcode);
			if(bestSolution != null)
			{
				bestSolution.Score += score;
				return bestSolution;
			}

			Count++;
			Move bestMove = null;
			bestSolution = new Solution();
			var moves = new GeoScanner(_board).GetDeposits();

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
			
			
			if(bestSolution.Score != 0)
				bestSolution.Moves.Push(bestMove);
			
			Cash.Add(deepness, bcode, bestSolution);
			
			bestSolution.Score += score;
			
			return bestSolution;
		}
	}
}
