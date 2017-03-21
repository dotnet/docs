        [EditorAttribute(typeof(System.Web.UI.Design.UrlEditor), typeof(UITypeEditor))]
        public string URL
        {
            get
            {
                return http_url;
            }
            set
            {
                http_url = value;
            }
        }

        private string http_url;