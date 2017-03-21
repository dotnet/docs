        [EditorAttribute(typeof(System.Drawing.Design.BitmapEditor), 
            typeof(System.Drawing.Design.UITypeEditor))]
        public Bitmap testBitmap
        {
            get
            {
                return testBmp;
            }
            set
            {
                testBmp = value;
            }
        }
        private Bitmap testBmp;