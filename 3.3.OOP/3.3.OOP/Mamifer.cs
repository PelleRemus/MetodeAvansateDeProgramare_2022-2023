using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._3.OOP
{
    // Mostenire
    class Mamifer : Animal
    {
        public char Gen { get; set; }
        public int NrMembre { get; set; }

        // Mostenire: apelam constructorul clasei de baza folosind cuv cheie base
        public Mamifer(string specia, string culoare, char gen, int nrMembre)
            : base(specia, culoare)
        {
            Gen = gen;
            NrMembre = nrMembre;
        }

        public void Mananca(Animal prada)
        {
            Hranire(prada.NivelDeEnergie);
        }
    }
}
