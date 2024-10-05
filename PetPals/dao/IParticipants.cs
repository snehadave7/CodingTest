using PetPals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.dao {
    internal interface IParticipants {
        public bool CreateParticipant(Participants participant, int eventId);

    }
}
