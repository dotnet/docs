    public class CustomHyperLinkControl : WebControl
    {
        public CustomHyperLinkControl() { }

        // The TargetUrl property represents the URL that 
        // the custom hyperlink control navigates to.
        [UrlProperty()]
        public string TargetUrl
        {
            get
            {
                string s = (string)ViewState["TargetUrl"];
                return ((s == null) ? String.Empty : s);
            }
            set
            {
                ViewState["TargetUrl"] = value;
            }
        }

        // The Text property represents the visible text that 
        // the custom hyperlink control is displayed with.        
        public virtual string Text
        {
            get
            {
                string s = (string)ViewState["Text"];
                return ((s == null) ? String.Empty : s);
            }
            set
            {
                ViewState["Text"] = value;
            }
        }

        // Implement this method to render the control.
    }