    public ICollection Values
    {
        get
        {
            // Return an array where each item is a value.
            Object[] values = new Object[ItemsInUse];
            for (Int32 n = 0; n < ItemsInUse; n++)
                values[n] = items[n].Value;
            return values;
        }
    }