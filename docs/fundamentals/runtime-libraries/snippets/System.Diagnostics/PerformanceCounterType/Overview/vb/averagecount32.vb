'<snippet1>
Imports System.Collections
Imports System.Collections.Specialized
Imports System.Diagnostics
Imports System.Runtime.Versioning

<SupportedOSPlatform("Windows")>
Public Class App1

    Private Shared avgCounter64Sample As PerformanceCounter
    Private Shared avgCounter64SampleBase As PerformanceCounter

    Public Shared Sub Main()

        Dim samplesList As New ArrayList()
        'If the category does not exist, create the category and exit.
        'Performance counters should not be created and immediately used.
        'There is a latency time to enable the counters, they should be created
        'prior to executing the App1lication that uses the counters.
        'Execute this sample a second time to use the counters.
        If Not (SetupCategory()) Then
            CreateCounters()
            CollectSamples(samplesList)
            CalculateResults(samplesList)
        End If

    End Sub

    Private Shared Function SetupCategory() As Boolean
        If Not PerformanceCounterCategory.Exists("AverageCounter64SampleCategory") Then

            Dim counterDataCollection As New CounterCreationDataCollection()

            ' Add the counter.
            Dim averageCount64 As New CounterCreationData()
            averageCount64.CounterType = PerformanceCounterType.AverageCount64
            averageCount64.CounterName = "AverageCounter64Sample"
            counterDataCollection.Add(averageCount64)

            ' Add the base counter.
            Dim averageCount64Base As New CounterCreationData()
            averageCount64Base.CounterType = PerformanceCounterType.AverageBase
            averageCount64Base.CounterName = "AverageCounter64SampleBase"
            counterDataCollection.Add(averageCount64Base)

            ' Create the category.
            PerformanceCounterCategory.Create("AverageCounter64SampleCategory",
               "Demonstrates usage of the AverageCounter64 performance counter type.",
                      PerformanceCounterCategoryType.SingleInstance, counterDataCollection)

            Return True
        Else
            Console.WriteLine("Category exists - AverageCounter64SampleCategory")
            Return False
        End If
    End Function 'SetupCategory

    Private Shared Sub CreateCounters()
        ' Create the counters.

        '<snippet2>
        avgCounter64Sample = New PerformanceCounter("AverageCounter64SampleCategory", "AverageCounter64Sample", False)
        '</snippet2>

        avgCounter64SampleBase = New PerformanceCounter("AverageCounter64SampleCategory", "AverageCounter64SampleBase", False)

        avgCounter64Sample.RawValue = 0
        avgCounter64SampleBase.RawValue = 0
    End Sub

    '<Snippet3>
    Private Shared Sub CollectSamples(ByVal samplesList As ArrayList)

        Dim r As New Random(DateTime.Now.Millisecond)

        ' Loop for the samples.
        Dim j As Integer
        For j = 0 To 99

            Dim value As Integer = r.Next(1, 10)
            Console.Write(j.ToString() + " = " + value.ToString())

            avgCounter64Sample.IncrementBy(value)

            avgCounter64SampleBase.Increment()

            If j Mod 10 = 9 Then
                OutputSample(avgCounter64Sample.NextSample())
                samplesList.Add(avgCounter64Sample.NextSample())
            Else
                Console.WriteLine()
            End If
            System.Threading.Thread.Sleep(50)
        Next j
    End Sub
    '</Snippet3>

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
    '	Description - This counter type shows how many items are processed, on average,
    '		during an operation. Counters of this type display a ratio of the items 
    '		processed (such as bytes sent) to the number of operations completed. The  
    '		ratio is calculated by comparing the number of items processed during the 
    '		last interval to the number of operations completed during the last interval. 
    ' Generic type - Average
    '  	Formula - (N1 - N0) / (D1 - D0), where the numerator (N) represents the number 
    '		of items processed during the last sample interval and the denominator (D) 
    '		represents the number of operations completed during the last two sample 
    '		intervals. 
    '	Average (Nx - N0) / (Dx - D0)  
    '	Example PhysicalDisk\ Avg. Disk Bytes/Transfer 
    '++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++
    Private Shared Function MyComputeCounterValue(ByVal s0 As CounterSample, ByVal s1 As CounterSample) As [Single]
        Dim numerator As [Single] = CType(s1.RawValue, [Single]) - CType(s0.RawValue, [Single])
        Dim denomenator As [Single] = CType(s1.BaseValue, [Single]) - CType(s0.BaseValue, [Single])
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
