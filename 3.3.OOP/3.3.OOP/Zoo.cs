using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._3.OOP
{
    // Generice
    class Zoo
    {
        public List<Habitat<Animal>> habitate;

        public Zoo()
        {
            habitate = new List<Habitat<Animal>>();
        }
    }
}
