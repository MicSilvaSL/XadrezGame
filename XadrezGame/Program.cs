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
				b.SetPieceOnBoard(new King(b, PieceColor.White), new Position(0, 0));
				b.SetPieceOnBoard(new Rook(b, PieceColor.Red), new Position(1, 3));
				b.SetPieceOnBoard(new Rook(b, PieceColor.Blue), new Position(2, 7));
			} 
			catch (TabuleiroException tab) 
			{
				Console.WriteLine(tab.Message);
			}
			

			ScreenView.ShowBoard(b);
		}
	}
}
