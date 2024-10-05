using PetPals.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Models {
    internal class ItemDonation:Donations {
        public string ItemType { get; set; }

        public ItemDonation(string donorName, decimal amount, string itemType)
            : base(donorName, amount)  
        {
            ItemType = itemType;
        }

        public override void RecordDonation(List<Donations> donations) {
            donations.Add(this); 
        }
    }
}
