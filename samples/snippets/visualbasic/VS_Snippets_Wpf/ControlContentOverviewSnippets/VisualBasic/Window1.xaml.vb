
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes
Imports System.Collections.ObjectModel


'/ <summary>
'/ Interaction logic for Window1.xaml
'/ </summary>

Class Window1
    Inherits System.Windows.Window

    Dim dataList As New MyData()

    Public Sub New()
        InitializeComponent()


        CreateButtons()
        AddFirstListBox()
        AddThirdListBox()
        ReportLBIs()


    End Sub 'New


    Sub ReportLBIs()
        '<Snippet11>
        Console.WriteLine("Items in simpleListBox:")

        For Each item As Object In simpleListBox.Items
            Console.WriteLine(item.GetType().ToString())
        Next item

        Console.WriteLine(vbCr + "Items in listBoxItemListBox:")

        For Each item As Object In listBoxItemListBox.Items
            Console.WriteLine(item.GetType().ToString())
        Next item

    End Sub 'ReportLBIs
    '</Snippet11>

    '<Snippet12>
    '
    '        Items in simpleListBox:
    '        System.String
    '        System.Windows.Shapes.Rectangle
    '        System.Windows.Controls.StackPanel
    '        System.DateTime
    '
    '        Items in listBoxItemListBox:
    '        System.Windows.Controls.ListBoxItem
    '        System.Windows.Controls.ListBoxItem
    '        System.Windows.Controls.ListBoxItem
    '        System.Windows.Controls.ListBoxItem
    '        
    '</Snippet12>
    Sub AddThirdListBox()
        '<Snippet9>
        Dim listBox1 As New ListBox()
        Dim listData As New MyData()
        Dim binding1 As New Binding()

        binding1.Source = listData
        listBox1.SetBinding(ListBox.ItemsSourceProperty, binding1)
        '</Snippet9>
        AddHandler listBox1.SelectionChanged, AddressOf listBox1_SelectionChanged

        root.Children.Add(listBox1)

    End Sub 'AddThirdListBox


    Private Sub listBox1_SelectionChanged(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)

        Dim theListBox As ListBox = sender '

        If theListBox Is Nothing Then
            MessageBox.Show("theListBox is null")
            Return
        End If

        If e.AddedItems.Count = 0 Then
            MessageBox.Show("e.AddedItems is empty")
            Return
        End If

        MessageBox.Show(e.AddedItems(0).GetType().ToString())
        Dim lbi As ListBoxItem = _
            CType(theListBox.ItemContainerGenerator.ContainerFromItem(e.AddedItems(0)), ListBoxItem)

        If lbi Is Nothing Then
            MessageBox.Show("lbi is null")

        Else

            lbi.Background = Brushes.Green
        End If

    End Sub 'listBox1_SelectionChanged


    Private listBox1 As New ListBox()
    Private stackPanel1 As New StackPanel()


    Sub AddFirstListBox()
        '<Snippet4>
        ' Create a Button with a string as its content.
        listBox1.Items.Add("This is a string in a ListBox")

        ' Create a Button with a DateTime object as its content.
        Dim dateTime1 As New DateTime(2004, 3, 4, 13, 6, 55)

        listBox1.Items.Add(dateTime1)

        ' Create a Button with a single UIElement as its content.
        Dim rect1 As New Rectangle()
        rect1.Width = 40
        rect1.Height = 40
        rect1.Fill = Brushes.Blue
        listBox1.Items.Add(rect1)

        ' Create a Button with a panel that contains multiple objects 
        ' as its content.
        Dim ellipse1 As New Ellipse()
        Dim textBlock1 As New TextBlock()

        ellipse1.Width = 40
        ellipse1.Height = 40
        ellipse1.Fill = Brushes.Blue

        textBlock1.TextAlignment = TextAlignment.Center
        textBlock1.Text = "Text below an Ellipse"

        stackPanel1.Children.Add(ellipse1)
        stackPanel1.Children.Add(textBlock1)

        listBox1.Items.Add(stackPanel1)
        '</Snippet4>
        root.Children.Add(listBox1)

    End Sub 'AddFirstListBox



    Private Sub CreateButtons()
        '<Snippet2>           
        ' Add a string to a button.
        Dim stringContent As New Button()
        stringContent.Content = "This is string content of a Button"

        ' Add a DateTime object to a button.
        Dim objectContent As New Button()
        Dim dateTime1 As New DateTime(2004, 3, 4, 13, 6, 55)

        objectContent.Content = dateTime1

        ' Add a single UIElement to a button.
        Dim uiElementContent As New Button()

        Dim rect1 As New Rectangle()
        rect1.Width = 40
        rect1.Height = 40
        rect1.Fill = Brushes.Blue
        uiElementContent.Content = rect1

        ' Add a panel that contains multpile objects to a button.
        Dim panelContent As New Button()
        Dim stackPanel1 As New StackPanel()
        Dim ellipse1 As New Ellipse()
        Dim textBlock1 As New TextBlock()

        ellipse1.Width = 40
        ellipse1.Height = 40
        ellipse1.Fill = Brushes.Blue

        textBlock1.TextAlignment = TextAlignment.Center
        textBlock1.Text = "Button"

        stackPanel1.Children.Add(ellipse1)
        stackPanel1.Children.Add(textBlock1)

        panelContent.Content = stackPanel1
        '</Snippet2>           
        root.Children.Add(stringContent)
        root.Children.Add(uiElementContent)
        root.Children.Add(panelContent)
        root.Children.Add(objectContent)

        AddHandler stringContent.Click, AddressOf stringContent_Click

    End Sub 'CreateButtons


    Private Sub stringContent_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        '<Snippet15>
        Dim lbi As ListBoxItem = _
            CType(simpleListBox.ItemContainerGenerator.ContainerFromItem(itemToSelect),  _
                  ListBoxItem)

        If Not (lbi Is Nothing) Then
            lbi.IsSelected = True
        End If
        '</Snippet15>

    End Sub 'stringContent_Click
End Class 'Window1


'<Snippet8>
Public Class MyData
    Inherits ObservableCollection(Of String)

    Public Sub New()  '

        Add("Item 1")
        Add("Item 2")
        Add("Item 3")

    End Sub 'New
End Class 'MyData
'</Snippet8>
