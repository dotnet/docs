Public Class Form1

    Private Sub GetLinksFromFramesButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GetLinksFromFramesButton.Click
        Me.GetLinksFromFrames()
    End Sub

    '<SNIPPET2>
    Dim LinksTable As Hashtable

    Private Sub GetLinksFromFrames()
        LinksTable = New Hashtable()
        Dim FrameUrl As String

        If (WebBrowser1.Document IsNot Nothing) Then
            With WebBrowser1.Document
                Dim CurrentWindow As HtmlWindow = .Window
                If (CurrentWindow.Frames.Count > 0) Then
                    For Each Frame As HtmlWindow In CurrentWindow.Frames
                        FrameUrl = Frame.Url.ToString()
                        Dim FrameLinksHash As New Hashtable()
                        LinksTable.Add(FrameUrl, FrameLinksHash)

                        For Each HrefElement As HtmlElement In Frame.Document.Links
                            FrameLinksHash.Add(HrefElement.GetAttribute("HREF"), "Url")
                        Next
                    Next
                Else
                    Dim DocLinksHash As New Hashtable()
                    LinksTable.Add(.Url.ToString(), DocLinksHash)

                    For Each HrefElement As HtmlElement In .Links
                        DocLinksHash.Add(HrefElement.GetAttribute("HREF"), "Url")
                    Next
                End If
            End With
        End If
    End Sub
    '</SNIPPET2>

    Private Sub ShowModalDialogButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowModalDialogButton.Click
        Me.ShowModalDialog()
    End Sub

    '<SNIPPET3>
    Private Sub ShowModalDialog()
        If (WebBrowser1.Document IsNot Nothing) Then
            Dim Frame As HtmlWindow = WebBrowser1.Document.Window

            Dim DialogArguments As String = "dialogHeight: 250px; dialogWidth: 300px; dialogTop: 300px;" & _
                "dialogLeft: 300px; edge: Sunken; center: Yes; help: Yes; resizable: No; status: No;"

            ' Show the dialog.
            Dim RawWindow As mshtml.IHTMLWindow2 = Frame.DomWindow
            RawWindow.showModalDialog("http://www.adatum.com/dialogWindow.htm", Nothing, CObj(DialogArguments))
        End If
    End Sub
    '</SNIPPET3>


    Private Sub OpenNewWindowOverBrowserButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenNewWindowOverBrowserButton.Click
        Me.OpenNewWindowOverBrowser()
    End Sub

    '<SNIPPET4>
    'Private Sub TestCookies()
    '    If (WebBrowser1.Document IsNot Nothing) Then
    '        Dim Capabilities As System.Windows.Forms.HtmlNavigator = WebBrowser1.Document.Window.Navigator
    '        If (Not Capabilities.CookieEnabled) Then
    '            MessageBox.Show("You have disabled cookies in Internet Explorer. The current " & _
    '                " application will not work properly without them. See your system " & _
    '                "administrator for more details.")
    '        End If
    '    End If
    'End Sub
    '</SNIPPET4>

    '<SNIPPET5>
    Private Sub OpenNewWindowOverBrowser()
        If (WebBrowser1.Document IsNot Nothing) Then
            Dim DocWindow As HtmlWindow = WebBrowser1.Document.Window

            Dim NewWindow As HtmlWindow = DocWindow.OpenNew(New Uri("http://www.adatum.com/popup.htm"), "left=" & DocWindow.Position.X & ",top=" & DocWindow.Position.Y & ",width=" & WebBrowser1.Width & ",height=" & WebBrowser1.Height)
        End If
    End Sub
    '</SNIPPET5>


    Private Sub SetWindowStatusButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetWindowStatusButton.Click
        Me.SetWindowStatus()
    End Sub

    '<SNIPPET6>
    Dim WithEvents PopWindow As HtmlWindow

    Private Sub SetWindowStatus()
        If (WebBrowser1.Document IsNot Nothing) Then
            Dim DocWindow As HtmlWindow = WebBrowser1.Document.Window
            PopWindow = DocWindow.OpenNew(New Uri("file://C:\\testStatusBarText.htm"), "")
        End If
    End Sub

    Private Sub PopWindow_Load(ByVal sender As Object, ByVal e As HtmlElementEventArgs) Handles PopWindow.Load
        MessageBox.Show("Loaded!")
    End Sub
    '</SNIPPET6>

    Private Sub ResetFramesButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetFramesButton.Click
        Me.ResetFrames()
    End Sub

    '<SNIPPET8>
    Private Sub ResetFrames()
        If (WebBrowser1.Document IsNot Nothing) Then
            Dim FrameElement As HtmlElement
            Dim DocWindow As HtmlWindow = WebBrowser1.Document.Window

            For Each FrameWindow As HtmlWindow In DocWindow.Frames
                FrameElement = FrameWindow.WindowFrameElement
                Dim OriginalUrl As String = FrameElement.GetAttribute("SRC")

                If (Not OriginalUrl.Equals(FrameWindow.Url.ToString())) Then
                    FrameWindow.Navigate(New Uri(OriginalUrl))
                End If
            Next
        End If
    End Sub
    '</SNIPPET8>


    '<SNIPPET9>
    Dim BalanceWindow As HtmlWindow

    Private Sub BalanceWindowButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BalanceWindowButton.Click
        If (WebBrowser1.Document IsNot Nothing) Then
            With WebBrowser1.Document
                BalanceWindow = .Window.OpenNew(New Uri("http://www.adatum.com/viewBalances.aspx"), "dialogHeight: 250px; dialogWidth: 300px; " & _
                " dialogTop: 300px; dialogLeft: 300px; edge: Sunken; center: Yes; help: Yes; " & _
                "resizable: No; status: No;")

                ' Listen for activity on the document.


                WindowTimeout.Interval = 300000
                WindowTimeout.Start()
            End With
        End If
    End Sub

    Private Sub Document_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        WindowTimeout.Stop()
        WindowTimeout.Start()
    End Sub

    Private Sub WindowTimeout_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WindowTimeout.Tick
        If (Not BalanceWindow.IsClosed) Then
            BalanceWindow.Close()
            WindowTimeout.Stop()
        End If
    End Sub
    '</SNIPPET9>

    '<SNIPPET10>
    Dim OrderWindow As HtmlWindow
    Dim FormElement As HtmlElement

    Private Sub NewOrderButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewOrderButton.Click
        LoadOrderForm()
    End Sub

    Private Sub LoadOrderForm()
        If (WebBrowser1.Document IsNot Nothing) Then
            With WebBrowser1.Document
                OrderWindow = .Window.OpenNew(New Uri("file://C:\\orderForm.htm"), "")

                ' !TODO: Perform this in the load event handler!
                ' Get order form. 
                Dim ElemCollection As System.Windows.Forms.HtmlElementCollection = .All.GetElementsByName("NewOrderForm")
                If (ElemCollection.Count = 1) Then
                    FormElement = ElemCollection(0)
                    ' TODO: Resolve this. 
                    'FormElement.AttachEventHandler("onsubmit", New HtmlElementEventHandler(AddressOf Form_Submit))
                End If
            End With

        End If
    End Sub

    Private Sub Form_Submit(ByVal sender As Object, ByVal e As HtmlElementEventArgs)
        Dim DoOrder As Boolean = OrderWindow.Confirm("Once you transmit this order, you cannot cancel it. Submit?")
        If (Not DoOrder) Then
            ' Cancel the submit. 
            e.ReturnValue = False
            OrderWindow.Alert("Submit cancelled.")
        End If
    End Sub
    '</SNIPPET10>


    Private Sub OpenThreeWindowsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenThreeWindowsButton.Click
        ' Me.OpenThreeWindows()
    End Sub

    ' NOTE: HtmlScreen will be ripped from build soon.
    'Private Sub OpenThreeWindows()
    '    If (WebBrowser1.Document IsNot Nothing) Then
    '        With WebBrowser1.Document
    '            Dim WindowWidth As Integer = (ScreenObj.AvailableArea.Width / 3) - 10

    '            ' Open first window.
    '            Dim FirstWindow As HtmlWindow = .Window.OpenNew("http://www.microsoft.com/", "width=" & WindowWidth & ",height=200px,top=0,left=0")
    '            .Window.OpenNew("http://www.microsoft.com/", "width=" & WindowWidth & ",height=200px,top=0,left=" & WindowWidth + 10)
    '            .Window.OpenNew("http://www.microsoft.com/", "width=" & WindowWidth & ",height=200px,top=0,left=" & ((WindowWidth * 2) + 20))
    '        End With
    '    End If
    'End Sub

    Private Sub WindowOpenOnExeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WindowOpenOnExeButton.Click
        If (WebBrowser1.Document IsNot Nothing) Then
            With WebBrowser1.Document
                .Window.Open(New Uri("http://kamikaze/printTest.exe"), "_blank", "", False)
            End With
        End If
    End Sub

    Private Sub DisplayWindow1Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DisplayWindow1Button.Click
        DisplayFirstUrl()
    End Sub

    Private Sub DisplayWindow2Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DisplayWindow2Button.Click
        DisplaySecondUrl()
    End Sub

    '<SNIPPET13>
    Private Sub DisplayFirstUrl()
        If (WebBrowser1.Document IsNot Nothing) Then
            With WebBrowser1.Document
                ' If this is called first, the window will only have a status bar.
                .Window.Open(New Uri("http://www.microsoft.com/"), "displayWindow", "status=yes,width=200,height=400", False)
            End With
        End If
    End Sub

    Private Sub DisplaySecondUrl()
        If (WebBrowser1.Document IsNot Nothing) Then
            With WebBrowser1.Document
                ' If this is called first, the window will only have an Address bar.
                .Window.Open(New Uri("http://msdn.microsoft.com/"), "displayWindow", "width=400,height=200,location=yes", False)
            End With
        End If
    End Sub
    '</SNIPPET13>


    Private Sub EnableClickScrollButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnableClickScrollButton.Click
        Me.EnableClickScroll()
    End Sub


    '<SNIPPET14>
    Dim WithEvents Doc As Windows.Forms.HtmlDocument

    Private Sub EnableClickScroll()
        If (WebBrowser1.Document IsNot Nothing) Then
            Doc = WebBrowser1.Document
        End If
    End Sub

    Private Sub TopWindow_Click(ByVal sender As Object, ByVal e As HtmlElementEventArgs) Handles Doc.Click
        Dim DocWindow As HtmlWindow = WebBrowser1.Document.Window
        DocWindow.ScrollTo(e.MousePosition.X, e.MousePosition.Y)
    End Sub
    '</SNIPPET14>



    '<SNIPPET15>
    Dim ResizableWindow As HtmlWindow

    Private Sub ResizeWindow()
        If (WebBrowser1.Document IsNot Nothing) Then
            ResizableWindow = WebBrowser1.Document.Window.OpenNew(New Uri("http://www.microsoft.com/"), "")
            ResizableWindow.ResizeTo(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height)
        End If
    End Sub
    '</SNIPPET15>

    Private Sub ResizeWindowButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResizeWindowButton.Click
        Me.ResizeWindow()
    End Sub


    Private Sub SuppressScriptErrorsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SuppressScriptErrorsButton.Click
        Me.SuppressScriptErrors()
    End Sub

    '<SNIPPET16>
    Dim WithEvents ScriptWindow As HtmlWindow

    Private Sub SuppressScriptErrors()
        If (WebBrowser1.Document IsNot Nothing) Then
            ScriptWindow = WebBrowser1.Document.Window
        End If
    End Sub

    Private Sub ScriptWindow_Error(ByVal sender As Object, ByVal e As HtmlElementErrorEventArgs) Handles ScriptWindow.Error
        MessageBox.Show("Suppressed error!")
        e.Handled = True
    End Sub
    '</SNIPPET16>


    Private Sub OpenRestrictedWindowButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenRestrictedWindowButton.Click
        ' Me.OpenRestrictedWindow()
    End Sub

    '<SNIPPET17>
    'Dim WithEvents RestrictedWindow As HtmlWindow

    'Private Sub OpenRestrictedWindow()
    '    If (WebBrowser1.Document IsNot Nothing) Then
    '        RestrictedWindow = WebBrowser1.Document.Window.OpenNew("http://www.adatum.com/", "width=300,height=300,resizable=yes")
    '    End If
    'End Sub

    'Private Sub RestrictedWindow_ResizeStart(ByVal sender As Object, ByVal e As HtmlElementEventArgs) Handles RestrictedWindow.ResizeStart
    '    e.ReturnValue = True
    'End Sub
    '</SNIPPET17>
End Class
