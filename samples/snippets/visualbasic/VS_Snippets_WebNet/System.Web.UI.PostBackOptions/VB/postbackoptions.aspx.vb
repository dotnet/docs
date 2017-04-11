' <snippet2>
Partial Class postbackoptionsvb
    Inherits System.Web.UI.Page
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)

        ' Create a new PostBackOptions object and set its properties.
        Dim myPostBackOptions As PostBackOptions = New PostBackOptions(Me)
        myPostBackOptions.ActionUrl = "Page2.aspx"
        myPostBackOptions.AutoPostBack = False
        myPostBackOptions.RequiresJavaScriptProtocol = True
        myPostBackOptions.PerformValidation = True

        ' Add the client-side script to the HyperLink1 control.
        HyperLink1.NavigateUrl = Page.ClientScript.GetPostBackEventReference(myPostBackOptions)

        Label1.Text = "Click this hyperlink to initiate a postback event."

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Page.IsPostBack Then
            Label1.Text = "A postback event has occurred."
        End If

    End Sub
End Class
' </snippet2>