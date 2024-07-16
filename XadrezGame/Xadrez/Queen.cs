using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XadrezGame.Tabuleiro;

namespace XadrezGame.Xadrez
{
	
	public class Queen : Piece
	{
		public Queen(Board board, PieceColor color) : base(color, board)
		{
		}

		public override string ToString()
		{
			return "D";
			//Dama
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

			//cima
			p.SetPosition(this.PiecePosition.Line - 1, this.PiecePosition.Column);
			while (CanMove(p) && this.CurrentBoard.IsValidPostion(p))
			{
				result[p.Line, p.Column] = true;

				if (this.CurrentBoard.GetPiece(p) != null && this.CurrentBoard.GetPiece(p).Color != this.Color)
					break;

				p.SetPosition(p.Line - 1, p.Column);
			}

			//baixo
			p.SetPosition(this.PiecePosition.Line + 1, this.PiecePosition.Column);
			while (CanMove(p) && this.CurrentBoard.IsValidPostion(p))
			{
				result[p.Line, p.Column] = true;

				if (this.CurrentBoard.GetPiece(p) != null && this.CurrentBoard.GetPiece(p).Color != this.Color)
					break;

				p.SetPosition(p.Line + 1, p.Column);
			}

			//direita
			p.SetPosition(this.PiecePosition.Line, this.PiecePosition.Column + 1);
			while (CanMove(p) && this.CurrentBoard.IsValidPostion(p))
			{
				result[p.Line, p.Column] = true;

				if (this.CurrentBoard.GetPiece(p) != null && this.CurrentBoard.GetPiece(p).Color != this.Color)
					break;

				p.SetPosition(p.Line, p.Column + 1);
			}

			//esquerda
			p.SetPosition(this.PiecePosition.Line, this.PiecePosition.Column - 1);
			while (CanMove(p) && this.CurrentBoard.IsValidPostion(p))
			{
				result[p.Line, p.Column] = true;

				if (this.CurrentBoard.GetPiece(p) != null && this.CurrentBoard.GetPiece(p).Color != this.Color)
					break;

				p.SetPosition(p.Line, p.Column - 1);
			}

			//diagonal pra baixo esquerda
			p.SetPosition(base.PiecePosition.Line - 1, base.PiecePosition.Column - 1);
			while (base.CurrentBoard.IsValidPostion(p) && CanMove(p))
			{
				result[p.Line, p.Column] = true;

				if (base.CurrentBoard.GetPiece(p) != null && base.CurrentBoard.GetPiece(p).Color != base.Color)
				{
					break;
				}

				p.SetPosition(p.Line - 1, p.Column - 1);

			}

			//diagonal pra cima esquerda
			p.SetPosition(base.PiecePosition.Line + 1, base.PiecePosition.Column - 1);
			while (base.CurrentBoard.IsValidPostion(p) && CanMove(p))
			{
				result[p.Line, p.Column] = true;

				if (base.CurrentBoard.GetPiece(p) != null && base.CurrentBoard.GetPiece(p).Color != base.Color)
				{
					break;
				}

				p.SetPosition(p.Line + 1, p.Column - 1);

			}

			//diagonal pra cima direita
			p.SetPosition(base.PiecePosition.Line + 1, base.PiecePosition.Column + 1);
			while (base.CurrentBoard.IsValidPostion(p) && CanMove(p))
			{
				result[p.Line, p.Column] = true;

				if (base.CurrentBoard.GetPiece(p) != null && base.CurrentBoard.GetPiece(p).Color != base.Color)
				{
					break;
				}

				p.SetPosition(p.Line + 1, p.Column + 1);

			}

			//diagonal pra baixo direita
			p.SetPosition(base.PiecePosition.Line - 1, base.PiecePosition.Column + 1);
			while (base.CurrentBoard.IsValidPostion(p) && CanMove(p))
			{
				result[p.Line, p.Column] = true;

				if (base.CurrentBoard.GetPiece(p) != null && base.CurrentBoard.GetPiece(p).Color != base.Color)
				{
					break;
				}

				p.SetPosition(p.Line - 1, p.Column + 1);

			}

			return result;
		}
	}
}
