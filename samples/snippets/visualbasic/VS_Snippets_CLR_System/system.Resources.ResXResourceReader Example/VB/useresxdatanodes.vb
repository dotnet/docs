'<Snippet2>
Imports System
Imports System.Collections
Imports System.Resources
Imports System.ComponentModel.Design

Namespace UseDataNodesExample
    Public Class Program
        Public Shared Sub Main()
            Console.WriteLine(vbNewLine + "Enumerating as data items...")
            EnumResourceItems("Resource1.resx", False)

            Console.WriteLine(vbNewLine + "Enumerating as data nodes...")
            EnumResourceItems("Resource1.resx", True)
        End Sub

        Public Shared Sub EnumResourceItems(resxFile As String, useDataNodes As Boolean)
            Using reader As New ResXResourceReader(resxFile)
                reader.UseResXDataNodes = useDataNodes

                '<Snippet3>
                ' Enumerate using IEnumerable.GetEnumerator().
                Console.WriteLine(vbNewLine + "  Default enumerator:")
                For Each entry As DictionaryEntry In reader
                    ShowResourceItem(entry, useDataNodes)
                Next entry
                '</Snippet3>

                '<Snippet4>
                ' Enumerate using GetMetadataEnumerator()
                Dim metadataEnumerator As IDictionaryEnumerator = reader.GetMetadataEnumerator()

                Console.WriteLine(vbNewLine + "  MetadataEnumerator:")
                While metadataEnumerator.MoveNext()
                    ShowResourceItem(metadataEnumerator.Entry, useDataNodes)
                End While
                '</Snippet4>

                '<Snippet5>
                ' Enumerate using GetEnumerator()
                Dim enumerator As IDictionaryEnumerator = reader.GetEnumerator()

                Console.WriteLine(vbNewLine + "  Enumerator:")
                While enumerator.MoveNext()
                    ShowResourceItem(enumerator.Entry, useDataNodes)
                End While
                '</Snippet5>
            End Using
        End Sub

        Public Shared Sub ShowResourceItem(entry As DictionaryEntry, isDataNode As Boolean)
            ' Use a Nothing type resolver.
            Dim typeres As ITypeResolutionService = Nothing
            Dim dnode As ResXDataNode

            If isDataNode Then
                ' Display from node info.
                dnode = CType(entry.Value, ResXDataNode)
                Console.WriteLine("  {0}={1}", dnode.Name, dnode.GetValue(typeres))
            Else
                ' Display as DictionaryEntry info.
                Console.WriteLine("  {0}={1}", entry.Key, entry.Value)
            End If
        End Sub
    End Class
End Namespace

' The example program will have the following output:
'
' Enumerating as data items...
'
'   Default enumerator:
'   DataSample=Sample DATA value
'
'   MetadataEnumerator:
'   MetadataSample=Sample METADATA value
'
'   Enumerator:
'   DataSample=Sample DATA value
'
' Enumerating as data nodes...
'
'   Default enumerator:
'   DataSample=Sample DATA value
'   MetadataSample=Sample METADATA value
'
'   MetadataEnumerator:
'
'   Enumerator:
'   DataSample=Sample DATA value
'   MetadataSample=Sample METADATA value
'</Snippet2>