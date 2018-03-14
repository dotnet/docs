' <snippet1>
Option Explicit On
Option Strict On

Imports System
Imports System.Xml
Imports System.Xml.Schema

Namespace Microsoft.Samples.Xml

    NotInheritable Class XmlDocumentSample

        Private Sub New()

        End Sub

        Shared reader As XmlReader
        Shared filename As String = "bookdtd.xml"

        Public Shared Sub Main()


            Dim eventHandler As New ValidationEventHandler(AddressOf XmlDocumentSample.ValidationCallback)

            Try

                ' Create the validating reader and specify DTD validation.
                Dim settings As New XmlReaderSettings()
                settings.DtdProcessing = DtdProcessing.Parse
                settings.ValidationType = ValidationType.DTD
                AddHandler settings.ValidationEventHandler, eventHandler

                reader = XmlReader.Create(filename, settings)

                ' Pass the validating reader to the XML document.
                ' Validation fails due to an undefined attribute, but the 
                ' data is still loaded into the document.
                Dim doc As New XmlDocument()
                doc.Load(reader)
                Console.WriteLine(doc.OuterXml)
            
            Finally

                If Not (reader Is Nothing) Then
                    reader.Close()
                End If

            End Try

        End Sub

        ' Display the validation error.
        Private Shared Sub ValidationCallback(ByVal sender As Object, ByVal args As ValidationEventArgs)
            Console.WriteLine("Validation error loading: {0}", filename)
            Console.WriteLine(args.Message)
        End Sub

    End Class
End Namespace
'</snippet1>