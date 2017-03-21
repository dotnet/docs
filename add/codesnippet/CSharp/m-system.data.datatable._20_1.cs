    private void ClearTable(DataTable table)
    {
        try
        {
            table.Clear();
        }
        catch (DataException e)
        {
            // Process exception and return.
            Console.WriteLine("Exception of type {0} occurred.", 
                e.GetType());
        }
    
    }