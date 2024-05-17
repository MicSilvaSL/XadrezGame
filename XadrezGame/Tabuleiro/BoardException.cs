using System;

namespace XadrezGame.Tabuleiro
{
	public class BoardException : Exception
	{
		public BoardException (string msg) : base (msg) { }

	}
}
