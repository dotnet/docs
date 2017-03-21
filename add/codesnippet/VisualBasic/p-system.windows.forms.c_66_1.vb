Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.IO
Imports System.Security.Permissions

Public Class MyIconButton
    Inherits Button

    Private ButtonIcon As Icon

    Public Sub New()
        MyBase.New()

        ' Set the button's FlatStyle property.
        Me.FlatStyle = System.Windows.Forms.FlatStyle.System
    End Sub

    Public Sub New(ByVal Icon As Icon)
        MyBase.New()

        ' Assign the icon to the private field.   
        Me.ButtonIcon = Icon

        ' Size the button to 4 pixels larger than the icon.
        Me.Height = ButtonIcon.Height + 4
        Me.Width = ButtonIcon.Width + 4
    End Sub


    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Dim SecPerm As New SecurityPermission(SecurityPermissionFlag.UnmanagedCode)
            SecPerm.Demand()

            ' Extend the CreateParams property of the Button class.
            Dim cp As System.Windows.Forms.CreateParams = MyBase.CreateParams
            ' Update the button Style.
            cp.Style = cp.Style Or &H40 ' BS_ICON value

            Return cp
        End Get
    End Property

    Public Property Icon() As Icon
        Get
            Return ButtonIcon
        End Get

        Set(ByVal Value As Icon)
            ButtonIcon = Value
            UpdateIcon()
            ' Size the button to 4 pixels larger than the icon.
            Me.Height = ButtonIcon.Height + 4
            Me.Width = ButtonIcon.Width + 4
        End Set
    End Property

    <SecurityPermission(SecurityAction.Demand, UnmanagedCode := True)> _
    Protected Overrides Sub OnHandleCreated(ByVal e As EventArgs)
        MyBase.OnHandleCreated(e)

        ' Update the icon on the button if there is currently an icon assigned to the icon field.
        If Me.ButtonIcon IsNot Nothing Then
            UpdateIcon()
        End If
    End Sub

    Private Sub UpdateIcon()
        Dim IconHandle As IntPtr = IntPtr.Zero

        ' Get the icon's handle.
        If Me.Icon IsNot Nothing Then
            IconHandle = Icon.Handle
        End If

        ' Send Windows the message to update the button. 
        ' BM_SETIMAGE (second parameter) and IMAGE_ICON (third parameter).
        SendMessage(Handle, &HF7, &H1, IconHandle.ToInt32())
    End Sub

    ' Declare the SendMessage function.
    Declare Auto Function SendMessage Lib "user32" (ByVal hWnd As IntPtr, _
            ByVal msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As IntPtr
End Class