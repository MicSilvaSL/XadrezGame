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
		private XadrezMatch _match;

		public King(Board board, PieceColor color, XadrezMatch match) : base(color, board) 
		{
			_match = match;
		}

		public override string ToString()
		{
			return "R";
		}

		private bool CanMove(Position pos) 
		{
			Piece p = this.CurrentBoard.GetPiece(pos);

			return p == null || p.Color != this.Color;
		}

		private bool TestRookForCastle(Position pos) //Roque teste para a torre
		{
			Piece p = base.CurrentBoard.GetPiece(pos);
			return p != null && p is Rook && p.Color == this.Color && p.AmountMovement == 0;
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

			// #jogadaespecial Roque 
			if (this.AmountMovement == 0 && !_match.Check)
			{
				//#jogadaespecial Roque pequeno
				Position PosHook1 = new Position(this.PiecePosition.Line, this.PiecePosition.Column + 3);
				if (TestRookForCastle(PosHook1)) 
				{
					Position p1 = new Position(this.PiecePosition.Line, this.PiecePosition.Column + 1);
					Position p2 = new Position(this.PiecePosition.Line, this.PiecePosition.Column + 2);
					
					if (base.CurrentBoard.GetPiece(p1) == null &&
						base.CurrentBoard.GetPiece(p2) == null) 
					{
						possiblePath[this.PiecePosition.Line, this.PiecePosition.Column + 2] = true;
					}
				}

				//#jogadaespecial Roque grande
				Position PosHook2 = new Position(this.PiecePosition.Line, this.PiecePosition.Column - 4);
				if (TestRookForCastle(PosHook2))
				{
					Position p1 = new Position(this.PiecePosition.Line, this.PiecePosition.Column - 1);
					Position p2 = new Position(this.PiecePosition.Line, this.PiecePosition.Column - 2);
					Position p3 = new Position(this.PiecePosition.Line, this.PiecePosition.Column - 3);
					
					if (base.CurrentBoard.GetPiece(p1) == null &&
						base.CurrentBoard.GetPiece(p2) == null &&
						base.CurrentBoard.GetPiece(p3) == null)
					{
						possiblePath[this.PiecePosition.Line, this.PiecePosition.Column - 2] = true;
					}
				}


			}


			return possiblePath;

		}

	}
}
