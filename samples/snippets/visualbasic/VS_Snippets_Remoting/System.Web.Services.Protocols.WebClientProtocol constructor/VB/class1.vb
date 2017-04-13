Imports System
Imports System.Diagnostics
Imports System.Xml.Serialization
Imports System.Web.Services.Protocols
Imports System.Web.Services


Namespace WebClientProtocol_Constructor
    ' This class derives from System.Web.Services.Protocols.WebClientProtocol
    ' as if the user is implemented his own protocol.
    ' It demonstrates the use of WebClientProtocol's constructor.
    ' <Snippet1>
    Class TempConvertService
        Inherits System.Web.Services.Protocols.WebClientProtocol
      
        Public Sub New()
           MyBase.New()
           ' Rest of class initialization.
        End Sub 
    End Class 
    ' </Snippet1>
End Namespace 'WebClientProtocol_Constructor
