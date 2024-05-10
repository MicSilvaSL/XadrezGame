using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XadrezGame.Tabuleiro;

namespace XadrezGame.Xadrez
{
	public class XadrexPosition
	{
		public char Column { get; set; }
		public int Line { get; set; }

		public XadrexPosition(char column, int line) 
		{
			this.Column = column;
			this.Line = line;
		}

		public Position ToPosition() 
		{
			return new Position(8 - Line, Column - 'a');
		}


		public override string ToString()
		{
			return "" + Column + Line;
		}

	}
}
