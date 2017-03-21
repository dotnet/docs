        // Override the OnPreRender method to set _message to
        // a default value if it is null.
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            if (_message == null)
                _message = "Here is some default text.";
        }