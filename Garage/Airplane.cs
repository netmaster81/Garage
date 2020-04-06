using System;
namespace Garage
{
    public class Airplane : Vehicle
    {
        //public static int AirPlaneNumbers=0;
        public int NumberOfSeat { get; set; }
        public int NumberOfEngine { get; set; }

        public Airplane()
        {
            TypeName = "Airplane";
            //AirPlaneNumbers++;
            //TotalNumber++;
        }
        public override string ToString => base.ToString + 
                                            $"\nSeat#       :{NumberOfSeat}  Engine# :{NumberOfEngine}";
        

       

    }
}