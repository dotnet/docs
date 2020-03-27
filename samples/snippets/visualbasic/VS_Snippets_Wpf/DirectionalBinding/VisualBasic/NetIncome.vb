Imports System.ComponentModel
Imports System.Runtime.CompilerServices

'<SnippetDataObject>
Public Class NetIncome
    Implements INotifyPropertyChanged

    ' Events
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    ' Methods
    Public Sub New()
        Me._totalIncome = 5000
        Me._rent = 2000
        Me._food = 0
        Me._misc = 0
        Me._savings = 0
        Me._savings = (Me.TotalIncome - ((Me.Rent + Me.Food) + Me.Misc))
    End Sub

    Private Sub OnPropertyChanged(ByVal info As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(info))
    End Sub

    Private Sub UpdateSavings()
        Me.Savings = (Me.TotalIncome - ((Me.Rent + Me.Misc) + Me.Food))
        If ((Me.Savings >= 0) AndAlso (Me.Savings >= 0)) Then
        End If
    End Sub


    ' Properties
    Public Property Food As Integer
        Get
            Return Me._food
        End Get
        Set(ByVal value As Integer)
            If (Me.Food <> value) Then
                Me._food = value
                Me.OnPropertyChanged("Food")
                Me.UpdateSavings()
            End If
        End Set
    End Property

    Public Property Misc As Integer
        Get
            Return Me._misc
        End Get
        Set(ByVal value As Integer)
            If (Me.Misc <> value) Then
                Me._misc = value
                Me.OnPropertyChanged("Misc")
                Me.UpdateSavings()
            End If
        End Set
    End Property

    Public Property Rent As Integer
        Get
            Return Me._rent
        End Get
        Set(ByVal value As Integer)
            If (Me.Rent <> value) Then
                Me._rent = value
                Me.OnPropertyChanged("Rent")
                Me.UpdateSavings()
            End If
        End Set
    End Property

    Public Property Savings As Integer
        Get
            Return Me._savings
        End Get
        Set(ByVal value As Integer)
            If (Me.Savings <> value) Then
                Me._savings = value
                Me.OnPropertyChanged("Savings")
                Me.UpdateSavings()
            End If
        End Set
    End Property

    Public Property TotalIncome As Integer
        Get
            Return Me._totalIncome
        End Get
        Set(ByVal value As Integer)
            If (Me.TotalIncome <> value) Then
                Me._totalIncome = value
                Me.OnPropertyChanged("TotalIncome")
            End If
        End Set
    End Property


    ' Fields
    Private _food As Integer
    Private _misc As Integer
    Private _rent As Integer
    Private _savings As Integer
    Private _totalIncome As Integer
End Class
'</SnippetDataObject>


