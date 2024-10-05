using PetPals.dao;
using PetPals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.model {
    internal class PetShelter:IAdoptable {
        private String name { get; set; }
        public  List<Pets> availablePets;

        public PetShelter() {
            availablePets = new List<Pets>();
            
        }

        public void AddPet(Pets pet) {
            availablePets.Add(pet);
            Console.WriteLine($"{pet.Petname} has been added to the shelter.");
        }

        public void RemovePet(Pets pet) {
            if (availablePets.Contains(pet)) {
                availablePets.Remove(pet);
                Console.WriteLine($"{pet.Petname} has been adopted and removed from the shelter.");
            }
            else {
                Console.WriteLine($"{pet.Petname} is not in the shelter.");
            }
        }

        public void ListAvailablePets() {
            if (availablePets.Count == 0) {
                Console.WriteLine("No pets are currently available for adoption.");
            }
            else {
                Console.WriteLine("Available pets:");
                foreach (Pets pet in availablePets) {
                    Console.WriteLine($"Name: {pet.Petname}, Age: {pet.Petage}, Breed: {pet.Petbreed}");
                }
            }

        }

        public void Adopt() {
            Console.WriteLine($"{name} has pets you can adopt");
        }

        

    }
}