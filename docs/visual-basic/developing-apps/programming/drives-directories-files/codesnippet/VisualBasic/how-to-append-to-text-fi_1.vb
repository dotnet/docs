Dim inputString As String = "This is a test string."
My.Computer.FileSystem.WriteAllText(
  "C://testfile.txt", inputString, True)