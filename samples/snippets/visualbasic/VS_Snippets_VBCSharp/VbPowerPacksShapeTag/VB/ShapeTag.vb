Public Class ShapeTag
    ' <Snippet1>
    Private Sub Form1_Load() Handles MyBase.Load
        ' Declare an instance of a NodeInfo class.
        Dim MyNode As New NodeInfo
        ' Assign the instance to the Tag property.
        RectangleShape1.Tag = MyNode
    End Sub

    Private Sub RectangleShape1_Click() Handles RectangleShape1.Click
        ' Declare an instance of a networkForm form.
        Dim networkForm As New Form()
        ' Assign the Tag property of the RectangleShape to the new form.
        ' This passes the MyNode instance of the NodeInfo class to the
        ' form.
        networkForm.Tag = RectangleShape1.Tag
        ' Show the new form.
        networkForm.Show()
    End Sub
    ' </Snippet1>
End Class
