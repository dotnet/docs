        Dim list As System.Collections.ObjectModel.
          ReadOnlyCollection(Of String)
        list = My.Computer.FileSystem.FindInFiles("C:\TestDir", 
         "sample string", True, FileIO.SearchOption.SearchTopLevelOnly)
        For Each name In list
            ListBox1.Items.Add(name)
        Next