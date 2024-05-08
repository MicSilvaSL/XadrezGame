using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XadrezGame.Tabuleiro;

namespace XadrezGame
{
	internal class ScreenView
	{
		public static void ShowBoard(Board board)
		{
			for (int i = 0; i < board.Line; i++)
			{
				for (int j = 0; j < board.Colunm; j++)
				{

					if (board.GetPiece(i, j) == null)
					{
						Console.Write("- ");
					}
					else
					{
						Console.Write(board.GetPiece(i, j) + " ");
					}


				}

				Console.WriteLine();

			}

		}
	}
}
