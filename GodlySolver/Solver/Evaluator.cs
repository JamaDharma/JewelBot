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

namespace GodlySolver
{
	public class Evaluator
	{
				
		public static int EvaluateLite(Board board, IEnumerable<Move> moves)
		{
			return Evaluate(board, Game.CreateLite(board), moves);
		}
		
		public static int EvaluateReal(Board board, IEnumerable<Move> moves)
		{
			return Evaluate(board, Game.CreateReal(board), moves);
		}
		
		static int Evaluate(Board board, Game game, IEnumerable<Move> moves)
		{
			int score = game.Run();
			foreach(var move in moves)
			{
				move.MoveBoard(board);
				score+=game.Run();
			}
			return score;
		}
	}
}
