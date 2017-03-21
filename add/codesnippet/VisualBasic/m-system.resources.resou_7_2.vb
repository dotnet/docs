Imports System.Resources

Module CreateResource
   Public Sub Main()
      Dim table As New PersonTable("Name", "Employee Number", "Age", 30, 18, 5)
      Dim rr As New ResXResourceWriter(".\UIResources.resx")
      rr.AddResource("TableName", "Employees of Acme Corporation")
      rr.AddResource("Employees", table)
      rr.Generate()
      rr.Close()
   End Sub
End Module