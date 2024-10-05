using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Models {
    internal class Cat:Pets {
        public string CatColor { get; set; }
        public Cat(string name, int age, string breed, string CatColor) : base(name, age, breed) { 
        
            this.CatColor = CatColor;
        }

        public override string ToString() {
            return $"CatColor: {CatColor}";
        }
    }
}
