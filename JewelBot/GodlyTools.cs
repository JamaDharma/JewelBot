/*
 * Created by SharpDevelop.
 * User: JD
 * Date: 24.06.2011
 * Time: 11:47
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using GodlySolver;

namespace JewelBot
{
	/// <summary>
	/// Description of GodlyTools.
	/// </summary>
	static class GodlyTools
	{
		public static Board ToBoard(this Coin[,] state)
		{
			byte[,] bb = new byte[8,8];
			Board.WalkMap((i,j)=>bb[i,j]=(byte)state[i,j]);
			return new Board(bb);
		}
		
		public static JewelBot.Move Convert(this GodlySolver.Move move)
		{
			var result = new JewelBot.Move();
			result.Cell = new Cell(move.A.X,move.A.Y);
			result.Vertical = (move.A+GodlySolver.Offset.Vertical)==move.B;
			return result;
		}
	}
}
