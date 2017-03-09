using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSH_Zadanko_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string liczba_losowan;
            int liczba_wylosowana;

            Random rand = new Random((int)DateTime.Now.Ticks); // Tworzy liczbe losowa na podstawie liczby sek od 1970... chyba
            int maximum = 0;

            int[] tablica_losowan = new int[20]; // Tworzy tablice 20 elementowa

            Console.Write("Podaj liczbę losowań: ");

            liczba_losowan = Console.ReadLine(); // Wczytuje liczbę losowań z klawiatury
            int X = Int32.Parse(liczba_losowan); // Parsuje / zamienia stringa na inta;
            Console.WriteLine("Liczba losowań " + liczba_losowan);
            Console.WriteLine("");
            System.Threading.Thread.Sleep(2000);

            for (int i = 0; i < X; i++) // Inkrementowanie poszczegolnych elementow tablicy z zakresu 0 do 19 
            {
                liczba_wylosowana = rand.Next(0, 20);  // losuje liczbe od 0 do 19 (bo tyle jest elementow w tablicy)
                tablica_losowan[liczba_wylosowana]++;
            }

            foreach (int wartosc in tablica_losowan)  // Petla Sprawdzajaca maksymalna liczbe w tablicy 
            {
                if (wartosc > maximum)
                {
                    maximum = wartosc;
                }
            }
            int licznik = 0;  // Powinno Być Ok
            foreach (float wartosc in tablica_losowan)
            {
                Console.BackgroundColor = ConsoleColor.Black; // Ustawia domyslny kolor tla na czarny
                Console.Write("|{0,2}|{1,4}|{2,5:F2}|", licznik, wartosc, (float)wartosc / maximum); // 3 Arg.  to normalizacja czyli wartosc przez najwieksza wartosc w tablicy

                int pomocnicza = 0;

                for (float j = 0; j < (float)(wartosc / maximum) * 60; j++)  // Petla sprawdzajaca ile razy ma sie narysowac # na podstawie wartosci znormalizowanej przy maks 60-ciu #
                {

                    if (j <= 20)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                    }
                    else if (j <= 40)
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                    }
                    else if (j <= 60)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }
                    Console.Write("#");
                    pomocnicza++;
                }

                while(pomocnicza < 60) // Odpowiedzialna za niebieskie tlo
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.Write(" ");
                    pomocnicza++;
                }

                licznik++;
                Console.WriteLine("");
            }
            Console.ReadLine();
        }
    }
}
