using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    class Circle
    {
        public Point location;
        public string color;
        public bool selected;

        public Circle() { }

        public Circle(int x, int y, bool b)
        {
            string[] colors = { "blue", "red", "yellow", "black" };
            int i = new Random().Next(0, 3);

            location = new Point(x, y);
            color = colors[i];
            selected = b;
        }
    }

    
}
