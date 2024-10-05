using PetPals.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.dao {
    internal interface IDonations {
        public bool CreateDonation(int shelterid, Donations donation, DateTime date);
    }
}
