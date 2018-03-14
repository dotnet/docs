Imports Microsoft.VisualBasic
Imports System

Public Class global_asax

    ' <snippet2>
    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)

        'Initialize user count property
        Application("UserCount") = 0

    End Sub

    Sub AnonymousIdentification_Creating(ByVal sender As Object, ByVal e As AnonymousIdentificationEventArgs)

        ' Change the anonymous id
        e.AnonymousID = "mysite.com_Anonymous_User_" & DateTime.Now.Ticks

        ' Increment count of unique anonymous users
        Application("UserCount") = Int32.Parse(Application("UserCount").ToString()) + 1

    End Sub

    ' </snippet2>

End Class
