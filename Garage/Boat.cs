using System;
namespace Garage
{
    public class Boat : Vehicle
    {
        public int Length { get; set; }
        public Boat()
        {
            TypeName = "Boat";
        }

        public override string ToString => base.ToString +
                                            $"\n Length#:{Length}  ";
        
        

    }
}