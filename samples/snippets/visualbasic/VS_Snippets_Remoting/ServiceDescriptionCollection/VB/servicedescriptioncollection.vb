' System.Web.Services.Description.ServiceDescriptionCollection

' The following program demonstrates the 'ServiceDescriptionCollection' class.
' It creates two 'ServiceDescription' objects and add them to 
' 'ServiceDescriptionCollection' object. It displays the name of 'ServiceDescription'
' objects using 'Item' property. 'GetBinding' method is used to display binding instance of the 
' 'ServiceDescription' object.
' 
' Note: This program requires 'DataTypes_VB.wsdl' and 'MathService_VB.wsdl' files to 
' be placed in same directory as that of .exe for running.

' <Snippet1>
Imports System
Imports System.Xml
Imports System.Web.Services.Description

Class MyServiceDescriptionCollection
   
   Public Shared Sub Main()
      Try
         ' Get ServiceDescription objects.
         Dim myServiceDescription1 As ServiceDescription = _
            ServiceDescription.Read("DataTypes_VB.wsdl")
         Dim myServiceDescription2 As ServiceDescription = _
            ServiceDescription.Read("MathService_VB.wsdl")

         ' Set the names of the ServiceDescriptions.
         myServiceDescription1.Name = "DataTypes"
         myServiceDescription2.Name = "MathService"
         
         ' Create a ServiceDescriptionCollection.
         Dim myServiceDescriptionCollection As _
            New ServiceDescriptionCollection()
         
         ' Add the ServiceDescriptions to the collection. 
         myServiceDescriptionCollection.Add(myServiceDescription1)
         myServiceDescriptionCollection.Add(myServiceDescription2)
         
         ' Display the elements of the collection using the Item property.
         Console.WriteLine("Elements in the collection: ")
         Dim i As Integer
         For i = 0 To myServiceDescriptionCollection.Count - 1
            Console.WriteLine(myServiceDescriptionCollection(i).Name)
         Next i

         ' Construct an XML qualified name.
         Dim myXmlQualifiedName As New XmlQualifiedName( _
            "MathServiceSoap", "http://tempuri2.org/")
         
         ' Get the Binding from the collection.
         Dim myBinding As Binding =  _
            myServiceDescriptionCollection.GetBinding(myXmlQualifiedName)
         
         Console.WriteLine("Binding found in collection with name: " &  _
            myBinding.ServiceDescription.Name)
      Catch e As Exception
         Console.WriteLine("The following exception was raised: {0}", _
                 e.Message.ToString())
      End Try
   End Sub 'Main
End Class 'MyServiceDescriptionCollection
' </Snippet1>
