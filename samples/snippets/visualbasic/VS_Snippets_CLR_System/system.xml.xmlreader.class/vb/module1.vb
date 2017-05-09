Imports System.Runtime.CompilerServices
Imports System.Xml

Module Module1

    Sub Main()
        If True Then

        End If
    End Sub


    ' <Snippet1>
    <Extension()>
    Public Async Function ReadStartElementAsync(reader As XmlReader, localname As String, ns As String) As Task
        If (Await reader.MoveToContentAsync() <> XmlNodeType.Element) Then
            Throw New InvalidOperationException(reader.NodeType.ToString() + " is an invalid XmlNodeType")
        End If

        If ((reader.LocalName = localname) And (reader.NamespaceURI = ns)) Then
            Await reader.ReadAsync()
        Else
            Throw New InvalidOperationException("localName or namespace doesn’t match")
        End If
    End Function
    ' </Snippet1>

    ' <Snippet2>
    <Extension()>
    Public Async Function ReadEndElementAsync(reader As XmlReader) As task
        If (Await reader.MoveToContentAsync() <> XmlNodeType.EndElement) Then
            Throw New InvalidOperationException()
        End If
        Await reader.ReadAsync()
    End Function
    ' </Snippet2>


    ' <Snippet3>
    <Extension()>
    Public Async Function ReadToNextSiblingAsync(reader As XmlReader, localName As String, namespaceURI As String) As Task(Of Boolean)
        If (localName = Nothing Or localName.Length = 0) Then
            Throw New ArgumentException("localName is empty or null")
        End If

        If (namespaceURI = Nothing) Then
            Throw New ArgumentNullException("namespaceURI")
        End If

        ' atomize local name and namespace
        localName = reader.NameTable.Add(localName)
        namespaceURI = reader.NameTable.Add(namespaceURI)

        ' find the next sibling
        Dim nt As XmlNodeType
        Do

            Await reader.SkipAsync()
            If (reader.ReadState <> ReadState.Interactive) Then
                Exit Do
            End If
            nt = reader.NodeType
            If ((nt = XmlNodeType.Element) And
               ((CObj(localName) = CObj(reader.LocalName))) And
               (CObj(namespaceURI) = CObj(reader.NamespaceURI))) Then
                Return True
            End If
        Loop While (nt <> XmlNodeType.EndElement And (Not reader.EOF))

        Return False

    End Function
    ' </Snippet3>


    ' <Snippet4>
    <Extension()>
    Public Async Function ReadToFollowingAsync(reader As XmlReader, localName As String, namespaceURI As String) As Task(Of Boolean)
        If (localName = Nothing Or localName.Length = 0) Then
            Throw New ArgumentException("localName is empty or null")
        End If

        If (namespaceURI = Nothing) Then
            Throw New ArgumentNullException("namespaceURI")
        End If

        ' atomize local name and namespace
        localName = reader.NameTable.Add(localName)
        namespaceURI = reader.NameTable.Add(namespaceURI)

        ' find element with that name
        While (Await reader.ReadAsync())
            If ((reader.NodeType = XmlNodeType.Element) And
               (CObj(localName) = CObj(reader.LocalName)) And
               (CObj(namespaceURI) = CObj(reader.NamespaceURI))) Then
                Return True
            End If
        End While

        Return False
    End Function
    ' </Snippet4>

    ' <Snippet5>
    <Extension()>
    Public Async Function ReadToDescendantAsync(reader As XmlReader, localName As String, namespaceURI As String) As Task(Of Boolean)
        If (localName = Nothing Or localName.Length = 0) Then
            Throw New ArgumentException("localName is empty or null")
        End If

        If (namespaceURI = Nothing) Then
            Throw New ArgumentNullException("namespaceURI")
        End If

        ' save the element or root depth
        Dim parentDepth As Integer = reader.Depth
        If (reader.NodeType <> XmlNodeType.Element) Then
            ' adjust the depth if we are on root node
            If (reader.ReadState = ReadState.Initial) Then
                parentDepth -= 1
            Else
                Return False
            End If
        ElseIf (reader.IsEmptyElement) Then
            Return False
        End If
        ' atomize local name and namespace
        localName = reader.NameTable.Add(localName)
        namespaceURI = reader.NameTable.Add(namespaceURI)

        ' find the descendant
        While (Await reader.ReadAsync() And reader.Depth > parentDepth)
            If (reader.NodeType = XmlNodeType.Element And
               (CObj(localName) = CObj(reader.LocalName)) And
               (CObj(namespaceURI) = CObj(reader.NamespaceURI))) Then
                Return True
            End If
        End While

        Return False
    End Function
    ' </Snippet5>

    ' <Snippet6>
    Public Async Function TestReader(stream As System.IO.Stream) As Task
        Dim settings As New XmlReaderSettings()
        settings.Async = True

        Using reader As XmlReader = XmlReader.Create(stream, settings)
            While (Await reader.ReadAsync())
                Select Case (reader.NodeType)
                    Case XmlNodeType.Element
                        Console.WriteLine("Start Element {0}", reader.Name)
                    Case XmlNodeType.Text
                        Console.WriteLine("Text Node: {0}",
                                 Await reader.GetValueAsync())
                    Case XmlNodeType.EndElement
                        Console.WriteLine("End Element {0}", reader.Name)
                    Case Else
                        Console.WriteLine("Other node {0} with value {1}",
                                        reader.NodeType, reader.Value)
                End Select
            End While
        End Using
    End Function
    ' </Snippet6>



End Module
