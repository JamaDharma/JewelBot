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
using System.Threading.Tasks;

namespace Solver
{
	enum Coin : int
    {
        None=0,
        Black =1,
        Red=2,
        Yellow=3,
        Blue=4,
        Green=5,
        Purple=6
    }
	


		
	
	
	
	/// <summary>
	/// Description of Game.
	/// </summary>
	public class Game
	{
		public Board Board{get; private set;}
		Exploder exploder;
		
		
		public Game(byte[,] map)
		{
			Board = new Board(map);
			exploder = new Exploder(Board);
		}
		
		public int Explode()
		{
			return exploder.Explode();
		}
	}
		
}
