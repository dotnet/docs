'<Snippet1>
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Public NotInheritable Class Form1
    Inherits System.Windows.Forms.Form

    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel

    <System.STAThread()> _
    Public Shared Sub Main()
        System.Windows.Forms.Application.Run(New Form1)
    End Sub 'Main

    Public Sub New()
        MyBase.New()


        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel

        ' Configure the LinkLabel's size and location. Specify that the
        ' size should be automatically determined by the content.
        Me.linkLabel1.Location = New System.Drawing.Point(34, 56) 
        Me.linkLabel1.Size = New System.Drawing.Size(224, 16) 
        Me.linkLabel1.AutoSize = True 

        ' Configure the appearance.
        ' Set the DisabledLinkColor so that a disabled link will show up against the form's background.
        Me.linkLabel1.DisabledLinkColor = System.Drawing.Color.Red 
        Me.linkLabel1.VisitedLinkColor = System.Drawing.Color.Blue 
        Me.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline 
        Me.linkLabel1.LinkColor = System.Drawing.Color.Navy 
        
        Me.linkLabel1.TabIndex = 0 
        Me.linkLabel1.TabStop = True 
        
        ' Identify what the first Link is.
        Me.linkLabel1.LinkArea = New System.Windows.Forms.LinkArea(0, 8)

        ' Identify that the first link is visited already.
        Me.linkLabel1.Links(0).Visited = true
        
        ' Set the Text property to a string.
        Me.linkLabel1.Text = "Register Online.  Visit Microsoft.  Visit MSN."

        ' Create new links using the Add method of the LinkCollection class.
        ' Underline the appropriate words in the LinkLabel's Text property.
        ' The words 'Register', 'Microsoft', and 'MSN' will 
        ' all be underlined and behave as hyperlinks.

        ' First check that the Text property is long enough to accommodate
        ' the desired hyperlinked areas.  If it's not, don't add hyperlinks.
        If Me.LinkLabel1.Text.Length >= 45 Then
            Me.LinkLabel1.Links(0).LinkData = "Register"
            Me.LinkLabel1.Links.Add(24, 9, "www.microsoft.com")
            Me.LinkLabel1.Links.Add(42, 3, "www.msn.com")
            ' The second link is disabled and will appear as red.
            Me.linkLabel1.Links(1).Enabled = False
        End If

        ' Set up how the form should be displayed and adds the controls to the form.
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.LinkLabel1})
        Me.Text = "Link Label Example"
    End Sub

    Private Sub linkLabel1_LinkClicked(ByVal sender As Object, _
                ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

        ' Determine which link was clicked within the LinkLabel.
        Me.LinkLabel1.Links(LinkLabel1.Links.IndexOf(e.Link)).Visited = True

        ' Displays the appropriate link based on the value of the LinkData property of the Link object.
        Dim target As String = CType(e.Link.LinkData, String)

        ' If the value looks like a URL, navigate to it.
        ' Otherwise, display it in a message box.
        If (target IsNot Nothing) AndAlso (target.StartsWith("www")) Then
            System.Diagnostics.Process.Start(target)
        Else
            MessageBox.Show(("Item clicked: " + target))
        End If

    End Sub

End Class
'</Snippet1>
