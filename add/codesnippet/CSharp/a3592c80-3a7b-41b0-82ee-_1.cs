        protected override void PerformDataBinding(IEnumerable retrievedData) {
            base.PerformDataBinding(retrievedData);

            // If the data is retrieved from an IDataSource as an 
            // IEnumerable collection, attempt to bind its values to a 
            // set of TextBox controls.
            if (retrievedData != null) {

                foreach (object dataItem in retrievedData) {
                    
                    TextBox box = new TextBox();
                    
                    // The dataItem is not just a string, but potentially
                    // a System.Data.DataRowView or some other container. 
                    // If DataTextField is set, use it to determine which 
                    // field to render. Otherwise, use the first field.                    
                    if (DataTextField.Length > 0) {
                        box.Text = DataBinder.GetPropertyValue(dataItem, 
                            DataTextField, null);
                    }
                    else {
                        PropertyDescriptorCollection props = 
                            TypeDescriptor.GetProperties(dataItem);

                        // Set the "default" value of the TextBox.
                        box.Text = String.Empty;
                        
                        // Set the true data-bound value of the TextBox,
                        // if possible.
                        if (props.Count >= 1) {                        
                            if (null != props[0].GetValue(dataItem)) {
                                box.Text = props[0].GetValue(dataItem).ToString();
                            }
                        }
                    }                                        
                    
                    BoxSet.Add(box);
                }
            }
        }