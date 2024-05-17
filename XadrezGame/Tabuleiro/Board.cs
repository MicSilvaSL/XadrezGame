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


		public Piece GetPiece(int line, int colunm) 
		{
			return _pieces[line, colunm];
		}
		public Piece GetPiece(Position pos)
		{
			return GetPiece(pos.Line, pos.Column);
		}

		public Piece RemovePiece(Position pos) 
		{
			if (GetPiece(pos) == null) 
			{
				return null;
			}

			Piece remainder = GetPiece(pos);
			remainder.PiecePosition = null;
			_pieces[pos.Line, pos.Column] = null;

			return remainder;

		}


		public void SetPieceOnBoard(Piece p, Position pos) 
		{
			if (HasPieceOnPosition(pos)) 
			{
				throw new BoardException("Ja existe uma peca nessa posição");
			}

			_pieces[pos.Line, pos.Column] = p;
			p.PiecePosition = pos;
		}

		public bool IsValidPostion(Position pos) 
		{
			if (pos == null || pos.Line < 0 || pos.Line >= Line || pos.Column < 0 || pos.Column >= Colunm) 
				return false;

			return true;
		}

		public void CheckValidPostion(Position pos) 
		{
			if (!IsValidPostion(pos)) 
			{
				throw new BoardException("Posição invalida");
			}
		}

		public bool HasPieceOnPosition(Position pos)
		{
			CheckValidPostion(pos);
			return GetPiece(pos) != null;
		}

	}
}