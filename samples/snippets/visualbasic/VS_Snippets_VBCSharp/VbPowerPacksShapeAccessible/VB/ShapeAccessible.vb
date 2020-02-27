Public Class ShapeAccessible

    Private Sub ShapeAccessible_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' <Snippet1>
        Dim OvalShape1 As New OvalShape
        Dim canvas As New ShapeContainer
        ' Set the form as the parent of the ShapeContainer.
        canvas.Parent = Me
        ' Set the ShapeContainer as the parent of the OvalShape.
        OvalShape1.Parent = canvas
        ' Assign an image resource to the BackgroundImage property.
        OvalShape1.BackgroundImage = My.Resources.cactus
        OvalShape1.Size = New Size(My.Resources.cactus.Size)
        ' Assign the AccessibleName and AccessibleDescription text.
        OvalShape1.AccessibleName = "Image"
        OvalShape1.AccessibleDescription = "A picture of a cactus"
        ' </Snippet1>
        MsgBox(OvalShape1.AccessibleName & " " & OvalShape1.AccessibleDescription)
    End Sub
    ' <Snippet2>
    Private Sub OvalShape1_QueryAccessibilityHelp(
        ByVal sender As Object, 
        ByVal e As System.Windows.Forms.QueryAccessibilityHelpEventArgs
      ) Handles OvalShape1.QueryAccessibilityHelp

        e.HelpString = "Displays an oval representing a network node."
    End Sub
    ' </Snippet2>
End Class