'<SnippetData> 
Imports System
Imports System.Collections.ObjectModel
Imports System.ComponentModel

' LibraryItem implements INotifyPropertyChanged so that the 
' application is notified when a property changes. It 
' implements IEditableObject so that pending changes can be discarded. 
Public Class LibraryItem
    Implements INotifyPropertyChanged
    Implements IEditableObject
    Private Structure ItemData
        Friend Title As String
        Friend CallNumber As String
        Friend DueDate As DateTime
    End Structure

    Private copyData As ItemData
    Private currentData As ItemData

    Public Sub New(ByVal title As String, ByVal callNum As String, ByVal dueDate As DateTime)
        Me.Title = title
        Me.CallNumber = callNum
        Me.DueDate = dueDate
    End Sub

    Public Property Title() As String
        Get
            Return currentData.Title
        End Get
        Set(ByVal value As String)
            If currentData.Title <> value Then
                currentData.Title = value
                NotifyPropertyChanged("Title")
            End If
        End Set
    End Property

    Public Property CallNumber() As String
        Get
            Return currentData.CallNumber
        End Get
        Set(ByVal value As String)
            If currentData.CallNumber <> value Then
                currentData.CallNumber = value
                NotifyPropertyChanged("CallNumber")
            End If
        End Set
    End Property

    Public Property DueDate() As DateTime
        Get
            Return currentData.DueDate
        End Get
        Set(ByVal value As DateTime)
            If value <> currentData.DueDate Then
                currentData.DueDate = value
                NotifyPropertyChanged("DueDate")
            End If
        End Set
    End Property

#Region "INotifyPropertyChanged Members"

    Public Event PropertyChanged As PropertyChangedEventHandler _
        Implements INotifyPropertyChanged.PropertyChanged

    Protected Sub NotifyPropertyChanged(ByVal info As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(info))
    End Sub

#End Region

#Region "IEditableObject Members"

    Public Overridable Sub BeginEdit() Implements IEditableObject.BeginEdit
        copyData = currentData
    End Sub

    Public Overridable Sub CancelEdit() Implements IEditableObject.CancelEdit
        currentData = copyData

        NotifyPropertyChanged("")
    End Sub

    Public Overridable Sub EndEdit() Implements IEditableObject.EndEdit

        copyData = New ItemData()
    End Sub

#End Region

End Class


Public Class MusicCD
    Inherits LibraryItem
    Private Structure MusicData
        Friend SongNumber As Integer
        Friend Artist As String

    End Structure

    Private copyData As MusicData
    Private currentData As MusicData

    Public Sub New(ByVal title As String, ByVal artist As String,
                   ByVal songNum As Integer, ByVal callNum As String,
                   ByVal dueDate As DateTime)

        MyBase.New(title, callNum, dueDate)
        currentData.SongNumber = songNum
        currentData.Artist = artist
    End Sub

    Public Property Artist() As String
        Get
            Return currentData.Artist
        End Get
        Set(ByVal value As String)
            If value <> currentData.Artist Then
                currentData.Artist = value
                NotifyPropertyChanged("Artist")
            End If
        End Set
    End Property

    Public Property NumberOfTracks() As Integer
        Get
            Return currentData.SongNumber
        End Get
        Set(ByVal value As Integer)
            If value <> currentData.SongNumber Then
                currentData.SongNumber = value
                NotifyPropertyChanged("NumberOfTracks")
            End If
        End Set
    End Property

    Public Overloads Overrides Sub BeginEdit()
        MyBase.BeginEdit()
        copyData = currentData
    End Sub

    Public Overloads Overrides Sub CancelEdit()
        MyBase.CancelEdit()
        currentData = copyData
    End Sub

    Public Overloads Overrides Sub EndEdit()
        MyBase.EndEdit()
        copyData = New MusicData()
    End Sub

End Class

Public Class Book
    Inherits LibraryItem
    Private Structure BookData
        Friend Author As String
        Friend Genre As String
    End Structure

    Private currentData As BookData
    Private copyData As BookData

    Public Sub New(ByVal title As String, ByVal author As String, 
                   ByVal genre As String, ByVal callnum As String, 
                   ByVal dueDate As DateTime)
        MyBase.New(title, callnum, dueDate)

        Me.Author = author
        Me.Genre = genre
    End Sub

    Public Property Author() As String
        Get
            Return currentData.Author
        End Get
        Set(ByVal value As String)
            If value <> currentData.Author Then
                currentData.Author = value
                NotifyPropertyChanged("Author")
            End If
        End Set
    End Property

    Public Property Genre() As String
        Get
            Return currentData.Genre
        End Get
        Set(ByVal value As String)
            If value <> currentData.Genre Then
                currentData.Genre = value
                NotifyPropertyChanged("Genre")
            End If
        End Set
    End Property

    Public Overloads Overrides Sub BeginEdit()
        MyBase.BeginEdit()
        copyData = currentData
    End Sub

    Public Overloads Overrides Sub CancelEdit()
        MyBase.CancelEdit()
        currentData = copyData
    End Sub

    Public Overloads Overrides Sub EndEdit()
        MyBase.EndEdit()
        copyData = New BookData()
    End Sub

End Class

Public Class MovieDVD
    Inherits LibraryItem
    Private Structure MovieData
        Friend Length As TimeSpan
        Friend Director As String
        Friend Genre As String
    End Structure

    Private currentData As MovieData
    Private copyData As MovieData


    Public Sub New(ByVal title As String, ByVal director As String,
                   ByVal genre As String, ByVal length As TimeSpan,
                   ByVal callnum As String, ByVal dueDate As DateTime)

        MyBase.New(title, callnum, dueDate)
        Me.Director = director
        Me.Length = length
        Me.Genre = genre
    End Sub

    Public Property Length() As TimeSpan
        Get
            Return currentData.Length
        End Get
        Set(ByVal value As TimeSpan)
            If value <> currentData.Length Then
                currentData.Length = value
                NotifyPropertyChanged("Length")
            End If
        End Set
    End Property

    Public Property Director() As String
        Get
            Return currentData.Director
        End Get
        Set(ByVal value As String)
            If value <> currentData.Director Then
                currentData.Director = value
                NotifyPropertyChanged("Director")
            End If
        End Set
    End Property

    Public Property Genre() As String
        Get
            Return currentData.Genre
        End Get
        Set(ByVal value As String)
            If value <> currentData.Genre Then
                currentData.Genre = value
                NotifyPropertyChanged("Genre")
            End If
        End Set
    End Property

    Public Overloads Overrides Sub BeginEdit()
        MyBase.BeginEdit()
        copyData = currentData
    End Sub

    Public Overloads Overrides Sub CancelEdit()
        MyBase.CancelEdit()
        currentData = copyData
    End Sub

    Public Overloads Overrides Sub EndEdit()
        MyBase.EndEdit()
        copyData = New MovieData()
    End Sub

End Class

Public Class LibraryCatalog
    Inherits ObservableCollection(Of LibraryItem)

    Public Sub New()
        Add(New MusicCD("A Programmers Plight", "Jon Orton", 12,
                        "CD.OrtPro", New DateTime(2010, 3, 24)))
        Add(New Book("Cooking with Thyme", "Eliot J. Graff",
                        "Home Economics", "HE.GraThy", New DateTime(2010, 2, 26)))
        Add(New MovieDVD("Terror of the Testers", "Molly Dempsey", "Horror",
                         New TimeSpan(1, 27, 19), "DVD.DemTer", New DateTime(2010, 2, 1)))
        Add(New MusicCD("The Best of Jim Hance", "Jim Hance", 15,
                        "CD.HanBes", New DateTime(2010, 1, 31)))
        Add(New Book("Victor and the VB Vehicle", "Tommy Hortono",
                        "YA Fiction", "YA.HorVic", New DateTime(2010, 3, 1)))
    End Sub
End Class
'</SnippetData> 