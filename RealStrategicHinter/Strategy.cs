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
	class Strategy
	{
		const int MaxDeepness = 4;
		
		static int lastDeepness = 0;
		static Board lastSolved = new Board(new byte[8,8]);
		static IEnumerable<Move> lastSolution;
		
		public static IEnumerable<Move> GetBestMoveSequence(Board board)
		{
			int deviation = 0;
			Board.WalkMap(p=>deviation+=board[p]==lastSolved[p]?0:1);
			
			if(deviation != 0)
			{
				lastSolved = board.Copy();
				lastSolution = new Solver(board).Solve(MaxDeepness-lastDeepness++).Moves;
				lastDeepness = lastDeepness == 4 ? 0 : lastDeepness;
			}
			
			return lastSolution;
		}
	
	}
}
