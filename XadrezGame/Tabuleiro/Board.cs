namespace XadrezGame.Tabuleiro
{
	public class Board
	{
		public int Line { get; set; }
		public int Colunm { get; set; }

		private Piece[,] _pieces;

		public Board (int  line, int colunm) 
		{
			this.Line = line;
			this.Colunm = colunm;
			
			_pieces = new Piece[line, colunm];
		}

	}
}