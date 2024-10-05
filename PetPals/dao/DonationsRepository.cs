using CrimeReportingSystem.Util;
using PetPals.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.dao {
    internal class DonationsRepository : IDonations {
        SqlCommand command = null;

        public DonationsRepository() {
            command = new SqlCommand();
        }
        public bool CreateDonation(int shelterid, Donations donation, DateTime date) {
            string query = "INSERT INTO Donations(DonorName,DonationType,DonationAmount,DonationDate,ShelterId)" +
                            "VALUES(@DonorName,@DonationType,@DonationAmount,@DonationDate,@ShelterId)";

            string status = "Open";
            string donationType = "Cash";
            using (SqlConnection connection = new SqlConnection(DBConnUtil.GetConnectionString())) {
                command.CommandText = query;
                command.Connection = connection;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@DonorName", donation.DonorName);
           
                command.Parameters.AddWithValue("@DonationType", donationType);
                command.Parameters.AddWithValue("@DonationAmount", donation.Amount);
                command.Parameters.AddWithValue("@DonationDate", date);
                command.Parameters.AddWithValue("@ShelterId", shelterid);


                try {
                    connection.Open();


                    int input = command.ExecuteNonQuery();
                    if (input > 0) {

                        Console.WriteLine("New Donation Added Successfully...");
                        return true;
                    }
                    else {
                        Console.WriteLine("Not added");
                        return false;
                    }
                }
                catch (Exception ex) {
                    Console.WriteLine("Database Connection failed");
                    return false;
                }
            }
        }
    }
}
