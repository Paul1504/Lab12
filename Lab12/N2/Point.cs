using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N2
{
    public class Point<T>
    {
        public T Data { get; set; }
        public bool isFound { get; set; }

        public Point(T data)
        {
            Data = data;
            isFound = false;
        }
    }
}
