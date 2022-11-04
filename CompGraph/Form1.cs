using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Numerics;
using System.Reflection.Emit;
using static System.Windows.Forms.LinkLabel;
using Label = System.Windows.Forms.Label;
//using static System.Net.Mime.MediaTypeNames;

namespace CompGraph
{
    public partial class Form1 : Form
    {
        private ArrayPoints arrayPoints = new ArrayPoints(2);
        Bitmap bitmap = new Bitmap(100, 100);
        Graphics graphics;

        private int CursorX;
        private int CursorY;
        //Pen Oldpen = new Pen(Color.Black, 3f);
        Pen pen = new Pen(Color.Black, 3f);
        private List<LineList> MyLines = new List<LineList>();
        private List<LineList> toGroup = new List<LineList>();
        private List<Group> MyGroups = new List<Group>();
        private List<LineList> l = new List<LineList>();
        
        public Point MouseDownLocation;
        private bool IsMouseDown = false;
        private int m_StartX;
        private int m_StartY;
        private int m_CurX;
        private int m_CurY;
        private int counter = 0;
        private int ChosenPointX;
        private int ChosenPointY;
        private bool isGroupChosen = false;
        private bool isLineChosen = false;
        private bool isPointChosen = false;
        private int ChosenLineNumber = 0;
        private int ChosenGroupNumber = 0;
        private string DrawCase = "Line";
        private Image defaultImage;
        Point Point1 = new Point();
        Point Point2 = new Point();
        List<Point> Point1Group = new List<Point>();
        List<Point> Point2Group = new List<Point>();
        Point StartDownLocation = new Point();


        TrackBar Scale_trackBar = new TrackBar();


        public Form1()
        {
            InitializeComponent();
            SetSize();
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
            //РЕЖИМ РИСОВАНИЯ ПРЯМЫХ ЛИНИЙ
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
            //РЕЖИМ РИСОВАНИЯ
            else
            {
                if (DrawMode_rb.Checked)
                {
                    IsMouseDown = true;
                }
            }
        }



        //Действия при ведении ЛКМ по экрану для разных режимов работы
        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            //Определение координат курсора и вывод их в окно
            CursorX = e.X;
            CursorY = e.Y;
            CursorX_tb.Text = CursorX.ToString();
            CursorY_tb.Text = CursorY.ToString();

            //Режим работы с линиями и выбор действий в зависимости от текущего режима
            if (LineMode_RB.Checked)
            {
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
                            MouseMove_CopyLine(sender, e);
                            break;
                        }
                    case "MoveLine":
                        {
                            MouseMove_MoveLine(sender, e);
                            break;
                        }

                    case "ChangeLine":
                        {
                            MouseMove_ChangeLine(sender, e);
                            break;
                        }
                    case "CreateGroup":
                        {
                            MouseMove_CreateGroup(sender, e);
                            break;
                        }
                    case "MoveGroup":
                        {
                            MouseMove_MoveGroup(sender, e);
                            break;
                        }
                    case "ChangeGroup":
                        {
                            MouseMove_ChangeGroup(sender, e);
                            break;
                        }
                }

                pictureBox1.Invalidate();
            }

            else
            {
                if (DrawMode_rb.Checked)
                {
                    if (!IsMouseDown) return;
                    arrayPoints.SetPoint(e.X, e.Y);

                    if (arrayPoints.GetPointsCount() >= 2)
                    {
                        graphics.DrawLines(pen, arrayPoints.GetPoints());
                        pictureBox1.Image = bitmap;
                        arrayPoints.SetPoint(e.X, e.Y);
                    }
                }
            }

        }


        private void MouseMove_CopyLine(object sender, MouseEventArgs e)
        {
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
        }
        private void MouseMove_ChangeLine(object sender, MouseEventArgs e)
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
        }
        private void MouseMove_MoveLine(object sender, MouseEventArgs e)
        {
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

        }
        private void MouseMove_CreateGroup(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < MyLines.Count; i++)
            {
                if (IsPointOnLine(e.X, e.Y, MyLines[i].X1, MyLines[i].X2, MyLines[i].Y1, MyLines[i].Y2))
                {
                    toGroup.Add(MyLines[i]);
                }
            }
            toGroup = toGroup.Distinct().ToList();
        }
        private void MouseMove_MoveGroup(object sender, MouseEventArgs e)
        {
            if (!isGroupChosen)
            {
                ChosenGroupNumber = GetGroup();
            }
            

            if (ChosenGroupNumber > -1)
            {
                isGroupChosen = true;
                for (int i = 0; i < MyGroups[ChosenGroupNumber].Lines.Count; i++)
                {
                    LineList lines = new LineList();
                    if (ChosenGroupNumber >= 0 && MyGroups.Count > 0)
                    {
                        lines.X1 = e.X + MyGroups[ChosenGroupNumber].Lines[i].X1 - StartDownLocation.X;
                        lines.Y1 = e.Y + MyGroups[ChosenGroupNumber].Lines[i].Y1 - StartDownLocation.Y;
                        lines.X2 = e.X + MyGroups[ChosenGroupNumber].Lines[i].X2 - StartDownLocation.X;
                        lines.Y2 = e.Y + MyGroups[ChosenGroupNumber].Lines[i].Y2 - StartDownLocation.Y;
                        l.Add(lines);
                    }
                    
                }
                isGroupChosen = false;
                MyGroups.Add(new Group(l, MyGroups[ChosenGroupNumber].pen));
                MyGroups.RemoveAt(ChosenGroupNumber);
                l.Clear();
                StartDownLocation.X = e.X;
                StartDownLocation.Y = e.Y;
            }
        }
        private void MouseMove_ChangeGroup(object sender, MouseEventArgs e)
        {
            if (!isGroupChosen)
            {
                ChosenGroupNumber = GetGroup();
            }


            if (ChosenGroupNumber > -1)
            {
                isGroupChosen = true;
                for (int i = 0; i < MyGroups[ChosenGroupNumber].Lines.Count; i++)
                {
                    LineList lines = new LineList();
                    if (ChosenGroupNumber >= 0 && MyGroups.Count > 0)
                    {
                        lines.X1 = e.X + MyGroups[ChosenGroupNumber].Lines[i].X1 - StartDownLocation.X;
                        lines.Y1 = e.Y + MyGroups[ChosenGroupNumber].Lines[i].Y1 - StartDownLocation.Y;
                        lines.X2 = e.X + MyGroups[ChosenGroupNumber].Lines[i].X2 - StartDownLocation.X;
                        lines.Y2 = e.Y + MyGroups[ChosenGroupNumber].Lines[i].Y2 - StartDownLocation.Y;
                        l.Add(lines);
                    }

                }
                isGroupChosen = false;
                MyGroups.Add(new Group(l, MyGroups[ChosenGroupNumber].pen));
                MyGroups.RemoveAt(ChosenGroupNumber);
                l.Clear();
                StartDownLocation.X = e.X;
                StartDownLocation.Y = e.Y;
            }
        }


        //Действия при отпускании ЛКМ для разных режимов работы
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
                                MouseUp_Line(sender, e);
                                break;
                            }
                        case "CopyLine":
                            {
                                MouseUp_CopyLine(sender, e);
                                break;
                            }
                        case "MoveLine":
                            {
                                MouseUp_MoveLine(sender, e);
                                break;
                            }
                        case "ChangeLine":
                            {
                                MouseUp_ChangeLine(sender, e);
                                break;
                            }
                        case "CreateGroup": break;

                        case "MoveGroup":
                            {
                                MouseUp_MoveGroup(sender, e);
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


        private void MouseUp_Line(object sender, MouseEventArgs e)
        {
            LineList DrawLine = new LineList();
            DrawLine.X1 = m_StartX;
            DrawLine.Y1 = m_StartY;
            DrawLine.X2 = m_CurX;
            DrawLine.Y2 = m_CurY;
            DrawLine.pen = this.pen.Clone() as Pen;
            MyLines.Add(DrawLine);
        }
        private void MouseUp_CopyLine(object sender, MouseEventArgs e)
        {
            LineList DrawLine = new LineList();
            DrawLine.X1 = Point1.X;
            DrawLine.Y1 = Point1.Y;
            DrawLine.X2 = Point2.X;
            DrawLine.Y2 = Point2.Y;
            MyLines.Add(DrawLine);
            isLineChosen = false;
            DrawCase = "Line";
        }
        private void MouseUp_MoveLine(object sender, MouseEventArgs e)
        {
            if (MyLines.Count > 0)
            {
                LineList DrawLine;
                if (ChosenLineNumber >= 0)
                {
                    DrawLine = new LineList(MyLines[ChosenLineNumber].pen);
                }
                else
                    DrawLine = new LineList();

                DrawLine.X1 = Point1.X;
                DrawLine.Y1 = Point1.Y;
                DrawLine.X2 = Point2.X;
                DrawLine.Y2 = Point2.Y;
                MyLines.Add(DrawLine);

                if (ChosenLineNumber >= 0)
                {
                    MyLines.RemoveAt(ChosenLineNumber);
                }
                else
                {
                    MyLines.RemoveAt(MyLines.Count - 1);
                }

                isLineChosen = false;
            }
        }
        private void MouseUp_ChangeLine(object sender, MouseEventArgs e)
        {
            if (MyLines.Count > 0)
            {
                LineList DrawLine;
                if (ChosenLineNumber >= 0)
                {
                    DrawLine = new LineList(MyLines[ChosenLineNumber].pen);
                }
                else
                    DrawLine = new LineList();
                DrawLine.X1 = Point1.X;
                DrawLine.Y1 = Point1.Y;
                DrawLine.X2 = Point2.X;
                DrawLine.Y2 = Point2.Y;
                MyLines.Add(DrawLine);

                if (ChosenLineNumber >= 0)
                    MyLines.RemoveAt(ChosenLineNumber);
                else
                {
                    MyLines.RemoveAt(MyLines.Count - 1);
                }
                isLineChosen = false;
                isPointChosen = false;
            }
        }
        private void MouseUp_MoveGroup(object sender, MouseEventArgs e)
        {
            if (ChosenGroupNumber >= 0)
            {
                l.Clear();
            }
            /*else
            {
                MyGroups.RemoveAt(MyGroups.Count - 1);
            }*/
            isGroupChosen = false;
        }


        //Отрисовка линий после выполнения каждого режима
        private void pictureBox3_Paint(object sender, PaintEventArgs e)
        {
            Paint_Lines(sender, e);
            if (LineMode_RB.Checked)
            {
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
                        case "CreateGroup":
                            {
                                Pen dashed_pen = new Pen(Color.Blue, 1);
                                e.Graphics.DrawLine(dashed_pen, Point1.X, Point1.Y, Point2.X, Point2.Y);
                                break;

                            }
                    }
                }
            }
        }
        private void Paint_Lines(object sender, PaintEventArgs e)
        {
            Random random = new Random();
            Pen dot_Color2 = new Pen(Color.Green, 3);
            Pen dot_Color = new Pen(Color.Blue, 3);
            Pen group_pen = new Pen(Color.Purple, 3);
           
            
            if (LineMode_RB.Checked)
            {
                int i, x1, y1, x2, y2;

                for (i = 0; i <= MyLines.Count - 1; i++)
                {
                    x1 = MyLines[i].X1;
                    x2 = MyLines[i].X2;
                    y1 = MyLines[i].Y1;
                    y2 = MyLines[i].Y2;
                    e.Graphics.DrawLine(MyLines[i].pen, x1, y1, x2, y2);
                    e.Graphics.DrawRectangle(dot_Color, x1, y1, 2, 2);
                    e.Graphics.DrawRectangle(dot_Color, x2, y2, 2, 2);
                }

                for (i = 0; i <= toGroup.Count - 1; i++)
                {
                    x1 = toGroup[i].X1;
                    x2 = toGroup[i].X2;
                    y1 = toGroup[i].Y1;
                    y2 = toGroup[i].Y2;
                    e.Graphics.DrawLine(group_pen, x1, y1, x2, y2);
                    e.Graphics.DrawRectangle(dot_Color2, x1, y1, 2, 2);
                    e.Graphics.DrawRectangle(dot_Color2, x2, y2, 2, 2);
                }

                if (MyGroups.Count > 0)
                {
                    for (i = 0; i < MyGroups.Count; i++)
                    {
                        for (int j = 0; j < MyGroups[i].Lines.Count; j++)
                        {
                            
                            x1 = MyGroups[i].Lines[j].X1;
                            x2 = MyGroups[i].Lines[j].X2;
                            y1 = MyGroups[i].Lines[j].Y1;
                            y2 = MyGroups[i].Lines[j].Y2;
                            e.Graphics.DrawLine(MyGroups[i].pen, x1, y1, x2, y2);
                            e.Graphics.DrawRectangle(dot_Color2, x1, y1, 2, 2);
                            e.Graphics.DrawRectangle(dot_Color2, x2, y2, 2, 2);
                        }
                    }
                }
                
            }
        }


        //Вспомогательные методы
        private int GetLine()
        {
            int line = -1;

            for (int i = 0; i < MyLines.Count; i++)
            {
                if (IsPointOnLine(CursorX, CursorY, MyLines[i].X1, MyLines[i].X2, MyLines[i].Y1, MyLines[i].Y2))
                {
                    line = i;
                }
            }
            if (line != -1)
            {
                int x1 = MyLines[line].X1;
                int x2 = MyLines[line].X2;
                int y1 = MyLines[line].Y1;
                int y2 = MyLines[line].Y2;
                int A, B, C = 0;
                if (x1 <= x2)
                {
                    A = y1 - y2;
                    B = x2 - x1;
                    C = x1 * y2 - x2 * y1;

                }
                else
                {
                    A = y1 - y2;
                    B = x2 - x1;
                    C = x1 * y2 - x2 * y1;
                }
                StatusBar.Text = GetEquation(A, B, C);
            }
            else
            {
                StatusBar.Text = "Линия не выбрана!";
            }

            return line;
        }
        public int GetGroup()
        {
            for (int i = 0; i < MyGroups.Count; i++)
            {
                for (int j = 0; j < MyGroups[i].Lines.Count; j++)
                {

                    var x1 = MyGroups[i].Lines[j].X1;
                    var x2 = MyGroups[i].Lines[j].X2;
                    var y1 = MyGroups[i].Lines[j].Y1;
                    var y2 = MyGroups[i].Lines[j].Y2;

                    if (IsPointOnLine(CursorX, CursorY, x1,x2, y1, y2))
                    {
                        Check.Text = i.ToString();
                        //MyGroups[i].pen.Color = Color.Red;
                        return i;
                    }         
                }
            }

            return -1;
        }
        private bool IsPointOnLine(int x, int y, int x1, int x2, int y1, int y2)
        {
            int eps = 5;
            return Math.Abs(L(x, y, x1,y1) + L(x, y, x2, y2)
                - L(x1, y1, x2, y2)) <= eps;
        }
        private double L(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
        }
        private static string GetEquation(int a, int b, int c)
        {
            string result = "";

            if (a != 0 && b != 0)
            {
                if (b < 0)
                {
                    result += a.ToString() + "x -" + Math.Abs(b).ToString() + "y ";
                }
                else
                {
                    result += a.ToString() + "x + " + b.ToString() + "y ";
                }
                if (c < 0)
                {
                    result += "- " + Math.Abs(c).ToString() + " = 0";
                }
                else
                {
                    result += "+ " + Math.Abs(c).ToString() + " = 0";
                }
            }
            else
            {
                if (a == 0)
                {
                    if (b < 0)
                    {
                        result += "-" + Math.Abs(b).ToString() + "y ";
                    }
                    else
                    {
                        result += b.ToString() + "y ";
                    }
                    if (c < 0)
                    {
                        result += "- " + Math.Abs(c).ToString() + " = 0";
                    }
                    else
                    {
                        result += "+ " + Math.Abs(c).ToString() + " = 0";
                    }
                }
                else
                {
                    result += a.ToString() + "x";
                    if (c < 0)
                    {
                        result += "- " + Math.Abs(c).ToString() + " = 0";
                    }
                    else
                    {
                        result += "+ " + Math.Abs(c).ToString() + " = 0";
                    }
                }
            }
            return result;
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
        private void create_group_Click(object sender, EventArgs e)
        {          
            Random random = new Random();
            var r = random.Next(0, 255);
            var g = random.Next(0, 255);
            var b = random.Next(0, 255);
            Color color = Color.FromArgb(r, g, b);
            Group tmp = new Group(new Pen(color, 3));

            foreach (var item in toGroup)
            {
                tmp.Add(item);
            }

            MyGroups.Add(tmp);
            ClearLines(toGroup);
            toGroup.Clear();            
        }
        private void ClearLines(List<LineList> toGr)
        {
            for (int i = 0; i < toGr.Count; i++)
            {
                DeleteLine(toGr[i].X1, toGr[i].X2, toGr[i].Y1, toGr[i].Y2);
            }
        }
        private void DeleteLine(int x1, int x2, int y1, int y2)
        {
            for (int i = 0; i < MyLines.Count; i++)
            {
                if (MyLines[i].X1 == x1 && MyLines[i].X2 == x2 && MyLines[i].Y1 == y1 && MyLines[i].Y2 == y2)
                MyLines.Remove(MyLines[i]);
            }
        }



        //Работа с дизайном при рисовании
        private void ClearButton_Click(object sender, EventArgs e)
        {
            if (LineMode_RB.Checked)
            {
                pictureBox1.Image = defaultImage;
                MyLines.Clear();
                toGroup.Clear();
                MyGroups.Clear();
                pictureBox1.Invalidate();
            }

            if (DrawMode_rb.Checked)
            {
                graphics.Clear(pictureBox1.BackColor);
                pictureBox1.Image = bitmap;
            }

        }
        private void ChangeColor_Click(object sender, EventArgs e)
        {
            pen.Color = ((Button)sender).BackColor;
        }
        private void NewColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pen.Color = colorDialog1.Color;
                ((Button)sender).BackColor = colorDialog1.Color;
            }
        }
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            pen.Width = trackBar1.Value;  
        }
        private void SaveFile_Click(object sender, EventArgs e)
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



        //Выбор режима работы по нажатию ПКМ
        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toGroup.Clear();
            if (LineMode_RB.Checked)
            {
                DrawCase = "Line";
            }
        }
        private void CopyLineToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            toGroup.Clear();
            if (LineMode_RB.Checked)
            {
                DrawCase = "CopyLine";
            }
        }
        private void MoveLineToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            toGroup.Clear();
            if (LineMode_RB.Checked)
            {
                DrawCase = "MoveLine";
            }
        }
        private void changeLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toGroup.Clear();
            if (LineMode_RB.Checked)
            {
                DrawCase = "ChangeLine";
            }
        }
        private void createGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LineMode_RB.Checked)
            {
                DrawCase = "CreateGroup";
            }
        }
        private void changeGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LineMode_RB.Checked)
            {
                DrawCase = "ChangeGroup";

                create_group.Visible = false;
                Check.Visible = false;
                StatusBar.Visible = false;
                flowLayoutPanel2.Visible = false;

                FlowLayoutPanel Scale = new FlowLayoutPanel();
                Scale.Visible = true;
                Scale.Height = 150;
                panel1.Controls.Add(Scale);
                
                Scale_trackBar.Size = trackBar1.Size;
                Scale_trackBar.Minimum = 5;
                Scale_trackBar.Maximum = 20;
                Scale_trackBar.Value = 13;
                Scale_trackBar.TickFrequency = 1;
                //Scale_trackBar.ValueChanged += Scale_Bar_ValueChanged;
                Scale_trackBar.MouseUp += Scale_trackBar_MouseUp;

                Label label = new Label();
                label.Text = "Масштабирование";
                label.Width = label1.Width;
                label.Font = new Font("Segoe UI Symbol", 12);
                label.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                label.TextAlign = ContentAlignment.MiddleCenter;


                TrackBar Rotate_trackBar = new TrackBar();
                Rotate_trackBar.Size = trackBar1.Size;
                Rotate_trackBar.Minimum = 0;
                Rotate_trackBar.Maximum = 36;
                Rotate_trackBar.Value = 18;
                Rotate_trackBar.TickFrequency = 1;

                Label rotate_label = new Label();
                rotate_label.Text = "Поворот";
                rotate_label.Width = label1.Width;
                rotate_label.Font = new Font("Segoe UI Symbol", 12);
                rotate_label.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                rotate_label.TextAlign = ContentAlignment.MiddleCenter;


                //Scale_trackBar.Parent = Scale;
                Scale.Controls.Add(label);
                Scale.Controls.Add(Scale_trackBar);

                Scale.Controls.Add(rotate_label);
                Scale.Controls.Add(Rotate_trackBar);

                Scale.Location = flowLayoutPanel2.Location;
            }
        }

        private void Scale_trackBar_MouseUp(object? sender, MouseEventArgs e)
        {
            if (ChosenGroupNumber > -1)
            {
                for (int i = 0; i < MyGroups[ChosenGroupNumber].Lines.Count; i++)
                {
                    double value = Scale_trackBar.Value / 10.0;
                    MyGroups[ChosenGroupNumber].Lines[i].X1 = (int)(MyGroups[ChosenGroupNumber].Lines[i].X1 * value);
                    MyGroups[ChosenGroupNumber].Lines[i].X2 = (int)(MyGroups[ChosenGroupNumber].Lines[i].X2 * value);
                    MyGroups[ChosenGroupNumber].Lines[i].Y1 = (int)(MyGroups[ChosenGroupNumber].Lines[i].Y1 * value);
                    MyGroups[ChosenGroupNumber].Lines[i].Y2 = (int)(MyGroups[ChosenGroupNumber].Lines[i].Y2 * value);
                }

                Scale_trackBar.Value = 13;
            }
        }

        private void moveGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LineMode_RB.Checked)
            {
                DrawCase = "MoveGroup";
            }
        }
    }    
}