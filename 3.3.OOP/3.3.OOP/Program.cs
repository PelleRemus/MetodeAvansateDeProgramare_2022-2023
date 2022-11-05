using System;
using System.Linq;

namespace _3._3.OOP
{
    static class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            Animal amiba = new Animal("amiba", "albastra");
            Console.WriteLine(amiba.GetSpecia());

            while(amiba.Varsta < 20)
            {
                Console.WriteLine($"---------- ziua {amiba.Varsta} ------------");
                bool gasesteMancare = random.Next(2) == 1;
                if (gasesteMancare)
                {
                    double valoareMancare = random.NextDouble() * 0.3 + 0.1;
                    amiba.Hranire(valoareMancare);
                }

                amiba.Imbatranire(1);
                if (amiba.NivelDeEnergie <= 0)
                    break;
            }
            Console.WriteLine($"{amiba.GetSpecia()} a murit dupa {amiba.Varsta} zile");



            Animal caine = new Caine("labrador", "golden", 'M', 4, "Marcel");
            (caine as Caine).Latra();

            caine.Imbatranire(1);
            Console.WriteLine(caine.Varsta);



            // Extension Methods
            string propozitie = "Ana are mere.";
            // string[] cuvinte = ToWords(propozitie);
            string[] cuvinte = propozitie.ToWords();
            foreach(string cuvant in cuvinte)
                Console.WriteLine(cuvant);



            // Generice
            Zoo zoo = new Zoo();
            Habitat<Animal> habitatCaini = new Habitat<Animal>();
            habitatCaini.locuitori.Add(caine);

            Caine caine2 = new Caine("labrador", "golden", 'F', 4, "Marcel");
            habitatCaini.locuitori.Add(caine2);
            zoo.habitate.Add(habitatCaini);
        }

        public static string[] ToWords(this string sentence)
        {
            return sentence
                    .Split(' ', '.', ',', ';', '!', '?')
                    .Where(x => !string.IsNullOrEmpty(x))
                    .ToArray();
        }

        // Generice
        public static void Vaneaza<T>(T vanator, Animal prada)
            where T: Mamifer
        {
            if (random.Next(4) != 0)
                vanator.Mananca(prada);
        }
    }
}
