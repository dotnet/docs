Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization
Imports Microsoft.VisualBasic


Public Class Sample
    
    ' <Snippet1>
    Private Sub PrintNamespacePairs(ByVal namespaces As XmlSerializerNamespaces)
        Dim qualifiedNames() As XmlQualifiedName = namespaces.ToArray()
        Dim i As Integer
        For i = 0 To qualifiedNames.Length - 1
            Console.WriteLine(qualifiedNames(i).Name & ControlChars.Tab & _
                              qualifiedNames(i).Namespace)
        Next i
    End Sub

    ' </Snippet1>
End Class
