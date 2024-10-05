using PetPals.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Models {
    internal class CashDonation : Donations {
        
            public DateTime DonationDate { get; set; }

            public CashDonation(string donorName, int amount, DateTime donationDate)
                : base(donorName, amount)  
            {
                DonationDate = donationDate;
            }

            public override void RecordDonation(List<Donations> donations) {
                donations.Add(this);  
            }
        }
    

}
