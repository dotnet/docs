        Dim myArray As Array = New Integer() { 1, 2, 4 }
        SyncLock(myArray.SyncRoot) 
            For Each item As Object In myArray
                Console.WriteLine(item)
            Next
        End SyncLock