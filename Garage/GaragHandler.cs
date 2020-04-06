using System;
using System.Collections.Generic;
using System.Linq;

namespace Garage
{
    public class GaragHandler
    {
        private Garage<Vehicle> CustomGarage;
        public int Capacity { get; set; }
        public GaragHandler()
        {
                
        }
        public GaragHandler(int capacity)
        {
            CustomGarage = new Garage<Vehicle>();
            Capacity = capacity;
        }
        public void PrintlistNumberOfType()
        {
            
            if (Search("Airplane").Count() != 0) Console.WriteLine($"Airplane: {Search("Airplane").Count()}");
            if (Search("Boat").Count() != 0) Console.WriteLine($"boat: {Search("Boat").Count()}");
            if (Search("Bus").Count() != 0) Console.WriteLine($"bus: {Search("Bus").Count()}");
            if (Search("Car").Count() != 0) Console.WriteLine($"car: {Search("Car").Count()}");
            if (Search("Motorcycle").Count() != 0) Console.WriteLine($"motorcycle: {Search("Motorcycle").Count()}");
        }
        public void PrintAll()
        {
            var orderbytype = CustomGarage.Vehicles.OrderBy(v => v.TypeName).ToList();
            foreach (var item in CustomGarage.Vehicles) item.Print();
           
        }
        public List<Vehicle> Search(string color, int wheelNumber)
        {
            return CustomGarage.Vehicles.Where(v => v.Color == color)
                            .Select(v => v)
                            .Where(vt => vt.NumberOfWheels == wheelNumber)
                            .Select(v => v).ToList();
        }
        public List<Vehicle> Search(string vehicleType, string color, int wheelNumber)
        {
            return CustomGarage.Vehicles.Where(v => v.Color == color)
                            .Select(v => v)
                            .Where(vt => vt.NumberOfWheels == wheelNumber)
                            .Select(v => v)
                            .Where(v => v.TypeName == vehicleType)
                            .Select(v => v).ToList();
        }
        public List<Vehicle> Search(string vehicleType)
        {
            return CustomGarage.Vehicles.Where(v => v.TypeName == vehicleType)
                            .Select(v => v).ToList();
        }
        public Vehicle SearchByRegisterNumber(string regNumb)
        {
            var x = CustomGarage.Vehicles.SingleOrDefault(v => v.RegisterNumber == regNumb.ToUpper());
                            
            return x;

        }
        public void AddVehicle()
        {
            if (CustomGarage.Count() == Capacity)
            {
                Console.WriteLine("your Garage is full you cannot add a new item");
                return;
            }
            UI.AddVehicleMenu();
            int input = UI.InputIsInteger();
            switch (input)
            {
                case 0:
                    return;
                case 1:
                    var airplane = new Airplane();
                    airplane.ConsoleVehicleAdd();
                    CustomGarage.CheckIfVehickeIsAdded(airplane);
                    break;
                case 2:
                    var boat = new Boat();
                    boat.ConsoleVehicleAdd();
                    CustomGarage.CheckIfVehickeIsAdded(boat);
                    break;
                case 3:
                    var bus = new Bus();
                    bus.ConsoleVehicleAdd();
                    CustomGarage.CheckIfVehickeIsAdded(bus);
                    break;
                case 4:
                    var car = new Car();
                    car.ConsoleVehicleAdd();
                    CustomGarage.CheckIfVehickeIsAdded(car);
                    break;
                case 5:
                    var motorcycle = new Motorcycle();
                    motorcycle.ConsoleVehicleAdd();
                    CustomGarage.CheckIfVehickeIsAdded(motorcycle);
                    break;
                   
            }

        }

        public bool RemoveVehicle(string regNum) 
        {
            var itemToRemove = CustomGarage.Vehicles.SingleOrDefault(r => r.RegisterNumber == regNum);
            if (itemToRemove != null)
            {
                CustomGarage.Vehicles.Remove(itemToRemove);
                return true;
            }
            return false;

        }

    }

}
                    

  
        
