using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XadrezGame.Tabuleiro
{
	public class Piece
	{
		public Position PiecePosition { get; set; }
		public PieceColor Color { get; set; }
		public int AmountMovement { get; protected set; }
		public Board CurrentBoard { get; protected set; }


		public Piece(Position pos, PieceColor color, Board board) 
		{
			this.PiecePosition = pos;
			this.Color = color;
			this.CurrentBoard = board;

			AmountMovement = 0;
		}

	}
}
