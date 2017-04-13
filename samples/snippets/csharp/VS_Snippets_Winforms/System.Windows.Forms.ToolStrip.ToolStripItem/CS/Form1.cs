// <snippet1>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace RolloverItemDemoLib
{
    // <snippet10>
    // This class implements a ToolStripItem that highlights
    // its border and text when the mouse enters its
    // client rectangle. It has a clickable state which is
    // exposed through the Clicked property and displayed
    // by highlighting or graying out the item's image. 
    public class RolloverItem : ToolStripItem
    {
        private bool clickedValue = false;
        private bool rolloverValue = false;

        private Rectangle imageRect;
        private Rectangle textRect;

        // For brevity, this implementation limits the possible 
        // TextDirection values to ToolStripTextDirection.Horizontal. 
        public override ToolStripTextDirection TextDirection
        {
            get
            {
                return base.TextDirection;
            }
            set
            {
                if (value == ToolStripTextDirection.Horizontal)
                {
                    base.TextDirection = value;
                }
                else
                {
                    throw new ArgumentException(
                        "RolloverItem supports only horizontal text.");
                }
            }
        }

        // For brevity, this implementation limits the possible 
        // TextImageRelation values to ImageBeforeText and TextBeforeImage. 
        public new TextImageRelation TextImageRelation
        {
            get
            {
                return base.TextImageRelation;
            }

            set
            {
                if (value == TextImageRelation.ImageBeforeText || 
                    value == TextImageRelation.TextBeforeImage)
                {
                    base.TextImageRelation = value;
                }
                else
                {
                    throw new ArgumentException(
                        "Unsupported TextImageRelation value.");
                }
            }
        }
        
        // This property returns true if the mouse is 
        // inside the client rectangle.
        public bool Rollover
        {
            get
            {
                return this.rolloverValue;
            }   
        }

        // This property returns true if the item 
        // has been toggled into the clicked state.
        // Clicking again toggles it to the 
        // unclicked state.
        public bool Clicked
        {
            get
            {
                return this.clickedValue;
            }
        }

        // <snippet11>
        // The method defines the behavior of the Click event.
        // It simply toggles the state of the clickedValue field.
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            this.clickedValue ^= true;
        }
        // </snippet11>

        // <snippet14>
        // The method defines the behavior of the DoubleClick 
        // event. It shows a MessageBox with the item's text.
        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);

            string msg = String.Format("Item: {0}", this.Text);

            MessageBox.Show(msg);
        }
        // </snippet14>

        // <snippet15>
        // This method defines the behavior of the MouseEnter event.
        // It sets the state of the rolloverValue field to true and
        // tells the control to repaint.
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            this.rolloverValue = true;

            this.Invalidate();
        }
        // </snippet15>

        // <snippet16>
        // This method defines the behavior of the MouseLeave event.
        // It sets the state of the rolloverValue field to false and
        // tells the control to repaint.
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            this.rolloverValue = false;

            this.Invalidate();
        }
        // </snippet16>

        // <snippet12>
        // This method defines the painting behavior of the control.
        // It performs the following operations:
        //
        // Computes the layout of the item's image and text.
        // Draws the item's background image.
        // Draws the item's image.
        // Draws the item's text.
        //
        // Drawing operations are implemented in the 
        // RolloverItemRenderer class.
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (this.Owner != null)
            {
                // Find the dimensions of the image and the text 
                // areas of the item. 
                this.ComputeImageAndTextLayout();

                // Draw the background. This includes drawing a highlighted 
                // border when the mouse is in the client area.
                ToolStripItemRenderEventArgs ea = new ToolStripItemRenderEventArgs(
                     e.Graphics,
                     this);
                this.Owner.Renderer.DrawItemBackground(ea);

                // Draw the item's image. 
                ToolStripItemImageRenderEventArgs irea =
                    new ToolStripItemImageRenderEventArgs(
                    e.Graphics,
                    this,
                    imageRect );
                this.Owner.Renderer.DrawItemImage(irea);

                // If the item is on a drop-down, give its
                // text a different highlighted color.
                Color highlightColor = 
                    this.IsOnDropDown ?
                    Color.Salmon : SystemColors.ControlLightLight;

                // Draw the text, and highlight it if the 
                // the rollover state is true.
                ToolStripItemTextRenderEventArgs rea =
                    new ToolStripItemTextRenderEventArgs(
                    e.Graphics,
                    this,
                    base.Text,
                    textRect,
                    this.rolloverValue ? highlightColor : base.ForeColor,
                    base.Font,
                    base.TextAlign);
                this.Owner.Renderer.DrawItemText(rea);
            }
        }
        // </snippet12>

        // <snippet13>
        // This utility method computes the layout of the 
        // RolloverItem control's image area and the text area.
        // For brevity, only the following settings are 
        // supported:
        //
        // ToolStripTextDirection.Horizontal
        // TextImageRelation.ImageBeforeText 
        // TextImageRelation.ImageBeforeText
        // 
        // It would not be difficult to support vertical text
        // directions and other image/text relationships.
        private void ComputeImageAndTextLayout()
        {
            Rectangle cr = base.ContentRectangle;
            Image img = base.Owner.ImageList.Images[base.ImageKey];

            // Compute the center of the item's ContentRectangle.
            int centerY = (cr.Height - img.Height) / 2;

            // Find the dimensions of the image and the text 
            // areas of the item. The text occupies the space 
            // not filled by the image. 
            if (base.TextImageRelation == TextImageRelation.ImageBeforeText &&
                base.TextDirection == ToolStripTextDirection.Horizontal)
            {
                imageRect = new Rectangle(
                    base.ContentRectangle.Left,
                    centerY,
                    base.Image.Width,
                    base.Image.Height);

                textRect = new Rectangle(
                    imageRect.Width,
                    base.ContentRectangle.Top,
                    base.ContentRectangle.Width - imageRect.Width,
                    base.ContentRectangle.Height);
            }
            else if (base.TextImageRelation == TextImageRelation.TextBeforeImage &&
                     base.TextDirection == ToolStripTextDirection.Horizontal)
            {
                imageRect = new Rectangle(
                    base.ContentRectangle.Right - base.Image.Width,
                    centerY,
                    base.Image.Width,
                    base.Image.Height);

                textRect = new Rectangle(
                    base.ContentRectangle.Left,
                    base.ContentRectangle.Top,
                    imageRect.X,
                    base.ContentRectangle.Bottom);
            }
        }
        // </snippet13>
    }
    // </snippet10>

    #region RolloverItemRenderer

    // <snippet20>
    // This is the custom renderer for the RolloverItem control.
    // It draws a border around the item when the mouse is
    // in the item's client area. It also draws the item's image
    // in an inactive state (grayed out) until the user clicks
    // the item to toggle its "clicked" state.
    internal class RolloverItemRenderer : ToolStripSystemRenderer
    {
        // <snippet21>
        protected override void OnRenderItemImage(
            ToolStripItemImageRenderEventArgs e)
        {
            base.OnRenderItemImage(e);

            RolloverItem item = e.Item as RolloverItem;

            // If the ToolSTripItem is of type RolloverItem, 
            // perform custom rendering for the image.
            if (item != null)
            {
                if (item.Clicked)
                {
                    // The item is in the clicked state, so 
                    // draw the image as usual.
                    e.Graphics.DrawImage(
                        e.Image,
                        e.ImageRectangle.X,
                        e.ImageRectangle.Y);
                }
                else
                {
                    // In the unclicked state, gray out the image.
                    ControlPaint.DrawImageDisabled(
                        e.Graphics,
                        e.Image,
                        e.ImageRectangle.X,
                        e.ImageRectangle.Y,
                        item.BackColor);
                }
            }
        }
        // </snippet21>

        // <snippet22>
        // This method defines the behavior for rendering the
        // background of a ToolStripItem. If the item is a
        // RolloverItem, it paints the item's BackgroundImage 
        // centered in the client area. If the mouse is in the 
        // item's client area, a border is drawn around it.
        // If the item is on a drop-down or if it is on the
        // overflow, a gradient is painted in the background.
        protected override void OnRenderItemBackground(
            ToolStripItemRenderEventArgs e)
        {
            base.OnRenderItemBackground(e);

            RolloverItem item = e.Item as RolloverItem;

            // If the ToolSTripItem is of type RolloverItem, 
            // perform custom rendering for the background.
            if (item != null)
            {
                if (item.Placement == ToolStripItemPlacement.Overflow ||
                    item.IsOnDropDown)
                {
                    using (LinearGradientBrush b = new LinearGradientBrush(
                        item.ContentRectangle,
                        Color.Salmon,
                        Color.DarkRed,
                        0f,
                        false))
                    {
                        e.Graphics.FillRectangle(b, item.ContentRectangle);
                    }
                }

                // The RolloverItem control only supports 
                // the ImageLayout.Center setting for the
                // BackgroundImage property.
                if (item.BackgroundImageLayout == ImageLayout.Center)
                {
                    // Get references to the item's ContentRectangle
                    // and BackgroundImage, for convenience.
                    Rectangle cr = item.ContentRectangle;
                    Image bgi = item.BackgroundImage;

                    // Compute the center of the item's ContentRectangle.
                    int centerX = (cr.Width - bgi.Width) / 2;
                    int centerY = (cr.Height - bgi.Height) / 2;

                    // If the item is selected, draw the background
                    // image as usual. Otherwise, draw it as disabled.
                    if (item.Selected)
                    {
                        e.Graphics.DrawImage(bgi, centerX, centerY);
                    }
                    else
                    {
                        ControlPaint.DrawImageDisabled(
                                e.Graphics,
                                bgi,
                                centerX,
                                centerY,
                                item.BackColor);
                    }
                }

                // If the item is in the rollover state, 
                // draw a border around it.
                if (item.Rollover)
                {
                    ControlPaint.DrawFocusRectangle(
                        e.Graphics,
                        item.ContentRectangle);
                }
            }
        }
        // </snippet22>

    #endregion

    }
    // </snippet20>

    // This form tests various features of the RolloverItem
    // control. RolloverItem conrols are created and added
    // to the form's ToolStrip. They are also created and 
    // added to a button's ContextMenuStrip. The behavior
    // of the RolloverItem control differs depending on 
    // the type of parent control.
    public class RolloverItemTestForm : Form
    {
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Button button1;

        private string infoIconKey = "Information icon";
        private string handIconKey = "Hand icon";
        private string exclIconKey = "Exclamation icon";
        private string questionIconKey = "Question icon";
        private string warningIconKey = "Warning icon ";

        private System.ComponentModel.IContainer components = null;

        public RolloverItemTestForm()
        {
            InitializeComponent();

            // Set up the form's ToolStrip control.
            InitializeToolStrip();

            // Set up the ContextMenuStrip for the button.
            InitializeContextMenu();
        }

        // This utility method initializes the ToolStrip control's 
        // image list. For convenience, icons from the SystemIcons 
        // class are used for this demonstration, but any images
        // could be used.
        private void InitializeImageList(ToolStrip ts)
        {
            if (ts.ImageList == null)
            {
                ts.ImageList = new ImageList();
                ts.ImageList.ImageSize = SystemIcons.Exclamation.Size;

                ts.ImageList.Images.Add(
                    this.infoIconKey,
                    SystemIcons.Information);

                ts.ImageList.Images.Add(
                    this.handIconKey,
                    SystemIcons.Hand);

                ts.ImageList.Images.Add(
                    this.exclIconKey,
                    SystemIcons.Exclamation);

                ts.ImageList.Images.Add(
                    this.questionIconKey,
                    SystemIcons.Question);

                ts.ImageList.Images.Add(
                    this.warningIconKey,
                    SystemIcons.Warning);
            }
        }

        private void InitializeToolStrip()
        {
            this.InitializeImageList(this.toolStrip1);

            this.toolStrip1.Renderer = new RolloverItemRenderer();

            RolloverItem item = this.CreateRolloverItem(
                this.toolStrip1,
                "RolloverItem on ToolStrip",
                this.Font,
                infoIconKey,
                TextImageRelation.ImageBeforeText,
                exclIconKey);

            this.toolStrip1.Items.Add(item);

            item = this.CreateRolloverItem(
                this.toolStrip1,
                "RolloverItem on ToolStrip",
                this.Font,
                infoIconKey,
                TextImageRelation.ImageBeforeText,
                exclIconKey);

            this.toolStrip1.Items.Add(item);
        }

        private void InitializeContextMenu()
        {
            Font f = new System.Drawing.Font(
                "Arial",
                18f,
                FontStyle.Bold);

            ContextMenuStrip cms = new ContextMenuStrip();
            this.InitializeImageList(cms);

            cms.Renderer = new RolloverItemRenderer();
            cms.AutoSize = true;
            cms.ShowCheckMargin = false;
            cms.ShowImageMargin = false;

            RolloverItem item = this.CreateRolloverItem(
                cms,
                "RolloverItem on ContextMenuStrip",
                f,
                handIconKey,
                TextImageRelation.ImageBeforeText,
                exclIconKey);

            cms.Items.Add(item);

            item = this.CreateRolloverItem(
                cms,
                "Another RolloverItem on ContextMenuStrip",
                f,
                questionIconKey,
                TextImageRelation.ImageBeforeText,
                exclIconKey);

            cms.Items.Add(item);

            item = this.CreateRolloverItem(
                cms,
                "And another RolloverItem on ContextMenuStrip",
                f,
                warningIconKey,
                TextImageRelation.ImageBeforeText,
                exclIconKey);

            cms.Items.Add(item);

            cms.Closing += new ToolStripDropDownClosingEventHandler(cms_Closing);

            this.button1.ContextMenuStrip = cms;
        }

        // This method handles the ContextMenuStrip 
        // control's Closing event. It prevents the 
        // RolloverItem from closing the drop-down  
        // when the item is clicked.
        void cms_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked)
            {
                e.Cancel = true;
            }
        }

        // <snippet3>
        // This method handles the Click event for the button.
        // it selects the first item in the ToolStrip control
        // by using the ToolStripITem.Select method.
        private void button1_Click(object sender, EventArgs e)
        {
            RolloverItem item = this.toolStrip1.Items[0] as RolloverItem;

            if (item != null)
            {
                item.Select();

                this.Invalidate();
            }
        }
        // </snippet3>

        // <snippet2>
        // This utility method creates a RolloverItem 
        // and adds it to a ToolStrip control.
        private RolloverItem CreateRolloverItem(
            ToolStrip owningToolStrip,
            string txt,
            Font f,
            string imgKey,
            TextImageRelation tir,
            string backImgKey)
        {
            RolloverItem item = new RolloverItem();

            item.Alignment = ToolStripItemAlignment.Left;
            item.AllowDrop = false;
            item.AutoSize = true;

            item.BackgroundImage = owningToolStrip.ImageList.Images[backImgKey];
            item.BackgroundImageLayout = ImageLayout.Center;
            item.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            item.DoubleClickEnabled = true;
            item.Enabled = true;
            item.Font = f;

            // These assignments are equivalent. Each assigns an
            // image from the owning toolstrip's image list.
            item.ImageKey = imgKey;
            //item.Image = owningToolStrip.ImageList.Images[infoIconKey];
            //item.ImageIndex = owningToolStrip.ImageList.Images.IndexOfKey(infoIconKey);
            item.ImageScaling = ToolStripItemImageScaling.None;

            item.Owner = owningToolStrip;
            item.Padding = new Padding(2);
            item.Text = txt;
            item.TextAlign = ContentAlignment.MiddleLeft;
            item.TextDirection = ToolStripTextDirection.Horizontal;
            item.TextImageRelation = tir;

            return item;
        }
        // </snippet2>

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AllowItemReorder = true;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(845, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 100);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Click to select";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RolloverItemTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(845, 282);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "RolloverItemTestForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }

    static class Program
    {   
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RolloverItemTestForm());
        }
    }

}
// </snippet1>