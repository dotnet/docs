' System.Web.Services.Description.ServiceDescriptionCollection.GetBinding()

' The following program demonstrates the 'GetBinding' method 
' of 'ServiceDescriptionCollection' class. It searches for a 
' 'Binding' in the collection and returns the Binding instance.
' On success, a message is displayed on the console.
' 
' Note: This program requires 'DataTypes_VB.wsdl' and 'MathService_VB.wsdl'
' files to be placed in same directory as that of .exe for running.

Imports System
Imports System.Xml
Imports System.Web.Services.Description


Class MyServiceDescriptionCollection
   
   Public Shared Sub Main()
      Try
         Dim myServiceDescription1 As ServiceDescription = _
                 ServiceDescription.Read("DataTypes_VB.wsdl")
         Dim myServiceDescription2 As ServiceDescription = _
                 ServiceDescription.Read("MathService_VB.wsdl")
         
         ' Create the object of 'ServiceDescriptionCollection' class.
         Dim myCollection As New ServiceDescriptionCollection()
         ' Add ServiceDescription objects.
         myCollection.Add(myServiceDescription1)
         myCollection.Add(myServiceDescription2)
' <Snippet1>
         ' Construct an XML qualified name.
         Dim myXmlQualifiedName As _
            New XmlQualifiedName("MathServiceSoap", "http://tempuri2.org/")
         
         ' Get the Binding from the collection.
         Dim myBinding As Binding = _
            myCollection.GetBinding(myXmlQualifiedName)
' </Snippet1>
         Console.WriteLine("Specified Binding is a member of ServiceDescription" + _
                 " instances within the collection")
      Catch e As Exception
         Console.WriteLine("The following exception was raised: {0}", e.Message.ToString())
      End Try
   End Sub 'Main
End Class 'MyServiceDescriptionCollection
