'<Snippet1>
Imports System
Imports System.IO
Imports System.ComponentModel
Imports System.Web.UI
Imports System.Web.UI.Design
Imports System.Web.UI.Design.WebControls
Imports System.Web.UI.WebControls
Imports Examples.WebNet

Namespace Examples.WebNet
    ' Create a class that extends CreateUserWizardDesigner.
    Public Class MyCreateUserWizardDesigner
        Inherits CreateUserWizardDesigner

        ' This variable contains debugging information.
        Private debugInfo As String = "Useful information."

        ' Override the GetErrorDesignTimeHtml method to add some more
        ' information to the error message.
        Protected Overrides Function GetErrorDesignTimeHtml(ByVal e As Exception) As String
            ' Get the error message from the base class.
            Dim htmlStr As String
            htmlStr = MyBase.GetErrorDesignTimeHtml(e)

            ' Append the debugging information to it.
            htmlStr &= "<br>DebugInfo: " & debugInfo

            ' Return the error message.
            Return htmlStr
        End Function
    End Class

End Namespace
'</Snippet1>
