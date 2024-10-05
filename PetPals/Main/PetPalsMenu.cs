
using Microsoft.VisualBasic.FileIO;
using PetPals.dao;
using PetPals.Exceptions;
using PetPals.model;
using PetPals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Main {
    internal class PetPalsMenu {
        
        public  List<Pets> availablePets = new List<Pets>();
        public PetShelter shelter = new PetShelter();
        Dictionary<string, PetShelter> shelters = new Dictionary<string, PetShelter>();
        PetShelter cityShelter = new PetShelter();
        PetShelter countryShelter = new PetShelter();

        
        Pets dog = new Dog("Buddy", 3,"Large");
        Pets cat = new Cat("Whiskers", 2, "Persian", "White");

        

        IPets _petRepository;
        IShelters _shelterRepository;
        IDonations _donationRepository;
        IAdoptionEvents _adoptionEvents;
        IParticipants _participantsRepository;

        public PetPalsMenu() {
            _petRepository = new PetsRepository();
            _shelterRepository = new ShelterRepository();
            _donationRepository = new DonationsRepository();
            _adoptionEvents = new AdoptionEventsRepository();
            _participantsRepository = new ParticipantsRepository();
        }

        public void Run() {
        MainMenu:
            Console.WriteLine("Welcome to PetPals");
            Console.WriteLine("Enter 1: To view all pets");
            Console.WriteLine("Enter 2: To Record Cash Donation");
            Console.WriteLine("Enter 3: To view details about upcommming adoption events");
            Console.WriteLine("Enter 4: To create a participant");
            Console.WriteLine("Enter 5: To add Pets");
            Console.WriteLine("Enter 6: To remove Pet");
            Console.WriteLine("Enter 7: To show list of available pets");
            Console.WriteLine("Enter 8: To HostEvent");
            Console.WriteLine("");
            int choice = int.Parse(Console.ReadLine());
            switch (choice) {
                case 1:
                    // get all pets
                    List<Pets> pets = _petRepository.GetAllPets();
                    foreach (var pet in pets) {
                        Console.WriteLine(pet);
                    }
                    goto MainMenu;
                    break;
                case 2:
                    int standderedAmount = 10;
                    // get all shelterid
                    List<Shelters> sh = _shelterRepository.GetAllShelters();
                    foreach (var i in sh) {
                        Console.WriteLine(i);
                    }
                    Console.WriteLine("Enter shelterid for donation");
                    int shelterid = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter DonorName");
                    string name = Console.ReadLine();
                    fund: try {
                        Console.WriteLine("enter donation amount");
                        int amount = int.Parse(Console.ReadLine());
                        if (amount < standderedAmount) {
                            throw new InsuffFundException("Funds less than 10Rs cannot be excepted");
                        }
                        DateTime date = DateTime.Now;
                        Donations donations = new CashDonation(name, amount, date);
                        _donationRepository.CreateDonation(shelterid, donations, date); goto MainMenu;
                    }
                    catch(Exception e) {
                        Console.WriteLine(e.Message); goto fund;
                    }

                    

                    break;
                case 3:
                    List<AdoptionEvents> adoption = _adoptionEvents.GetAllAdoption();
                    foreach (var a in adoption) {
                        Console.WriteLine(a);
                    }
                    goto MainMenu;
                    break;
                case 4: Participants:

                    Console.WriteLine("Enter name");
                    string pName = Console.ReadLine();
                    Console.WriteLine("Type: shelter adopter");
                    string type = Console.ReadLine();
                    List<AdoptionEvents> adoption1 = _adoptionEvents.GetAllAdoption();
                    foreach (var a in adoption1) {
                        Console.WriteLine(a);
                    }
                    Console.WriteLine("Enter event id");
                    int eventID = int.Parse(Console.ReadLine());
                    Participants p = new Participants(pName, type);
                    _participantsRepository.CreateParticipant(p, eventID);
                    goto MainMenu;
                    break;
                case 5:
                AddPetMenu:
                    Console.Clear();
                    Console.WriteLine("Add a Pet Menu:");
                    Console.WriteLine("1. Add a Dog");
                    Console.WriteLine("2. Add a Cat");
                    Console.WriteLine("3. Go Back");
                    Console.Write("Select an option: ");
                    string option = Console.ReadLine();
                    switch (option) {
                        case "1":
                            // Take input from the user to add a pet
                            

                        enterage: try {
                                Console.Write("Enter the name of the pet: ");
                                string petname = Console.ReadLine();
                                Console.Write("Enter the age of the pet: ");
                                if (!int.TryParse(Console.ReadLine(), out int age) || age <= 0) {
                                    throw new InvalidAge("Invalid age. Please enter a positive number.");
 
                                }
                                Console.Write("Enter the breed of the pet: ");
                                string breed = Console.ReadLine();

                                Pets newPet = new Pets(petname, age, breed);
                                shelter.AddPet(newPet);

                                Console.WriteLine("Pet added");

                                Console.WriteLine("Enter to continue");
                                Console.ReadKey();
                                goto AddPetMenu;
                            }
                            catch (InvalidAge  ex) {
                                Console.WriteLine(ex.Message); goto enterage;
                            }

                            
                            break;

                        case "2":
                            Console.WriteLine("Add Cat:");

                            // Get cat details from user
                            Console.Write("Enter Cat Name: ");
                            string catname = Console.ReadLine();
                        age: try {
                                Console.WriteLine("Enter catAge");
                                if (!int.TryParse(Console.ReadLine(), out int age) || age <= 0) {
                                    throw new InvalidAge("Invalid age. Please enter a positive number.");

                                }
                                string catbreed = "cat";
                                Console.Write("Enter Cat Color: ");
                                string catColor = Console.ReadLine();
                                Cat newCat = new Cat(catname, age, catbreed, catColor);
                                shelter.AddPet(newCat);
                                Console.WriteLine("Pet added");

                            }

                            catch (InvalidAge ex) {
                                Console.WriteLine(ex.Message); goto enterage;
                            }

                            
                            goto MainMenu;
                            break;
                        case "3":

                            goto MainMenu;
                            return;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            goto AddPetMenu;
                            break;
                    }


                    break;
                case 6:
                    Console.Write("Enter the name of the pet to remove: ");
                    string petNameToRemove = Console.ReadLine();
                    Pets petToRemove = null;

                    foreach (var pet in shelter.availablePets) {
                        if (pet.Petname.Equals(petNameToRemove, StringComparison.OrdinalIgnoreCase)) {
                            petToRemove = pet;
                            break;
                        }
                    }

                    if (petToRemove != null) {
                        shelter.RemovePet(petToRemove);
                    }
                    else {
                        Console.WriteLine("Pet not found.");
                    }


                    goto MainMenu;
                    break;
                case 7:
                    shelter.ListAvailablePets();

                    goto MainMenu;
                    break;
                case 8:
                    List<AdoptionEvents> adoption2 = _adoptionEvents.GetAllAdoption();
                    foreach (var a in adoption2) {
                        Console.WriteLine(a);
                    }
                    goto Participants;
                    break;
                default:
                    Console.WriteLine("Wrong input"); goto MainMenu;
                    break;

            }

        }

        public void AddPet(Pets pet) {
            if (pet == null) {
                throw new ArgumentNullException(nameof(pet), "Cannot add a null pet.");
            }
            availablePets.Add(pet);
            Console.WriteLine($"Pet added to shelter: {pet.ToString()}");
        }
        public void RemovePet(Pets pet) {
            if (pet == null) {
                throw new ArgumentNullException(nameof(pet), "Cannot remove a null pet.");
            }
            if (!availablePets.Contains(pet)) {
                throw new ArgumentException("Pet not found in the shelter.");
            }
            availablePets.Remove(pet);
            Console.WriteLine($"Pet removed from shelter: {pet.ToString()}");
        }

        public void ListAvailablePets() {
            if (availablePets.Count == 0) {
                Console.WriteLine("No pets available in the shelter.");
            }
            else {
                Console.WriteLine("Available Pets in the Shelter:");
                foreach (var pet in availablePets) {
                    Console.WriteLine(pet.ToString());
                }
            }
        }
    }
}