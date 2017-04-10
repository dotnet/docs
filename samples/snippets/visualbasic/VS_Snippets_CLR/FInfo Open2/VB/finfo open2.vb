' <Snippet1>
imports System
imports System.IO
imports System.Text

Public Class Test
	Public Shared Sub Main()
		Dim path As String = "c:\MyTest.txt"
		Dim fi As FileInfo = new FileInfo(path)
		Dim fs As FileStream

		' Delete the file if it exists.
		If fi.Exists = False
			'Create the file.
			fs = fi.Create()
			Dim info As Byte() = _
					New UTF8Encoding(true).GetBytes( _
						"This is some text in the file.")

			'Add some information to the file.
			fs.Write(info, 0, info.Length)
			fs.Close()
		End If

		'Open the stream and read it back.
		fs = fi.Open(FileMode.Open, FileAccess.Read)
		Dim b(1024) As byte
		Dim temp As UTF8Encoding = New UTF8Encoding(true)

		Do While fs.Read(b,0,b.Length) > 0
			Console.WriteLine(temp.GetString(b))
		Loop
            Try
                fs.Write(b,0,b.Length)
                Catch e As Exception
                Console.WriteLine("Writing was disallowed, as expected: {0}", e.ToString())
            End Try
        fs.Close()
	End Sub
End Class
'This code produces output similar to the following; 
'results may vary based on the computer/file structure/etc.:
'
'This is some text in the file.
'
'
'
'
'
'
'
'
'
'
'
'
'Writing was disallowed, as expected: System.NotSupportedException: Stream does 
'not support writing.
'   at System.IO.__Error.WriteNotSupported()
'   at System.IO.FileStream.Write(Byte[] array, Int32 offset, Int32 count)
'   at VB_Console_Application.Test.Main() in C:\Documents and Settings\MyComputer
'\My Documents\Visual Studio 2005\Projects\finfo open2\finfo open2\Module1.vb:line 34
'
' </Snippet1>
