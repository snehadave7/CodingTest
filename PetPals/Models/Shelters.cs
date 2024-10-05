using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Models {
    internal class Shelters {
        
        public int ShelterId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public Shelters()
        {
            
        }
        public Shelters(int ShelterId, string Name, string Location)
        {
            this.ShelterId = ShelterId;
            this.Name = Name;
            this.Location = Location;

        }

        public override string ToString() {
            return $"ShelterId: {ShelterId} Name: {Name} Location: {Location}";
        }
    }
}
