using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._3.OOP
{
    // Generice: Habitat pentru un singur tip de animale
    class Habitat<T>
        where T: Animal
    {
        public List<T> locuitori;

        public Habitat()
        {
            locuitori = new List<T>();
        }
    }
}
