/*
 * Created by SharpDevelop.
 * User: JD
 * Date: 20.06.2011
 * Time: 6:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace GodlySolver
{
	class Filler :IImploder
	{
		readonly Imploder _imploder;
		readonly Board _board;
		readonly Random _rnd;
		
		public Filler(Board board)
		{
			_board = board;
			_imploder = new Imploder(_board);
			_rnd = new Random();
		}
		
		public void Implode()
		{
			_imploder.Implode();
			Board.WalkMap(p=>{
			              	if(_board[p] == 0) 
			              		_board[p] = (byte)_rnd.Next(1,7);
			              });
		}
	}
}
