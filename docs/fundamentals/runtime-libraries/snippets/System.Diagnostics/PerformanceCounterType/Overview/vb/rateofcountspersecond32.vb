'<snippet1>
Imports System.Collections
Imports System.Collections.Specialized
Imports System.Diagnostics
Imports System.Runtime.Versioning

<SupportedOSPlatform("Windows")>
Public Class App4
    Private Shared PC As PerformanceCounter


    Public Shared Sub Main()
        Dim samplesList As New ArrayList()

        'If the category does not exist, create the category and exit.
        'Performance counters should not be created and immediately used.
        'There is a latency time to enable the counters, they should be created
        'prior to executing the App4lication that uses the counters.
        'Execute this sample a second time to use the counters.
        If Not (SetupCategory()) Then
            CreateCounters()
            CollectSamples(samplesList)
            CalculateResults(samplesList)
        End If
    End Sub


    Private Shared Function SetupCategory() As Boolean

        If Not PerformanceCounterCategory.Exists("RateOfCountsPerSecond32SampleCategory") Then


            Dim CCDC As New CounterCreationDataCollection()

            ' Add the counter.
            Dim rateOfCounts32 As New CounterCreationData()
            rateOfCounts32.CounterType = PerformanceCounterType.RateOfCountsPerSecond32
            rateOfCounts32.CounterName = "RateOfCountsPerSecond32Sample"
            CCDC.Add(rateOfCounts32)

            ' Create the category.
            PerformanceCounterCategory.Create("RateOfCountsPerSecond32SampleCategory", _
                "Demonstrates usage of the RateOfCountsPerSecond32 performance counter type.", _
                PerformanceCounterCategoryType.SingleInstance, CCDC)
            Return True
        Else
            Console.WriteLine("Category exists - RateOfCountsPerSecond32SampleCategory")
            Return False
        End If
    End Function 'SetupCategory


    Private Shared Sub CreateCounters()
        ' Create the counter.
        PC = New PerformanceCounter("RateOfCountsPerSecond32SampleCategory", "RateOfCountsPerSecond32Sample", False)

        PC.RawValue = 0
    End Sub


    Private Shared Sub CollectSamples(ByVal samplesList As ArrayList)

        Dim r As New Random(DateTime.Now.Millisecond)

        ' Initialize the performance counter.
        PC.NextSample()

        ' Loop for the samples.
        Dim j As Integer
        For j = 0 To 99

            Dim value As Integer = r.Next(1, 10)
            PC.IncrementBy(value)
            Console.Write((j.ToString() + " = " + value.ToString()))

            If j Mod 10 = 9 Then
                Console.WriteLine((";       NextValue() = " + PC.NextValue().ToString()))
                OutputSample(PC.NextSample())
                samplesList.Add(PC.NextSample())
            Else
                Console.WriteLine()
            End If
            System.Threading.Thread.Sleep(50)
        Next j
    End Sub


    Private Shared Sub CalculateResults(ByVal samplesList As ArrayList)
        Dim i As Integer
        For i = 0 To (samplesList.Count - 1) - 1
            ' Output the sample.
            OutputSample(CType(samplesList(i), CounterSample))
            OutputSample(CType(samplesList((i + 1)), CounterSample))


            ' Use .NET to calculate the counter value.
            Console.WriteLine(".NET computed counter value = " + CounterSampleCalculator.ComputeCounterValue(CType(samplesList(i), CounterSample), CType(samplesList((i + 1)), CounterSample)).ToString())

            ' Calculate the counter value manually.
            Console.WriteLine("My computed counter value = " + MyComputeCounterValue(CType(samplesList(i), CounterSample), CType(samplesList((i + 1)), CounterSample)).ToString())
        Next i
    End Sub





    '++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++
    '	PERF_COUNTER_COUNTER
    '	Description	 - This counter type shows the average number of operations completed
    '		during each second of the sample interval. Counters of this type
    '		measure time in ticks of the system clock. The F variable represents
    '		the number of ticks per second. The value of F is factored into the
    '		equation so that the result can be displayed in seconds.
    '
    '	Generic type - Difference
    '
    '	Formula - (N1 - N0) / ( (D1 - D0) / F), where the numerator (N) represents the number
    '		of operations performed during the last sample interval, the denominator
    '		(D) represents the number of ticks elapsed during the last sample
    '		interval, and F is the frequency of the ticks.
    '
    '	     Average - (Nx - N0) / ((Dx - D0) / F) 
    '
    '       Example - System\ File Read Operations/sec 
    '++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++
    Private Shared Function MyComputeCounterValue(ByVal s0 As CounterSample, ByVal s1 As CounterSample) As [Single]
        Dim numerator As [Single] = CType(s1.RawValue - s0.RawValue, [Single])
        Dim denomenator As [Single] = CType(s1.TimeStamp - s0.TimeStamp, [Single]) / CType(s1.SystemFrequency, [Single])
        Dim counterValue As [Single] = numerator / denomenator
        Return counterValue
    End Function 'MyComputeCounterValue


    ' Output information about the counter sample.
    Private Shared Sub OutputSample(ByVal s As CounterSample)
        Console.WriteLine(ControlChars.Lf + ControlChars.Cr + "+++++++++++")
        Console.WriteLine("Sample values - " + ControlChars.Lf + ControlChars.Cr)
        Console.WriteLine(("   BaseValue        = " + s.BaseValue.ToString()))
        Console.WriteLine(("   CounterFrequency = " + s.CounterFrequency.ToString()))
        Console.WriteLine(("   CounterTimeStamp = " + s.CounterTimeStamp.ToString()))
        Console.WriteLine(("   CounterType      = " + s.CounterType.ToString()))
        Console.WriteLine(("   RawValue         = " + s.RawValue.ToString()))
        Console.WriteLine(("   SystemFrequency  = " + s.SystemFrequency.ToString()))
        Console.WriteLine(("   TimeStamp        = " + s.TimeStamp.ToString()))
        Console.WriteLine(("   TimeStamp100nSec = " + s.TimeStamp100nSec.ToString()))
        Console.WriteLine("++++++++++++++++++++++")
    End Sub
End Class

'</snippet1>
