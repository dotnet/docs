Imports Microsoft.VisualBasic.PowerPacks
Public Class ShapeName

    Private Sub ShapeName_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' <Snippet1>
        Dim os As New OvalShape
        Dim sc As New ShapeContainer
        sc.Parent = Me
        os.Parent = sc
        ' Assign a value to the Name property.
        os.Name = "NewOval1"
        ' </Snippet1>
        MsgBox(os.Name)
    End Sub
End Class
