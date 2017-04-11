'<snippet7>
Imports System
Imports System.Runtime.InteropServices

'<snippet8>
' Declare a class member for each structure element.
<StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Auto)> _
Public Class OpenFileName
    Public structSize As Integer = 0
    Public hwnd As IntPtr = IntPtr.Zero
    Public hinst As IntPtr = IntPtr.Zero
    Public filter As String = Nothing
    Public custFilter As String = Nothing
    Public custFilterMax As Integer = 0
    Public filterIndex As Integer = 0
    Public file As String = Nothing
    Public maxFile As Integer = 0
    Public fileTitle As String = Nothing
    Public maxFileTitle As Integer = 0
    Public initialDir As String = Nothing
    Public title As String = Nothing
    Public flags As Integer = 0
    Public fileOffset As Short = 0
    Public fileExtMax As Short = 0
    Public defExt as String = Nothing
    Public custData As Integer = 0
    Public pHook As IntPtr = IntPtr.Zero
    Public template As String = Nothing
End Class

Public Class LibWrap
   ' Declare managed prototype for the unmanaged function.
   Declare Auto Function GetOpenFileName Lib "Comdlg32.dll" ( _
      <[In], Out> ByVal ofn As OpenFileName ) As Boolean
End Class
'</snippet8>

'<snippet9>
Public Class App
    Public Shared Sub Main()
        Dim ofn As New OpenFileName()

        ofn.structSize = Marshal.SizeOf(ofn)
        ofn.filter = "Log files" & ChrW(0) & "*.log" & ChrW(0) & _
            "Batch files" & ChrW(0) & "*.bat" & ChrW(0)
        ofn.file = New String(New Char(256){})
        ofn.maxFile = ofn.file.Length
        ofn.fileTitle = new string(New Char(64){})
        ofn.maxFileTitle = ofn.fileTitle.Length
        ofn.initialDir = "C:\"
        ofn.title = "Open file called using platform invoke..."
        ofn.defExt = "txt"

        If LibWrap.GetOpenFileName(ofn) Then
            Console.WriteLine("Selected file with full path: {0}", ofn.file)
        End If
    End Sub
End Class
'</snippet9>
'</snippet7>
