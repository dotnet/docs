' <Snippet1>
' IndexButton.vb
Option Strict On
Imports System
Imports System.ComponentModel
Imports System.Security.Permissions
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace Samples.AspNet.VB.Controls
    < _
    AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal), _
    AspNetHostingPermission(SecurityAction.InheritanceDemand, _
        Level:=AspNetHostingPermissionLevel.Minimal), _
    ToolboxData("<{0}:IndexButton runat=""server""> </{0}:IndexButton>") _
    > _
    Public Class IndexButton
        Inherits Button
        Private indexValue As Integer

        < _
        Bindable(True), _
        Category("Behavior"), _
        DefaultValue(0), _
        Description("The index stored in control state.") _
        > _
        Public Property Index() As Integer
            Get
                Return indexValue
            End Get
            Set(ByVal value As Integer)
                indexValue = value
            End Set
        End Property

        < _
        Bindable(True), _
        Category("Behavior"), _
        DefaultValue(0), _
        Description("The index stored in view state.") _
        > _
        Public Property IndexInViewState() As Integer
            Get
                Dim obj As Object = ViewState("IndexInViewState")
                If obj Is Nothing Then obj = 0
                Return CInt(obj)
            End Get
            Set(ByVal value As Integer)
                ViewState("IndexInViewState") = value
            End Set
        End Property

        Protected Overrides Sub OnInit(ByVal e As EventArgs)
            MyBase.OnInit(e)
            Page.RegisterRequiresControlState(Me)
        End Sub

        Protected Overrides Function SaveControlState() As Object
            ' Invoke the base class's method and
            ' get the contribution to control state
            ' from the base class.
            ' If the indexValue field is not zero
            ' and the base class's control state is not null,
            ' use Pair as a convenient data structure
            ' to efficiently save 
            ' (and restore in LoadControlState)
            ' the two-part control state
            ' and restore it in LoadControlState.

            Dim obj As Object = MyBase.SaveControlState()

            If indexValue <> 0 Then
                If obj IsNot Nothing Then
                    Return New Pair(obj, indexValue)
                Else
                    Return indexValue
                End If
            Else
                Return obj
            End If
        End Function

        Protected Overrides Sub LoadControlState(ByVal state As Object)
            If (state IsNot Nothing) Then
                Dim p As Pair = TryCast(state, Pair)
                If p IsNot Nothing Then
                    MyBase.LoadControlState(p.First)
                    indexValue = CInt(p.Second)
                Else
                    If (TypeOf (state) Is Integer) Then
                        indexValue = CInt(state)
                    Else
                        MyBase.LoadControlState(state)
                    End If
                End If
            End If
        End Sub

    End Class
End Namespace
' </Snippet1>
