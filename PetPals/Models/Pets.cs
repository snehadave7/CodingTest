using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Models {
    internal class Pets {
        
        public int PetId { get; set; }
        public string Petname { get; set; }
        public int Petage { get; set; }
        public string Petbreed { get; set; }
        public string Type { get; set; }
        public bool AvailableForAdoption { get; set; }


        public Pets(string Petname,int Petage,string Petbreed)
        {
            
            this.Petname = Petname;
            this.Petage = Petage;
            this.Petbreed = Petbreed;
            
            
        }
        public Pets()
        {
            
        }

        public override string ToString() {
            return $"  Petname: {Petname} Petage: {Petage} Petbreed:{Petbreed}";
        }
    }
}
