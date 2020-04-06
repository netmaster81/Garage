using System;
namespace Garage
{
    public class Bus : Vehicle
    {
        public int NumberOfSeat { get; set; }
        public int NumberOfDoor { get; set; }
        public Bus()
        {
            TypeName = "Bus";
        }

        public override string ToString => base.ToString +
                                            $"\nSeat#       :{NumberOfSeat}  Door## :{NumberOfDoor}";  
        
        
    }
}