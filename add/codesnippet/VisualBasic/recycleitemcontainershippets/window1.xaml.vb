Imports System.Collections.ObjectModel

Class Window1

End Class

'<SnippetListBoxData> 
Public Class LotsOfItems
    Inherits ObservableCollection(Of String)
    Public Sub New()
        For i As Integer = 0 To 999
            Add("item " & i.ToString())
        Next
    End Sub
End Class
'</SnippetListBoxData> 

'<SnippetTreeViewData> 
Public Class TreeViewData
    Inherits ObservableCollection(Of ItemsForTreeView)

    Public Sub New()
        For i As Integer = 0 To 99
            Dim item As New ItemsForTreeView()
            item.TopLevelName = "item " & i.ToString()
            Add(item)
        Next
    End Sub
End Class


Public Class ItemsForTreeView
    Private _TopLevelName As String
    Public Property TopLevelName() As String
        Get
            Return _TopLevelName
        End Get
        Set(ByVal value As String)
            _TopLevelName = value
        End Set
    End Property
    Private level2Items As ObservableCollection(Of String)

    Public ReadOnly Property SecondLevelItems() As ObservableCollection(Of String)
        Get
            If level2Items Is Nothing Then
                level2Items = New ObservableCollection(Of String)()
            End If
            Return level2Items
        End Get
    End Property

    Public Sub New()
        For i As Integer = 0 To 9
            SecondLevelItems.Add("Second Level " & i.ToString())
        Next
    End Sub
End Class
'</SnippetTreeViewData> 

'<SnippetTreeViewItemStyleSelector> 
Public Class TreeViewItemStyleSelector
    Inherits StyleSelector
    Public Overloads Overrides Function SelectStyle(ByVal item As Object, ByVal container As DependencyObject) As Style
        Dim itemString As String = TryCast(item, String)

        Dim strings As String() = itemString.Split(Nothing)
        Dim value As Integer

        If Not Int32.TryParse(strings(strings.Length - 1), value) Then
            Return Nothing
        End If

        Dim win1 As Window1 = CType(Application.Current.MainWindow, Window1)
        Dim sp As StackPanel = win1.sp1

        If value < 5 Then
            Return TryCast(sp.FindResource("TreeViewItemStyle1"), Style)
        Else
            Return TryCast(sp.FindResource("TreeViewItemStyle2"), Style)
        End If

    End Function
End Class
'</SnippetTreeViewItemStyleSelector> 