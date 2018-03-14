Imports System
Imports System.ComponentModel
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Security.Permissions

Namespace ASPNET.Samples

   <AspNetHostingPermission(SecurityAction.Demand, _
      Level:=AspNetHostingPermissionLevel.Minimal)> _
   Public NotInheritable Class ViewStateControl3
      Inherits WebControl

      Private _text As String


'<snippet1>
      ' Override the OnLoad method to check if the 
      ' page that uses this control has posted back.
      ' If so, check whether this controls contains
      ' only literal content, and if it does,
      ' it gets the UniqueID property and writes it
      ' to the page. Otherwise, it writes a message
      ' that the control contains more than literal content.
      Overrides Protected Sub OnLoad(ByVal e As EventArgs)

         If Page.IsPostBack = True Then
            Dim s As String

            If Me.IsLiteralContent() = True Then
               s = Controls(0).UniqueID
               Context.Response.Write(s)
            Else
               Context.Response.Write( _
               "The control contains more than literal content.")
            End If
         End If
      End Sub
'</snippet1>

     
      Public Property [Text]() As [String]
         Get
            If _text Is Nothing Then
              Return String.Empty
            Else
              Return _text
            End If
         End Get
         Set
            _text = value
         End Set
      End Property

      Public Property TextInViewState() As String
         Get
            Dim o As Object = ViewState("TextInViewState")
            If o Is Nothing Then
               Return String.Empty
            Else
               Return CStr(o)
            End If
         End Get
   
         Set
            ViewState("TextInViewState") = value
         End Set
      End Property


'<snippet2>
      ' Override the ViewStateIgnoresCase property to allow the same
      ' entries with different casing to be stored in the control's
      ' ViewState property.
      Overrides Protected ReadOnly Property ViewStateIgnoresCase As Boolean
         Get
            Return True
         End Get
      End Property
'</snippet2>


      Overrides Protected Sub RenderContents( _
       writer As HtmlTextWriter)


         writer.Write("Text = ")
         writer.Write(Text)
         writer.Write("TextInViewState = ")
         writer.Write(TextInViewState)
     
     
      End Sub

      
   End Class

End Namespace