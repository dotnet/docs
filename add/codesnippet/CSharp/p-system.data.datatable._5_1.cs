    private void ChangeCultureInfo(DataTable table)
    {
        // Print the LCID  of the present CultureInfo.
        Console.WriteLine(table.Locale.LCID);

        // Create a new CultureInfo for the United Kingdom.
        CultureInfo myCultureInfo = new CultureInfo("en-gb");
        table.Locale = myCultureInfo;

        // Print the new LCID.
        Console.WriteLine(table.Locale.LCID); 
    }