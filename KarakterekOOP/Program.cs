using System.Collections.Generic;

namespace KarakterekOOP
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<Karakter> karakterek = new List<Karakter>();
			Beolvasas("karakterek.txt", karakterek);
			LegmagasabbEletero(karakterek);
			AtlagSzint(karakterek);

			foreach (var item in karakterek)
            {
				//Console.WriteLine(item.ToString());
            }
        }

		static void LegmagasabbEletero(List<Karakter> karakterek)
		{
			Karakter legnagyobb = karakterek[0];
	
			foreach (var item in karakterek)
			{
				if (legnagyobb.Eletero < item.Eletero)
				{
					legnagyobb = item;
				}
			}
			Console.WriteLine($"Legnagyobb életerővel rendelkező karakter: {legnagyobb.Nev} {legnagyobb.Szint} {legnagyobb.Ero}");
        }
		static void AtlagSzint(List<Karakter> karakterek)
		{
			int osszSzint = 0;
			foreach (var item in karakterek)
			{
				osszSzint += item.Szint;
			}
			Console.WriteLine($"Karakterek szintjének átlaga: {osszSzint/karakterek.Count}");
		}

		static void Beolvasas(string fileNev, List<Karakter> karakterek)
		{
			StreamReader sr = new StreamReader(fileNev);
			sr.ReadLine();
			
			while (!sr.EndOfStream) {
				string line = sr.ReadLine();
				string[] szavak = line.Split(";");
				
				Karakter karakter = new Karakter(szavak[0], Convert.ToInt16(szavak[1]), Convert.ToInt16(szavak[2]), Convert.ToInt16(szavak[3]));
				karakterek.Add(karakter);
			}
		}
	}
}
