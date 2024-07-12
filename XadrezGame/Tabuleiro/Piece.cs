using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XadrezGame.Tabuleiro
{
	public abstract class Piece
	{
		public Position PiecePosition { get; set; }
		public PieceColor Color { get; set; }
		public int AmountMovement { get; protected set; }
		public Board CurrentBoard { get; protected set; }


		public Piece(PieceColor color, Board board)
		{
			this.Color = color;
			this.CurrentBoard = board;

			PiecePosition = null;
			AmountMovement = 0;
		}

		public void IncrementMovement() => AmountMovement++;

		public abstract bool[,] PossibleMovements();

		public bool ExistPossibleMovements() 
		{
			bool[,] movs = PossibleMovements();

			for (int i = 0; i < CurrentBoard.Line; i++) 
			{
				for (int j = 0; j < CurrentBoard.Colunm; j++) 
				{
					if (movs[i, j])
						return true;
				}
			}

			return false;

		}

		public bool CanMoveTo(Position position) 
		{
			return PossibleMovements()[position.Line, position.Column];
		}

	}
}
