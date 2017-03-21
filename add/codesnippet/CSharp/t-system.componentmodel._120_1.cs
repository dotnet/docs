        [EditorAttribute(typeof(System.ComponentModel.Design.CollectionEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public ICollection testCollection
        {
            get
            {
                return Icollection;
            }
            set
            {
                Icollection = value;
            }
        }
        private ICollection Icollection;