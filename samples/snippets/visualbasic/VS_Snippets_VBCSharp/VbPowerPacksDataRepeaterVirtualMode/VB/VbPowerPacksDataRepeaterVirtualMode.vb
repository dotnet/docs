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

    Private Sub DataRepeater1_CurrentItemIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataRepeater1.CurrentItemIndexChanged

    End Sub
    '<Snippet1>
    Private Sub DataRepeater1_ItemValueNeeded(
        ByVal sender As Object, 
        ByVal e As Microsoft.VisualBasic.PowerPacks.DataRepeaterItemValueEventArgs
      ) Handles DataRepeater1.ItemValueNeeded
        If e.ItemIndex < Employees.Count Then
            Select Case e.Control.Name
                Case "txtFirstName"
                    e.Value = Employees.Item(e.ItemIndex + 1).firstName
                Case "txtLastName"
                    e.Value = Employees.Item(e.ItemIndex + 1).lastName
            End Select
        End If
    End Sub
    '</Snippet1>
    '<Snippet2>
    Private Sub DataRepeater1_ItemValuePushed(
        ByVal sender As Object, 
        ByVal e As Microsoft.VisualBasic.PowerPacks.DataRepeaterItemValueEventArgs
      ) Handles DataRepeater1.ItemValuePushed

        Dim emp As Employee = Employees.Item(e.ItemIndex)
        Select Case e.Control.Name
            Case "txtFirstName"
                emp.firstName = e.Control.Text
            Case "txtLastName"
                emp.lastName = e.Control.Text
            Case Else
                MsgBox("Error during ItemValuePushed unexpected control: " & 
                    e.Control.Name)
        End Select
    End Sub
    '</Snippet2>
    '<Snippet3>
    Private Sub Child_KeyDown(
        ByVal sender As Object, 
        ByVal e As System.Windows.Forms.KeyEventArgs
      ) Handles txtFirstName.KeyDown, txtLastName.KeyDown

        If e.KeyCode = Keys.Escape Then
            Datarepeater1.CancelEdit()
        End If
    End Sub
    '</Snippet3>
    Public Structure Employee
        Public firstName As String
        Public lastName As String

    End Structure
    Dim Employees As List(Of Employee)
    Dim blnNewItemNeedEventFired As Boolean = False
    '<Snippet4>
    Private Sub DataRepeater1_NewItemNeeded(
      ) Handles DataRepeater1.NewItemNeeded

        Dim newEmployee As New Employee
        Employees.Add(newEmployee)
        blnNewItemNeedEventFired = True
    End Sub
    '</Snippet4>
    '<Snippet5>
    Private Sub DataRepeater1_ItemsRemoved(
        ByVal sender As Object, 
        ByVal e As Microsoft.VisualBasic.PowerPacks.DataRepeaterAddRemoveItemsEventArgs
      ) Handles DataRepeater1.ItemsRemoved

        Employees.RemoveAt(e.ItemIndex)
    End Sub
    '</Snippet5>
    '<Snippet6>
    Private Sub Text_Validating(
        ByVal sender As Object, 
        ByVal e As System.ComponentModel.CancelEventArgs
      ) Handles txtFirstName.Validating, txtLastName.Validating

        If txtFirstName.Text = "" Then
            MsgBox("Please enter a name.")
            e.Cancel = True
        End If
    End Sub
    '</Snippet6>

End Class
