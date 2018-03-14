    Private Sub DataRepeater1_LayoutStyleChanged(ByVal sender As Object,
     ByVal e As System.EventArgs) Handles DataRepeater1.LayoutStyleChanged
        ' Call a method to re-initialize the template.
        DataRepeater1.BeginResetItemTemplate()
        If DataRepeater1.LayoutStyle =
         PowerPacks.DataRepeaterLayoutStyles.Vertical Then
            ' Change the height of the template and rearrange the controls.
            DataRepeater1.ItemTemplate.Height = 150
            DataRepeater1.ItemTemplate.Controls(TextBox1.Name).Location =
             New Point(20, 40)
            DataRepeater1.ItemTemplate.Controls(TextBox2.Name).Location =
             New Point(150, 40)
        Else
            ' Change the width of the template and rearrange the controls.
            DataRepeater1.ItemTemplate.Width = 150
            DataRepeater1.ItemTemplate.Controls(TextBox1.Name).Location =
             New Point(40, 20)
            DataRepeater1.ItemTemplate.Controls(TextBox2.Name).Location =
             New Point(40, 150)
        End If
        ' Apply the changes to the template.
        DataRepeater1.EndResetItemTemplate()
    End Sub