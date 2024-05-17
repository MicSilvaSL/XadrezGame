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
		public static void ShowBoard(Board board)
		{
			for (int i = 0; i < board.Line; i++)
			{
				Console.Write(8 - i + " ");

				for (int j = 0; j < board.Colunm; j++)
				{

					if (board.GetPiece(i, j) == null)
					{
						Console.Write("- ");
					}
					else
					{
						PrintColorPiece(board.GetPiece(i,j));
					}


				}

				Console.WriteLine();

			}

			Console.WriteLine("  A B C D E F G H");

		}

		public static void PrintColorPiece(Piece piece) 
		{
			ConsoleColor aux = Console.ForegroundColor;

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
