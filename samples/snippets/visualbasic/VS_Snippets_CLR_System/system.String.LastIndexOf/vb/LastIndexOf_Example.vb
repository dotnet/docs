Option Strict On

' <Snippet1>
Imports System.IO

Public Module Test
   Public Sub Main()
      Dim filename As String 
      
      filename = ExtractFilename("C:\temp\")
      Console.WriteLine("{0}", IIf(String.IsNullOrEmpty(fileName), "<none>", filename))
      
      filename = ExtractFilename("C:\temp\delegate.txt") 
      Console.WriteLine("{0}", IIf(String.IsNullOrEmpty(fileName), "<none>", filename))

      filename = ExtractFilename("delegate.txt")      
      Console.WriteLine("{0}", IIf(String.IsNullOrEmpty(fileName), "<none>", filename))
      
      filename = ExtractFilename("C:\temp\notafile.txt")
      Console.WriteLine("{0}", IIf(String.IsNullOrEmpty(fileName), "<none>", filename))
   End Sub
   
   Public Function ExtractFilename(filepath As String) As String
      ' If path ends with a "\", it's a path only so return String.Empty.
      If filepath.Trim().EndsWith("\") Then Return String.Empty
      
      ' Determine where last backslash is.
      Dim position As Integer = filepath.LastIndexOf("\"c)
      ' If there is no backslash, assume that this is a filename.
      If position = -1 Then
         ' Determine whether file exists in the current directory.
         If File.Exists(Environment.CurrentDirectory + Path.DirectorySeparatorChar + filepath) Then
            Return filepath
         Else
            Return String.Empty
         End If
      Else
         ' Determine whether file exists using filepath.
         If File.Exists(filepath) Then
            ' Return filename without file path.
            Return filepath.Substring(position + 1)
         Else
            Return String.Empty
         End If                     
      End If
   End Function
End Module 
' The example displays the following output:
'        <none>
'        delegate.txt
'        <none>
'        <none>
' </Snippet1>
