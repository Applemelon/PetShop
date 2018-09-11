using PetShop.Core.Entity;
using PetShop.Core.UIService;
using PetShopApp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace PetShopApp
{
    public class Printer: IPrinter
    {
        readonly IPetService petService;
        readonly PrintExpressions pExp;

        public Printer(IPetService paraPetService)
        {
            petService = paraPetService;
            pExp = new PrintExpressions();
        }

        void PL(string message)
        {
            Console.WriteLine(message);
        }

        void P(string message)
        {
            Console.Write(message);
        }

        String R()
        {
            return Console.ReadLine();
        }

        public void MainMenu()
        {
            pExp.Intro();

            while(true)
            {
                pExp.PMain();

                string choice = R();

                switch (WhileParseInt(choice, "Please input a number between 0 and 4.", 4, 0))
                {
                    case 1:
                        Create();
                        break;
                    case 2:
                        Read();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        Delete();
                        break;
                    case 0:
                        Environment.Exit(1);
                        break;
                    default:
                        break;
                }
            }
        }

        int WhileParseInt(string choice, string print, int maximum, int minimum)
        {
            while (!int.TryParse(choice, out int parseOutput) || int.Parse(choice) >= maximum + 1 || int.Parse(choice) <= minimum - 1)
            {
                PL(print);
                choice = R();
            }
            return int.Parse(choice);
        }

        void Create()
        {
            PL("");
            PL("Enter the name of the Pet");
            string name = R();

            PL("");
            PL("Enter the number of the type of the Pet");
            PetType type = SelectPetType();

            PL("");
            PL("Enter the birthdate of the Pet");
            DateTime birthday = BirthdayFormat();

            PL("");
            PL("Enter the color of the Pet");
            string color = R();

            PL("");
            PL("Enter the name of the previous owner of the Pet");
            string previousowner = R();

            PL("");
            PL("Enter the price of the Pet");
            double price = ParseToDouble("Your entered value is not a number. Please enter the price of the Pet");

            Pet pet = petService.New(name, type, birthday, color, previousowner, price);

            PL("");
            PL("You have created the following pet:");
            PL("Name: " + name);
            PL("Pet type: " + type.ToString());
            PL("Birth date: " + birthday.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture));
            PL("Color: " + color);
            PL("Previous owner: " + previousowner);
            PL("Price: " + price);
            PL("");
            PL("Do you want to add the Pet to the repository?");
            PL("Enter 1 to add the Pet to the repository");
            PL("Enter 2 to delete the Pet");

            string choice = R();

            switch (WhileParseInt(choice, "Please input a number between 1 and 2.", 2, 1))
            {
                case 1:
                    petService.Create(pet);
                    PL("The Pet has been added to the repository.");
                    break;
                case 2:
                    PL("The Pet has not been added to the repository.");
                    break;
                default:
                    break;
            }
        }

        void Read()
        {
            PL("-----------------------------------");
            PL("Amount of Pet entries: " + petService.GetAll().Count());
            PL("");
            PL("What would you like to do?");
            PL("");
            PL("Enter 1 to find a Pet entry");
            PL("Enter 2 to get a full list of Pet entries");
            PL("Enter 0 to go back");
            PL("");

            var choice = R();

            switch (WhileParseInt(choice, "Please input a number between 0 and 2.", 2, 0))
            {
                case 1:
                    FindPet();
                    break;
                case 2:
                    ListAllPets();

                    PL("");
                    PL("Enter 1 to sort the Pets by price");
                    PL("Enter 0 or 2 to go back");

                    var choice2 = R();

                    switch (WhileParseInt(choice2, "Please input a number between 0 and 2.", 2, 0))
                    {
                        case 1:
                            {
                                ArraySortByPrice();
                                break;
                            }
                        case 2:
                            {
                                break;
                            }
                        case 0:
                            {
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                    break;
                case 0:
                    break;
                default:
                    break;
            }
        }
        void Update()
        {
            List<Pet> list = petService.GetAll();
            PL("");
            ListAllPets();
            PL("");
            PL("Please enter the id of the Pet you would like to update");
            PL("Enter 0 to go back");

            string choice = R();

            switch (WhileParseInt(choice, "Please input a number between 0 and " + (list.Count) + ".", (list.Count), 0))
            {
                case int id:
                    if (id != 0)
                    {
                        UpdateMenu(list.ElementAt(id - 1));
                        break;
                    }
                    else
                    {
                        break;
                    }
            }
        }

        void Delete()
        {
            List<Pet> list = petService.GetAll();
            PL("");
            ListAllPets();
            PL("");
            PL("Enter the id of the Pet you wish to delete from the repository");
            PL("Enter 0 to go back");

            string choice1 = R();

            switch (WhileParseInt(choice1, "Please input a number between 0 and " + (list.Count) + ".", (list.Count), 0))
            {
                case int id1:
                    if (id1 != 0)
                    {
                        PL("Are you sure you want to delete " + petService.GetById(id1) + "?");
                        PL("Enter 1 to delete");
                        PL("Enter 0 or 2 to go back");

                        string choice2 = R();

                        switch (WhileParseInt(choice2, "Please input a number between 0 and 2", 2, 0))
                        {
                            case int id2:
                                if (id2 != 0)
                                {
                                    petService.Delete(id2);
                                    break;
                                }
                                else
                                {
                                    break;
                                }
                        }
                        break;
                    }
                    else
                    {
                        break;
                    }
            }
        }

        PetType SelectPetType()
        {
            List<PetType> list = petService.GetAllTypes();

            for (int i = 0; i < list.Count; i++)
            {
                PetType type = list.ElementAt(i);
                PL("Enter " + (i + 1) + " for " + list.ElementAt(i).ToString());
            }

            string choice = R();

            switch (WhileParseInt(choice, "Please input a number between 0 and " + (list.Count) + ".", (list.Count), 0))
            {
                case int id:
                    if (id != 0)
                    {
                        return list.ElementAt(id - 1);
                    }
                    else
                    {
                        break;
                    }
                default:
            }
            PetType nullType = PetType.NONE;
            return nullType;

        }

        DateTime BirthdayFormat()
        {
            string choice = null;
            int day = WhileParseInt(choice, "Enter the day number: ", 31, 1);

            choice = null;
            int month = WhileParseInt(choice, "Enter the month number: ", 12, 1);

            choice = null;
            int year = WhileParseInt(choice, "Enter the year number: ", 3000, 1);

            DateTime inputtedDate = new DateTime(year, month, day);
            return inputtedDate;
        }

        double ParseToDouble(string print)
        {
            string choice = R();
            double outVal;

            while (!Double.TryParse(choice, out outVal))
            {
                PL(print);
                choice = R();
            }
            return double.Parse(choice);
        }

        int PrintFindCustomeryId()
        {
            Console.WriteLine("Insert Customer Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please insert a number");
            }
            return id;
        }

        void FindPet()
        {
            PL("");
            PL("Enter 1 to find a Pet based on id");
            PL("Enter 2 to find a Pet based on name");
            PL("Enter 3 to find a Pet based on type");
            PL("Enter 4 to find a Pet based on birth date");
            PL("Enter 5 to find a Pet based on sold date");
            PL("Enter 6 to find a Pet based on color");
            PL("Enter 7 to find a Pet based on the previous owner");
            PL("Enter 0 to go back");

            var choice = R();
            List<Pet> list = petService.GetAll();
            List<Pet> results = new List<Pet>();

            switch (WhileParseInt(choice, "Please input a number between 0 and 7.", 7, 0))
            {
                case 1:
                    PL("Enter the id you would like to search on");
                    string item1 = R();
                    foreach (var pet in list)
                    {
                        if (pet.id == int.Parse(item1))
                        {
                            results.Add(pet);
                        }
                    }
                    break;
                case 2:
                    PL("Enter the name you would like to search on");
                    string item2 = R();
                    foreach (var pet in list)
                    {
                        if (pet.name == ("%" + item2 + "%"))
                        {
                            results.Add(pet);
                        }
                    }
                    break;
                case 3:
                    PL("Enter the type you would like to search on");
                    string item3 = R();
                    foreach (var pet in list)
                    {
                        if (pet.type.ToString().ToLower() == item3)
                        {
                            results.Add(pet);
                        }
                    }
                    break;
                case 4:
                    PL("Enter the birth date you would like to search on");
                    DateTime item4 = BirthdayFormat();
                    foreach (var pet in list)
                    {
                        if (pet.birthday == item4) 
                        {
                            results.Add(pet);
                        }
                    }
                    break;
                case 5:
                    PL("Enter the sold date you would like to search on");
                    DateTime item5 = BirthdayFormat();
                    foreach (var pet in list)
                    {
                        if (pet.solddate == item5)
                        {
                            results.Add(pet);
                        }
                    }
                    break;
                case 6:
                    PL("Enter the color you would like to search on");
                    string item6 = R();
                    foreach (var pet in list)
                    {
                        if (pet.color == item6)
                        {
                            results.Add(pet);
                        }
                    }
                    break;
                case 7:
                    PL("Enter the id you would like to search on");
                    string item7 = R();
                    foreach (var pet in list)
                    {
                        if (pet.price == double.Parse(item7))
                        {
                            results.Add(pet);
                        }
                    }
                    break;
                case 0:
                    break;
                default:
                    break;
            }

            PL("");
            PL("Results of the search:");
            if(results.Count != 0)
            {
                foreach (var pet in results)
                {
                    PL(pet.ToString() + "");
                }
            }
            else
            {
                PL("No Pets found :(");
            }
        }

        void ListAllPets()
        {
            List<Pet> list = petService.GetAll();

            foreach (var pet in list)
            {
                PL(pet.ToString() + "");
            }
        }

        void ArraySortByPrice()
        {
            List<Pet> list = petService.GetAll();
            Pet[] pets = new Pet[list.Count];

            for (int i = 0; i < list.Count; i++)
            {
                pets[i] = list.Find(Pet => Pet.id == (i + 1));
            }

            pets = BubbleSort(pets);

            foreach (var pet in pets)
            {
                PL(pet.ToString() + "");
            }
            PL("Press enter to return to main menu");
            R();
        }

        Pet[] BubbleSort(Pet[] pets)
        {
            for (int i = 1; i < pets.Length; i++) // repeat sorting phase N – 1 times
            {
                for (int j = 0; j < pets.Length - i; j++) // sorting phase
                {
                    if (pets[j].price > pets[j + 1].price) // compare elements pair-wise
                    {
                        Pet tmp = pets[j]; // swap element pair
                        pets[j] = pets[j + 1];
                        pets[j + 1] = tmp;
                    }
                }
            }
            return pets;
        }

        void UpdateMenu(Pet pet)
        {
            bool breaking = false;
            while(breaking != true)
            {
                PL("");
                PL(pet.ToString() + "");
                PL("");
                PL("Enter 1 to update name");
                PL("Enter 2 to update type");
                PL("Enter 3 to update birth date");
                PL("Enter 4 to update sold date");
                PL("Enter 5 to update color");
                PL("Enter 6 to update previous owner");
                PL("Enter 7 to update price");
                PL("Enter 0 to go back");

                var choice = R();

                switch (WhileParseInt(choice, "Please input a number between 0 and 7.", 7, 0))
                {
                    case 1:
                        PL("Enter the new name");
                        pet.name = R();
                        break;
                    case 2:
                        PL("Enter the new pet type");
                        pet.type = SelectPetType();
                        break;
                    case 3:
                        PL("Enter the new birth date");
                        pet.birthday = BirthdayFormat();
                        break;
                    case 4:
                        PL("Enter the new sold date");
                        pet.solddate = BirthdayFormat();
                        break;
                    case 5:
                        PL("Enter the new color");
                        pet.color = R();
                        break;
                    case 6:
                        PL("Enter the new previous owner");
                        pet.previousowner = R();
                        break;
                    case 7:
                        PL("Enter the new price");
                        pet.price = ParseToDouble("Please enter a number");
                        break;
                    case 0:
                        breaking = true;
                        break;
                    default:
                        break;
                }
            }
        }

    }
}
