using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Exceptions {
    internal class InsuffFundException:ApplicationException {
        public InsuffFundException()
        {
            
        }
        public InsuffFundException(string message):base(message)
        {
            
        }
    }
}
