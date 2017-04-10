Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
' <Snippet1>
 Private Sub Menu_Copy(sender As System.Object, e As System.EventArgs)
     ' Ensure that text is selected in the text box.   
     If textBox1.SelectionLength > 0 Then
         ' Copy the selected text to the Clipboard.
         textBox1.Copy()
     End If
 End Sub
     
 Private Sub Menu_Cut(sender As System.Object, e As System.EventArgs)
     ' Ensure that text is currently selected in the text box.   
     If textBox1.SelectedText <> "" Then
         ' Cut the selected text in the control and paste it into the Clipboard.
         textBox1.Cut()
     End If
 End Sub
     
 Private Sub Menu_Paste(sender As System.Object, e As System.EventArgs)
     ' Determine if there is any text in the Clipboard to paste into the text box.
     If Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) = True Then
         ' Determine if any text is selected in the text box.
         If textBox1.SelectionLength > 0 Then
             ' Ask user if they want to paste over currently selected text.
             If MessageBox.Show("Do you want to paste over current selection?", _
                "Cut Example", MessageBoxButtons.YesNo) = DialogResult.No Then
                 ' Move selection to the point after the current selection and paste.
                 textBox1.SelectionStart = textBox1.SelectionStart + _
                    textBox1.SelectionLength
             End If
         End If 
         ' Paste current text in Clipboard into text box.
         textBox1.Paste()
     End If
 End Sub
    
 Private Sub Menu_Undo(sender As System.Object, e As System.EventArgs)
     ' Determine if last operation can be undone in text box.   
     If textBox1.CanUndo = True Then
         ' Undo the last operation.
         textBox1.Undo()
         ' Clear the undo buffer to prevent last action from being redone.
         textBox1.ClearUndo()
     End If
 End Sub

' </Snippet1>
End Class

