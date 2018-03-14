' <snippet1>
Imports System
Imports System.Security.Permissions
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Web
Imports System.Web.UI
 
Namespace Samples.AspNet.VB.Controls
' <snippet2>
    '////////////////////////////////////////////////////////////
    '
    ' The strongly typed CycleCollection class is a collection
    ' that contains Cycle class instances, which implement the
    ' IStateManager interface.
    '
    '////////////////////////////////////////////////////////////
    <AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
                   Public NotInheritable Class CycleCollection
        Inherits StateManagedCollection

        Private Shared _typesOfCycles() As Type = _
            {GetType(Bicycle), GetType(Tricycle)}

        Protected Overrides Function CreateKnownType(ByVal index As Integer) As Object
            Select Case index
                Case 0
                    Return New Bicycle()
                Case 1
                    Return New Tricycle()
                Case Else
                    Throw New ArgumentOutOfRangeException("Unknown Type")
            End Select

        End Function


        Protected Overrides Function GetKnownTypes() As Type()
            Return _typesOfCycles

        End Function


        Protected Overrides Sub SetDirtyObject(ByVal o As Object)
            CType(o, Cycle).SetDirty()

        End Sub
    End Class
' </snippet2>
    '////////////////////////////////////////////////////////////
    '
    ' The abstract Cycle class represents bicycles and tricycles.
    '
    '////////////////////////////////////////////////////////////

    MustInherit Public Class Cycle
        Implements IStateManager


        Friend Protected Sub New(ByVal numWheels As Integer) 
            MyClass.New(numWheels, "Red")

        End Sub

        Friend Protected Sub New(ByVal numWheels As Integer, ByVal color As String) 
            numOfWheels = numWheels
            CycleColor = color

        End Sub

        Private numOfWheels As Integer = 0    
        Public ReadOnly Property NumberOfWheels() As Integer 
            Get
                Return numOfWheels
            End Get
        End Property 

        Public Property CycleColor() As String 
            Get
                Dim o As Object = ViewState("Color")
                If o Is Nothing Then 
                    Return String.Empty
                Else  
                    Return o.ToString()
                End If            
            End Get
            Set
                ViewState("Color") = value
            End Set
        End Property


        Friend Sub SetDirty() 
            ViewState.SetDirty(True)

        End Sub

        ' Because Cycle does not derive from Control, it does not 
        ' have access to an inherited view state StateBag object.
        Private cycleViewState As StateBag

        Private ReadOnly Property ViewState() As StateBag 
            Get
                If cycleViewState Is Nothing Then
                    cycleViewState = New StateBag(False)
                    If trackingViewState Then
                        CType(cycleViewState, IStateManager).TrackViewState()
                    End If
                End If
                Return cycleViewState
            End Get
        End Property

        ' The IStateManager implementation.
        Private trackingViewState As Boolean

        ReadOnly Property IsTrackingViewState() As Boolean _
            Implements IStateManager.IsTrackingViewState
            Get
                Return trackingViewState
            End Get
        End Property


        Sub LoadViewState(ByVal savedState As Object) _
            Implements IStateManager.LoadViewState
            Dim cycleState As Object() = CType(savedState, Object())

            ' In SaveViewState, an array of one element is created.
            ' Therefore, if the array passed to LoadViewState has 
            ' more than one element, it is invalid.
            If cycleState.Length <> 1 Then
                Throw New ArgumentException("Invalid Cycle View State")
            End If

            ' Call LoadViewState on the StateBag object.
            CType(ViewState, IStateManager).LoadViewState(cycleState(0))

        End Sub


        ' Save the view state by calling the StateBag's SaveViewState
        ' method.
        Function SaveViewState() As Object Implements IStateManager.SaveViewState
            Dim cycleState(0) As Object

            If Not (cycleViewState Is Nothing) Then
                cycleState(0) = _
                CType(cycleViewState, IStateManager).SaveViewState()
            End If
            Return cycleState

        End Function


        ' Begin tracking view state. Check the private variable, because 
        ' if the view state has not been accessed or set, then it is not being 
        ' used and there is no reason to store any view state.
        Sub TrackViewState() Implements IStateManager.TrackViewState
            trackingViewState = True
            If Not (cycleViewState Is Nothing) Then
                CType(cycleViewState, IStateManager).TrackViewState()
            End If

        End Sub
    End Class


    Public NotInheritable Class Bicycle
        Inherits Cycle


        ' Create a red Cycle with two wheels.
        Public Sub New()
            MyBase.New(2)

        End Sub
    End Class

    Public NotInheritable Class Tricycle
        Inherits Cycle


        ' Create a red Cycle with three wheels.
        Public Sub New()
            MyBase.New(3)

        End Sub
    End Class
End Namespace
' </snippet1>