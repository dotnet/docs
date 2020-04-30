Option Strict On

Module Module1

    Sub Main()
        TestIterator()
        TestWithoutIterator()
    End Sub

    Sub TestIterator()
        Dim memoryBefore = GC.GetTotalMemory(True)

        '<Snippet10>
        Dim adminRequests = 
            From line In New StreamReaderEnumerable("..\..\log.txt")
            Where line.Contains("admin.aspx 401")

        Dim results = adminRequests.ToList()
        '</Snippet10>

        Dim memoryAfter = GC.GetTotalMemory(False)

        Console.WriteLine("Memory Used With Iterator = " & vbTab & Format((memoryAfter - memoryBefore) / 1000, "n") & "kb")
    End Sub

    Sub TestWithoutIterator()
        Dim memoryBefore = GC.GetTotalMemory(True)

        Dim sr = My.Computer.FileSystem.OpenTextFileReader("..\..\log.txt")

        Dim fileContents As New List(Of String)
        While Not sr.EndOfStream
            fileContents.Add(sr.ReadLine())
        End While

        Dim adminRequests = 
            From line In fileContents 
            Where line.Contains("admin.aspx 401")

        Dim results = adminRequests.ToList()

        sr.Close()

        Dim memoryAfter = GC.GetTotalMemory(False)

        Console.WriteLine("Memory Used Without Iterator = " & vbTab & Format((memoryAfter - memoryBefore) / 1000, "n") & "kb")

    End Sub

End Module

