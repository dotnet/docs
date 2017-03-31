
Imports System
Imports System.Net
Imports System.Text
Imports System.Threading
Imports System.Runtime.Serialization



Public Class Test
    
    
    Public Shared Sub Main() 
        ' Snippets 1 and 2
        HexConversions()
        
        ' snippet 7
        SampleToString()
        
        ' snippet 8
        SampleEquals()
        
        ' snippets 4, 5, and 6
        GetParts()
        
        ' snippet 3
        SampleMakeRelative()
        
        ' snippets 9 - 17
        SampleCheckSchemeName()
        
        ' snippets 18 
        SampleUserInfo()
    
    End Sub 'Main
    
    
    Private Shared Sub SampleToString() 
        '<snippet7>
        ' Create a new Uri from a string address.
        Dim uriAddress As New Uri("HTTP://www.Contoso.com:80/thick%20and%20thin.htm")
        
        ' Write the new Uri to the console and note the difference in the two values.
        ' ToString() gives the canonical version.  OriginalString gives the orginal 
        ' string that was passed to the constructor.
        ' The following outputs "http://www.contoso.com/thick and thin.htm".
        Console.WriteLine(uriAddress.ToString())
        
        ' The following outputs "HTTP://www.Contoso.com:80/thick%20and%20thin.htm".
        Console.WriteLine(uriAddress.OriginalString)
    
    End Sub 'SampleToString
     '</snippet7>
    
    Private Shared Sub SampleEquals() 
        '<snippet8>
        ' Create some Uris.
        Dim address1 As New Uri("http://www.contoso.com/index.htm#search")
        Dim address2 As New Uri("http://www.contoso.com/index.htm")
        If address1.Equals(address2) Then
            Console.WriteLine("The two addresses are equal")
        Else
            Console.WriteLine("The two addresses are not equal")
        End If
     '</snippet8>
    End Sub 'SampleEquals
    
    
    Private Shared Sub GetParts() 
        '<snippet4>
        ' Create Uri
        Dim uriAddress As New Uri("http://www.contoso.com/index.htm#search")
        Console.WriteLine(uriAddress.Fragment)
        Console.WriteLine("Uri {0} the default port ", IIf(uriAddress.IsDefaultPort, "uses", "does not use")) 'TODO: For performance reasons this should be changed to nested IF statements
        
        Console.WriteLine("The path of this Uri is {0}", uriAddress.GetLeftPart(UriPartial.Path))
        Console.WriteLine("Hash code {0}", uriAddress.GetHashCode())
        '</snippet4>
        '<snippet5>
        Dim uriAddress1 As New Uri("http://www.contoso.com/title/index.htm")
        Console.WriteLine("The parts are {0}, {1}, {2}", uriAddress1.Segments(0), uriAddress1.Segments(1), uriAddress1.Segments(2))
        '</snippet5>
        '<snippet6>
        Dim uriAddress2 As New Uri("file://server/filename.ext")
        Console.WriteLine(uriAddress2.LocalPath)
        Console.WriteLine("Uri {0} a UNC path", IIf(uriAddress2.IsUnc, "is", "is not")) 'TODO: For performance reasons this should be changed to nested IF statements
        Console.WriteLine("Uri {0} a local host", IIf(uriAddress2.IsLoopback, "is", "is not")) 'TODO: For performance reasons this should be changed to nested IF statements
        Console.WriteLine("Uri {0} a file", IIf(uriAddress2.IsFile, "is", "is not")) 'TODO: For performance reasons this should be changed to nested IF statements
    
    End Sub 'GetParts
     '</snippet6>
    
    Private Shared Sub HexConversions() 
        '<snippet1>
        Dim testChar As Char = "e"c
        If Uri.IsHexDigit(testChar) = True Then
            Console.WriteLine("'{0}' is the hexadecimal representation of {1}", testChar, Uri.FromHex(testChar))
        Else
            Console.WriteLine("'{0}' is not a hexadecimal character", testChar)
        End If 
        Dim returnString As String = Uri.HexEscape(testChar)
        Console.WriteLine("The hexadecimal value of '{0}' is {1}", testChar, returnString)
        '</snippet1>
        '<snippet2>
        Dim testString As String = "%75"
        Dim index As Integer = 0
        If Uri.IsHexEncoding(testString, index) Then
            Console.WriteLine("The character is {0}", Uri.HexUnescape(testString, index))
        Else
            Console.WriteLine("The character is not hexadecimal encoded")
        End If
     '</snippet2>
    End Sub 'HexConversions
    
    
    
    ' MakeRelative
    Private Shared Sub SampleMakeRelative() 
        '<snippet3>
        ' Create a base Uri.
        Dim address1 As New Uri("http://www.contoso.com/")
        
        ' Create a new Uri from a string.
        Dim address2 As New Uri("http://www.contoso.com/index.htm?date=today")
        
        ' Determine the relative Uri.  
        Console.WriteLine("The difference is {0}", address1.MakeRelativeUri(address2))
    
    End Sub 'SampleMakeRelative
     '</snippet3>
    
    'CheckSchemeName
    Private Shared Sub SampleCheckSchemeName() 
        '<snippet9>
        Dim address1 As New Uri("http://www.contoso.com/index.htm#search")
        Console.WriteLine("address 1 {0} a valid scheme name", IIf(Uri.CheckSchemeName(address1.Scheme), " has", " does not have")) 'TODO: For performance reasons this should be changed to nested IF statements
        
        If address1.Scheme = Uri.UriSchemeHttp Then
            Console.WriteLine("Uri is HTTP type")
        End If 
        Console.WriteLine(address1.HostNameType)
        '</snippet9>
        
        '<snippet10>
        Dim address2 As New Uri("file://server/filename.ext")
        If address2.Scheme = Uri.UriSchemeFile Then
            Console.WriteLine("Uri is a file")
        End If 
        '</snippet10>
        Console.WriteLine(address2.HostNameType)
        
        '<snippet11>
        Dim address3 As New Uri("mailto:user@contoso.com?subject=uri")
        If address3.Scheme = Uri.UriSchemeMailto Then
            Console.WriteLine("Uri is an email address")
        End If 
        '</snippet11>        
        '<snippet12>    
        Dim address4 As New Uri("news:123456@contoso.com")
        If address4.Scheme = Uri.UriSchemeNews Then
            Console.WriteLine("Uri is an Internet news group")
        End If 
        '</snippet12>
        '<snippet13>
        Dim address5 As New Uri("nntp://news.contoso.com/123456@contoso.com")
        If address5.Scheme = Uri.UriSchemeNntp Then
            Console.WriteLine("Uri is nntp protocol")
        End If 
        '</snippet13>
        '<snippet14>
        Dim address6 As New Uri("gopher://example.contoso.com/")
        If address6.Scheme = Uri.UriSchemeGopher Then
            Console.WriteLine("Uri is Gopher protocol")
        End If 
        '</snippet14>
        '<snippet15>
        Dim address7 As New Uri("ftp://contoso/files/testfile.txt")
        If address7.Scheme = Uri.UriSchemeFtp Then
            Console.WriteLine("Uri is Ftp protocol")
        End If 
        '</snippet15>
        '<snippet16>
        Dim address8 As New Uri("https://example.contoso.com")
        If address8.Scheme = Uri.UriSchemeHttps Then
            Console.WriteLine("Uri is Https protocol.")
        End If 
        '</snippet16>
        '<snippet17>
        Dim address As String = "www.contoso.com"
        Dim uriString As String = String.Format("{0}{1}{2}", Uri.UriSchemeHttp, Uri.SchemeDelimiter, address)
        
        Dim result As Uri = New Uri(uriString)

        If result.IsWellFormedOriginalString() = True Then
            Console.WriteLine("{0} is a well formed Uri", uriString)
        else
            Console.WriteLine("{0} is not a well formed Uri", uriString)
        End If
        '</snippet17>
    End Sub 'SampleCheckSchemeName
    
    
    Private Shared Sub SampleUserInfo() 
        '<snippet18>
        Dim uriAddress As New Uri("http://user:password@www.contoso.com/index.htm ")
        Console.WriteLine(uriAddress.UserInfo)
        Console.WriteLine("Fully Escaped {0}", IIf(uriAddress.UserEscaped, "yes", "no")) 'TODO: For performance reasons this should be changed to nested IF statements
    
    End Sub 'SampleUserInfo 
        '</snippet18>
End Class 'Test
