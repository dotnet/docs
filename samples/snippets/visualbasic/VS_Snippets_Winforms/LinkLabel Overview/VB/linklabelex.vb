Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data

Namespace ListViewOverview
    
    
    '/ <summary>
    '/		Summary description for Form1.
    '/ </summary>
    Public Class Form1
        Inherits System.Windows.Forms.Form
        '/ <summary>
        '/		Required designer variable.
        '/ </summary>
        Private components As System.ComponentModel.Container
        
        
        Public Sub New()
            '
            ' Required for Windows Form Designer support
            '
            InitializeComponent()
            
            InitializeMyLinkLabel()
        End Sub 'New
        
        '<Snippet1>
        ' Create a new LinkLabel control.
        Private linkLabel1 As New LinkLabel()
        
        
        Public Sub InitializeMyLinkLabel()
            
            ' Set the control to autosize based on the text content.
            linkLabel1.AutoSize = True
            ' Position and size the control on the form.
            linkLabel1.Location = New System.Drawing.Point(8, 16)
            linkLabel1.Size = New System.Drawing.Size(135, 13)
            ' Set the text to display in the label.
            linkLabel1.Text = "Click here to get more info."
            
            ' Create a new link using the Add method of the LinkCollection class.
            linkLabel1.Links.Add(6, 4, "www.microsoft.com")
            
            ' Create an event handler for the LinkClicked event.
            AddHandler linkLabel1.LinkClicked, AddressOf Me.linkLabel1_LinkClicked
            
            ' Add the control to the form.
            Me.Controls.Add(linkLabel1)
        End Sub 'InitializeMyLinkLabel
        
        
        Private Sub linkLabel1_LinkClicked(sender As Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
            ' Determine which link was clicked within the LinkLabel.
            linkLabel1.Links(linkLabel1.Links.IndexOf(e.Link)).Visited = True
            ' Display the appropriate link based on the value of the LinkData property of the Link object.
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString())
        End Sub 'linkLabel1_LinkClicked
        '</Snippet1>

         
        '/ <summary>
        '/		Required method for Designer support - do not modify
        '/		the contents of this method with the code editor.
        '/ </summary>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.Size = New System.Drawing.Size(300, 300)
            Me.Text = "Form1"
        End Sub 'InitializeComponent
        
        '/ <summary>
        '/ 	The main entry point for the application.
        '/ </summary>
        <STAThread()> _
        Shared Sub Main()
            Application.Run(New Form1())
        End Sub 'Main
    End Class 'Form1
End Namespace 'ListViewOverview
