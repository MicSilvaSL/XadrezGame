using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XadrezGame.Tabuleiro;

namespace XadrezGame.Xadrez
{
	public class King : Piece
	{

		public King(Board board, PieceColor color) : base(color, board) 
		{

		}


		public override string ToString()
		{
			return "R ";
		}

	}
}
