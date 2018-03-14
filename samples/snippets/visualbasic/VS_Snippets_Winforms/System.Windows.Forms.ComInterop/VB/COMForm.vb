' <snippet1>
' <snippet2>
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
' </snippet2>

<ComClass(COMForm.ClassId, COMForm.InterfaceId, COMForm.EventsId)> _
Public Class COMForm

#Region "COM GUIDs"
    ' These  GUIDs provide the COM identity for this class 
    ' and its COM interfaces. If you change them, existing 
    ' clients will no longer be able to access the class.
    Public Const ClassId As String = "1b49fe33-7c93-41ae-9dc7-8ac4d823286a"
    Public Const InterfaceId As String = "11651e1f-6db0-4c9e-b644-dcb79e6de2f6"
    Public Const EventsId As String = "7e61f977-b39d-47a6-8f34-f743c65ae3a3"
#End Region

    ' A creatable COM class must have a Public Sub New() 
    ' with no parameters, otherwise, the class will not be 
    ' registered in the COM registry and cannot be created 
    ' via CreateObject.
    Public Sub New()
        MyBase.New()
    End Sub

    ' <snippet3>
    Private WithEvents frmManager As FormManager

    Public Sub ShowForm1()
        ' Call the StartForm method by using a new instance
        ' of the Form1 class.
        StartForm(New Form1)
    End Sub

    Private Sub StartForm(ByVal frm As Form)

        ' This procedure is used to show all forms
        ' that the client application requests. When the first form
        ' is displayed, this code will create a new message
        ' loop that runs on a new thread. The new form will
        ' be treated as the main form.

        ' Later forms will be shown on the same message loop.
        If IsNothing(frmManager) Then
            frmManager = New FormManager(frm)
        Else
            frmManager.ShowForm(frm)
        End If
    End Sub

    Private Sub frmManager_MessageLoopExit() _
    Handles frmManager.MessageLoopExit

        'Release the reference to the frmManager object.
        frmManager = Nothing

    End Sub
    ' </snippet3>

End Class
' </snippet1>