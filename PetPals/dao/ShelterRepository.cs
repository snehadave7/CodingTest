using CrimeReportingSystem.Util;
using PetPals.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.dao {
    internal class ShelterRepository:IShelters {
        SqlCommand command = null;

        public ShelterRepository() {
            command = new SqlCommand();
        }

        public List<Shelters> GetAllShelters() {
            List<Shelters> Shelter = new List<Shelters>();



            using (SqlConnection connection = new SqlConnection(DBConnUtil.GetConnectionString())) {
                command.CommandText = "SELECT * FROM Shelters";
                command.Connection = connection;
                try {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            Shelters shelter = new Shelters();
                            shelter.ShelterId = (int)reader["ShelterId"];
                            shelter.Name = (string)reader["Name"];
                            shelter.Location = (string)reader["Loaction"];



                            Shelter.Add(shelter);

                        }
                    }

                    return Shelter;
                }
                catch (Exception ex) {
                    Console.WriteLine("Database Connection failed");
                    return null;
                }
            }
        }
            public void AddPet(Pets pets,int shelterId) {
            string query = "INSERT INTO Pets(PetName,PetAge,PetBreed,Type,ShelterId)" +
                            "VALUES(@PetName,@PetAge,@PetBreed,@Type,@ShelterId)";

            bool AvailableForAdoption = true;
            using (SqlConnection connection = new SqlConnection(DBConnUtil.GetConnectionString())) {
                command.CommandText = query;
                command.Connection = connection;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@PetName",pets.Petname );
                command.Parameters.AddWithValue("@PetAge", pets.Petage);
                command.Parameters.AddWithValue("@PetBreed", pets.Petbreed);
                command.Parameters.AddWithValue("@Type",pets.Type );
                command.Parameters.AddWithValue("@ShelterId",shelterId);
                command.Parameters.AddWithValue("@AvailableForAdoption", AvailableForAdoption);

                try {
                    connection.Open();


                    int input = command.ExecuteNonQuery();
                    if (input > 0) {

                        Console.WriteLine("New Pet Added Successfully...");
                    }
                    else {
                        throw new NotImplementedException();

                    }
                }
                catch (Exception ex) {
                    Console.WriteLine("Database Connection failed");
                }

            }
        }

        public List<Pets> GetAvailablePets() {
            
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

               

               
            
    }
}
