using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Exceptions {
    internal class InvalidAge:ApplicationException {
        public InvalidAge()
        {
            
            
        }
        public InvalidAge(string message):base(message)
        {
            
        }

    }
}
