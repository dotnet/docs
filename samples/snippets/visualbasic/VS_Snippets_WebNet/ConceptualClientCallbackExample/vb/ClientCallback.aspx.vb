' <Snippet4>
Partial Class ClientCallback
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler

    Protected catalog As ListDictionary
    Protected returnValue As String
    Sub Page_Load(ByVal sender As Object, ByVal e As _
        System.EventArgs) Handles Me.Load
        Dim cbReference As String
        cbReference = Page.ClientScript.GetCallbackEventReference(Me, _
            "arg", "ReceiveServerData", "context")
        Dim callbackScript As String = ""
        callbackScript &= "function CallServer(arg, context) { " & _
            cbReference & "} ;"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), _
            "CallServer", callbackScript, True)

        ' Populate List Dictionary with invented database data
        catalog = New ListDictionary()
        catalog.Add("monitor", 12)
        catalog.Add("laptop", 10)
        catalog.Add("keyboard", 23)
        catalog.Add("mouse", 17)

        ListBox1.DataSource = catalog
        ListBox1.DataTextField = "key"
        ListBox1.DataBind()
    End Sub

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) _
    Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent

        If catalog(eventArgument) Is Nothing Then
            returnValue = "-1"
        Else
            returnValue = catalog(eventArgument).ToString()
        End If

    End Sub

    Public Function GetCallbackResult() _
    As String Implements _
    System.Web.UI.ICallbackEventHandler.GetCallbackResult

        Return returnValue

    End Function

End Class
' </Snippet4>