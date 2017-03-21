        [EditorAttribute(typeof(System.Windows.Forms.Design.FileNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string testFilename
        {
            get
            {
                return filename;
            }
            set
            {
                filename = value;
            }
        }
        private string filename;       