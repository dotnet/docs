' System.Web.UI.Control.LoadViewState;
' System.Web.UI.Control.SaveViewState;
' System.Web.UI.Control.HasChildViewState;
' System.Web.UI.Control.IsTrackingViewState;
' System.Web.UI.Control.TrackViewState;
' System.Web.UI.Control.DataBind;
' System.Web.UI.Control.EnableViewState

' The following example demonstrates the methods 'LoadViewState',
' 'SaveViewState','HasChildViewState','IsTrackingViewState','TrackViewState',
' 'DataBind','EnableViewState' of 'Control' class.
' A custom control LogOnControl is created by deriving from 'Control' class.
' LogOnControl class overloads 'LoadViewState'   
' After the postback, the saved information is retrieved and displayed by 
' clicking the 'Display Saved ViewState' button.

Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace LogOnControlSample

   Public Class LogOnControl
      Inherits Control
      Private _userText As String
      Private _passwordText As String

      Public Property UserText() As String
         Get
            Return _userText
         End Get
         Set
            _userText = value
         End Set
      End Property 

      Public Property PasswordText() As String
         Get
            Return _passwordText
         End Get
         Set
            _passwordText = value
         End Set
      End Property

' <Snippet1>
      Protected Overrides Sub LoadViewState(savedState As Object)
         If Not (savedState Is Nothing) Then
            ' Load State from the array of objects that was saved at ;
            ' SavedViewState.
            Dim myState As Object() = CType(savedState, Object())
            If Not (myState(0) Is Nothing) Then
               MyBase.LoadViewState(myState(0))
            End If
            If Not (myState(1) Is Nothing) Then
               UserText = CStr(myState(1))
            End If
            If Not (myState(2) Is Nothing) Then
               PasswordText = CStr(myState(2))
            End If
         End If
      End Sub
' </Snippet1>

' <Snippet2>
      Protected Overrides Function SaveViewState() As Object
         ' Change Text Property of Label when this function is invoked.
         If HasControls() And Page.IsPostBack Then
            CType(Controls(0), Label).Text = "Custom Control Has Saved State"
         End If
         ' Save State as a cumulative array of objects.
         Dim baseState As Object = MyBase.SaveViewState()
         Dim _userText As String = UserText
         Dim _passwordText As String = PasswordText
         Dim allStates(3) As Object
         allStates(0) = baseState
         allStates(1) = _userText
         allStates(2) = PasswordText
         Return allStates
      End Function
' </Snippet2>

      ' Add a Label as one of the child controls.
      Protected Overrides Sub CreateChildControls()
         Dim myLabel As New Label()
         myLabel.Text = "Custom Control"
         Controls.Add(New Label())
      End Sub

      ' Demonstrates implementation of DataBind method. 
     
' <Snippet3>
' <Snippet4>
' <Snippet5>
' <Snippet6>
      Public Overrides Sub DataBind()
         MyBase.OnDataBinding(EventArgs.Empty)
         ' Reset the control's state.
         Controls.Clear()
         ' Check for HasChildViewState to avoid unnecessary calls to ClearChildViewState.
         If HasChildViewState Then
            ClearChildViewState()
         End If
         ChildControlsCreated = True
         If Not IsTrackingViewState Then
            TrackViewState()
         End If
      End Sub
' </Snippet6>
' </Snippet5>
' </Snippet4>
' </Snippet3>

   End Class
End Namespace
