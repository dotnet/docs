
#Region "Using directives"

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms


#End Region


Class Form1
    Inherits Form

    Public Sub New()

        'InitializeHotTrackingListView()
        'InitializeListViewWithBackgroundImage()
        InitializeFindNearestItemListView()
        'InitializeFindListView()
        InitializeListView1()
        listView1.Items.Add(New ListViewItem("One item"))
        listView1.Items.Add(New ListViewItem("two items"))
        InitializeComponent()

    End Sub

    ' The following code example demonstrates handling the ColumnWidthChanging event. It
    ' also demonstrates the NewWidth and Cancel members.  To run this example paste the code
    ' into a Windows Form. Call InitializeListView1 from the form's constructor or load-event
    ' handling method. 
    '<snippet6>
    Private WithEvents listView1 As New ListView()

    Private Sub InitializeListView1()

        ' Initialize a ListView in detail view and add some columns.
        listView1.View = View.Details
        listView1.Width = 200
        listView1.Columns.Add("Column1")
        listView1.Columns.Add("Column2")
        Me.Controls.Add(listView1)

    End Sub


    ' Handle the ColumnWidthChangingEvent.
    Private Sub listView1_ColumnWidthChanging(ByVal sender As Object, _
        ByVal e As ColumnWidthChangingEventArgs) _
        Handles listView1.ColumnWidthChanging

        ' Check if the new width is too big or too small.
        If e.NewWidth > 100 OrElse e.NewWidth < 5 Then

            ' Cancel the event and inform the user if the new
            ' width does not meet the criteria.
            MessageBox.Show("Column width is too large or too small")
            e.Cancel = True
        End If

    End Sub
    '</snippet6>

#Region "snippet3"

    '<snippet3>
    ' Declare the ListView and Button for the example.
    Private findListView As New ListView()
    Private WithEvents findButton As New Button()


    Private Sub InitializeFindListView()

        ' Set up the location and event handling for the button.
        findButton.Location = New Point(10, 10)

        ' Set up the location of the ListView and add some items.
        findListView.Location = New Point(10, 30)
        findListView.Items.Add(New ListViewItem("angle bracket"))
        findListView.Items.Add(New ListViewItem("bracket holder"))
        findListView.Items.Add(New ListViewItem("bracket"))

        ' Add the button and ListView to the form.
        Me.Controls.Add(findButton)
        Me.Controls.Add(findListView)

    End Sub

    Private Sub findButton_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles findButton.Click

        ' Call FindItemWithText, sending output to MessageBox.
        Dim item1 As ListViewItem = findListView.FindItemWithText("brack")
        If (item1 IsNot Nothing) Then
            MessageBox.Show("Calling FindItemWithText passing 'brack': " _
                & item1.ToString())
        Else
            MessageBox.Show("Calling FindItemWithText passing 'brack': null")
        End If

    End Sub
    '</snippet3>
#End Region

    'This method is for testing purposes only.
    'void findButton_Click(object sender, EventArgs e)
    '{
    '    Console.WriteLine("findListView contains: ");
    '    foreach (ListViewItem item in findListView.Items)
    '        Console.WriteLine(item.ToString());
    '    ListViewItem item1 = findListView.FindItemWithText("brack");
    '    Console.WriteLine("Call FindItemWithText('brack')");
    '    if (item1 != null) 
    '        Console.WriteLine(item1.ToString());
    '    else Console.WriteLine("null");
    '    ListViewItem item2 = findListView.FindItemWithText("brack", true, 0);
    '    Console.WriteLine("Call FindItemWithText('brack', true, 0)");
    '    if (item2 != null) 
    '        Console.WriteLine(item2.ToString());
    '    else Console.WriteLine("null");
    '    ListViewItem item3 = findListView.FindItemWithText("brack", true, 0, false);
    '    Console.WriteLine("Call FindItemWithText('brack', true, 0, false)");
    '    if (item3 != null)
    '        Console.WriteLine(item3.ToString());
    '    else Console.WriteLine("null");
    '    ListViewItem item4 = findListView.FindItemWithText("brack", true, 0, true);
    '    Console.WriteLine("Call FindItemWithText('brack', true, 0, true)");
    '    if (item4 != null)
    '        Console.WriteLine(item4.ToString());
    '    else Console.WriteLine("null");
    '}

#Region "snippet2"
    ' The following code example demonstrates a ListView with hot tracking enabled.
    ' To run this example paste the following code into a Windows Form and and call
    ' the InitializeHotTrackingListView method from the form's constructor or load-event
    ' handling method.
    '<snippet2>
    Private list As New ImageList()
    Private hotTrackinglistView As New ListView()


    Private Sub InitializeHotTrackingListView()
        list.Images.Add(New Bitmap(GetType(Button), "Button.bmp"))
        hotTrackinglistView.SmallImageList = list
        hotTrackinglistView.Location = New Point(20, 20)
        hotTrackinglistView.View = View.SmallIcon
        Dim listItem1 As New ListViewItem("Short", 0)
        Dim listItem2 As New ListViewItem("Tiny", 0)
        hotTrackinglistView.Items.Add(listItem1)
        hotTrackinglistView.Items.Add(listItem2)
        hotTrackinglistView.HotTracking = True
        Me.Controls.Add(hotTrackinglistView)

    End Sub
    '</snippet2>
#End Region

#Region "snippet1"
    ' The following code example demonstrates initializing a ListView in detail view and
    ' automatically resizing the columns using the AutoResizeColumn method. 
    ' To run this example, paste this code into a  Windows Form and call
    ' the InitializeResizingListView method from the form's constructor or load-event
    ' handling method.
    '<snippet1>
    Private resizingListView As New ListView()
    Private WithEvents button1 As New Button()


    Private Sub InitializeResizingListView()
        ' Set location and text for button.
        button1.Location = New Point(100, 15)
        button1.Text = "Resize"
        AddHandler button1.Click, AddressOf button1_Click

        ' Set the ListView to details view.
        resizingListView.View = View.Details

        'Set size, location and populate the ListView.
        resizingListView.Size = New Size(200, 100)
        resizingListView.Location = New Point(40, 40)
        resizingListView.Columns.Add("HeaderSize")
        resizingListView.Columns.Add("ColumnContent")
        Dim listItem1 As New ListViewItem("Short")
        Dim listItem2 As New ListViewItem("Tiny")
        listItem1.SubItems.Add(New ListViewItem.ListViewSubItem(listItem1, _
            "Something longer"))
        listItem2.SubItems.Add(New ListViewItem.ListViewSubItem(listItem2, _
            "Something even longer"))
        resizingListView.Items.Add(listItem1)
        resizingListView.Items.Add(listItem2)

        ' Add the ListView and the Button to the form.
        Me.Controls.Add(resizingListView)
        Me.Controls.Add(button1)

    End Sub


    Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles button1.Click

        ' Resize the first column to the header size.
        resizingListView.AutoResizeColumn(0, _
            ColumnHeaderAutoResizeStyle.HeaderSize)

        ' Resize the second column to the column content.
        resizingListView.AutoResizeColumn(1, _
            ColumnHeaderAutoResizeStyle.ColumnContent)

    End Sub
    '</snippet1>
#End Region


    ' The following code example demonstrates the use of the BackGroundImageLayout
    ' member. To run this example, paste the following
    ' code into a Windows Form and call the InitializeListViewWithBackgroundImage method
    ' from the form's constructor or load-event handling method. You must have the STAThread
    ' attribute applied to the Main method of your form.

    '<snippet4>
    Private imageListView As New ListView()

    Private Sub InitializeListViewWithBackgroundImage()

        imageListView.Location = New Point(40, 40)
        imageListView.BackgroundImageLayout = ImageLayout.Stretch
        imageListView.Items.AddRange(New ListViewItem() _
            {New ListViewItem("Yes"), New ListViewItem("No")})
        Dim bmp1 As New Bitmap("c:\FakePhoto.jpg")
        imageListView.BackgroundImage = New Bitmap(bmp1, New Size(30, 40))
        Me.Controls.Add(imageListView)

    End Sub
    '</snippet4>


#Region "snippet5"
    ' The following code example demonstrates the FindNearestItem method. 
    ' To run this example, paste the code into a Windows Form and call the
    ' InitializeFindNearestItemListView from the form's constructor or load-
    ' event handling method. When the application is running, click the 
    ' ListView to see the results of calling the FindNearestItem method.
    '<snippet5>
    Private WithEvents findNearestItemListView As New ListView()


    Private Sub InitializeFindNearestItemListView()
        findNearestItemListView.Size = New Size(200, 100)
        Dim buttonImage As New Bitmap(GetType(Button), "Button.bmp")
        Dim list As New ImageList()
        findNearestItemListView.LargeImageList = list

        list.Images.Add(buttonImage)
        findNearestItemListView.Items.Add(New ListViewItem("Click", 0))
        findNearestItemListView.Items.Add(New ListViewItem("OK", 0))
        findNearestItemListView.Items.Add(New ListViewItem("Cancel", 0))
        findNearestItemListView.Items.Add(New ListViewItem("Exit", 0))
        findNearestItemListView.Items.Add(New ListViewItem("Help", 0))
        Me.Controls.Add(findNearestItemListView)
    End Sub



    Private Sub findNearestItemListView_MouseClick(ByVal sender As Object, _
        ByVal e As MouseEventArgs) Handles findNearestItemListView.MouseClick

        Dim foundItem As ListViewItem = _
            findNearestItemListView.FindNearestItem(SearchDirectionHint.Right, _
            New Point(e.X, e.Y))
        If (foundItem IsNot Nothing) Then
            MessageBox.Show(foundItem.Text)
        Else
            MessageBox.Show("Did not find an item")
        End If

    End Sub
    '</snippet5>
#End Region
    <STAThread()> _
    Public Shared Sub Main()
        Application.EnableVisualStyles()
        Application.Run(New Form1())

    End Sub 'Main


    Private Sub InitializeComponent()

        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Name = "Form1"

    End Sub 'InitializeComponent

    ' The following example demonstrates handling the ItemSelectionChanged event.

    '<snippet8>
    Private Sub listView1_ItemSelectionChanged(ByVal sender As Object, _
        ByVal e As ListViewItemSelectionChangedEventArgs) _
        Handles listView1.ItemSelectionChanged

        MessageBox.Show("Selection changed to " & e.Item.ToString())

    End Sub

    '</snippet8>


    ' The following example demonstrates using the HitTest method to determine
    ' the location of a MouseDown in a ListView. To run this code paste it into
    ' a Windows Form that contains a ListView named listView1 that is populated with
    ' items.  Associate the MouseDown event for the form and listView1
    ' the HandleMouseDown method in this example.
    '<snippet7>
    Private Sub HandleMouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) _
            Handles Me.MouseDown, listView1.MouseDown

        Dim info As ListViewHitTestInfo = listView1.HitTest(e.X, e.Y)
        MessageBox.Show(info.Location.ToString())

    End Sub
    '</snippet7>

    '<snippet9>
    Private resizingListView2 As New ListView()
    Private WithEvents resizeButton As New Button()
    
    
    Private Sub InitializeResizingListView2() 

        ' Set location and text for button.
        resizeButton.Location = New Point(100, 15)
        resizeButton.Text = "Resize"

        ' Set the ListView to details view.
        resizingListView2.View = View.Details
        
        'Set size, location and populate the ListView.
        resizingListView2.Size = New Size(200, 100)
        resizingListView2.Location = New Point(40, 40)
        resizingListView2.Columns.Add("HeaderSize")
        resizingListView2.Columns.Add("ColumnContent")
        Dim listItem1 As New ListViewItem("Short")
        Dim listItem2 As New ListViewItem("Tiny")
        listItem1.SubItems.Add(New ListViewItem.ListViewSubItem(listItem1, _
            "Something longer"))
        listItem2.SubItems.Add(New ListViewItem.ListViewSubItem(listItem2, _
            "Something even longer"))
        resizingListView2.Items.Add(listItem1)
        resizingListView2.Items.Add(listItem2)
        
        ' Add the ListView and the Button to the form.
        Me.Controls.Add(resizingListView2)
        Me.Controls.Add(resizeButton)
    
    End Sub
    
    Private Sub resizeButton_Click(ByVal sender As Object, _
        ByVal e As EventArgs) Handles resizeButton.Click

        resizingListView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
    End Sub
'</snippet9>

End Class

