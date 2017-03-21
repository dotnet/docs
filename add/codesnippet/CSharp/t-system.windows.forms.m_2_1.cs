    // This code example demonstrates how to use ToolStripPanel
    // controls with a multiple document interface (MDI).
    public class Form1 : Form
    {
        public Form1()
        {
            // Make the Form an MDI parent.
            this.IsMdiContainer = true;

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