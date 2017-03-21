        [EditorAttribute(typeof(System.Windows.Forms.Design.AnchorEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public System.Windows.Forms.AnchorStyles testAnchor
        {
            get
            {
                return anchor;
            }
            set
            {
                anchor = value;
            }
        }
        private AnchorStyles anchor;       