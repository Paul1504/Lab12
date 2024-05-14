using System;
using System.Diagnostics;
using System.Xml.Linq;
using T3;
using VehicleLibrary1;
class Program
{
    static void Main(string[] args)
    {
        bool isSucceed;
        int answ;
        BinaryTree<Vehicle> root = null;
        List<Vehicle> nodes = new List<Vehicle>();
        do
        {
            Console.WriteLine('\n' + "1. Создать идеально - сбалансированное дерево");
            Console.WriteLine("2. Распечатать дерево");
            Console.WriteLine("3. Найти самую дорогую машину");
            Console.WriteLine("4. Преобразовать дерево в дерево поиска");
            Console.WriteLine("5. Удалить дерево из памяти");
            Console.WriteLine("6. Конец работы");
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
                        Console.Write("Введите размер дерева: ");
                        int size;
                        if (!int.TryParse(Console.ReadLine(), out size))
                        {
                            Console.WriteLine("Неверный ввод. Пожалуйста, введите число.");
                            break;
                        }
                        root = BinaryTree<Vehicle>.MakeBalancedTree<Car, SUV, Truck>(null, size);
                        nodes = BinaryTree<Vehicle>.ToList(root);
                        Console.WriteLine("Идеально сбалансированное дерево создано.");
                        break;
                    }
                case 2:
                    {
                        if (root == null)
                        {
                            Console.WriteLine("Дерево не создано. Сначала создайте дерево.");
                            break;
                        }
                        Console.WriteLine("Дерево:");
                        BinaryTree<Vehicle>.ShowTree(root, 0);
                        break;
                    }
                case 3:
                    {
                        if (root == null)
                        {
                            Console.WriteLine("Дерево не создано. Сначала создайте дерево.");
                            break;
                        }
                        Vehicle maxPriceVehicle = root.FindMaxPriceVehicle();
                        Console.WriteLine($"Машина с максимальной ценой: {maxPriceVehicle}");
                        break;
                    }
                case 4:
                    {
                        if (root == null)
                        {
                            Console.WriteLine("Дерево не создано. Сначала создайте дерево.");
                            break;
                        }
                        BinaryTree<Vehicle>.FillTheSearchTree(root, nodes);
                        Console.WriteLine("Дерево преобразовано в дерево поиска.");
                        break;
                    }
                case 5:
                    {
                        root = null;
                        Console.WriteLine("Память очищена.");
                        break;
                    }
                case 6:
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