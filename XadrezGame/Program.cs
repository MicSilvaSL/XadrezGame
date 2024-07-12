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

					try 
					{
						Console.Clear();
						ScreenView.ShowBoard(match.Board);

						Console.WriteLine();

						Console.WriteLine("Turn: " + match.Turn);
						Console.WriteLine("Waiting player: " + match.CurrentPlayerColor);

						Console.WriteLine();

						Console.Write("Set origin: ");
						Position orign = ScreenView.ReadXadrezPosition().ToPosition();
						match.ValidOrignMovement(orign);

						bool[,] validPositions = match.Board.GetPiece(orign).PossibleMovements();

						Console.Clear();
						ScreenView.ShowBoard(match.Board, validPositions);

						Console.WriteLine();
						Console.Write("Set destination: ");
						Position destination = ScreenView.ReadXadrezPosition().ToPosition();
						match.ValidDestinationMovement(orign, destination);

						match.DoTurn(orign, destination);
					} 
					catch(BoardException e) 
					{
						Console.WriteLine(e.Message);
						Console.ReadLine();
					}
					
				}


				
			} 
			catch (BoardException tab) 
			{
				Console.WriteLine(tab.Message);
			}
			

			
		}
	}
}
