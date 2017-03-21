Private Sub AddTimeStamp()
    'Create a new DataTable.
    Dim table As New DataTable("NewTable")

    'Get its PropertyCollection.
    Dim properties As PropertyCollection = table.ExtendedProperties

    'Add a timestamp value to the PropertyCollection.
    properties.Add("TimeStamp", DateTime.Now)

    'Print the timestamp.
    Console.WriteLine(properties("TimeStamp"))
End Sub 