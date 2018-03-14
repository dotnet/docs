Imports System.Net

Public Class Form1

    Private Sub PrintDOMButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintDOMButton.Click
        PrintDomBegin()
    End Sub

    '<SNIPPET1>
    Private Sub PrintDomBegin()
        If (WebBrowser1.Document IsNot Nothing) Then
            Dim ElemColl As HtmlElementCollection

            Dim Doc As HtmlDocument = WebBrowser1.Document
            If (Not (Doc Is Nothing)) Then
                ElemColl = Doc.GetElementsByTagName("HTML")
                Dim Str As String = PrintDom(ElemColl, New System.Text.StringBuilder(), 0)

                WebBrowser1.DocumentText = Str
            End If
        End If
    End Sub

    Private Function PrintDom(ByVal ElemColl As HtmlElementCollection, ByRef ReturnStr As System.Text.StringBuilder, ByVal Depth As Integer) As String
        Dim Str As New System.Text.StringBuilder()

        For Each Elem As HtmlElement In ElemColl
            Dim ElemName As String

            ElemName = Elem.GetAttribute("ID")
            If (ElemName Is Nothing Or ElemName.Length = 0) Then
                ElemName = Elem.GetAttribute("name")
                If (ElemName Is Nothing Or ElemName.Length = 0) Then
                    ElemName = "<no name>"
                End If
            End If

            Str.Append(CChar(" "), Depth * 4)
            Str.Append(ElemName & ": " & Elem.TagName & "(Level " & Depth & ")")
            ReturnStr.AppendLine(Str.ToString())

            If (Elem.CanHaveChildren) Then
                PrintDom(Elem.Children, ReturnStr, Depth + 1)
            End If

            Str.Remove(0, Str.Length)
        Next

        PrintDom = ReturnStr.ToString()
    End Function
    '</SNIPPET1>

    Private Sub EnableElementMoveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnableElementMoveButton.Click

    End Sub

    '<SNIPPET2>
    Dim WithEvents Doc As HtmlDocument
    Dim MoveElement As HtmlElement

    Private Sub EnableElementMove()
        If (WebBrowser1 IsNot Nothing) Then
            Doc = WebBrowser1.Document
        End If
    End Sub

    Private Sub Document_Click(ByVal sender As Object, ByVal args As HtmlElementEventArgs) Handles Doc.Click
        If (MoveElement Is Nothing) Then
            MoveElement = WebBrowser1.Document.GetElementFromPoint(args.ClientMousePosition)
        Else
            With WebBrowser1.Document
                Dim TargetElement As HtmlElement = .GetElementFromPoint(args.ClientMousePosition)
                If (TargetElement.CanHaveChildren) Then

                    TargetElement.AppendChild(MoveElement)
                    MoveElement = Nothing
                End If
            End With
        End If
    End Sub
    '</SNIPPET2>

    Private Sub EnableEditingButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnableEditingButton.Click
        EnableEditing()
    End Sub

    '<SNIPPET3>
    Private Sub EnableEditing()
        Dim Elem As HtmlElement = WebBrowser1.Document.GetElementById("div1")
        If (Not Elem Is Nothing) Then
            If (Elem.ClientRectangle.Width < 200) Then
                Elem.SetAttribute("width", "200px")
            End If

            If (Elem.ClientRectangle.Height < 50) Then
                Elem.SetAttribute("height", "50px")
            End If

            Elem.SetAttribute("contentEditable", "true")
            Elem.Focus()
        End If
    End Sub
    '</SNIPPET3>

    '<SNIPPET4>
    Private Sub CreateHyperlinkFromSelection()
        If (WebBrowser1.Document IsNot Nothing) Then
            Dim IDoc As mshtml.IHTMLDocument2 = WebBrowser1.Document.DomDocument

            If (Not (IDoc Is Nothing)) Then
                Dim ISelect As mshtml.IHTMLSelectionObject = IDoc.selection
                If (ISelect Is Nothing) Then
                    MsgBox("Please select some text before using this command.")
                    Exit Sub
                End If

                Dim TxtRange As mshtml.IHTMLTxtRange = ISelect.createRange()

                ' Create the link.
                If (TxtRange.queryCommandEnabled("CreateLink")) Then
                    TxtRange.execCommand("CreateLink", True)
                End If
            End If
        End If
    End Sub
    '</SNIPPET4>


    Private Sub CreateHTMLMenuButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateHTMLMenuButton.Click
        CreateHTMLMenu()
    End Sub

    '<SNIPPET5>
    Private Sub CreateHtmlMenu()
        Dim Elem As HtmlElement = WebBrowser1.Document.GetElementById("div1")

        Dim HtmlMenu As String = "<DIV id=""menu1"" style=""width:200px;position:absolute;"">"
        HtmlMenu &= "<DIV id=""menu1_1"" style=""background:#999999;color:white;font-weight:bold;"">"
        HtmlMenu &= "<SPAN id=""menu1_0_cue"" style=""border-style:solid;border-width:1px;color:white;background:999999;"">+</SPAN>First Level<BR>"
        HtmlMenu &= "<DIV id=""menu1_1_0"" style=""margin-left:20px;color:white;font-weight:normal;display:none;"">"
        HtmlMenu &= "<DIV id=""menu1_1_1"" style=""margin-left:20px;color:white;"">First Sub-Level</DIV>" & vbCrLf
        HtmlMenu &= "<DIV id=""menu1_1_2"" style=""margin-left:20px;color:white;"">Second Sub-Level</DIV>" & vbCrLf
        HtmlMenu &= "</DIV></DIV>"

        HtmlMenu &= "</DIV>"

        Elem.InnerHtml = HtmlMenu

        ' Retrieve the menu cues and hook up an event handler for expanding and collapsing display of the
        ' child elements.  
        For Each MenuCueElem As HtmlElement In Elem.GetElementsByTagName("SPAN")
            If MenuCueElem.Id.EndsWith("cue") Then
                AddHandler MenuCueElem.Click, New HtmlElementEventHandler(AddressOf Me.Element_Click)
            End If
        Next
    End Sub

    Private Sub Element_Click(ByVal sender As Object, ByVal e As HtmlElementEventArgs)
        ' !TODO: Need SetStyle() implemented per DCR. 
    End Sub
    '</SNIPPET5>

    Private Sub GetOffsetsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GetOffsetsButton.Click
        GetOffsets()
    End Sub

    '<SNIPPET6>
    Private Sub GetOffsets()
        Dim Str As String = ""
        Dim Doc As HtmlDocument = WebBrowser1.Document

        For Each Elem As HtmlElement In Doc.GetElementsByTagName("SPAN")
            Str &= "OffsetParent for " & Elem.Id & " is " & Elem.OffsetParent.Id
            Str &= "; OffsetRectangle is " & Elem.OffsetRectangle.ToString() & vbCrLf
        Next

        MessageBox.Show(Str)
    End Sub
    '</SNIPPET6>

    Private Sub AddURLToTooltipButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddURLToTooltipButton.Click
        AddUrlToTooltip()
    End Sub

    '<SNIPPET7>
    Private Sub AddUrlToTooltip()
        If (WebBrowser1.Document IsNot Nothing) Then
            With WebBrowser1.Document
                For Each Elem As HtmlElement In .GetElementsByTagName("IMG")
                    If (Elem.Parent.TagName.Equals("A")) Then
                        Dim AltStr As String = Elem.GetAttribute("ALT")
                        If (Not (AltStr Is Nothing) And (AltStr.Length <> 0)) Then
                            Elem.SetAttribute("ALT", AltStr & " - points to " & Elem.Parent.GetAttribute("HREF"))
                        Else
                            Elem.SetAttribute("ALT", "Points to " & Elem.Parent.GetAttribute("HREF"))
                        End If
                    End If
                Next
            End With
        End If
    End Sub
    '</SNIPPET7>

    Private Sub AddlinkToPageButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddlinkToPageButton.Click
        AddLinkToPage("http://www.adatum.com/")
    End Sub

    '<SNIPPET8>
    Private Sub AddLinkToPage(ByVal url As String)
        If (WebBrowser1.Document IsNot Nothing) Then
            With WebBrowser1.Document
                Dim Elem As HtmlElement = .CreateElement("A")
                Elem.SetAttribute("HREF", url)
                Elem.InnerText = "Visit our web site for more details."

                .Body.AppendChild(Elem)
            End With
        End If
    End Sub
    '</SNIPPET8>

    Private Sub AddDIVMessageButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddDIVMessageButton.Click
        AddDivMessage()
    End Sub

    '<SNIPPET9>
    Private Sub AddDivMessage()
        Dim CurrentUri As New Uri(WebBrowser1.Url.ToString())
        Dim HostName As String

        ' Ensure we have a host name, and not just an IP, against which to test.
        If (Not CurrentUri.HostNameType = UriHostNameType.Dns) Then
            Dim Permit As New DnsPermission(System.Security.Permissions.PermissionState.Unrestricted)
            Permit.Assert()

            Dim HostEntry As IPHostEntry = System.Net.Dns.GetHostEntry(CurrentUri.Host)
            HostName = HostEntry.HostName
        Else
            HostName = CurrentUri.Host
        End If

        If (Not HostName.Contains("adatum.com")) Then
            AddTopPageMessage("You are viewing a web site other than ADatum.com. " & _
                "Please exercise caution, and ensure your web surfing complies with all " & _
                "corporate regulations as laid out in the company handbook.")
        End If
    End Sub

    Private Sub AddTopPageMessage(ByVal Message As String)
        If (WebBrowser1.Document IsNot Nothing) Then
            With WebBrowser1.Document
                ' Do not insert the warning again if it already exists. 
                Dim ReturnedElems As HtmlElementCollection = .All.GetElementsByName("ADatumWarningDiv")
                If (Not (ReturnedElems Is Nothing) And (ReturnedElems.Count > 0)) Then
                    Exit Sub
                End If

                Dim DivElem As HtmlElement = .CreateElement("DIV")
                DivElem.Name = "ADatumWarningDiv"
                DivElem.Style = "background-color:black;color:white;font-weight:bold;width:100%;"
                DivElem.InnerText = Message

                DivElem = .Body.InsertAdjacentElement(HtmlElementInsertionOrientation.AfterBegin, DivElem)
            End With
        End If
    End Sub
    '</SNIPPET9>

    Private Sub HandleFormSubmitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HandleFormSubmitButton.Click
        SubmitForm("form1")
    End Sub

    '<SNIPPET10>
    Private Sub SubmitForm(ByVal FormName As String)
        Dim Elems As HtmlElementCollection
        Dim Elem As HtmlElement

        If (WebBrowser1.Document IsNot Nothing) Then
            With WebBrowser1.Document
                Elems = .All.GetElementsByName(FormName)
                If (Not Elems Is Nothing And Elems.Count > 0) Then
                    Elem = Elems(0)
                    If (Elem.TagName.Equals("FORM")) Then
                        Elem.InvokeMember("Submit")
                    End If
                End If
            End With
        End If
    End Sub
    '</SNIPPET10>


    Private Sub ShiftRowsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShiftRowsButton.Click
        ShiftRows("dataTable")
    End Sub

    '<SNIPPET11>
    Private Sub ShiftRows(ByVal TableName As String)
        If (WebBrowser1.Document IsNot Nothing) Then
            With WebBrowser1.Document
                Dim Elems As HtmlElementCollection = .All.GetElementsByName(TableName)
                If (Not Elems Is Nothing And Elems.Count > 0) Then
                    Dim Elem As HtmlElement = Elems(0)

                    ' Prepare the arguments.
                    Dim Args(2) As Object
                    Args(0) = CObj("-1")
                    Args(1) = CObj("0")

                    Elem.InvokeMember("moveRow", Args)
                End If
            End With
        End If
    End Sub
    '</SNIPPET11>


    Private Sub ScrollToElementButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScrollToElementButton.Click
        ScrollToElement("orderDetails")
    End Sub

    '<SNIPPET12>
    Private Sub ScrollToElement(ByVal ElemName As String)
        If (WebBrowser1.Document IsNot Nothing) Then
            With WebBrowser1.Document
                Dim Elems As HtmlElementCollection = .All.GetElementsByName(ElemName)
                If (Not Elems Is Nothing And Elems.Count > 0) Then
                    Dim Elem As HtmlElement = Elems(0)

                    Elem.ScrollIntoView(True)
                End If
            End With
        End If
    End Sub
    '</SNIPPET12>

    Private Sub InsertImageFooterButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InsertImageFooterButton.Click
        InsertImageFooter()
    End Sub

    '<SNIPPET13>
    Private Sub InsertImageFooter()
        If (WebBrowser1.Document IsNot Nothing) Then
            With WebBrowser1.Document
                Dim Elem As HtmlElement = .CreateElement("IMG")
                Elem.SetAttribute("SRC", "http://www.adatum.com/images/footer-banner.jpg")

                .Body.AppendChild(Elem)
            End With
        End If
    End Sub
    '</SNIPPET13>


    Private Sub HandleBodyErrorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HandleBodyErrorButton.Click
        SetBody()
    End Sub

    '<SNIPPET14>
    Dim WithEvents BodyElement As HtmlElement

    Private Sub SetBody()
        If (WebBrowser1.Document IsNot Nothing) Then
            BodyElement = WebBrowser1.Document.Body
        End If
    End Sub

    'Private Sub HandleError(ByVal sender As Object, ByVal e As HtmlElementEventArgs) Handles BodyElement.Error
    '     System.Diagnostics.EventLog.WriteEntry("Custom Application", "Scripting error occurred: " & _
    '      e.
    'End Sub
    '</SNIPPET14>


    Private Sub HandleFormFocusButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HandleFormFocusButton.Click
        HandleFormFocus()
    End Sub

    '<SNIPPET15>
    Dim WithEvents TargetFormElement As HtmlElement

    Private Sub HandleFormFocus()
        If (WebBrowser1.Document IsNot Nothing) Then
            With WebBrowser1.Document
                If (.Forms.Count > 0) Then
                    Dim TargetForm As HtmlElement = .Forms(0)
                    Dim SearchCollection As HtmlElementCollection = TargetForm.All.GetElementsByName("text1")
                    If (SearchCollection.Count = 1) Then
                        TargetFormElement = SearchCollection(0)
                    End If
                End If
            End With
        End If
    End Sub

    Private Sub TargetFormElement_Focus(ByVal sender As Object, ByVal e As HtmlElementEventArgs)
        Dim TextElement As HtmlElement = e.FromElement
        Dim ElementText As String = TextElement.GetAttribute("value")

        ' Check that this value is at least five characters long.
        If (ElementText.Length < 5) Then
            e.ReturnValue = True
            MessageBox.Show("The entry in the current field must be at least five characters long.")
        End If
    End Sub
    '</SNIPPET15>

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        AttachCopyHandler()
    End Sub


    '<SNIPPET16>
    Private Sub AttachCopyHandler()
        If (WebBrowser1.Document IsNot Nothing) Then
            Dim Div As HtmlElement = WebBrowser1.Document.GetElementById("Div1")
            Div.AttachEventHandler("oncopy", New EventHandler(AddressOf HtmlElement_OnCopy))
        End If
    End Sub

    Private Sub HtmlElement_OnCopy(ByVal sender As Object, ByVal e As EventArgs)
        BrowserStatus.Text = "Selection copied. Selection is: " & Clipboard.GetText()
    End Sub
    '</SNIPPET16>

    Private Sub FlowLayoutPanel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles FlowLayoutPanel1.Paint

    End Sub
End Class