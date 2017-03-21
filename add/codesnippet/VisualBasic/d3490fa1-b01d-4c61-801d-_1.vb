Dim list = My.Computer.FileSystem.GetFiles(
    My.Computer.FileSystem.SpecialDirectories.MyDocuments)
Dim listReader As New System.Collections.Specialized.StringCollection
For Each item As String In list
   listReader.Add(item)
Next
My.Computer.Clipboard.SetFileDropList(listReader)