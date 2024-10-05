using PetPals.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Models {
    internal class Adopters : IAdoptable {
        public string Name { get; set; }

        public Adopters(string name) {
            Name = name;
        }

        public void Adopt() {
            Console.WriteLine($"{Name} is looking to adopt a pet.");
        }
    }
}
