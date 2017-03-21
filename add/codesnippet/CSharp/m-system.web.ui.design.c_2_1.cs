        public override string GetDesignTimeHtml()
        {
            if (simpleControl.Text.Length > 0)
            {
                string spec = "<a href='{0}.aspx'>{0}</a>";
                return String.Format(spec, simpleControl.Text);
            }
            else
                return GetEmptyDesignTimeHtml();
        }