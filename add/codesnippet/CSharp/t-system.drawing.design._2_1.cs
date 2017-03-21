        [EditorAttribute(typeof(System.Drawing.Design.ImageEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Image testImage
        {
            get
            {
                return testImg;
            }
            set
            {
                testImg = value;
            }
        }
        private Image testImg;                