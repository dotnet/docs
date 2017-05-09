Option Explicit On
Option Strict On

Imports System.Windows.Forms

Class Form2
    Inherits Form
End Class

Class SidebarMenu
    Inherits Form
End Class

Class Class0d07a83c90eb4489b120d268c6185436
    ' 0d07a83c-90eb-4489-b120-d268c6185436
    ' How to: Communicate Between Forms in an Application

    Public Sub Method1()
        ' <snippet1>
        My.Forms.Form2.Text = Now.ToString
        My.Forms.Form2.Show()
        ' </snippet1>
    End Sub
End Class

Class Classf6bff4e667694294956b037aa6106d2a
    ' f6bff4e6-6769-4294-956b-037aa6106d2a
    ' My.Forms Object

    ' <snippet2>
    Sub ShowSidebarMenu(ByVal newTitle As String)
        If My.Forms.SidebarMenu IsNot Nothing Then
            My.Forms.SidebarMenu.Text = newTitle
        End If
    End Sub
    ' </snippet2>
End Class
