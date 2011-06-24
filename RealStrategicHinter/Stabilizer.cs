/*
 * Created by SharpDevelop.
 * User: JD
 * Date: 24.06.2011
 * Time: 11:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using GodlySolver;

namespace RealStrategicHinter
{


	class Stabilizer
	{
		static int margin = 0;
		
		static Board lastBoard = new Board(new byte[8,8]);
		
		public static IEnumerable<Move> GetBestMoveSequence(Board board)
		{
			int deviation = 0;
			
			Board.WalkMap(p=>deviation+=board[p]==lastBoard[p]?0:1);
			
			lastBoard = board.Copy();
			
			return deviation > margin 
				? new List<Move>()
				: Strategy.GetBestMoveSequence(board);
		}

	}
}
