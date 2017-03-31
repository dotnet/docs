Imports System
Imports System.Data
Imports System.IO
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected dataGrid1 As DataGrid
    Protected dataSet1 As DataSet
    
' <Snippet1>
    Private Sub button1_Click(sender As Object, e As System.EventArgs)
        Dim myStream As Stream
        Dim saveFileDialog1 As New SaveFileDialog()
        
        saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        saveFileDialog1.FilterIndex = 2
        saveFileDialog1.RestoreDirectory = True
        
        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            myStream = saveFileDialog1.OpenFile()
            If (myStream IsNot Nothing) Then
                ' Code to write the stream goes here.
                myStream.Close()
            End If
        End If
    End Sub

' </Snippet1>
End Class

