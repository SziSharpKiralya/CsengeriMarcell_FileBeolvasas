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
			RendezesEroSzerint(karakterek);
            HaromLegjobb(karakterek);
			Csata(karakterek[0], karakterek[1]);
            Console.WriteLine($"{karakterek[2].Nev}-nek a támadása igaz-e hogy meghaladja a 20-at: {karakterek[2].MeghaladjaE(20)}");
			Console.WriteLine($"{karakterek[6].Nev}-nek a támadása igaz-e hogy meghaladja a 89-at: {karakterek[6].MeghaladjaE(89)}");
			AdatokFajlba(karakterek);
			AdatokBeolvasasaFajlbol("karakterek.csv", karakterek);
            
            //foreach (var item in karakterek)
            //{
            //	Console.WriteLine(item.ToString());
            //}
        }
		static void AdatokFajlba(List<Karakter> karakterek)
		{
			karakterek.Clear();
			string szoveg = "";
			szoveg += "Nev;Szint;Eletero;Ero\n";
			foreach (var item in karakterek)
			{
				szoveg += item.Nev + ";" + item.Szint + ";" + item.Eletero + ";" + item.Ero + "\n";
			}
            File.WriteAllText("./karakterek.csv", szoveg);
		}
		static void AdatokBeolvasasaFajlbol(string fileNev, List<Karakter> karakterek)
		{
			karakterek.Clear();
			StreamReader sr = new StreamReader(fileNev);
			sr.ReadLine();

			while (!sr.EndOfStream)
			{
				string line = sr.ReadLine();
				string[] szavak = line.Split(";");
                Karakter karakter = new Karakter(szavak[0], Convert.ToInt16(szavak[1]), Convert.ToInt16(szavak[2]), Convert.ToInt16(szavak[3]));
				karakterek.Add(karakter);
			}
			Console.WriteLine("Karakterek be lettek olvasva CSV fájlból");
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

		static void RendezesEroSzerint(List<Karakter> karakterek)
		{
			for (int i = 0; i < karakterek.Count; i++) {
				for (int j = 0; j < karakterek.Count; j++)
				{
					if ((karakterek[i].Ero > karakterek[j].Ero))
					{
						Karakter csere = karakterek[i];
						karakterek[i] = karakterek[j];
						karakterek [j] = csere;
					}
				}
			}
            Console.WriteLine("Karakterek szintje erejük szerint újra lett rendezve");
            //foreach (var item in karakterek)
            //{
            //	//Console.WriteLine(item.Ero);
            //}
        }

        static void HaromLegjobb(List<Karakter> karakterek)
        {
            for (int i = 0; i < karakterek.Count; i++)
            {
                for (int j = 0; j < karakterek.Count; j++)
                {
                    if ((karakterek[i].Ero + karakterek[i].Szint > karakterek[j].Ero + karakterek[i].Szint))
                    {
                        Karakter csere = karakterek[i];
                        karakterek[i] = karakterek[j];
                        karakterek[j] = csere;
                    }
                }
            }
            Console.Write("A három legjobb karakter: ");
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"{karakterek[i].Nev}, ");
            }
            Console.WriteLine();
        }

		static void Csata(Karakter karakter1, Karakter karakter2)
		{
            if (karakter1.Ero + karakter1.Szint  > karakter2.Ero + karakter2.Szint)
			{
                Console.WriteLine($"{karakter1.Nev} győzedelmeskedett {karakter2.Nev} felett");
			}
            else
            {
                Console.WriteLine($"{karakter2.Nev} győzedelmeskedett {karakter1.Nev} felett");
            }

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
			Console.WriteLine("Karakterek be lettek olvasva TXT fájlból");
		}
	}
}
