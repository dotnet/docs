'<snippet1>
Imports System
Imports System.IO
Imports System.Xml

Namespace Microsoft.Samples.Xml

    Public Class Sample

        Private Const filename As String = "book.xml"

        Public Shared Sub Main()

            Dim mySample As Sample = New Sample()
            mySample.Run(filename)
        End Sub

        Public Sub Run(ByVal args As String)

            ' Create and load the XML document.
            Console.WriteLine("Loading file {0} ...", args)
            Dim doc As XmlDocument = New XmlDocument()
            doc.Load(args)

            'Create the event handlers.
            AddHandler doc.NodeChanged, AddressOf MyNodeChangedEvent
            AddHandler doc.NodeInserted, AddressOf MyNodeInsertedEvent

            ' Change the book price.
            doc.DocumentElement.LastChild.InnerText = "5.95"

            ' Add a new element.
            Dim newElem As XmlElement = doc.CreateElement("style")
            newElem.InnerText = "hardcover"
            doc.DocumentElement.AppendChild(newElem)

            Console.WriteLine()
            Console.WriteLine("Display the modified XML...")
            Console.WriteLine(doc.OuterXml)

        End Sub

        ' Handle the NodeChanged event.
        Private Sub MyNodeChangedEvent(ByVal source As Object, ByVal args As XmlNodeChangedEventArgs)
            Console.Write("Node Changed Event: <{0}> changed", args.Node.Name)
            If Not (args.Node.Value Is Nothing) Then
                Console.WriteLine(" with value  {0}", args.Node.Value)
            Else
                Console.WriteLine("")
            End If
        End Sub

        ' Handle the NodeInserted event.
        Private Sub MyNodeInsertedEvent(ByVal source As Object, ByVal args As XmlNodeChangedEventArgs)
            Console.Write("Node Inserted Event: <{0}> inserted", args.Node.Name)
            If Not (args.Node.Value Is Nothing) Then
                Console.WriteLine(" with value {0}", args.Node.Value)
            Else
                Console.WriteLine("")
            End If
        End Sub

    End Class

End Namespace
'</snippet1>