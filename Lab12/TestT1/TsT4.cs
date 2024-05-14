using T4;
using VehicleLibrary1;


namespace TestT1
{
    [TestClass]
    public class TsT4
    {
        [TestMethod]
        public void Add()
        {
            MyCollection<Vehicle> myCollection = new MyCollection<Vehicle>();

            Vehicle car = new Vehicle();
            myCollection.Add(car);

            Assert.IsTrue(myCollection.Contains(car));
        }

        [TestMethod]
        public void Contains()
        {
            MyCollection<Vehicle> myCollection = new MyCollection<Vehicle>();

            Vehicle car = new Vehicle();
            myCollection.Add(car);
            bool result = myCollection.Contains(car);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Remove()
        {
            MyCollection<Vehicle> myCollection = new MyCollection<Vehicle>();
            Vehicle car = new Vehicle();

            myCollection.Add(car);

            myCollection.Remove(car);

            Assert.IsFalse(myCollection.Contains(car));
        }

        [TestMethod]
        public void GetEnumerator()
        {
            MyCollection<Vehicle> myCollection = new MyCollection<Vehicle>();
            Vehicle car1 = new Vehicle();
            Vehicle car2 = new Vehicle();
            myCollection.Add(car1);
            myCollection.Add(car2);
            Vehicle[] expectedObjects = { car1, car2 };

            int index = 0;
            foreach (Vehicle item in myCollection)
            {
                Assert.AreEqual(expectedObjects[index], item);
                index++;
            }
        }

        [TestMethod]
        public void Clear()
        {
            MyCollection<Vehicle> myCollection = new MyCollection<Vehicle>();
            Vehicle car1 = new Vehicle();
            Vehicle car2 = new Vehicle();
            myCollection.Add(car1);
            myCollection.Add(car2);

            myCollection.Clear();

            Assert.AreEqual(0, myCollection.Count);
        }

        [TestMethod]
        public void CopyTo()
        {
            MyCollection<Vehicle> myCollection = new MyCollection<Vehicle>();
            Vehicle car1 = new Vehicle();
            Vehicle car2 = new Vehicle();
            myCollection.Add(car1);
            myCollection.Add(car2);
            Vehicle[] targetArray = new Vehicle[2];

            myCollection.CopyTo(targetArray, 0);

            Assert.AreEqual(car1, targetArray[0]);
            Assert.AreEqual(car2, targetArray[1]);
        }

        [TestMethod]
        public void RemoveRange()
        {
            MyCollection<Vehicle> myCollection = new MyCollection<Vehicle>();
            Vehicle car1 = new Vehicle();
            Vehicle car2 = new Vehicle();
            Vehicle[] itemsToAdd = { car1, car2 };
            myCollection.AddRange(itemsToAdd);

            Vehicle[] itemsToRemove = { car1, car2 };

            int removedCount = myCollection.RemoveRange(itemsToRemove);

            Assert.AreEqual(itemsToRemove.Length, removedCount);
            foreach (Vehicle item in itemsToRemove)
            {
                Assert.IsFalse(myCollection.Contains(item), $"Item {item} was not removed");
            }
        }

        [TestMethod]
        public void ShallowClone_CreatesShallowCopy()
        {
            Vehicle item1 = new Vehicle();
            Vehicle item2 = new Vehicle();
            MyCollection<Vehicle> original = new MyCollection<Vehicle>();
            original.Add(item1);
            original.Add(item2);

            MyCollection<Vehicle> clone = original.ShallowClone();

            Assert.AreNotSame(original, clone);
            //Assert.AreSame(original.positions, clone.positions);
        }
    }
}
