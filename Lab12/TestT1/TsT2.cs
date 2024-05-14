using N2;
using VehicleLibrary1;


namespace TestT1
{
    [TestClass]
    public class TsT2
    {
        [TestMethod]
        public void Add()
        {
            HTable<Vehicle> table = new HTable<Vehicle>();
            Vehicle car = new Car();
            car.RandomInit();

            table.Add(car);

            Assert.AreEqual(1, table.count);
        }

        [TestMethod]
        public void FullTable()
        {
            HTable<Vehicle> table = new HTable<Vehicle>();
            for (int i = 0; i < 11; i++)
            {
                Vehicle car = new Car();
                car.RandomInit();
                table.Add(car);
            }

            Assert.ThrowsException<Exception>(() => table.Add(new Car()));
        }
        [TestMethod]
        public void FoundByYear()
        {
            HTable<Vehicle> table = new HTable<Vehicle>();
            Vehicle car = new Car { Year = 2022 };
            table.Add(car);

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            table.SearchByYear(2022);

            string output = stringWriter.ToString().Trim();
            Assert.AreEqual(car.ToString(), output);
        }

        [TestMethod]
        public void NotFoundByYear()
        {
            HTable<Vehicle> table = new HTable<Vehicle>();
            Vehicle car = new Car { Year = 2022 };
            table.Add(car);

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            table.SearchByYear(2023);

            string output = stringWriter.ToString().Trim();
            Assert.AreEqual("Ёлемент с годом выпуска 2023 не найден.", output);
        }

        [TestMethod]
        public void RemoveByYear()
        {
            HTable<Vehicle> table = new HTable<Vehicle>();
            Vehicle car = new Car { Year = 2022 };
            table.Add(car);

            bool removed = table.RemoveByYear(2022);

            Assert.IsTrue(removed);
            Assert.AreEqual(0, table.count);
        }
    }
}
