                Dim parameters _
                As NameValueCollection = pSettings.Parameters

                Dim pEnum _
                As IEnumerator = parameters.GetEnumerator()

                Dim i As Integer = 0
                While pEnum.MoveNext()
                    Dim pLength As String = _
                    parameters(i).Length.ToString()
                    Console.WriteLine( _
                    "Provider ssettings: {0} has {1} parameters", _
                    pSettings.Name, pLength)
                End While
            Next pSettings