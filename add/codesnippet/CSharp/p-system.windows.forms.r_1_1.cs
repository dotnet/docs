        private void button1_Click(object sender, EventArgs e)
        {
            Application.VisualStyleState =
                Application.VisualStyleState ^
                VisualStyleState.ClientAndNonClientAreasEnabled;

            GroupBoxRenderer.RenderMatchingApplicationState = true;
            if (Application.RenderWithVisualStyles)
                this.Text = "Visual Styles Enabled";
            else
                this.Text = "Visual Styles Disabled";
        }