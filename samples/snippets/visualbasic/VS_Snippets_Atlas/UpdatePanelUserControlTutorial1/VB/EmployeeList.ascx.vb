Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Partial class EmployeeList
    Inherits System.Web.UI.UserControl

    Public ReadOnly Property EmployeeID() As Integer
        Get
            If EmployeesGridView.SelectedIndex <> -1 Then
                Return CInt(EmployeesGridView.DataKeys(EmployeesGridView.SelectedIndex).Value)
            Else
                Return -1
            End If
        End Get
    End Property

    Public Property UpdateMode() As UpdatePanelUpdateMode
        Get
            Return Me.EmployeeListUpdatePanel.UpdateMode
        End Get
        Set(ByVal value As UpdatePanelUpdateMode)
            Me.EmployeeListUpdatePanel.UpdateMode = value
        End Set
    End Property

    Public Sub Update()
        Me.EmployeeListUpdatePanel.Update()
    End Sub

    Public ReadOnly Property SelectedIndex() As Integer
        Get
            Return Me.EmployeesGridView.SelectedIndex
        End Get
    End Property

    Protected Overrides Sub OnPreRender(ByVal e As EventArgs)
        MyBase.OnPreRender(e)

        Me.LastUpdatedLabel.Text = DateTime.Now.ToString()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As EventArgs)
        MyBase.OnInit(e)
        AddHandler Me.EmployeesGridView.SelectedIndexChanged, AddressOf Me.EmployeesGridView_SelectedIndexChanged
        AddHandler Me.EmployeesGridView.PageIndexChanged, AddressOf Me.EmployeesGridView_PageIndexChanged
        AddHandler Me.EmployeesGridView.DataBound, AddressOf Me.EmployeesGridView_DataBound
        AddHandler Me.EmployeesGridView.Sorted, AddressOf Me.EmployeesGridView_Sorted
    End Sub

    Public Event SelectedIndexChanged As EventHandler

    Protected Sub OnSelectedIndexChanged(ByVal e As EventArgs)
        RaiseEvent SelectedIndexChanged(Me, e)
    End Sub

    Private Sub EmployeesGridView_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        RaiseEvent SelectedIndexChanged(Me, e)

        ViewState("SelectedEmployeeID") = Me.EmployeeID
    End Sub

    Private Sub EmployeesGridView_PageIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        If EmployeesGridView.SelectedIndex <> -1 Then
            Me.EmployeesGridView.SelectedIndex = -1
            RaiseEvent SelectedIndexChanged(Me, e)
        End If
    End Sub

    Private Sub EmployeesGridView_Sorted(ByVal sender As Object, ByVal e As EventArgs)
        If EmployeesGridView.SelectedIndex <> -1 Then
            Me.EmployeesGridView.SelectedIndex = -1
            RaiseEvent SelectedIndexChanged(Me, e)
        End If
    End Sub

    Protected Sub EmployeesGridView_DataBound(ByVal sender As Object, ByVal e As EventArgs)
        Dim selectedEmployeeID As Integer
        If ViewState("SelectedEmployeeID") Is Nothing Then
            selectedEmployeeID = -1
        Else
            selectedEmployeeID = CInt(ViewState("SelectedEmployeeID"))
        End If

        For i As Integer = 0 To EmployeesGridView.Rows.Count - 1
            If CInt(EmployeesGridView.DataKeys(i).Value) = selectedEmployeeID Then
                EmployeesGridView.SelectedIndex = i
                RaiseEvent SelectedIndexChanged(Me, e)
            End If
        Next
    End Sub
End Class
