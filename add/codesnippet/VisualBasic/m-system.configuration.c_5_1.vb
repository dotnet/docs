            Dim i As Integer = 0
            While secEnum.MoveNext()
                Dim setionName _
                As String = sections.GetKey(i)
                Console.WriteLine( _
                "Section name: {0}", setionName)
                i += 1
            End While