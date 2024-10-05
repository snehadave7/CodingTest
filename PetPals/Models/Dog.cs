using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Models {
    internal class Dog:Pets {
        public string DogBreed { get; set; }
        public Dog(string name,int age,string DogBreed):base(name,age ,DogBreed) {
            this.DogBreed = DogBreed;
        }

        public override string ToString() {
            return $"DogBreed: {DogBreed}";
        }
    }
}
