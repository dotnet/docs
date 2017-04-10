Public Class Form1

    Private Sub EmployeesBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeesBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.EmployeesBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.NorthwindDataSet)

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'NorthwindDataSet.Employees' table. You can move, or remove it, as needed.
        Me.EmployeesTableAdapter.Fill(Me.NorthwindDataSet.Employees)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' <Snippet1>
        ' Switch the orientation.
        If DataRepeater1.LayoutStyle =
         PowerPacks.DataRepeaterLayoutStyles.Vertical Then
            DataRepeater1.LayoutStyle =
             PowerPacks.DataRepeaterLayoutStyles.Horizontal
        Else
            DataRepeater1.LayoutStyle =
             PowerPacks.DataRepeaterLayoutStyles.Vertical
        End If
        ' </Snippet1>
    End Sub

    ' <Snippet2>
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
    ' </Snippet2>
End Class
