    private void AddTimeStamp()
    {
        //Create a new DataTable.
        DataTable table = new DataTable("NewTable");

        //Get its PropertyCollection.
        PropertyCollection properties = table.ExtendedProperties;

        //Add a timestamp value to the PropertyCollection.
        properties.Add("TimeStamp", DateTime.Now);

        // Print the timestamp.
        Console.WriteLine(properties["TimeStamp"]);
    }