using PetPals.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Models {
    internal class AdoptionEvents {
       

        public int EventId { get; set; }
        public string Eventname { get; set; }
        public DateTime Eventdate { get; set; }
        public string Location { get; set; }

         
        
        public AdoptionEvents(int EventId, string Eventname,DateTime Eventdate, string Location)
        {
            this.EventId = EventId;
            this.Eventname = Eventname;
            this.Eventdate = Eventdate;
            this.Location = Location;
        }

        public override string ToString() {
            return $"EventId: {EventId} Eventname:{Eventname}  Eventdate:{Eventdate}  Location: {Location}";
        }
        public List<IAdoptable> Participants { get; set; }

        public  AdoptionEvents() {
            Participants = new List<IAdoptable>();
        }

        public void RegisterParticipant(IAdoptable participant) {
            Participants.Add(participant);
            Console.WriteLine($"{participant.GetType().Name} has been registered for the adoption event.");
        }

        public void HostEvent() {
            Console.WriteLine("Hosting the adoption event...");

            foreach (var participant in Participants) {
                participant.Adopt();
            }
        }
    }
}
