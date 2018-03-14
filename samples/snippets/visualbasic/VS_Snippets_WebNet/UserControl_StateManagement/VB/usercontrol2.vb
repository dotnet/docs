Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls


Public Class LogOnControl
   Inherits UserControl
   Protected user As TextBox
   Protected password As TextBox
   ' <Snippet1>  
   ' <Snippet2>
   
    Public Property UserText() As String

        Get
            Return CStr(ViewState("usertext"))
        End Get
        Set(ByVal value As String)
            ViewState("usertext") = value
        End Set

    End Property
   
    Public Property PasswordText() As String

        Get
            Return CStr(ViewState("passwordtext"))
        End Get
        Set(ByVal value As String)
            ViewState("passwordtext") = value
        End Set

    End Property
   
    <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
    Protected Overrides Sub LoadViewState(ByVal savedState As Object)

        Dim totalState As Object() = Nothing
        If Not (savedState Is Nothing) Then
            totalState = CType(savedState, Object())
            If totalState.Length <> 3 Then
                ' Throw an appropriate exception.
            End If
            ' Load base state.
            MyBase.LoadViewState(totalState(0))
            ' Load extra information specific to this control.
            If Not (totalState Is Nothing) AndAlso Not (totalState(1) Is Nothing) AndAlso Not (totalState(2) Is Nothing) Then
                UserText = CStr(totalState(1))
                PasswordText = CStr(totalState(2))
            End If
        End If

    End Sub
     
    <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
    Protected Overrides Function SaveViewState() As Object

        Dim baseState As Object = MyBase.SaveViewState()
        Dim totalState(2) As Object
        totalState(0) = baseState
        totalState(1) = user.Text
        totalState(2) = password.Text
        Return totalState

    End Function
End Class 
' </Snippet2>  
' </Snippet1>