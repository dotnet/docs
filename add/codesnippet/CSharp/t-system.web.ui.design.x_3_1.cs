        [EditorAttribute(typeof(System.Web.UI.Design.XmlFileEditor), typeof(UITypeEditor))]
        public string XmlFile
        {
            get
            {
                return xml_;
            }
            set
            {
                xml_ = value;
            }
        }

        private string xml_;