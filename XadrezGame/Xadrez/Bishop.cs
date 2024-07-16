using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XadrezGame.Tabuleiro;

namespace XadrezGame.Xadrez
{
	public class Bishop : Piece
	{

		public Bishop (Board board, PieceColor color) : base(color, board) 
		{

		}

		public override string ToString()
		{
			return "B";
			//Bispo
		}

		private bool CanMove(Position pos)
		{
			Piece p = this.CurrentBoard.GetPiece(pos);

			return p == null || p.Color != this.Color;
		}


		public override bool[,] PossibleMovements()
		{
			bool[,] result = new bool[base.CurrentBoard.Line, base.CurrentBoard.Colunm];

			Position p = new Position(0, 0);

			//diagonal pra baixo esquerda
			p.SetPosition(base.PiecePosition.Line - 1, base.PiecePosition.Column - 1);
			while(base.CurrentBoard.IsValidPostion(p) && CanMove(p)) 
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
