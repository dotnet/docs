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


