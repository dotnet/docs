' <snippet510>
' <snippet520>
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Diagnostics
Imports System.Drawing.Design
Imports System.Windows.Forms
Imports System.Windows.Forms.Design
' </snippet520>

' <snippet530>
Namespace MarqueeControlLibrary.Design

    <ToolboxItemFilter("MarqueeControlLibrary.MarqueeBorder", _
    ToolboxItemFilterType.Require), _
    ToolboxItemFilter("MarqueeControlLibrary.MarqueeText", _
    ToolboxItemFilterType.Require)> _
    <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
    Public Class MarqueeControlRootDesigner
        Inherits DocumentDesigner
        ' </snippet530>

        ' <snippet540>
        Public Sub New()
            Trace.WriteLine("MarqueeControlRootDesigner ctor")
        End Sub
        ' </snippet540>

        ' <snippet550>
        Public Overrides Sub Initialize(ByVal component As IComponent)

            ' <snippet580>
            MyBase.Initialize(component)

            Dim cs As IComponentChangeService = _
            CType(GetService(GetType(IComponentChangeService)), _
            IComponentChangeService)

            If (cs IsNot Nothing) Then
                AddHandler cs.ComponentChanged, AddressOf OnComponentChanged
            End If
            ' </snippet580>

            ' <snippet590>
            Me.Verbs.Add(New DesignerVerb("Run Test", _
            New EventHandler(AddressOf OnVerbRunTest)))

            Me.Verbs.Add(New DesignerVerb("Stop Test", _
            New EventHandler(AddressOf OnVerbStopTest)))
            ' </snippet590>
        End Sub
        ' </snippet550>

        ' <snippet560>
        Private Sub OnComponentChanged( _
        ByVal sender As Object, _
        ByVal e As ComponentChangedEventArgs)
            If TypeOf e.Component Is IMarqueeWidget Then
                Me.Control.Refresh()
            End If
        End Sub
        ' </snippet560>

        ' <snippet570>
        Private Sub OnVerbRunTest( _
        ByVal sender As Object, _
        ByVal e As EventArgs)

            Dim c As MarqueeControl = CType(Me.Control, MarqueeControl)
            c.Start()

        End Sub

        Private Sub OnVerbStopTest( _
        ByVal sender As Object, _
        ByVal e As EventArgs)

            Dim c As MarqueeControl = CType(Me.Control, MarqueeControl)
            c.Stop()

        End Sub
        ' </snippet570>

    End Class
End Namespace
' </snippet510>