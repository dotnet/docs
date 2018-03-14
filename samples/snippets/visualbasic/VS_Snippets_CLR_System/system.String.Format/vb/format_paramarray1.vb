' Visual Basic .NET Document
Option Strict On

' <Snippet10>
Public Class CityInfo
   Public Sub New(name As String, population As Integer, area As Decimal, year As Integer)
      Me.Name = name
      Me.Population = population
      Me.Area = area
      Me.Year = year
   End Sub
   
   Public ReadOnly Name As String
   Public ReadOnly Population As Integer
   Public ReadOnly Area As Decimal
   Public ReadOnly Year As Integer
End Class

Module Example
   Public Sub Main()
      Dim nyc2010 As New CityInfo("New York", 8175133, 302.64d, 2010)
      ShowPopulationData(nyc2010)
      Dim sea2010 As New CityInfo("Seattle", 608660, 83.94d, 2010)      
      ShowPopulationData(sea2010) 
   End Sub
   
   Private Sub ShowPopulationData(city As CityInfo)
      Dim args() As Object = { city.Name, city.Year, city.Population, city.Area }
      Dim result = String.Format("{0} in {1}: Population {2:N0}, Area {3:N1} sq. feet", args)
      Console.WriteLine(result) 
   End Sub
End Module
' The example displays the following output:
'       New York in 2010: Population 8,175,133, Area 302.6 sq. feet
'       Seattle in 2010: Population 608,660, Area 83.9 sq. feet   
' </Snippet10>
