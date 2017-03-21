 private void GetAndSetExtendedProperties(DataTable myTable){
    // Add an item to the collection.
    myTable.ExtendedProperties.Add("TimeStamp", DateTime.Now);
    // Print the item.
    Console.WriteLine(myTable.ExtendedProperties["TimeStamp"]);
 }