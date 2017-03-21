        // Override the OnLoad method to set _text to
        // a default value if it is null.
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (_text == null)
                _text = "Here is some default text.";
        }