using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public bool PrzebiegGry()
        {
            int rzad = 0;
            int kolumna = 0;

            Random rand1 = new Random();
            Random rand2 = new Random();
            //sprawdzam czy graczem jest komputer
            if(NazwaGracza != "komputer")
            {
                Console.WriteLine("Podaj miejsce w którym chcesz postawic symbol:");
                Console.Write("Podaj rzad:");
                int.TryParse(Console.ReadLine().Trim(), out rzad);
                Console.Write("Podaj kolumne");
                int.TryParse(Console.ReadLine().Trim(), out kolumna);
            }
            else
            {
                rzad = rand1.Next(1, 4);    //komuter losuje rzad
                kolumna = rand2.Next(1, 4);     //komputer losuje kolumne
            }
            while (!sprawdzPlansze(rzad, kolumna))
            {
                if(NazwaGracza != "komputer")
                {
                    Console.WriteLine("Podane kordy są nie poprawne.");
                    Console.WriteLine("Podaj miejsce w którym chcesz postawic symbol:");
                    Console.Write("Podaj rzad:");
                    int.TryParse(Console.ReadLine().Trim(), out rzad);
                    Console.Write("Podaj kolumne");
                    int.TryParse(Console.ReadLine().Trim(), out kolumna);
                }
                else
                {
                    rzad = rand1.Next(1, 4);
                    kolumna = rand2.Next(1, 4);
                }
            }

            plansza[rzad - 1, kolumna - 1] = Gracz;
            pokazPlansze();     //Pokazuje zaktualizowaną plansze

            if (zwyciestwo())
            {
                if(NazwaGracza == ("komputer"))
                {
                    Console.WriteLine("Komputer wygrał!!!");
                }
                else
                {
                    Console.WriteLine("Gratulacje wygrałeś"+NazwaGracza);
                }
                return true;
            }else if (remis())
            {
                Console.WriteLine("!!!REMIS!!!");
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
                    if(plansza[rzad,kolumna] != 1 && plansza[rzad, kolumna] != 2)
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
            if(rzad > 3 || kolumna > 3)
            {
                return false;
            }
            if (plansza[rzad-1, kolumna-1] != 1 && plansza[rzad-1,kolumna-1] != 2)
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
