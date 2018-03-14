<System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "
    
    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If (components IsNot Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerNonUserCode()> Private Sub InitializeComponent()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser
        Me.SuspendLayout()
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser1.Location = New System.Drawing.Point(0, 0)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(661, 284)
        Me.WebBrowser1.TabIndex = 0
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(661, 284)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend Shared Readonly Property GetInstance as Form1
        Get
        	if m_DefaultInstance is nothing OrElse m_DefaultInstance.IsDisposed() Then
				SyncLock m_SyncObject
					if m_DefaultInstance is nothing OrElse m_DefaultInstance.IsDisposed() Then
						m_DefaultInstance = new Form1
					end if
				End SyncLock
			End If
			return m_DefaultInstance
        End Get
    End Property

    Private Shared m_DefaultInstance as Form1
    Private Shared m_SyncObject as new Object
#End Region

    ' <SNIPPET1>
    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        Dim Doc As HtmlDocument = WebBrowser1.Document

        AddHandler Doc.MouseDown, New HtmlElementEventHandler(AddressOf Document_MouseDown)
        AddHandler Doc.MouseMove, New HtmlElementEventHandler(AddressOf Document_MouseMove)
        AddHandler Doc.MouseUp, New HtmlElementEventHandler(AddressOf Document_MouseUp)
    End Sub

    Private Sub Document_MouseDown(ByVal sender As Object, ByVal e As HtmlElementEventArgs)
        ' Insert your code here.
    End Sub

    Private Sub Document_MouseMove(ByVal sender As Object, ByVal e As HtmlElementEventArgs)
        ' Insert your code here.
    End Sub

    Private Sub Document_MouseUp(ByVal sender As Object, ByVal e As HtmlElementEventArgs)
        ' Insert your code here.
    End Sub
    '</SNIPPET1>
End Class
