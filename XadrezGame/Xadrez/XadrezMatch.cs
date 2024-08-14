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

		public Piece VulnerableEnPassant { get; private set; }

		public XadrezMatch()
		{
			Board = new Board(8, 8);
			Turn = 1;
			CurrentPlayerColor = PieceColor.Red;
			_allPieces = new HashSet<Piece>();
			_capturedPieces = new HashSet<Piece>();
			VulnerableEnPassant = null;

			InstantiatePieces();

		}

		public void PlacePiece( char column, int line, Piece piece)
		{
			Board.SetPieceOnBoard(piece, new XadrexPosition(column, line).ToPosition());
			_allPieces.Add(piece);
		}

		private void InstantiatePieces()
		{
			PlacePiece('a', 1, new Rook(Board, PieceColor.Blue));
			PlacePiece('b', 1, new Knight(Board, PieceColor.Blue));
			PlacePiece('c', 1, new Bishop(Board, PieceColor.Blue));
			PlacePiece('d', 1, new Queen(Board, PieceColor.Blue));
			PlacePiece('e', 1, new King(Board, PieceColor.Blue, this));
			PlacePiece('f', 1, new Bishop(Board, PieceColor.Blue));
			PlacePiece('g', 1, new Knight(Board, PieceColor.Blue));
			PlacePiece('h', 1, new Rook(Board, PieceColor.Blue));

			PlacePiece('a', 2, new Pawn(Board, PieceColor.Blue, this));
			PlacePiece('b', 2, new Pawn(Board, PieceColor.Blue, this));
			PlacePiece('c', 2, new Pawn(Board, PieceColor.Blue, this));
			PlacePiece('d', 2, new Pawn(Board, PieceColor.Blue, this));
			PlacePiece('e', 2, new Pawn(Board, PieceColor.Blue, this));
			PlacePiece('f', 2, new Pawn(Board, PieceColor.Blue, this));
			PlacePiece('g', 2, new Pawn(Board, PieceColor.Blue, this));
			PlacePiece('h', 2, new Pawn(Board, PieceColor.Blue, this));


			PlacePiece('a', 8, new Rook(Board, PieceColor.Red));
			PlacePiece('b', 8, new Knight(Board, PieceColor.Red));
			PlacePiece('c', 8, new Bishop(Board, PieceColor.Red));
			PlacePiece('d', 8, new Queen(Board, PieceColor.Red));
			PlacePiece('e', 8, new King(Board, PieceColor.Red, this));
			PlacePiece('f', 8, new Bishop(Board, PieceColor.Red));
			PlacePiece('g', 8, new Knight(Board, PieceColor.Red));
			PlacePiece('h', 8, new Rook(Board, PieceColor.Red));

			PlacePiece('a', 7, new Pawn(Board, PieceColor.Red, this));
			PlacePiece('b', 7, new Pawn(Board, PieceColor.Red, this));
			PlacePiece('c', 7, new Pawn(Board, PieceColor.Red, this));
			PlacePiece('d', 7, new Pawn(Board, PieceColor.Red, this));
			PlacePiece('e', 7, new Pawn(Board, PieceColor.Red, this));
			PlacePiece('f', 7, new Pawn(Board, PieceColor.Red, this));
			PlacePiece('g', 7, new Pawn(Board, PieceColor.Red, this));
			PlacePiece('h', 7, new Pawn(Board, PieceColor.Red, this));

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

			//#jogada especial em passant
			Piece p = Board.GetPiece(destination);

			if (p is Pawn && (destination.Line == origin.Line - 2 || destination.Line == origin.Line + 2))
				VulnerableEnPassant = p;
			else 
				VulnerableEnPassant = null;


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

			// #jogadaespecial Roque pequeno
			if (piece is King && destination.Column == origin.Column + 2) 
			{
				Position originHook = new Position(origin.Line, origin.Column + 3);
				Position destinationHook = new Position(origin.Line, origin.Column + 1);

				Piece hook = Board.RemovePiece(originHook);
				hook.IncrementMovement();
				Board.SetPieceOnBoard(hook, destinationHook);

			}

			// #jogadaespecial Roque grande
			if (piece is King && destination.Column == origin.Column - 2)
			{
				Position originHook = new Position(origin.Line, origin.Column - 4);
				Position destinationHook = new Position(origin.Line, origin.Column - 1);

				Piece hook = Board.RemovePiece(originHook);
				hook.IncrementMovement();
				Board.SetPieceOnBoard(hook, destinationHook);

			}

			//#jogadaespecial en passant
			if (piece is Pawn) 
			{
				if (destination.Column != origin.Column && capturedPiece == null) 
				{
					Position pos = piece.Color == PieceColor.Blue ? 
						new Position(destination.Line + 1, destination.Column) :
						new Position(destination.Line - 1, destination.Column);

					capturedPiece = Board.RemovePiece(pos);
					_capturedPieces.Add(capturedPiece);

				}
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

			if (destinationPiece is King && destination.Column == origin.Column + 2)
			{
				Position originHook = new Position(origin.Line, origin.Column + 3);
				Position destinationHook = new Position(origin.Line, origin.Column + 1);

				Piece hook = Board.RemovePiece(destinationHook);
				hook.DecrementMovement();
				Board.SetPieceOnBoard(hook, originHook);

			}

			// #jogadaespecial Roque grande
			if (destinationPiece is King && destination.Column == origin.Column - 2)
			{
				Position originHook = new Position(origin.Line, origin.Column - 4);
				Position destinationHook = new Position(origin.Line, origin.Column - 1);

				Piece hook = Board.RemovePiece(destinationHook);
				hook.DecrementMovement();
				Board.SetPieceOnBoard(hook, originHook);

			}

			//#jogadaespecial en passant
			if (destinationPiece is Pawn)
			{
				if (destination.Column != origin.Column && capturedPiece == VulnerableEnPassant)
				{
					Piece pawn = Board.RemovePiece(destination);
					
					Position p = destinationPiece.Color == PieceColor.Blue ?
						new Position(3,destination.Column) :
						new Position(4,destination.Column);


					Board.SetPieceOnBoard(pawn, p);

				}
			}


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
