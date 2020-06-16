using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt_MarcinGalica
{
    class Gra
    {
        static int[,] plansza;
        string nazwa_Gracza;

        public Gra(int gracz, string nazwaGracza)
        {
            Gracz = gracz;
            plansza = new int[3, 3];
            NazwaGracza = nazwaGracza;
        }
        public int Gracz { get; set; }

        public string NazwaGracza
        {
            get { return this.nazwa_Gracza; }
            set
            {
                if (value.Length > 0)
                {
                    nazwa_Gracza = value;
                }
                else
                {
                    while (value.Length < 1)
                    {
                        Console.WriteLine("Zmień nazwe Gracza:");
                        value = Console.ReadLine();
                    }
                }
            }
        }


        public static void inicjacjaPlansza()
        {
            for (int rzad = 0; rzad < 3; rzad++)
            {
                for (int kolumna = 0; kolumna < 3; kolumna++)
                {
                    plansza[rzad, kolumna] = 0;
                }
            }
            pokazPlansze();
        }
        private static void pokazPlansze()
        {
            for (int rzad = 0; rzad < 3; rzad++)
            {
                for (int kolumna = 0; kolumna < 3; kolumna++)
                {
                    Console.Write(plansza[rzad, kolumna] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("-----");
        }
        }
    }
