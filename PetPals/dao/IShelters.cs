using PetPals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.dao {
    internal interface IShelters {
        public void AddPet(Pets pets,int shelterId);
        
        public List<Pets> GetAvailablePets();
        public List<Shelters> GetAllShelters();
    }
}
