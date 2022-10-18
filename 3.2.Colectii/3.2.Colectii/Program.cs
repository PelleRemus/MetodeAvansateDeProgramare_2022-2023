using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._2.Colectii
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            // Arrays
            //
            int[] array;            // declarare
            array = new int[100];   // initializare
            int[] array2 = new int[100]; // 2 in 1
            int[] array3 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }; // inline initialization

            // atribuire de valori in array
            for (int i = 0; i < 100; i++)
                array[i] = 2 * (i + 1);

            // afisare
            for(int i=0; i<100; i++)
                Console.Write($"{array[i]} ");
            Console.WriteLine();

            foreach(int value in array2)
                Console.Write($"{value} ");
            Console.WriteLine();

            for(int i=0; i<array3.Length; i++)
                Console.Write($"{array3[i]} ");
            Console.WriteLine();


            //
            // Matrici
            //
            int n = 10;
            int[,] matrix = new int[n, n];
            int[,] matrix2 = new int[,]
            {
                { 10, 2, 3, 4 },
                { 5, 6, 7, 80 },
                { 900, 10, 110, 120 }
            };

            // Afisare
            for (int i = 0; i < matrix2.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                    Console.Write($"{matrix2[i, j]}\t");
                Console.WriteLine();
            }
            Console.WriteLine();


            //
            // Stringuri
            //
            string text = "string simplu";
            string speciale = "\"UOradea\"\n\\\t\t\\ \r";

            // Afisare
            Console.WriteLine(speciale);

            // Metode speciale
            // Split
            string fraza = "Am fost acasa. M-am uitat pe YT; a fost interesnat.";
            // split pentru fiecare propozitie: ramanem cu 
            string[] propozitii = fraza.Split(new char[] { '.', ';' }, StringSplitOptions.TrimEntries);
            for(int i=0; i<propozitii.Length; i++)
                Console.WriteLine(propozitii[i]);

            // Substring
            string subtext = text.Substring(7);
            Console.WriteLine(subtext);
            subtext = text.Substring(text.LastIndexOf("s"));
            Console.WriteLine(subtext);

            // String empty
            string empty = "";
            string empty2 = string.Empty; // echivalent cu cel de sus

            // Contains
            Console.WriteLine(text.Contains("string"));
            Console.WriteLine(text.Contains("strong"));

            // Compare
            string string1 = "string1z";
            string string2 = "string2a";

            Console.WriteLine(string2.CompareTo(string1)); // 1
            Console.WriteLine(string1.CompareTo(string2)); // -1
            Console.WriteLine(string1.CompareTo(string1)); // 0
            // in loc sa scrii if(string1 < string2), scrii:
            if (string1.CompareTo(string2) < 0) ;

            // Join
            Console.WriteLine(string.Join('!', propozitii));

            // Search inteligent
            string nume = "Popa Bota";
            string prenume = "Ana-Maria";

            // avem nevoie de toate numele separat
            char[] separatori = new char[] { ' ', '-' };
            string numePrenume = $"{nume} {prenume}";
            string[] toateNumele = numePrenume.Split(separatori);

            // user input; si acesta trebuie separat
            string input = ""; // Console.ReadLine();
            string[] inputs = input.Split(separatori);

            // presupunem ca userul a fost gasit
            bool ok = true;
            for(int i=0; i<inputs.Length; i++)
            {
                // presupunem ca inputul curent nu apare in nume
                bool ok2 = false;
                // si verificam daca apare in vreun nume
                for (int j = 0; j < toateNumele.Length; j++)
                    if (toateNumele[j].ToLower().Contains(inputs[i].ToLower()))
                        ok2 = true;

                // daca inputul curent nu apare in niciun nume, ok va fi false
                // deci presupunerea a fost gresita
                ok = ok && ok2;
            }

            if(ok)
                Console.WriteLine($"User with name {nume} {prenume} found!");
            else
                Console.WriteLine("Did not find anyone");

            //
            // Liste
            //
            List<int> lista = new List<int>();

            // Adaugare
            for (int i = 1; i <= 10; i++)
                lista.Add(i);

            // AddRange
            lista.AddRange(new int[] { 11, 12, 13 });

            // Afisare
            foreach(int value in lista)
                Console.Write($"{value} ");
            Console.WriteLine();

            // Find
            Console.WriteLine(lista.Find(value => value > 8));
            // codul echivalent
            foreach (int value in lista)
                if (value > 8)
                {
                    Console.WriteLine(value);
                    break;
                }

            // FindAll
            var greaterThan8 = lista.FindAll(value => value > 8);
            foreach (int value in greaterThan8)
                Console.Write($"{value} ");
            Console.WriteLine();

            // functii din Linq
            // Any
            Console.WriteLine(lista.Any());
            Console.WriteLine(lista.Any(value => value >= 100));

            // Distinct
            lista.Add(1);
            foreach (int value in lista.Distinct())
                Console.Write($"{value} ");
            Console.WriteLine();

            Console.WriteLine(lista[lista.Count - 1]);

            // Select, Where, OrderBy
            var lowerThan8 = lista
                .Select(x => x - 1)
                .Where(value => value < 8)
                .OrderBy(x => x)
                .ToList();

            foreach (int value in lowerThan8)
                Console.Write($"{value} ");
            Console.WriteLine();

            // Skip, Take
            int pageSize = 5;
            int pageNumber = 2;

            var pageTwo = lista.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            foreach (int value in pageTwo)
                Console.Write($"{value} ");
            Console.WriteLine();

            // Alte colectii
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary["dog"] = "a faithful pet";
            Console.WriteLine(dictionary["dog"]);
        }
    }
}
