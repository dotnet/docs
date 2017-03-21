    // Implements the IDataGridViewEditingControl.EditingControlFormattedValue 
    // property.
    public object EditingControlFormattedValue
    {
        get
        {
            return this.Value.ToShortDateString();
        }
        set
        {            
            if (value is String)
            {
                try
                {
                    // This will throw an exception of the string is 
                    // null, empty, or not in the format of a date.
                    this.Value = DateTime.Parse((String)value);
                }
                catch
                {
                    // In the case of an exception, just use the 
                    // default value so we're not left with a null
                    // value.
                    this.Value = DateTime.Now;
                }
            }
        }
    }