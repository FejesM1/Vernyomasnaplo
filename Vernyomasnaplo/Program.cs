using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vernyomasnaplo
{
    internal class Program
    {
        static void Main(string[] args)
        {
        bool fut=true;
        bool selected = false;
        string[] menupontok = { "Felhasználó regisztrálása", "Felhasználó adatainak módosítása","Felhasználó adatainak megjelenítése", "Felhasználó adatainak törlése", "Beállítások" };
        int aktualis_menu_pont = 0;
        int menupontok_szama=menupontok.Length;
            while (fut)
            {
                try
                {
                    Console.Clear();
                    for (int i = 0; i < menupontok_szama; i++)
                    {
                        if (aktualis_menu_pont == i)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
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
                            selected = true;
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

                }
                catch (Exception e)
                {
                    Console.WriteLine("Hiba történt!");
                    Console.WriteLine("Szeretné látni a hibát?");
                    
                }
            }

        }
    }
}
