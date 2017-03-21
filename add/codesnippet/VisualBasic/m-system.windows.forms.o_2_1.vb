 Private Sub LayeredWindows()
     ' Gets the version of the layered windows feature.
     Dim myVersion As Version = _
        OSFeature.Feature.GetVersionPresent(OSFeature.LayeredWindows)
        
     ' Prints whether the feature is available.
     If (myVersion IsNot Nothing) Then
         textBox1.Text = "Layered windows feature is installed." & _
            ControlChars.CrLf
     Else
         textBox1.Text = "Layered windows feature is not installed." & _
            ControlChars.CrLf
     End If
 End Sub
