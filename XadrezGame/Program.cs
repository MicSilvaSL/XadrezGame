using XadrezGame.Tabuleiro;

namespace XadrezGame
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Board b = new Board(8, 8);


			ScreenView.ShowBoard(b);
		}
	}
}
