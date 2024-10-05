using PetPals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.dao {
    internal interface IAdoptionEvents {
        public void HostEvent();
        public void AddParticipant(Participants participant);
        public List<AdoptionEvents> GetAllAdoption();
    }
}
