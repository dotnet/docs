Option Explicit
Option Strict

Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    Protected textBox2 As TextBox
    
    ' <Snippet1>
    Private Sub button1_Click(sender As Object, e As System.EventArgs)
        ' Takes the selected text from a text box and puts it on the clipboard.
        If textBox1.SelectedText <> "" Then
            Clipboard.SetDataObject(textBox1.SelectedText)
        Else
            textBox2.Text = "No text selected in textBox1"
        End If
    End Sub 'button1_Click
     
    Private Sub button2_Click(sender As Object, e As System.EventArgs)
        ' Declares an IDataObject to hold the data returned from the clipboard.
        ' Retrieves the data from the clipboard.
        Dim iData As IDataObject = Clipboard.GetDataObject()
        
        ' Determines whether the data is in a format you can use.
        If iData.GetDataPresent(DataFormats.Text) Then
            ' Yes it is, so display it in a text box.
            textBox2.Text = CType(iData.GetData(DataFormats.Text), String)
        Else
            ' No it is not.
            textBox2.Text = "Could not retrieve data off the clipboard."
        End If
    End Sub 'button2_Click
    ' </Snippet1>
End Class 'Form1 
