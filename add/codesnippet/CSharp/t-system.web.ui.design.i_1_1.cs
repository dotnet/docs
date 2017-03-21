        [EditorAttribute(typeof(System.Web.UI.Design.ImageUrlEditor), typeof(UITypeEditor))]
        public string imageURL
        {
            get
            {
                return imgURL;
            }
            set
            {
                imgURL = value;
            }
        }

        private string imgURL;