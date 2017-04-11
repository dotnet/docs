' Visual Basic .NET Document
Option Strict On

' <Snippet1>
'
' The source code should be saved in a file named Example1.cs. It 
' can be compiled at the command line as follows:
'
'    vbc Assembly1.vb /t:library /keyfile:<snkfilename> 
'
' The public key of the Friend1 file should be changed to the full
' public key stored in your strong-named key file.
'
Imports System.IO
Imports System.Runtime.CompilerServices

<Assembly:InternalsVisibleTo("Friend1, PublicKey=002400000480000094" + _
                             "0000000602000000240000525341310004000" + _
                             "001000100bf8c25fcd44838d87e245ab35bf7" + _
                             "3ba2615707feea295709559b3de903fb95a93" + _
                             "3d2729967c3184a97d7b84c7547cd87e435b5" + _
                             "6bdf8621bcb62b59c00c88bd83aa62c4fcdd4" + _
                             "712da72eec2533dc00f8529c3a0bbb4103282" + _
                             "f0d894d5f34e9f0103c473dce9f4b457a5dee" + _
                             "fd8f920d8681ed6dfcb0a81e96bd9b176525a" + _
                             "26e0b3")>

Public Class FileUtilities
   Friend Shared Function AppendDirectorySeparator(dir As String) As String
      If Not dir.Trim().EndsWith(Path.DirectorySeparatorChar) Then
         Return dir.Trim() + Path.DirectorySeparatorChar
      Else
         Return dir
      End If   
   End Function
End Class
' </Snippet1>
