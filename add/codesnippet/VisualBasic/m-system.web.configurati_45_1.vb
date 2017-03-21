        ' Display item details of the collection.
        For i As Integer = 0 To (TrustLevelCollection1.Count - 1)
          Console.WriteLine("Collection item {0}", i)
          Console.WriteLine("Name: {0}", _
           TrustLevelCollection1.Get(i).Name)
          Console.WriteLine("PolicyFile: {0}", _
           TrustLevelCollection1.Get(i).PolicyFile)
          Console.WriteLine()
        Next i