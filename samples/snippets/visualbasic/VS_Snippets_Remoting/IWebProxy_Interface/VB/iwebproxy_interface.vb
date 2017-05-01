 '
'  This program demonstrates  'Credentials' property, 'GetProxy' and 'IsBypassed' methods of 
'  IWebProxy interface.
'  The 'WebProxy_Interface' class implements the 'IWebProxy' interface. It provides an implementation for the
'  'GetProxy' and 'IsByPassed' methods and 'ICredentials' property. The 'GetProxy' method returns the url 
'  of the proxy server as specified in the constructor. The 'IsByPassed' method returns false indicating 
'  that the proxy server must never be bypassed for any requested url. The 'ICredentials' property stores 
'  the credentials required by the proxy server to authenticate the actual user.
'

Imports System
Imports System.Net
Imports Microsoft.VisualBasic

' <Snippet1>
' <Snippet2>
' <snippet3>
Public Class WebProxy_Interface
    Implements IWebProxy
    
    
    'The credentials to be used with the web proxy.
    Private iCredentials As ICredentials
    
    'Uri of the associated proxy server.
    Private webProxyUri As Uri
    
    
    Sub New(proxyUri As Uri)
        
        webProxyUri = proxyUri
    End Sub 'New 
    

    'Get and Set the Credentials property.
    
    Public Property Credentials() As ICredentials Implements IWebProxy.Credentials
        Get
            Return iCredentials
        End Get
        Set
            If iCredentials Is value Then
                iCredentials = value
            End If
        End Set
    End Property
     
    'Returns the web proxy for the specified destination(destUri).
    Public Function GetProxy(destUri As Uri) As Uri Implements IWebProxy.GetProxy
        
        'Always use the same proxy.
        Return webProxyUri
    End Function 'GetProxy
     
    
    'Returns whether the web proxy should be bypassed for the specified destination(hostUri).
    Public Function IsBypassed(hostUri As Uri) As Boolean Implements IWebProxy.IsBypassed
       'Never bypass the proxy.
        Return False
    End Function 'IsBypassed 
End Class 'WebProxy_Interface



' </Snippet3>
' </Snippet2>
' </Snippet1>

Public Class WebProxy_Example

   '<Snippet4>
   
    Public Shared Sub Main()
        Dim webProxy_Interface As New WebProxy_Interface(New Uri("http://proxy.example.com"))
        
        webProxy_Interface.Credentials = New NetworkCredential("myusername", "mypassword")
        
        Console.WriteLine("The web proxy is : {0}", webProxy_Interface.GetProxy(New Uri("http://www.contoso.com")))
        
        'Determine whether the Web proxy can be bypassed for the site "http://www.contoso.com".
	console.writeline("For the Uri http://www.contoso.com , the ")
        If webProxy_Interface.IsBypassed(New Uri("http://www.contoso.com")) Then
            Console.WriteLine("webproxy is by passed")
        Else
            Console.WriteLine("webproxy is not bypassed")
        End If 
    End Sub 'Main

    '</Snippet4>
    
End Class 'WebProxy_Example