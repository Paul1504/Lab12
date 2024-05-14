using VehicleLibrary1;
using System;
using T1;

namespace Lab12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isSucceed;
            int answ;
            Console.WriteLine("Введите кол-во элементов");
            int n = int.Parse(Console.ReadLine());
            DoublyLinkedList<Vehicle> list = new DoublyLinkedList<Vehicle>();
            Point<Vehicle> beg = DoublyLinkedList<Vehicle>.MakeList<Car, SUV, Truck>(n);
            do
            {
                Console.WriteLine('\n' + "1. Создать список");
                Console.WriteLine("2. Вывести список");
                Console.WriteLine("3. Добавить элемент");
                Console.WriteLine("4. Удалить машины после указанного года");
                Console.WriteLine("5. Копировать список");
                Console.WriteLine("6. Очистить память");
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
                            Console.WriteLine($"Список из {n} элементов успешно создан");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Cписок");
                            list.ShowList(beg);
                            break;
                        }
                    case 3:
                        {
                            list.AddElement(beg);
                            Console.WriteLine($"Элементы с позицией 1, 3, 5 и т.д были добавлены ");
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Введите год, после которого удалить машины");
                            int brand = int.Parse(Console.ReadLine());
                            beg = DoublyLinkedList<Vehicle>.RemoveElement(beg, brand);
                            break;
                        }
                    case 5:
                        {
                            Point<Vehicle> copyBeg = list.CopyList(beg);
                            Console.WriteLine("Копия:");
                            list.ShowList(copyBeg);
                            break;
                        }
                    case 6:
                        {
                            beg = null;
                            Console.WriteLine("Память очищена");    
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