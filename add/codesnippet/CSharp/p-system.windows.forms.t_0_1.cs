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