using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XadrezGame.Tabuleiro;

namespace XadrezGame.Xadrez
{
	public class Pawn : Piece
	{
		private XadrezMatch _match;

		public Pawn(Board board, PieceColor color, XadrezMatch match) : base(color, board)
		{
			_match = match;
		}

		public override string ToString()
		{
			return "P";
		}

		public bool ExistEnemy(Position pos)
		{
			Piece p = base.CurrentBoard.GetPiece(pos);

			return p != null && p.Color != base.Color;

		}

		public bool FreeSpace(Position pos) 
		{
			return base.CurrentBoard.GetPiece(pos) == null;
		}

		public override bool[,] PossibleMovements()
		{
			bool[,] result = new bool[this.CurrentBoard.Line, this.CurrentBoard.Colunm];

			Position p = new Position(0, 0);

			if (base.Color == PieceColor.Blue) 
			{
				p.SetPosition(base.PiecePosition.Line - 1, base.PiecePosition.Column);
				if (base.CurrentBoard.IsValidPostion(p) && FreeSpace(p)) 
				{
					result[p.Line, p.Column] = true;
				}

				p.SetPosition(base.PiecePosition.Line - 2, base.PiecePosition.Column);
				if (base.CurrentBoard.IsValidPostion(p) && FreeSpace(p) && base.AmountMovement == 0) 
				{
					result[p.Line, p.Column] = true;
				}

				p.SetPosition(base.PiecePosition.Line - 1, base.PiecePosition.Column - 1);
				if (base.CurrentBoard.IsValidPostion(p) && ExistEnemy(p)) 
				{
					result[p.Line, p.Column] = true;
				}

				p.SetPosition(base.PiecePosition.Line - 1, base.PiecePosition.Column + 1);
				if (base.CurrentBoard.IsValidPostion(p) && ExistEnemy(p))
				{
					result[p.Line, p.Column] = true;
				}

				//#jogada especial en passant
				if (base.PiecePosition.Line == 3) 
				{
					Position left = new Position(base.PiecePosition.Line, base.PiecePosition.Column - 1);
					if (CurrentBoard.IsValidPostion(left ) && ExistEnemy(left) && CurrentBoard.GetPiece(left) == _match.VulnerableEnPassant) 
					{
						result[left.Line - 1, left.Column] = true;
					}

					Position right = new Position(base.PiecePosition.Line, base.PiecePosition.Column + 1);
					if (CurrentBoard.IsValidPostion(right) && ExistEnemy(right) && CurrentBoard.GetPiece(right) == _match.VulnerableEnPassant)
					{
						result[right.Line - 1, right.Column] = true;
					}
				}

			}
			else 
			{
				p.SetPosition(base.PiecePosition.Line + 1, base.PiecePosition.Column);
				if (base.CurrentBoard.IsValidPostion(p) && FreeSpace(p))
				{
					result[p.Line, p.Column] = true;
				}

				p.SetPosition(base.PiecePosition.Line + 2, base.PiecePosition.Column);
				if (base.CurrentBoard.IsValidPostion(p) && FreeSpace(p) && base.AmountMovement == 0)
				{
					result[p.Line, p.Column] = true;
				}

				p.SetPosition(base.PiecePosition.Line + 1, base.PiecePosition.Column - 1);
				if (base.CurrentBoard.IsValidPostion(p) && ExistEnemy(p))
				{
					result[p.Line, p.Column] = true;
				}

				p.SetPosition(base.PiecePosition.Line + 1, base.PiecePosition.Column + 1);
				if (base.CurrentBoard.IsValidPostion(p) && ExistEnemy(p))
				{
					result[p.Line, p.Column] = true;
				}

				//#jogada especial en passant
				if (base.PiecePosition.Line == 4)
				{
					Position left = new Position(base.PiecePosition.Line, base.PiecePosition.Column - 1);
					if (CurrentBoard.IsValidPostion(left) && ExistEnemy(left) && CurrentBoard.GetPiece(left) == _match.VulnerableEnPassant)
					{
						result[left.Line + 1, left.Column] = true;
					}

					Position right = new Position(base.PiecePosition.Line, base.PiecePosition.Column + 1);
					if (CurrentBoard.IsValidPostion(right) && ExistEnemy(right) && CurrentBoard.GetPiece(right) == _match.VulnerableEnPassant)
					{
						result[right.Line + 1, right.Column] = true;
					}
				}

			}

			return result;
		}
	}
}
