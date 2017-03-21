        [Category("Data")]
        [Description("Indicates the source of data for the control.")]
        [RefreshProperties(RefreshProperties.Repaint)]
        [AttributeProvider(typeof(IListSource))]
        public object DataSource
        {
            get
            {
                return this.dataGridView1.DataSource;
            }

            set
            {
                this.dataGridView1.DataSource = value;
            }
        }