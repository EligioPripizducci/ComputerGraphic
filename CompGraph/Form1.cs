using Newtonsoft.Json;
using System;
using System.Drawing.Drawing2D;
using System.Text.Json;
using static System.Windows.Forms.LinkLabel;
using JsonSerializer = System.Text.Json.JsonSerializer;
//using JsonSerializer = Newtonsoft.Json.JsonSerializer;
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
        Pen pen = new Pen(Color.Black, 2f);
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
        private int ChosenPointX;
        private int ChosenPointY;
        private bool isGroupChosen = false;
        private bool isLineChosen = false;
        private bool isPointChosen = false;
        private int ChosenLineNumber = 0;
        private int ChosenGroupNumber = -1;
        private string DrawCase = "Line";
        private string xyz_str = "";
        private int PhiCorner;
        private int TettaCorner;
        private double Viewer;
        private Image defaultImage;
        Point Point1 = new Point();
        Point Point2 = new Point();
        List<Point> Point1Group = new List<Point>();
        List<Point> Point2Group = new List<Point>();
        Point StartDownLocation = new Point();
        private Bitmap bm = new Bitmap(2000, 1300);


        Label q_lab = new Label();
        Label p_lab = new Label();
        Label rotate_label = new Label();
        Label label = new Label();
        FlowLayoutPanel Scale = new FlowLayoutPanel();
        FlowLayoutPanel mirror_panel = new FlowLayoutPanel();
        TrackBar Scale_trackBar = new TrackBar();
        NumericUpDown value_number = new NumericUpDown();
        Button scale_picture = new Button();
        NumericUpDown value_angle = new NumericUpDown();
        Button rotate_picture = new Button();
        Button mirror_picture = new Button();
        CheckBox Y_mirror = new CheckBox();
        CheckBox X_mirror = new CheckBox();
        CheckBox Z_mirror = new CheckBox();
        CheckBox test = new CheckBox();
        NumericUpDown p_koef = new NumericUpDown();
        NumericUpDown q_koef = new NumericUpDown();
        Button project_picture = new Button();
        Button Ungroup = new Button();
        OpenFileDialog openFileDialog1 = new OpenFileDialog();


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
            if (Rubbish_rb.Checked)
            {
                IsMouseDown = true;
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
                if (!IsMouseDown) return;
                if (Rubbish_rb.Checked)
                {
                    for (int i = 0; i < MyLines.Count; i++)
                    {
                        if (IsPointOnLine(e.X, e.Y, MyLines[i].X1, MyLines[i].X2, MyLines[i].Y1, MyLines[i].Y2))
                        {
                            MyLines.Remove(MyLines[i]);
                        }
                    }
                    /*for (int i = 0; i < MyGroups.Count; i++)
                    {
                        for (int j = 0; j < MyGroups[i].Lines.Count; j++)
                        {
                            if (IsPointOnLine(e.X, e.Y, MyGroups[i].Lines[j].X1, MyGroups[i].Lines[j].X2, MyGroups[i].Lines[j].Y1, MyGroups[i].Lines[j].Y2))
                            {
                                MyGroups.Remove(MyGroups[i]);
                            }
                        }
                        
                    }*/
                    pictureBox1.Invalidate();
                }
            }

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


        private void MouseMove_CopyLine(object sender, MouseEventArgs e)
        {
            if (!isLineChosen)
            {
                ChosenLineNumber = GetLine();
            }
            isLineChosen = true;

            if (ChosenLineNumber >= 0)
            {
                Point1.X = e.X + MyLines[ChosenLineNumber].RenderX1 - StartDownLocation.X;
                Point1.Y = e.Y + MyLines[ChosenLineNumber].RenderY1 - StartDownLocation.Y;
                Point2.X = e.X + MyLines[ChosenLineNumber].RenderX2 - StartDownLocation.X;
                Point2.Y = e.Y + MyLines[ChosenLineNumber].RenderY2 - StartDownLocation.Y;
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

                    Point1.X = e.X + MyLines[ChosenLineNumber].RenderX1 - StartDownLocation.X;
                    Point1.Y = e.Y + MyLines[ChosenLineNumber].RenderY1 - StartDownLocation.Y;
                    Point2.X = MyLines[ChosenLineNumber].RenderX2;
                    Point2.Y = MyLines[ChosenLineNumber].RenderY2;
                }
                else
                {
                    Point1.X = MyLines[ChosenLineNumber].RenderX1;
                    Point1.Y = MyLines[ChosenLineNumber].RenderY1;
                    Point2.X = e.X + MyLines[ChosenLineNumber].RenderX2 - StartDownLocation.X;
                    Point2.Y = e.Y + MyLines[ChosenLineNumber].RenderY2 - StartDownLocation.Y;
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
                Point1.X = e.X + MyLines[ChosenLineNumber].RenderX1 - StartDownLocation.X;
                Point1.Y = e.Y + MyLines[ChosenLineNumber].RenderY1 - StartDownLocation.Y;
                Point2.X = e.X + MyLines[ChosenLineNumber].RenderX2 - StartDownLocation.X;
                Point2.Y = e.Y + MyLines[ChosenLineNumber].RenderY2 - StartDownLocation.Y;
            }

        }
        private void MouseMove_CreateGroup(object sender, MouseEventArgs e)
        {
            XY_rb_CheckedChanged(this, new EventArgs());
            for (int i = 0; i < MyLines.Count; i++)
            {
                if (IsPointOnLine(e.X, e.Y, MyLines[i].RenderX1, MyLines[i].RenderX2, MyLines[i].RenderY1, MyLines[i].RenderY2))
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
                //MyGroups.Add(new Group(l, MyGroups[ChosenGroupNumber].pen));
                MyGroups.Add(new Group(l));
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
                    LineList lines = MyGroups[ChosenGroupNumber].Lines[i];
                    if (ChosenGroupNumber >= 0 && MyGroups.Count > 0)
                    {
                        if (XY_rb.Checked)
                        {
                            lines.X1 = MyGroups[ChosenGroupNumber].Lines[i].X1 + e.X - StartDownLocation.X;
                            lines.X2 = MyGroups[ChosenGroupNumber].Lines[i].X2 + e.X - StartDownLocation.X;
                            lines.Y1 = MyGroups[ChosenGroupNumber].Lines[i].Y1 + e.Y - StartDownLocation.Y;
                            lines.Y2 = MyGroups[ChosenGroupNumber].Lines[i].Y2 + e.Y - StartDownLocation.Y;
                        }

                        else if (XZ_rb.Checked)
                        {
                            lines.X1 = MyGroups[ChosenGroupNumber].Lines[i].X1 + e.X - StartDownLocation.X;
                            lines.X2 = MyGroups[ChosenGroupNumber].Lines[i].X2 + e.X - StartDownLocation.X;
                            lines.Z1 = MyGroups[ChosenGroupNumber].Lines[i].Z1 + e.Y - StartDownLocation.Y;
                            lines.Z2 = MyGroups[ChosenGroupNumber].Lines[i].Z2 + e.Y - StartDownLocation.Y;
                        }

                        else if (YZ_rb.Checked)
                        {
                            lines.Z1 = MyGroups[ChosenGroupNumber].Lines[i].Z1 + e.X - StartDownLocation.X;
                            lines.Z2 = MyGroups[ChosenGroupNumber].Lines[i].Z2 + e.X - StartDownLocation.X;
                            lines.Y1 = MyGroups[ChosenGroupNumber].Lines[i].Y1 + e.Y - StartDownLocation.Y;
                            lines.Y2 = MyGroups[ChosenGroupNumber].Lines[i].Y2 + e.Y - StartDownLocation.Y;
                        }

                        lines.RenderX1 = e.X + MyGroups[ChosenGroupNumber].Lines[i].RenderX1 - StartDownLocation.X;
                        lines.RenderY1 = e.Y + MyGroups[ChosenGroupNumber].Lines[i].RenderY1 - StartDownLocation.Y;
                        lines.RenderX2 = e.X + MyGroups[ChosenGroupNumber].Lines[i].RenderX2 - StartDownLocation.X;
                        lines.RenderY2 = e.Y + MyGroups[ChosenGroupNumber].Lines[i].RenderY2 - StartDownLocation.Y;
                        l.Add(lines);
                    }

                }
                isGroupChosen = false;
                //MyGroups.Add(new Group(l, MyGroups[ChosenGroupNumber].pen));
                MyGroups.Add(new Group(l));
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
            if (Rubbish_rb.Checked)
            {
                IsMouseDown = false;
            }
        }


        private void MouseUp_Line(object sender, MouseEventArgs e)
        {
            LineList DrawLine = new LineList();
            if (XY_rb.Checked)
            {
                DrawLine.X1 = m_StartX;
                DrawLine.Y1 = m_StartY;
                DrawLine.X2 = m_CurX;
                DrawLine.Y2 = m_CurY;
            }
            else if (XZ_rb.Checked)
            {
                DrawLine.X1 = m_StartX;
                DrawLine.Z1 = m_StartY;
                DrawLine.X2 = m_CurX;
                DrawLine.Z2 = m_CurY;
            }
            else if (YZ_rb.Checked)
            {
                DrawLine.Z1 = m_StartX;
                DrawLine.Y1 = m_StartY;
                DrawLine.Z2 = m_CurX;
                DrawLine.Y2 = m_CurY;
            }
            DrawLine.GetRender();
            DrawLine.pen = this.pen.Clone() as Pen;
            MyLines.Add(DrawLine);
            XY_rb_CheckedChanged(this, new EventArgs());
        }
        private void MouseUp_CopyLine(object sender, MouseEventArgs e)
        {
            LineList DrawLine = new LineList();
            if (XY_rb.Checked)
            {
                DrawLine.X1 = Point1.X;
                DrawLine.Y1 = Point1.Y;
                DrawLine.X2 = Point2.X;
                DrawLine.Y2 = Point2.Y;
            }
            else if (XZ_rb.Checked)
            {
                DrawLine.X1 = Point1.X;
                DrawLine.Z1 = Point1.Y;
                DrawLine.X2 = Point2.X;
                DrawLine.Z2 = Point2.Y;
            }
            else if (YZ_rb.Checked)
            {
                DrawLine.Z1 = Point1.X;
                DrawLine.Y1 = Point1.Y;
                DrawLine.Z2 = Point2.X;
                DrawLine.Y2 = Point2.Y;
            }

            DrawLine.GetRender();
            MyLines.Add(DrawLine);
            XY_rb_CheckedChanged(this, new EventArgs());
            isLineChosen = false;
            //DrawCase = "Line";
        }
        private void MouseUp_MoveLine(object sender, MouseEventArgs e)
        {
            if (MyLines.Count > 0)
            {
                LineList DrawLine;
                if (ChosenLineNumber >= 0)
                {
                    DrawLine = MyLines[ChosenLineNumber];
                    //DrawLine = new LineList(MyLines[ChosenLineNumber].pen);
                }
                else
                    DrawLine = new LineList();

                if (XY_rb.Checked)
                {
                    DrawLine.X1 = Point1.X;
                    DrawLine.Y1 = Point1.Y;
                    DrawLine.X2 = Point2.X;
                    DrawLine.Y2 = Point2.Y;
                }
                else if (XZ_rb.Checked)
                {
                    DrawLine.X1 = Point1.X;
                    DrawLine.Z1 = Point1.Y;
                    DrawLine.X2 = Point2.X;
                    DrawLine.Z2 = Point2.Y;
                }
                else if (YZ_rb.Checked)
                {
                    DrawLine.Z1 = Point1.X;
                    DrawLine.Y1 = Point1.Y;
                    DrawLine.Z2 = Point2.X;
                    DrawLine.Y2 = Point2.Y;
                }
                DrawLine.GetRender();
                MyLines.Add(DrawLine);

                if (ChosenLineNumber >= 0)
                {
                    MyLines.RemoveAt(ChosenLineNumber);
                }
                else
                {
                    MyLines.RemoveAt(MyLines.Count - 1);
                }
                XY_rb_CheckedChanged(this, new EventArgs());
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
                    DrawLine = MyLines[ChosenLineNumber];
                }
                else
                {
                    DrawLine = new LineList();
                    MyLines.Add(DrawLine);
                }


                if (XY_rb.Checked)
                {
                    DrawLine.X1 = Point1.X;
                    DrawLine.Y1 = Point1.Y;
                    DrawLine.X2 = Point2.X;
                    DrawLine.Y2 = Point2.Y;
                }
                else if (XZ_rb.Checked)
                {
                    DrawLine.X1 = Point1.X;
                    DrawLine.Z1 = Point1.Y;
                    DrawLine.X2 = Point2.X;
                    DrawLine.Z2 = Point2.Y;
                }
                else if (YZ_rb.Checked)
                {
                    DrawLine.Z1 = Point1.X;
                    DrawLine.Y1 = Point1.Y;
                    DrawLine.Z2 = Point2.X;
                    DrawLine.Y2 = Point2.Y;
                }

                DrawLine.GetRender();
                //MyLines.Add(DrawLine);

                /*if (ChosenLineNumber >= 0)
                    MyLines.RemoveAt(ChosenLineNumber);*/
                XY_rb_CheckedChanged(this, new EventArgs());
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

            isGroupChosen = false;
        }


        //Отрисовка линий после выполнения каждого режима
        private void pictureBox3_Paint(object sender, PaintEventArgs e)
        {
            Paint_Lines(e.Graphics);
            if (LineMode_RB.Checked)
            {
                pictureBox1.Image = bm;
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
        private void Paint_Lines(Graphics gr)
        {
            Random random = new Random();
            Pen dot_Color2 = new Pen(Color.Green, 3);
            Pen dot_Color = new Pen(Color.Blue, 3);
            Pen group_pen = new Pen(Color.Purple, 3);
            if (MyLines.Count > 0 && ChosenLineNumber >= 0)
            {
                //control.Text = MyLines[ChosenLineNumber].RenderX1.ToString() + " " + MyLines[ChosenLineNumber].RenderY1.ToString() + ";" + MyLines[ChosenLineNumber].RenderX2.ToString() + " " + MyLines[ChosenLineNumber].RenderY2.ToString();
            }


            if (LineMode_RB.Checked || Rubbish_rb.Checked)
            {
                int i, x1, y1, x2, y2;

                for (i = 0; i < MyLines.Count; i++)
                {
                    x1 = MyLines[i].RenderX1;
                    x2 = MyLines[i].RenderX2;
                    y1 = MyLines[i].RenderY1;
                    y2 = MyLines[i].RenderY2;
                    gr.DrawLine(MyLines[i].pen, x1, y1, x2, y2);
                    gr.DrawRectangle(dot_Color, x1, y1, 2, 2);
                    gr.DrawRectangle(dot_Color, x2, y2, 2, 2);
                }

                for (i = 0; i < toGroup.Count; i++)
                {
                    x1 = toGroup[i].RenderX1;
                    x2 = toGroup[i].RenderX2;
                    y1 = toGroup[i].RenderY1;
                    y2 = toGroup[i].RenderY2;
                    gr.DrawLine(group_pen, x1, y1, x2, y2);
                    gr.DrawRectangle(dot_Color2, x1, y1, 2, 2);
                    gr.DrawRectangle(dot_Color2, x2, y2, 2, 2);
                }

                if (MyGroups.Count > 0)
                {
                    for (i = 0; i < MyGroups.Count; i++)
                    {
                        for (int j = 0; j < MyGroups[i].Lines.Count; j++)
                        {

                            x1 = MyGroups[i].Lines[j].RenderX1;
                            x2 = MyGroups[i].Lines[j].RenderX2;
                            y1 = MyGroups[i].Lines[j].RenderY1;
                            y2 = MyGroups[i].Lines[j].RenderY2;
                            gr.DrawLine(MyGroups[i].Lines[j].pen, x1, y1, x2, y2);
                            gr.DrawRectangle(dot_Color2, x1, y1, 2, 2);
                            gr.DrawRectangle(dot_Color2, x2, y2, 2, 2);
                        }
                    }
                }

            }
        }
        private void PaintTMP()
        {
            Bitmap bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics gr = Graphics.FromImage(bm);
            
            Paint_Lines(gr);
            pictureBox1.Image = bm;
        }


        //Вспомогательные методы
        private int GetLine()
        {
            int line = -1;

            for (int i = 0; i < MyLines.Count; i++)
            {
                if (IsPointOnLine(CursorX, CursorY, MyLines[i].RenderX1, MyLines[i].RenderX2, MyLines[i].RenderY1, MyLines[i].RenderY2))
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

                    var x1 = MyGroups[i].Lines[j].RenderX1;
                    var x2 = MyGroups[i].Lines[j].RenderX2;
                    var y1 = MyGroups[i].Lines[j].RenderY1;
                    var y2 = MyGroups[i].Lines[j].RenderY2;

                    if (IsPointOnLine(CursorX, CursorY, x1, x2, y1, y2))
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
            int eps = 10;
            return Math.Abs(L(x, y, x1, y1) + L(x, y, x2, y2)
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
            if (toGroup.Count > 0)
            {
                color = toGroup[0].pen.Color;
            }
            Group tmp = new Group();

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
        /*private Point GetPointofGroup(Group gr)
        {
            Point point;
            int min_X1 = 10000, min_Y1 = 10000;
            int tmp_X, tmp_Y;
            foreach (var item in gr.Lines)
            {
                var FirstLong = Math.Sqrt(Math.Pow((item.X1 - 0), 2) + Math.Pow((item.Y1 - 0), 2));
                var SecondLong = Math.Sqrt(Math.Pow((item.X2 - 0), 2) + Math.Pow((item.Y2 - 0), 2));

                if (FirstLong < SecondLong)
                {
                    tmp_X = item.X1;
                    tmp_Y = item.Y1;
                }
                else
                {
                    tmp_X = item.X2;
                    tmp_Y = item.Y2;
                }
                FirstLong = Math.Sqrt(Math.Pow((min_X1 - 0), 2) + Math.Pow((min_Y1 - 0), 2));
                SecondLong = Math.Sqrt(Math.Pow((tmp_X - 0), 2) + Math.Pow((tmp_Y - 0), 2));
                if (FirstLong > SecondLong)
                {
                    min_X1 = tmp_X;
                    min_Y1 = tmp_Y;
                }
            }
            point = new Point(min_X1, min_Y1);
            return point;
        }
        private Point GetNewXY(Group gr)
        {
            Point point;
            int min_X1 = 10000, max_Y1 = -1;
            int tmp_X, tmp_Y;
            foreach (var item in gr.Lines)
            {
                if (item.Y1 > item.Y2)
                {
                    tmp_Y = item.Y1;
                }
                else
                {
                    tmp_Y = item.Y2;
                }
                if (tmp_Y > max_Y1)
                {
                    max_Y1 = tmp_Y;
                }
            }
            foreach (var item in gr.Lines)
            {
                if (item.X1 < item.X2)
                {
                    tmp_X = item.X1;
                }
                else
                {
                    tmp_X = item.X2;
                }
                if (tmp_X < min_X1)
                {
                    min_X1 = tmp_X;
                }
            }
            point = new Point(min_X1, max_Y1);
            return point;
        }*/
        private double GetSin(double angle)
        {
            double radian = angle * Math.PI / 180;
            double result = Math.Sin(radian);
            //result = Math.Round(result, 7);
            return result;
        }
        private double GetCos(double angle)
        {
            double radian = angle * Math.PI / 180;
            double result = Math.Cos(radian);
            //result = Math.Round(result, 7);
            return result;
        }
        private void MatrixMultX(Group lines)
        {
            double value = (double)value_angle.Value;
            FindCenter(lines, out int cx, out int cy, out int cz);
            var Sinus = GetSin(value);
            var Cosinus = GetCos(value);

            for (int i = 0; i < lines.Lines.Count; i++)
            {
                lines.Lines[i].Y1 -= cy;
                lines.Lines[i].Y2 -= cy;
                lines.Lines[i].Z1 -= cz;
                lines.Lines[i].Z2 -= cz;

                lines.Lines[i].RenderX1 = lines.Lines[i].Z1;
                lines.Lines[i].RenderX2 = lines.Lines[i].Z2;
                lines.Lines[i].RenderY1 = lines.Lines[i].Y1;
                lines.Lines[i].RenderY2 = lines.Lines[i].Y2;
            }

            for (int i = 0; i < lines.Lines.Count; i++)
            {
                int tmp_y1 = lines.Lines[i].Y1;
                int tmp_y2 = lines.Lines[i].Y2;

                lines.Lines[i].Y1 = (int)(lines.Lines[i].Y1 * Cosinus - lines.Lines[i].Z1 * Sinus);
                lines.Lines[i].Y2 = (int)(lines.Lines[i].Y2 * Cosinus - lines.Lines[i].Z2 * Sinus);
                lines.Lines[i].Z1 = (int)(tmp_y1 * Sinus + lines.Lines[i].Z1 * Cosinus);
                lines.Lines[i].Z2 = (int)(tmp_y2 * Sinus + lines.Lines[i].Z2 * Cosinus);

                lines.Lines[i].RenderX1 = lines.Lines[i].Z1;
                lines.Lines[i].RenderX2 = lines.Lines[i].Z2;
                lines.Lines[i].RenderY1 = lines.Lines[i].Y1;
                lines.Lines[i].RenderY2 = lines.Lines[i].Y2;
            }

            for (int i = 0; i < lines.Lines.Count; i++)
            {
                lines.Lines[i].Y1 += cy;
                lines.Lines[i].Y2 += cy;
                lines.Lines[i].Z1 += cz;
                lines.Lines[i].Z2 += cz;

                lines.Lines[i].RenderX1 = lines.Lines[i].Z1;
                lines.Lines[i].RenderX2 = lines.Lines[i].Z2;
                lines.Lines[i].RenderY1 = lines.Lines[i].Y1;
                lines.Lines[i].RenderY2 = lines.Lines[i].Y2;
            }
        }
        private void MatrixMultY(Group lines)
        {
            double value = (double)value_angle.Value;
            FindCenter(lines, out int cx, out int cy, out int cz);
            var Sinus = GetSin(value);
            var Cosinus = GetCos(value);

            for (int i = 0; i < lines.Lines.Count; i++)
            {
                lines.Lines[i].X1 -= cx;
                lines.Lines[i].X2 -= cx;
                lines.Lines[i].Z1 -= cz;
                lines.Lines[i].Z2 -= cz;

                lines.Lines[i].RenderX1 = lines.Lines[i].X1;
                lines.Lines[i].RenderX2 = lines.Lines[i].X2;
                lines.Lines[i].RenderY1 = lines.Lines[i].Z1;
                lines.Lines[i].RenderY2 = lines.Lines[i].Z2;
            }

            for (int i = 0; i < lines.Lines.Count; i++)
            {
                int tmp_x1 = lines.Lines[i].X1;
                int tmp_x2 = lines.Lines[i].X2;


                lines.Lines[i].X1 = (int)(lines.Lines[i].X1 * Cosinus + lines.Lines[i].Z1 * Sinus);
                lines.Lines[i].X2 = (int)(lines.Lines[i].X2 * Cosinus + lines.Lines[i].Z2 * Sinus);
                lines.Lines[i].Z1 = (int)(lines.Lines[i].Z1 * Cosinus - tmp_x1 * Sinus);
                lines.Lines[i].Z2 = (int)(lines.Lines[i].Z2 * Cosinus - tmp_x2 * Sinus);

                lines.Lines[i].RenderX1 = lines.Lines[i].X1;
                lines.Lines[i].RenderX2 = lines.Lines[i].X2;
                lines.Lines[i].RenderY1 = lines.Lines[i].Z1;
                lines.Lines[i].RenderY2 = lines.Lines[i].Z2;
            }

            for (int i = 0; i < lines.Lines.Count; i++)
            {
                lines.Lines[i].X1 += cx;
                lines.Lines[i].X2 += cx;
                lines.Lines[i].Z1 += cz;
                lines.Lines[i].Z2 += cz;

                lines.Lines[i].RenderX1 = lines.Lines[i].X1;
                lines.Lines[i].RenderX2 = lines.Lines[i].X2;
                lines.Lines[i].RenderY1 = lines.Lines[i].Z1;
                lines.Lines[i].RenderY2 = lines.Lines[i].Z2;
            }
        }
        private void MatrixMultZ(Group lines)
        {
            double value = (double)value_angle.Value;
            FindCenter(lines, out int cx, out int cy, out int cz);
            var Sinus = GetSin(value);
            var Cosinus = GetCos(value);

            for (int i = 0; i < lines.Lines.Count; i++)
            {
                lines.Lines[i].X1 -= cx;
                lines.Lines[i].X2 -= cx;
                lines.Lines[i].Y1 -= cy;
                lines.Lines[i].Y2 -= cy;
            }

            for (int i = 0; i < lines.Lines.Count; i++)
            {
                int tmp_x1 = lines.Lines[i].X1;
                int tmp_x2 = lines.Lines[i].X2;

                lines.Lines[i].X1 = (int)(lines.Lines[i].X1 * Cosinus - lines.Lines[i].Y1 * Sinus);
                lines.Lines[i].X2 = (int)(lines.Lines[i].X2 * Cosinus - lines.Lines[i].Y2 * Sinus);
                lines.Lines[i].Y1 = (int)(tmp_x1 * Sinus + lines.Lines[i].Y1 * Cosinus);
                lines.Lines[i].Y2 = (int)(tmp_x2 * Sinus + lines.Lines[i].Y2 * Cosinus);
            }

            for (int i = 0; i < lines.Lines.Count; i++)
            {
                lines.Lines[i].X1 += cx;
                lines.Lines[i].X2 += cx;
                lines.Lines[i].Y1 += cy;
                lines.Lines[i].Y2 += cy;

                lines.Lines[i].RenderX1 = lines.Lines[i].X1;
                lines.Lines[i].RenderX2 = lines.Lines[i].X2;
                lines.Lines[i].RenderY1 = lines.Lines[i].Y1;
                lines.Lines[i].RenderY2 = lines.Lines[i].Y2;
            }
        }
        private void MirrorXY(Group group)
        {
            FindCenter(group, out int cx, out int cy, out int cz);
            if (Y_mirror.Checked && X_mirror.Checked)
            {
                for (int i = 0; i < group.Lines.Count; i++)
                {
                    group.Lines[i].X1 = (group.Lines[i].X1 - cx) * (-1) + cx;
                    group.Lines[i].Y1 = (group.Lines[i].Y1 - cy) * (-1) + cy;
                    group.Lines[i].X2 = (group.Lines[i].X2 - cx) * (-1) + cx;
                    group.Lines[i].Y2 = (group.Lines[i].Y2 - cy) * (-1) + cy;
                }

                for (int i = 0; i < group.Lines.Count; i++)
                {
                    group.Lines[i].RenderX1 = group.Lines[i].X1;
                    group.Lines[i].RenderX2 = group.Lines[i].X2;
                    group.Lines[i].RenderY1 = group.Lines[i].Y1;
                    group.Lines[i].RenderY2 = group.Lines[i].Y2;
                }
            }
            else if (Y_mirror.Checked)
            {
                for (int i = 0; i < group.Lines.Count; i++)
                {
                    group.Lines[i].Y1 = (group.Lines[i].Y1 - cy) * (-1) + cy;
                    group.Lines[i].Y2 = (group.Lines[i].Y2 - cy) * (-1) + cy;
                }

                for (int i = 0; i < group.Lines.Count; i++)
                {
                    group.Lines[i].RenderY1 = group.Lines[i].Y1;
                    group.Lines[i].RenderY2 = group.Lines[i].Y2;
                }
            }
            else if (X_mirror.Checked)
            {
                for (int i = 0; i < group.Lines.Count; i++)
                {
                    group.Lines[i].X1 = (group.Lines[i].X1 - cx) * (-1) + cx;
                    group.Lines[i].X2 = (group.Lines[i].X2 - cx) * (-1) + cx;
                }

                for (int i = 0; i < group.Lines.Count; i++)
                {
                    group.Lines[i].RenderX1 = group.Lines[i].X1;
                    group.Lines[i].RenderX2 = group.Lines[i].X2;
                }
            }
        }
        private void MirrorXZ(Group group)
        {
            FindCenter(group, out int cx, out int cy, out int cz);
            if (Z_mirror.Checked && X_mirror.Checked)
            {
                for (int i = 0; i < group.Lines.Count; i++)
                {
                    group.Lines[i].X1 = (group.Lines[i].X1 - cx) * (-1) + cx;
                    group.Lines[i].Z1 = (group.Lines[i].Z1 - cz) * (-1) + cz;
                    group.Lines[i].X2 = (group.Lines[i].X2 - cx) * (-1) + cx;
                    group.Lines[i].Z2 = (group.Lines[i].Z2 - cz) * (-1) + cz;
                }

                for (int i = 0; i < group.Lines.Count; i++)
                {
                    group.Lines[i].RenderX1 = group.Lines[i].X1;
                    group.Lines[i].RenderX2 = group.Lines[i].X2;
                    group.Lines[i].RenderY1 = group.Lines[i].Z1;
                    group.Lines[i].RenderY2 = group.Lines[i].Z2;
                }
            }
            else if (Z_mirror.Checked)
            {
                for (int i = 0; i < group.Lines.Count; i++)
                {
                    group.Lines[i].Z1 = (group.Lines[i].Z1 - cz) * (-1) + cz;
                    group.Lines[i].Z2 = (group.Lines[i].Z2 - cz) * (-1) + cz;
                }

                for (int i = 0; i < group.Lines.Count; i++)
                {
                    group.Lines[i].RenderY1 = group.Lines[i].Z1;
                    group.Lines[i].RenderY2 = group.Lines[i].Z2;
                }
            }
            else if (X_mirror.Checked)
            {
                for (int i = 0; i < group.Lines.Count; i++)
                {
                    group.Lines[i].X1 = (group.Lines[i].X1 - cx) * (-1) + cx;
                    group.Lines[i].X2 = (group.Lines[i].X2 - cx) * (-1) + cx;
                }

                for (int i = 0; i < group.Lines.Count; i++)
                {
                    group.Lines[i].RenderX1 = group.Lines[i].X1;
                    group.Lines[i].RenderX2 = group.Lines[i].X2;
                }
            }
        }
        private void MirrorYZ(Group group)
        {
            FindCenter(group, out int cx, out int cy, out int cz);
            if (Z_mirror.Checked && Y_mirror.Checked)
            {
                for (int i = 0; i < group.Lines.Count; i++)
                {
                    group.Lines[i].Y1 = (group.Lines[i].Y1 - cy) * (-1) + cy;
                    group.Lines[i].Z1 = (group.Lines[i].Z1 - cz) * (-1) + cz;
                    group.Lines[i].Y2 = (group.Lines[i].Y2 - cy) * (-1) + cy;
                    group.Lines[i].Z2 = (group.Lines[i].Z2 - cz) * (-1) + cz;
                }

                for (int i = 0; i < group.Lines.Count; i++)
                {
                    group.Lines[i].RenderX1 = group.Lines[i].Z1;
                    group.Lines[i].RenderX2 = group.Lines[i].Z2;
                    group.Lines[i].RenderY1 = group.Lines[i].Y1;
                    group.Lines[i].RenderY2 = group.Lines[i].Y2;
                }
            }
            else if (Z_mirror.Checked)
            {
                for (int i = 0; i < group.Lines.Count; i++)
                {
                    group.Lines[i].Z1 = (group.Lines[i].Z1 - cz) * (-1) + cz;
                    group.Lines[i].Z2 = (group.Lines[i].Z2 - cz) * (-1) + cz;
                }

                for (int i = 0; i < group.Lines.Count; i++)
                {
                    group.Lines[i].RenderX1 = group.Lines[i].Z1;
                    group.Lines[i].RenderX2 = group.Lines[i].Z2;
                }
            }
            else if (Y_mirror.Checked)
            {
                for (int i = 0; i < group.Lines.Count; i++)
                {
                    group.Lines[i].Y1 = (group.Lines[i].Y1 - cy) * (-1) + cy;
                    group.Lines[i].Y2 = (group.Lines[i].Y2 - cy) * (-1) + cy;
                }

                for (int i = 0; i < group.Lines.Count; i++)
                {
                    group.Lines[i].RenderY1 = group.Lines[i].Y1;
                    group.Lines[i].RenderY2 = group.Lines[i].Y2;
                }
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
        private void SaveFile_ClickAsync(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {     
                if (pictureBox1.Image != null)
                {
                    var name = saveFileDialog1.FileName + "1.json";
                    pictureBox1.Image.Save(saveFileDialog1.FileName);

                    using (StreamWriter fs = new StreamWriter(name))
                    {
                        var str = JsonSerializer.Serialize<List<LineList>>(MyLines);
                        fs.Write(str);
                    }


                    var name2 = saveFileDialog1.FileName + "2.json";
                    using (StreamWriter fs2 = new StreamWriter(name2))
                    {
                        var str = JsonSerializer.Serialize<List<List<LineList>>>(MyGroups.Select(x => x.Lines).ToList());
                        fs2.Write(str);
                    }
                }
                
            }
        }
        private void Load_btn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {


                if (openFileDialog1.FileName != "")
                {
                    if (openFileDialog1.FileName.IndexOf("2.json") != -1)
                    {
                        using (FileStream fs2 = new FileStream(openFileDialog1.FileName, FileMode.OpenOrCreate))
                        {
                            MyGroups = JsonSerializer.Deserialize<List<List<LineList>>>(fs2).Select(x => new Group() { Lines = x }).ToList();
                        }
                    }
                    else
                    {
                        using (FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.OpenOrCreate))
                        {
                            MyLines = JsonSerializer.Deserialize<List<LineList>>(fs);
                        }
                    }                   
                    PaintTMP();
                }      
            }
        }



        //Выбор режима работы по нажатию ПКМ
        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toGroup.Clear();
            if (LineMode_RB.Checked)
            {
                CoordPanel.Visible = true;
                create_group.Visible = true;
                Check.Visible = true;
                StatusBar.Visible = true;
                flowLayoutPanel2.Visible = true;

                Scale.Visible = false;
                mirror_panel.Visible = false;
                DrawCase = "Line";
            }
        }
        private void CopyLineToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            toGroup.Clear();
            if (LineMode_RB.Checked)
            {
                CoordPanel.Visible = true;
                create_group.Visible = true;
                Check.Visible = true;
                StatusBar.Visible = true;
                flowLayoutPanel2.Visible = true;

                Scale.Visible = false;
                mirror_panel.Visible = false;
                DrawCase = "CopyLine";
            }
        }
        private void MoveLineToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            toGroup.Clear();
            if (LineMode_RB.Checked)
            {
                create_group.Visible = true;
                Check.Visible = true;
                StatusBar.Visible = true;
                flowLayoutPanel2.Visible = true;

                Scale.Visible = false;
                mirror_panel.Visible = false;
                DrawCase = "MoveLine";
            }
        }
        private void changeLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toGroup.Clear();
            if (LineMode_RB.Checked)
            {
                CoordPanel.Visible = true;
                create_group.Visible = true;
                Check.Visible = true;
                StatusBar.Visible = true;
                flowLayoutPanel2.Visible = true;

                Scale.Visible = false;
                mirror_panel.Visible = false;
                DrawCase = "ChangeLine";
            }
        }
        private void createGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LineMode_RB.Checked)
            {
                CoordPanel.Visible = true;
                create_group.Visible = true;
                Check.Visible = true;
                StatusBar.Visible = true;
                flowLayoutPanel2.Visible = true;

                Scale.Visible = false;
                mirror_panel.Visible = false;

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
                CoordPanel.Visible = false;


                Scale.Width = 240;
                mirror_panel.Width = 240;
                mirror_panel.Height = 80;
                Scale.Location = flowLayoutPanel2.Location;
                Scale.Visible = true;
                Scale.Height = 300;
                panel1.Controls.Add(Scale);


                //Масштабирование изображения
                value_number.Width = 65;
                value_number.DecimalPlaces = 1;
                value_number.Maximum = 2;
                value_number.Minimum = 0.5M;
                value_number.Increment = 0.1M;

                scale_picture.Text = "Изменить";
                scale_picture.Width = 150;
                scale_picture.Click += Scale_picture_Click;


                label.Text = "Масштабирование";
                label.Width = label1.Width;
                label.Font = new Font("Segoe UI Symbol", 12);
                label.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                label.TextAlign = ContentAlignment.MiddleCenter;

                Scale.Controls.Add(label);
                Scale.Controls.Add(value_number);
                Scale.Controls.Add(scale_picture);

                //Поворот изображения

                rotate_label.Text = "Поворот";
                rotate_label.Width = label1.Width;
                rotate_label.Font = new Font("Segoe UI Symbol", 12);
                rotate_label.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                rotate_label.TextAlign = ContentAlignment.MiddleCenter;

                value_angle.Width = 65;
                value_angle.DecimalPlaces = 0;
                value_angle.Maximum = 360;
                value_angle.Minimum = -360;
                value_angle.Increment = 5;

                rotate_picture.Width = 150;
                rotate_picture.Text = "Повернуть";
                rotate_picture.Click += Rotate_picture_Click;

                Scale.Controls.Add(rotate_label);
                Scale.Controls.Add(value_angle);
                Scale.Controls.Add(rotate_picture);

                //Зеркалирование изображения
                mirror_picture.Width = 210;

                mirror_picture.Text = "Отразить";
                mirror_picture.Click += Mirror_picture_Click;
                X_mirror.Width = 80;
                Y_mirror.Width = 80;
                Z_mirror.Width = 80;

                X_mirror.Text = "Отр. по Х";
                Y_mirror.Text = "Отр. по Y";
                Z_mirror.Text = "Отр. по Z";

                Scale.Controls.Add(Y_mirror);
                Scale.Controls.Add(X_mirror);
                Scale.Controls.Add(Z_mirror);
                Scale.Controls.Add(mirror_picture);
                //Scale.Controls.Add(mirror_panel);

                //Проецирование изображения

                q_lab.Font = new Font("Segoe UI Symbol", 12);
                p_lab.Font = new Font("Segoe UI Symbol", 12);
                q_lab.Text = "Коэф. Q";
                p_lab.Text = "Коэф. P";
                project_picture.Width = 210;
                project_picture.Text = "Проецировать";
                project_picture.Click += Project_picture_Click1;
                p_koef.DecimalPlaces = 1;
                p_koef.Maximum = 2;
                p_koef.Minimum = 0.1M;
                p_koef.Increment = 0.1M;
                q_koef.DecimalPlaces = 1;
                q_koef.Maximum = 2;
                q_koef.Minimum = 0.1M;
                q_koef.Increment = 0.1M;
                Scale.Controls.Add(p_koef);
                Scale.Controls.Add(p_lab);
                Scale.Controls.Add(q_koef);
                Scale.Controls.Add(q_lab);
                Scale.Controls.Add(project_picture);

                Ungroup.Width = 210;
                Ungroup.Text = "Разгруппировать";
                Ungroup.Click += Ungroup_Click;
                Scale.Controls.Add(Ungroup);
            }
        }


        private void Ungroup_Click(object? sender, EventArgs e)
        {
            if (ChosenGroupNumber > -1 && ChosenGroupNumber < MyGroups.Count)
            {
                for (int i = 0; i < MyGroups[ChosenGroupNumber].Lines.Count; i++)
                {
                    MyLines.Add(MyGroups[ChosenGroupNumber].Lines[i]);
                }

                MyGroups.Remove(MyGroups[ChosenGroupNumber]);

                if (MyGroups.Count == 0)
                {
                    ChosenGroupNumber = -1;
                }
            }
        }
        private void Project_picture_Click1(object? sender, EventArgs e)
        {
            if (ChosenGroupNumber > -1)
            {
                FindCenter(MyGroups[ChosenGroupNumber], out int cx, out int cy, out int cz);

                for (int i = 0; i < MyGroups[ChosenGroupNumber].Lines.Count; i++)
                {
                    var tmp_x1 = (int)(MyGroups[ChosenGroupNumber].Lines[i].X1 - cx);
                    var tmp_y1 = (int)(MyGroups[ChosenGroupNumber].Lines[i].Y1 - cy);
                    var tmp_x2 = (int)(MyGroups[ChosenGroupNumber].Lines[i].X2 - cx);
                    var tmp_y2 = (int)(MyGroups[ChosenGroupNumber].Lines[i].Y2 - cy);

                    double value1 = (double)1.0 / (tmp_x1 * (double)p_koef.Value + tmp_y1 * (double)q_koef.Value);
                    double value2 = (double)1.0 / (tmp_x2 * (double)p_koef.Value + tmp_y2 * (double)q_koef.Value);

                    MyGroups[ChosenGroupNumber].Lines[i].X1 = (int)(tmp_x1 * value1 + cx);
                    MyGroups[ChosenGroupNumber].Lines[i].X2 = (int)(tmp_x2 * value2 + cx);
                    MyGroups[ChosenGroupNumber].Lines[i].Y1 = (int)(tmp_y1 * value1 + cy);
                    MyGroups[ChosenGroupNumber].Lines[i].Y2 = (int)(tmp_y2 * value2 + cy);

                }
            }
        }
        private void Mirror_picture_Click(object? sender, EventArgs e)
        {
            if (ChosenGroupNumber > -1)
            {
                if (xyz_str == "yz")
                {
                    MirrorYZ(MyGroups[ChosenGroupNumber]);
                }
                else if (xyz_str == "xy")
                {
                    MirrorXY(MyGroups[ChosenGroupNumber]);
                }
                else if (xyz_str == "xz")
                {
                    MirrorXZ(MyGroups[ChosenGroupNumber]);
                }
            }
        }
        private void Rotate_picture_Click(object? sender, EventArgs e)
        {
            if (ChosenGroupNumber > -1)
            {
                if (xyz_str == "yz") MatrixMultX(MyGroups[ChosenGroupNumber]);
                else if (xyz_str == "xy") MatrixMultZ(MyGroups[ChosenGroupNumber]);
                else if (xyz_str == "xz") MatrixMultY(MyGroups[ChosenGroupNumber]);
            }
        }
        private void Scale_picture_Click(object? sender, EventArgs e)
        {
            if (ChosenGroupNumber > -1)
            {
                FindCenter(MyGroups[ChosenGroupNumber], out int cx, out int cy, out int cz);
                double value = (double)value_number.Value;

                for (int i = 0; i < MyGroups[ChosenGroupNumber].Lines.Count; i++)
                {
                    MyGroups[ChosenGroupNumber].Lines[i].X1 = (int)((MyGroups[ChosenGroupNumber].Lines[i].X1 - cx) * value + cx);
                    MyGroups[ChosenGroupNumber].Lines[i].X2 = (int)((MyGroups[ChosenGroupNumber].Lines[i].X2 - cx) * value + cx);
                    MyGroups[ChosenGroupNumber].Lines[i].Y1 = (int)((MyGroups[ChosenGroupNumber].Lines[i].Y1 - cy) * value + cy);
                    MyGroups[ChosenGroupNumber].Lines[i].Y2 = (int)((MyGroups[ChosenGroupNumber].Lines[i].Y2 - cy) * value + cy);
                    MyGroups[ChosenGroupNumber].Lines[i].Z1 = (int)((MyGroups[ChosenGroupNumber].Lines[i].Z1 - cz) * value + cz);
                    MyGroups[ChosenGroupNumber].Lines[i].Z2 = (int)((MyGroups[ChosenGroupNumber].Lines[i].Z2 - cz) * value + cz);
                }
                XY_rb_CheckedChanged(sender, e);
                PaintTMP();
            }
        }


        private void moveGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LineMode_RB.Checked)
            {
                DrawCase = "MoveGroup";
            }
        }
        private void XY_rb_CheckedChanged(object sender, EventArgs e)
        {
            if (XY_rb.Checked)
            {
                xyz_str = "xy";
                X_mirror.Enabled = true;
                Y_mirror.Enabled = true;
                Z_mirror.Enabled = false;
                for (int i = 0; i < MyLines.Count; i++)
                {
                    MyLines[i].RenderX1 = MyLines[i].X1;
                    MyLines[i].RenderX2 = MyLines[i].X2;
                    MyLines[i].RenderY1 = MyLines[i].Y1;
                    MyLines[i].RenderY2 = MyLines[i].Y2;
                }
                for (int i = 0; i < MyGroups.Count; i++)
                {
                    for (int j = 0; j < MyGroups[i].Lines.Count; j++)
                    {
                        MyGroups[i].Lines[j].RenderX1 = MyGroups[i].Lines[j].X1;
                        MyGroups[i].Lines[j].RenderX2 = MyGroups[i].Lines[j].X2;
                        MyGroups[i].Lines[j].RenderY1 = MyGroups[i].Lines[j].Y1;
                        MyGroups[i].Lines[j].RenderY2 = MyGroups[i].Lines[j].Y2;
                    }
                }
            }
            else if (XZ_rb.Checked)
            {
                xyz_str = "xz";
                X_mirror.Enabled = true;
                Y_mirror.Enabled = false;
                Z_mirror.Enabled = true;
                for (int i = 0; i < MyLines.Count; i++)
                {
                    MyLines[i].RenderX1 = MyLines[i].X1;
                    MyLines[i].RenderX2 = MyLines[i].X2;
                    MyLines[i].RenderY1 = MyLines[i].Z1;
                    MyLines[i].RenderY2 = MyLines[i].Z2;
                }
                for (int i = 0; i < MyGroups.Count; i++)
                {
                    for (int j = 0; j < MyGroups[i].Lines.Count; j++)
                    {
                        MyGroups[i].Lines[j].RenderX1 = MyGroups[i].Lines[j].X1;
                        MyGroups[i].Lines[j].RenderX2 = MyGroups[i].Lines[j].X2;
                        MyGroups[i].Lines[j].RenderY1 = MyGroups[i].Lines[j].Z1;
                        MyGroups[i].Lines[j].RenderY2 = MyGroups[i].Lines[j].Z2;
                    }
                }
            }
            else if (YZ_rb.Checked)
            {
                xyz_str = "yz";
                X_mirror.Enabled = false;
                Y_mirror.Enabled = true;
                Z_mirror.Enabled = true;
                for (int i = 0; i < MyLines.Count; i++)
                {
                    MyLines[i].RenderX1 = MyLines[i].Z1;
                    MyLines[i].RenderX2 = MyLines[i].Z2;
                    MyLines[i].RenderY1 = MyLines[i].Y1;
                    MyLines[i].RenderY2 = MyLines[i].Y2;
                }

                for (int i = 0; i < MyGroups.Count; i++)
                {
                    for (int j = 0; j < MyGroups[i].Lines.Count; j++)
                    {
                        MyGroups[i].Lines[j].RenderX1 = MyGroups[i].Lines[j].Z1;
                        MyGroups[i].Lines[j].RenderX2 = MyGroups[i].Lines[j].Z2;
                        MyGroups[i].Lines[j].RenderY1 = MyGroups[i].Lines[j].Y1;
                        MyGroups[i].Lines[j].RenderY2 = MyGroups[i].Lines[j].Y2;
                    }
                }
            }
        }
        private void FindCenter(Group grp, out int cx, out int cy, out int cz)
        {
            int maxX = -1000, maxY = -1000, maxZ = -1000;
            int minX = 10000, minY = 10000, minZ = 10000;


            for (int i = 0; i < grp.Lines.Count(); i++)
            {
                var ln = grp.Lines[i];
                More(ln.X1, ln.Y1, ln.Z1, ref maxX, ref maxY, ref maxZ);
                More(ln.X2, ln.Y2, ln.Z2, ref maxX, ref maxY, ref maxZ);
                Less(ln.X1, ln.Y1, ln.Z1, ref minX, ref minY, ref minZ);
                Less(ln.X2, ln.Y2, ln.Z2, ref minX, ref minY, ref minZ);
            }

            cx = (minX + maxX) / 2;
            cy = (minY + maxY) / 2;
            cz = (minZ + maxZ) / 2;
        }
        private void More(int x, int y, int z, ref int maxX, ref int maxY, ref int maxZ)
        {
            if (x > maxX) maxX = x;
            if (y > maxY) maxY = y;
            if (z > maxZ) maxZ = z;
        }
        private void Less(int x, int y, int z, ref int minX, ref int minY, ref int minZ)
        {
            if (x < minX) minX = x;
            if (y < minY) minY = y;
            if (z < minZ) minZ = z;
        }
        private void TrimParams_Click(object sender, EventArgs e)
        {
            if (ChosenGroupNumber > -1)
            {               
                Trimetria form = new Trimetria();            
                form.ShowDialog();
                PhiCorner = form.Phi_corner;
                TettaCorner = form.Tetta_corner;
                Viewer = form.viewer;
                Trimetria(MyGroups[ChosenGroupNumber], PhiCorner, TettaCorner, Viewer);
                PaintTMP();
            }
            
        }
        private void Trimetria(Group lines, int phi, int tetta, double view)
        {
            double CosinusPhi = GetCos(phi);
            double SinusPhi = GetSin(phi);

            double CosinusTet = GetCos(tetta);
            double SinusTet = GetSin(tetta);

            view = 1 / view;
            for (int i = 0; i < lines.Lines.Count; i++)
            {
                int tmpX1 = lines.Lines[i].X1;
                int tmpX2 = lines.Lines[i].X2;
                lines.Lines[i].X1 = (int)(lines.Lines[i].X1 * CosinusPhi + lines.Lines[i].Z1 * SinusPhi);
                lines.Lines[i].X2 = (int)(lines.Lines[i].X2 * CosinusPhi + lines.Lines[i].Z2 * SinusPhi);
                lines.Lines[i].Z1 = (int)(lines.Lines[i].Z1 * CosinusPhi - tmpX1 * SinusPhi);
                lines.Lines[i].Z2 = (int)(lines.Lines[i].Z2 * CosinusPhi - tmpX2 * SinusPhi);

                lines.Lines[i].RenderX1 = lines.Lines[i].X1;
                lines.Lines[i].RenderX2 = lines.Lines[i].X2;
                lines.Lines[i].RenderY1 = lines.Lines[i].Z1;
                lines.Lines[i].RenderY2 = lines.Lines[i].Z2;
            }

            for (int i = 0; i < lines.Lines.Count; i++)
            {
                int tmpY1 = lines.Lines[i].Y1;
                int tmpY2 = lines.Lines[i].Y2;

                lines.Lines[i].Y1 = (int)(lines.Lines[i].Y1 * CosinusTet - lines.Lines[i].Z1 * SinusTet);
                lines.Lines[i].Y2 = (int)(lines.Lines[i].Y2 * CosinusTet - lines.Lines[i].Z2 * SinusTet);
                lines.Lines[i].Z1 = (int)(tmpY1 * SinusTet + lines.Lines[i].Z1 * CosinusTet);
                lines.Lines[i].Z2 = (int)(tmpY2 * SinusTet + lines.Lines[i].Z2 * CosinusTet);

                lines.Lines[i].RenderX1 = lines.Lines[i].Z1;
                lines.Lines[i].RenderX2 = lines.Lines[i].Z2;
                lines.Lines[i].RenderY1 = lines.Lines[i].Y1;
                lines.Lines[i].RenderY2 = lines.Lines[i].Y2;
            }

            for (int i = 0; i < lines.Lines.Count; i++)
            {
                var znam1 = lines.Lines[i].Z1 * view;
                var znam2 = lines.Lines[i].Z2 * view;

                lines.Lines[i].X1 = (int) (lines.Lines[i].X1 / znam1);
                lines.Lines[i].X2 = (int) (lines.Lines[i].X2 / znam2);
                lines.Lines[i].Y1 = (int) (lines.Lines[i].Y1 / znam1);
                lines.Lines[i].Y2 = (int) (lines.Lines[i].Y2 / znam2);
                lines.Lines[i].Z1 = 0;
                lines.Lines[i].Z2 = 0;

                lines.Lines[i].RenderX1 = (int)(lines.Lines[i].X1 / znam1);
                lines.Lines[i].RenderX2 = (int)(lines.Lines[i].X2 / znam2);
                lines.Lines[i].RenderY1 = (int)(lines.Lines[i].Y1 / znam1);
                lines.Lines[i].RenderY2 = (int)(lines.Lines[i].Y2 / znam2);
            }
        }
  
    }
}