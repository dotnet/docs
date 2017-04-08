'<snippet16>
Imports System
Imports System.Collections.Concurrent
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading
Imports System.Threading.Tasks

Namespace DictionaryHowToVB

    ' The type of the value to store in the dictionary
    Class CityInfo

        Private _name As String
        Property Name As String
            Get
                Return _name
            End Get
            Set(ByVal value As String)
                _name = value
            End Set
        End Property

        Private _lastQueryDate As DateTime
        Property LastQueryDate As DateTime
            Get
                Return _lastQueryDate
            End Get
            Set(ByVal value As DateTime)
                _lastQueryDate = value
            End Set
        End Property

        Private _longitude As Decimal
        Property Longitude As Decimal
            Get
                Return _longitude
            End Get
            Set(ByVal value As Decimal)
                _longitude = value
            End Set
        End Property
        Private _latitude As Decimal
        Property Latitude As Decimal
            Get
                Return _latitude
            End Get
            Set(ByVal value As Decimal)
                _latitude = value
            End Set
        End Property
        Private _highTemps() As Integer

        Property RecentHighTemperatures As Integer()
            Get
                Return _highTemps
            End Get
            Set(ByVal value As Integer())
                _highTemps = value
            End Set
        End Property

        Public Sub New()

        End Sub

        Public Sub New(ByVal key As String)
            _name = key
            ' MaxValue means "not initialized"
            _longitude = Decimal.MaxValue
            _latitude = Decimal.MaxValue
            _lastQueryDate = DateTime.Now
            _highTemps = {0}
        End Sub

        Public Sub New(ByVal name As String, ByVal longitude As Decimal,
                       ByVal latitude As Decimal, ByVal temps As Integer())
            _name = name
            _longitude = longitude
            _latitude = latitude
            _highTemps = temps
        End Sub
    End Class

    Class Program
        ' Create a new concurrent dictionary with the specified concurrency level and capacity.
        Shared cities As New ConcurrentDictionary(Of String, CityInfo)(System.Environment.ProcessorCount, 10)

        Shared Sub Main()

            Dim data As CityInfo() =
                {New CityInfo With {.Name = "Boston", .Latitude = 42.358769, .Longitude = -71.057806, .RecentHighTemperatures = {56, 51, 52, 58, 65, 56, 53}},
                    New CityInfo With {.Name = "Miami", .Latitude = 25.780833, .Longitude = -80.195556, .RecentHighTemperatures = {86, 87, 88, 87, 85, 85, 86}},
                    New CityInfo With {.Name = "Los Angeles", .Latitude = 34.05, .Longitude = -118.25, .RecentHighTemperatures = {67, 68, 69, 73, 79, 78, 78}},
                    New CityInfo With {.Name = "Seattle", .Latitude = 47.609722, .Longitude = -122.333056, .RecentHighTemperatures = {49, 50, 53, 47, 52, 52, 51}},
                    New CityInfo With {.Name = "Toronto", .Latitude = 43.716589, .Longitude = -79.340686, .RecentHighTemperatures = {53, 57, 51, 52, 56, 55, 50}},
                    New CityInfo With {.Name = "Mexico City", .Latitude = 19.432736, .Longitude = -99.133253, .RecentHighTemperatures = {72, 68, 73, 77, 76, 74, 73}},
                    New CityInfo With {.Name = "Rio de Janiero", .Latitude = -22.908333, .Longitude = -43.196389, .RecentHighTemperatures = {72, 68, 73, 82, 84, 78, 84}},
                    New CityInfo With {.Name = "Quito", .Latitude = -0.25, .Longitude = -78.583333, .RecentHighTemperatures = {71, 69, 70, 66, 65, 64, 61}}}

            '  Add some key/value pairs from multiple threads.
            Dim tasks(1) As Task

         tasks(0) = Task.Run(Sub()
                                For i As Integer = 0 To 1
                                   If cities.TryAdd(data(i).Name, data(i)) Then
                                      Console.WriteLine("Added {0} on thread {1}", data(i).Name, Thread.CurrentThread.ManagedThreadId)
                                   Else
                                      Console.WriteLine("Could not add {0}", data(i))
                                   End If
                                Next
                             End Sub)

         tasks(1) = Task.Run(Sub()
                                For i As Integer = 2 To data.Length - 1
                                   If cities.TryAdd(data(i).Name, data(i)) Then
                                      Console.WriteLine("Added {0} on thread {1}", data(i).Name, Thread.CurrentThread.ManagedThreadId)
                                   Else
                                      Console.WriteLine("Could not add {0}", data(i))
                                   End If
                                Next
                             End Sub)

            ' Output results so far
            Task.WaitAll(tasks)

            ' Enumerate data on main thread. Note that
            ' ConcurrentDictionary is the one collection class
            ' that does not support thread-safe enumeration.
            For Each city In cities
                Console.WriteLine("{0} has been added", city.Key)
            Next

            AddOrUpdateWithoutRetrieving()
            RetrieveValueOrAdd()
            RetrieveAndUpdateOrAdd()

            Console.WriteLine("Press any key")
            Console.ReadKey()

        End Sub

        ' This method shows how to add key-value pairs to the dictionary
        ' in scenarios where the key might already exist.
        Private Shared Sub AddOrUpdateWithoutRetrieving()
            ' Sometime later. We receive new data from some source.
            Dim ci = New CityInfo With {.Name = "Toronto", .Latitude = 43.716589, .Longitude = -79.340686, .RecentHighTemperatures = {54, 59, 67, 82, 87, 55, -14}}

            ' Try to add data. If it doesn't exist, the object ci is added. If it does
            ' already exist, update existingVal according to the custom logic in the 
            ' delegate.
            cities.AddOrUpdate(ci.Name, ci, Function(key, existingVal)
                                                ' If this delegate is invoked, then the key already exists.
                                                ' Here we make sure the city really is the same city we already have.
                                                ' (Support for multiple keys of the same name is left as an exercise for the reader.)
                                                If (ci.Name = existingVal.Name And ci.Longitude = existingVal.Longitude) = False Then
                                                    Throw New ArgumentException("Duplicate city names are not allowed: {0}.", ci.Name)
                                                End If
                                                ' The only updatable fields are the temerature array and lastQueryDate.
                                                existingVal.LastQueryDate = DateTime.Now
                                                existingVal.RecentHighTemperatures = ci.RecentHighTemperatures
                                                Return existingVal
                                            End Function)

            ' Verify that the dictionary contains the new or updated data.
            Console.Write("Most recent high temperatures for {0} are: ", cities(ci.Name).Name)
            Dim temps = cities(ci.Name).RecentHighTemperatures
            For Each temp In temps
                Console.Write("{0}, ", temp)
            Next

            Console.WriteLine()

        End Sub

        'This method shows how to use data and ensure that it has been
        ' added to the dictionary.
        Private Shared Sub RetrieveValueOrAdd()
            Dim searchKey = "Caracas"
            Dim retrievedValue As CityInfo = Nothing

            Try
                retrievedValue = cities.GetOrAdd(searchKey, GetDataForCity(searchKey))

            Catch e As ArgumentException
                Console.WriteLine(e.Message)
            End Try

            ' Use the data.
            If Not retrievedValue Is Nothing Then
                Console.WriteLine("Most recent high temperatures for {0} are: ", retrievedValue.Name)
                Dim temps = cities(retrievedValue.Name).RecentHighTemperatures
                For Each temp In temps
                    Console.Write("{0}, ", temp)
                Next
            End If
            Console.WriteLine()

        End Sub

        ' This method shows how to retrieve a value from the dictionary,
        ' when you expect that the key/value pair already exists,
        ' and then possibly update the dictionary with a new value for the key.
        Private Shared Sub RetrieveAndUpdateOrAdd()
            Dim retrievedValue As CityInfo = New CityInfo()
            Dim searchKey = "Buenos Aires"

            If (cities.TryGetValue(searchKey, retrievedValue)) Then

                ' Use the data
                Console.Write("Most recent high temperatures for {0} are: ", retrievedValue.Name)
                Dim temps = retrievedValue.RecentHighTemperatures
                For Each temp In temps
                    Console.Write("{0}, ", temp)

                Next
                ' Make a copy of the data. Our object will update its lastQueryDate automatically.
                Dim newValue As CityInfo = New CityInfo(retrievedValue.Name,
                                                        retrievedValue.Longitude,
                                                        retrievedValue.Latitude,
                                                        retrievedValue.RecentHighTemperatures)

            Else
                Console.WriteLine("Unable to find data for {0}", searchKey)
            End If
        End Sub

        ' Assume this method knows how to find long/lat/temp info for any specified city.
        Private Shared Function GetDataForCity(ByVal searchKey As String) As CityInfo
            ' Real implementation left as exercise for the reader.
            If String.CompareOrdinal(searchKey, "Caracas") = 0 Then
                Return New CityInfo() With {.Name = "Caracas",
                                            .Longitude = 10.5,
                                            .Latitude = -66.916667,
                                            .RecentHighTemperatures = {91, 89, 91, 91, 87, 90, 91}}
            ElseIf String.CompareOrdinal(searchKey, "Buenos Aires") = 0 Then
                Return New CityInfo() With {.Name = "Buenos Aires",
                                            .Longitude = -34.61,
                                            .Latitude = -58.369997,
                                            .RecentHighTemperatures = {80, 86, 89, 91, 84, 86, 88}}
            Else
                Throw New ArgumentException("Cannot find any data for {0}", searchKey)

            End If
        End Function
    End Class
End Namespace
'</snippet16>
