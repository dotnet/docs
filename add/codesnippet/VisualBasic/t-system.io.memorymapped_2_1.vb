            Using Stream As MemoryMappedViewStream = mmf.CreateViewStream()
                Dim writer As BinaryWriter = New BinaryWriter(Stream)
                writer.Write(1)
            End Using