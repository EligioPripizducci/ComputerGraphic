﻿using System;
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
        public Pen pen = new Pen(Color.Black, 3f);

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
            pen = new Pen(Color.Black);
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
    }
}
