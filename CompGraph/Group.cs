using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompGraph
{
    internal class Group
    {
        public List<LineList> Lines = new List<LineList>();
        public Pen pen = new Pen(Color.Black, 3f);

        public Group(List<LineList>lines, Pen pen)
        {
            Lines = new List<LineList>(lines);
            this.pen = pen;
        }

        public Group(Pen pen)
        {
            this.pen = pen;
        }

        public Group()
        {
        }

        public void Add(LineList line)
        {
            Lines.Add(line);
        }

    }
}
