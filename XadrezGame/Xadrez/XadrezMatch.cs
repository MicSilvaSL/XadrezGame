using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XadrezGame.Tabuleiro;

namespace XadrezGame.Xadrez
{
	public class XadrezMatch
	{
		
		private int _turn;
		private PieceColor _playerColor;
		
		public Board Board { get; private set; }
		public bool IsFinishedMatch { get; private set; }

		public XadrezMatch() 
		{
			Board = new Board(8, 8);
			_turn = 1;
			_playerColor = PieceColor.Red;
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


		public void ExecuteMovement(Position origin, Position destination) 
		{
			Piece piece = Board.RemovePiece(origin);
			piece.IncrementMovement();

			Piece capturedPiece = Board.RemovePiece(destination);
			
			Board.SetPieceOnBoard(piece, destination);
		}

	}
}
