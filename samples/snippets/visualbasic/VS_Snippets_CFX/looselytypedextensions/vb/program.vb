' Copyright (c) Microsoft Corporation. All rights reserved.

Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Linq
Imports System.Text
Imports System.ServiceModel.Syndication
Imports System.Runtime.Serialization

Imports System.Xml
Imports System.Xml.Linq
Imports System.Xml.Serialization
Imports System.IO
Namespace Microsoft.Syndication.Samples

    Class Program
        Shared Sub Main(ByVal args As String())
            'Create an extensible object (in this case, SyndicationFeed). Other extensible types (SyndicationItem,
            'SyndicationCategory, SyndicationPerson, SyndicationLink) follow the same pattern.
            ' <Snippet0>
            Dim feed As New SyndicationFeed()

            'Attribute extensions are stored in a dictionary indexed by XmlQualifiedName
            feed.AttributeExtensions.Add(New XmlQualifiedName("myAttribute", ""), "someValue")
            ' </Snippet0>

            'Add several different types of element extensions.
            feed.ElementExtensions.Add("simpleString", "", "hello, world!")
            feed.ElementExtensions.Add("simpleString", "", "another simple string")

            feed.ElementExtensions.Add(New DataContractExtension With {.Key = "X", .Value = 4})
            feed.ElementExtensions.Add(New XmlSerializerExtension With {.Key = "Y", .Value = 8}, New XmlSerializer(GetType(XmlSerializerExtension)))

            feed.ElementExtensions.Add(New XElement("xElementExtension", _
                                        New XElement("Key", New XAttribute("attr1", "someValue"), "Z"), _
                                        New XElement("Value", New XAttribute("attr1", "someValue"), "15")).CreateReader())


            'Dump the raw feed XML to the console to show how extensions elements appear in the final XML
            Console.WriteLine("Raw XML")
            Console.WriteLine("-------")
            DumpToConsole(feed.GetAtom10Formatter())
            Console.WriteLine(Environment.NewLine)

            'Read in the XML into a new SyndicationFeed to show the "read" path
            Dim inputStream As Stream = WriteToMemoryStream(feed.GetAtom10Formatter())
            Dim feed2 As SyndicationFeed = SyndicationFeed.Load(New XmlTextReader(inputStream))


            Console.WriteLine("Attribute Extensions")
            Console.WriteLine("--------------------")

            Console.WriteLine(feed.AttributeExtensions(New XmlQualifiedName("myAttribute", "")))
            Console.WriteLine("")


            Console.WriteLine("Primitive Extensions")
            Console.WriteLine("--------------------")
            For Each s As String In feed2.ElementExtensions.ReadElementExtensions(Of String)("simpleString", "")
                Console.WriteLine(s)
            Next

            Console.WriteLine("")

            Console.WriteLine("SerializableExtensions")
            Console.WriteLine("----------------------")

            For Each dce As DataContractExtension In feed2.ElementExtensions.ReadElementExtensions(Of DataContractExtension)("DataContractExtension", "http://schemas.datacontract.org/2004/07/SyndicationExtensions")
                Console.WriteLine(dce.ToString())
            Next

            Console.WriteLine("")

            For Each xse As XmlSerializerExtension In feed2.ElementExtensions.ReadElementExtensions(Of XmlSerializerExtension)("XmlSerializerExtension", "", New XmlSerializer(GetType(XmlSerializerExtension)))
                Console.WriteLine(xse.ToString())
            Next

            Console.WriteLine("")

            Console.WriteLine("XElement Extensions")
            Console.WriteLine("-------------------")

            'Dim query = From extension In feed2.ElementExtensions _
            '            Where extension.OuterName = "xElementExtension" _
            '            Select extension

            For Each extension As SyndicationElementExtension In (From ext In feed2.ElementExtensions Where ext.OuterName = "xElementExtension" Select ext)
                Dim xelement As XNode = XNode.ReadFrom(extension.GetReader())
                Console.WriteLine(xelement.ToString())
            Next


            Console.WriteLine("")

            Console.WriteLine("Reader over all extensions")
            Console.WriteLine("--------------------------")

            Dim extensionsReader As XmlReader = feed2.ElementExtensions.GetReaderAtElementExtensions()

            While extensionsReader.IsStartElement()
                Dim extension As XNode = XElement.ReadFrom(extensionsReader)
                Console.WriteLine(extension.ToString())
            End While

            Console.ReadLine()

        End Sub

        Private Shared Sub DumpToConsole(ByVal formatter As SyndicationFeedFormatter)
            Dim writer As XmlWriter = XmlTextWriter.Create(Console.Out, New XmlWriterSettings() With {.Indent = True})

            formatter.WriteTo(writer)
            writer.Flush()
        End Sub

        Private Shared Function WriteToMemoryStream(ByVal formatter As SyndicationFeedFormatter) As Stream
            Dim strm As New MemoryStream()
            Dim writer As XmlWriter = XmlTextWriter.Create(strm, New XmlWriterSettings() With {.Indent = True})

            formatter.WriteTo(writer)
            writer.Flush()
            strm.Position = 0

            WriteToMemoryStream = strm
        End Function

    End Class

End Namespace
