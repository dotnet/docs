' <Snippet1>
Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace Samples.AspNet.VB.Controls

    Public Class MyLoginView
        Inherits LoginView

        Private _anonymoustemplate As ITemplate

        <Browsable(False), DefaultValue(""), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(LoginView)), TemplateInstance(TemplateInstance.Single)> _
        Public Overrides Property AnonymousTemplate() As System.Web.UI.ITemplate
            Get
                Return _anonymoustemplate
            End Get
            Set(ByVal value As System.Web.UI.ITemplate)
                _anonymoustemplate = value
            End Set
        End Property

    End Class

End Namespace
' </Snippet1>
