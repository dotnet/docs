' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Public Class CityInfo
   Dim cityName As String
   Dim countryName As String
   Dim pop2010 As Integer
   
   Public Sub New(name As String, country As String, pop2010 As Integer)
      Me.cityName = name
      Me.countryName = country
      Me.pop2010 = pop2010
   End Sub
   
   Public ReadOnly Property City As String
      Get
         Return Me.cityName
      End Get
   End Property
   
   Public ReadOnly Property Country As String
      Get
         Return Me.countryName
      End Get
   End Property
   
   Public ReadOnly Property Population As Integer
      Get
         Return Me.pop2010
      End Get   
   End Property
   
   Public Shared Function CompareByName(city1 As CityInfo, city2 As CityInfo) As Integer
      Return String.Compare(city1.City, city2.City)
   End Function
   
   Public Shared Function CompareByPopulation(city1 As CityInfo, city2 As CityInfo) As Integer
      Return city1.Population.CompareTo(city2.Population)
   End Function
   
   Public Shared Function CompareByNames(city1 As CityInfo, city2 As CityInfo) As Integer
      Return String.Compare(city1.Country + city1.City, city2.Country + city2.City)
   End Function   
End Class

Module Example
   Public Sub Main()
      Dim NYC As New CityInfo("New York City", "United States of America", 8175133)
      Dim Det As New CityInfo("Detroit", "United States of America", 713777)
      Dim Paris As New CityInfo("Paris", "France", 2193031)
      Dim cities As CityInfo() = { NYC, Det, Paris }
      ' Display ordered array.
      DisplayArray(cities)
      
      ' Sort array by city name.
      Array.Sort(cities, AddressOf CityInfo.CompareByName)
      DisplayArray(cities)
      
      ' Sort array by population.
      Array.Sort(cities, AddressOf CityInfo.CompareByPopulation)
      DisplayArray(cities)
      
      ' Sort array by country + city name.
      Array.Sort(cities, AddressOf CityInfo.CompareByNames)
      DisplayArray(cities)
   End Sub
   
   Private Sub DisplayArray(cities() As CityInfo)
      Console.WriteLine("{0,-20} {1,-25} {2,10}", "City", "Country", "Population")
      For Each city In cities
         Console.WriteLine("{0,-20} {1,-25} {2,10:N0}", city.City, city.Country, city.Population)
      Next
      Console.WriteLine()
   End Sub
End Module
' The example displays the following output:
'     City                 Country                   Population
'     New York City        United States of America   8,175,133
'     Detroit              United States of America     713,777
'     Paris                France                     2,193,031
'     
'     City                 Country                   Population
'     Detroit              United States of America     713,777
'     New York City        United States of America   8,175,133
'     Paris                France                     2,193,031
'     
'     City                 Country                   Population
'     Detroit              United States of America     713,777
'     Paris                France                     2,193,031
'     New York City        United States of America   8,175,133
'     
'     City                 Country                   Population
'     Paris                France                     2,193,031
'     Detroit              United States of America     713,777
'     New York City        United States of America   8,175,133
' </Snippet1>

