using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Vernyomasnaplo
{
    internal class Program
    {
        static bool fut = true;
        static bool kivalasztva = false;
        static bool bejelentkezve = false; 
        static string[] menupontok = { "Regisztrálás", "Bejelentkezés", "Vérnyomás hozzáadása ", "Adatok megjelenítése", "Adat törlése", "Beállítások", "Kilépés" };
        static Action[] fuggvenyek = { Regisztral, Bejelentkezes, Hozzaad, Megjelenit, Torol, Beallit, Kilep };
        static int aktualis_menu_pont = 0;
        static int menupontok_szama = menupontok.Length;
        static ConsoleColor[] szinek = { ConsoleColor.Green, ConsoleColor.Red, ConsoleColor.Blue, ConsoleColor.Yellow, ConsoleColor.Cyan, ConsoleColor.Magenta, ConsoleColor.Gray, ConsoleColor.Black };
        static string[] szinek_neve = { "Zöld", "Piros", "Kék", "Sárga", "Cian", "Magenta", "Szürke", "Fekete" };
        static int szinek_szama = szinek.Length;
        static int alapszin = 0;
        static int alaphatter = 7;
        static string bejelentkezettFelhasznalo = "";

        static List<string> adatok = new List<string>();

        static void Main(string[] args)
        {
            while (fut)
            {
                Console.BackgroundColor = szinek[alaphatter];
                Console.Clear();

                int startIndex = bejelentkezve ? 2 : 0;
                int endIndex = bejelentkezve ? menupontok.Length : 2;

               
                for (int i = startIndex; i < endIndex; i++)
                {
                    if (aktualis_menu_pont == i)
                    {
                        Console.ForegroundColor = szinek[alapszin];
                        Console.WriteLine(menupontok[i]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.WriteLine(menupontok[i]);
                    }
                }

               
                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.Enter:
                        
                        if (aktualis_menu_pont >= startIndex && aktualis_menu_pont < endIndex)
                            fuggvenyek[aktualis_menu_pont]();

                        
                        if (bejelentkezve && aktualis_menu_pont < 2)
                            aktualis_menu_pont = 2;
                        break;

                    case ConsoleKey.UpArrow:
                        if (aktualis_menu_pont > startIndex)
                            aktualis_menu_pont--;
                        break;

                    case ConsoleKey.DownArrow:
                        if (aktualis_menu_pont < endIndex - 1)
                            aktualis_menu_pont++;
                        break;

                    default:
                        Console.Beep();
                        break;
                }
            }
        }






        static bool FelhasznaloLetezik(string nev)
        {
            if (!File.Exists("Felhaszn.txt")) return false;

            foreach (var sor in File.ReadAllLines("Felhaszn.txt"))
            {
                var adatok = sor.Split(';');
                if (adatok.Length > 0 && adatok[0] == nev)
                    return true;
            }
            return false;
        }

        static void Regisztral()
        {
            Console.Clear();
            Console.WriteLine("Regisztrálás:\n");
            Console.Write("Felhasználónév: ");
            string nev = Console.ReadLine();

            if (FelhasznaloLetezik(nev))
            {
                Console.WriteLine("Ez a felhasználónév már létezik!");
                Console.ReadLine();
                return;
            }

            Console.Write("Jelszó: ");
            string jelszo = Console.ReadLine();

            File.AppendAllText("Felhaszn.txt", $"{nev};{jelszo}\n");
            Console.WriteLine("Sikeres regisztráció!");
            Console.ReadLine();
        }

        static void Bejelentkezes()
        {
            Console.Clear();
            Console.WriteLine("Bejelentkezés:\n");

            Console.Write("Felhasználónév: ");
            string nev = Console.ReadLine();
            Console.Write("Jelszó: ");
            string jelszo = Console.ReadLine();

            if (!File.Exists("Felhaszn.txt"))
            {
                Console.WriteLine("Még nincs regisztrált felhasználó!");
                Console.ReadLine();
                return;
            }

            bool sikeres = false;
            foreach (var sor in File.ReadAllLines("Felhaszn.txt"))
            {
                var adatok = sor.Split(';');
                if (adatok.Length >= 2 && adatok[0] == nev && adatok[1] == jelszo)
                {
                    sikeres = true;
                    break;
                }
            }

            if (sikeres)
            {
                bejelentkezve = true;
                bejelentkezettFelhasznalo = nev;
                Console.WriteLine("Sikeres bejelentkezés!");
            }
            else
            {
                Console.WriteLine("Hibás felhasználónév vagy jelszó!");
            }
            Console.ReadLine();
        }

        static void Hozzaad()
        {
            Console.Clear();
            Console.WriteLine("Vérnyomás hozzáadása:\n");

            Console.Write("Adja meg a vérnyomás értékét: ");
            string vernyomas = Console.ReadLine();

            string fajlNev = $"{bejelentkezettFelhasznalo}_Adatok.txt";
            string sor = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - Vérnyomás: {vernyomas}";
            File.AppendAllText(fajlNev, sor + Environment.NewLine);

            Console.WriteLine("Sikeresen hozzáadva!");
            Console.ReadLine();
        }


        static void Megjelenit()
        {
            Console.Clear();
            string fajlNev = $"{bejelentkezettFelhasznalo}_Adatok.txt";

            if (!File.Exists(fajlNev))
            {
                Console.WriteLine("Nincs még mentett adat!");
            }
            else
            {
                Console.WriteLine("Mentett vérnyomás adatok:\n");
                foreach (var sor in File.ReadAllLines(fajlNev))
                {
                    Console.WriteLine(sor);
                }
            }
            Console.WriteLine("\nNyomjon le egy gombot a kilépéshez.");
            Console.ReadLine();
        }

        static void Torol()
        {
            Console.Clear();
            Console.WriteLine("Törlés");
            Console.ReadLine();
        }

        static void Beallit()
        {
            string[] kiirni = { "Betű", "Háttér" };
            bool megy = true;
            int aktualis = 0;

            while (megy)
            {
                Console.Clear();
                for (int i = 0; i < kiirni.Length; i++)
                {
                    if (i == aktualis)
                    {
                        Console.ForegroundColor = szinek[aktualis];
                        Console.WriteLine(kiirni[i]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                        Console.WriteLine(kiirni[i]);
                }

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Enter:
                        int szin = Szinvalaszto();
                        if (alaphatter != szin && alapszin != szin)
                        {
                            megy = false;
                            if (aktualis == 0)
                                alapszin = szin;
                            else
                                alaphatter = szin;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Nem lehet a betű és a háttér azonos színű! Enterre tovább!!!");
                            Console.ReadLine();
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (aktualis < kiirni.Length - 1)
                            aktualis++;
                        break;

                    case ConsoleKey.UpArrow:
                        if (aktualis > 0)
                            aktualis--;
                        break;
                }
            }
        }

        static int Szinvalaszto()
        {
            bool kivalaszt = true;
            int akt_szin_szama = 0;

            while (kivalaszt)
            {
                Console.Clear();
                for (int i = 0; i < szinek.Length; i++)
                {
                    if (i == akt_szin_szama)
                    {
                        Console.ForegroundColor = szinek[akt_szin_szama];
                        Console.WriteLine(szinek_neve[i]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                        Console.WriteLine(szinek_neve[i]);
                }

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Enter:
                        kivalaszt = false;
                        break;
                    case ConsoleKey.UpArrow:
                        if (akt_szin_szama > 0) akt_szin_szama--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (akt_szin_szama < szinek_szama - 1) akt_szin_szama++;
                        break;
                    default:
                        Console.Beep();
                        break;
                }
            }
            return akt_szin_szama;
        }

        static void Kilep()
        {
            fut = false;
        }
    }
}
