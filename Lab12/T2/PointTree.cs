using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleLibrary1;

namespace T2
{
    public class PointTree<T> where T : IInit
    {
            public T data;
            public PointTree<T> left, right;

            public PointTree(T input)
            {
                data = input;
                left = null;
                right = null;
            }
          public PointTree()
          {
            left = null;
            right = null;
          }
        public override string ToString()
            {
                return data.ToString() + " ";
            }
    }
}


