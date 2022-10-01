using System.Drawing.Drawing2D;
using static System.Windows.Forms.LinkLabel;

namespace CompGraph
{
    public partial class Form1 : Form
    {
        private ArrayPoints arrayPoints = new ArrayPoints(2);
        Bitmap bitmap = new Bitmap(100, 100);
        Graphics graphics;

        private int CursorX;
        private int CursorY;
        Pen Oldpen = new Pen(Color.Black, 3f);
        Pen pen = new Pen(Color.Black, 3f);
        private List<LineList> MyLines = new List<LineList>();
        public Point MouseDownLocation;
        private bool IsMouseDown = false;
        private int m_StartX;
        private int m_StartY;
        private int m_CurX;
        private int m_CurY;
        private int counter = 0;
        private int ChosenPointX;
        private int ChosenPointY;
        private bool isLineChosen = false;
        private bool isPointChosen = false;
        private int ChosenLineNumber = 0;
        private string DrawCase = "Line";
        private Image defaultImage;
        Point Point1 = new Point();
        Point Point2 = new Point();
        Point StartDownLocation = new Point();


        public Form1()
        {
            InitializeComponent();
            SetSize();
            //GetCursorCoord();
        }

        private void SetSize()
        {
            Rectangle rectangle = Screen.PrimaryScreen.Bounds;
            bitmap = new Bitmap(rectangle.Width, rectangle.Height);
            graphics = Graphics.FromImage(bitmap);

            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }



        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            //ÐÅÆÈÌ ÐÈÑÎÂÀÍÈß ÏÐßÌÛÕ ËÈÍÈÉ
            if (LineMode_RB.Checked)
            {
                IsMouseDown = true;
                defaultImage = pictureBox1.Image;
                m_StartX = e.X;
                m_StartY = e.Y;
                m_CurX = e.X;
                m_CurY = e.Y;
                StartDownLocation = e.Location;
            }
            //ÐÅÆÈÌ ÐÈÑÎÂÀÍÈß ÊÀÊ ÓÃÎÄÍÎ
            else
            {
                if (DrawMode_rb.Checked)
                {
                    IsMouseDown = true;
                }
            }
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            if (LineMode_RB.Checked)
            {
                CursorX = e.X;
                CursorY = e.Y;

                CursorX_tb.Text = CursorX.ToString();
                CursorY_tb.Text = CursorY.ToString();


                Pen dashed_pen = new Pen(Color.Green, 1);
                dashed_pen.DashStyle = DashStyle.Dash;
                if (IsMouseDown == false) return;
                m_CurX = e.X;
                m_CurY = e.Y;
                switch (DrawCase)
                {
                    case "Line":
                        {
                            break;
                        }
                    case "CopyLine":
                        {
                            //i = MyLines.Count - 1;
                            if (!isLineChosen)
                            {
                                ChosenLineNumber = GetLine();
                            }
                            isLineChosen = true;
                            if (ChosenLineNumber >= 0)
                            {
                                Point1.X = e.X + MyLines[ChosenLineNumber].X1 - StartDownLocation.X;
                                Point1.Y = e.Y + MyLines[ChosenLineNumber].Y1 - StartDownLocation.Y;
                                Point2.X = e.X + MyLines[ChosenLineNumber].X2 - StartDownLocation.X;
                                Point2.Y = e.Y + MyLines[ChosenLineNumber].Y2 - StartDownLocation.Y;
                            }
                            
                            break;

                        }
                    case "MoveLine":
                        {
                            //i = MyLines.Count - 1;
                            if (!isLineChosen)
                            {
                                ChosenLineNumber = GetLine();
                            }
                            isLineChosen = true;

                            if (ChosenLineNumber >= 0 && MyLines.Count > 0)
                               
                            {
                                Point1.X = e.X + MyLines[ChosenLineNumber].X1 - StartDownLocation.X;
                                Point1.Y = e.Y + MyLines[ChosenLineNumber].Y1 - StartDownLocation.Y;
                                Point2.X = e.X + MyLines[ChosenLineNumber].X2 - StartDownLocation.X;
                                Point2.Y = e.Y + MyLines[ChosenLineNumber].Y2 - StartDownLocation.Y;
                            }
                            
                            break;

                        }

                    case "ChangeLine":
                        {
                            
                            if (!isLineChosen)
                            {
                                ChosenLineNumber = GetLine();
                            }
                            isLineChosen = true;
                            if (ChosenLineNumber >= 0 && MyLines.Count > 0)
                            {
                                isPointChosen = true;
                                GetPoint(Point1.X, Point2.X, Point1.Y, Point2.Y);
                                if (Point1.X == ChosenPointX)
                                {

                                    Point1.X = e.X + MyLines[ChosenLineNumber].X1 - StartDownLocation.X;
                                    Point1.Y = e.Y + MyLines[ChosenLineNumber].Y1 - StartDownLocation.Y;
                                    Point2.X = MyLines[ChosenLineNumber].X2;
                                    Point2.Y = MyLines[ChosenLineNumber].Y2;
                                }
                                else
                                {
                                    Point1.X = MyLines[ChosenLineNumber].X1;
                                    Point1.Y = MyLines[ChosenLineNumber].Y1;
                                    Point2.X = e.X + MyLines[ChosenLineNumber].X2 - StartDownLocation.X;
                                    Point2.Y = e.Y + MyLines[ChosenLineNumber].Y2 - StartDownLocation.Y;
                                }
                                isPointChosen = true;
                            }     
                            break;
                        }
                }

                pictureBox1.Invalidate();
            }

            else
            {
                if (DrawMode_rb.Checked)
                {
                    CursorX = e.X;
                    CursorY = e.Y;

                    CursorX_tb.Text = CursorX.ToString();
                    CursorY_tb.Text = CursorY.ToString();



                    if (!IsMouseDown) return;
                    arrayPoints.SetPoint(e.X, e.Y);

                    if(arrayPoints.GetPointsCount() >= 2)
                    {
                        graphics.DrawLines(pen, arrayPoints.GetPoints());
                        pictureBox1.Image = bitmap;
                        arrayPoints.SetPoint(e.X, e.Y);
                    }
                }
            }

        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            if (LineMode_RB.Checked)
            {
                IsMouseDown = false;

                if (e.Button == MouseButtons.Left)
                {
                    switch (DrawCase)
                    {
                        case "Line":
                            {
                                LineList DrawLine = new LineList();
                                DrawLine.X1 = m_StartX;
                                DrawLine.Y1 = m_StartY;
                                DrawLine.X2 = m_CurX;
                                DrawLine.Y2 = m_CurY;
                                MyLines.Add(DrawLine);
                                break;
                            }
                        case "CopyLine":
                            {
                                LineList DrawLine = new LineList();
                                DrawLine.X1 = Point1.X;
                                DrawLine.Y1 = Point1.Y;
                                DrawLine.X2 = Point2.X;
                                DrawLine.Y2 = Point2.Y;
                                MyLines.Add(DrawLine);
                                isLineChosen = false;
                                DrawCase = "Line";
                                break;
                            }
                        case "MoveLine":
                            {
                                if (MyLines.Count > 0)
                                {
                                    LineList DrawLine = new LineList();
                                    DrawLine.X1 = Point1.X;
                                    DrawLine.Y1 = Point1.Y;
                                    DrawLine.X2 = Point2.X;
                                    DrawLine.Y2 = Point2.Y;
                                    MyLines.Add(DrawLine);
                                    
                                    if (ChosenLineNumber >= 0)
                                        MyLines.RemoveAt(ChosenLineNumber);
                                    isLineChosen = false;
                                    //isPointChosen = false;
                                    //DrawCase = "Line";
                                }
                                
                                break;
                            }


                        case "ChangeLine":
                            {
                                
                                if (MyLines.Count > 0)
                                {
                                    LineList DrawLine = new LineList();
                                    DrawLine.X1 = Point1.X;
                                    DrawLine.Y1 = Point1.Y;
                                    DrawLine.X2 = Point2.X;
                                    DrawLine.Y2 = Point2.Y;
                                    MyLines.Add(DrawLine);

                                    if (ChosenLineNumber >= 0)
                                        MyLines.RemoveAt(ChosenLineNumber);
                                    isLineChosen = false;
                                    isPointChosen = false;
                                    //DrawCase = "Line";
                                }

                                break;
                            }
                    }
                    pictureBox1.Invalidate();
                }
            }
            else
            {
                if (DrawMode_rb.Checked)
                {
                    IsMouseDown = false;
                    arrayPoints.ResetPoints();
                }
            }
        }

        private void pictureBox3_Paint(object sender, PaintEventArgs e)
        {
            Pen MyPen = new Pen(Color.Red, 3);
            if (LineMode_RB.Checked)
            {
                int i, x1, y1, x2, y2;

                for (i = 0; i <= MyLines.Count - 1; i++)
                {
                    x1 = MyLines[i].X1;
                    x2 = MyLines[i].X2;
                    y1 = MyLines[i].Y1;
                    y2 = MyLines[i].Y2;
                    e.Graphics.DrawLine(pen, x1, y1, x2, y2);

                }


                if (IsMouseDown == true)
                {
                    switch (DrawCase)
                    {
                        case "Line":
                            {
                                Pen dashed_pen = new Pen(Color.Blue, 1);
                                e.Graphics.DrawLine(dashed_pen, m_StartX, m_StartY, m_CurX, m_CurY);
                                break;
                            }
                        case "CopyLine":
                            {
                                Pen dashed_pen = new Pen(Color.Blue, 1);
                                e.Graphics.DrawLine(dashed_pen, Point1.X, Point1.Y, Point2.X, Point2.Y);
                                break;
                            }
                        case "MoveLine":
                            {
                                Pen dashed_pen = new Pen(Color.Blue, 1);
                                e.Graphics.DrawLine(dashed_pen, Point1.X, Point1.Y, Point2.X, Point2.Y);
                                break;
                            }
                        case "ChangeLine":
                            {
                                Pen dashed_pen = new Pen(Color.Blue, 1);
                                e.Graphics.DrawLine(dashed_pen, Point1.X, Point1.Y, Point2.X, Point2.Y);
                                break;
                            }
                    }
                }
            }           
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (LineMode_RB.Checked)
            {
                DrawCase = "MoveLine";
            }  
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (LineMode_RB.Checked)
            {
                DrawCase = "CopyLine";
            }
            
        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LineMode_RB.Checked)
            {
                DrawCase = "Line";
            }  
        }

        private void changeLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LineMode_RB.Checked)
            {
                DrawCase = "ChangeLine";
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            if (LineMode_RB.Checked)
            {
                pictureBox1.Image = defaultImage;
                MyLines.Clear();
                pictureBox1.Invalidate();
            }

            if (DrawMode_rb.Checked)
            {
                //arrayPoints.
                graphics.Clear(pictureBox1.BackColor);
                pictureBox1.Image = bitmap;
            }
            
        }

        private int GetLine()
        {
            
            for (int i = 0; i < MyLines.Count; i++)
            {
                int tmpX = 0;
                int tmpY = 0;
                if ((MyLines[i].X2 - MyLines[i].X1) == 0)
                {
                    tmpX = MyLines[i].X2;
                }
                else
                {
                    tmpX = MyLines[i].X2 - MyLines[i].X1;
                }
                if ((MyLines[i].Y2 - MyLines[i].Y1) == 0)
                {
                    tmpY = MyLines[i].Y2;
                }
                else
                {
                    tmpY = MyLines[i].Y2 - MyLines[i].Y1;
                }
                if (Math.Abs((CursorX - MyLines[i].X1) / tmpX - (CursorY - MyLines[i].Y1) / tmpY) <= 0.006)
                {
                   // StatusBar.Text = i.ToString();
                    return i;
                }
               
            }
            
            return 0;
        }

        public void GetPoint(int x1, int x2, int y1, int y2)
        {
            double FirstLong;
            double SecondLong;
            FirstLong = Math.Sqrt(Math.Pow((CursorX - x1), 2) + Math.Pow((CursorY - y1), 2));
            SecondLong = Math.Sqrt(Math.Pow((CursorX - x2), 2) + Math.Pow((CursorY - y2), 2));
            if (FirstLong < SecondLong)
            {
                ChosenPointX = x1;
                ChosenPointY = y1;
            }
            else
            {
                ChosenPointX = x2;
                ChosenPointY = y2;
            }
                
        }


        private void button4_Click(object sender, EventArgs e)
        {
            pen.Color = ((Button)sender).BackColor;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                //Oldpen = pen;
                pen.Color = colorDialog1.Color;
                ((Button)sender).BackColor = colorDialog1.Color;
            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            pen.Width = trackBar1.Value;  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "JPG(*.JPG)|*.jpg";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Save(saveFileDialog1.FileName);
                }
            }
        }
    }    
}