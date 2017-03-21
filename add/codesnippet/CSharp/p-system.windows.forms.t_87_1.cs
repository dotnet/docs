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