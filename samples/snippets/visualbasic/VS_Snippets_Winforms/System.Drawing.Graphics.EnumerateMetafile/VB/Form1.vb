'<snippet1>
Imports System
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Windows.Forms
' for Marshal.Copy
Imports System.Runtime.InteropServices


Public Class Form1
    Inherits Form
    Private metafile1 As Metafile
    Private metafileDelegate As Graphics.EnumerateMetafileProc
    Private destPoint As Point
    
    Public Sub New() 
        metafile1 = New Metafile("C:\test.wmf")
        metafileDelegate = New Graphics.EnumerateMetafileProc(AddressOf MetafileCallback)
        destPoint = New Point(20, 10)
    
    End Sub
    
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs) 
        e.Graphics.EnumerateMetafile(metafile1, destPoint, metafileDelegate)
    
    End Sub
    
    Private Function MetafileCallback(ByVal recordType As _
        EmfPlusRecordType, ByVal flags As Integer, ByVal dataSize As Integer, _
        ByVal data As IntPtr, ByVal callbackData As PlayRecordCallback) As Boolean

        Dim dataArray As Byte() = Nothing
        If data <> IntPtr.Zero Then

            ' Copy the unmanaged record to a managed byte buffer 
            ' that can be used by PlayRecord.
            dataArray = New Byte(dataSize) {}
            Marshal.Copy(data, dataArray, 0, dataSize)
        End If

        metafile1.PlayRecord(recordType, flags, dataSize, dataArray)
        Return True

    End Function
    
    Shared Sub Main() 
        Application.Run(New Form1())
    End Sub

End Class
'</snippet1>