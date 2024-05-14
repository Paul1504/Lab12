using System;
using VehicleLibrary1;
using Lab12;
using T1;

namespace TestT1
{
    [TestClass]
    public class TsT1
    {

        [TestMethod]
        public void MakeList()
        {
            DoublyLinkedList<Vehicle> list = new DoublyLinkedList<Vehicle>();

            Point<Vehicle> currentPoint = DoublyLinkedList<Vehicle>.MakeList<Car, SUV, Truck>(3);

            Assert.IsNotNull(currentPoint);
            Assert.IsNotNull(currentPoint.Next);
        }

        [TestMethod]
        public void AddElement()
        {
            DoublyLinkedList<Vehicle> list = new DoublyLinkedList<Vehicle>();
            Car car = new Car();
            Point<Vehicle> beg = DoublyLinkedList<Vehicle>.MakePoint(car);

            list.AddElement(beg);

            Assert.IsNotNull(beg.Next);
        }
        [TestMethod]
        public void RemoveElement()
        {
            Point<Vehicle> currentPoint = new Point<Vehicle>(new Vehicle());
            currentPoint.Next = new Point<Vehicle>(new Vehicle());
            currentPoint.Next.Pred = currentPoint;
            int year = 2001;

            Point<Vehicle> result = DoublyLinkedList<Vehicle>.RemoveElement(currentPoint, year);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CopyList()
        {
            DoublyLinkedList<Vehicle> list = new DoublyLinkedList<Vehicle>();
            Car car = new Car();
            Point<Vehicle> beg = DoublyLinkedList<Vehicle>.MakePoint(car);

            Point<Vehicle> newBeg = list.CopyList(beg);

            Assert.AreEqual(car, newBeg.Data);
        }
    }
    
}
