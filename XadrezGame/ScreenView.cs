using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XadrezGame.Tabuleiro;
using XadrezGame.Xadrez;

namespace XadrezGame
{
	internal class ScreenView
	{

		public static void PrintMatch(XadrezMatch match) 
		{
			ShowBoard(match.Board);

			Console.WriteLine();
			
			PrintCapturePieces(match);

			Console.WriteLine();

			if (!match.IsFinishedMatch) 
			{
				Console.WriteLine("Turn: " + match.Turn);
				Console.WriteLine("Waiting player: " + match.CurrentPlayerColor);

				if (match.IsOnCheck(PieceColor.Blue))
				{
					Console.WriteLine("Is on Check");
				}
			}
			else 
			{
				Console.WriteLine("Finish match");
				Console.WriteLine("Color: " + match.CurrentPlayerColor.ToString() + " is the Winner!!");
			}


		}

		private static void PrintCapturePieces(XadrezMatch match) 
		{
			ConsoleColor aux = Console.ForegroundColor;

			Console.WriteLine("Captured Pieces:");
			Console.Write("Red: ");
			
			Console.ForegroundColor = ConsoleColor.Red;
			PrintCaptureSetPieces(match.PiecesCaptured(PieceColor.Red));
			Console.ForegroundColor = aux;

			Console.WriteLine();

			Console.Write("Blue: ");

			Console.ForegroundColor = ConsoleColor.Blue;
			PrintCaptureSetPieces(match.PiecesCaptured(PieceColor.Blue));
			Console.ForegroundColor = aux;
			

		}

		private static void PrintCaptureSetPieces(HashSet<Piece> pieces) 
		{
			Console.Write("[");

			foreach( Piece p in pieces) 
			{
				Console.Write(p + " ");
			}

			Console.Write("]");
		}

		public static void ShowBoard(Board board)
		{
			for (int i = 0; i < board.Line; i++)
			{
				Console.Write(8 - i + " ");

				for (int j = 0; j < board.Colunm; j++)
				{
					PrintPiece(board.GetPiece(i, j));
				}

				Console.WriteLine();

			}

			Console.WriteLine("  A B C D E F G H");

		}

		public static void ShowBoard(Board board, bool[,] validPostions)
		{
			ConsoleColor backgroundColor = Console.BackgroundColor;
			ConsoleColor highlightColor = ConsoleColor.DarkGray;


			for (int i = 0; i < board.Line; i++)
			{
				Console.Write(8 - i + " ");

				for (int j = 0; j < board.Colunm; j++)
				{
					if (validPostions[i, j])
					{
						Console.BackgroundColor = highlightColor;
					}

					PrintPiece(board.GetPiece(i, j));
					
					Console.BackgroundColor = backgroundColor;
				}

				Console.WriteLine();

			}

			Console.WriteLine("  A B C D E F G H");

		}


		public static void PrintPiece(Piece piece) 
		{
			ConsoleColor aux = Console.ForegroundColor;

			if (piece == null) 
			{
				Console.Write("- ");
			}
			else 
			{
				switch (piece.Color)
				{

					case PieceColor.Blue:

						Console.ForegroundColor = ConsoleColor.Blue;
						Console.Write(piece);
						Console.ForegroundColor = aux;
						break;

					case PieceColor.Red:

						Console.ForegroundColor = ConsoleColor.Red;
						Console.Write(piece);
						Console.ForegroundColor = aux;
						break;

					default:
						Console.Write(piece.ToString());
						break;
				}

				Console.Write(" ");

			}

		}


		public static XadrexPosition ReadXadrezPosition() 
		{
			string readPosition = Console.ReadLine();
			char column = readPosition[0];
			int line = int.Parse(readPosition[1] + "");

			return new XadrexPosition(column, line);

		}

	}
}
