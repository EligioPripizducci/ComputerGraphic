using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompGraph
{
    internal class LineList
    {
        public static long TotalCount;
        private int _X1;
        private int _Y1;
        private int _X2;
        private int _Y2;
        private int _Z1;
        private int _Z2;

        private int _RenderX1;
        private int _RenderX2;
        private int _RenderY1;
        private int _RenderY2;
        private int _RenderZ1;
        private int _RenderZ2;

        public Pen pen = new Pen(Color.Black, 2f);

        public int X1
        {
            get { return _X1; }
            set { _X1 = value; }
        }
        public int Y1
        {
            get { return _Y1; }
            set { _Y1 = value; }
        }
        public int X2
        {
            get { return _X2; }
            set { _X2 = value; }
        }
        public int Y2
        {
            get { return _Y2; }
            set { _Y2 = value; }
        }
        public int Z1
        {
            get { return _Z1; }
            set { _Z1 = value; }
        }
        public int Z2
        {
            get { return _Z2; }
            set { _Z2 = value; }
        }
        public int RenderX1
        {
            get { return _RenderX1; }
            set { _RenderX1 = value; }
        }
        public int RenderX2
        {
            get { return _RenderX2; }
            set { _RenderX2 = value; }
        }
        public int RenderY1
        {
            get { return _RenderY1; }
            set { _RenderY1 = value; }
        }
        public int RenderY2
        {
            get { return _RenderY2; }
            set { _RenderY2 = value; }
        }
        public int RenderZ1
        {
            get { return _RenderZ1; }
            set { _RenderZ1 = value; }
        }
        public int RenderZ2
        {
            get { return _RenderZ2; }
            set { _RenderZ2 = value; }
        }

        public LineList(int _X1, int _Y1, int _X2, int _Y2, Pen _pen)
        {
            X1 = _X1;
            Y1 = _Y1;
            X2 = _X2;
            Y2 = _Y2;
            //pen = _pen;
            this.pen = _pen.Clone() as Pen;
            TotalCount += 1;
            //this.pen = pen;
        }

        public LineList()
        {
            X1 = 0;
            Y1 = 0;
            X2 = 0;
            Y2 = 0;
            Z1 = 0;
            Z2 = 0;
            pen = new Pen(Color.Black, 2f);
            TotalCount += 1;
        }

        public LineList(Pen _pen)
        {
            X1 = 0;
            Y1 = 0;
            X2 = 0;
            Y2 = 0;
            this.pen = _pen.Clone() as Pen;
        }

        ~LineList()
        {
            TotalCount -= 1;
        }

        public void Dispose()
        {
            this.Dispose();
        }

        public void GetRender()
        {
            _RenderX1 = _X1;
            _RenderY1 = _Y1;
            _RenderX2 = _X2;
            _RenderY2 = _Y2;
            _RenderZ2 = _Z2;
            _RenderZ2 = _Z2;
        }

    }
}
