using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3
{
    public class Point<T>
    {
        public T? Data { get; set; }
        public Point<T>? left { get; set; }
        public Point<T>? right { get; set; }
        public Point()
        {
            left = null;
            right = null;
        }
        public Point(T data)
        {
            Data = data;
            left = null;
            right = null;
        }
        public override string ToString()
        {
            return Data + " ";
        }

    }
}
