/*
 * Created by SharpDevelop.
 * User: JD
 * Date: 20.06.2011
 * Time: 6:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Linq;

namespace GodlySolver
{
	/// <summary>
	/// Description of Game.
	/// </summary>
	public class Game
	{
		static public Game CreateLite(Board board)
		{
			return new Game(board, new Imploder(board));
		}
		static public Game CreateReal(Board board)
		{
			return new Game(board, new Filler(board));
		}
		
		Board _board;
		Exploder _exploder;
		IImploder _imploder;
		
		Game(Board board, IImploder imploder)
		{
			_board = board;
			_exploder = new Exploder(_board);
			_imploder = imploder;;
		}
		
		public int CarefulRun()
		{
			_imploder.Implode();
			return LiteRun();
		}
		
		public int LiteRun()
		{
			int turn = 1;
			int score = 0;
			int turnScore;
			while((turnScore = _exploder.Explode())>0)
			{
				score += turnScore* turn++;
				_imploder.Implode();
			}
			return score;
		}
	}
}
