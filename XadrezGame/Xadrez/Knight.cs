using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XadrezGame.Tabuleiro;

namespace XadrezGame.Xadrez
{
	public class Knight : Piece
	{
		public Knight(Board board, PieceColor color) : base(color, board)
		{
		}

		public override string ToString()
		{
			return "C";
			//Cavalo
		}

		private bool CanMove(Position pos)
		{
			Piece p = this.CurrentBoard.GetPiece(pos);

			return p == null || p.Color != this.Color;
		}

		public override bool[,] PossibleMovements()
		{
			bool[,] result = new bool[this.CurrentBoard.Line, this.CurrentBoard.Colunm];

			Position p = new Position(0, 0);

			p.SetPosition(base.PiecePosition.Line - 1, base.PiecePosition.Column - 2);
			if (base.CurrentBoard.IsValidPostion(p) && CanMove(p)) 
			{
				result[p.Line, p.Column] = true;
			}

			p.SetPosition(base.PiecePosition.Line - 2, base.PiecePosition.Column - 1);
			if (base.CurrentBoard.IsValidPostion(p) && CanMove(p))
			{
				result[p.Line, p.Column] = true;
			}

			p.SetPosition(base.PiecePosition.Line - 2, base.PiecePosition.Column + 1);
			if (base.CurrentBoard.IsValidPostion(p) && CanMove(p))
			{
				result[p.Line, p.Column] = true;
			}

			p.SetPosition(base.PiecePosition.Line - 1, base.PiecePosition.Column + 2);
			if (base.CurrentBoard.IsValidPostion(p) && CanMove(p))
			{
				result[p.Line, p.Column] = true;
			}

			p.SetPosition(base.PiecePosition.Line + 1, base.PiecePosition.Column + 2);
			if (base.CurrentBoard.IsValidPostion(p) && CanMove(p))
			{
				result[p.Line, p.Column] = true;
			}

			p.SetPosition(base.PiecePosition.Line + 2, base.PiecePosition.Column + 1);
			if (base.CurrentBoard.IsValidPostion(p) && CanMove(p))
			{
				result[p.Line, p.Column] = true;
			}

			p.SetPosition(base.PiecePosition.Line + 2, base.PiecePosition.Column - 1);
			if (base.CurrentBoard.IsValidPostion(p) && CanMove(p))
			{
				result[p.Line, p.Column] = true;
			}

			p.SetPosition(base.PiecePosition.Line + 1, base.PiecePosition.Column - 2);
			if (base.CurrentBoard.IsValidPostion(p) && CanMove(p))
			{
				result[p.Line, p.Column] = true;
			}

			return result;
		}
	}
}
