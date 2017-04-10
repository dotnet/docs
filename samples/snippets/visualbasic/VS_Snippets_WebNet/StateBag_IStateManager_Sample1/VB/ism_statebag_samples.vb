' <snippet1>
' Create a namespace that contains a class, MyItem,
' that implements the IStateManager interface and 
' another, MyControl, that overrides its own view-state
' management methods to use those of MyItem.
Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Collections
Imports System.Security.Permissions

Namespace StateBagSampleVB

    ' <Snippet8>
    ' Create a class that implements IStateManager so that
    ' it can manage its own view state.   

    <AspNetHostingPermission(SecurityAction.Demand, _
       Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class MyItem
        Implements IStateManager
        Private _message As String

        ' The StateBag object that allows you to save
        ' and restore view-state information.
        Private _viewstate As StateBag


        ' The constructor for the MyItem class.
        Public Sub New(ByVal mesg As String)
            _message = mesg
            _viewstate = New StateBag()
            _viewstate.Add("message", _message)
        End Sub 'New

        ' <Snippet2>
        ' Create a Message property that reads from and writes
        ' to view state. If the set accessor writes the message
        ' value to view state, the StateBag.SetItemDirty method
        ' is called, telling view state that the item has changed. 

        Public Property Message() As String
            Get
                Return CStr(_viewstate("message"))
            End Get
            Set(ByVal value As String)
                _message = value
                _viewstate.SetItemDirty("message", True)
            End Set
        End Property

        ' </Snippet2>
        ' <Snippet3>
        ' Implement the LoadViewState method. If the saved view state
        ' exists, the view-state value is loaded to the MyItem 
        ' control. 
        Sub LoadViewState(ByVal savedState As Object) Implements IStateManager.LoadViewState
            _message = CStr(_viewstate("message"))
            If Not (savedState Is Nothing) Then
                CType(_viewstate, IStateManager).LoadViewState(savedState)
            End If
        End Sub 'LoadViewState
        ' </Snippet3>
        ' <Snippet4>
        ' Implement the SaveViewState method. If the StateBag
        ' that stores the MyItem class's view state contains
        ' a value for the message property and if the value
        ' has changed since the TrackViewState method was last 
        ' called, all view state for this class is deleted, 
        ' using the StateBag.Clear method,and the new value is added.
        Function SaveViewState() As Object Implements IStateManager.SaveViewState
            ' Check whether the message property exists in 
            ' the ViewState property, and if it does, check
            ' whether it has changed since the most recent
            ' TrackViewState method call.
            If Not CType(_viewstate, IDictionary).Contains("message") OrElse _viewstate.IsItemDirty("message") Then
                _viewstate.Clear()
                ' Add the _message property to the StateBag.
                _viewstate.Add("message", _message)
            End If
            Return CType(_viewstate, IStateManager).SaveViewState()
        End Function 'IStateManager.SaveViewState


        ' </Snippet4>
        ' <Snippet5>
        ' Implement the TrackViewState method for this class by
        ' calling the TrackViewState method of the class's private
        ' _viewstate property.
        Sub TrackViewState() Implements IStateManager.TrackViewState
            CType(_viewstate, IStateManager).TrackViewState()
        End Sub 'IStateManager.TrackViewState
        ' </Snippet5>
        ' <snippet6>
        ' Implement the IsTrackingViewState method for this class 
        ' by calling the IsTrackingViewState method of the class's
        ' private _viewstate property. 

        ReadOnly Property IsTrackingViewState() As Boolean Implements IStateManager.IsTrackingViewState
            Get
                Return CType(_viewstate, IStateManager).IsTrackingViewState
            End Get
        End Property

        ' </snippet6>
        ' <Snippet7>
        ' Create a function that iterates through the view-state
        ' values stored for this class and returns the
        ' results as a string.
        Public Function EnumerateViewState() As String
            Dim keyName, keyValue As String
            Dim result As String = [String].Empty
            Dim myStateItem As StateItem
            Dim myDictionaryEnumerator As IDictionaryEnumerator = _viewstate.GetEnumerator()
            While myDictionaryEnumerator.MoveNext()
                keyName = CStr(myDictionaryEnumerator.Key)
                myStateItem = CType(myDictionaryEnumerator.Value, StateItem)
                keyValue = CStr(myStateItem.Value)
                result = result + "<br>ViewState[" + keyName + "] = " + keyValue
            End While
            Return result
        End Function 'EnumerateViewState
    End Class 'MyItem 
    ' </Snippet7>
    ' </Snippet8>

    ' <snippet9>
    ' This class contains an instance of the MyItem class as 
    ' private member. It overrides the state management methods 
    ' of the Control class, since it has to invoke state 
    ' management methods of MyItem whenever its own
    ' view state is being saved, loaded, or tracked.

    <AspNetHostingPermission(SecurityAction.Demand, _
       Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class MyControl
        Inherits Control
        Private myItem As MyItem

        Public Sub New()
            myItem = New MyItem("Hello World!")
        End Sub 'New

        ' Override the LoadViewState method of the Control class.
        Protected Overrides Sub LoadViewState(ByVal savedState As Object)
            If Not (savedState Is Nothing) Then
                Dim myState As Object() = CType(savedState, Object())
                If Not (myState(0) Is Nothing) Then
                    MyBase.LoadViewState(myState(0))
                End If
                If Not (myState(1) Is Nothing) Then
                    CType(myItem, IStateManager).LoadViewState(myState(1))
                End If
            End If
        End Sub 'LoadViewState
        ' Override the TrackViewState method of the Control class
        ' to call the version of this method that was 
        ' implemented in the MyItem class.
        Protected Overrides Sub TrackViewState()
            MyBase.TrackViewState()
            If Not (myItem Is Nothing) Then
                CType(myItem, IStateManager).TrackViewState()
            End If
        End Sub 'TrackViewState

        ' Override the SaveViewState method of the Control class to
        ' call the version of this method that was implemented by
        ' the MyItem class.
        Protected Overrides Function SaveViewState() As Object
            Dim baseState As Object = MyBase.SaveViewState()
            Dim itemState As Object
            If Not (myItem Is Nothing) Then
                itemState = CType(myItem, IStateManager).SaveViewState()
            Else
                itemState = Nothing
            End If

            Dim myState(1) As Object
            myState(0) = baseState
            myState(1) = itemState
            Return myState
        End Function 'SaveViewState


        Public Sub SetMessage(ByVal mesg As String)
            myItem.Message = mesg
        End Sub 'SetMessage


        Public Function GetMessage() As String
            Return myItem.Message
        End Function 'GetMessage


        ' Display the contents of Message and ViewState properties. 
        Protected Overrides Sub Render(ByVal output As HtmlTextWriter)
            ' Track changes to  view state before rendering.
            TrackViewState()
            output.Write(("Message: " + myItem.Message))
            output.Write("<br>")
            output.Write("<br>Enumerating the view state of the custom control<br>")
            output.Write(myItem.EnumerateViewState())
        End Sub 'Render
    End Class 'MyControl
    ' </snippet9>
End Namespace 'StateBagSampleVB
' </snippet1>