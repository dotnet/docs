' System.Web.Services.Description.ServiceDescriptionCollection.ServiceDescriptionCollection()
' System.Web.Services.Description.ServiceDescriptionCollection.Add()
' System.Web.Services.Description.ServiceDescriptionCollection.Item(Int32)

' The following program demonstrates 'Constructor', 'Add' method and 
' 'Item' property of 'ServiceDescriptionCollection' class. It creates an
' instance of 'ServiceDescriptionCollection' and adds  
' 'ServiceDescription' objects to the collection. The Item property is used to 
' display the TargetNamespace of elements in the collection.
' 
' Note: This program requires 'DataTypes_VB.wsdl' and 'MathService_VB.wsdl' 
' files to be placed in same directory as that of .exe for running.

Imports System
Imports System.Web.Services.Description

Class MyServiceDescriptionCollection
   
   Public Shared Sub Main()
      Try
         Dim myServiceDescription1 As ServiceDescription = _
                 ServiceDescription.Read("DataTypes_VB.wsdl")
         Dim myServiceDescription2 As ServiceDescription =  _
                 ServiceDescription.Read("MathService_VB.wsdl")

' <Snippet11>
' <Snippet12>
         ' Create a ServiceDescriptionCollection.
         Dim myCollection As New ServiceDescriptionCollection()

         ' Add ServiceDescriptions to the collection. 
         myCollection.Add(myServiceDescription1)
         myCollection.Add(myServiceDescription2)
' </Snippet12>
' </Snippet11>

' <Snippet13>
         ' Display element properties in the collection using 
         ' the Item property.
         Dim i As Integer
         For i = 0 To myCollection.Count - 1
            Console.WriteLine(myCollection(i).TargetNamespace)
         Next i
' </Snippet13>
      Catch e As Exception
         Console.WriteLine("The following exception was raised: {0}", e.Message.ToString())
      End Try
   End Sub 'Main
End Class 'MyServiceDescriptionCollection
