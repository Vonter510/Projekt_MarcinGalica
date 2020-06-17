using System;

namespace Projekt_MarcinGalica
{
    class Program
    {
        static void Main(string[] args)
        {
            string nazwaGracza = "";
            bool gameOver = false;

            Console.Write("Podaj nazwe Gracza 1:");
            nazwaGracza = Console.ReadLine();
            Gra gracz1 = new Gra(1, nazwaGracza);
            Console.WriteLine("Podaj nzwe Gracza 2: !Napisz 'komputer' jeśli chcesz grać przeciwko komputerowi!");
            nazwaGracza = Console.ReadLine();
            Gra gracz2 = new Gra(2, nazwaGracza);

            while (!gameOver)
            {
                Gra.inicjacjaPlanszy();
                while(!gracz1.PrzebiegGry() && !gracz2.PrzebiegGry())
                {
                    gameOver = true;
                }
                if (gameOver)
                {
                    Console.WriteLine("Chcesz zagracz ponownie?");
                    if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                    {
                        Console.WriteLine("Gra skończona");
                    }
                    else gameOver = false;
                }
            }
            Console.ReadLine();
        }
    }
}
