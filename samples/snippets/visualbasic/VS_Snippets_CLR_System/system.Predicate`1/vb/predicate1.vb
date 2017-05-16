' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Collections.Generic

Public Class HockeyTeam
   Private _name As String
   Private _founded As Integer
   
   Public Sub New(name As String, year As Integer)
      _name = name
      _founded = year
   End Sub

   Public ReadOnly Property Name As String
      Get
         Return _name
      End Get
   End Property

   Public ReadOnly Property Founded As Integer
      Get 
         Return _founded
      End Get   
   End Property
End Class

Module Example
   Public Sub Main()
      Dim rnd As New Random()
      Dim teams As New List(Of HockeyTeam)()
      teams.AddRange( { new HockeyTeam("Detroit Red Wings", 1926), 
                        new HockeyTeam("Chicago Blackhawks", 1926),
                        new HockeyTeam("San Jose Sharks", 1991),
                        new HockeyTeam("Montreal Canadiens", 1909),
                        new HockeyTeam("St. Louis Blues", 1967) } )
      Dim years() As Integer = { 1920, 1930, 1980, 2000 }
      Dim foundedBeforeYear As Integer = years(rnd.Next(0, years.Length))
      Console.WriteLine("Teams founded before {0}:", foundedBeforeYear)
      For Each team in teams.FindAll( Function(x) x.Founded <= foundedBeforeYear )
         Console.WriteLine("{0}: {1}", team.Name, team.Founded)
      Next   
   End Sub
End Module
' The example displays output similar to the following:
'       Teams founded before 1930:
'       Detroit Red Wings: 1926
'       Chicago Blackhawks: 1926
'       Montreal Canadiens: 1909
' </Snippet3>

