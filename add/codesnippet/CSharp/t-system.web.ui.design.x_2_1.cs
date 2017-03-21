        [EditorAttribute(typeof(System.Web.UI.Design.XslUrlEditor), typeof(UITypeEditor))]
        public string XslFileURL
        {
            get
            {
                return xslURL;
            }
            set
            {
                xslURL = value;
            }
        }

        private string xslURL;