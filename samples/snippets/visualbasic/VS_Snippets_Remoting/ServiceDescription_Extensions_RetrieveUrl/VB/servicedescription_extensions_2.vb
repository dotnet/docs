' System.Web.Services.Description.ServiceDescription.Extensions
' System.Web.Services.Description.ServiceDescription.RetrievalUrl

' The following program demonstrates properties 'Extensions', 'RetrievalUrl' of 
' 'ServiceDescription' class. The input to the program is a WSDL file
' 'ServiceDescription_Extensions_Input_vb.wsdl'. This program adds one object 
' to the extensions collection and displays the count and set the 'RetrievalURL' and displays.

Imports System
Imports System.Web.Services
Imports System.Web.Services.Description

Class MyServiceDescription
   
   Public Shared Sub Main()
' <Snippet1>
' <Snippet2>
      Dim myServiceDescription As New ServiceDescription()
      myServiceDescription = _
         ServiceDescription.Read("ServiceDescription_Extensions_Input_vb.wsdl")
      Console.WriteLine( _
         myServiceDescription.Bindings(1).Extensions(0).ToString())
      Dim mySoapBinding As New SoapBinding()
      mySoapBinding.Required = True
      Dim mySoapBinding1 As New SoapBinding()
      mySoapBinding1.Required = False
      myServiceDescription.Extensions.Add(mySoapBinding)
      myServiceDescription.Extensions.Add(mySoapBinding1)
      Dim myServiceDescriptionFormatExtension As _
         ServiceDescriptionFormatExtension
      For Each myServiceDescriptionFormatExtension _
         In myServiceDescription.Extensions
         Console.WriteLine("Required: " & _
            myServiceDescriptionFormatExtension.Required.ToString())
      Next myServiceDescriptionFormatExtension
      myServiceDescription.Write("ServiceDescription_Extensions_Output_vb.wsdl")
      myServiceDescription.RetrievalUrl = "http://www.contoso.com/"
      Console.WriteLine("Retrieval URL is: " & _
         myServiceDescription.RetrievalUrl)
' </Snippet2>
' </Snippet1>
   End Sub 'Main 

End Class 'MyServiceDescription 
