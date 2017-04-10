
#Region "Using directives"

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms


#End Region


Class Form1
    Inherits Form
    
    Public Sub New() 
        InitializeComponent()
        
        'InitializeTextSearchListView();
        InitializeLocationSearchListView()
    
    End Sub 'New
    
    '/ <summary>
    '/ Required designer variable.
    '/ </summary>
    Private components As System.ComponentModel.IContainer = Nothing
    
    
    '/ <summary>
    '/ Clean up any resources being used.
    '/ </summary>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean) 
        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    
    End Sub 'Dispose
    
    #Region "Windows Form Designer generated code"
    
    
    '/ <summary>
    '/ Required method for Designer support - do not modify
    '/ the contents of this method with the code editor.
    '/ </summary>
    Private Sub InitializeComponent() 
        ' 
        ' Form1
        ' 
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Name = "Form1"
        Me.Text = "Form1"
    
    End Sub 'InitializeComponent 
    
    #End Region
    
    '<snippet1>
    Private textListView As New ListView()
    Private WithEvents searchBox As New TextBox()
    
    Private Sub InitializeTextSearchListView() 
        searchBox.Location = New Point(150, 20)
        textListView.Scrollable = True
        textListView.Width = 80
        textListView.Height = 50
        
        ' Set the View to list to use the FindItemWithText method.
        textListView.View = View.List
        
        ' Populate the ListView with items.
        textListView.Items.AddRange(New ListViewItem() { _
            New ListViewItem("Amy Alberts"), _
            New ListViewItem("Amy Recker"), _
            New ListViewItem("Erin Hagens"), _
            New ListViewItem("Barry Johnson"), _
            New ListViewItem("Jay Hamlin"), _
            New ListViewItem("Brian Valentine"), _
            New ListViewItem("Brian Welker"), _
            New ListViewItem("Daniel Weisman")})

        ' Add the controls to the form.
        Me.Controls.Add(textListView)
        Me.Controls.Add(searchBox)
    
    End Sub
     
    '<snippet11>
    Private Sub searchBox_TextChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles searchBox.TextChanged

        ' Call FindItemWithText with the contents of the textbox.
        Dim foundItem As ListViewItem = _
            textListView.FindItemWithText(searchBox.Text, False, 0, True)

        If (foundItem IsNot Nothing) Then
            textListView.TopItem = foundItem
        End If

    End Sub
    '</snippet11>
    '</snippet1>

    '<snippet2>
    Private WithEvents iconListView As New ListView()
    Private previousItemBox As New TextBox()
    
    
    Private Sub InitializeLocationSearchListView()
        previousItemBox.Location = New Point(150, 20)

        ' Create an image list for the icon ListView.
        iconListView.LargeImageList = New ImageList()

        ' Add an image to the ListView large icon list.
        iconListView.LargeImageList.Images.Add(New Bitmap(GetType(Control), "Edit.bmp"))

        ' Set the view to large icon and add some items with the image
        ' in the image list.
        iconListView.View = View.SmallIcon
        iconListView.Items.AddRange(New ListViewItem() { _
            New ListViewItem("Amy Alberts", 0), _
            New ListViewItem("Amy Recker", 0), _
            New ListViewItem("Erin Hagens", 0), _
            New ListViewItem("Barry Johnson", 0), _
            New ListViewItem("Jay Hamlin", 0), _
            New ListViewItem("Brian Valentine", 0), _
            New ListViewItem("Brian Welker", 0), _
            New ListViewItem("Daniel Weisman", 0)})

        Me.Controls.Add(iconListView)
        Me.Controls.Add(previousItemBox)
    End Sub
    
    ' <snippet21>
    Sub iconListView_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) _
        Handles iconListView.MouseDown

        ' Find the next item up from where the user clicked.
        Dim foundItem As ListViewItem = _
        iconListView.FindNearestItem(SearchDirectionHint.Up, e.X, e.Y)

        ' Display the results in a textbox.
        If (foundItem IsNot Nothing) Then
            previousItemBox.Text = foundItem.Text
        Else
            previousItemBox.Text = "No item found"
        End If


    End Sub
    ' </snippet21>
    '</snippet2>

    <STAThread()>  _
    Shared Sub Main() 
        Application.EnableVisualStyles()
        Application.Run(New Form1())
    
    End Sub 'Main
End Class 'Form1 





