' <Snippet2>
Partial Class ClientCallback
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler

    '<Snippet4>
    '<Snippet3>
    Protected catalog As ListDictionary
    Protected saleitem As ListDictionary
    Protected returnValue As String
    Protected validationLookUpStock As String = "LookUpStock"
    Protected validationLookUpSale As String = "LookUpSale"
    '</Snippet3>
    Sub Page_Load(ByVal sender As Object, ByVal e As _
        System.EventArgs) Handles Me.Load

        Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), _
            validationLookUpStock, "function LookUpStock() {  " & _
            "var lb = document.forms[0].ListBox1; " & _
            "if (lb.selectedIndex == -1) { alert ('Please make a selection.'); return; } " & _
            "var product = lb.options[lb.selectedIndex].text;  " & _
            "CallServer(product, ""LookUpStock"");}  ", True)
        If (User.Identity.IsAuthenticated) Then
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), _
            validationLookUpSale, "function LookUpSale() {  " & _
            "var lb = document.forms[0].ListBox1; " & _
            "if (lb.selectedIndex == -1) { alert ('Please make a selection.'); return; } " & _
            "var product = lb.options[lb.selectedIndex].text;  " & _
            "CallServer(product, ""LookUpSale"");} ", True)
        End If

        Dim cbReference As String
        cbReference = "var param = arg + '|' + context;" & _
             Page.ClientScript.GetCallbackEventReference(Me, _
            "param", "ReceiveServerData", "context")
        Dim callbackScript As String = ""
        callbackScript &= "function CallServer(arg, context) { " & _
            cbReference & "} ;"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), _
            "CallServer", callbackScript, True)

        ' Populate List Dictionary with invented database data
        catalog = New ListDictionary()
        saleitem = New ListDictionary()
        catalog.Add("monitor", 12)
        catalog.Add("laptop", 10)
        catalog.Add("keyboard", 23)
        catalog.Add("mouse", 17)
        saleitem.Add("monitor", 1)
        saleitem.Add("laptop", 0)
        saleitem.Add("keyboard", 0)
        saleitem.Add("mouse", 1)

        ListBox1.DataSource = catalog
        ListBox1.DataTextField = "key"
        ListBox1.DataBind()
    End Sub
    '</Snippet4>

    '<Snippet5>
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) _
    Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent

        Dim argParts() As String = eventArgument.Split("|"c)
        If ((argParts Is Nothing) OrElse (argParts.Length <> 2)) Then
            returnValue = "A problem occurred trying to retrieve stock count."
            Return
        End If

        Dim product As String = argParts(0)
        Dim validationaction = argParts(1)
        Select Case validationaction
            Case "LookUpStock"
                Try
                    Page.ClientScript.ValidateEvent("LookUpStockButton", validationaction)
                    If (catalog(product) Is Nothing) Then
                        returnValue = "Item not found."
                    Else
                        returnValue = catalog(product).ToString() & " in stock."
                    End If
                Catch
                    returnValue = "Can not retrieve stock count."
                End Try
            Case "LookUpSale"
                Try
                    Page.ClientScript.ValidateEvent("LookUpSaleButton", validationaction)
                    If (saleitem(product) Is Nothing) Then
                        returnValue = "Item not found."
                    Else
                        If (Convert.ToBoolean(saleitem(product))) Then
                            returnValue = "Item is on sale."
                        Else
                            returnValue = "Item is not on sale."
                        End If
                    End If
                Catch
                    returnValue = "Can not retrieve sale status."
                End Try

        End Select

    End Sub
    '</Snippet5>

    '<Snippet6>
    Public Function GetCallbackResult() _
    As String Implements _
    System.Web.UI.ICallbackEventHandler.GetCallbackResult

        Return returnValue

    End Function
    '</Snippet6>

    '<Snippet7>
    Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
        Page.ClientScript.RegisterForEventValidation("LookUpStockButton", _
          validationLookUpStock)
        If (User.Identity.IsAuthenticated) Then
            Page.ClientScript.RegisterForEventValidation("LookUpSaleButton", _
             validationLookUpSale)
        End If
        MyBase.Render(writer)
    End Sub
    '</Snippet7>
End Class
' </Snippet2>