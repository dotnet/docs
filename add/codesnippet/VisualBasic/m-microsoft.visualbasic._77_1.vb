Dim someData As Object
someData = My.Computer.Clipboard.GetData("specialformat")
My.Computer.FileSystem.WriteAllBytes("C:\\mylogfile", someData, True)