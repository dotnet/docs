            Dim strings() As String = {"Hello", "world"}
            Dim bw As New MyBodyWriter(strings)

            Dim strBuilder As New StringBuilder(10)
            Dim writer = XmlWriter.Create(strBuilder)
            Dim dictionaryWriter = XmlDictionaryWriter.CreateDictionaryWriter(writer)

            bw.WriteBodyContents(dictionaryWriter)
            dictionaryWriter.Flush()