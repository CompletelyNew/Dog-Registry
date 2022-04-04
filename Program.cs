using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace DogRegistry
{
    class Program
    {
        static void Main(string[] args)
        {

            Dog add = new Dog();
            Dog update = new Dog();
            Dog delete = new Dog();
            Dog search = new Dog();
            Dog list = new Dog();
            
                                 
            bool continueToRegister = true;
            bool loggedIn = false;

            if (loggedIn == false)
            {
                Console.Write("Please Enter User name: ");
                string username = Console.ReadLine();
                Console.Write("Please Enter Password: ");
                string password = Console.ReadLine();

                Authentication L = new Authentication();

                bool result = L.Login(username, password);
                if (result == false)
                {
                    Console.WriteLine("Invalid entry!");
                }
                else
                {
                    loggedIn = true;
                }
            
            
                while (continueToRegister)       //use while loop to implement menu options
                {
                    Console.WriteLine();
                    Console.WriteLine("**********Welcome to the Dog Registry**********"); //C.R.U.D. menu
                    Console.WriteLine();
                    Console.WriteLine("");
                    Console.WriteLine("1) Add an Entry To the Registry ");
                    Console.WriteLine("2) Update the Registry ");
                    Console.WriteLine("3) Delete an Entry From the Registry");
                    Console.WriteLine("4) Search the Registry");
                    Console.WriteLine("5) Print Registry Account Information");
                    Console.WriteLine("6) Exit");

                    Console.WriteLine();
                        try
                        {
                            int option = Convert.ToInt32(Console.ReadLine());

                            switch (option)
                            {

                                case 1:
                                    #region Add a Dog to the Registry
                                    Console.Write("Please Enter Name: ");
                                    string name = Console.ReadLine();

                                    Console.Write("Please Enter Breed: ");
                                    string breed = Console.ReadLine();

                                    Console.Write("Please Enter Age: ");
                                    int age = Convert.ToInt32(Console.ReadLine());

                                    Console.Write("Please Enter Weight: ");
                                    int weight = Convert.ToInt32(Console.ReadLine());

                                    Console.Write("Please enter the Dog's Hobbies: ");
                                    string hobbies = Console.ReadLine();

                                    Console.Write("Please enter the Gender (M/F): ");
                                    string gender = Console.ReadLine();

                                    //create objects to call AddDog()
                                    Dog registeredDog = new Dog();
                                    registeredDog.Name = name;
                                    registeredDog.Breed = breed;
                                    registeredDog.Age = age;
                                    registeredDog.Weight = weight;
                                    registeredDog.Hobbies = hobbies;
                                    registeredDog.Gender = gender;

                                    Console.WriteLine(add.AddDog(registeredDog)); //call the AddDog() using the parameter(registeredDog) to print DB details
                                    break;
                                #endregion

                                #region Update the Registry
                                case 2:
                                    Console.Write("Please Enter Name: ");
                                    string name2 = Console.ReadLine();

                                    Console.Write("Please enter Id: ");
                                    int Id2 = Convert.ToInt32(Console.ReadLine());

                                    Console.Write("Please Enter Breed: ");
                                    string breed2 = Console.ReadLine();

                                    Console.Write("Please Enter Age: ");
                                    int age2 = Convert.ToInt32(Console.ReadLine());

                                    Console.Write("Please Enter Weight: ");
                                    int weight2 = Convert.ToInt32(Console.ReadLine());

                                    Console.Write("Please enter the Dog's Hobbies: ");
                                    string hobbies2 = Console.ReadLine();

                                    Console.Write("Please enter the Gender (M/F): ");
                                    string gender2 = Console.ReadLine();

                                    //create objects to call UpdateDog()
                                    Dog updateRegistry = new Dog();
                                    updateRegistry.Id = Id2;
                                    updateRegistry.Name = name2;
                                    updateRegistry.Breed = breed2;
                                    updateRegistry.Age = age2;
                                    updateRegistry.Weight = weight2;
                                    updateRegistry.Hobbies = hobbies2;
                                    updateRegistry.Gender = gender2;

                                    Console.WriteLine(update.UpdateDog(updateRegistry));
                                    break;
                                #endregion

                                #region Delete an Entry From the Registry
                                case 3:
                                    Console.Write("Please Enter Registry Id to Delete: ");
                                    int dId = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine(delete.deleteDog(dId));
                                    break;
                                #endregion

                                #region Search the Registry 
                                case 4:
                                    Console.Write("Please Enter Registry Id to Search For Dog: ");
                                    int sId = Convert.ToInt32(Console.ReadLine());
                                    Dog s = search.getID(sId);
                                    Console.WriteLine("ID: " + s.Id);
                                    Console.WriteLine("Name: " + s.Name);
                                    Console.WriteLine("Breed: " + s.Breed);
                                    Console.WriteLine("Age: " + s.Age);
                                    Console.WriteLine("Weight: " + s.Weight);
                                    Console.WriteLine("Hobbies: " + s.Hobbies);
                                    Console.WriteLine("Gender: " + s.Gender);
                                    break;
                                #endregion

                                #region Display Account Information
                                case 5:
                                    List<Dog> array = list.GetList();
                                    foreach (var detail2 in array)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("Id: " + detail2.Id);
                                        Console.WriteLine("Name: " + detail2.Name);
                                        Console.WriteLine("Breed: " + detail2.Breed);
                                        Console.WriteLine("Age: " + detail2.Age);
                                        Console.WriteLine("Weight: " + detail2.Weight);
                                        Console.WriteLine("Hobbies: " + detail2.Hobbies);
                                        Console.WriteLine("Gender: " + detail2.Gender);
                                    }
                                    break;
                                #endregion

                                #region
                                case 6:
                                    continueToRegister = false;
                                    loggedIn = false;
                                    break;
                                #endregion

                                #region User Input Error
                                default:
                                    Console.WriteLine("Invalid Input. Please Enter a number from the menu");
                                    break;
                                    #endregion

                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.WriteLine("Please enter a number from the menu");
                        }

                }

            }



        }
    }
}
