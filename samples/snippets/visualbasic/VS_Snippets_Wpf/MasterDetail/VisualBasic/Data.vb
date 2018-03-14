Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Collections.ObjectModel


' <Snippet3>
Public Class Team
  Private _name As String

  Public Sub New(ByVal name As String)
    _name = name
  End Sub 'New

  Public ReadOnly Property Name() As String
    Get
      Return _name
    End Get
  End Property
End Class 'Team

Public Class TeamList
  Inherits ObservableCollection(Of Team)

  Public Sub New()

  End Sub 'New
End Class 'TeamList


Public Class Division
  Private _name As String
  Private _teams As TeamList

  Public Sub New(ByVal name As String)
    _name = name
    _teams = New TeamList()

  End Sub 'New

  Public ReadOnly Property Name() As String
    Get
      Return _name
    End Get
  End Property

  Public ReadOnly Property Teams() As TeamList
      Get
        Return _teams
      End Get
  End Property
End Class 'Division

Public Class DivisionList
  Inherits ObservableCollection(Of Division)

  Public Sub New()

  End Sub 'New
End Class 'DivisionList


Public Class League
  Private _name As String
  Private _divisions As DivisionList

  Public Sub New(ByVal name As String)
    _name = name
    _divisions = New DivisionList()

  End Sub 'New

  Public ReadOnly Property Name() As String
    Get
      Return _name
    End Get
  End Property

  Public ReadOnly Property Divisions() As DivisionList
    Get
      Return _divisions
    End Get
  End Property
End Class 'League


Public Class LeagueList
  Inherits ObservableCollection(Of League)

  Public Sub New()
    MyBase.New()
    Dim l As League
    Dim d As Division

        l = New League("League A")
        Add(l)
        d = New Division("Division A")
        l.Divisions.Add(d)
        d.Teams.Add(New Team("Team I"))
        d.Teams.Add(New Team("Team II"))
        d.Teams.Add(New Team("Team III"))
        d.Teams.Add(New Team("Team IV"))
        d.Teams.Add(New Team("Team V"))
        d = New Division("Division B")
        l.Divisions.Add(d)
        d.Teams.Add(New Team("Team Blue"))
        d.Teams.Add(New Team("Team Red"))
        d.Teams.Add(New Team("Team Yellow"))
        d.Teams.Add(New Team("Team Green"))
        d.Teams.Add(New Team("Team Orange"))
        d = New Division("Division C")
        l.Divisions.Add(d)
        d.Teams.Add(New Team("Team East"))
        d.Teams.Add(New Team("Team West"))
        d.Teams.Add(New Team("Team North"))
        d.Teams.Add(New Team("Team South"))
        l = New League("League B")
        Add(l)
        d = New Division("Division A")
        l.Divisions.Add(d)
        d.Teams.Add(New Team("Team 1"))
        d.Teams.Add(New Team("Team 2"))
        d.Teams.Add(New Team("Team 3"))
        d.Teams.Add(New Team("Team 4"))
        d.Teams.Add(New Team("Team 5"))
        d = New Division("Division B")
        l.Divisions.Add(d)
        d.Teams.Add(New Team("Team Diamond"))
        d.Teams.Add(New Team("Team Heart"))
        d.Teams.Add(New Team("Team Club"))
        d.Teams.Add(New Team("Team Spade"))
        d = New Division("Division C")
        l.Divisions.Add(d)
        d.Teams.Add(New Team("Team Alpha"))
        d.Teams.Add(New Team("Team Beta"))
        d.Teams.Add(New Team("Team Gamma"))
        d.Teams.Add(New Team("Team Delta"))
        d.Teams.Add(New Team("Team Epsilon"))

  End Sub 'New
End Class 'LeagueList
' </Snippet3>
