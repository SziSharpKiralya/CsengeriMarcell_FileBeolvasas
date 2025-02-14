using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarakterekOOP
{
	internal class KarakterStats
	{
		private string nev;
		private int szint;
		private int eletero;
		private int ero;

		public KarakterStats(string nev, int szint, int eletero, int ero)
		{
			this.nev = nev;
			this.szint = szint;
			this.eletero = eletero;
			this.ero = ero;
		}

		public string Nev { get => nev; }
		public int Szint { get => szint; }
		public int Eletero { get => eletero; }
		public int Ero { get => ero; }

		public override string ToString()
		{
			return $"{nev} - {szint}, Életpont: {eletero}, Hadierő: {ero} ";
		}
	
	}
}
