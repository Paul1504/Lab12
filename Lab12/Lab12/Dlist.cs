using Lab12;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleLibrary1;

namespace T1
{
        public class DoublyLinkedList<T> where T : IInit
        {
            public Point<T> currentPoint;

            public DoublyLinkedList()
            {
                currentPoint = null;
            }

            public static Point<T> MakePoint(T data)
            {
                return new Point<T>(data);
            }

            public static Point<T> MakeList<T1, T2, T3>(int size)
            {
                Random rnd = new Random();
                T car = (T)Activator.CreateInstance(typeof(T));
                car.RandomInit();

                Point<T> currentPoint = null;
                if (size > 0)
                {
                    currentPoint = MakePoint(car);
                }

                for (int i = 1; i < size; i++)
                {
                    int randomCar = rnd.Next(4);
                    T addCar;
                    switch (randomCar)
                    {
                        case 0:
                            addCar = (T)Activator.CreateInstance(typeof(T));
                            break;
                        case 1:
                            addCar = (T)Activator.CreateInstance(typeof(T1));
                            break;
                        case 2:
                            addCar = (T)Activator.CreateInstance(typeof(T2));
                            break;
                        case 3:
                            addCar = (T)Activator.CreateInstance(typeof(T3));
                            break;
                        default:
                            addCar = (T)(object)new Vehicle();
                            break;
                    }

                    addCar.RandomInit();
                    Point<T> newPoint = MakePoint(addCar);

                    newPoint.Next = currentPoint;
                    currentPoint.Pred = newPoint;
                    currentPoint = newPoint;
                }
                return currentPoint;
            }

            public void ShowList(Point<T> beg)
            {
                if (beg == null)
                    Console.WriteLine("Лист пустой");
                else
                {
                    Point<T> currentPoint = beg;
                    while (currentPoint != null)
                    {
                        Console.WriteLine(currentPoint.Data);
                        currentPoint = currentPoint.Next;
                    }
                }
            }

            public void AddElement(Point<T> beg)
            {
                Random random = new Random();
                int position = 1;
                Point<T> currentPoint = beg;

                while (currentPoint != null)
                {
                    if (position % 2 != 0)
                    {
                        T newItem = (T)Activator.CreateInstance(typeof(T));
                        newItem.RandomInit();
                        Point<T> newPoint = MakePoint(newItem);

                        newPoint.Next = currentPoint.Next;
                        currentPoint.Next = newPoint;
                        newPoint.Pred = currentPoint;
                        if (newPoint.Next != null)
                            newPoint.Next.Pred = newPoint;
                    }
                    currentPoint = currentPoint.Next;
                    position++;
                }
            }

            public static Point<T> RemoveElement(Point<T> currentPoint, int year)
            {
                bool isDetected = false;
                if (currentPoint == null)
                {
                    Console.WriteLine("Список пуст, удалять нечего");
                    return null;
                }

                Point<T> current = currentPoint;
                while (current != null)
                {
                    Vehicle currentVehicle = (Vehicle)(object)current.Data;
                    if (!isDetected && currentVehicle.Year == year)
                    {
                        isDetected = true;
                    }
                    if (isDetected)
                    {
                        Point<T> next = current.Next;
                        if (next != null)
                        {
                            current.Next = null;
                            next.Pred = null;
                            current = next;
                        }
                        else
                        {
                            current.Next = null;
                            current = null;
                        }
                    }
                    else
                    {
                        current = current.Next;
                    }
                }
                return currentPoint;
            }

            public Point<T> CopyList(Point<T> beg)
            {
                Point<T> newStartPoint = MakePoint(beg.Data);
                Point<T> lastPoint = newStartPoint;
                Point<T> currentPoint = beg.Next;

                while (currentPoint != null)
                {
                    Point<T> newPoint = MakePoint(currentPoint.Data);
                    lastPoint.Next = newPoint;
                    newPoint.Pred = lastPoint;
                    lastPoint = newPoint;
                    currentPoint = currentPoint.Next;
                }
                return newStartPoint;
            }
        }
}
