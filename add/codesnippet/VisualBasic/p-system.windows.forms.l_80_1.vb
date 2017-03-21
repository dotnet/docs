
    ' Declare the LinkLabel object.
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel

    ' Declare keywords array to identify links
    Dim keywords() As String

    Private Sub InitializeLinkLabel()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.LinkLabel1.Links.Clear()
        ' Set the location, name and size.
        Me.LinkLabel1.Location = New System.Drawing.Point(10, 20)
        Me.LinkLabel1.Name = "CompanyLinks"
        Me.LinkLabel1.Size = New System.Drawing.Size(104, 150)

        ' Set the LinkBehavior property to show underline when mouse
        ' hovers over the links.
        Me.LinkLabel1.LinkBehavior = _
            System.Windows.Forms.LinkBehavior.HoverUnderline
        Dim textString As String = "For more information see our" & _
           " company website or the research page at Contoso Ltd. "

        ' Set the text property.
        Me.LinkLabel1.Text = textString

        ' Set the color of the links to black, unless the mouse
        ' is hovering over a link.
        Me.LinkLabel1.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel1.ActiveLinkColor = System.Drawing.Color.Blue

        ' Add links to the LinkCollection using starting index and
        ' length of keywords.
        keywords = New String() {"company", "research"}
        Dim keyword As String
        For Each keyword In keywords
            Me.LinkLabel1.Links.Add(textString.IndexOf(keyword), keyword.Length)
        Next

        ' Add the label to the form.
        Me.Controls.Add(Me.LinkLabel1)
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As Object, _
        ByVal e As LinkLabelLinkClickedEventArgs) _
        Handles LinkLabel1.LinkClicked

        Dim url As String

        ' Determine which link was clicked and set the appropriate url.
        Select Case LinkLabel1.Links.IndexOf(e.Link)
            Case 0
                url = "www.microsoft.com"

            Case 1
                url = "www.contoso.com/research"
        End Select

        ' Set the visited property to True. This will change
        ' the color of the link.
        e.Link.Visited = True

        ' Open Internet Explorer to the correct url.
        System.Diagnostics.Process.Start("IExplore.exe", url)
    End Sub