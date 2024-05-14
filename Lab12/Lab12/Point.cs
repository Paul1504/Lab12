using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VehicleLibrary1;

namespace Lab12
{
    public class Point<T>
    {
        public T Data { get; set; }
        public Point<T> Next { get; set; }
        public Point<T> Pred { get; set; }

        public Point(T data)
        {
            Data = data;
            Next = null;
            Pred = null;
        }
    }

}
