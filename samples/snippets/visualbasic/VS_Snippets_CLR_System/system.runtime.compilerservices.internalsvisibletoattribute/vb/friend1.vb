' Visual Basic .NET Document
Option Strict On

Imports System.IO

' <Snippet2>
'
' The source code should be saved in a file named Friend1.vb. It 
' can be compiled at the command line as follows:
'
'    vbc Friend1.vb /r:Assembly1.dll /keyfile:<snkfilename> 
'
' The public key of the Friend1 assembly should correspond to the public key
' specified in the class constructor of the InternalsVisibleTo attribute in the
' Assembly1 assembly.
'
Module Example
   Public Sub Main()
      Dim dir As String = "C:\Program Files"
      dir = FileUtilities.AppendDirectorySeparator(dir)
      Console.WriteLine(dir)
   End Sub
End Module
' The example displays the following output:
'       C:\Program Files\
' </Snippet2>


Public Class FileUtilities
   Friend Shared Function AppendDirectorySeparator(dir As String) As String
      If Not dir.Trim().EndsWith(Path.DirectorySeparatorChar) Then
         Return dir.Trim() + Path.DirectorySeparatorChar
      Else
         Return dir
      End If   
   End Function
End Class
