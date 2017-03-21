        protected override void OnPreRender(System.EventArgs e)
        {
            // Run the OnPreRender method on the base class.
            base.OnPreRender(e);

            // Always display the Ad with a border.
            this.BorderWidth =  System.Web.UI.WebControls.Unit.Point(1);
        }