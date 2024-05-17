using XadrezGame.Tabuleiro;
using XadrezGame.Xadrez;

namespace XadrezGame
{
	internal class Program
	{
		static void Main(string[] args)
		{

			try 
			{
				XadrezMatch match = new XadrezMatch();

				while (!match.IsFinishedMatch) 
				{
					Console.Clear();
					ScreenView.ShowBoard(match.Board);
					
					Console.WriteLine();

					Console.WriteLine("Set origin:");
					Position orign = ScreenView.ReadXadrezPosition().ToPosition();

					Console.WriteLine("Set destination:");
					Position destination = ScreenView.ReadXadrezPosition().ToPosition();

					match.ExecuteMovement(orign, destination);

				}


				
			} 
			catch (BoardException tab) 
			{
				Console.WriteLine(tab.Message);
			}
			

			
		}
	}
}
