' System.Web.Services.Description.ServiceDescriptionCollection.Contains()
' System.Web.Services.Description.ServiceDescriptionCollection.IndexOf()
' System.Web.Services.Description.ServiceDescriptionCollection.Remove()

' The following program demonstrates 'Contains', 'IndexOf' and 
' 'Remove' methods of 'ServiceDescriptionCollection' class. It creates an 
' instance of 'ServiceDescriptionCollection' and adds 'ServiceDescription' 
' objects to the collection. It checks for an object of 'ServiceDescription', 
' retrieves the index of the object and removes it from the collection.
'
' Note: This program requires 'DataTypes_VB.wsdl' and 'MathService_VB.wsdl' 
' files to be placed in the same directory as that of .exe for
' running.


Imports System
Imports System.Web.Services.Description


Class MyServiceDescriptionCollection
   
   Public Shared Sub Main()
      Try
         Dim myServiceDescription1 As ServiceDescription = _
                 ServiceDescription.Read("DataTypes_VB.wsdl")
         Dim myServiceDescription2 As ServiceDescription = _
                 ServiceDescription.Read("MathService_VB.wsdl")
         Dim myCollection As New ServiceDescriptionCollection()
         
         ' Add 'ServiceDescription' objects.
         myCollection.Add(myServiceDescription1)
         myCollection.Add(myServiceDescription2)
         
' <Snippet1>      
         ' Check for 'ServiceDescription' object in the collection.
         If myCollection.Contains(myServiceDescription2) Then
' <Snippet2>
' <Snippet3>
            ' Get the index of 'ServiceDescription' object.
            Dim myIndex As Integer = myCollection.IndexOf(myServiceDescription2)
            ' Remove 'ServiceDescription' object from the collection.
            myCollection.Remove(myServiceDescription2)
            Console.WriteLine("Element at index {0} is removed ", myIndex.ToString())
' </Snippet3>
' </Snippet2>
         Else
            Console.WriteLine("Element not found.")
         End If
' </Snippet1>
      Catch e As Exception
         Console.WriteLine("The following exception was raised: {0}", e.Message.ToString())
      End Try
   End Sub 'Main
End Class 'MyServiceDescriptionCollection