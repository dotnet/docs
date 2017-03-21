    Public Sub DisplayAttributes(reader As XmlReader)
        If reader.HasAttributes Then
            Console.WriteLine("Attributes of <" & reader.Name & ">")
            Dim i As Integer
            For i = 0 To reader.AttributeCount - 1
                reader.MoveToAttribute(i)
                Console.Write(" {0}={1}", reader.Name, reader.Value)
            Next i
            reader.MoveToElement() 'Moves the reader back to the element node.
        End If
    End Sub 'DisplayAttributes