 Private Sub SetProperty(column As DataColumn)
     column.ExtendedProperties.Add("TimeStamp", DateTime.Now)
 End Sub    
    
 Private Sub GetProperty(column As DataColumn)
     Console.WriteLine(column.ExtendedProperties("TimeStamp").ToString())
End Sub