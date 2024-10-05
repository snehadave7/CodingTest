using PetPals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.dao {
    internal interface IPets {

        public List<Pets> GetAllPets();
    }
}
