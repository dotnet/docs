Imports System.Collections.Concurrent

Module Module1

    Sub IntroTopic_OptInModel()

        '<snippet1>
        Dim source = Enumerable.Range(1, 10000)

        ' Opt in to PLINQ with AsParallel
        Dim evenNums = From num In source.AsParallel()
                       Where num Mod 2 = 0
                       Select num
        Console.WriteLine("{0} even numbers out of {1} total",
                          evenNums.Count(), source.Count())
        ' The example displays the following output:
        '       5000 even numbers out of 10000 total
        ' </snippet1>

    End Sub

    Function Compute(ByVal i As Integer) As Double
        Return 1.0
    End Function
    Function ProcessWithSideEffects(ByVal i As Integer) As Double
        Return 1.0
    End Function

    Sub IntroTopic_DOP()
        Dim source = Enumerable.Range(1, 10000)
        '<snippet5>
        Dim query = From item In source.AsParallel().WithDegreeOfParallelism(2)
                    Where Compute(item) > 42
                    Select item
        '</snippet5>
    End Sub

    Sub IntroTopic_OptIntoOrdering()

        Dim numbers = Enumerable.Range(0, 1000)
        '<snippet3>
        Dim evenNums = From num In numbers.AsParallel().AsOrdered()
                       Where num Mod 2 = 0
                       Select num


        '</snippet3>
    End Sub

    Sub ForAllOperator()

        Dim concurrentBag As New ConcurrentBag(Of Integer)

        '<snippet4>
        Dim nums = Enumerable.Range(10, 10000)
        Dim query = From num In nums.AsParallel()
                    Where num Mod 10 = 0
                    Select num

        ' Process the results as each thread completes
        ' and add them to a System.Collections.Concurrent.ConcurrentBag(Of Int)
        ' which can safely accept concurrent add operations
        query.ForAll(Sub(e) concurrentBag.Add(Compute(e)))
        '</snippet4>
    End Sub

    Sub OrderPreservation()
        Dim cities() = {New City}
        Dim people() = {New Person}

        'Order Preservation In PLINQ 1st snippet
        '<snippet8>
        Dim cityQuery = From city In cities.AsParallel()
                        Where city.Population > 10000
                        Take (1000)
        '</snippet8>


        'Order Preservation In PLINQ 2nd snippet
        '<snippet9>
        Dim orderedCities = From city In cities.AsParallel().AsOrdered()
                            Where city.Population > 10000
                            Take (1000)
        '</snippet9>

        '<snippet6>
        Dim orderedCities2 = From city In cities.AsParallel().AsOrdered()
                             Where city.Population > 10000
                             Select city
                             Take (1000)

        Dim finalResult = From city In orderedCities2.AsUnordered()
                          Join p In people.AsParallel() On city.Name Equals p.CityName
                          Select New With {.Name = city.Name, .Pop = city.Population, .Mayor = city.Mayor}

        For Each city In finalResult
            Console.WriteLine(city.Name & ":" & city.Pop & ":" & city.Mayor)
        Next

        '</snippet6>

        '<snippet7>
        Dim orderedCities3 = From city In cities.AsParallel()
                             Where city.Population > 10000
                             Order By city.Name
                             Take (1000)
        '</snippet7>

    End Sub
    Class City
        Public Name As String
        Public Population As Integer
        Public Mayor As String
    End Class

    Class Person
        Public Name As String
        Public CityName As String
    End Class

    Class Customer
        Public Orders() As Order
    End Class

    Class Order
        Public amount As Double
        Public OrderDate As DateTime
    End Class


    Function ExpensiveFunc(ByVal I As Integer) As Double 'dummy
        Return 1.0
    End Function

    Sub MergeOptions()
        Dim nums = Enumerable.Range(0, 1000)
        '<snippet26>
        Dim scanlines = From n In nums.AsParallel().WithMergeOptions(ParallelMergeOptions.NotBuffered)
                        Where n Mod 2 = 0
                        Select ExpensiveFunc(n)

        '</snippet26>
    End Sub

    Sub OverParallelization()
        Dim customers() = {New Customer}
        Dim aDate = DateTime.Now
        '<snippet20>
        Dim q = From cust In customers.AsParallel()
                From order In cust.Orders.AsParallel()
                Where order.OrderDate > aDate
                Select New With {cust, order}

        '</snippet20>
    End Sub

    '<snippet23>
    Class MergeOptions2
        Sub DoMergeOptions()

            Dim nums = Enumerable.Range(1, 10000)

            ' Replace NotBuffered with AutoBuffered
            ' or FullyBuffered to compare behavior.
            Dim scanLines = From n In nums.AsParallel().WithMergeOptions(ParallelMergeOptions.NotBuffered)
                            Where n Mod 2 = 0
                            Select ExpensiveFunc(n)

            Dim sw = Stopwatch.StartNew()
            For Each line In scanLines
                Console.WriteLine(line)
            Next

            Console.WriteLine("Elapsed time: {0} ms. Press any key to exit.")
            Console.ReadKey()

        End Sub
        ' A function that demonstrates what a fly
        ' sees when it watches television :-)
        Function ExpensiveFunc(ByVal i As Integer) As String
            Threading.Thread.SpinWait(2000000)
            Return String.Format("{0} *****************************************", i)
        End Function
    End Class
    '</snippet23>
End Module
