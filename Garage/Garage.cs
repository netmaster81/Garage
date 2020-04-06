using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Garage
{
    public class Garage<T> : IEnumerable<T> where T : Vehicle

    {
        public List<T> Vehicles { get; } // list all Vehicles as a read only prop
        public Garage()
        {
            Vehicles = new List<T>();
        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in Vehicles)
            {
                yield return item;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public List<string> GaragVehType() 
        {
            // it is returned list with all vehicle type
            //for print the result you need to calculate the number of repitation and print the type
            var list = new List<string>();
            foreach (var item in Vehicles)
            {
                list.Add(item.TypeName);
            }
            return list;
        }
        public bool Add(T v)
        {
            
            int uniqReg = Vehicles.Where(v1 => v1.RegisterNumber == v.RegisterNumber)
                                   .Select(v => v).Count();
            if (uniqReg > 0)
            {
                return false;// for uniq Register number
            }
            else 
            {
                Vehicles.Add(v); 
                return true;
            }

        }
        public bool Remove(T v)
        {
            if (Vehicles.Contains(v))
            {
                Vehicles.Remove(v);
                return true;
            }
            return false;
        }
        public int Count() => Vehicles.Count;
        public void Print()
        {
            Vehicles.ForEach(v => v.Print());
            
        }

        

    }
}



        
        

