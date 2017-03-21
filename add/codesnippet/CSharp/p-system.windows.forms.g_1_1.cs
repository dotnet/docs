
	// Match application style and toggle visual styles off
	// and on for the application.
        private void button1_Click(object sender, EventArgs e)
        {
            GroupBoxRenderer.RenderMatchingApplicationState = true;
            Application.VisualStyleState = 
                Application.VisualStyleState ^ 
                VisualStyleState.ClientAndNonClientAreasEnabled;

          
            if (Application.RenderWithVisualStyles)
                this.Text = "Visual Styles Enabled";
            else
                this.Text = "Visual Styles Disabled";
        }