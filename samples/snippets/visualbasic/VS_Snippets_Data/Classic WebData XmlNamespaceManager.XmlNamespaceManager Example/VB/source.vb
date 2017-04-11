Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Xml.Xsl
Imports System.Xml.XPath
Imports System.Xml.Schema



Public Class Class1
    
    Public Sub Method1()
        ' <Snippet1>
        Dim reader As New XmlTextReader("myfile.xml")
        Dim nsmanager As New XmlNamespaceManager(reader.NameTable)
        nsmanager.AddNamespace("msbooks", "www.microsoft.com/books")
        nsmanager.PushScope()
        nsmanager.AddNamespace("msstore", "www.microsoft.com/store")
        While reader.Read()
            Console.WriteLine("Reader Prefix:{0}", reader.Prefix)
            Console.WriteLine("XmlNamespaceManager Prefix:{0}",             nsmanager.LookupPrefix(nsmanager.NameTable.Get(reader.NamespaceURI)))
        End While
        ' </Snippet1>
    End Sub 'Method1
End Class 'Class1 
