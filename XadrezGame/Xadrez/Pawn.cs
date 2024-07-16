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
		public Pawn(Board board, PieceColor color) : base(color, board)
		{
		}

		public override string ToString()
		{
			return "P";
			//Cavalo
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

			if (base.Color == PieceColor.Red) 
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
			}

			return result;
		}
	}
}
