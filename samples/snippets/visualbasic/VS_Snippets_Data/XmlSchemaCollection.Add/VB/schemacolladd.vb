Imports System
Imports System.Xml
Imports System.Xml.Schema

Namespace Microsoft.Samples.Xml.Schema

    Public NotInheritable Class Sample

        Private Sub New()

        End Sub

        Public Shared Sub Main()

            '<snippet1>
            Dim sc As XmlSchemaCollection = New XmlSchemaCollection()
            AddHandler sc.ValidationEventHandler, AddressOf ValidationCallBack

            ' Create a resolver with the necessary credentials.
            Dim resolver As XmlUrlResolver = New XmlUrlResolver()
            resolver.Credentials = System.Net.CredentialCache.DefaultCredentials

            ' Add the new schema to the collection.
            sc.Add("", New XmlTextReader("sample.xsd"), resolver)
            '</snippet1>

            If (sc.Count > 0) Then
                Dim tr As XmlTextReader = New XmlTextReader("notValidXSD.xml")
                Dim rdr As XmlValidatingReader = New XmlValidatingReader(tr)

                rdr.ValidationType = ValidationType.Schema
                rdr.Schemas.Add(sc)
                AddHandler rdr.ValidationEventHandler, AddressOf ValidationCallBack
                While (rdr.Read())
                End While
            End If

        End Sub

        Private Shared Sub ValidationCallBack(ByVal sender As Object, ByVal e As ValidationEventArgs)
            Console.WriteLine("XSD Error: {0}", e.Message)
        End Sub

    End Class

End Namespace