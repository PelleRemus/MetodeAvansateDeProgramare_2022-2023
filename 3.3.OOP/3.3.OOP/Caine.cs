using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._3.OOP
{
    class Caine : Mamifer
    {
        public string Stapan { get; set; }

        public Caine(string specia, string culoare, char gen, int nrMembre, string stapan)
            : base(specia, culoare, gen, nrMembre)
        {
            Stapan = stapan;
        }

        // Polimorfism: ... pentru a suprascrie intr-o clasa derivata
        public override void Hranire(double sursaDeEnergie)
        {
            base.Hranire(sursaDeEnergie * 2);
        }

        // Polimorfism
        public override void Imbatranire(int nrAni)
        {
            if (nrAni < 0)
                return;
            Varsta += nrAni * 7;
            NivelDeEnergie = 0.01;
        }

        public void Latra()
        {
            Console.WriteLine("HAM! HAM! HAM!");
        }
    }
}
