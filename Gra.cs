using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Timers;

namespace Projekt_MarcinGalica
{
    class Gra
    {
        static string[,] plansza;
        string nazwa_Gracza;

        public Gra(string gracz, string nazwaGracza)
        {
            Gracz = gracz;
            plansza = new string[3, 3];
            NazwaGracza = nazwaGracza;
        }
        public string Gracz { get; set; }

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

        public bool PrzebiegGry()
        {
            int rzad = 0;
            int kolumna = 0;

            Random rand1 = new Random();
            Random rand2 = new Random();
            //sprawdzam czy graczem jest komputer
            if(NazwaGracza != "komputer")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Tura: " + NazwaGracza);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Podaj miejsce w którym chcesz postawic symbol:");
                Console.Write("Podaj rzad: ");
                int.TryParse(Console.ReadLine().Trim(), out rzad);
                Console.Write("Podaj kolumne: ");
                int.TryParse(Console.ReadLine().Trim(), out kolumna);
            }
            else
            {
                rzad = rand1.Next(1, 4);    //komuter losuje rzad
                for(int i = 0; i < 5000; i++)
                {
                    kolumna = rand2.Next(1, 4);     //komputer losuje kolumne
                }
            }
            while (!sprawdzPlansze(rzad, kolumna))
            {
                if(NazwaGracza != "komputer")
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Podane kordy są nie poprawne.");
                    Console.WriteLine("Podaj miejsce w którym chcesz postawic symbol:");
                    Console.Write("Podaj rzad: ");
                    int.TryParse(Console.ReadLine().Trim(), out rzad);
                    Console.Write("Podaj kolumne: ");
                    int.TryParse(Console.ReadLine().Trim(), out kolumna);
                }
                else
                {
                    rzad = rand1.Next(1, 4);    //komuter losuje rzad
                    for (int i = 0; i < 5000; i++)
                    {
                        kolumna = rand2.Next(1, 4);     //komputer losuje kolumne
                    }
                }
            }

            plansza[rzad - 1, kolumna - 1] = Gracz;
            pokazPlansze();     //Pokazuje zaktualizowaną plansze

            if (zwyciestwo())
            {
                if(NazwaGracza == ("komputer"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Komputer wygrał!!!");
                    Console.ResetColor();
                    Console.WriteLine("ESC - Wróć do Menu");
                    Console.WriteLine("F1 - Nowa tura skonczona");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Gratulacje "+ NazwaGracza +" udało ci się wygrać!!!");
                    Console.ResetColor();
                    Console.WriteLine("ESC - Wróć do Menu");
                    Console.WriteLine("F1 - Nowa tura skonczona");
                }
                return true;
            }else if (remis())
            {
                Console.WriteLine("!!!REMIS!!!");
                Console.ResetColor();
                Console.WriteLine("ESC - Wróć do Menu");
                Console.WriteLine("F1 - Nowa tura skonczona");
                return true;
            }
            return false;
        }
        private bool zwyciestwo()
        {
            //sprawdza po rządzie
            if(plansza[0,0] == Gracz && plansza[0,1] == Gracz && plansza[0,2] == Gracz)
            {
                return true;
            }
            if(plansza[1, 0] == Gracz && plansza[1, 1] == Gracz && plansza[1, 2] == Gracz)
            {
                return true;
            }
            if(plansza[2, 0] == Gracz && plansza[2, 1] == Gracz && plansza[2, 2] == Gracz)
            {
                return true;
            }
            //sprawdza po kolumnie
            if (plansza[0, 0] == Gracz && plansza[1, 0] == Gracz && plansza[2, 0] == Gracz)
            {
                return true;
            }
            if (plansza[0, 1] == Gracz && plansza[1, 1] == Gracz && plansza[2, 1] == Gracz)
            {
                return true;
            }
            if (plansza[0, 2] == Gracz && plansza[1, 2] == Gracz && plansza[2, 2] == Gracz)
            {
                return true;
            }
            //sprawdza na skos
            if (plansza[0, 0] == Gracz && plansza[1, 1] == Gracz && plansza[2, 2] == Gracz)
            {
                return true;
            }
            if (plansza[0, 2] == Gracz && plansza[1, 1] == Gracz && plansza[2, 0] == Gracz)
            {
                return true;
            }
            return false;
        }
        private bool remis()
        {
            for(int rzad = 0; rzad < 3; rzad++)
            {
                for(int kolumna = 0; kolumna <3; kolumna++)
                {
                    if(plansza[rzad,kolumna] != "1" && plansza[rzad, kolumna] != "2")
                    {
                        return false;
                    }
                   
                }
            }
            return true;
        }
        //Sprawdzanie czy plansza jest poprawna
        private bool sprawdzPlansze(int rzad, int kolumna)
        {
            bool poprawne = false;
            if(rzad > 3 || kolumna > 3 || rzad < 1 || kolumna < 1)
            {
                return false;
            }
            if (plansza[rzad-1, kolumna-1] != "X" && plansza[rzad-1,kolumna-1] != "O")
            {
                poprawne = true;
            }
            return poprawne;
        }
        public static void inicjacjaPlanszy()
        {
            for (int rzad = 0; rzad < 3; rzad++)
            {
                for (int kolumna = 0; kolumna < 3; kolumna++)
                {
                    plansza[rzad, kolumna] = "0";
                }
            }
            pokazPlansze();
        }
        private static void pokazPlansze()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("  | 1  2  3 ");
            Console.WriteLine("------------");
            Console.ForegroundColor = ConsoleColor.White;
            for (int rzad = 0; rzad < 3; rzad++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write((rzad + 1).ToString() + " |");
                Console.ForegroundColor = ConsoleColor.White;
                for (int kolumna = 0; kolumna < 3; kolumna++)
                {
                    switch (plansza[rzad, kolumna])
                    {
                        case "0":
                            Console.Write(" - ");
                            break;
                        case "X":
                            Console.Write(" X ");
                            break;                      
                        case "O":
                            Console.Write(" O ");
                            break;

                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("------------");
        }
        }
    }
