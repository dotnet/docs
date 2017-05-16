Imports System
Imports System.Text
Imports System.IO
Imports System.Xml
Imports System.Xml.Xsl
Imports System.Xml.XPath
Imports System.Net


Class XslCompiledTransform_Samples
    
    
    Shared Sub Main() 
    
    End Sub 'Main
     
    
' Transform files
Shared Sub XslCompiledTransform_Transform1() 
'<snippet1>
' Load the style sheet.
Dim xslt As New XslCompiledTransform()
xslt.Load("output.xsl")
        
' Execute the transform and output the results to a file.
xslt.Transform("books.xml", "books.html")
'</snippet1>    
End Sub 'XslCompiledTransform_Transform1
     
    
'==============================//
' Transform URI and XmlWriter
Shared Sub XslCompiledTransform_Transform2() 
'<snippet2>
' Load the style sheet.
Dim xslt As New XslCompiledTransform()
xslt.Load("output.xsl")
        
' Create the writer.
Dim settings As New XmlWriterSettings()
settings.Indent = True
settings.IndentChars = vbTab
Dim writer As XmlWriter = XmlWriter.Create("output.xml", settings)
        
' Execute the transformation.
xslt.Transform("books.xml", writer)
writer.Close()
'</snippet2>    
End Sub 'XslCompiledTransform_Transform2
     
    
'==============================//
' Transform URI and TextWriter
Shared Sub XslCompiledTransform_Transform3() 
'<snippet3>
' Load the style sheet.
Dim xslt As New XslCompiledTransform()
xslt.Load("HTML_out.xsl")
        
' Transform the file and output an HTML string.
Dim HTMLoutput As String
Dim writer As New StringWriter()
xslt.Transform("books.xml", Nothing, writer)
HTMLoutput = writer.ToString()
writer.Close()
'</snippet3>    
End Sub 'XslCompiledTransform_Transform3
     
    
'==============================//		
' Transform with document function
Shared Sub XslCompiledTransform_Transform4() 
        Dim UserName As String = "username"
        Dim SecurelyStoredPassword As String = "psswd"
        Dim Domain As String = "domain"
        
'<snippet4>
' Create a resolver and specify the necessary credentials.
Dim resolver As New XmlSecureResolver(New XmlUrlResolver(), "http://serverName/data/")
Dim myCred As System.Net.NetworkCredential
myCred = New System.Net.NetworkCredential(UserName, SecurelyStoredPassword, Domain)
resolver.Credentials = myCred
        
Dim settings As New XsltSettings()
settings.EnableDocumentFunction = True
        
' Load the style sheet.
Dim xslt As New XslCompiledTransform()
xslt.Load("http://serverName/data/xsl/sort.xsl", settings, resolver)
        
' Transform the file.
        Using reader As XmlReader = XmlReader.Create("books.xml")

            Using writer As XmlWriter = XmlWriter.Create("output.xml")
                xslt.Transform(reader, Nothing, writer, resolver)
            End Using

        End Using
'</snippet4>    
End Sub 'XslCompiledTransform_Transform4
    
    
'==============================//
' Transform XPathDocument and XmlWriter
Shared Sub XslCompiledTransform_Transform5() 
'<snippet5>
' Load the style sheet.
Dim xslt As New XslCompiledTransform()
xslt.Load("output.xsl")
        
' Create the writer.
Dim settings As New XmlWriterSettings()
settings.Indent = True
settings.IndentChars = vbTab
Dim writer As XmlWriter = XmlWriter.Create("output.xml", settings)
        
' Execute the transformation.
xslt.Transform(New XPathDocument("books.xml"), writer)
writer.Close()
'</snippet5>    
End Sub 'XslCompiledTransform_Transform5
     
    
'==============================//
' Transform XPathDocument and FileStream
Shared Sub XslCompiledTransform_Transform6() 
'<snippet6>
' Load the style sheet.
Dim xslt As New XslCompiledTransform()
xslt.Load("output.xsl")
        
' Create the FileStream.
Using fs As New FileStream("c:\data\output.xml", FileMode.Create)
   ' Execute the transformation.
    xslt.Transform(New XPathDocument("books.xml"), Nothing, fs)
End Using
'</snippet6>    
End Sub 'XslCompiledTransform_Transform6
     
    
'==============================//
' Transform XmlReader and XmlWriter
Shared Sub XslCompiledTransform_Transform7() 
'<snippet7>
' Load the style sheet.
Dim xslt As New XslCompiledTransform()
xslt.Load("output.xsl")
        
' Create the writer.
Dim settings As New XmlWriterSettings()
settings.Indent = True
settings.IndentChars = vbTab
Dim writer As XmlWriter = XmlWriter.Create("output.xml", settings)
        
Dim reader As XmlReader = XmlReader.Create("books.xml")
reader.MoveToContent()
        
' Execute the transformation.
xslt.Transform(reader, writer)
writer.Close()
reader.Close()
'</snippet7>    
  End Sub 'XslCompiledTransform_Transform7 

'==============================//
    ' Print Names of Temp Files
    Shared Sub Print_TempFiles()
        '<snippet8>
        ' Create the XslCompiledTransform object.
        Dim xslt As New XslCompiledTransform(True)

        ' Load the style sheet and enable scripts.
        ' Temporary files are created only for style sheets with <msxsl:script> blocks.
        xslt.Load("output.xsl", XsltSettings.TrustedXslt, New XmlUrlResolver())

        ' Transform the file.
        xslt.Transform("books.xml", "output.xml")

        ' Output names of temporary files.
        Dim filename As String
        For Each filename In xslt.TemporaryFiles
            Console.WriteLine(filename)
        Next filename
        '</snippet8>
    End Sub 'Print_TempFiles

End Class 'XslCompiledTransform_Samples
