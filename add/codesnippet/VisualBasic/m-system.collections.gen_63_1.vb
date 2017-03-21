            ' List all the avi files.
            Dim aviFiles As SortedSet(Of String) = mediaFiles1.GetViewBetween("avi", "avj")
            Console.WriteLine("AVI files:")
            For Each avi As String In aviFiles
                Console.WriteLine(vbTab & "{0}", avi)
            Next