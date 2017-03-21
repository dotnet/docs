        private void GetDataPresent2() 
        {
            // Creates a component to store in the data object.
            Component myComponent = new Component();

            // Creates a new data object and assigns it the component.
            DataObject myDataObject = new DataObject(myComponent);
 
            // Creates a type to store the type of data.
            Type myType = myComponent.GetType();
 
            // Checks whether the specified data type exists in the object.
            if (myDataObject.GetDataPresent(myType))
            {
                MessageBox.Show("The specified data is stored in the data object.");
                // Displays the type of data.
                textBox1.Text = "The data type is " + myDataObject.GetData(myType).GetType().Name + ".";
            }
            else
                MessageBox.Show("The specified data is not stored in the data object.");
        }