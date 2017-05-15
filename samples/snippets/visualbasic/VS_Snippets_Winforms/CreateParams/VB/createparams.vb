' <snippet1>
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

    ' <snippet3>

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
    ' </snippet3>

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
' </snippet1>

'///////////////////////////////////////////////////////////////////////////////////////////////////

' <snippet2>
Public Class Form1
    Inherits System.Windows.Forms.Form

    Friend WithEvents MyStdButton As System.Windows.Forms.Button
    Friend WithEvents MyIconButton As MyIconButton
    Friend WithEvents OpenDlg As OpenFileDialog

    Public Sub New()
        MyBase.New()
        Try
            ' Create the button with the default icon.
            MyIconButton = New MyIconButton(New Icon(Application.StartupPath + "\Default.ico"))

        Catch ex As Exception
            ' If the default icon does not exist, create the button without an icon.
            MyIconButton = New MyIconButton()
            System.Diagnostics.Debug.WriteLine(ex.ToString())
        Finally
            MyStdButton = New Button()

            'Set the location, text and width of the standard button.
            MyStdButton.Location = New Point(MyIconButton.Location.X, _
                        MyIconButton.Location.Y + MyIconButton.Height + 20)
            MyStdButton.Text = "Change Icon"
            MyStdButton.Width = 100

            ' Add the buttons to the Form.
            Me.Controls.Add(MyStdButton)
            Me.Controls.Add(MyIconButton)
        End Try

    End Sub

    Public Shared Sub Main()
        Application.Run(New Form1())
    End Sub

    Private Sub MyStdButton_Click(ByVal sender As System.Object, _
                ByVal e As System.EventArgs) Handles MyStdButton.Click
        ' Use an OpenFileDialog to allow the user to assign a new image to the derived button.
        OpenDlg = New OpenFileDialog()
        OpenDlg.InitialDirectory = Application.StartupPath
        OpenDlg.Filter = "Icon files (*.ico)|*.ico"
        OpenDlg.Multiselect = False
        OpenDlg.ShowDialog()

        If OpenDlg.FileName <> "" Then
            MyIconButton.Icon = New Icon(OpenDlg.FileName)
        End If
    End Sub

    Private Sub MyIconButton_Click(ByVal sender As System.Object, _
                ByVal e As System.EventArgs) Handles MyIconButton.Click
        ' Make sure MyIconButton works.
        MessageBox.Show("MyIconButton was clicked!")
    End Sub
End Class
' </snippet2>