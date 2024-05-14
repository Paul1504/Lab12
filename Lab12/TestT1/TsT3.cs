using N2;
using VehicleLibrary1;
using T3;


namespace TestT1
{
    [TestClass]
    public class TsT3
    {

        [TestMethod]
        public void TreeList()
        {
            BinaryTree<Vehicle> tree = new BinaryTree<Vehicle>(new Vehicle { Price = 5 });
            tree.left = new BinaryTree<Vehicle>(new Vehicle { Price = 3 });
            tree.right = new BinaryTree<Vehicle>(new Vehicle { Price = 8 });
            tree.left.left = new BinaryTree<Vehicle>(new Vehicle { Price = 1 });
            tree.left.right = new BinaryTree<Vehicle>(new Vehicle { Price = 4 });

            List<Vehicle> nodes = BinaryTree<Vehicle>.NodesToList(tree);

            Assert.AreEqual(5, nodes.Count, "Количество узлов в списке некорректно.");
            Assert.AreEqual(1, nodes[0].Price);
            Assert.AreEqual(3, nodes[1].Price);
            Assert.AreEqual(4, nodes[2].Price);
            Assert.AreEqual(5, nodes[3].Price);
            Assert.AreEqual(8, nodes[4].Price);
        }

        [TestMethod]
        public void CreatesSearchTree()
        {
            BinaryTree<Vehicle> tree = new BinaryTree<Vehicle>(new Vehicle { Price = 5 });
            List<Vehicle> nodeList = new List<Vehicle>
            {
                new Vehicle { Price = 3 },
                new Vehicle { Price = 8 },
                new Vehicle { Price = 1 },
                new Vehicle { Price = 4 }
            };

            BinaryTree<Vehicle>.FillTheSearchTree(tree, nodeList);

            Assert.IsTrue(IsValidBinarySearchTree(tree));
        }

        [TestMethod]
        public void MakeBalancedTree()
        {
            int size = 7;

            BinaryTree<Vehicle> tree = BinaryTree<Vehicle>.MakeBalancedTree<Car, Truck, SUV>(null, size);

            int actualSize = GetTreeSize(tree);
            Assert.AreEqual(size, actualSize);
        }


        [TestMethod]
        public void FindMaxPrice()
        {
            BinaryTree<Vehicle> tree = new BinaryTree<Vehicle>(new Vehicle { Price = 5 });
            tree.left = new BinaryTree<Vehicle>(new Vehicle { Price = 3 });
            tree.right = new BinaryTree<Vehicle>(new Vehicle { Price = 8 });
            tree.left.left = new BinaryTree<Vehicle>(new Vehicle { Price = 1 });
            tree.left.right = new BinaryTree<Vehicle>(new Vehicle { Price = 4 });

            Vehicle maxPriceVehicle = tree.FindMaxPriceVehicle();

            Assert.AreEqual(8, maxPriceVehicle.Price);
        }

        private int GetTreeSize(BinaryTree<Vehicle> node)
        {
            if (node == null)
            {
                return 0;
            }
            return 1 + GetTreeSize(node.left) + GetTreeSize(node.right);
        }

        private bool IsValidBinarySearchTree(BinaryTree<Vehicle> node)
        {
            if (node == null)
            {
                return true;
            }

            if (node.left != null && node.left.data.Price >= node.data.Price)
            {
                return false;
            }

            if (node.right != null && node.right.data.Price <= node.data.Price)
            {
                return false;
            }

            return IsValidBinarySearchTree(node.left) && IsValidBinarySearchTree(node.right);
        }

    }
}
