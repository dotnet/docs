' <Snippet1>

' To compile and run this sample from the command line, proceed as follows:
' vbc controliskeylocked.vb /r:System.Windows.Forms.dll /r:System.dll 
' /r:System.Data.dll /r:System.Drawing.dll

Imports System
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Public Class CapsLockIndicator
   
    Public Shared Sub Main()
        if Control.IsKeyLocked(Keys.CapsLock) Then
            MessageBox.Show("The Caps Lock key is ON.")
        Else
            MessageBox.Show("The Caps Lock key is OFF.")
        End If
    End Sub 'Main
End Class 'CapsLockIndicator
' </Snippet1>