/*
 * Created by SharpDevelop.
 * User: JD
 * Date: 24.06.2011
 * Time: 11:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using GodlySolver;

namespace RealStrategicHinter
{
	/// <summary>
	/// Description of StrategicHinter.
	/// </summary>
	public class StrategicHinter
	{
		public static IEnumerable<Move> GetBestMoveSequence(Board board)
		{
			return Stabilizer.GetBestMoveSequence(board);
		}
	}
}
