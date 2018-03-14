Public Class Color

    Private Sub ContactsBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContactsBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.ContactsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.NorthwndDataSet)

    End Sub

    Private Sub Color_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'NorthwndDataSet.Contacts' table. You can move, or remove it, as needed.
        Me.ContactsTableAdapter.Fill(Me.NorthwndDataSet.Contacts)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If DataRepeater1.LayoutStyle = PowerPacks.DataRepeaterLayoutStyles.Horizontal Then
            DataRepeater1.LayoutStyle = PowerPacks.DataRepeaterLayoutStyles.Vertical
        Else
            DataRepeater1.LayoutStyle = PowerPacks.DataRepeaterLayoutStyles.Horizontal
        End If
    End Sub
    ' <Snippet1>
    Private Sub DataRepeater1_LayoutStyleChanged(
        ) Handles DataRepeater1.LayoutStyleChanged

        ' Set the SelectionColor based on orientation.
        If DataRepeater1.LayoutStyle = 
           PowerPacks.DataRepeaterLayoutStyles.Vertical Then

            DataRepeater1.SelectionColor = Drawing.Color.Blue
        Else
            DataRepeater1.SelectionColor = Drawing.Color.Red
        End If
    End Sub
    ' </Snippet1>
End Class
