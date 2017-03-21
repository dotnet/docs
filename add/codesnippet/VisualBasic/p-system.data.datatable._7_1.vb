 Private Sub GetAndSetExtendedProperties(ByVal myTable As DataTable)
    ' Add an item to the collection.
    myTable.ExtendedProperties.Add("TimeStamp", DateTime.Now)
    ' Print the item.
    Console.WriteLine(myTable.ExtendedProperties.Item("TimeStamp"))
 End Sub