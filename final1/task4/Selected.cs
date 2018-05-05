using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    public class Selected
    {
        public  List<Point> locations;
        public Point location;
        public int index;
        public string color;

        public Selected()
        {
            index = new int();
            location = new Point();
            color = "White";
        }

        public Selected(Point p, string c, int i)
        {
            index = i;
            location = p;
            color = c;
        }
    }
}
