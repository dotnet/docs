'<Snippet1>
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Windows.Forms

' A DesignerAttribute associates the example IDesigner with an example control.
<DesignerAttribute(GetType(ExampleIDesigner))> _
Public Class TestControl
    Inherits System.Windows.Forms.UserControl

    Public Sub New()
    End Sub
End Class

<System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
Public Class ExampleIDesigner
    Implements System.ComponentModel.Design.IDesigner

    ' Local reference to the designer's component.
    Private _component As IComponent

    ' Public accessor to the designer's component.
    Public ReadOnly Property Component() As System.ComponentModel.IComponent Implements IDesigner.Component
        Get
            Return _component
        End Get
    End Property

    Public Sub New()
    End Sub

    Public Sub Initialize(ByVal component As System.ComponentModel.IComponent) Implements IDesigner.Initialize
        ' This method is called after a designer for a component is created,
        ' and stores a reference to the designer's component.
        Me._component = component
    End Sub

    ' This method peforms the 'default' action for the designer. The default action 
    ' for a basic IDesigner implementation is invoked when the designer's component 
    ' is double-clicked. By default, a component associated with a basic IDesigner 
    ' implementation is displayed in the design-mode component tray.
    Public Sub DoDefaultAction() Implements IDesigner.DoDefaultAction
        ' Shows a message box indicating that the default action for the designer was invoked.
        MessageBox.Show("The DoDefaultAction method of an IDesigner implementation was invoked.", "Information")
    End Sub

    ' Returns a collection of designer verb menu items to show in the 
    ' shortcut menu for the designer's component.
    Public ReadOnly Property Verbs() As System.ComponentModel.Design.DesignerVerbCollection Implements IDesigner.Verbs
        Get
            Dim verbs_ As New DesignerVerbCollection()
            Dim dv1 As New DesignerVerb("Display Component Name", New EventHandler(AddressOf Me.ShowComponentName))
            verbs_.Add(dv1)
            Return verbs_
        End Get
    End Property

    ' Event handler for displaying a message box showing the designer's component's name.
    Private Sub ShowComponentName(ByVal sender As Object, ByVal e As EventArgs)
        If (Me.Component IsNot Nothing) Then
            MessageBox.Show(Me.Component.Site.Name, "Designer Component's Name")
        End If
    End Sub

    ' Provides an opportunity to release resources before object destruction.
    Public Sub Dispose() Implements IDisposable.Dispose
    End Sub

End Class
'</Snippet1>