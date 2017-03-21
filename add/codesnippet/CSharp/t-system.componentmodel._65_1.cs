        [EditorAttribute(typeof(System.ComponentModel.Design.ArrayEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public object[] componentArray
        {
            get
            {
                return compArray;
            }
            set
            {
                compArray = value;
            }
        }
        private object[] compArray;