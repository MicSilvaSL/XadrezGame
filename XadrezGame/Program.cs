using XadrezGame.Tabuleiro;
using XadrezGame.Xadrez;

namespace XadrezGame
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Board b = new Board(8, 8);

			try 
			{
				b.SetPieceOnBoard(new King(b, PieceColor.Black), new Position(0, 0));
				b.SetPieceOnBoard(new Rook(b, PieceColor.Black), new Position(1, 3));
				b.SetPieceOnBoard(new Rook(b, PieceColor.Black), new Position(2, 7));

				ScreenView.ShowBoard(b);

			} 
			catch (TabuleiroException tab) 
			{
				Console.WriteLine(tab.Message);
			}
			

			
		}
	}
}
