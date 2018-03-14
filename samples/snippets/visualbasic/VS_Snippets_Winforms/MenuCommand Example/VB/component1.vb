'<snippet10>
Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design

Namespace VbMenuCommand
    <Designer(GetType(CDesigner))> _
    Public Class Component1
        Inherits System.ComponentModel.Component
        Private components As System.ComponentModel.Container = Nothing

        Public Sub New(ByVal container As System.ComponentModel.IContainer)
            container.Add(Me)
            InitializeComponent()
        End Sub

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub InitializeComponent()
        End Sub
    End Class

    '<Snippet1>
    <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
    Public Class CDesigner
        Inherits System.ComponentModel.Design.ComponentDesigner

        Public Overrides Sub Initialize(ByVal comp As IComponent)
            MyBase.Initialize(comp)

            Dim mcs As IMenuCommandService = CType(comp.Site.GetService(GetType(IMenuCommandService)), IMenuCommandService)
            Dim mc As New MenuCommand(New EventHandler(AddressOf OnF1Help), StandardCommands.F1Help)
            mc.Enabled = True
            mc.Visible = True
            mc.Supported = True
            mcs.AddCommand(mc)
            System.Windows.Forms.MessageBox.Show("Initialize() has been invoked.")
        End Sub

        Private Sub OnF1Help(ByVal sender As Object, ByVal e As EventArgs)
            System.Windows.Forms.MessageBox.Show("F1Help has been invoked.")
        End Sub
    End Class
    '</Snippet1>
End Namespace
'</snippet10>