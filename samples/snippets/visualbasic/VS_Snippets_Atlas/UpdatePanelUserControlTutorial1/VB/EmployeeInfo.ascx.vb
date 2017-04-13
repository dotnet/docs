Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Partial Class EmployeeInfo
    Inherits System.Web.UI.UserControl

    Private _EmployeeID As Integer

    Public Property EmployeeID() As Integer
        Get
            Return _EmployeeID
        End Get
        Set(ByVal value As Integer)
            _EmployeeID = value
            Me.EmployeeDataSource.SelectParameters("SelectedEmployeeID").DefaultValue = _
              _EmployeeID.ToString()
        End Set
    End Property

    '<Snippet1>
    Public Property UpdateMode() As UpdatePanelUpdateMode
        Get
            Return Me.EmployeeInfoUpdatePanel.UpdateMode
        End Get
        Set(ByVal value As UpdatePanelUpdateMode)
            Me.EmployeeInfoUpdatePanel.UpdateMode = value
        End Set
    End Property

    Public Sub Update()
        Me.EmployeeInfoUpdatePanel.Update()
    End Sub
    '</Snippet1>

    Protected Overrides Sub OnPreRender(ByVal e As EventArgs)
        MyBase.OnPreRender(e)

        Me.LastUpdatedLabel.Text = DateTime.Now.ToString()
    End Sub
End Class
