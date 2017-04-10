' System.Web.Services.Protocols.SoapServerMessage
' System.Web.Services.Protocols.SoapServerMessage.Action
' System.Web.Services.Protocols.SoapServerMessage.Server
' System.Web.Services.Protocols.SoapServerMessage.MethodInfo
' System.Web.Services.Protocols.SoapServerMessage.OneWay
' System.Web.Services.Protocols.SoapServerMessage.Url

'   The following example demonstrates the 'Action', 'Client', 'MethodInfo',
'   'OneWay' and 'Url' properties  of the 'SoapServerMessage' class. The program 
'   extends the 'SoapExtension' class to create a class that is used to log the 
'   SOAP messages transferred for a web service method invocation. 
'   To associate this 'SoapExtension' class with the web service 
'   method a class that extends from 'SoapExtensionAttribute' is used. 
'   This 'SoapExtensionAttribute' is applied to a web service method. 
'   Whenever this method is invoked on the server, all the SOAP message 
'   that get transfered both from the client(which is accessing the web service) 
'   and the server are written into a log file. 

<%@ WebService Language="vb" Class="MathSvc" %>

Imports System
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.IO
Imports Microsoft.VisualBasic

Public Class MySoapExtension
   Inherits SoapExtension
   Private oldStream As Stream
   Private newStream As Stream
   Private filename As String
   
   ' Return the file name that is to log the SOAP messages.
   Overloads Public Overrides Function GetInitializer( _
      methodInfo As LogicalMethodInfo, attribute As SoapExtensionAttribute) _
      As Object
      Return CType(attribute, MySoapExtensionAttribute).Filename
   End Function 'GetInitializer
   
   ' Return the file name that is to log the SOAP messages.
   Overloads Public Overrides Function GetInitializer(filename As Type) _
      As Object
      Return CType(filename, Type)
   End Function 'GetInitializer
   
   ' Save the name of the log file that will save the SOAP messages.
   Public Overrides Sub Initialize(initializer As Object)
      filename = CStr(initializer)
   End Sub 'Initialize
   
' <Snippet1>
   ' Process the SOAP message received and write it to a log file.
   Public Overrides Sub ProcessMessage(message As SoapMessage)
      Select Case message.Stage
         Case SoapMessageStage.BeforeSerialize
         Case SoapMessageStage.AfterSerialize
            WriteOutput(CType(message, SoapServerMessage))
         Case SoapMessageStage.BeforeDeserialize
            WriteInputBeforeDeserialize(CType(message, SoapServerMessage))
         Case SoapMessageStage.AfterDeserialize
            WriteInputAfterDeserialize(CType(message, SoapServerMessage))
         Case Else
               Throw New Exception("invalid stage")
      End Select
   End Sub 'ProcessMessage
   
   
   ' Write the contents of the incoming SOAP message to the log file.
   Public Sub WriteInputAfterDeserialize(message As SoapServerMessage)
' <Snippet2>
' <Snippet3>
' <Snippet4>
' <Snippet5>
' <Snippet6>
      Dim myFileStream As New FileStream(filename, FileMode.Append, FileAccess.Write)
      Dim myStreamWriter As New StreamWriter(myFileStream)
      
      ' Print to the log file the request header field for SoapAction header.
      myStreamWriter.WriteLine("The SoapAction Http request header field is: ")
      myStreamWriter.WriteLine((ControlChars.Tab + message.Action))
      
      ' Print to the log file the type of the XML Web service.
      myStreamWriter.WriteLine("The type of the XML Web service is: ")
      If message.Server.GetType().Equals(GetType(MathSvc)) Then
         myStreamWriter.WriteLine(ControlChars.Tab + "MathSvc")
      End If
      
      ' Print to the log file the name of the XML Web service method.
      myStreamWriter.WriteLine("The name of the XML Web service method requested:")
      myStreamWriter.WriteLine((ControlChars.Tab + message.MethodInfo.Name))
      
      ' Print to the log file if the method invoked is OneWay.
      If message.OneWay Then
         myStreamWriter.WriteLine( _
            "The client doesn't wait for the server to finish processing")
      Else
         myStreamWriter.WriteLine( _
            "The client waits for the server to finish processing")
      End If 
      
      ' Print to the log file the URL of the site that provides 
      ' implementation of the XML Web service method.
      myStreamWriter.WriteLine( _
         "The url of the XML Web service method requested: ")
      myStreamWriter.WriteLine((ControlChars.Tab + message.Url))
      myStreamWriter.Flush()
      myStreamWriter.Close()
      myFileStream.Close()
' </Snippet6>
' </Snippet5>
' </Snippet4>
' </Snippet3>
' </Snippet2>
   End Sub 'WriteInputAfterDeserialize
' </Snippet1>
   ' Write the contents of the incoming SOAP message to the log file.
   Public Sub WriteInputBeforeDeserialize(message As SoapServerMessage)
      Copy(oldStream, newStream)
      Dim myFileStream As New FileStream(filename, FileMode.Append, FileAccess.Write)
      Dim myStreamWriter As New StreamWriter(myFileStream)
      myStreamWriter.WriteLine( _
         "================================== Request at " + DateTime.Now)
      myStreamWriter.WriteLine("The contents of the SOAP envelope are: ")
      myStreamWriter.Flush()
      newStream.Position = 0
      Copy(newStream, myFileStream)
      myFileStream.Close()
      newStream.Position = 0
   End Sub 'WriteInputBeforeDeserialize
      
   ' Write the contents of the outgoing SOAP message to the log file.
   Public Sub WriteOutput(message As SoapServerMessage)
      newStream.Position = 0
      Dim myFileStream As _
         New FileStream(filename, FileMode.Append, FileAccess.Write)
      Dim myStreamWriter As New StreamWriter(myFileStream)
      myStreamWriter.WriteLine( _
         "---------------------------------- Response at " + DateTime.Now)
      myStreamWriter.Flush()
      Copy(newStream, myFileStream)
      myFileStream.Close()
      newStream.Position = 0
      Copy(newStream, oldStream)
   End Sub 'WriteOutput
   
   ' Return a new MemoryStream for SOAP processing.
   Public Overrides Function ChainStream(stream As Stream) As Stream
      oldStream = stream
      newStream = New MemoryStream()
      Return newStream
   End Function 'ChainStream
   
   ' Utility method to copy the contents of one stream to another. 
   Sub Copy(fromStream As Stream, toStream As Stream)
      Dim myTextReader = New StreamReader(fromStream)
      Dim myTextWriter = New StreamWriter(toStream)
      myTextWriter.WriteLine(myTextReader.ReadToEnd())
      myTextWriter.Flush()
   End Sub 'Copy
End Class 'MySoapExtension

' A SoapExtensionAttribute that can be associated with an
' XML Web service method.

<AttributeUsage(AttributeTargets.Method)> _
Public Class MySoapExtensionAttribute
   Inherits SoapExtensionAttribute
   Private myFilename As String
   Private myPriority As Integer
   
   ' Set the name of the log file where SOAP messages will be stored.
   Public Sub New()
      myFilename = "C:\logService.txt"
   End Sub 'New
   
   ' Return the type of MySoapExtension class.   
   Public Overrides ReadOnly Property ExtensionType() As Type
      Get
         Return GetType(MySoapExtension)
      End Get
   End Property
   
   ' User can set priority of the SoapExtension.   
   Public Overrides Property Priority() As Integer
      Get
         Return myPriority
      End Get
      Set
         myPriority = value
      End Set
   End Property
   
   Public Property Filename() As String
      Get
         Return myFilename
      End Get
      Set
         myFilename = value
      End Set
   End Property
End Class 'MySoapExtensionAttribute

Public Class MathSvc
   Inherits WebService
   
   <WebMethod(), MySoapExtensionAttribute()> _
   Public Function Add(xValue As Single, yValue As Single) As Single
      Return xValue + yValue
   End Function 'Add
End Class 'MathSvc
