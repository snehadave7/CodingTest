using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Exceptions {
    internal class AdoptionException {
      
    }
}

namespace exception.Exceptions {
    internal class ProductAlreadyExistException : ApplicationException { 
        public ProductAlreadyExistException() { }
        public ProductAlreadyExistException(string message) : base(message) { }
    }
}