    Public Sub DisplayAttributes(reader As XmlReader)
        If reader.HasAttributes Then
            Console.WriteLine("Attributes of <" & reader.Name & ">")
            While reader.MoveToNextAttribute()
                Console.WriteLine(" {0}={1}", reader.Name, reader.Value)
            End While
        End If
    End Sub 'DisplayAttributes