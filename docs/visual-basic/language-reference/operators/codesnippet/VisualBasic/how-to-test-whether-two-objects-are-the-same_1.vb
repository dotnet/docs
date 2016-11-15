    Public Sub processControl(ByVal f As System.Windows.Forms.Form, 
        ByVal c As System.Windows.Forms.Control)
        Dim active As System.Windows.Forms.Control = f.ActiveControl
        If (active IsNot Nothing) And (c Is active) Then
            ' Insert code to process control c
        End If
        Return
    End Sub