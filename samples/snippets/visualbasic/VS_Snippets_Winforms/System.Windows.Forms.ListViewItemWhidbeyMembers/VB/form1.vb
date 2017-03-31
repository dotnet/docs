
#Region "Using directives"

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms


#End Region


Public Class Form1
    Inherits Form
    
    Private components As IContainer
    
    
    Public Sub New() 
        InitializeComponent()
        'InitializeFindItemListView();
        'InitializeItemsWithToolTips();
        'InitializeIndentedListViewItems();
        InitializeListView1()
        AddHandler Me.Load, AddressOf Form1_Load
    
    End Sub 'New
     
    
    
    Private Sub InitializeComponent() 
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Name = "Form1"

    End Sub 'InitializeComponent
     
    <STAThread()>  _
    Public Shared Sub Main() 
        Application.EnableVisualStyles()
        Application.Run(New Form1())
    
    End Sub 'Main
    
    
    
    ' The following example demonstrates how to use the ShowItemToolTip and ToolTipText 
    ' properties. To run this example, paste the code into a Windows Form and call
    ' InitializeItemsWithToolTips from the form's constructor or Load event handling
    ' method.
    '<snippet4>
    ' Declare the ListView.
    Private ListViewWithToolTips As ListView
    
    Private Sub InitializeItemsWithToolTips() 
        
        ' Construct and set the View property of the ListView.
        ListViewWithToolTips = New ListView()
        ListViewWithToolTips.Width = 200
        ListViewWithToolTips.View = View.List
        
        ' Show item tooltips.
        ListViewWithToolTips.ShowItemToolTips = True
        
        ' Create items with a tooltip.
        Dim item1WithToolTip As New ListViewItem("Item with a tooltip")
        item1WithToolTip.ToolTipText = "This is the item tooltip."
        Dim item2WithToolTip As New ListViewItem("Second item with a tooltip")
        item2WithToolTip.ToolTipText = "A different tooltip for this item."
        
        ' Create an item without a tooltip.
        Dim itemWithoutToolTip As New ListViewItem("Item without tooltip.")
        
        ' Add the items to the ListView.
        ListViewWithToolTips.Items.AddRange(New ListViewItem() _
            {item1WithToolTip, item2WithToolTip, itemWithoutToolTip})
        
        ' Add the ListView to the form.
        Me.Controls.Add(ListViewWithToolTips)
        Me.Controls.Add(button1)
    
    End Sub
    '</snippet4>

    '<snippet2>
    Private indentedListView As ListView
    
    
    Private Sub InitializeIndentedListViewItems() 
        indentedListView = New ListView()
        indentedListView.Width = 200
        
        ' View must be set to Details to use IndentCount.
        indentedListView.View = View.Details
        indentedListView.Columns.Add("Indented Items", 150)
        
        ' Create an image list and add an image.
        Dim list As New ImageList()
        list.Images.Add(New Bitmap(GetType(Button), "Button.bmp"))
        
        ' SmallImageList must be set when using IndentCount.
        indentedListView.SmallImageList = list
        
        Dim item1 As New ListViewItem("Click", 0)
        item1.IndentCount = 1
        Dim item2 As New ListViewItem("OK", 0)
        item2.IndentCount = 2
        Dim item3 As New ListViewItem("Cancel", 0)
        item3.IndentCount = 3
        indentedListView.Items.AddRange(New ListViewItem() {item1, item2, item3})
        
        ' Add the controls to the form.
        Me.Controls.Add(indentedListView)
    
    End Sub 'InitializeIndentedListViewItems 
    '</snippet2>

    ' Declare the ListView and the Label.
    Private WithEvents findListView As ListView
    Private label1 As Label
    
    
    Private Sub InitializeFindItemListView() 
        findListView = New ListView()
        label1 = New Label()
        label1.Location = New Point(200, 20)
        
        ' View must be set to SmallIcon to use the FindNearestItem method.
        findListView.View = View.SmallIcon
        
        ' Create an image list and add items to the ListView with an image.
        Dim list As New ImageList()
        list.Images.Add(New Bitmap(GetType(Button), "Button.bmp"))
        findListView.SmallImageList = list
        findListView.Items.Add(New ListViewItem("Click", 0))
        findListView.Items.Add(New ListViewItem("OK", 0))
        findListView.Items.Add(New ListViewItem("Cancel", 0))
        
        ' Add the controls to the form.
        Me.Controls.Add(findListView)
        Me.Controls.Add(label1)
    
    End Sub
    
    
    ' The following example demonstrates how to use the FindNearestItem
    ' method.  To run this example, paste the following code into
    ' a Windows Form that contains a ListView named findListView. Ensure
    ' the View property is set to an icon view, and that the ListView 
    ' is populated with items. Associate the MouseDown event of findListView
    ' with the findListView_MouseDown method in this example.
    ' <snippet1>
    Private Sub findListView_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)


        Dim info As ListViewHitTestInfo = findListView.HitTest(e.X, e.Y)
        Dim foundItem As ListViewItem = Nothing
        If (info.Item IsNot Nothing) Then
            foundItem = info.Item.FindNearestItem(SearchDirectionHint.Up)
        End If
        If (foundItem IsNot Nothing) Then
            label1.Text = "Previous Item: " + foundItem.Text

        Else
            label1.Text = "No item found"
        End If

    End Sub
    ' </snippet1>

    ' The following code example demonstrates how to use the Position property. To run
    ' this example paste the code into a Windows Form and call InitializePositionedListView
    ' from the form's constructor or Load-event handling method. Click the button to see
    ' the Position property of moveItem change.
    '<snippet3>
    Private positionListView As ListView
    Private moveItem As ListViewItem
    Private WithEvents button1 As Button
    
    
    Private Sub InitializePositionedListViewItems() 
        ' Set some basic properties on the ListView and button.
        positionListView = New ListView()
        positionListView.Height = 200
        button1 = New Button()
        button1.Location = New Point(160, 30)
        button1.AutoSize = True
        button1.Text = "Click to reposition"

        ' View must be set to icon view to use the Position property.
        positionListView.View = View.LargeIcon
        
        ' Create the items and add them to the ListView.
        Dim item1 As New ListViewItem("Click")
        Dim item2 As New ListViewItem("OK")
        moveItem = New ListViewItem("Move")
        positionListView.Items.AddRange(New ListViewItem() _
            {item1, item2, moveItem})
        
        ' Add the controls to the form.
        Me.Controls.Add(positionListView)
        Me.Controls.Add(button1)

    End Sub
    
    Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
        moveItem.Position = New Point(30, 30)
    End Sub
    '</snippet3>
    
    ' The following code example demonstrates how to use the GetSubItemAt
    ' method.  To run this code, paste it into a Windows Form and call 
    ' InitializeListView1 from the form's constructor or Load event-handling
    ' method.
    '<snippet5>
    Private WithEvents listView1 As ListView
    
    Private Sub InitializeListView1()
        listView1 = New ListView()

        ' Set the view to details to show subitems.
        listView1.View = View.Details

        ' Add some columns and set the width.
        listView1.Columns.Add("Name")
        listView1.Columns.Add("Number")
        listView1.Columns.Add("Description")
        listView1.Width = 175

        ' Create some items and subitems; add the to the ListView.
        Dim item1 As New ListViewItem("Widget")
        item1.SubItems.Add(New ListViewItem.ListViewSubItem(item1, "14"))
        item1.SubItems.Add(New ListViewItem.ListViewSubItem(item1, "A description of Widget"))
        Dim item2 As New ListViewItem("Bracket")
        item2.SubItems.Add(New ListViewItem.ListViewSubItem(item2, "8"))
        listView1.Items.Add(item1)
        listView1.Items.Add(item2)

        ' Add the ListView to the form.
        Me.Controls.Add(listView1)
    End Sub
    
    Private Sub listView1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)


        ' Get the item at the mouse pointer.
        Dim info As ListViewHitTestInfo = listView1.HitTest(e.X, e.Y)

        Dim subItem As ListViewItem.ListViewSubItem = Nothing

        ' Get the subitem 120 pixels to the right.
        If (info IsNot Nothing) Then
            If (info.Item IsNot Nothing) Then
                subItem = info.Item.GetSubItemAt(e.X + 120, e.Y)
            End If
        End If ' Show the text of the subitem, if found.
        If (subItem IsNot Nothing) Then
            MessageBox.Show(subItem.Text)
        End If
    End Sub
    '</snippet5>

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) 
    
    End Sub
End Class






