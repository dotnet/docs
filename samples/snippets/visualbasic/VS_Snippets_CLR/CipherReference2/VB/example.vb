'<SNIPPET1>
Imports System
Imports System.Security.Cryptography.Xml
Imports System.Xml
Imports System.IO


' This sample used the GetXml method in the CipherReference class
' to write the value of CipherReference to the console.
Module Module1

    Sub Main()
        ' Create a URI string.
        Dim uri As String = "http://www.woodgrovebank.com/document.xml"
        ' Create a Base64 transform. The input content retrieved from the
        ' URI should be Base64-decoded before other processing.
        Dim base64 As Transform = New XmlDsigBase64Transform
        Dim tc As New TransformChain
        tc.Add(base64)
        ' Create <CipherReference> information.
        Dim reference As CipherReference = New CipherReference(uri, tc)
	' Write the XML for the CipherReference to the console.
	Console.WriteLine("Cipher Reference: {0}", reference.GetXml().OuterXml)
    End Sub

End Module
'</SNIPPET1>
