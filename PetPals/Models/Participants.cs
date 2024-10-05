using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Models {
    internal class Participants {

        public int ParticipantId { get; set; }
        public string ParticipantName { get; set; }
        public string ParticipantType { get; set; }
        public int EventId { get; set; }

        public Participants()
        {
            
        }
        public Participants( string ParticipantName, string ParticipantType)
        {
            
            this.ParticipantName = ParticipantName;
            this.ParticipantType = ParticipantType;
            
        }

        public override string ToString() {
            return $"ParticipantId: {ParticipantId} ParticipantName: {ParticipantName} ParticipantType: {ParticipantType} EventId: {EventId}";
        }
    }
}
