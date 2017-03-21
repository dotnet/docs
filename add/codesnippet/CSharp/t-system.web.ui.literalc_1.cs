        // Add two LiteralControls that render HTML H3 elements and text.
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")] 
        protected override void CreateChildControls() {

            this.Controls.Add(new LiteralControl("<h3>Value: "));

            TextBox box = new TextBox();
            box.Text = "0";
            this.Controls.Add(box);

            this.Controls.Add(new LiteralControl("</h3>"));
        }