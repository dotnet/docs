'<SnippetData>
Imports System
Imports System.ComponentModel
Imports System.Windows.Controls
Imports System.Globalization

' LibraryItem implements INotifyPropertyChanged so that the 
' application is notified when a property changes. It 
' implements IEditableObject so that pending changes can be discarded.
' In this example, the application does not discard changes.
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
        Me.DueDate = DueDate
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

    Protected Sub NotifyPropertyChanged(ByVal info As [String])
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(info))
    End Sub

#End Region

#Region "IEditableObject Members"

    Public Overridable Sub BeginEdit() _
        Implements IEditableObject.BeginEdit

        copyData = currentData
    End Sub

    Public Overridable Sub CancelEdit() _
        Implements IEditableObject.CancelEdit

        currentData = copyData

        NotifyPropertyChanged("")
    End Sub

    Public Overridable Sub EndEdit() _
        Implements IEditableObject.EndEdit

        copyData = New ItemData()
    End Sub

#End Region

End Class

Public Class CallNumberRule
    Inherits ValidationRule

    ' A valid call number contains a period (.)
    ' and 6 characters after the period.
    Public Overloads Overrides Function Validate(ByVal value As Object,
                               ByVal cultureInfo As CultureInfo) As ValidationResult

        Dim callNum As String = DirectCast(value, String)

        Dim dotIndex As Integer = callNum.IndexOf(".")

        If dotIndex = -1 OrElse dotIndex = 0 Then
            Return New ValidationResult(False,
                "There must be characters followed by a period (.) in the call number.")
        End If

        Dim substr As String = callNum.Substring(dotIndex + 1)

        If substr.Length <> 6 Then
            Return New ValidationResult(False,
                "The call number must have 6 characters after the period (.).")
        End If

        Return ValidationResult.ValidResult
    End Function
End Class

'</SnippetData>