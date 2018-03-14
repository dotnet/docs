// <snippet1>
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
// </snippet1>

namespace WindowsApplication2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();

            //Application.Run(new Form1());
            //Application.Run(new Form2());
            Application.Run(new Form3());
            //Application.Run(new Form4());
            //Application.Run(new Form5());
            //Application.Run(new Form6());
        }
    }

    // <snippet10>
    // This code example demonstrates how to use ToolStripPanel
    // controls with a multiple document interface (MDI).
    public class Form1 : Form
    {
        public Form1()
        {
            // Make the Form an MDI parent.
            this.IsMdiContainer = true;

            // <snippet11>
            // Create ToolStripPanel controls.
            ToolStripPanel tspTop = new ToolStripPanel();
            ToolStripPanel tspBottom = new ToolStripPanel();
            ToolStripPanel tspLeft = new ToolStripPanel();
            ToolStripPanel tspRight = new ToolStripPanel();

            // Dock the ToolStripPanel controls to the edges of the form.
            tspTop.Dock = DockStyle.Top;
            tspBottom.Dock = DockStyle.Bottom;
            tspLeft.Dock = DockStyle.Left;
            tspRight.Dock = DockStyle.Right;

            // Create ToolStrip controls to move among the 
            // ToolStripPanel controls.

            // Create the "Top" ToolStrip control and add
            // to the corresponding ToolStripPanel.
            ToolStrip tsTop = new ToolStrip();
            tsTop.Items.Add("Top");
            tspTop.Join(tsTop);

            // Create the "Bottom" ToolStrip control and add
            // to the corresponding ToolStripPanel.
            ToolStrip tsBottom = new ToolStrip();
            tsBottom.Items.Add("Bottom");
            tspBottom.Join(tsBottom);

            // Create the "Right" ToolStrip control and add
            // to the corresponding ToolStripPanel.
            ToolStrip tsRight = new ToolStrip();
            tsRight.Items.Add("Right");
            tspRight.Join(tsRight);

            // Create the "Left" ToolStrip control and add
            // to the corresponding ToolStripPanel.
            ToolStrip tsLeft = new ToolStrip();
            tsLeft.Items.Add("Left");
            tspLeft.Join(tsLeft);
            // </snippet11>

            // <snippet12>
            // Create a MenuStrip control with a new window.
            MenuStrip ms = new MenuStrip();
            ToolStripMenuItem windowMenu = new ToolStripMenuItem("Window");
            ToolStripMenuItem windowNewMenu = new ToolStripMenuItem("New", null, new EventHandler(windowNewMenu_Click));
            windowMenu.DropDownItems.Add(windowNewMenu);
            ((ToolStripDropDownMenu)(windowMenu.DropDown)).ShowImageMargin = false;
            ((ToolStripDropDownMenu)(windowMenu.DropDown)).ShowCheckMargin = true;

            // Assign the ToolStripMenuItem that displays 
            // the list of child forms.
            ms.MdiWindowListItem = windowMenu;

            // Add the window ToolStripMenuItem to the MenuStrip.
            ms.Items.Add(windowMenu);

            // Dock the MenuStrip to the top of the form.
            ms.Dock = DockStyle.Top;

            // The Form.MainMenuStrip property determines the merge target.
            this.MainMenuStrip = ms;
            // </snippet12>

            // Add the ToolStripPanels to the form in reverse order.
            this.Controls.Add(tspRight);
            this.Controls.Add(tspLeft);
            this.Controls.Add(tspBottom);
            this.Controls.Add(tspTop);

            // Add the MenuStrip last.
            // This is important for correct placement in the z-order.
            this.Controls.Add(ms);
        }

        // This event handler is invoked when 
        // the "New" ToolStripMenuItem is clicked.
        // It creates a new Form and sets its MdiParent 
        // property to the main form.
        void windowNewMenu_Click(object sender, EventArgs e)
        {
            Form f = new Form();
            f.MdiParent = this;
            f.Text = "Form - " + this.MdiChildren.Length.ToString();
            f.Show();
        }
    }
    // </snippet10>

    // <snippet20>
    // This code example demonstrates how to use a ProfessionalRenderer
    // to define custom professional colors at runtime.
    class Form2 : Form
    {
        // <snippet21>
        public Form2()
        {
            // Create a new ToolStrip control.
            ToolStrip ts = new ToolStrip();

            // Populate the ToolStrip control.
            ts.Items.Add("Apples");
            ts.Items.Add("Oranges");
            ts.Items.Add("Pears");
            ts.Items.Add(
                "Change Colors", 
                null, 
                new EventHandler(ChangeColors_Click));

            // Create a new MenuStrip.
            MenuStrip ms = new MenuStrip();

            // Dock the MenuStrip control to the top of the form.
            ms.Dock = DockStyle.Top;

            // Add the top-level menu items.
            ms.Items.Add("File");
            ms.Items.Add("Edit");
            ms.Items.Add("View");
            ms.Items.Add("Window");

            // <snippet23>
            // Add the ToolStrip to Controls collection.
            this.Controls.Add(ts);

            // Add the MenuStrip control last.
            // This is important for correct placement in the z-order.
            this.Controls.Add(ms);
            // </snippet23>
        }
        // </snippet21>

        // <snippet22>
        // This event handler is invoked when the "Change colors"
        // ToolStripItem is clicked. It assigns the Renderer
        // property for the ToolStrip control.
        void ChangeColors_Click(object sender, EventArgs e)
        {
            ToolStripManager.Renderer = 
                new ToolStripProfessionalRenderer(new CustomProfessionalColors());
        }
        // </snippet22>
    }
    
    // <snippet30>
    // This class defines the gradient colors for 
    // the MenuStrip and the ToolStrip.
    class CustomProfessionalColors : ProfessionalColorTable
    {
        public override Color ToolStripGradientBegin
        { get { return Color.BlueViolet; } }

        public override Color ToolStripGradientMiddle
        { get { return Color.CadetBlue; } }

        public override Color ToolStripGradientEnd
        { get { return Color.CornflowerBlue; } }

        public override Color MenuStripGradientBegin
        { get { return Color.Salmon; } }

        public override Color MenuStripGradientEnd
        { get { return Color.OrangeRed; } }
    }
    // </snippet30>
    // </snippet20>

    // <snippet40>
    // This code example demonstrates how to handle the Opening event.
    // It also demonstrates dynamic item addition and dynamic 
    // SourceControl determination with reuse.
    class Form3 : Form
    {
        // Declare the ContextMenuStrip control.
        private ContextMenuStrip fruitContextMenuStrip;

        public Form3()
        {
            // Create a new ContextMenuStrip control.
            fruitContextMenuStrip = new ContextMenuStrip();

            // Attach an event handler for the 
            // ContextMenuStrip control's Opening event.
            fruitContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(cms_Opening);

            // Create a new ToolStrip control.
            ToolStrip ts = new ToolStrip();

            // Create a ToolStripDropDownButton control and add it
            // to the ToolStrip control's Items collections.
            ToolStripDropDownButton fruitToolStripDropDownButton = new ToolStripDropDownButton("Fruit", null, null, "Fruit");
            ts.Items.Add(fruitToolStripDropDownButton);

            // Dock the ToolStrip control to the top of the form.
            ts.Dock = DockStyle.Top;

            // Assign the ContextMenuStrip control as the 
            // ToolStripDropDownButton control's DropDown menu.
            fruitToolStripDropDownButton.DropDown = fruitContextMenuStrip;

            // Create a new MenuStrip control and add a ToolStripMenuItem.
            MenuStrip ms = new MenuStrip();
            ToolStripMenuItem fruitToolStripMenuItem = new ToolStripMenuItem("Fruit", null, null, "Fruit");
            ms.Items.Add(fruitToolStripMenuItem);

            // Dock the MenuStrip control to the top of the form.
            ms.Dock = DockStyle.Top;

            // Assign the MenuStrip control as the 
            // ToolStripMenuItem's DropDown menu.
            fruitToolStripMenuItem.DropDown = fruitContextMenuStrip;

            // Assign the ContextMenuStrip to the form's 
            // ContextMenuStrip property.
            this.ContextMenuStrip = fruitContextMenuStrip;

            // Add the ToolStrip control to the Controls collection.
            this.Controls.Add(ts);

            //Add a button to the form and assign its ContextMenuStrip.
            Button b = new Button();
            b.Location = new System.Drawing.Point(60, 60);
            this.Controls.Add(b);
            b.ContextMenuStrip = fruitContextMenuStrip;

            // Add the MenuStrip control last.
            // This is important for correct placement in the z-order.
            this.Controls.Add(ms);
        }

        // <snippet42>
        // This event handler is invoked when the ContextMenuStrip
        // control's Opening event is raised. It demonstrates
        // dynamic item addition and dynamic SourceControl 
        // determination with reuse.
        void cms_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Acquire references to the owning control and item.
            Control c = fruitContextMenuStrip.SourceControl as Control;
            ToolStripDropDownItem tsi = fruitContextMenuStrip.OwnerItem as ToolStripDropDownItem;

            // Clear the ContextMenuStrip control's Items collection.
            fruitContextMenuStrip.Items.Clear();

            // Check the source control first.
            if (c != null)
            {
                // Add custom item (Form)
                fruitContextMenuStrip.Items.Add("Source: " + c.GetType().ToString());
            }
            else if (tsi != null)
            {
                // Add custom item (ToolStripDropDownButton or ToolStripMenuItem)
                fruitContextMenuStrip.Items.Add("Source: " + tsi.GetType().ToString());
            }

            // Populate the ContextMenuStrip control with its default items.
            fruitContextMenuStrip.Items.Add("-");
            fruitContextMenuStrip.Items.Add("Apples");
            fruitContextMenuStrip.Items.Add("Oranges");
            fruitContextMenuStrip.Items.Add("Pears");

            // Set Cancel to false. 
            // It is optimized to true based on empty entry.
            e.Cancel = false;
        }
        // </snippet42>
    }
    // </snippet40>

    // <snippet50>
    // This code example demonstrates using the Spring property 
    // to interactively center a ToolStripStatusLabel in a StatusStrip.
    class Form4 : Form
    {
        // Declare the ToolStripStatusLabel.
        ToolStripStatusLabel middleLabel;

        public Form4()
        {
            // Create a new StatusStrip control.
            StatusStrip ss = new StatusStrip();

            // Add the leftmost label.
            ss.Items.Add("Left");

            // Handle middle label separately -- action will occur
            // when the label is clicked.
            middleLabel = new ToolStripStatusLabel("Middle (Spring)");
            middleLabel.Click += new EventHandler(middleLabel_Click);
            ss.Items.Add(middleLabel);

            // Add the rightmost label
            ss.Items.Add("Right");

            // Add the StatusStrip control to the controls collection.
            this.Controls.Add(ss);
        }

        // <snippet51>
        // This event hadler is invoked when the 
        // middleLabel control is clicked. It toggles
        // the value of the Spring property.
        void middleLabel_Click(object sender, EventArgs e)
        {
            // Toggle the value of the Spring property.
            middleLabel.Spring ^= true;

            // Set the Text property according to the
            // value of the Spring property. 
            middleLabel.Text = 
                middleLabel.Spring ? "Middle (Spring - True)" : "Middle (Spring - False)";
        }
        // </snippet51>
    }
    // </snippet50>

    // <snippet60>
    // This code example demonstrates how to set the check
    // and image margins for a ToolStripMenuItem.
    class Form5 : Form
    {
        // <snippet61>
        public Form5()
        {
            // Size the form to show three wide menu items.
            this.Width = 500;
            this.Text = "ToolStripContextMenuStrip: Image and Check Margins";

            // Create a new MenuStrip control.
            MenuStrip ms = new MenuStrip();

            // Create the ToolStripMenuItems for the MenuStrip control.
            ToolStripMenuItem bothMargins = new ToolStripMenuItem("BothMargins");
            ToolStripMenuItem imageMarginOnly = new ToolStripMenuItem("ImageMargin");
            ToolStripMenuItem checkMarginOnly = new ToolStripMenuItem("CheckMargin");
            ToolStripMenuItem noMargins = new ToolStripMenuItem("NoMargins");

            // Customize the DropDowns menus.
            // This ToolStripMenuItem has an image margin 
            // and a check margin.
            bothMargins.DropDown = CreateCheckImageContextMenuStrip();
            ((ContextMenuStrip)bothMargins.DropDown).ShowImageMargin = true;
            ((ContextMenuStrip)bothMargins.DropDown).ShowCheckMargin = true;

            // This ToolStripMenuItem has only an image margin.
            imageMarginOnly.DropDown = CreateCheckImageContextMenuStrip();
            ((ContextMenuStrip)imageMarginOnly.DropDown).ShowImageMargin = true;
            ((ContextMenuStrip)imageMarginOnly.DropDown).ShowCheckMargin = false;

            // This ToolStripMenuItem has only a check margin.
            checkMarginOnly.DropDown = CreateCheckImageContextMenuStrip();
            ((ContextMenuStrip)checkMarginOnly.DropDown).ShowImageMargin = false;
            ((ContextMenuStrip)checkMarginOnly.DropDown).ShowCheckMargin = true;

            // This ToolStripMenuItem has no image and no check margin.
            noMargins.DropDown = CreateCheckImageContextMenuStrip();
            ((ContextMenuStrip)noMargins.DropDown).ShowImageMargin = false;
            ((ContextMenuStrip)noMargins.DropDown).ShowCheckMargin = false;

            // Populate the MenuStrip control with the ToolStripMenuItems.
            ms.Items.Add(bothMargins);
            ms.Items.Add(imageMarginOnly);
            ms.Items.Add(checkMarginOnly);
            ms.Items.Add(noMargins);

            // Dock the MenuStrip control to the top of the form.
            ms.Dock = DockStyle.Top;

            // Add the MenuStrip control to the controls collection last.
            // This is important for correct placement in the z-order.
            this.Controls.Add(ms);
        }
        // </snippet61>

        // This utility method creates a Bitmap for use in 
        // a ToolStripMenuItem's image margin.
        internal Bitmap CreateSampleBitmap()
        {
            // The Bitmap is a smiley face.
            Bitmap sampleBitmap = new Bitmap(32, 32);
            Graphics g = Graphics.FromImage(sampleBitmap);

            using (Pen p = new Pen(ProfessionalColors.ButtonPressedBorder))
            {
                // Set the Pen width.
                p.Width = 4;

                // Set up the mouth geometry.
                Point[] curvePoints = new Point[]{
                    new Point(4,14), 
                    new Point(16,24), 
                    new Point(28,14)};

                // Draw the mouth.
                g.DrawCurve(p, curvePoints);

                // Draw the eyes.
                g.DrawEllipse(p, new Rectangle(new Point(7, 4), new Size(3, 3)));
                g.DrawEllipse(p, new Rectangle(new Point(22, 4), new Size(3, 3)));
            }

            return sampleBitmap;
        }

        // <snippet62>
        // This utility method creates a ContextMenuStrip control
        // that has four ToolStripMenuItems showing the four 
        // possible combinations of image and check margins.
        internal ContextMenuStrip CreateCheckImageContextMenuStrip()
        {
            // Create a new ContextMenuStrip control.
            ContextMenuStrip checkImageContextMenuStrip = new ContextMenuStrip();

            // Create a ToolStripMenuItem with a
            // check margin and an image margin.
            ToolStripMenuItem yesCheckYesImage = 
                new ToolStripMenuItem("Check, Image");
            yesCheckYesImage.Checked = true;
            yesCheckYesImage.Image = CreateSampleBitmap();

            // Create a ToolStripMenuItem with no
            // check margin and with an image margin.
            ToolStripMenuItem noCheckYesImage = 
                new ToolStripMenuItem("No Check, Image");
            noCheckYesImage.Checked = false;
            noCheckYesImage.Image = CreateSampleBitmap();

            // Create a ToolStripMenuItem with a
            // check margin and without an image margin.
            ToolStripMenuItem yesCheckNoImage = 
                new ToolStripMenuItem("Check, No Image");
            yesCheckNoImage.Checked = true;

            // Create a ToolStripMenuItem with no
            // check margin and no image margin.
            ToolStripMenuItem noCheckNoImage = 
                new ToolStripMenuItem("No Check, No Image");
            noCheckNoImage.Checked = false;

            // Add the ToolStripMenuItems to the ContextMenuStrip control.
            checkImageContextMenuStrip.Items.Add(yesCheckYesImage);
            checkImageContextMenuStrip.Items.Add(noCheckYesImage);
            checkImageContextMenuStrip.Items.Add(yesCheckNoImage);
            checkImageContextMenuStrip.Items.Add(noCheckNoImage);

            return checkImageContextMenuStrip;
        }
        // </snippet62>
    }
    // </snippet60>

    // <snippet70>
    // This example demonstrates how to apply a 
    // custom professional renderer to an individual
    // ToolStrip or to the application as a whole.
    class Form6 : Form
    {
        ComboBox targetComboBox = new ComboBox();

        public Form6()
        {
            // Alter the renderer at the top level.

            // Create and populate a new ToolStrip control.
            ToolStrip ts = new ToolStrip();
            ts.Name = "ToolStrip";
            ts.Items.Add("Apples");
            ts.Items.Add("Oranges");
            ts.Items.Add("Pears");

            // Create a new menustrip with a new window.
            MenuStrip ms = new MenuStrip();
            ms.Name = "MenuStrip";
            ms.Dock = DockStyle.Top;

            // add top level items
            ToolStripMenuItem fileMenuItem = new ToolStripMenuItem("File");
            ms.Items.Add(fileMenuItem);
            ms.Items.Add("Edit");
            ms.Items.Add("View");
            ms.Items.Add("Window");

            // Add subitems to the "File" menu.
            fileMenuItem.DropDownItems.Add("Open");
            fileMenuItem.DropDownItems.Add("Save");
            fileMenuItem.DropDownItems.Add("Save As...");
            fileMenuItem.DropDownItems.Add("-");
            fileMenuItem.DropDownItems.Add("Exit");

            // Add a Button control to apply renderers.
            Button applyButton = new Button();
            applyButton.Text = "Apply Custom Renderer";
            applyButton.Click += new EventHandler(applyButton_Click);

            // Add the ComboBox control for choosing how
            // to apply the renderers.
            targetComboBox.Items.Add("All");
            targetComboBox.Items.Add("MenuStrip");
            targetComboBox.Items.Add("ToolStrip");
            targetComboBox.Items.Add("Reset");

            // Create and set up a TableLayoutPanel control.
            TableLayoutPanel tlp = new TableLayoutPanel();
            tlp.Dock = DockStyle.Fill;
            tlp.RowCount = 1;
            tlp.ColumnCount = 2;
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent));
            tlp.Controls.Add(applyButton);
            tlp.Controls.Add(targetComboBox);

            // Create a GroupBox for the TableLayoutPanel control.
            GroupBox gb = new GroupBox();
            gb.Text = "Apply Renderers";
            gb.Dock = DockStyle.Fill;
            gb.Controls.Add(tlp);

            // Add the GroupBox to the form.
            this.Controls.Add(gb);

            // Add the ToolStrip to the form's Controls collection.
            this.Controls.Add(ts);

            // Add the MenuStrip control last.
            // This is important for correct placement in the z-order.
            this.Controls.Add(ms);
        }

        // <snippet80>
        // This event handler is invoked when 
        // the "Apply Renderers" button is clicked.
        // Depending on the value selected in a ComboBox control,
        // it applies a custom renderer selectively to
        // individual MenuStrip or ToolStrip controls,
        // or it applies a custom renderer to the 
        // application as a whole.
        void applyButton_Click(object sender, EventArgs e)
        {
            ToolStrip ms = ToolStripManager.FindToolStrip("MenuStrip");
            ToolStrip ts = ToolStripManager.FindToolStrip("ToolStrip");

            if (targetComboBox.SelectedItem != null)
            {
                switch (targetComboBox.SelectedItem.ToString())
                {
                    case "Reset":
                    {
                        ms.RenderMode = ToolStripRenderMode.ManagerRenderMode;
                        ts.RenderMode = ToolStripRenderMode.ManagerRenderMode;

                        // Set the default RenderMode to Professional.
                        ToolStripManager.RenderMode = ToolStripManagerRenderMode.Professional;

                        break;
                    }

                    case "All":
                    {
                        ms.RenderMode = ToolStripRenderMode.ManagerRenderMode;
                        ts.RenderMode = ToolStripRenderMode.ManagerRenderMode;

                        // Assign the custom renderer at the application level.
                        ToolStripManager.Renderer = new CustomProfessionalRenderer();

                        break;
                    }

                    case "MenuStrip":
                    {
                        // Assign the custom renderer to the MenuStrip control only.
                        ms.Renderer = new CustomProfessionalRenderer();

                        break;
                    }

                    case "ToolStrip":
                    {
                        // Assign the custom renderer to the ToolStrip control only.
                        ts.Renderer = new CustomProfessionalRenderer();

                        break;
                    }
                }
            }
        }
        // </snippet80>
    }

    // <snippet100>
    // This type demonstrates a custom renderer. It overrides the
    // OnRenderMenuItemBackground and OnRenderButtonBackground methods
    // to customize the backgrounds of MenuStrip items and ToolStrip buttons.
    class CustomProfessionalRenderer : ToolStripProfessionalRenderer
    {
        // <snippet101>
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (e.Item.Selected)
            {
                using (Brush b = new SolidBrush(ProfessionalColors.SeparatorLight))
                {
                    e.Graphics.FillEllipse(b, e.Item.ContentRectangle);
                }
            }
            else
            {
                using (Pen p = new Pen(ProfessionalColors.SeparatorLight))
                {
                    e.Graphics.DrawEllipse(p, e.Item.ContentRectangle);
                }
            }
        }
        // </snippet101>

        // <snippet102>
        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            Rectangle r = Rectangle.Inflate(e.Item.ContentRectangle, -2, -2);

            if (e.Item.Selected)
            {
                using (Brush b = new SolidBrush(ProfessionalColors.SeparatorLight))
                {
                    e.Graphics.FillRectangle(b, r);
                }
            }
            else
            {
                using (Pen p = new Pen(ProfessionalColors.SeparatorLight))
                {
                    e.Graphics.DrawRectangle(p, r);
                }
            }
        }
        // </snippet102>
    }
    // </snippet100>
    // </snippet70>
}

