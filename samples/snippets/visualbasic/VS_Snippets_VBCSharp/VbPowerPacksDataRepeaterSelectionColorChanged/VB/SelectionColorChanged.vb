Public Class SelectionColorChanged

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        DataRepeater1.SelectionColor = Color.Purple
    End Sub

    Private Sub CategoriesBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CategoriesBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.CategoriesBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.NorthwndDataSet)

    End Sub

    Private Sub SelectionColorChanged_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'NorthwndDataSet.Categories' table. You can move, or remove it, as needed.
        Me.CategoriesTableAdapter.Fill(Me.NorthwndDataSet.Categories)

    End Sub
    ' <Snippet1>
    Private Sub DataRepeater1_SelectionColorChanged(
      ) Handles DataRepeater1.SelectionColorChanged
        Dim ColorString As String = DataRepeater1.SelectionColor.ToString
        Dim BracketPosition As Integer
        ' Find the left bracket.
        BracketPosition = InStr(ColorString, "[")
        ' Find the color name.
        ColorString = Microsoft.VisualBasic.Right(ColorString, 
         Len(ColorString) - BracketPosition)
        ColorString = Microsoft.VisualBasic.Left(ColorString, 
         Len(ColorString) - 1)
        ' Display a message.
        MsgBox("Selections will be indicated by a " & ColorString &
           " header.")
    End Sub
    ' </Snippet1>
End Class
