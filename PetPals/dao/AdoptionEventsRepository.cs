using CrimeReportingSystem.Util;
using PetPals.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.dao {
    internal class AdoptionEventsRepository:IAdoptionEvents {
        SqlCommand command = null;

        public AdoptionEventsRepository() {
            command = new SqlCommand();
        }

        public void AddParticipant(Participants participant) {
            throw new NotImplementedException();
        }

        public List<AdoptionEvents> GetAllAdoption() {
            List<AdoptionEvents> events = new List<AdoptionEvents>();



            using (SqlConnection connection = new SqlConnection(DBConnUtil.GetConnectionString())) {
                command.CommandText = "SELECT * FROM AdoptionEvents";
                command.Connection = connection;
                try {
                    connection.Open();
                    Console.WriteLine("Connection successful!");



                    using (SqlDataReader reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            AdoptionEvents e = new AdoptionEvents();
                            e.Eventname = (string)reader["EventNamne"];
                            e.Eventdate = (DateTime)reader["EventDate"];
                            e.Location = (string)reader["Location"];
                            e.EventId = (int)reader["EventId"];



                            events.Add(e);

                        }
                    }

                    return events;
                }
                catch (Exception ex) {
                    Console.WriteLine("Database Connection failed");
                    return null;
                }
            }
            }

        public void HostEvent() {
            throw new NotImplementedException();
        }
    }
}
