namespace CompGraph
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);


            
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button5 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.DrawMode_rb = new System.Windows.Forms.RadioButton();
            this.LineMode_RB = new System.Windows.Forms.RadioButton();
            this.CursorX_tb = new System.Windows.Forms.TextBox();
            this.CursorY_tb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Load_btn = new System.Windows.Forms.Button();
            this.TrimParams = new System.Windows.Forms.Button();
            this.CoordPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.XZ_rb = new System.Windows.Forms.RadioButton();
            this.YZ_rb = new System.Windows.Forms.RadioButton();
            this.XY_rb = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.create_group = new System.Windows.Forms.Button();
            this.Check = new System.Windows.Forms.TextBox();
            this.StatusBar = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.Rubbish_rb = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.panel1.SuspendLayout();
            this.CoordPanel.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(943, 688);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox3_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox3_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox3_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox3_MouseUp);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lineToolStripMenuItem,
            this.copyLineToolStripMenuItem,
            this.moveLineToolStripMenuItem,
            this.changeLineToolStripMenuItem,
            this.createGroupToolStripMenuItem,
            this.changeGroupToolStripMenuItem,
            this.moveGroupToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 158);
            // 
            // lineToolStripMenuItem
            // 
            this.lineToolStripMenuItem.Name = "lineToolStripMenuItem";
            this.lineToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.lineToolStripMenuItem.Text = "Line";
            this.lineToolStripMenuItem.Click += new System.EventHandler(this.lineToolStripMenuItem_Click);
            // 
            // copyLineToolStripMenuItem
            // 
            this.copyLineToolStripMenuItem.Name = "copyLineToolStripMenuItem";
            this.copyLineToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.copyLineToolStripMenuItem.Text = "CopyLine";
            this.copyLineToolStripMenuItem.Click += new System.EventHandler(this.CopyLineToolStripMenuItem2_Click);
            // 
            // moveLineToolStripMenuItem
            // 
            this.moveLineToolStripMenuItem.Name = "moveLineToolStripMenuItem";
            this.moveLineToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.moveLineToolStripMenuItem.Text = "MoveLine";
            this.moveLineToolStripMenuItem.Click += new System.EventHandler(this.MoveLineToolStripMenuItem3_Click);
            // 
            // changeLineToolStripMenuItem
            // 
            this.changeLineToolStripMenuItem.Name = "changeLineToolStripMenuItem";
            this.changeLineToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.changeLineToolStripMenuItem.Text = "ChangeLine";
            this.changeLineToolStripMenuItem.Click += new System.EventHandler(this.changeLineToolStripMenuItem_Click);
            // 
            // createGroupToolStripMenuItem
            // 
            this.createGroupToolStripMenuItem.Name = "createGroupToolStripMenuItem";
            this.createGroupToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.createGroupToolStripMenuItem.Text = "CreateGroup";
            this.createGroupToolStripMenuItem.Click += new System.EventHandler(this.createGroupToolStripMenuItem_Click);
            // 
            // changeGroupToolStripMenuItem
            // 
            this.changeGroupToolStripMenuItem.Name = "changeGroupToolStripMenuItem";
            this.changeGroupToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.changeGroupToolStripMenuItem.Text = "ChangeGroup";
            this.changeGroupToolStripMenuItem.Click += new System.EventHandler(this.changeGroupToolStripMenuItem_Click);
            // 
            // moveGroupToolStripMenuItem
            // 
            this.moveGroupToolStripMenuItem.Name = "moveGroupToolStripMenuItem";
            this.moveGroupToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.moveGroupToolStripMenuItem.Text = "MoveGroup";
            this.moveGroupToolStripMenuItem.Click += new System.EventHandler(this.moveGroupToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 32);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.ChangeColor_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ClearButton.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ClearButton.Location = new System.Drawing.Point(0, 602);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(258, 46);
            this.ClearButton.TabIndex = 3;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.button5);
            this.flowLayoutPanel1.Controls.Add(this.button7);
            this.flowLayoutPanel1.Controls.Add(this.button8);
            this.flowLayoutPanel1.Controls.Add(this.button9);
            this.flowLayoutPanel1.Controls.Add(this.button13);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(239, 42);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Black;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(41, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(32, 32);
            this.button5.TabIndex = 3;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.ChangeColor_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Lime;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Location = new System.Drawing.Point(79, 3);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(32, 32);
            this.button7.TabIndex = 5;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.ChangeColor_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Blue;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Location = new System.Drawing.Point(117, 3);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(32, 32);
            this.button8.TabIndex = 6;
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.ChangeColor_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Location = new System.Drawing.Point(155, 3);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(32, 32);
            this.button9.TabIndex = 7;
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.ChangeColor_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(193, 3);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(40, 32);
            this.button13.TabIndex = 11;
            this.button13.Text = "Add";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.NewColor_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label1);
            this.flowLayoutPanel2.Controls.Add(this.trackBar1);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(6, 101);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(242, 78);
            this.flowLayoutPanel2.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Толщина";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBar1
            // 
            this.trackBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.trackBar1.Location = new System.Drawing.Point(3, 24);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(225, 45);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // DrawMode_rb
            // 
            this.DrawMode_rb.AutoSize = true;
            this.DrawMode_rb.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DrawMode_rb.Location = new System.Drawing.Point(3, 3);
            this.DrawMode_rb.Name = "DrawMode_rb";
            this.DrawMode_rb.Size = new System.Drawing.Size(154, 24);
            this.DrawMode_rb.TabIndex = 6;
            this.DrawMode_rb.TabStop = true;
            this.DrawMode_rb.Text = "Режим рисования";
            this.DrawMode_rb.UseVisualStyleBackColor = true;
            // 
            // LineMode_RB
            // 
            this.LineMode_RB.AutoSize = true;
            this.LineMode_RB.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LineMode_RB.Location = new System.Drawing.Point(3, 33);
            this.LineMode_RB.Name = "LineMode_RB";
            this.LineMode_RB.Size = new System.Drawing.Size(133, 24);
            this.LineMode_RB.TabIndex = 7;
            this.LineMode_RB.TabStop = true;
            this.LineMode_RB.Text = "Режим прямых";
            this.LineMode_RB.UseVisualStyleBackColor = true;
            // 
            // CursorX_tb
            // 
            this.CursorX_tb.Dock = System.Windows.Forms.DockStyle.Left;
            this.CursorX_tb.Location = new System.Drawing.Point(3, 26);
            this.CursorX_tb.Name = "CursorX_tb";
            this.CursorX_tb.ReadOnly = true;
            this.CursorX_tb.Size = new System.Drawing.Size(125, 23);
            this.CursorX_tb.TabIndex = 8;
            this.CursorX_tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CursorY_tb
            // 
            this.CursorY_tb.Dock = System.Windows.Forms.DockStyle.Right;
            this.CursorY_tb.Location = new System.Drawing.Point(134, 26);
            this.CursorY_tb.Name = "CursorY_tb";
            this.CursorY_tb.ReadOnly = true;
            this.CursorY_tb.Size = new System.Drawing.Size(114, 23);
            this.CursorY_tb.TabIndex = 9;
            this.CursorY_tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(245, 23);
            this.label2.TabIndex = 10;
            this.label2.Text = "Координаты мыши";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Load_btn);
            this.panel1.Controls.Add(this.TrimParams);
            this.panel1.Controls.Add(this.CoordPanel);
            this.panel1.Controls.Add(this.flowLayoutPanel3);
            this.panel1.Controls.Add(this.create_group);
            this.panel1.Controls.Add(this.Check);
            this.panel1.Controls.Add(this.StatusBar);
            this.panel1.Controls.Add(this.flowLayoutPanel4);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.flowLayoutPanel2);
            this.panel1.Controls.Add(this.ClearButton);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(685, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(258, 688);
            this.panel1.TabIndex = 11;
            // 
            // Load_btn
            // 
            this.Load_btn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Load_btn.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Load_btn.Location = new System.Drawing.Point(0, 556);
            this.Load_btn.Name = "Load_btn";
            this.Load_btn.Size = new System.Drawing.Size(258, 46);
            this.Load_btn.TabIndex = 21;
            this.Load_btn.Text = "Load";
            this.Load_btn.UseVisualStyleBackColor = true;
            this.Load_btn.Click += new System.EventHandler(this.Load_btn_Click);
            // 
            // TrimParams
            // 
            this.TrimParams.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TrimParams.Location = new System.Drawing.Point(6, 60);
            this.TrimParams.Name = "TrimParams";
            this.TrimParams.Size = new System.Drawing.Size(242, 35);
            this.TrimParams.TabIndex = 19;
            this.TrimParams.Text = "Триметрия";
            this.TrimParams.UseVisualStyleBackColor = true;
            this.TrimParams.Click += new System.EventHandler(this.TrimParams_Click);
            // 
            // CoordPanel
            // 
            this.CoordPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CoordPanel.Controls.Add(this.XZ_rb);
            this.CoordPanel.Controls.Add(this.YZ_rb);
            this.CoordPanel.Controls.Add(this.XY_rb);
            this.CoordPanel.Location = new System.Drawing.Point(3, 372);
            this.CoordPanel.Name = "CoordPanel";
            this.CoordPanel.Size = new System.Drawing.Size(238, 39);
            this.CoordPanel.TabIndex = 18;
            // 
            // XZ_rb
            // 
            this.XZ_rb.AutoSize = true;
            this.XZ_rb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.XZ_rb.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.XZ_rb.Location = new System.Drawing.Point(3, 3);
            this.XZ_rb.Name = "XZ_rb";
            this.XZ_rb.Size = new System.Drawing.Size(45, 24);
            this.XZ_rb.TabIndex = 16;
            this.XZ_rb.TabStop = true;
            this.XZ_rb.Text = "XZ";
            this.XZ_rb.UseVisualStyleBackColor = true;
            this.XZ_rb.CheckedChanged += new System.EventHandler(this.XY_rb_CheckedChanged);
            // 
            // YZ_rb
            // 
            this.YZ_rb.AutoSize = true;
            this.YZ_rb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.YZ_rb.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.YZ_rb.Location = new System.Drawing.Point(54, 3);
            this.YZ_rb.Name = "YZ_rb";
            this.YZ_rb.Size = new System.Drawing.Size(44, 24);
            this.YZ_rb.TabIndex = 17;
            this.YZ_rb.TabStop = true;
            this.YZ_rb.Text = "YZ";
            this.YZ_rb.UseVisualStyleBackColor = true;
            this.YZ_rb.CheckedChanged += new System.EventHandler(this.XY_rb_CheckedChanged);
            // 
            // XY_rb
            // 
            this.XY_rb.AutoSize = true;
            this.XY_rb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.XY_rb.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.XY_rb.Location = new System.Drawing.Point(104, 3);
            this.XY_rb.Name = "XY_rb";
            this.XY_rb.Size = new System.Drawing.Size(44, 24);
            this.XY_rb.TabIndex = 15;
            this.XY_rb.TabStop = true;
            this.XY_rb.Text = "XY";
            this.XY_rb.UseVisualStyleBackColor = true;
            this.XY_rb.CheckedChanged += new System.EventHandler(this.XY_rb_CheckedChanged);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.label2);
            this.flowLayoutPanel3.Controls.Add(this.CursorX_tb);
            this.flowLayoutPanel3.Controls.Add(this.CursorY_tb);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 417);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(251, 56);
            this.flowLayoutPanel3.TabIndex = 11;
            // 
            // create_group
            // 
            this.create_group.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.create_group.Location = new System.Drawing.Point(6, 276);
            this.create_group.Name = "create_group";
            this.create_group.Size = new System.Drawing.Size(242, 35);
            this.create_group.TabIndex = 14;
            this.create_group.Text = "Создать группу";
            this.create_group.UseVisualStyleBackColor = true;
            this.create_group.Click += new System.EventHandler(this.create_group_Click);
            // 
            // Check
            // 
            this.Check.Location = new System.Drawing.Point(6, 317);
            this.Check.Name = "Check";
            this.Check.Size = new System.Drawing.Size(242, 23);
            this.Check.TabIndex = 13;
            // 
            // StatusBar
            // 
            this.StatusBar.Location = new System.Drawing.Point(6, 346);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(242, 23);
            this.StatusBar.TabIndex = 13;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.DrawMode_rb);
            this.flowLayoutPanel4.Controls.Add(this.LineMode_RB);
            this.flowLayoutPanel4.Controls.Add(this.Rubbish_rb);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(3, 476);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(251, 74);
            this.flowLayoutPanel4.TabIndex = 12;
            // 
            // Rubbish_rb
            // 
            this.Rubbish_rb.AutoSize = true;
            this.Rubbish_rb.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Rubbish_rb.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Rubbish_rb.Location = new System.Drawing.Point(142, 33);
            this.Rubbish_rb.Name = "Rubbish_rb";
            this.Rubbish_rb.Size = new System.Drawing.Size(74, 24);
            this.Rubbish_rb.TabIndex = 12;
            this.Rubbish_rb.TabStop = true;
            this.Rubbish_rb.Text = "Ластик";
            this.Rubbish_rb.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.Location = new System.Drawing.Point(0, 648);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(258, 40);
            this.button2.TabIndex = 2;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.SaveFile_ClickAsync);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(943, 688);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.CoordPanel.ResumeLayout(false);
            this.CoordPanel.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem lineToolStripMenuItem;
        private ToolStripMenuItem copyLineToolStripMenuItem;
        private ToolStripMenuItem moveLineToolStripMenuItem;
        private Button button1;
        private Button ClearButton;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button button5;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button13;
        private FlowLayoutPanel flowLayoutPanel2;
        private TrackBar trackBar1;
        private Label label1;
        private RadioButton DrawMode_rb;
        private RadioButton LineMode_RB;
        private TextBox CursorX_tb;
        private TextBox CursorY_tb;
        private Label label2;
        private ColorDialog colorDialog1;
        private SaveFileDialog saveFileDialog1;
        private Panel panel1;
        private FlowLayoutPanel flowLayoutPanel3;
        private FlowLayoutPanel flowLayoutPanel4;
        private TextBox StatusBar;
        private ToolStripMenuItem changeLineToolStripMenuItem;
        private TextBox Check;
        private ToolStripMenuItem createGroupToolStripMenuItem;
        private Button create_group;
        private ToolStripMenuItem changeGroupToolStripMenuItem;
        private ToolStripMenuItem moveGroupToolStripMenuItem;
        private RadioButton Rubbish_rb;
        private RadioButton YZ_rb;
        private RadioButton XZ_rb;
        private RadioButton XY_rb;
        private FlowLayoutPanel CoordPanel;
        private Button TrimParams;
        private Button Load_btn;
        private Button button2;
    }
}