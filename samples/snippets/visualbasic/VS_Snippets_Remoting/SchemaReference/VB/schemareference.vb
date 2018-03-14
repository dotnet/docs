' System.Web.Services.Discovery.SchemaReference.SchemaReference()
' System.Web.Services.Discovery.SchemaReference.SchemaReference(string)
' System.Web.Services.Discovery.SchemaReference.SchemaReference.DefaultFileName
' System.Web.Services.Discovery.SchemaReference.SchemaReference.Namespace
' System.Web.Services.Discovery.SchemaReference.SchemaReference.ReadDocument(stream)
' System.Web.Services.Discovery.SchemaReference.SchemaReference.Schema
' System.Web.Services.Discovery.SchemaReference.SchemaReference.Ref
' System.Web.Services.Discovery.SchemaReference.SchemaReference.TargetNamespace
' System.Web.Services.Discovery.SchemaReference.SchemaReference.Url
' System.Web.Services.Discovery.SchemaReference.SchemaReference.WriteDocument(object,stream)
' System.Web.Services.Discovery.SchemaReference.SchemaReference

' This example demonstrates 'SchemaReference' class, its constructors, 'ReadDocument',
' 'WriteDocument', 'Namespace, 'DefaultFileName', 'Schema', 'Ref', 'TargetNamespace',
' and 'Url' members. A variable of type 'SchemaReference' is taken. A xml schema 
' document is passed as parameter to overloaded constructor. All the membes are shown
' using 'SchemaReference' variable. 
'  Note : The dataservice.xsd file should be copied to Inetpub\wwwroot

' <Snippet1> 
Imports System
Imports System.IO
Imports System.Net
Imports System.Xml
Imports System.Xml.Schema
Imports System.Web.Services.Discovery

Public Module SchemaReferenceModule

   Public Sub Main()
      Try

' <Snippet2>

         ' Reference the schema document.
         Dim myStringUrl As String = "c:\\Inetpub\\wwwroot\\dataservice.xsd"
         Dim myXmlSchema As XmlSchema

         ' Create the client protocol.
         Dim myDiscoveryClientProtocol As DiscoveryClientProtocol = _
             New DiscoveryClientProtocol()
         myDiscoveryClientProtocol.Credentials = _
             CredentialCache.DefaultCredentials

         ' Create a schema reference.
         Dim mySchemaReferenceNoParam As SchemaReference = New SchemaReference()

         Dim mySchemaReference As SchemaReference = _
             New SchemaReference(myStringUrl)

         ' Set the client protocol.
         mySchemaReference.ClientProtocol = myDiscoveryClientProtocol

         ' Access the default file name associated with the schema reference.
         Console.WriteLine("Default filename is : " & _
             mySchemaReference.DefaultFilename)

         ' Access the namespace associated with schema reference class.
         Console.WriteLine("Namespace is : " & SchemaReference.Namespace)

         Dim myStream As FileStream = _
             New FileStream(myStringUrl, FileMode.OpenOrCreate)

         ' Read the document in a stream.
         mySchemaReference.ReadDocument(myStream)

         ' Get the schema of the referenced document.
         myXmlSchema = mySchemaReference.Schema

         Console.WriteLine("Reference is : " & mySchemaReference.Ref)

         Console.WriteLine("Target namespace (default empty) is : " & _
             mySchemaReference.TargetNamespace)

         Console.WriteLine("URL is : " & mySchemaReference.Url)

         ' Write the document in the stream.
         mySchemaReference.WriteDocument(myXmlSchema, myStream)

         myStream.Close()
         mySchemaReference = Nothing
' </Snippet2>
      Catch e As Exception

         Console.WriteLine(e.ToString)

      End Try

   End Sub
End Module

' </Snippet1> 
