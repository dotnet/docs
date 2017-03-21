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