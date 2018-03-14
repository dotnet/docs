'<snippetFullCode>
Imports System.Collections.ObjectModel
Imports System.ComponentModel

Public Class MainWindow

    Private Sub dataGrid1_InitializingNewItem(ByVal sender As System.Object, _
        ByVal e As System.Windows.Controls.InitializingNewItemEventArgs) _
        Handles dataGrid1.InitializingNewItem

        Dim newCourse As Course = CType(e.NewItem, Course)
        newCourse.StartDate = DateTime.Today
        newCourse.EndDate = DateTime.Today

    End Sub

End Class

Public Class Courses
    Inherits ObservableCollection(Of Course)

    Sub New()
        Me.Add(New Course With { _
            .Name = "Learning WPF", _
            .Id = 1001, _
            .StartDate = New DateTime(2010, 1, 11), _
            .EndDate = New DateTime(2010, 1, 22) _
        })
        Me.Add(New Course With { _
            .Name = "Learning Silverlight", _
            .Id = 1002, _
            .StartDate = New DateTime(2010, 1, 25), _
            .EndDate = New DateTime(2010, 2, 5) _
        })
        Me.Add(New Course With { _
            .Name = "Learning Expression Blend", _
            .Id = 1003, _
            .StartDate = New DateTime(2010, 2, 8), _
            .EndDate = New DateTime(2010, 2, 19) _
        })
        Me.Add(New Course With { _
            .Name = "Learning LINQ", _
            .Id = 1004, _
            .StartDate = New DateTime(2010, 2, 22), _
            .EndDate = New DateTime(2010, 3, 5) _
        })
    End Sub

End Class

Public Class Course
    Implements IEditableObject, INotifyPropertyChanged

    Private _name As String
    Public Property Name As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            If _name = value Then Return
            _name = value
            OnPropertyChanged("Name")
        End Set
    End Property

    Private _number As Integer
    Public Property Id As Integer
        Get
            Return _number
        End Get
        Set(ByVal value As Integer)
            If _number = value Then Return
            _number = value
            OnPropertyChanged("Id")
        End Set
    End Property

    Private _startDate As DateTime
    Public Property StartDate As DateTime
        Get
            Return _startDate
        End Get
        Set(ByVal value As DateTime)
            If _startDate = value Then Return
            _startDate = value
            OnPropertyChanged("StartDate")
        End Set
    End Property

    Private _endDate As DateTime
    Public Property EndDate As DateTime
        Get
            Return _endDate
        End Get
        Set(ByVal value As DateTime)
            If _endDate = value Then Return
            _endDate = value
            OnPropertyChanged("EndDate")
        End Set
    End Property

#Region "IEditableObject"

    Private backupCopy As Course
    Private inEdit As Boolean

    Public Sub BeginEdit() Implements IEditableObject.BeginEdit
        If inEdit Then Return
        inEdit = True
        backupCopy = CType(Me.MemberwiseClone(), Course)
    End Sub

    Public Sub CancelEdit() Implements IEditableObject.CancelEdit
        If Not inEdit Then Return
        inEdit = False
        Me.Name = backupCopy.Name
        Me.Id = backupCopy.Id
        Me.StartDate = backupCopy.StartDate
        Me.EndDate = backupCopy.EndDate
    End Sub

    Public Sub EndEdit() Implements IEditableObject.EndEdit
        If Not inEdit Then Return
        inEdit = False
        backupCopy = Nothing
    End Sub

#End Region

#Region "INotifyPropertyChanged"

    Public Event PropertyChanged As PropertyChangedEventHandler _
        Implements INotifyPropertyChanged.PropertyChanged

    Private Sub OnPropertyChanged(ByVal propertyName As String)
        RaiseEvent PropertyChanged(Me, _
           New PropertyChangedEventArgs(propertyName))
    End Sub

#End Region

End Class

'<snippetCourseValidationRule>
Public Class CourseValidationRule
    Inherits ValidationRule

    Public Overrides Function Validate(ByVal value As Object, _
        ByVal cultureInfo As System.Globalization.CultureInfo) _
        As ValidationResult

        Dim course As Course = _
            CType(CType(value, BindingGroup).Items(0), Course)

        If course.StartDate > course.EndDate Then
            Return New ValidationResult(False, _
                "Start Date must be earlier than End Date.")
        Else
            Return ValidationResult.ValidResult
        End If

    End Function

End Class
'</snippetCourseValidationRule>
'</snippetFullCode>

