'<Snippet1>
Imports System
Imports System.Text
Imports System.Timers
Imports System.Threading
Imports Microsoft.Win32
Imports System.Reflection
Imports System.Diagnostics
Imports System.Globalization



Public Class PerfCounter1


    <STAThread()> _
    Public Shared Sub Main(ByVal args() As String)
        Try
            If (Not PerformanceCounterCategory.Exists("Orders")) Then
                ' If the category does not exist, create the category and exit.
                ' Performance counters should not be created and immediately used.
                ' There is a latency time to enable the counters, they should be created
                ' prior to executing the application that uses the counters.

                ' Create custom counters.
                Writer.CreateCounters()
                Return
            End If
            Dim server As New Writer()
            ' Start the counters.
            server.StartCounters()
            Dim client As New Reader()
            ' Read the counters from the client.
            client.StartCounters()
            server.CloseTimer()
            client.Finish()
            Writer.DeleteCounters()
            Console.WriteLine("Press any key to exit.")
            Console.Read()

        Catch e As Exception
            Console.WriteLine("Sample failed with exception: " + e.ToString())
        End Try

    End Sub 'Main


    Public Class Writer
        Private timer1 As System.Timers.Timer
        Private counter1 As PerformanceCounter
        Private counter2 As PerformanceCounter
        Private counter3 As PerformanceCounter
        Private counter4 As PerformanceCounter
        Private finalCount As Integer


        Public Sub New()
            Me.timer1 = New System.Timers.Timer(100)
            Me.finalCount = 0
            AddHandler timer1.Elapsed, AddressOf Me.OnTimer1

        End Sub 'New

        '<Snippet4>
        Public Shared Sub CreateCounters()
            '<Snippet2>
            Dim data1 As New CounterCreationData("Trucks", "Number of orders", PerformanceCounterType.NumberOfItems32)
            Dim data2 As New CounterCreationData("Rate of sales", "Orders/second", PerformanceCounterType.RateOfCountsPerSecond32)
            Dim ccds As New CounterCreationDataCollection()
            ccds.Add(data1)
            ccds.Add(data2)
            Console.WriteLine("Creating Orders custom counter.")
            If Not PerformanceCounterCategory.Exists("Orders") Then
                PerformanceCounterCategory.Create("Orders", "Processed orders", PerformanceCounterCategoryType.MultiInstance, ccds)
            End If
            '</Snippet2>
            '<Snippet3>
            Console.WriteLine("Creating Inventory custom counter")
            If Not PerformanceCounterCategory.Exists("Inventory") Then
                PerformanceCounterCategory.Create("Inventory", "Truck inventory", PerformanceCounterCategoryType.SingleInstance, "Trucks", "Number of trucks on hand")
            End If
            '</Snippet3>

        End Sub 'CreateCounters
        '</Snippet4>


        Public Sub StartCounters()
            Console.WriteLine("Instantiating Custom Counter Orders, Trucks, United States")
            Me.counter1 = New PerformanceCounter("Orders", "Trucks", "United States", False)
            Me.counter1.RawValue = 5
            Console.WriteLine("Instantiating Custom Counter Orders, Trucks, Europe")
            Me.counter2 = New PerformanceCounter("Orders", "Trucks", "Europe", False)
            Me.counter2.RawValue = 10
            Console.WriteLine("Instantiating Custom Counter Orders, Rate of Sales, Total")
            Me.counter3 = New PerformanceCounter("Orders", "Rate of Sales", "Total", False)
            Me.counter3.RawValue = 10
            Console.WriteLine("Instantiating Custom Counter Inventory, Trucks")
            Me.counter4 = New PerformanceCounter("Inventory", "Trucks", False)
            Me.counter4.RawValue = 15

            Me.timer1.Start()

        End Sub 'StartCounters


        Public Sub CloseTimer()
            Me.timer1.Close()

        End Sub 'CloseTimer


        Public Shared Sub DeleteCounters()
            Try
                PerformanceCounterCategory.Delete("Orders")
                PerformanceCounterCategory.Delete("Inventory")
            Catch e As Exception
                Console.WriteLine(e.ToString())
            End Try

        End Sub 'DeleteCounters


        Private Sub OnTimer1(ByVal sender As Object, ByVal args As ElapsedEventArgs)
            Try
                Me.counter1.IncrementBy(100)
                Me.counter1.Increment()
                Me.counter2.IncrementBy(50)
                Me.counter2.Decrement()
                Me.counter3.IncrementBy(1)
                Me.counter4.IncrementBy(150)
                Me.finalCount += 1
            Catch e As Exception
                Console.WriteLine("Unexpected exception thrown :" + e.ToString())
            End Try

        End Sub 'OnTimer1
    End Class 'Writer


    Public Class Reader
        Private signal As ManualResetEvent
        Private timer1 As System.Timers.Timer
        Private counter1 As PerformanceCounter
        Private counter2 As PerformanceCounter
        Private counter3 As PerformanceCounter
        Private counter4 As PerformanceCounter
        Private finalCount As Integer


        Public Sub New()
            signal = New ManualResetEvent(False)
            Me.timer1 = New System.Timers.Timer(500)
            Me.finalCount = 0
            AddHandler timer1.Elapsed, AddressOf Me.OnTimer1

        End Sub 'New


        Public Sub Finish()
            Me.signal.WaitOne()
            Me.timer1.Close()
            PerformanceCounter.CloseSharedResources()

        End Sub 'Finish


        Private Sub OnTimer1(ByVal sender As Object, ByVal args As ElapsedEventArgs)
            Try
                SyncLock Me
                    If Me.finalCount >= 10 Then
                        Return
                    End If
                    Dim value1 As Single = Me.counter1.NextValue()
                    Console.WriteLine("Custom Counter Orders, Trucks, United States: {0}", value1.ToString())

                    Dim value2 As Single = Me.counter2.NextValue()
                    Console.WriteLine("Custom Counter Orders, Trucks, Europe: {0}", value2.ToString())

                    Dim value3 As Single = Me.counter3.NextValue()
                    Console.WriteLine("Custom Counter Orders, Rate of sales, United Total: {0}", value3.ToString())

                    Dim value4 As Single = Me.counter4.NextValue()
                    Console.WriteLine("Custom Counter Inventory, Trucks, United States: {0}", value4.ToString())

                    If Me.finalCount < 5 Then
                        Me.finalCount += 1
                    Else
                        Me.finalCount += 1
                        Me.signal.Set()
                    End If
                End SyncLock
            Catch e As Exception
                Console.WriteLine("Sample failure :" + e.ToString())
                Me.signal.Set()
            End Try

        End Sub 'OnTimer1


        Public Sub StartCounters()
            Console.WriteLine("Instantiating Custom Counter Orders, Trucks, United States")
            ' Instantiate a counter, category "Orders, counter name "Trucks", instance "United States"
            Me.counter1 = New PerformanceCounter("Orders", "Trucks", "United States")
            Console.WriteLine("Instantiating Custom Counter Orders, Trucks, Europe")
            ' Instantiate a counter, category "Orders, counter name "Trucks", instance "Europe"
            Me.counter2 = New PerformanceCounter("Orders", "Trucks", "Europe")
            Console.WriteLine("Instantiating Custom Counter Orders, Rate of Sales.")
            ' Instantiate a counter, category "Orders", counter name "Rate of Sales", single instance.
            Me.counter3 = New PerformanceCounter("Orders", "Rate of Sales", "Total")
            Console.WriteLine("Instantiating Custom Counter Inventory, Trucks, Only instance.")
            ' Instantiate a single instance counter, category "Inventory", counter name "Trucks".
            Me.counter4 = New PerformanceCounter("Inventory", "Trucks", False)

            Me.timer1.Start()

        End Sub 'StartCounters
    End Class 'Reader
End Class 'PerfCounter1
'</Snippet1>
