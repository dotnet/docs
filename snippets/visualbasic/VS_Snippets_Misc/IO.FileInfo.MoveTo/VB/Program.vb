
'<SNIPPET1>
Imports System
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Xml

Module Program

	Private sourcePath As String = Environment.GetFolderPath _
	(Environment.SpecialFolder.MyDocuments) & _
	"\FileInfoTestDirectory\MoveFrom\FromFile.xml"
	'
	Private destPath As String = Environment.GetFolderPath _
	(Environment.SpecialFolder.MyDocuments) & _
	"\FileInfoTestDirectory\DestFile.xml"
	'
	' The main entry point for the application.
	'
	<STAThread()> Sub Main()
		' Change Console properties to make it obvious that 
		' the application is starting.
		Console.Clear()
		' Move it to the upper left corner of the screen.
		Console.SetWindowPosition(0, 0)
		' Make it very large.
		Console.SetWindowSize(Console.LargestWindowWidth - 24, _
			Console.LargestWindowHeight - 16)
		Console.WriteLine("Welcome.")
		Console.WriteLine("This application demonstrates the FileInfo.MoveTo method.")
		Console.WriteLine("Press any key to start.")
		Dim s As String = Console.ReadLine()
		Console.Write("    Checking whether ")
		Console.Write(sourcePath)
		Console.WriteLine(" exists.")
		Dim fInfo As FileInfo = New FileInfo(sourcePath)
		EnsureSourceFileExists()
		DisplayFileProperties(fInfo)
		Console.WriteLine("Preparing to move the file to ")
		Console.Write(destPath)
		Console.WriteLine(".")
		MoveFile(fInfo)
		DisplayFileProperties(fInfo)
		Console.WriteLine("Preparing to delete directories.")
		DeleteFiles()
		Console.WriteLine("Press the ENTER key to close this application.")
		s = Console.ReadLine()
	End Sub
	'
	' Moves the supplied FileInfo instance to destPath.
	'
	Private Sub MoveFile(ByVal fInfo As FileInfo)
		Try
			fInfo.MoveTo(destPath)
			Console.WriteLine("File moved to ")
			Console.WriteLine(destPath)
		Catch ex As Exception
			DisplayException(ex)
		End Try
	End Sub
	'
	' Ensures that the test directories 
	' and the file FromFile.xml all exist.
	'
	Private Sub EnsureSourceFileExists()
		' Create a FileInfo instance, and get the full path 
		' to the parent directory.
		Dim fInfo As FileInfo = New FileInfo(sourcePath)
		Dim dirPath As String = fInfo.Directory.FullName
		' If the directory does not exist, create it.
		If Not Directory.Exists(dirPath) Then
			Directory.CreateDirectory(dirPath)
		End If
		' If DestFile.xml exists, delete it.
		If File.Exists(destPath) Then
			File.Delete(destPath)
		End If
		Console.Write("Creating file ")
		Console.Write(fInfo.FullName)
		Console.WriteLine(".")
		Try
			If Not fInfo.Exists Then
				' Call WriteFileContent to create the file.
				Console.WriteLine("Adding data to the file.")
				WriteFileContent(10)
				Console.WriteLine("Successfully created the file.")
			End If
		Catch ex As Exception
			DisplayException(ex)
		Finally
			dirPath = Nothing
			fInfo = Nothing
		End Try
	End Sub
	'
	' Creates and saves an Xml file to sourcePath.
	'
	Private Sub WriteFileContent(ByVal totalElements As Integer)
		Dim doc As New XmlDocument()
		doc.PreserveWhitespace = True
		doc.AppendChild(doc.CreateXmlDeclaration("1.0", Nothing, "yes"))
		doc.AppendChild(doc.CreateWhitespace(ControlChars.CrLf))
		Dim root As XmlElement = doc.CreateElement("FileInfo.MoveTo")
		Dim index As Integer = 0
		Dim elem As XmlElement
		While index < totalElements
			elem = doc.CreateElement("MyElement")
			elem.SetAttribute("Index", index.ToString())
			elem.AppendChild(doc.CreateWhitespace(ControlChars.CrLf))
			elem.AppendChild(doc.CreateTextNode(String.Format _
			 ("MyElement at position {0}.", index)))
			elem.AppendChild(doc.CreateWhitespace(ControlChars.CrLf))
			root.AppendChild(elem)
			index += 1
		End While
		doc.AppendChild(root)
		doc.AppendChild(doc.CreateWhitespace(ControlChars.CrLf))
		doc.Save(sourcePath)
	End Sub
	'
	' Displays FullName, CreationTime, and LastWriteTime of the supplied
	' FileInfo instance, then displays the text of the file.
	'
	Private Sub DisplayFileProperties(ByVal fInfo As FileInfo)
		Console.WriteLine("The FileInfo instance shows these property values.")
		Dim reader As StreamReader = Nothing
		Try
			Console.Write("FullName: ")
			Console.WriteLine(fInfo.FullName)
			Console.Write("CreationTime: ")
			Console.WriteLine(fInfo.CreationTime)
			Console.Write("LastWriteTime: ")
			Console.WriteLine(fInfo.LastWriteTime)
			Console.WriteLine()
			Console.WriteLine("File contents:")
			Console.WriteLine()
			reader = New StreamReader(fInfo.FullName)
			While Not reader.EndOfStream
				Console.WriteLine(reader.ReadLine())
			End While
			Console.WriteLine()
		Catch ex As Exception
			DisplayException(ex)
		Finally
			If Not reader Is Nothing Then
				reader.Close()
				reader = Nothing
			End If
		End Try
	End Sub
	'
	' Deletes the test directory and all its files and subdirectories.
	'
	Private Sub DeleteFiles()
		Try
			Dim dInfo As DirectoryInfo = New DirectoryInfo(Environment.GetFolderPath _
			  (Environment.SpecialFolder.MyDocuments) + "\FileInfoTestDirectory")
			If dInfo.Exists Then
				dInfo.Delete(True)
				Console.WriteLine("Successfully deleted directories and files.")
			End If
			dInfo = Nothing
		Catch ex As Exception
			DisplayException(ex)
		End Try
	End Sub
	'
	' Displays information about the supplied Exception. This
	' code is not suitable for production applications.
	'
	Private Sub DisplayException(ByVal ex As Exception)
		Dim sb As New StringBuilder("An exception of type """)
		sb.Append(ex.GetType().FullName)
		sb.Append(""" has occurred.")
		sb.Append(ControlChars.CrLf)
		sb.Append(ex.Message)
		sb.Append(ControlChars.CrLf)
		sb.Append("Stack trace information:")
		sb.Append(ControlChars.CrLf)
		Dim matchCol As MatchCollection = Regex.Matches(ex.StackTrace, _
		"(at\s)(.+)(\.)([^\.]*)(\()([^\)]*)(\))((\sin\s)(.+)(:line )([\d]*))?")
		Dim L As Integer = matchCol.Count
		Dim y, K As Integer
		Dim argList() As String
		Dim matchObj As Match
		Dim x As Integer = 0
		While x < L
			matchObj = matchCol(x)
			sb.Append(ControlChars.CrLf)
			sb.Append(ControlChars.CrLf)
			sb.Append(matchObj.Result("$1 $2$3$4$5"))
			argList = matchObj.Groups(6).Value.Split(New Char() {","})
			K = argList.Length
			y = 0
			While y < K
				sb.Append(ControlChars.CrLf)
				sb.Append("    ")
				sb.Append(argList(y).Trim().Replace(" ", "        "))
				sb.Append(",")
				y += 1
			End While
			sb.Remove(sb.Length - 1, 1)
			sb.Append(ControlChars.CrLf)
			If 0 < matchObj.Groups(8).Length Then
				sb.Append(ControlChars.CrLf)
				sb.Append(matchObj.Result("$10"))
				sb.Append(ControlChars.CrLf)
				sb.Append(matchObj.Result("line $12"))
			End If
			x += 1
		End While
		argList = Nothing
		matchObj = Nothing
		matchCol = Nothing
		Console.WriteLine(sb.ToString())
		sb = Nothing
		Return
	End Sub
End Module

' Welcome.
' This application demonstrates the FileInfo.MoveTo method.
' Press any key to start.
' 
'     Checking whether C:\Documents and Settings\MyComputer\My Documents\FileInfoTestDirectory\MoveFrom\FromFile.xml exists.
' Creating file C:\Documents and Settings\MyComputer\My Documents\FileInfoTestDirectory\MoveFrom\FromFile.xml.
' Adding data to the file.
' Successfully created the file.
' The FileInfo instance shows these property values.
' FullName: C:\Documents and Settings\MyComputer\My Documents\FileInfoTestDirectory\MoveFrom\FromFile.xml
' CreationTime: 4/18/2006 1:38:19 PM
' LastWriteTime: 4/18/2006 1:38:19 PM
' 
' File contents:
' 
' <?xml version="1.0" standalone="yes"?>
' <FileInfo.MoveTo><MyElement Index="0">
' MyElement at position 0.
' </MyElement><MyElement Index="1">
' MyElement at position 1.
' </MyElement><MyElement Index="2">
' MyElement at position 2.
' </MyElement><MyElement Index="3">
' MyElement at position 3.
' </MyElement><MyElement Index="4">
' MyElement at position 4.
' </MyElement><MyElement Index="5">
' MyElement at position 5.
' </MyElement><MyElement Index="6">
' MyElement at position 6.
' </MyElement><MyElement Index="7">
' MyElement at position 7.
' </MyElement><MyElement Index="8">
' MyElement at position 8.
' </MyElement><MyElement Index="9">
' MyElement at position 9.
' </MyElement></FileInfo.MoveTo>
' 
' Preparing to move the file to
' C:\Documents and Settings\MyComputer\My Documents\FileInfoTestDirectory\DestFile.xml.
' File moved to
' C:\Documents and Settings\MyComputer\My Documents\FileInfoTestDirectory\DestFile.xml
' The FileInfo instance shows these property values.
' FullName: C:\Documents and Settings\MyComputer\My Documents\FileInfoTestDirectory\DestFile.xml
' CreationTime: 4/18/2006 1:38:19 PM
' LastWriteTime: 4/18/2006 1:38:19 PM
' 
' File contents:
' 
' <?xml version="1.0" standalone="yes"?>
' <FileInfo.MoveTo><MyElement Index="0">
' MyElement at position 0.
' </MyElement><MyElement Index="1">
' MyElement at position 1.
' </MyElement><MyElement Index="2">
' MyElement at position 2.
' </MyElement><MyElement Index="3">
' MyElement at position 3.
' </MyElement><MyElement Index="4">
' MyElement at position 4.
' </MyElement><MyElement Index="5">
' MyElement at position 5.
' </MyElement><MyElement Index="6">
' MyElement at position 6.
' </MyElement><MyElement Index="7">
' MyElement at position 7.
' </MyElement><MyElement Index="8">
' MyElement at position 8.
' </MyElement><MyElement Index="9">
' MyElement at position 9.
' </MyElement></FileInfo.MoveTo>
' 
' Preparing to delete directories.
' Successfully deleted directories and files.
' Press the ENTER key to close this application.
' </SNIPPET1>
