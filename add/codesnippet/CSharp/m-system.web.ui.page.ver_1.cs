        // Override the Render method to ensure that this control
        // is nested in an HtmlForm server control, between a <form runat=server>
        // opening tag and a </form> closing tag.
        protected override void Render(HtmlTextWriter writer) {
            // Ensure that the control is nested in a server form.
            if (Page != null) {
                Page.VerifyRenderingInServerForm(this);
            }
            base.Render(writer);
        }