using CrimeReportingSystem.Util;
using PetPals.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.dao {
    internal class ParticipantsRepository:IParticipants {
        SqlCommand command = null;

        public ParticipantsRepository() {
            command = new SqlCommand();
        }

        public bool CreateParticipant(Participants participant, int eventId) {

            string query = "INSERT INTO Participants(ParticipantName,ParticipantType,EventId)" +
                            "VALUES(@ParticipantName,@ParticipantType,@EventId)";

            string status = "Open";
            string donationType = "Cash";
            using (SqlConnection connection = new SqlConnection(DBConnUtil.GetConnectionString())) {
                command.CommandText = query;
                command.Connection = connection;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@ParticipantName", participant.ParticipantName);
                command.Parameters.AddWithValue("@ParticipantType", participant.ParticipantType);
                
                command.Parameters.AddWithValue("@EventId", eventId);


                try {
                    connection.Open();


                    int input = command.ExecuteNonQuery();
                    if (input > 0) {

                        Console.WriteLine("New Participant Added Successfully...");
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
