using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XadrezGame.Tabuleiro;

namespace XadrezGame.Xadrez
{
	public class Rook : Piece
	{

		public Rook(Board board, PieceColor color) : base(color, board) { }


		public override string ToString()
		{
			return "T";
			//Torre
		}

		private bool CanMove(Position pos)
		{
			Piece p = this.CurrentBoard.GetPiece(pos);

			return p == null || p.Color != this.Color;
		}

		public override bool[,] PossibleMovements()
		{
			bool[,] possiblePath = new bool[this.CurrentBoard.Line, this.CurrentBoard.Colunm];

			Position p = new Position(0, 0);

			//cima
			p.SetPosition(this.PiecePosition.Line - 1, this.PiecePosition.Column);
			while(CanMove(p) && this.CurrentBoard.IsValidPostion(p)) 
			{
				possiblePath[p.Line, p.Column] = true;
				
				if (this.CurrentBoard.GetPiece(p) != null && this.CurrentBoard.GetPiece(p).Color != this.Color)
					break;

				p.SetPosition(p.Line - 1, p.Column);
			}

			//baixo
			p.SetPosition(this.PiecePosition.Line + 1, this.PiecePosition.Column);
			while (CanMove(p) && this.CurrentBoard.IsValidPostion(p))
			{
				possiblePath[p.Line, p.Column] = true;

				if (this.CurrentBoard.GetPiece(p) != null && this.CurrentBoard.GetPiece(p).Color != this.Color)
					break;

				p.SetPosition(p.Line + 1, p.Column);
			}

			//direita
			p.SetPosition(this.PiecePosition.Line, this.PiecePosition.Column + 1);
			while (CanMove(p) && this.CurrentBoard.IsValidPostion(p))
			{
				possiblePath[p.Line, p.Column] = true;

				if (this.CurrentBoard.GetPiece(p) != null && this.CurrentBoard.GetPiece(p).Color != this.Color)
					break;

				p.SetPosition(p.Line, p.Column + 1);
			}

			//esquerda
			p.SetPosition(this.PiecePosition.Line, this.PiecePosition.Column - 1);
			while (CanMove(p) && this.CurrentBoard.IsValidPostion(p))
			{
				possiblePath[p.Line, p.Column] = true;

				if (this.CurrentBoard.GetPiece(p) != null && this.CurrentBoard.GetPiece(p).Color != this.Color)
					break;

				p.SetPosition(p.Line, p.Column - 1);
			}


			return possiblePath;

		}

	}
}
