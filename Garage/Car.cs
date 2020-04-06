using System;
namespace Garage
{
    public class Car : Vehicle
    {
        public int NumberOfDoor { get; set; }

        public Car()
        {
            TypeName = "Car";
        }
        public override string ToString => base.ToString +
                                            $"\nDoor#:{NumberOfDoor}  ";
        
        
    }
}