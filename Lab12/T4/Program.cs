using VehicleLibrary1;
using System;
using T4;

namespace Task4
{
    internal class Program
    {
        static Vehicle CreateObject()
        {
            Random rand = new Random();
            int answ = rand.Next(1, 4);
            Vehicle car;
            if (answ == 1)
                car = new Car();
            else if (answ == 2)
                car = new SUV();
            else
                car = new Truck();
            car.RandomInit();
            return car;
        }

        static void Main(string[] args)
        {
            bool isSucceed;
            int answ;
            MyCollection<Vehicle> table = new MyCollection<Vehicle>();
            do
            {
                Console.WriteLine("1.Добавить один элемент");
                Console.WriteLine("2.Добавить много элементов");
                Console.WriteLine("3.Вывести");
                Console.WriteLine("4.Удалить авто");
                Console.WriteLine("5.Клонировать таблицу");
                Console.WriteLine("6.Очистить таблицу");
                Console.WriteLine("7.Завершить работу");
                do
                {
                    string tmp = Console.ReadLine();
                    isSucceed = int.TryParse(tmp, out answ);
                    if (!isSucceed)
                    {
                        Console.WriteLine("Неверный ввод.Попробуйте еще раз.");
                    }
                } while (!isSucceed);
                switch (answ)
                {
                    case 1:
                        {
                            Vehicle car = CreateObject();
                            table.Add(car);
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Введите кол-во");
                            int count = int.Parse(Console.ReadLine());

                            List<Vehicle> list = new List<Vehicle>();
                            for (int i = 0; i < count; i++)
                            {
                                list.Add(CreateObject());
                            }
                            table.AddRange(list);
                            break;
                        }
                    case 3:
                        {
                            table.Show();
                            break;
                        }
                    case 4:
                        {
                            Vehicle car = CreateObject();
                            if (table.Remove(car))
                                Console.WriteLine("Машина успешно удалена");
                            else
                                Console.WriteLine("Нет такой машины");
                            break;
                        }
                    case 5:
                        {
                            MyCollection<Vehicle> clonedTable = table.DeepClone();
                            Console.WriteLine("Клонированная таблица:");
                            clonedTable.Show();
                            break;
                        }
                    case 6:
                        {
                            table.Clear();
                            Console.WriteLine("Таблица очищена");
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine("Завершение работы");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Неверный ввод");
                            break;
                        }
                }
            } while (answ != 7);
        }
    } 
}