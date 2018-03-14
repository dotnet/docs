' <snippet10>
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.Windows.Forms

<ComVisible(False)> _
Friend Class FormManager
    ' This class is used so that you can generically pass any
    ' form that you want to the delegate.

    Private WithEvents appContext As ApplicationContext
    Private Delegate Sub FormShowDelegate(ByVal form As Form)
    Event MessageLoopExit()

    Public Sub New(ByVal MainForm As Form)
        Dim t As Thread
        If IsNothing(appContext) Then
            appContext = New ApplicationContext(MainForm)
            t = New Thread(AddressOf StartMessageLoop)
            t.IsBackground = True
            t.SetApartmentState(ApartmentState.STA)
            t.Start()
        End If
    End Sub

    Private Sub StartMessageLoop()
        ' Call the Application.Run method to run the form on its own message loop.
        Application.Run(appContext)
    End Sub

    Public Sub ShowForm(ByVal form As Form)

        Dim formShow As FormShowDelegate

        ' Start the main form first. Otherwise, focus will stay on the 
        ' calling form.
        appContext.MainForm.Activate()

        ' Create a new instance of the FormShowDelegate method, and
        ' then invoke the delegate off the MainForm object.
        formShow = New FormShowDelegate( _
        AddressOf ShowFormOnMainForm_MessageLoop)

        appContext.MainForm.Invoke(formShow, New Object() {form})
    End Sub

    Private Sub ShowFormOnMainForm_MessageLoop(ByVal form As Form)
        form.Show()
    End Sub

    Private Sub ac_ThreadExit( _
    ByVal sender As Object, _
    ByVal e As System.EventArgs) _
    Handles appContext.ThreadExit
        appContext.MainForm.Dispose()
        appContext.MainForm = Nothing
        appContext.Dispose()
        appContext = Nothing
        RaiseEvent MessageLoopExit()
    End Sub
End Class
' </snippet10>