using System;
using System.Collections.Generic;
using System.Text;

namespace Garage
{
    public static class UI
    {
        public static void Print(this Vehicle v) => Console.WriteLine(v.ToString 
                                             +"\n___________________________________________");
        public static void AddVehicleMenu()
        {
            Console.Clear();
            Console.WriteLine("For adding a new vehicle please choose by number"
                                + "\n Enter the number type of vehicle:");
            Console.WriteLine("1-Airplane:" + "\n2-Boat:" + "\n3-Bus:"
                                +"\n4-car:" + "\n5-Motorcycle");
        }
        public static int InputIsInteger()
        {
            int input;
            string inputstring;
            do
            {
                Console.WriteLine("Please Enter a number:");
                inputstring = Console.ReadLine();

            } while (!int.TryParse(inputstring, out input));
            return input;
        }
        public static string InputNotEMptyOrNull()
        {
            string stringInput;
            do
            {
                Console.WriteLine("Please Enter a NON null String");
                stringInput = Console.ReadLine();
            } while (string.IsNullOrEmpty(stringInput));
            return stringInput;
        }
        public static void MainMenu(this GaragHandler gh)
        {

            Console.Clear();
            Console.WriteLine($"YOU HAVE CREATED A GARAGE WITH MAX CAPACITY:{gh.Capacity}");
            Console.WriteLine("1-List all parked vehicles:"
                            + "\n2-List vehicle types and how many of each are in the garage: "
                            + "\n3-Adding vehicles from the garage:"
                            + "\n4-Removing vehicles from the garage by RegisterNumber:"
                            + "\n5-Find a specific vehicle through one or more properties:"
                            + "\n6-Please Enter 0 for exit from the program :"
                            );

            int input = InputIsInteger();
            switch (input)
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    do
                    {
                        gh.PrintAll();
                    } while (keepGoingOrGoBackOrexit());
                    gh.MainMenu();
                    break;
                case 2:
                    do
                    {
                        gh.PrintlistNumberOfType();
                    } while (keepGoingOrGoBackOrexit());
                    gh.MainMenu();
                    break;

                case 3:
                    do
                    {
                        gh.AddVehicle();
                    } while (keepGoingOrGoBackOrexit());
                    gh.MainMenu();
                    break;

                case 4:
                    do
                    {
                        Console.WriteLine("Please enter a Registration Number:");
                        string inputString = InputNotEMptyOrNull();
                        var searResult = gh.SearchByRegisterNumber(inputString).ToString();
                        if (searResult != "")
                        {
                            gh.RemoveVehicle(inputString);
                            Console.WriteLine("your Item has been removed!!");
                        }
                        else Console.WriteLine("You enter a wrong Register number:");
                    } while (keepGoingOrGoBackOrexit());
                    gh.MainMenu();
                    break;

                case 5:
                    do
                    {
                        gh.SearchMenu();
                    } while (keepGoingOrGoBackOrexit());
                    gh.MainMenu();
                    break;



            }

        }
        private static bool keepGoingOrGoBackOrexit()
        {
            Console.WriteLine("Repeat task enter '1' Exit '0' MainMenu press any key ");
            
            string input = InputNotEMptyOrNull();
            int x;
            if (int.TryParse(input, out x))
            {
                switch (x)
                {
                    case 1:
                        return true;
                    case 0:
                        Environment.Exit(0);
                        break;
                }
            }
            return false;
        }
        private static void SearchMenu(this GaragHandler gh)
        {
            Console.Clear();
            Console.WriteLine("1-Search by Register Number");
            Console.WriteLine("2-Search by Vehicle Type");
            Console.WriteLine("3-Search by vehicleType,color and wheelNumbe");
            Console.WriteLine("4-Search by color and wheelNumbe");
            Console.WriteLine("Please Enter a number of task ");
            int input = InputIsInteger();
            switch (input)
            {
                case 1:
                    Console.WriteLine("Please inter a Register Number:");
                    string regNum = InputNotEMptyOrNull();
                    var searchResult = gh.SearchByRegisterNumber(regNum);
                    if (searchResult.TypeName=="")
                    {
                        Console.WriteLine("your Item is not Exist");
                    }
                    else Console.WriteLine("your Item is Exist and I will print it :");
                    searchResult.Print();
                    break;
                case 2:
                    Console.WriteLine("please enter a vehicle Type:");
                    string vehType = InputNotEMptyOrNull();
                    var searchResult2 = gh.Search(vehType);
                    if (searchResult2.Count!=0)
                    {
                        Console.WriteLine("your Search Result is :");
                        searchResult2.ForEach(v => v.Print());
                    }
                    else Console.WriteLine("this Item is not Exist");
                    break;
                case 3:
                    Console.WriteLine("please enter a vehicle Type:");
                    vehType = InputNotEMptyOrNull();
                    Console.WriteLine("please enter a color:");
                    string vehColor = InputNotEMptyOrNull();
                    Console.WriteLine("please enter a wheelNumbe:");
                    int vehwheelNumber = InputIsInteger();
                    var searchResult3 = gh.Search(vehType, vehColor, vehwheelNumber);
                    if (searchResult3.Count != 0)
                    {
                        Console.WriteLine("your Search Result is :");
                        searchResult3.ForEach(v => v.Print());
                    }
                    else Console.WriteLine("this Items are not Exist");
                    break;
                case 4:
                    Console.WriteLine("please enter a color:");
                     vehColor = InputNotEMptyOrNull();
                    Console.WriteLine("please enter a wheelNumbe:");
                    vehwheelNumber = InputIsInteger();
                    var searchResult4 = gh.Search(vehColor, vehwheelNumber);
                    if (searchResult4.Count != 0)
                    {
                        Console.WriteLine("your Search Result is :");
                        searchResult4.ForEach(v => v.Print());
                    }
                    else Console.WriteLine("this Items are not Exist");
                    break;

                default:
                    break;
            }

        }
        public static void CheckIfVehickeIsAdded(this Garage<Vehicle> customGarage, Vehicle v)
        {
            if (customGarage.Add(v))
            {
                Console.WriteLine("Congratulation you just Added a new Vehicle");
                v.Print();
            }
            else
            {
                Console.WriteLine("You add an Item has same RegisterNumber for other Item");
                Console.WriteLine("Please try again and be sure to enter Uniq RegNum");
            }
        }
        public static void ConsoleVehicleAdd(this Vehicle v)
        {
            Console.WriteLine("Enter the RegisterNumber: ");
            v.RegisterNumber = InputNotEMptyOrNull();
            
            Console.WriteLine("Enter the NumberOfWheels");
            v.NumberOfWheels = InputIsInteger();

            Console.WriteLine("Enter the Color: ");
            v.Color = InputNotEMptyOrNull();
            switch (v.TypeName)
            {
                case "Airplane":
                    Console.WriteLine("Enter the NumberOfSeat: ");
                    (v as Airplane).NumberOfSeat = InputIsInteger();

                    Console.WriteLine("Enter the NumberOfEngine: ");
                    (v as Airplane).NumberOfEngine = InputIsInteger();
                    break;
                case "Boat":
                    Console.WriteLine("Enter the Lenght of Boat: ");
                    (v as Boat).Length = InputIsInteger();
                    break;
                case "Bus":
                    Console.WriteLine("Enter the NumberOfDoor");
                    (v as Bus).NumberOfDoor = InputIsInteger();
                    break;
                case "Car":
                    Console.WriteLine("Enter the NumberOfDoor");
                    (v as Car).NumberOfDoor = InputIsInteger();
                    break;
                case "Motorcycle":
                    Console.WriteLine("Enter the MotorCylinderNumber");
                    (v as Motorcycle).MotorCylinderNumber = InputIsInteger();
                    break;

            }
        }


    }
}











            


