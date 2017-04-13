'<snippet1>
Imports System
Imports System.Xml.Xsl

Module Module1

    Sub Main()
        'Create a new XslCompiledTransform and load the compiled transformation.
        Dim xslt As New XslCompiledTransform()
        xslt.Load(GetType(Transform))

        'Execute the transform and output the results to a file.
        xslt.Transform("books.xml", "discount_books.html")
    End Sub

End Module
'</snippet1>