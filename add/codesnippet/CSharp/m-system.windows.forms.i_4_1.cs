        private void GetData2() 
        {
            // Creates a component.
            Component myComponent = new Component();
 
            // Creates a data object, and assigns it the component.
            DataObject myDataObject = new DataObject(myComponent);
 
            // Creates a type, myType, to store the type of data.
            Type myType = myComponent.GetType();
 
            // Retrieves the data using myType to represent its type.
            Object myObject = myDataObject.GetData(myType);
            if(myObject != null)
                MessageBox.Show("The data type stored in the data object is " +
                    myObject.GetType().Name + ".");
            else
                MessageBox.Show("Data of the specified type was not stored " +
                    "in the data object.");
        }