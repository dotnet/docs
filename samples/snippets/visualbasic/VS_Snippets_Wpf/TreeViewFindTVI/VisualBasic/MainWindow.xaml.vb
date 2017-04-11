Imports System
Imports System.Collections.ObjectModel
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Input
Imports System.Windows.Media

''' <summary> 
''' Interaction logic for MainWindow.xaml 
''' </summary> 
Partial Public Class MainWindow
    Inherits Window

    Private data As New TestDataItem(0, 0, 0)

    Public Sub New()
        InitializeComponent()
        data.PopulateItems(2, 5)
        tv1.ItemsSource = data.Items
    End Sub

    '<Snippet1> 
    ''' <summary> 
    ''' Recursively search for an item in this subtree. 
    ''' </summary> 
    ''' <param name="container"> 
    ''' The parent ItemsControl.  This can be a TreeView or a TreeViewItem.
    ''' </param> 
    ''' <param name="item"> 
    ''' The item to search for. 
    ''' </param> 
    ''' <returns> 
    ''' The TreeViewItem that contains the specified item. 
    ''' </returns> 
    Private Function GetTreeViewItem(ByVal container As ItemsControl,
                                     ByVal item As Object) As TreeViewItem

        If container IsNot Nothing Then
            If container.DataContext Is item Then
                Return TryCast(container, TreeViewItem)
            End If

            ' Expand the current container 
            If TypeOf container Is TreeViewItem AndAlso
               Not DirectCast(container, TreeViewItem).IsExpanded Then

                container.SetValue(TreeViewItem.IsExpandedProperty, True)
            End If

            ' Try to generate the ItemsPresenter and the ItemsPanel. 
            ' by calling ApplyTemplate. Note that in the 
            ' virtualizing case, even if IsExpanded = true, 
            ' we still need to do this step in order to 
            ' regenerate the visuals because they may have been virtualized away. 
            container.ApplyTemplate()

            Dim itemsPresenter As ItemsPresenter =
                DirectCast(container.Template.FindName("ItemsHost", container), ItemsPresenter)

            If itemsPresenter IsNot Nothing Then
                itemsPresenter.ApplyTemplate()
            Else
                ' The Tree template has not named the ItemsPresenter, 
                ' so walk the descendents and find the child. 
                itemsPresenter = FindVisualChild(Of ItemsPresenter)(container)

                If itemsPresenter Is Nothing Then
                    container.UpdateLayout()

                    itemsPresenter = FindVisualChild(Of ItemsPresenter)(container)
                End If
            End If

            Dim itemsHostPanel As Panel =
                DirectCast(VisualTreeHelper.GetChild(itemsPresenter, 0), Panel)


            ' Do this to ensure that the generator for this panel has been created. 
            Dim children As UIElementCollection = itemsHostPanel.Children

            Dim virtualizingPanel As MyVirtualizingStackPanel =
                TryCast(itemsHostPanel, MyVirtualizingStackPanel)


            For index As Integer = 0 To container.Items.Count - 1

                Dim subContainer As TreeViewItem

                If virtualizingPanel IsNot Nothing Then

                    ' Bring the item into view so 
                    ' that the container will be generated. 
                    virtualizingPanel.BringIntoView(index)

                    subContainer =
                        DirectCast(container.ItemContainerGenerator.ContainerFromIndex(index), 
                            TreeViewItem)
                Else
                    subContainer =
                        DirectCast(container.ItemContainerGenerator.ContainerFromIndex(index), 
                            TreeViewItem)

                    ' Bring the item into view to maintain the 
                    ' same behavior as with a virtualizing panel. 
                    subContainer.BringIntoView()
                End If

                If subContainer IsNot Nothing Then

                    ' Search the next level for the object.
                    Dim resultContainer As TreeViewItem =
                        GetTreeViewItem(subContainer, item)

                    If resultContainer IsNot Nothing Then
                        Return resultContainer
                    Else
                        ' The object is not under this TreeViewItem
                        ' so collapse it.
                        subContainer.IsExpanded = False
                    End If
                End If
            Next
        End If

        Return Nothing
    End Function

    ''' <summary> 
    ''' Search for an element of a certain type in the visual tree. 
    ''' </summary> 
    ''' <typeparam name="T">The type of element to find.</typeparam> 
    ''' <param name="visual">The parent element.</param> 
    ''' <returns></returns> 
    Private Function FindVisualChild(Of T As Visual)(ByVal visual As Visual) As T

        For i As Integer = 0 To VisualTreeHelper.GetChildrenCount(visual) - 1

            Dim child As Visual = DirectCast(VisualTreeHelper.GetChild(visual, i), Visual)

            If child IsNot Nothing Then

                Dim correctlyTyped As T = TryCast(child, T)
                If correctlyTyped IsNot Nothing Then
                    Return correctlyTyped
                End If

                Dim descendent As T = FindVisualChild(Of T)(child)
                If descendent IsNot Nothing Then
                    Return descendent
                End If
            End If
        Next

        Return Nothing
    End Function
    '</Snippet1> 


    ''' <summary> 
    ''' Find the object that corresponds to the specified key. 
    ''' </summary> 
    ''' <param name="key">The key of the item to find.</param> 
    ''' <returns>The object that contains the specified key.</returns> 
    ''' <remarks> 
    ''' This method is specific to the object model in 
    ''' this sample and is not meant to be usable for general 
    ''' cases. Applications must provide the logic to find 
    ''' the data in their object model. 
    ''' 
    ''' This method relies on the data model getting populated 
    ''' by calling PopulateItems(2, 5). If you Change the parameters 
    ''' of PopulateItems, this method might not find the 
    ''' specified item. 
    ''' </remarks> 
    Private Function FindTreeDataItem(ByVal key As Integer) As TestDataItem
        Dim currentList As ObservableCollection(Of TestDataItem) = data.Items
        Dim i As Integer
        Dim currentIndex As Integer

        ' Determine whether to go to the first or second node. 
        If key < currentList(1).Key Then
            i = 0
        Else
            i = 1
        End If

        While (currentList(i).Items.Count = 2) AndAlso (currentList(i).Key <> key)

            ' Save the current value before changing i. 
            currentIndex = i

            ' Check whether the second item of the current list is 
            ' greater than the key. If it is, the item we want is 
            ' under the first item. 
            If key < currentList(i).Items(1).Key Then
                i = 0
            Else
                i = 1
            End If

            ' Get the original currentList[i].Items (before i changed). 
            currentList = currentList(currentIndex).Items
        End While


        Return currentList(i)
    End Function

    Private Sub Button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim key As Integer

        If Not Int32.TryParse(findItem.Text, key) OrElse
           key > TestDataItem.HighestKey Then

            MessageBox.Show(String.Format("Please enter a number between 1 and {0}",
                                          TestDataItem.HighestKey))
            Exit Sub
        End If

        Dim item As Object = FindTreeDataItem(key)

        If item Is Nothing Then
            MessageBox.Show("Item not found: " & item)
            Exit Sub
        End If

        Dim requestedItem As TreeViewItem = GetTreeViewItem(tv1, item)

        If requestedItem IsNot Nothing Then
            MessageBox.Show(requestedItem.ToString())
            requestedItem.IsSelected = True
        End If
    End Sub

End Class

'<Snippet2>
Public Class MyVirtualizingStackPanel
    Inherits VirtualizingStackPanel
    ''' <summary> 
    ''' Publically expose BringIndexIntoView. 
    ''' </summary> 
    Public Overloads Sub BringIntoView(ByVal index As Integer)

        Me.BringIndexIntoView(index)
    End Sub
End Class
'</Snippet2>

' Test data. 
Public Class TestDataItem

    Private _id As Integer
    Private _level As Integer
    Private _items As ObservableCollection(Of TestDataItem)
    Private _key As Integer
    Shared keyId As Integer = 0

    Public Sub New(ByVal id As Integer, ByVal level As Integer, ByVal key As Integer)
        _id = id
        _level = level
        _key = key
    End Sub

    Public Shared ReadOnly Property HighestKey() As Integer
        Get
            Return TestDataItem.keyId
        End Get
    End Property
    Public ReadOnly Property Id() As Integer
        Get
            Return _id
        End Get
    End Property

    Public ReadOnly Property Level() As Integer
        Get
            Return _level
        End Get
    End Property

    Public ReadOnly Property Key() As Integer
        Get
            Return _key
        End Get
    End Property

    Public ReadOnly Property Name() As String
        Get
            Return Key & ": Item " & Id & " on level " & Level
        End Get
    End Property


    Public Overloads Overrides Function ToString() As String
        Return Key.ToString()
    End Function

    Public ReadOnly Property Items() As ObservableCollection(Of TestDataItem)
        Get
            If _items Is Nothing Then
                _items = New ObservableCollection(Of TestDataItem)()
            End If
            Return _items
        End Get
    End Property

    Public Sub PopulateItems(ByVal count As Integer, ByVal levels As Integer)

        Items.Clear()

        If levels > Level Then
            For i As Integer = 0 To count - 1
                Dim item As New TestDataItem(i, Level + 1, keyId)
                keyId = keyId + 1
                Items.Add(item)
                item.PopulateItems(count, levels)
            Next
        End If
    End Sub
End Class

