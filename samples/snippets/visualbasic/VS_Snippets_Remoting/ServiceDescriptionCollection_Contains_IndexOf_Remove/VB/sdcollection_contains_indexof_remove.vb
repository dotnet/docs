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
         
' <Snippet11>      
         ' Check for a ServiceDescription in the collection.
         If myCollection.Contains(myServiceDescription2) Then
' <Snippet12>
' <Snippet13>
            ' Get the index of a ServiceDescription.
            Dim myIndex As Integer = myCollection.IndexOf(myServiceDescription2)

            ' Remove a ServiceDescription from the collection.
            myCollection.Remove(myServiceDescription2)
            Console.WriteLine("Element at index {0} is removed.", _
               myIndex.ToString())
' </Snippet13>
' </Snippet12>
         Else
            Console.WriteLine("Element not found.")
         End If
' </Snippet11>
      Catch e As Exception
         Console.WriteLine("The following exception was raised: {0}", e.Message.ToString())
      End Try
   End Sub 'Main
End Class 'MyServiceDescriptionCollection
