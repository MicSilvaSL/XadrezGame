using XadrezGame.Tabuleiro;

namespace XadrezGame.Xadrez
{
	public class XadrezMatch
	{

		public Board Board { get; private set; }
		
		public PieceColor CurrentPlayerColor { get; private set; }
		
		public bool IsFinishedMatch { get; private set; }
		
		public int Turn { get; private set; }

		public XadrezMatch() 
		{
			Board = new Board(8, 8);
			Turn = 1;
			CurrentPlayerColor = PieceColor.Red;
			InstantiatePieces();
		}

		private void InstantiatePieces() 
		{
			Board.SetPieceOnBoard(new Rook(Board, PieceColor.Red), new XadrexPosition('c', 1).ToPosition());
			Board.SetPieceOnBoard(new Rook(Board, PieceColor.Red), new XadrexPosition('c', 2).ToPosition());
			Board.SetPieceOnBoard(new Rook(Board, PieceColor.Red), new XadrexPosition('d', 2).ToPosition());
			Board.SetPieceOnBoard(new Rook(Board, PieceColor.Red), new XadrexPosition('e', 2).ToPosition());
			Board.SetPieceOnBoard(new Rook(Board, PieceColor.Red), new XadrexPosition('e', 1).ToPosition());
			Board.SetPieceOnBoard(new King(Board, PieceColor.Red), new XadrexPosition('d', 1).ToPosition());

			Board.SetPieceOnBoard(new Rook(Board, PieceColor.Blue), new XadrexPosition('c', 7).ToPosition());
			Board.SetPieceOnBoard(new Rook(Board, PieceColor.Blue), new XadrexPosition('c', 8).ToPosition());
			Board.SetPieceOnBoard(new Rook(Board, PieceColor.Blue), new XadrexPosition('d', 7).ToPosition());
			Board.SetPieceOnBoard(new Rook(Board, PieceColor.Blue), new XadrexPosition('e', 7).ToPosition());
			Board.SetPieceOnBoard(new Rook(Board, PieceColor.Blue), new XadrexPosition('e', 8).ToPosition());
			Board.SetPieceOnBoard(new King(Board, PieceColor.Blue), new XadrexPosition('d', 8).ToPosition());

		}

		public void DoTurn(Position origin, Position destination) 
		{
			ExecuteMovement(origin, destination);
			Turn++;
			ChangePlayerColor();
		}
		
		public void ChangePlayerColor() 
		{
			if (CurrentPlayerColor == PieceColor.Red) CurrentPlayerColor = PieceColor.Blue;
			else CurrentPlayerColor = PieceColor.Red;
		}

		public void ExecuteMovement(Position origin, Position destination) 
		{
			Piece piece = Board.RemovePiece(origin);
			piece.IncrementMovement();

			Piece capturedPiece = Board.RemovePiece(destination);
			
			Board.SetPieceOnBoard(piece, destination);
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
