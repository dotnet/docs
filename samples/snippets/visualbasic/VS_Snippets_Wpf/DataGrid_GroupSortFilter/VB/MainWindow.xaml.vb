' <snippet100>
Imports System.ComponentModel
Imports System.Collections.ObjectModel

Class MainWindow
    Public Sub New()
        InitializeComponent()

        ' Get a reference to the tasks collection.
        Dim _tasks As Tasks = Me.Resources("tasks")

        ' Generate some task data and add it to the task list.
        For index = 1 To 14
            _tasks.Add(New Task() With _
                         {.ProjectName = "Project " & ((index Mod 3) + 1).ToString(), _
                           .TaskName = "Task " & index.ToString(), _
                           .DueDate = Date.Now.AddDays(index), _
                           .Complete = (index Mod 2 = 0) _
                         })
        Next
    End Sub

    Private Sub UngroupButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        ' <snippet114>
        ' <snippet102>
        Dim cvTasks As ICollectionView = CollectionViewSource.GetDefaultView(dataGrid1.ItemsSource)
        ' </snippet102>
        If cvTasks IsNot Nothing Then
            cvTasks.GroupDescriptions.Clear()
        End If
        ' </snippet114>
    End Sub

    Private Sub GroupButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        ' <snippet112>
        Dim cvTasks As ICollectionView = CollectionViewSource.GetDefaultView(dataGrid1.ItemsSource)
        If cvTasks IsNot Nothing And cvTasks.CanGroup = True Then
            cvTasks.GroupDescriptions.Clear()
            cvTasks.GroupDescriptions.Add(New PropertyGroupDescription("ProjectName"))
            cvTasks.GroupDescriptions.Add(New PropertyGroupDescription("Complete"))
        End If
        ' </snippet112>
    End Sub

    Private Sub CompleteFilter_Changed(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        ' Refresh the view to apply filters.
        CollectionViewSource.GetDefaultView(dataGrid1.ItemsSource).Refresh()
    End Sub

    ' <snippet113>
    Private Sub CollectionViewSource_Filter(ByVal sender As System.Object, ByVal e As System.Windows.Data.FilterEventArgs)
        Dim t As Task = e.Item
        If t IsNot Nothing Then
            ' If filter is turned on, filter completed items.
            If Me.cbCompleteFilter.IsChecked = True And t.Complete = True Then
                e.Accepted = False
            Else
                e.Accepted = True
            End If
        End If
    End Sub
    ' </snippet113>
End Class

Public Class CompleteConverter
    Implements IValueConverter
    ' This converter changes the value of a Tasks Complete status from true/false to a string value of
    ' "Complete"/"Active" for use in the row group header.
    Public Function Convert(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.Convert
        Dim complete As Boolean = value
        If complete = True Then
            Return "Complete"
        Else
            Return "Active"
        End If
    End Function

    Public Function ConvertBack1(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.ConvertBack
        Dim strComplete As String = value
        If strComplete = "Complete" Then
            Return True
        Else
            Return False
        End If
    End Function
End Class

' Task class
' Requires Imports System.ComponentModel
Public Class Task
    Implements INotifyPropertyChanged, IEditableObject
    ' The Task class implements INotifyPropertyChanged and IEditableObject 
    ' so that the datagrid can properly respond to changes to the 
    ' data collection and edits made in the DataGrid.

    ' Private task data.
    Private m_ProjectName As String = String.Empty
    Private m_TaskName As String = String.Empty
    Private m_DueDate As DateTime = Date.Now
    Private m_Complete As Boolean = False

    ' Data for undoing canceled edits.
    Private temp_Task As Task = Nothing
    Private m_Editing As Boolean = False

    ' Public properties.
    Public Property ProjectName() As String
        Get
            Return Me.m_ProjectName
        End Get
        Set(ByVal value As String)
            If Not value = Me.m_ProjectName Then
                Me.m_ProjectName = value
                NotifyPropertyChanged("ProjectName")
            End If
        End Set
    End Property

    Public Property TaskName() As String
        Get
            Return Me.m_TaskName
        End Get
        Set(ByVal value As String)
            If Not value = Me.m_TaskName Then
                Me.m_TaskName = value
                NotifyPropertyChanged("TaskName")
            End If
        End Set
    End Property

    Public Property DueDate() As Date
        Get
            Return Me.m_DueDate
        End Get
        Set(ByVal value As Date)
            If Not value = Me.m_DueDate Then
                Me.m_DueDate = value
                NotifyPropertyChanged("DueDate")
            End If
        End Set
    End Property

    Public Property Complete() As Boolean
        Get
            Return Me.m_Complete
        End Get
        Set(ByVal value As Boolean)
            If Not value = Me.m_Complete Then
                Me.m_Complete = value
                NotifyPropertyChanged("Complete")
            End If
        End Set
    End Property

    ' Implement INotifyPropertyChanged interface. 
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Sub NotifyPropertyChanged(ByVal propertyName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub

    ' Implement IEditableObject interface.
    Public Sub BeginEdit() Implements IEditableObject.BeginEdit
        If Not Me.m_Editing Then
            Me.temp_Task = Me.MemberwiseClone()
            Me.m_Editing = True
        End If
    End Sub

    Public Sub CancelEdit() Implements IEditableObject.CancelEdit
        If m_Editing = True Then
            Me.ProjectName = Me.temp_Task.ProjectName
            Me.TaskName = Me.temp_Task.TaskName
            Me.DueDate = Me.temp_Task.DueDate
            Me.Complete = Me.temp_Task.Complete
            Me.m_Editing = False
        End If
    End Sub

    Public Sub EndEdit() Implements IEditableObject.EndEdit
        If m_Editing = True Then
            Me.temp_Task = Nothing
            Me.m_Editing = False
        End If
    End Sub
End Class

' <snippet101>
' Requires Imports System.Collections.ObjectModel
Public Class Tasks
    Inherits ObservableCollection(Of Task)
    ' Creating the Tasks collection in this way enables data binding from XAML.
End Class
' </snippet101>
' </snippet100>

Class ExtraSnippets
    ' This code is only used for snippets; it is not used by the sample app.
    Private dataGrid1 As DataGrid = New DataGrid()
    Private Sub Sort()
        ' <snippet211>
        Dim cvTasks As ICollectionView = CollectionViewSource.GetDefaultView(dataGrid1.ItemsSource)
        If cvTasks IsNot Nothing And cvTasks.CanSort = True Then
            cvTasks.SortDescriptions.Clear()
            cvTasks.SortDescriptions.Add(New SortDescription("ProjectName", ListSortDirection.Ascending))
            cvTasks.SortDescriptions.Add(New SortDescription("Complete", ListSortDirection.Ascending))
            cvTasks.SortDescriptions.Add(New SortDescription("DueDate", ListSortDirection.Ascending))
        End If
        ' </snippet211>
    End Sub
End Class