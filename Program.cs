using System;

namespace Projekt_MarcinGalica
{
    class Program
    {
        static void Main(string[] args)
        {   
            string nazwaGracza = "";
            bool CzyGraSkonczona = false;

            Console.Write("Podaj nazwe Gracza 1:");
            nazwaGracza = Console.ReadLine();
            Gra gracz1 = new Gra("X", nazwaGracza);
            Console.WriteLine("Podaj nzwe Gracza 2: !Napisz 'komputer' jeśli chcesz grać przeciwko komputerowi!");
            nazwaGracza = Console.ReadLine();
            Gra gracz2 = new Gra("O", nazwaGracza);


            while (!CzyGraSkonczona)
            {
                Gra.inicjacjaPlanszy();
                while(!gracz1.PrzebiegGry() && !gracz2.PrzebiegGry())
                {
                    CzyGraSkonczona = true;
                }
                if (CzyGraSkonczona)
                {
                    if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                    {
                        Console.WriteLine("Gra skończona");
                    } else if (Console.ReadKey(true).Key == ConsoleKey.F1)
                    {
                        CzyGraSkonczona = false;
                    } else
                    {
                        CzyGraSkonczona = false;
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
