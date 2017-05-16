
Imports System
Imports System.Net
Imports System.Text
Imports System.Threading



Public Class Test
    
    Public Shared Sub Main() 
        
       
        
        ' Constructor
        SampleConstructor()
        
        ' OriginalString
        SampleOriginalString()
        
        ' DNSSafeHost
        SampleDNSSafeHost()
        
        ' operator == and !==
        SampleOperatorEqual()
        
        ' IsBaseOf
        SampleIsBaseOf()
    
    End Sub 'Main
    
    
    
    
    
    ' Constructor
    Private Shared Sub SampleConstructor() 
        '<snippet2>
        ' Create an absolute Uri from a string.
        Dim absoluteUri As New Uri("http://www.contoso.com/")
        
        ' Create a relative Uri from a string.  allowRelative = true to allow for 
        ' creating a relative Uri.
        Dim relativeUri As New Uri("/catalog/shownew.htm?date=today")
        
        ' Check whether the new Uri is absolute or relative.
        If Not relativeUri.IsAbsoluteUri Then
            Console.WriteLine("{0} is a relative Uri.", relativeUri)
        End If 
        ' Create a new Uri from an absolute Uri and a relative Uri.
        Dim combinedUri As New Uri(absoluteUri, relativeUri)
        Console.WriteLine(combinedUri.AbsoluteUri)
    
    End Sub 'SampleConstructor
     '</snippet2>
    
    ' OriginalString
    Private Shared Sub SampleOriginalString() 
        '<snippet3>
        ' Create a new Uri from a string address.
        Dim uriAddress As New Uri("HTTP://www.ConToso.com:80//thick%20and%20thin.htm")
        
        ' Write the new Uri to the console and note the difference in the two values.
        ' ToString() gives the canonical version.  OriginalString gives the orginal 
        ' string that was passed to the constructor.
        ' The following outputs "http://www.contoso.com/thick and thin.htm".
        Console.WriteLine(uriAddress.ToString())
        
        ' The following outputs "HTTP://www.ConToso.com:80//thick%20and%20thin.htm".
        Console.WriteLine(uriAddress.OriginalString)
    
    End Sub 'SampleOriginalString
     '</snippet3>
    
    ' DNSSafeHost
    Private Shared Sub SampleDNSSafeHost() 
        '<snippet4>
        ' Create new Uri using a string address.         
        Dim address As New Uri("http://[fe80::200:39ff:fe36:1a2d%4]/temp/example.htm")
        
        ' Make the address DNS safe. 
        ' The following outputs "[fe80::200:39ff:fe36:1a2d]".
        Console.WriteLine(address.Host)
        
        ' The following outputs "fe80::200:39ff:fe36:1a2d%4".
        Console.WriteLine(address.DnsSafeHost)
    
    End Sub 'SampleDNSSafeHost
     '</snippet4>
    
    
    ' operator == and !==
    Private Shared Sub SampleOperatorEqual() 
        '<snippet5>
        ' Create some Uris.
        Dim address1 As New Uri("http://www.contoso.com/index.htm#search")
        Dim address2 As New Uri("http://www.contoso.com/index.htm")
        Dim address3 As New Uri("http://www.contoso.com/index.htm?date=today")
        
        ' The first two are equal because the fragment is ignored.
        If address1 = address2 Then
            Console.WriteLine("{0} is equal to {1}", address1.ToString(), address2.ToString())
        End If 
        ' The second two are not equal.
        If address2 <> address3 Then
            Console.WriteLine("{0} is not equal to {1}", address2.ToString(), address3.ToString())
        End If
     '</snippet5>
    End Sub 'SampleOperatorEqual
    
    
    ' IsBaseOf
    Private Shared Sub SampleIsBaseOf() 
        '<snippet6>
        ' Create a base Uri.
        Dim baseUri As New Uri("http://www.contoso.com/")
        
        ' Create a new Uri from a string.
        Dim uriAddress As New Uri("http://www.contoso.com/index.htm?date=today")
        
        ' Determine whether BaseUri is a base of UriAddress.  
        If baseUri.IsBaseOf(uriAddress) Then
            Console.WriteLine("{0} is the base of {1}", baseUri, uriAddress)
        End If
     '</snippet6>
    End Sub 'SampleIsBaseOf
End Class 'Test