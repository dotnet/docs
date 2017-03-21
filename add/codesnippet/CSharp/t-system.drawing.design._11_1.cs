        [EditorAttribute(typeof(System.Drawing.Design.FontEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Font testFont
        {
            get
            {
                return font;
            }
            set
            {
                font = value;
            }
        }
        private Font font;