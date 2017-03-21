Dim someData As Object
someData = My.Computer.Clipboard.GetDataObject()
My.Computer.FileSystem.WriteAllBytes("C:\mylogfile", someData, True)