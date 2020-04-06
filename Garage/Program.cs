using System;

namespace Garage
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
            var newGarage = new GaragHandler(2);
            Console.WriteLine("Please ENter the capacity of the new garage:");
            newGarage.Capacity = UI.InputIsInteger();

            newGarage.MainMenu();
            // if I enter number more than 5 
            
        }
    }
}
