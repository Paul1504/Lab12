using VehicleLibrary1;
using System;
using N2;
using System.Collections.Generic;

namespace Lab12
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
        public static void OverFlow(HTable<Vehicle> Htable)
        {
            while (Htable.count < 11)
            {
                Vehicle car = CreateObject(); 
                Htable.Add(car);
            }
            Console.WriteLine("Хеш-таблица заполнена.");
            Htable.Show();
            try
            {
                Vehicle car = CreateObject();
                Htable.Add(car);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Попытка добавить элемент в заполненную таблицу:");
                Console.WriteLine(ex.Message);
            }
        }
        static void Main(string[] args)
        {
            bool isSucceed;
            int answ;
            Console.WriteLine("Введите кол-во элементов");
            int n = int.Parse(Console.ReadLine());
                HTable<Vehicle> Htable = new HTable<Vehicle>();
                for (int i = 0; i < n; i++)
                {
                    Vehicle car = CreateObject();
                    Htable.Add(car);
                }
            do
            {
                Console.WriteLine('\n' + "1. Создать хеш-таблицу");
                Console.WriteLine("2. Вывести хеш-таблицу");
                Console.WriteLine("3. Добавить элемент");
                Console.WriteLine("4. Найти машину по году");
                Console.WriteLine("5. Удалить найденную машину по году");
                Console.WriteLine("6. Посмотреть, что будет, если добавить элемент в заполненную таблицу");
                Console.WriteLine("7. Конец работы");
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
                            Console.WriteLine($"Хеш-таблица из {n} элементов успешно создана");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Хеш-таблица:");
                            if(Htable == null)
                            {
                                Console.WriteLine("Таблица пустая");
                            }
                            else
                            Htable.Show();
                            break;
                        }
                    case 3:
                        {
                            Vehicle car = new Vehicle();
                            Htable.Add(car);
                            Console.WriteLine($"Элемент {car} был добавлен");
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Введите год, по которому нужно найти машину:");
                            int year = int.Parse(Console.ReadLine());
                            Htable.SearchByYear(year);
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Введите год, по которому нужно найти машину:");
                            int year = int.Parse(Console.ReadLine());
                            Htable.RemoveByYear(year);
                            break;
                        }
                    case 6:
                        {
                            OverFlow(Htable);
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