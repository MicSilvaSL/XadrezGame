using XadrezGame.Tabuleiro;

namespace XadrezGame.Xadrez
{
	public class XadrezMatch
	{

		private HashSet<Piece> _capturedPieces;
		private HashSet<Piece> _allPieces;

		public Board Board { get; private set; }

		public PieceColor CurrentPlayerColor { get; private set; }

		public bool IsFinishedMatch { get; private set; }

		public int Turn { get; private set; }

		public bool Check { get; private set; }

		public XadrezMatch()
		{
			Board = new Board(8, 8);
			Turn = 1;
			CurrentPlayerColor = PieceColor.Red;
			_allPieces = new HashSet<Piece>();
			_capturedPieces = new HashSet<Piece>();

			InstantiatePieces();

		}

		public void PlacePiece(Piece piece, char column, int line)
		{
			Board.SetPieceOnBoard(piece, new XadrexPosition(column, line).ToPosition());
			_allPieces.Add(piece);
		}

		private void InstantiatePieces()
		{
			PlacePiece(new Rook(Board, PieceColor.Red), 'h', 7);
			PlacePiece(new Rook(Board, PieceColor.Red), 'c', 1);
			PlacePiece(new Pawn(Board, PieceColor.Red), 'c', 2);
			PlacePiece(new Bishop(Board, PieceColor.Red), 'd', 2);
			PlacePiece(new Queen(Board, PieceColor.Red), 'f', 1);
			PlacePiece(new Knight(Board, PieceColor.Red), 'f', 4);
			PlacePiece(new King(Board, PieceColor.Red), 'd', 1);

			PlacePiece(new Rook(Board, PieceColor.Blue), 'c', 6);
			PlacePiece(new Rook(Board, PieceColor.Blue), 'b', 8);
			PlacePiece(new King(Board, PieceColor.Blue), 'a', 8);

		}

		public void DoTurn(Position origin, Position destination)
		{
			Piece pieceCaptured = ExecuteMovement(origin, destination);

			if (IsOnCheck(CurrentPlayerColor)) 
			{
				UndoMovement(origin, destination, pieceCaptured);
				throw new BoardException("You can't put yourself in check");
			}

			if (IsOnCheck(GetOpositeColor(CurrentPlayerColor)))
				Check = true;
			else
				Check = false;

			if (IsOnCheckMate(GetOpositeColor(CurrentPlayerColor))) 
			{
				IsFinishedMatch = true;
			}
			else 
			{
				Turn++;
				ChangePlayerColor();
			}

		}

		public void ChangePlayerColor()
		{
			if (CurrentPlayerColor == PieceColor.Red) CurrentPlayerColor = PieceColor.Blue;
			else CurrentPlayerColor = PieceColor.Red;
		}

		public Piece ExecuteMovement(Position origin, Position destination)
		{
			Piece piece = Board.RemovePiece(origin);
			piece.IncrementMovement();

			Piece capturedPiece = Board.RemovePiece(destination);

			Board.SetPieceOnBoard(piece, destination);

			if (capturedPiece != null)
			{
				_capturedPieces.Add(capturedPiece);
			}

			return capturedPiece;

		}

		public void UndoMovement(Position origin, Position destination, Piece capturedPiece)
		{
			Piece destinationPiece = Board.RemovePiece(destination);
			destinationPiece.DecrementMovement();

			if (capturedPiece != null) 
			{
				Board.SetPieceOnBoard(capturedPiece, destination);
				_capturedPieces.Remove(capturedPiece);
			}

			Board.SetPieceOnBoard(destinationPiece, origin);

		}

		public PieceColor GetOpositeColor(PieceColor color)
		{
			return color == PieceColor.Blue ? PieceColor.Red : PieceColor.Blue;
		}

		public Piece GetKing(PieceColor color)
		{
			foreach (var piece in PiecesInGame(color))
			{
				if (piece is King) return piece;
			}

			return null;
		}

		public bool IsOnCheck(PieceColor color) 
		{
			Piece r = GetKing(color);

			if (r == null) throw new BoardException("Não existe rei da cor "  + color + " ??");

			foreach(Piece p in PiecesInGame(GetOpositeColor(color))) 
			{
				bool[,] movements = p.PossibleMovements();
				if (movements[r.PiecePosition.Line, r.PiecePosition.Column]) 
				{
					return true;
				}
			}

			return false;
		}

		public bool IsOnCheckMate(PieceColor color) 
		{
			if (!IsOnCheck(color)) 
			{
				return false;
			}

			foreach(Piece p in PiecesInGame(color)) 
			{
				bool[,] moves = p.PossibleMovements();

				for (int x = 0; x < Board.Line; x++)
				{
					for (int y = 0; y < Board.Colunm; y++)
					{
						if (moves[x, y])
						{
							Position origin = p.PiecePosition;
							Position destination = new Position(x, y);
							Piece captured = ExecuteMovement(p.PiecePosition, destination);
							bool isInCheck = IsOnCheck(color);
							UndoMovement(origin, destination, captured);

                            if (!isInCheck)
                            {
								return false;
                            }
                        }

					}
				}

			}


			return true;
		}

		public HashSet<Piece> PiecesCaptured(PieceColor pieceColor) 
		{
			HashSet<Piece> result = new HashSet<Piece>();

			foreach (Piece piece in _capturedPieces)
			{
				if (piece.Color == pieceColor)
				{
					result.Add(piece);
				}
			}

			return result;
		}

		public HashSet<Piece> PiecesInGame(PieceColor pieceColor) 
		{
			HashSet<Piece> result = new HashSet<Piece>();

			foreach (Piece piece in _allPieces)
			{
				if (piece.Color == pieceColor)
				{
					result.Add(piece);
				}
			}

			result.ExceptWith(PiecesCaptured(pieceColor));

			return result;

		}

		public void ValidOrignMovement(Position pos) 
		{
			if (!Board.HasPieceOnPosition(pos)) 
			{
				throw new BoardException("Não existe peça nessa posição");
			}
			
			if (CurrentPlayerColor != Board.GetPiece(pos).Color) 
			{
				throw new BoardException("A peça de origem não é a sua");
			}

			if (!Board.GetPiece(pos).ExistPossibleMovements()) 
			{
				throw new BoardException("Essa peça não tem nenhum movemento não possivel");
			}

		}
		public void ValidDestinationMovement(Position origin, Position destination) 
		{
			if (!Board.GetPiece(origin).CanMoveTo(destination)) 
			{
				throw new BoardException("Não pode mover para esse local");
			}
		}

	}
}
