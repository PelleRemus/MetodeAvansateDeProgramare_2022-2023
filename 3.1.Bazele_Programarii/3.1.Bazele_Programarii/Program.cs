using System;

namespace _3._1.Bazele_Programarii
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Infroduceti un numar n: ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine($"Numarul {n} fara cifre pare este: {EliminareCifrePare(n)}");
            Console.WriteLine();

            Console.WriteLine($"Numarul {n} cu cifrele cerute adaugate este: {Adaugare_MA_IntreCifre(n)}");
            Console.WriteLine();

            AfisareN_DescompusInFactoriPrimi(n);

            // verificati daca n este prim
            if (IsPrime(n))
                Console.WriteLine($"{n} este prim!");
            else
                Console.WriteLine($"{n} NU este prim :(");
        }

        static int EliminareCifrePare(int n)
        {
            int oglindit = 0;

            int x = n; // folosim o variabila auxiliara pentru a nu modifica valoarea lui n
            while (x > 0)
            {
                int c = x % 10;
                x = x / 10;
                if (c % 2 != 0) // daca n este impar, il adaugam la oglindit, deci sarim peste cifrele pare
                    oglindit = oglindit * 10 + c;
            }

            x = Mirror(oglindit);
            return x;
        }

        static int Adaugare_MA_IntreCifre(int n)
        {
            // Adăugați media aritmetică a cifrelor consecutive din n între acestea
            // ex.: 1483 -> 1246853
            int x = n;
            int oglindit = 0;

            while (x > 9)
            {
                int c = x % 10;
                x = x / 10;
                int c2 = x % 10; // penultima cifra a lui n

                oglindit = oglindit * 10 + c;
                oglindit = oglindit * 10 + (c + c2) / 2; // adaugam doua cifre la oglindit: ultima cifra si media aritmetica
            }
            oglindit = oglindit * 10 + x;

            x = Mirror(oglindit);
            return x;
        }

        static void AfisareN_DescompusInFactoriPrimi(int n)
        {
            // scrieti descompurea lui n in factori primi
            int x = n;
            Console.Write($"{n} = ");
            for (int d = 2; d <= x; d++)
                if (x % d == 0)
                {
                    int p = CalculatePower(d, ref x);
                    Console.Write($"{d}^{p}");
                    if(x != 1)
                        Console.Write(" * ");
                }
            Console.WriteLine();
        }

        static bool IsPrime(int n)
        {
            if (n <= 1)
                return false; // daca dovedim ca n nu este prim, punem variabila pe false
            if (n == 2)
                return true;
            if (n % 2 == 0)
                return false;

            // for (int d = 2; d < n; d++) // cel mai ineficient
            // for (int d = 2; d <= n/2; d++) // reducem cu jumatate numarul de parcurgeri
            // for (int d = 2; d <= Math.Sqrt(n); d++) // daca nu am gasit niciun divizor pana la rad(n), nu o sa gasim altii
            // for (int d = 2; d * d <= n; d++) // dar calculul radicalului este ineficient, asa ca vom folosi inecuatia echivalenta
            for (int d = 3; d * d <= n; d += 2) // putem parcurge din 2 in 2 daca am facut deja verificarea cu 2
            {
                if (n % d == 0)
                {
                    return false;
                }
            }
            return true;
        }

        static int Mirror(int n)
        {
            int oglindit = 0;
            while(n > 0)
            {
                int c = n % 10;
                n = n / 10;
                oglindit = oglindit * 10 + c;
            }
            return oglindit;
        }

        static int CalculatePower(int divizor, ref int n)
        {
            int p = 0;
            while (n % divizor == 0)
            {
                p++;
                n = n / divizor;
            }
            return p;
        }
    }
}
