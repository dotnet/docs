Imports Microsoft.VisualBasic.PowerPacks

Public Class ShapeContainerForm
    ' <Snippet1>
    Private Sub Form1_Load() Handles MyBase.Load
        Dim NewOval As New OvalShape
        Dim i As Integer
        Dim found As Boolean
        ' Loop through the Controls collection.
        For i = 0 To Me.Controls.Count - 1
            ' If a ShapeContainer is found, make it the parent.
            If TypeOf Controls.Item(i) Is ShapeContainer Then
                NewOval.Parent = Controls.Item(i)
                found = True
                Exit For
            End If
        Next
        ' If no ShapeContainer is found, create one and set the parents.
        If found = False Then
            Dim sc As New ShapeContainer
            sc.Parent = Me
            NewOval.Parent = sc
        End If
        NewOval.Size = New Size(200, 300)
    End Sub
    ' </Snippet1>

End Class
