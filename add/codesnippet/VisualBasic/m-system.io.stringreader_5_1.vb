    Shared Sub ReadText(aTextReader As TextReader)
        Console.WriteLine("From {0} - {1}", _
            aTextReader.GetType().Name, aTextReader.ReadToEnd())
    End Sub