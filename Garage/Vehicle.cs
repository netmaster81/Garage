using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Garage
{
    public abstract class Vehicle
    {
        //public static int TotalNumber=0;
        private string registerNumber;
        public string RegisterNumber
        {
            get { return registerNumber; } 
            set
            { registerNumber = value.ToUpper(); } 
        }
        public string Color { get; set; }
        public int NumberOfWheels { get; set; }
        public string TypeName { get; set; }
        public Vehicle()
        {

        }
        public Vehicle(string registerNumbe, string color, int numberOfWheels)
        {
            RegisterNumber = registerNumbe; Color = color; NumberOfWheels = numberOfWheels;
        }
        public new virtual string ToString => $"Vehicle Type:{TypeName} Registration#:{registerNumber}"
                           + $"\nColor       :{Color}    Wheels#      :{NumberOfWheels}";
        

       
    }
}
        


        
