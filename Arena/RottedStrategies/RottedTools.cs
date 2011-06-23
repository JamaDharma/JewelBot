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
	static class RottedTools
	{
		public static Coin[,] ToCoin(this Board board)
		{
			Coin[,] cb = new Coin[8,8];
			Board.WalkMap((i,j)=>cb[i,j]=(Coin)board[i,j]);
			return cb;
		}
		public static GodlySolver.Move Convert(this JewelBot.Move move)
		{
			var dCell = move.DestinationCell();
			return new GodlySolver.Move(
				new Point(move.Cell.I, move.Cell.J),
				new Point(dCell.I, dCell.J)
			);
		}
	}
}
