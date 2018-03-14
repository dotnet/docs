'<Snippet2>
Imports System
Imports System.IO
Imports System.ComponentModel
Imports System.Web.UI.WebControls
Imports System.Web.UI
Imports System.Web.UI.Design
Imports System.Web.UI.Design.WebControls
Imports Examples.WebNet

Namespace Examples.WebNet
    ' Create a class that extends CreateUserWizard and uses
    ' MyCreateUserWizardDesigner as its designer.
    <Designer(GetType(Examples.WebNet.MyCreateUserWizardDesigner))> _
    Public Class MyCreateUserWizard
        Inherits CreateUserWizard
        ' Put your own code here
    End Class
End Namespace
'</Snippet2>
