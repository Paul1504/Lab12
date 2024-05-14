using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N2;
using VehicleLibrary1;

namespace N2
{
    public class HTable<T> where T : IInit
    {
        private Point<T>[] positions;
        public int count;

        public HTable(int size = 11)
        {
            positions = new Point<T>[size];
        }

        private int HashPos(T data)
        {
            return Math.Abs(data.GetHashCode()) % positions.Length;
        }

        public void Add(T data)
        {
            if (count == positions.Length)
                throw new Exception("Таблица полная");

            int position = HashPos(data);
            Point<T> d = new Point<T>(data);

            if (positions[position] == null)
            {
                positions[position] = d;
            }    
            else
            {
                int pos = position;
                while (positions[pos] != null)
                {
                    if (positions[pos].isFound)
                        break;
                    pos = (pos + 1) % positions.Length;
                }
                positions[pos] = d;
            }
            count++;
        }

        public void Show()
        {
            for (int i = 0; i < positions.Length; i++)
            {
                if (positions[i] != null && !positions[i].isFound)
                {
                    Console.WriteLine(positions[i].Data.ToString());
                }
                else
                {
                    Console.WriteLine("Пусто");
                }
            }
        }

        public void SearchByYear(int year)
        {
            bool found = false;
            for (int i = 0; i < positions.Length; i++)
            {
                if (positions[i] != null && !positions[i].isFound)
                {
                    if (((dynamic)positions[i].Data).Year == year)
                    {
                        Console.WriteLine(positions[i].Data.ToString());
                        found = true;
                    }
                }
            }
            if (!found)
            {
                Console.WriteLine($"Элемент с годом выпуска {year} не найден.");
            }
        }

        public bool RemoveByYear(int year)
        {
            bool removed = false;
            for (int i = 0; i < positions.Length; i++)
            {
                if (positions[i] != null && !positions[i].isFound)
                {
                    if (((dynamic)positions[i].Data).Year == year)
                    {
                        positions[i].isFound = true; 
                        count--;
                        removed = true;
                    }
                }
            }
            return removed;
        }
    }
}

