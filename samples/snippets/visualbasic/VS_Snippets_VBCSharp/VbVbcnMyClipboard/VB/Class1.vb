Option Explicit On
Option Strict On

Imports System.Windows.Forms
Imports System.Drawing

Public Class Class1


    '******************************************************************************
    Shared Sub TestClip2()
        Dim dataChunk As New System.Windows.Forms.DataObject

        '<Snippet9>
        My.Computer.Clipboard.SetDataObject(dataChunk)
        '</Snippet9>

    End Sub


    '******************************************************************************
    Shared Function TestClip() As String
        Dim dataChunk As New Object
        Dim coolPicture As New System.Drawing.Bitmap(5, 5)


        '<Snippet8>
        My.Computer.Clipboard.SetImage(coolPicture)
        '</Snippet8>

        '<Snippet7>
        My.Computer.Clipboard.SetData("specialFormat", dataChunk)
        '</Snippet7>

        '<Snippet6>
        Dim textOnClipboard As String = My.Computer.Clipboard.GetText()
        '</Snippet6>

        Return textOnClipboard
    End Function


    '******************************************************************************
    ' How to: Write to the Clipboard in Visual Basic
    Public Sub Method1()
        ' <snippet1>
        My.Computer.Clipboard.SetText("This is a test string.")
        ' </snippet1>
    End Sub

    Public Sub Method2()
        ' <snippet2>
        My.Computer.Clipboard.SetText("This is a test string.", 
        System.Windows.Forms.TextDataFormat.Rtf)
        ' </snippet2>
    End Sub


    '******************************************************************************
    ' How to: Clear the Clipboard in Visual Basic

    Public Sub Method3()
        ' <snippet3>
        My.Computer.Clipboard.Clear()
        ' </snippet3>
    End Sub


    '******************************************************************************
    ' How to: Read from the Clipboard in Visual Basic
    Public Sub Method4()
        ' <snippet4>
        MsgBox(My.Computer.Clipboard.GetText())
        ' </snippet4>
    End Sub

    Public Sub Method5()
        Dim Button1 As New System.Windows.Forms.Button
        ' <snippet5>
        Button1.Image = My.Computer.Clipboard.GetImage()
        ' </snippet5>
    End Sub

End Class
