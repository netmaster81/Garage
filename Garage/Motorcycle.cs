using System;
namespace Garage
{
    internal class Motorcycle : Vehicle
    {
        public int MotorCylinderNumber { get; set; }
        public Motorcycle()
        {
            TypeName = "Motorcycle";
        }
        public override string ToString => base.ToString +
                                            $"\nMotorCylinder#:{MotorCylinderNumber}  ";
       

    }
}