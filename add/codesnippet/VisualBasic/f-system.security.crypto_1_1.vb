Imports System
Imports System.IO
Imports System.Xml
Imports System.Security.Cryptography
Imports System.Security.Cryptography.Xml



Class Class1

    <STAThread()> _
    Shared Sub Main(ByVal args() As String)
        ' Encrypt a sample XML string.
        Dim productsXml As XmlDocument = LoadProducts()
        ShowTransformProperties(productsXml)

        ' Encrypt an XPath Xml string.
        Dim transformXml As XmlDocument = LoadTransformByXml()
        ShowTransformProperties(transformXml)

        ' Use XmlDsigXPathTransform to resolve a Uri.
        Dim baseUri As New Uri("http://www.contoso.com")
        Dim relativeUri As String = "xml"
        Dim absoluteUri As Uri = ResolveUris(baseUri, relativeUri)

        Console.WriteLine("This sample completed successfully; " + "press Enter to exit.")
        Console.ReadLine()

    End Sub 'Main


    ' Encrypt the text in the specified XmlDocument.
    Private Shared Sub ShowTransformProperties(ByVal xmlDoc As XmlDocument)
        ' Create a new XMLDocument object.
        Dim doc As New XmlDocument()

        ' Create a new XmlElement.
        Dim xPathElem As XmlElement = doc.CreateElement("XPath")

        ' Set the element text to the value
        ' of the XPath string.
        xPathElem.InnerText = "ancestor-or-self::PRODUCTS"

        ' Create a new XmlDsigXPathTransform object.
        Dim xmlTransform As New XmlDsigXPathTransform()

        ' Load the XPath XML from the element. 
        xmlTransform.LoadInnerXml(xPathElem.SelectNodes("."))
        ' Ensure the transform is using the proper algorithm.
        xmlTransform.Algorithm = SignedXml.XmlDsigXPathTransformUrl
        ' Retrieve the XML representation of the current transform.
        Dim xmlInTransform As XmlElement = xmlTransform.GetXml()
        Console.WriteLine(vbLf + "Xml representation of the current transform: ")
        Console.WriteLine(xmlInTransform.OuterXml)

        ' Retrieve the valid input types for the current transform.
        Dim validInTypes As Type() = xmlTransform.InputTypes
        ' Verify the xmlTransform can accept the XMLDocument as an
        ' input type.
        Dim i As Integer
        For i = 0 To validInTypes.Length
            If validInTypes(i).Equals(xmlDoc.GetType()) Then
                ' Load the document into the transfrom.
                xmlTransform.LoadInput(xmlDoc)
                Try
                    ' This transform is created for demonstration purposes.
                    Dim secondTransform As New XmlDsigXPathTransform()

                    Dim classDescription As String = secondTransform.ToString()
                    xmlTransform.LoadInnerXml(xPathElem.SelectNodes("."))
                Catch
                    Console.WriteLine("Caught exception while trying to " + "load the specified Xml document. The document " + "requires an XPath element to be valid.")
                End Try
                Exit For
            End If
        Next i

        Dim validOutTypes As Type() = xmlTransform.OutputTypes
        For i = validOutTypes.Length - 1 To 0 Step -1
            If validOutTypes(i).Equals(GetType(System.Xml.XmlDocument)) Then
                Try
                    Dim xmlDocumentType As Type = GetType(System.Xml.XmlDocument)
                    Dim xmlDocumentOutput As XmlDocument = CType(xmlTransform.GetOutput(xmlDocumentType), XmlDocument)
                    ' Display to the console the Xml before and after
                    ' encryption.
                    Console.WriteLine("Result of the GetOutput method call" + " from the current transform: " + xmlDocumentOutput.OuterXml)
                Catch ex As Exception
                    Console.WriteLine("Unexpected exception caught: " + ex.ToString())
                End Try

                Exit For
            ElseIf validOutTypes(i).Equals(GetType(System.Xml.XmlNodeList)) Then
                Try
                    Dim xmlNodeListType As Type = GetType(System.Xml.XmlNodeList)
                    Dim xmlNodes As XmlNodeList = CType(xmlTransform.GetOutput(xmlNodeListType), XmlNodeList)

                    ' Display to the console the Xml before and after
                    ' encryption.
                    Console.WriteLine("Encoding the following message: " + xmlDoc.InnerText)

                    Console.WriteLine("Nodes of the XmlNodeList retrieved " + "from GetOutput:")
                    Dim j As Integer
                    For j = 0 To xmlNodes.Count
                        Console.WriteLine("Node " + j + " has the following name: " + xmlNodes.Item(j).Name + " and the following InnerXml: " + xmlNodes.Item(j).InnerXml)
                    Next j
                Catch ex As Exception
                    Console.WriteLine("Unexpected exception caught: " + ex.ToString())
                End Try

                Exit For
            Else
                Dim outputObject As Object = xmlTransform.GetOutput()
            End If 
        Next i

    End Sub 'ShowTransformProperties


    ' Create an XML document for the dsig namespace.
    Private Shared Function LoadTransformByXml() As XmlDocument
        Dim xmlDoc As New XmlDocument()

        Dim transformXml As String = "<Signature><Reference URI=''><Transforms>"
        transformXml += "<Transform><XPath "
        transformXml += "xmlns:dsig='http://www.w3.org/2000/09/xmldsig#'>"
        transformXml += "not(ancestor-or-self::dsig:Signature)"
        transformXml += "</XPath></Transform>"
        transformXml += "</Transforms></Reference></Signature>"

        xmlDoc.LoadXml(transformXml)
        Return xmlDoc

    End Function 'LoadTransformByXml


    ' Create an XML document describing various products.
    Private Shared Function LoadProducts() As XmlDocument
        Dim xmlDoc As New XmlDocument()

        Dim contosoProducts As String = "<PRODUCTS>"
        contosoProducts += "<PRODUCT><ID>123</ID>"
        contosoProducts += "<DESCRIPTION>Router</DESCRIPTION></PRODUCT>"
        contosoProducts += "<PRODUCT><ID>456</ID>"
        contosoProducts += "<DESCRIPTION>Keyboard</DESCRIPTION></PRODUCT>"
        contosoProducts += "<PRODUCT><ID>789</ID>"
        contosoProducts += "<DESCRIPTION>Monitor</DESCRIPTION></PRODUCT>"
        contosoProducts += "</PRODUCTS>"

        xmlDoc.LoadXml(contosoProducts)
        Return xmlDoc

    End Function 'LoadProducts


    ' Resolve the specified base and relative Uri's .
    Private Shared Function ResolveUris(ByVal baseUri As Uri, ByVal relativeUri As String) As Uri
        Dim xmlResolver As New XmlUrlResolver()
        xmlResolver.Credentials = System.Net.CredentialCache.DefaultCredentials

        Dim xmlTransform As New XmlDsigXPathTransform()
        xmlTransform.Resolver = xmlResolver
        Dim absoluteUri As Uri = xmlResolver.ResolveUri(baseUri, relativeUri)

        If Not (absoluteUri Is Nothing) Then
            Console.WriteLine(vbLf + "Resolved the base Uri and relative Uri to the following:")
            Console.WriteLine(absoluteUri.ToString())
        Else
            Console.WriteLine("Unable to resolve the base Uri and relative Uri")
        End If
        Return absoluteUri

    End Function
End Class