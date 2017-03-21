    Public Sub GetHashCode_Example(ByVal e As PaintEventArgs)

        ' Create a Font object.
        Dim myFont As New Font("Arial", 16)

        ' Get the hash code for myFont.
        Dim hashCode As Integer = myFont.GetHashCode()

        ' Display the hash code in a message box.
        MessageBox.Show(hashCode.ToString())
    End Sub