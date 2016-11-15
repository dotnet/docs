For Each foundFile As String In
My.Computer.FileSystem.GetFiles("C:\Documents and Settings")
foundFile = foundFile & vbCrLf
My.Computer.FileSystem.WriteAllText(
  "C:\Documents and Settings\FileList.txt", foundFile, True)
Next