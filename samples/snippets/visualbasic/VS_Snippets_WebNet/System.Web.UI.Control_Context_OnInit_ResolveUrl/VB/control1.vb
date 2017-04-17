Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls


Namespace CustomControl1

    Public Class ParentControl
        Inherits Control
        ' <snippet1>      
        <System.Security.Permissions.PermissionSetAttribute( _
            System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
        Protected Overrides Function OnBubbleEvent(ByVal sender As Object, ByVal e As EventArgs) As Boolean

            ' Use the Context property to write text to the TraceContext object
            ' associated with the current request.         
            Context.Trace.Write("The ParentControl's OnBubbleEvent method is called.")
            Context.Trace.Write("The Source of event is: " + sender.ToString())

            Return True
        End Function 'OnBubbleEvent
        ' </snippet1>   

        <System.Security.Permissions.PermissionSetAttribute( _
            System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
        Protected Overrides Sub Render(ByVal myWriter As HtmlTextWriter)
            myWriter.Write("ParentControl")
            RenderChildren(myWriter)
        End Sub
    End Class

    Public Class ChildControl
        Inherits Button

        <System.Security.Permissions.PermissionSetAttribute( _
      System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
  Protected Overrides Sub OnClick(ByVal e As EventArgs)
            MyBase.OnClick(e)
            Context.Trace.Write("The ChildControl's OnClick method is called.")
            ' Bubble this event to parent.
            RaiseBubbleEvent(Me, e)
        End Sub 'OnClick
    End Class 'ChildControl
    _

    Public Class MyResolveUrl
        Inherits Control
        Private _ImageUrl As String

        Public Property ImageUrl() As String
            Get
                Return _ImageUrl
            End Get
            Set(ByVal value As String)
                _ImageUrl = value
            End Set
        End Property


        ' <snippet2>
        <System.Security.Permissions.PermissionSetAttribute( _
            System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
        Protected Overrides Sub Render(ByVal output As HtmlTextWriter)

            Dim myImage As New System.Web.UI.WebControls.Image()

            ' Use the ResolveUrl method to assign a URL
            ' path to the Image.
            myImage.ImageUrl = ResolveUrl(Me.ImageUrl)
            myImage.RenderControl(output)
        End Sub 'Render

        ' </snippet2>
    End Class


    Public Class myLabel
        Inherits WebControl
        Private _text As String


        Public Sub New()
            MyBase.New("H1")
        End Sub 'New


        Public Property [Text]() As String
            Get
                Return _text
            End Get
            Set(ByVal value As String)
                _text = value
            End Set
        End Property

        ' <snippet3>
        ' Override the OnInit method to set _text to 
        ' a default value if it is null.
        <System.Security.Permissions.PermissionSetAttribute( _
          System.Security.Permissions.SecurityAction.Demand, _
            Name:="FullTrust")> _
        Protected Overrides Sub OnInit(ByVal e As EventArgs)
            MyBase.OnInit(e)
            If _text Is Nothing Then
                _text = "Here is some default text."
            End If
        End Sub 'OnInit
        ' </snippet3>       

        <System.Security.Permissions.PermissionSetAttribute( _
      System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
  Protected Overrides Sub RenderContents(ByVal writer As HtmlTextWriter)
            writer.Write(_text)
        End Sub
    End Class
End Namespace
