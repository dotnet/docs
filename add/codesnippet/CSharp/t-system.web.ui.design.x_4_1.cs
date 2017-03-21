        [EditorAttribute(typeof(System.Web.UI.Design.XmlUrlEditor), typeof(UITypeEditor))]
        public string XmlFileURL
        {
            get
            {
                return xmlURL;
            }
            set
            {
                xmlURL = value;
            }
        }

        private string xmlURL;