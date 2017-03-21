        // Override the DataBindControl. 
        public override void DataBindControl(IDesignerHost designerHost, 
            Control control)
        {
            // Create a reference, named dataSourceBinding, 
            // to the control DataSource binding.
            DataBinding dataSourceBinding = 
                ((IDataBindingsAccessor)control).DataBindings["DataSource"];

            // If the binding exists, create a reference to the
            // list control, clear its ListItemCollection, and then add
            // an item to the collection.
            if (! (dataSourceBinding == null))
            {
                SimpleRadioButtonList simpleControl = 
                    (SimpleRadioButtonList)control;

                simpleControl.Items.Clear();
                simpleControl.Items.Add("Data-bound Radio Button.");
            }
        } // DataBindControl