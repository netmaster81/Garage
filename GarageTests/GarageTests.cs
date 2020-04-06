using Microsoft.VisualStudio.TestTools.UnitTesting;
using Garage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Garage.Tests
{
    [TestClass()]
    public class GarageTests
    {
        [TestMethod()]
        public void AddTest()
        {
            //Arrange
            var expectedgarage = new Garage<Vehicle>();
            var car = new Car() { RegisterNumber="aaa123"};
            var bus = new Bus() { RegisterNumber="ddd123"};
            var boat = new Boat() { RegisterNumber="ddd123"};
            expectedgarage.Vehicles.Add(car);
            expectedgarage.Vehicles.Add(bus);
            //expectedgarage.Vehicles.Add(boat);
            // Act
            var actgarage = new Garage<Vehicle>();
            actgarage.Add(car);
            actgarage.Add(bus);
            actgarage.Add(boat);

            //Assert
            //CollectionAssert.AreEqual(expectedgarage.Vehicles, actgarage.Vehicles);
            CollectionAssert.AreEqual(expectedgarage.Vehicles, actgarage.Vehicles);

        }

        [TestMethod()]
        public void RemoveTest()
        {
            //Arrange
            var expectedgarage = new Garage<Vehicle>();
            var car = new Car() { RegisterNumber = "aaa123" };
            var bus = new Bus() { RegisterNumber = "ddd123" };
            var boat = new Boat() { RegisterNumber = "eee123" };
            expectedgarage.Vehicles.Add(car);
            expectedgarage.Vehicles.Add(bus);
            expectedgarage.Vehicles.Add(boat);
            expectedgarage.Vehicles.Remove(boat);


            // Act
            var actgarage = new Garage<Vehicle>();
            actgarage.Add(car);
            actgarage.Add(bus);
            actgarage.Add(boat);
            actgarage.Remove(boat);

            //Assert
            
            CollectionAssert.AreEqual(expectedgarage.Vehicles, actgarage.Vehicles);
        }

        [TestMethod()]
        public void GaragVehTypeTest()
        {
            //Arrange
            var expectedgarage = new Garage<Vehicle>();
            var car = new Car() { RegisterNumber = "aaa123" };
            var bus = new Bus() { RegisterNumber = "ddd123" };
            var boat = new Boat() { RegisterNumber = "ccc123" };
            expectedgarage.Vehicles.Add(car);
            expectedgarage.Vehicles.Add(bus);
            expectedgarage.Vehicles.Add(boat);
            var expectedlist = expectedgarage.Vehicles.Select(v => v.TypeName).ToList();

            // Act
            var actlist = expectedgarage.GaragVehType();

            //Assert
            //CollectionAssert.AreEqual(expectedgarage.Vehicles, actgarage.Vehicles);
            CollectionAssert.AreEqual(expectedlist ,actlist);
        }

        [TestMethod()]
        public void PrintTest()
        {
            //Arrange
            var expectedgarage = new Garage<Vehicle>();
            var car = new Car() { RegisterNumber = "aaa123" };
            var bus = new Bus() { RegisterNumber = "ddd123" };
            
            expectedgarage.Vehicles.Add(car);
            expectedgarage.Vehicles.Add(bus);

            string expectedprint = $"Vehicle Type:{car.TypeName} Registration#:{car.RegisterNumber}"
                           + $"\nColor       :{car.Color}    Wheels#      :{car.NumberOfWheels}" +
                           $"\nDoor#:{car.NumberOfDoor}  " + "\n___________________________________________" +
                           $"\nVehicle Type:{bus.TypeName} Registration#:{bus.RegisterNumber}"
                           + $"\nColor       :{bus.Color}    Wheels#      :{bus.NumberOfWheels}"
                           + $"\nSeat#       :{bus.NumberOfSeat}  Door## :{bus.NumberOfDoor}" +
                           "\n___________________________________________";

            //Act

            string act = car.ToString + "\n___________________________________________\n" +
                        bus.ToString + "\n___________________________________________";
            //Assert
            Assert.AreEqual(expectedprint, act);
        }
    }
}