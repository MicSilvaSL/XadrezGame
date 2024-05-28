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

		public King(Board board, PieceColor color) : base(color, board) { }

		public override string ToString()
		{
			return "R";
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
			if (this.CurrentBoard.IsValidPostion(p) && CanMove(p)) 
			{
				possiblePath[p.Line, p.Column] = true;
			}

			//nordeste
			p.SetPosition(this.PiecePosition.Line - 1, this.PiecePosition.Column + 1);
			if (this.CurrentBoard.IsValidPostion(p) && CanMove(p))
			{
				possiblePath[p.Line, p.Column] = true;
			}

			//direta
			p.SetPosition(this.PiecePosition.Line, this.PiecePosition.Column + 1);
			if (this.CurrentBoard.IsValidPostion(p) && CanMove(p))
			{
				possiblePath[p.Line, p.Column] = true;
			}

			//sudeste
			p.SetPosition(this.PiecePosition.Line + 1, this.PiecePosition.Column + 1);
			if (this.CurrentBoard.IsValidPostion(p) && CanMove(p))
			{
				possiblePath[p.Line, p.Column] = true;
			}

			//baixo
			p.SetPosition(this.PiecePosition.Line + 1, this.PiecePosition.Column);
			if (this.CurrentBoard.IsValidPostion(p) && CanMove(p))
			{
				possiblePath[p.Line, p.Column] = true;
			}

			//sudoeste
			p.SetPosition(this.PiecePosition.Line + 1, this.PiecePosition.Column - 1);
			if (this.CurrentBoard.IsValidPostion(p) && CanMove(p))
			{
				possiblePath[p.Line, p.Column] = true;
			}

			//esquerda
			p.SetPosition(this.PiecePosition.Line, this.PiecePosition.Column - 1);
			if (this.CurrentBoard.IsValidPostion(p) && CanMove(p))
			{
				possiblePath[p.Line, p.Column] = true;
			}

			//noroeste
			p.SetPosition(this.PiecePosition.Line - 1, this.PiecePosition.Column - 1);
			if (this.CurrentBoard.IsValidPostion(p) && CanMove(p))
			{
				possiblePath[p.Line, p.Column] = true;
			}


			return possiblePath;

		}

	}
}
