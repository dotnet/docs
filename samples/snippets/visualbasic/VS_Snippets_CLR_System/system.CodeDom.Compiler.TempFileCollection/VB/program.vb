 '<Snippet1>
Imports System
Imports System.CodeDom.Compiler
Imports System.IO



Class Program
    
    Shared Sub Main(ByVal args() As String) 
        ' Create a directory in the current working directory.
        Directory.CreateDirectory("testDir")
        Dim tfc As New TempFileCollection("testDir", False)
        ' Returns the file name relative to the current working directory.
        Dim fileName As String = tfc.AddExtension("txt")
        Console.WriteLine(fileName)
        '<Snippet2>
        ' Name a file in the test directory.
        Dim file2Name As String = "testDir\test.txt"
        ' Add the file to the temp directory and indicate it is to be kept.
        tfc.AddFile(file2Name, True)
        '</Snippet2>
        Console.WriteLine(tfc.Count)
        ' Create and use the test files.
        Dim fs1 As FileStream = File.OpenWrite(fileName)
        Dim fs2 As FileStream = File.OpenWrite(file2Name)
        Dim sw1 As New StreamWriter(fs1)
        Dim sw2 As New StreamWriter(fs2)
        sw1.WriteLine("Test string")
        sw2.WriteLine("Test string")
        sw1.Close()
        sw2.Close()
        tfc.Delete()
        Console.WriteLine(tfc.Count)
        Try
            ' This call should succeed.
            File.OpenRead(file2Name)
            ' This call should fail.
            File.OpenRead(fileName)
        Catch e As FileNotFoundException
            Console.WriteLine(e.Message)
        End Try
    
    End Sub 'Main 
End Class 'Program

'</Snippet1>