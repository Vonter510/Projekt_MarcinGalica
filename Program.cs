using System;

namespace Projekt_MarcinGalica
{
    class Program
    {
        static void Main(string[] args)
        {
            bool start = true;
            string nazwaGracza = "";
            bool CzyGraSkonczona = false;
            while (start)
            {
                Console.WriteLine("Kołko i Krzyżyk");
                Console.WriteLine("Wybierz opcje gry:");
                Console.WriteLine("1 - Gracz vs Gracz");
                Console.WriteLine("2 - Gracz vs Komputer");
                Console.WriteLine("3 - Symulacja --> Komputer vs Komputer");
                Console.WriteLine("4 - Wyłącz program");
                Console.Write("Twój wybór:");
                string wybor = Console.ReadLine();
                switch (wybor)
                {
                    case "1":
                        Console.Write("Podaj nazwe Gracza 1:");
                        nazwaGracza = Console.ReadLine();
                        Gra gracz1 = new Gra("X", nazwaGracza);
                        Console.Write("Podaj nazwe Gracza 2:");
                        nazwaGracza = Console.ReadLine();
                        Gra gracz2 = new Gra("O", nazwaGracza);


                        while (!CzyGraSkonczona)
                        {
                            Gra.inicjacjaPlanszy();
                            while (!gracz1.PrzebiegGry() && !gracz2.PrzebiegGry())
                            {
                                CzyGraSkonczona = true;
                            }
                            if (CzyGraSkonczona)
                            {
                                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                                {
                                    Console.WriteLine("Gra skończona");
                                }
                                else if (Console.ReadKey(true).Key == ConsoleKey.F1)
                                {
                                    CzyGraSkonczona = false;
                                }
                                else
                                {
                                    CzyGraSkonczona = false;
                                }
                            }
                        }
                        Console.Clear();
                        break;
                    case "2":
                        Console.Write("Podaj nazwe Gracza 1:");
                        nazwaGracza = Console.ReadLine();
                        Gra gracz3 = new Gra("X", nazwaGracza);
                        nazwaGracza = "komputer";
                        Gra gracz4 = new Gra("O", nazwaGracza);


                        while (!CzyGraSkonczona)
                        {
                            Gra.inicjacjaPlanszy();
                            while (!gracz3.PrzebiegGry() && !gracz4.PrzebiegGry())
                            {
                                CzyGraSkonczona = true;
                            }
                            if (CzyGraSkonczona)
                            {
                                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                                {
                                    Console.WriteLine("Gra skończona");
                                }
                                else if (Console.ReadKey(true).Key == ConsoleKey.F1)
                                {
                                    CzyGraSkonczona = false;
                                }
                                else
                                {
                                    CzyGraSkonczona = false;
                                }
                            }
                        }
                        Console.Clear();
                        break;
                    case "3":
                        nazwaGracza = "komputer";
                        Gra gracz5 = new Gra("X", nazwaGracza);
                        Gra gracz6 = new Gra("O", nazwaGracza);


                        while (!CzyGraSkonczona)
                        {
                            Gra.inicjacjaPlanszy();
                            while (!gracz5.PrzebiegGry() && !gracz6.PrzebiegGry())
                            {
                                CzyGraSkonczona = true;
                            }
                            if (CzyGraSkonczona)
                            {
                                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                                {
                                    Console.WriteLine("Gra skończona");
                                }
                                else if (Console.ReadKey(true).Key == ConsoleKey.F1)
                                {
                                    CzyGraSkonczona = false;
                                }
                                else
                                {
                                    CzyGraSkonczona = false;
                                }
                            }
                        }
                        Console.Clear();
                        break;
                    case "4":
                        start = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Zła wartość");
                        Console.WriteLine("Wybierz ponownie:");
                        break;
                }
            }

        }
    }
}
