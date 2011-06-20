﻿/*
 * Created by SharpDevelop.
 * User: JD
 * Date: 20.06.2011
 * Time: 6:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Linq;

namespace Solver
{

	/// <summary>
	/// Description of Game.
	/// </summary>
	public class Game
	{
		public Board Board{get; private set;}
		Exploder exploder;
		Imploder imploder;
		
		public Game(byte[,] map)
		{
			Board = new Board(map);
			exploder = new Exploder(Board);
			imploder = new Imploder(Board);
		}
		
		internal int Explode()
		{
			return exploder.Explode();
		}
		
		internal void Implode()
		{
			imploder.Implode();
		}
		
		
	}
		
}