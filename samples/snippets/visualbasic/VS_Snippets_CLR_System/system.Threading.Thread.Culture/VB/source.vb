' <Snippet1>
Imports System.Threading
Imports System.Windows.Forms

Public Class UICulture : Inherits Form
    Sub New()

        ' Set the user interface to display in the
        ' same culture as that set in Control Panel.
        Thread.CurrentThread.CurrentUICulture = _
            Thread.CurrentThread.CurrentCulture

        ' Add additional code.
    End Sub

    Shared Sub Main()
        Application.Run(New UICulture())
    End Sub
End Class
' </Snippet1>