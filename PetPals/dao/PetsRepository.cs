using CrimeReportingSystem.Util;
using PetPals.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.dao {
    internal class PetsRepository : IPets {
        SqlCommand command = null;

        public PetsRepository() {
            command = new SqlCommand();
        }
        public List<Pets> GetAllPets() {
            List<Pets> Pets = new List<Pets>();

           

            using (SqlConnection connection = new SqlConnection(DBConnUtil.GetConnectionString())) {
                command.CommandText = "SELECT * FROM Pets";
                command.Connection = connection;
                try {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            Pets pet = new Pets();
                            pet.PetId = (int)reader["PetId"];
                            pet.Petname = (string)reader["Petname"];
                            pet.Petage = (int)reader["Petage"];
                            pet.Petbreed = (string)reader["Petbreed"];
                            pet.Type = (string)reader["Type"];
                            pet.AvailableForAdoption = (bool)reader["AvailableForAdoption"];


                            Pets.Add(pet);

                        }
                    }

                    return Pets;
                }
                catch (Exception ex) {
                    Console.WriteLine("Database Connection failed");
                    return null;
                }
            }
        }
        public bool DeletePets(int PetId) {
            using (SqlConnection connection = new SqlConnection(DBConnUtil.GetConnectionString())) {
                command.CommandText = "DELETE FROM pets WHERE PetId=@PetId";
                command.Connection = connection;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@PetId", PetId);
                try {
                    connection.Open();

                    int input = command.ExecuteNonQuery();
                    if (input > 0) {
                        
                        Console.WriteLine("Deleted Successfully");
                        return true;
                    }
                    else {
                        return false;
                        
                    }
                }
                catch (Exception ex) {
                    Console.WriteLine("Database Connection failed");
                }
                return false;
            }
        }
        
        
       


            
        
    }
}


