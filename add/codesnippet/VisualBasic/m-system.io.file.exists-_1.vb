Dim curFile As String = "c:\temp\test.txt"
Console.WriteLine(If(File.Exists(curFile), "File exists.", "File does not exist."))