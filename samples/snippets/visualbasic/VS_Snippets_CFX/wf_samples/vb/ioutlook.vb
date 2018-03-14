Imports System
Imports System.Collections.Generic
Imports System.Text

Namespace WF_Snippets.Microsoft.Office.Core
    'Hack: Skeleton of the interfaces that the code sample is looking for in the obsolete Outlook Interop Assembly...
    Public Class Application
        Public Function CreateItem(ByVal item As String) As _MailItem
            Return New _MailItem()
        End Function
    End Class


    Public Class SessionClass
        Public CurrentUser As CurrentUserClass
    End Class


    Public Class CurrentUserClass

        Public Address As String

        Public Session As SessionClass

    End Class


    Public Class _MailItem
        Public MailTo As String
        Public Subject As String
        Public Body As String
        Public Sub Send()
        End Sub
    End Class

    Public Class OlItemType

        Public Shared olMailItem As String

    End Class

End Namespace
