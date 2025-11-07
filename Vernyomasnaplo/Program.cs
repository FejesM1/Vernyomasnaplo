using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Vernyomasnaplo
{
    internal class Program
    {
        static bool fut=true;
        static bool kivalasztva = false;
        static string[] menupontok = { "Regisztrálás", "Adatok módosítása","Adatok megjelenítése", "Adat törlése", "Beállítások", "Kilépés" };
        static Action[] fuggvenyek = { Regisztral, Modosit, Megjelenit, Torol, Beallit, Kilep };
        static int aktualis_menu_pont = 0;
        static int menupontok_szama=menupontok.Length;
        static ConsoleColor[] szinek = {
                ConsoleColor.Green,
                ConsoleColor.Red,
                ConsoleColor.Blue,
                ConsoleColor.Yellow,
               
                ConsoleColor.Cyan,
                ConsoleColor.Magenta,
                ConsoleColor.Gray
            };
        static string[] szinek_neve = {
                    "Zöld",
                    "Piros",
                    "Kék",
                    "Sárga",
                  
                    "Cian",
                    "Magenta",
                    "Szürke"
                };
        static int szinek_szama=szinek.Length;
        static int alapszin = 0;
        static int alaphatter = 0;
        static void Main(string[] args)
        {
            while (fut)
            {
                try
                {
                    Console.Clear();
                    for (int i = 0; i < menupontok_szama; i++)
                    {
                        if (aktualis_menu_pont == i)
                        {
                            Console.ForegroundColor = szinek[alapszin];
                            Console.WriteLine(menupontok[i]);
                            Console.ForegroundColor=ConsoleColor.White;
                        }
                        else
                        {
                            Console.WriteLine(menupontok[i]);

                        }
                    }
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.Enter:
                            kivalasztva = true;
                            break;


                        case ConsoleKey.UpArrow:
                            if (aktualis_menu_pont > 0)
                            {
                                aktualis_menu_pont--;
                            }
                            break;

                        case ConsoleKey.DownArrow:
                            if (aktualis_menu_pont < menupontok_szama-1)
                            {
                                aktualis_menu_pont++;
                            }
                            break;




                        default:
                            Console.Beep();
                            break;
                    }

                    if (kivalasztva)
                    {
                        fuggvenyek[aktualis_menu_pont]();
                        kivalasztva=false;
                        aktualis_menu_pont = 0; 
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine("Hiba történt!");
                    Console.WriteLine("Szeretné látni a hibát?");
                    
                }
            }

        }
        static void Regisztral()
        {
            Console.Clear();
            Console.WriteLine("Regisztrál");
            Console.ReadLine();
        }

        static void Modosit()
        {
            Console.Clear();
            Console.WriteLine("Módosít");
            Console.ReadLine();
        }
        static void Megjelenit()
        {
            Console.Clear();
            Console.WriteLine("megjelenit");
            Console.ReadLine();
        }
        static void Torol()
        {
            Console.Clear();
            Console.WriteLine("töröl");
            Console.ReadLine();
        }
        static void Beallit()
        {
            
        bool kivalaszt=true;
            int akt_szin_szama = 0;
            while (kivalaszt)
            {
                Console.Clear();
                Console.WriteLine("Betűszín beállítása:");
                Console.WriteLine();
                for (int i = 0; i < szinek.Length; i++)
                {
                    if (i==akt_szin_szama) {
                        Console.ForegroundColor = szinek[akt_szin_szama];
                        Console.WriteLine(szinek[i]);
                        Console.ForegroundColor = ConsoleColor.White;

                    }
                    else
                    {
                        Console.WriteLine(szinek[i]);
                    }
                }
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Enter:
                        kivalaszt = false;
                        alapszin=akt_szin_szama;
                        break;
                    case ConsoleKey.UpArrow:
                        if (akt_szin_szama > 0)
                        {
                            akt_szin_szama--;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (akt_szin_szama < szinek_szama - 1)
                        {
                            akt_szin_szama++;
                        }
                        break;




                    default:
                        Console.Beep();
                        break;

                }
            }
        


            
        }
        static void Kilep()
        {
            fut = false;
        }
    }
}
