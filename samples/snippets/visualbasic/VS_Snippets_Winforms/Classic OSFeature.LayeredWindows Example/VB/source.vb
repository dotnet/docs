Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
' <Snippet1>
 Private Sub LayeredWindows()
     ' Gets the version of the layered windows feature.
     Dim myVersion As Version = _
        OSFeature.Feature.GetVersionPresent(OSFeature.LayeredWindows)
        
     ' Prints whether the feature is available.
     If OSFeature.Feature.IsPresent(OSFeature.LayeredWindows) Then
         textBox1.Text = "Layered windows feature is installed."
     Else
         textBox1.Text = "Layered windows feature is not installed."
     End If
 End Sub

' </Snippet1>
End Class
