namespace VbPowerPacksShapeEventsCS
{
    partial class ShapeEvents
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.ovalShape1 = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.rectangleShape2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape2,
            this.lineShape1,
            this.rectangleShape1,
            this.ovalShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(691, 500);
            this.shapeContainer1.TabIndex = 0;
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.ContextMenuStrip = this.contextMenuStrip1;
            this.rectangleShape1.Location = new System.Drawing.Point(28, 31);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(103, 189);
            this.rectangleShape1.Enter += new System.EventHandler(this.rectangleShape1_Enter);
            this.rectangleShape1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Shapes_KeyDown);
            this.rectangleShape1.DoubleClick += new System.EventHandler(this.rectangleShape1_DoubleClick);
            this.rectangleShape1.MouseHover += new System.EventHandler(this.rectangleShape1_MouseHover);
            this.rectangleShape1.EnabledChanged += new System.EventHandler(this.rectangleShape1_EnabledChanged);
            this.rectangleShape1.MouseEnter += new System.EventHandler(this.rectangleShape1_MouseEnter);
            this.rectangleShape1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rectangleShape1_KeyPress);
            this.rectangleShape1.LostFocus += new System.EventHandler(this.rectangleShape1_LostFocus);
            this.rectangleShape1.Leave += new System.EventHandler(this.rectangleShape1_Leave);
            this.rectangleShape1.MouseLeave += new System.EventHandler(this.rectangleShape1_MouseLeave);
            this.rectangleShape1.CursorChanged += new System.EventHandler(this.rectangleShape1_CursorChanged);
            this.rectangleShape1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rectangleShape1_MouseMove);
            this.rectangleShape1.ContextMenuChanged += new System.EventHandler(this.rectangleShape1_ContextMenuChanged);
            this.rectangleShape1.ContextMenuStripChanged += new System.EventHandler(this.rectangleShape1_ContextMenuStripChanged);
            this.rectangleShape1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.rectangleShape1_MouseWheel);
            this.rectangleShape1.Click += new System.EventHandler(this.rectangleShape1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(691, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(78, 22);
            this.toolStripStatusLabel1.Text = "toolStripLabel1";
            // 
            // ovalShape1
            // 
            this.ovalShape1.Location = new System.Drawing.Point(87, 126);
            this.ovalShape1.Name = "ovalShape1";
            this.ovalShape1.Size = new System.Drawing.Size(103, 168);
            this.ovalShape1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Shapes_KeyDown);
            this.ovalShape1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ovalShape1_MouseClick);
            this.ovalShape1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ovalShape1_KeyUp);
            this.ovalShape1.VisibleChanged += new System.EventHandler(this.ovalShape1_VisibleChanged);
            this.ovalShape1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.ovalShape1_PreviewKeyDown);
            this.ovalShape1.Move += new System.EventHandler(this.ovalShape1_Move);
            this.ovalShape1.RegionChanged += new System.EventHandler(this.ovalShape1_RegionChanged);
            this.ovalShape1.ParentChanged += new System.EventHandler(this.ovalShape1_ParentChanged);
            this.ovalShape1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ovalShape1_MouseDoubleClick);
            // 
            // lineShape1
            // 
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 305;
            this.lineShape1.X2 = 423;
            this.lineShape1.Y1 = 42;
            this.lineShape1.Y2 = 220;
            this.lineShape1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Shapes_KeyDown);
            // 
            // rectangleShape2
            // 
            this.rectangleShape2.Location = new System.Drawing.Point(321, 252);
            this.rectangleShape2.Name = "rectangleShape2";
            this.rectangleShape2.Size = new System.Drawing.Size(317, 216);
            this.rectangleShape2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rectangleShape2_MouseDown);
            this.rectangleShape2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rectangleShape2_MouseUp);
            this.rectangleShape2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rectangleShape2_MouseMove);
            this.rectangleShape2.Paint += new System.Windows.Forms.PaintEventHandler(this.rectangleShape2_Paint);
            // 
            // ShapeEvents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 500);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.shapeContainer1);
            this.Name = "ShapeEvents";
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripStatusLabel1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private Microsoft.VisualBasic.PowerPacks.OvalShape ovalShape1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape2;
    }
}

