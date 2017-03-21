        // Override the OnUnLoad method to set _text to
        // a default value if it is null.
        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
            if (_text == null)
                _text = "Here is some default text.";
        }