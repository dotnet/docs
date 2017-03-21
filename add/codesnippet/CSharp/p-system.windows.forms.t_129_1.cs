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
    }

    // This type demonstrates a custom renderer. It overrides the
    // OnRenderMenuItemBackground and OnRenderButtonBackground methods
    // to customize the backgrounds of MenuStrip items and ToolStrip buttons.
    class CustomProfessionalRenderer : ToolStripProfessionalRenderer
    {
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
    }