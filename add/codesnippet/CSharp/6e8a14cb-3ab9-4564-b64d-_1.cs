        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            if (Control.ID.StartsWith("Contoso"))
            {
                if (!Control.Enabled)
                {
                    return;
                }
            }

            base.Render(writer);
        }