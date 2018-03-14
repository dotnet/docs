Imports System.Xml
Imports System.Data
Imports System.Data.SqlClient

Public Class Form1
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim mtb As MaskedTextBox = New MaskedTextBox()
    End Sub

    Private Sub GetDocument()
	' <SNIPPET17>
	Dim Doc as HtmlDocument = WebBrowser1.Document
	' </SNIPPET17>
    End Sub

    '<SNIPPET1>
    Private Sub EnableAllElements()
        If (WebBrowser1.Document IsNot Nothing) Then
            For Each PageElement As HtmlElement In WebBrowser1.Document.All
                PageElement.Enabled = True
            Next
        End If
    End Sub
    '</SNIPPET1>

    '<SNIPPET2>
    Private Sub ShowCookies()
        MessageBox.Show("Cookies are " & WebBrowser1.Document.Cookie)
    End Sub
    '</SNIPPET2>

    '<SNIPPET3>
    Private Function GetLastModifiedDate() As String
        If (Not (WebBrowser1.Document Is Nothing)) Then
            Dim CurrentDocument As MSHTML.IHTMLDocument2 = WebBrowser1.Document.DomDocument
            GetLastModifiedDate = CurrentDocument.lastModified
        Else
            GetLastModifiedDate = Nothing
        End If
    End Function
    '</SNIPPET3>


    '<SNIPPET4>
    Private Sub ResetForms()
        If (Not (WebBrowser1.Document Is Nothing)) Then
            For Each FormElem As HtmlElement In WebBrowser1.Document.Forms
                FormElem.InvokeMember("reset")
            Next
        End If
    End Sub
    '</SNIPPET4>

    '<SNIPPET5>
    Private Function GetTableRowCount(ByVal TableID As String) As Integer
        Dim Count As Integer = 0

        If (WebBrowser1.Document IsNot Nothing) Then

            Dim TableElem As HtmlElement = WebBrowser1.Document.GetElementById(TableID)
            If (TableElem IsNot Nothing) Then
                For Each RowElem As HtmlElement In TableElem.GetElementsByTagName("TR")
                    Count = Count + 1
                Next
            Else
                Throw (New ArgumentException("No TABLE with an ID of " & TableID & " exists."))
            End If
        End If
        GetTableRowCount = Count
    End Function
    '</SNIPPET5>

    ' <SNIPPET6>
    Private Sub DisplayMetaDescription()
        If (WebBrowser1.Document IsNot Nothing) Then
            Dim Elems As HtmlElementCollection 
            Dim WebOC as WebBrowser = WebBrowser1

	    Elems = WebOC.Document.GetElementsByTagName("META")

            For Each elem As HtmlElement In Elems
                Dim NameStr As String = elem.GetAttribute("name")

                If ((NameStr IsNot Nothing) And (NameStr.Length <> 0)) Then
                    If NameStr.ToLower().Equals("description") Then
                        Dim ContentStr As String = elem.GetAttribute("content")
                        MessageBox.Show("Document: " & WebOC.Url.ToString() & vbCrLf & "Description: " & ContentStr)
                    End If
                End If
            Next
        End If
    End Sub
    '</SNIPPET6>


    '<SNIPPET7>
    Private Sub Document_Click(ByVal sender As Object, ByVal e As HtmlElementEventArgs)
        If (WebBrowser1.Document IsNot Nothing) Then
            Dim Elem As HtmlElement = WebBrowser1.Document.GetElementFromPoint(e.ClientMousePosition)
            Elem.ScrollIntoView(True)
        End If
    End Sub
    '</SNIPPET7>


    '<SNIPPET8>
    Private Function GetImageUrls() As String()
        If (WebBrowser1.Document IsNot Nothing) Then
            Dim Urls(WebBrowser1.Document.Images.Count) As String

            For Each ImgElement As HtmlElement In WebBrowser1.Document.Images
                Urls(Urls.Length) = ImgElement.GetAttribute("SRC")
            Next

            GetImageUrls = Urls
        Else
            Dim Urls(0) As String
            GetImageUrls = Urls
        End If
    End Function
    '</SNIPPET8>


    '<SNIPPET9>
    Private Sub InvokeTestMethod(ByVal Name As String, ByVal Address As String)
        If (Not (WebBrowser1.Document Is Nothing)) Then
            Dim ObjArr(2) As Object
            ObjArr(0) = CObj(New String(Name))
            ObjArr(1) = CObj(New String(Address))
            WebBrowser1.Document.InvokeScript("test", ObjArr)
        End If
    End Sub
    '</SNIPPET9>

    '<SNIPPET10>
    Private Sub DisplayCustomersTable()
        ' Initialize the database connection.
        Dim CustomerData As New DataSet()
        Dim CustomerTable As DataTable

        Try
            Dim DBConn As New SqlConnection("Data Source=localhost;Integrated Security=SSPI;Initial Catalog=Northwind;")
            Dim DBQuery As New SqlDataAdapter("SELECT * FROM CUSTOMERS", DBConn)
            DBQuery.Fill(CustomerData)
        Catch dbEX As DataException

        End Try

        CustomerTable = CustomerData.Tables("Customers")

        If (Not (WebBrowser1.Document Is Nothing)) Then
            With WebBrowser1.Document
                Dim TableElem As HtmlElement = .CreateElement("TABLE")
                .Body.AppendChild(TableElem)

                Dim TableRow As HtmlElement

                ' Create the table header. 
                Dim TableHeader As HtmlElement = .CreateElement("THEAD")
                TableElem.AppendChild(TableHeader)
                TableRow = .CreateElement("TR")
                TableHeader.AppendChild(TableRow)

                Dim HeaderElem As HtmlElement
                For Each Col As DataColumn In CustomerTable.Columns
                    HeaderElem = .CreateElement("TH")
                    HeaderElem.InnerText = Col.ColumnName
                    TableRow.AppendChild(HeaderElem)
                Next

                ' Create table rows.
                Dim TableBody As HtmlElement = .CreateElement("TBODY")
                TableElem.AppendChild(TableBody)
                For Each Row As DataRow In CustomerTable.Rows
                    TableRow = .CreateElement("TR")
                    TableBody.AppendChild(TableRow)
                    For Each Col As DataColumn In CustomerTable.Columns
                        Dim Item As Object = Row(Col)
                        Dim TableCell As HtmlElement = .CreateElement("TD")
                        If Not (TypeOf (Item) Is DBNull) Then
                            TableCell.InnerText = CStr(Item)
                        End If
                        TableRow.AppendChild(TableCell)
                    Next
                Next

            End With
        End If
    End Sub
    ' </SNIPPET10>

    '<SNIPPET11>
    Private Sub WriteNewDocument()
        If (WebBrowser1.Document IsNot Nothing) Then
            Dim doc As HtmlDocument = WebBrowser1.Document.OpenNew(True)
            doc.Write("<HTML><BODY>This is a new HTML document.</BODY></HTML>")
        End If
    End Sub
    '</SNIPPET11>

    '<SNIPPET12>
    Private Sub InvokeScript()
        If (WebBrowser1.Document IsNot Nothing) Then
            With WebBrowser1.Document
                Dim Str As String = .InvokeScript("test")
                Dim JScriptObj As Object = .InvokeScript("testJScriptObject")
                Dim DomObj As Object = .InvokeScript("testElement")
            End With
        End If
    End Sub
    '</SNIPPET12>

    '<SNIPPET13>
    Private Sub AppendText(ByVal Text As String)
        If (WebBrowser1.Document IsNot Nothing) Then
            With WebBrowser1.Document
                Dim TextElem As HtmlElement = .CreateElement("DIV")
                TextElem.InnerText = Text
                .Body.AppendChild(TextElem)
            End With
        End If
    End Sub
    '</SNIPPET13>


    '<SNIPPET14>
    Private Sub ExportDocumentLink()
        If (WebBrowser1.Document IsNot Nothing) Then
            Dim Link As String = "<A HREF=""" & WebBrowser1.Document.Url.ToString() & """>" & WebBrowser1.Document.Title & "</A>"

            Dim DataObj As IDataObject = Clipboard.GetDataObject()
            DataObj.SetData("Html", True, CObj(Link))
        End If
    End Sub
    '</SNIPPET14>

'    '<SNIPPET16>
 '   Public Sub SnipSelected()
  '      If (webBrowser1.Document IsNot Nothing) Then
   '         Dim o As Object = Nothing
    '        webBrowser1.Document.ExecCommand("Copy", False, o)
     '       Dim selected As String = CType(o, String)
      '      If (selected IsNot Nothing) AndAlso selected.Length > 0 Then
       '         MessageBox.Show("Selected text: " & selected)
        '    End If
        'End If
   ' End Sub
    '</SNIPPET16>

    Private Sub TestHTMLThrowButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestHTMLThrowButton.Click
        Dim elem As HtmlElement = WebBrowser1.Document.GetElementById("img1")
        elem.InnerHtml = "<DIV>Hello, world!</DIV>"
    End Sub

    Private Sub TestDomainButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestDomainButton.Click
        WebBrowser1.Document.Domain = "AKLAJ!()@#JOP#"
    End Sub

    Private Sub TestForwardNegButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestForwardNegButton.Click
        WebBrowser1.Document.Window.History.Forward(-1)
    End Sub

    Private Sub InnerTextButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InnerTextButton.Click
        Dim HeadElem As HtmlElement = WebBrowser1.Document.GetElementsByTagName("HEAD")(0)
        Dim ScriptElem As HtmlElement = WebBrowser1.Document.CreateElement("SCRIPT")
        ScriptElem.SetAttribute("innerText", "function test(name, addr) { " & _
            "window.alert('Name and address are ' + " & _
            "name + ', ' + addr); }")
        HeadElem.AppendChild(ScriptElem)
    End Sub

    Private Sub EnableAllElementsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnableAllElementsButton.Click
        Me.EnableAllElements()
    End Sub


    Private Sub GetLastModifiedDateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GetLastModifiedDateButton.Click
        Me.GetLastModifiedDate()
    End Sub

    Private Sub ResetFormsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetFormsButton.Click
        Me.ResetForms()
    End Sub

    Private Sub GetTableRowCountButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GetTableRowCountButton.Click
        Me.GetTableRowCount("table1")
    End Sub

    Private Sub FlowLayoutPanel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles FlowLayoutPanel1.Paint

    End Sub

    Private Sub DisplayMetaButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DisplayMetaButton.Click
        Me.DisplayMetaDescription()
    End Sub

    Private Sub GetImgUrlsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GetImgUrlsButton.Click
        Dim Urls As String() = Me.GetImageUrls()
    End Sub


    Private Sub InvokeTestMethodButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InvokeTestMethodButton.Click
        Me.InvokeTestMethod("Jay", "Somewhere")
    End Sub

    Private Sub WriteNewDocumentButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WriteNewDocumentButton.Click
        Me.WriteNewDocument()
    End Sub

    Private Sub InvokeScriptButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InvokeScriptButton.Click
        Me.InvokeScript()
    End Sub

    Private Sub AppendTextButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AppendTextButton.Click
        Me.AppendText("Dynamic Text")
    End Sub

    Private Sub ExportUrlsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportUrlsButton.Click
        Me.ExportDocumentLink()
    End Sub
End Class