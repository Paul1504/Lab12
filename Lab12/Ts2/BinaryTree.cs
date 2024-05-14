using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T3;
using VehicleLibrary1;

namespace T3
{
     public class BinaryTree<T> where T : Vehicle, IInit, IComparable
     {
        public T data;
        public BinaryTree<T> left, right;

        public BinaryTree(T input)
        {
            data = input;
            left = null;
            right = null;
        }

        public static BinaryTree<T> MakeBalancedTree<TYPE1, TYPE2, TYPE3>(BinaryTree<T> node, int size)
        {
            Random rnd = new Random();
            int randCar = rnd.Next(4);
            T car;
            switch (randCar)
            {
                case 0:
                    car = (T)Activator.CreateInstance(typeof(T));
                    break;
                case 1:
                    car = (T)Activator.CreateInstance(typeof(TYPE1));
                    break;
                case 2:
                    car = (T)Activator.CreateInstance(typeof(TYPE2));
                    break;
                case 3:
                    car = (T)Activator.CreateInstance(typeof(TYPE3));
                    break;
                default:
                    car  = (T)(object)new Vehicle();
                    break;
            }
            car.RandomInit();

            BinaryTree<T> newItem = new BinaryTree<T>(car);
            if (size == 0)
            {
                return null;
            }

            int ln = size / 2;
            int rn = size - ln - 1;

            newItem.left = MakeBalancedTree<TYPE1, TYPE2, TYPE3>(newItem.left, ln);
            newItem.right = MakeBalancedTree<TYPE1, TYPE2, TYPE3>(newItem.right, rn);

            return newItem;
        }

        public static BinaryTree<T> CreateTreeNode(T data)
        {
            BinaryTree<T> newNode = new BinaryTree<T>(data); 
            return newNode;
        }

        public static List<T> ToList(BinaryTree<T> node)
        {
            List<T> List = new List<T>();
            AddToList(node, List);
            return List;
        }

        public static void AddToList(BinaryTree<T> node, List<T> nodeList)
        {
            if (node != null)
            {
                AddToList(node.left, nodeList);

                nodeList.Add(node.data);

                AddToList(node.right, nodeList);
            }
        }
        public static void IntoSearchTree(BinaryTree<T> root, T data)
        {
            BinaryTree<T> currentNode = root;
            BinaryTree<T> parentNode = null;
            bool isFound = false;

            while (currentNode != null && !isFound)
            {
                parentNode = currentNode;

                if (data.Price == currentNode.data.Price)
                {
                    isFound = true;
                }
                else if (data.Price < currentNode.data.Price)
                {
                    currentNode = currentNode.left;
                }
                else
                {
                    currentNode = currentNode.right;
                }

            }

            if (!isFound)
            {
                BinaryTree<T> newTreeNode = new BinaryTree<T>(data);

                if (data.Price < parentNode.data.Price)
                {
                    parentNode.left = newTreeNode;
                }
                else
                {
                    parentNode.right = newTreeNode;
                }

            }
        }

        public static void FillTheSearchTree(BinaryTree<T> node, List<T> nodeList)
        {
            Random rnd = new Random();

            for (int i = 0; i < nodeList.Count; i++)
            {
                T car = nodeList[i];
                IntoSearchTree(node, car);
            }
        }

        public static void ShowTree(BinaryTree<T> currentNode, int sp)
        {
            if ( currentNode == null)
            {
                Console.WriteLine("Дерево пусто");
            }
            else if (currentNode != null)
            {
                ShowTree(currentNode.left, sp + 3);

                for (int i = 0; i < sp; i++)
                {
                    Console.Write(" ");
                }

                Console.WriteLine(currentNode.data);
                ShowTree(currentNode.right, sp + 3); 
            }
        }

        public T FindMaxPriceVehicle()
        {
            if (this == null)
            {
                return null;
            }

            T maxVehicle = data;
            if (left != null)
            {
                T leftMax = left.FindMaxPriceVehicle();
                if (leftMax.Price > maxVehicle.Price)
                {
                    maxVehicle = leftMax;
                }
            }

            if (right != null)
            {
                T rightMax = right.FindMaxPriceVehicle();
                if (rightMax.Price > maxVehicle.Price)
                {
                    maxVehicle = rightMax;
                }
            }

            return maxVehicle;
        }


        public override string ToString()
        {
            return data.ToString() + " ";
        }
     } 
}
