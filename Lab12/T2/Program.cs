using System;
using VehicleLibrary1;

namespace Lab12
{
    internal class Program
    {
        static Vehicle CreateCar()
        {
            Random random = new Random();
            int choice = random.Next(1, 4);
            Vehicle car;
            if (choice == 1)
                car = new Car();
            else if (choice == 2)
                car = new Truck();
            else
                car = new SUV();
            car.RandomInit();
            return car;
        }

        static PointTree<Vehicle> IdealTree(int size)
        {
            PointTree<T> r;
            int nl, nr;
            if (size == 0)
            {
                return null;
            }
            nl = size / 2;
            nr = size - nl - 1;
            Vehicle car = CreateCar();
            r = new PointTree<T>(car);
            r.left = IdealTree(nl);
            r.right = IdealTree(nr);
            return r;

        }

        static void ShowTree(Point p, int level)
        {
            if (p != null)
            {
                ShowTree(p.right, level + 3);
                for (int i = 0; i < level; i++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine(p);
                ShowTree(p.left, level + 3);
            }
        }

        static Car FindMax(PointTree<Vehicle> p)
        {
            if (p == null)
                return null;

            Car t1 = FindMax(p.left);
            Car t2 = FindMax(p.right);

            Car max = p.data;
            if (t1 == null && t2 == null)
                return p.data;
            if (t1 != null && t1.Cost > max.Cost)
                max = t1;
            if (t2 != null && t2.Cost > max.Cost)
                max = t2;

            return max;
        }

        static Point Add(Point newBeg, Car car)
        {
            if (newBeg == null)
            {
                return new Point(car);
            }
            else if (newBeg.data.Cost < car.Cost)
                newBeg.right = Add(newBeg.right, car);
            else if (newBeg.data.Cost > car.Cost)
                newBeg.left = Add(newBeg.left, car);

            return newBeg;
        }

        static Point ConvertToFindTree(Point beg, Point newBeg)
        {
            if (beg != null)
            {
                newBeg = Add(newBeg, beg.data);
                ConvertToFindTree(beg.left, newBeg);
                ConvertToFindTree(beg.right, newBeg);
            }

            return newBeg;
        }

        static Car FindMaxTreeFind(Point beg)
        {
            while (beg.right != null)
            {
                beg = beg.right;
            }
            return beg.data;
        }

        static Point Remove(Point beg, int cost)
        {
            if (cost > beg.data.Cost)
                beg.right = Remove(beg.right, cost);
            else if (cost < beg.data.Cost)
                beg.left = Remove(beg.left, cost);
            else
            {
                if (beg.right == null)
                    return beg.left;
                else if (beg.left == null)
                    return beg.right;
                else
                {
                    Point min = beg.left;
                    while (min.right != null)
                    {
                        min = min.right;
                    }
                    beg.data = min.data;
                    beg.left = Remove(beg.left, beg.data.Cost);
                }
            }
            return beg;
        }