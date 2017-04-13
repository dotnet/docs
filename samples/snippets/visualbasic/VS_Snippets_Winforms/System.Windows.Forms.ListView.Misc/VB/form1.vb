Imports System.Windows.Forms

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
Friend WithEvents ListView1 As System.Windows.Forms.ListView
Friend WithEvents Button1 As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Dim ListViewItem11 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("one")
        Dim ListViewItem12 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("two")
        Dim ListViewItem13 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("three")
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem11, ListViewItem12, ListViewItem13})
        Me.ListView1.Location = New System.Drawing.Point(15, 41)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(256, 208)
        Me.ListView1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(173, 11)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(73, 22)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ListView1)
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

    Public Shared Sub Main()
        Application.Run(New Form1())
    End Sub

    Public Sub DemonstrateSelection
        '<Snippet1>
        me.ListView1.Items(0).Focused = True
        me.ListView1.Items(0).Selected = True
        '</Snippet1>
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        DemonstrateSelection()
    End Sub

#End Region

End Class
