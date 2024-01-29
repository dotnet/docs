'<Snippet1>
Imports System.Collections
Imports System.Collections.Specialized
Imports System.Diagnostics
Imports System.Runtime.Versioning


' Provides a SampleFraction counter to measure the percentage of the user processor 
' time for this process to total processor time for the process.

<SupportedOSPlatform("Windows")>
Public Class App3

    Private Shared perfCounter As PerformanceCounter
    Private Shared basePerfCounter As PerformanceCounter
    Private Shared thisProcess As Process = Process.GetCurrentProcess()


    Public Shared Sub Main()

        Dim samplesList As New ArrayList()

        ' If the category does not exist, create the category and exit.
        ' Performance counters should not be created and immediately used.
        ' There is a latency time to enable the counters, they should be created
        ' prior to executing the application that uses the counters.
        ' Execute this sample a second time to use the category.
        If SetupCategory() Then
            Return
        End If
        CreateCounters()
        CollectSamples(samplesList)
        CalculateResults(samplesList)

    End Sub



    Private Shared Function SetupCategory() As Boolean
        If Not PerformanceCounterCategory.Exists("SampleFractionCategory") Then

            Dim CCDC As New CounterCreationDataCollection()

            ' Add the counter.
            Dim sampleFraction As New CounterCreationData()
            sampleFraction.CounterType = PerformanceCounterType.SampleFraction
            sampleFraction.CounterName = "SampleFractionSample"
            CCDC.Add(sampleFraction)

            ' Add the base counter.
            Dim sampleFractionBase As New CounterCreationData()
            sampleFractionBase.CounterType = PerformanceCounterType.SampleBase
            sampleFractionBase.CounterName = "SampleFractionSampleBase"
            CCDC.Add(sampleFractionBase)

            ' Create the category.
            PerformanceCounterCategory.Create("SampleFractionCategory", "Demonstrates usage of the SampleFraction performance counter type.", PerformanceCounterCategoryType.SingleInstance, CCDC)

            Return True
        Else
            Console.WriteLine("Category exists - SampleFractionCategory")
            Return False
        End If

    End Function 'SetupCategory


    Private Shared Sub CreateCounters()
        ' Create the counters.
        perfCounter = New PerformanceCounter("SampleFractionCategory", "SampleFractionSample", False)


        basePerfCounter = New PerformanceCounter("SampleFractionCategory", "SampleFractionSampleBase", False)


        perfCounter.RawValue = thisProcess.UserProcessorTime.Ticks
        basePerfCounter.RawValue = thisProcess.TotalProcessorTime.Ticks

    End Sub

    Private Shared Sub CollectSamples(ByVal samplesList As ArrayList)


        ' Loop for the samples.
        Dim j As Integer
        For j = 0 To 99

            perfCounter.IncrementBy(thisProcess.UserProcessorTime.Ticks)

            basePerfCounter.IncrementBy(thisProcess.TotalProcessorTime.Ticks)

            If j Mod 10 = 9 Then
                OutputSample(perfCounter.NextSample())
                samplesList.Add(perfCounter.NextSample())
            Else
                Console.WriteLine()
            End If
            System.Threading.Thread.Sleep(50)
        Next j

    End Sub


    Private Shared Sub CalculateResults(ByVal samplesList As ArrayList)
        Dim i As Integer
        For i = 0 To (samplesList.Count - 1)
            ' Output the sample.
            OutputSample(CType(samplesList(i), CounterSample))
            OutputSample(CType(samplesList((i + 1)), CounterSample))

            ' Use .NET to calculate the counter value.
            Console.WriteLine(".NET computed counter value = " + CounterSampleCalculator.ComputeCounterValue(CType(samplesList(i), CounterSample), CType(samplesList((i + 1)), CounterSample)))

            ' Calculate the counter value manually.
            Console.WriteLine("My computed counter value = " + MyComputeCounterValue(CType(samplesList(i), CounterSample), CType(samplesList((i + 1)), CounterSample)))
        Next i

    End Sub




    '++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++
    ' Description - This counter type provides A percentage counter that shows the 
    ' average ratio of user proccessor time to total processor time  during the last 
    ' two sample intervals.
    '++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++
    Private Shared Function MyComputeCounterValue(ByVal s0 As CounterSample, ByVal s1 As CounterSample) As [Single]
        Dim numerator As [Single] = CType(s1.RawValue, [Single]) - CType(s0.RawValue, [Single])
        Dim denomenator As [Single] = CType(s1.BaseValue, [Single]) - CType(s0.BaseValue, [Single])
        Dim counterValue As [Single] = 100 * (numerator / denomenator)
        Return counterValue

    End Function 'MyComputeCounterValue


    ' Output information about the counter sample.
    Private Shared Sub OutputSample(ByVal s As CounterSample)
        Console.WriteLine(vbCr + vbLf + "+++++++++++")
        Console.WriteLine("Sample values - " + vbCr + vbLf)
        Console.WriteLine("   BaseValue        = " + s.BaseValue)
        Console.WriteLine("   CounterFrequency = " + s.CounterFrequency)
        Console.WriteLine("   CounterTimeStamp = " + s.CounterTimeStamp)
        Console.WriteLine("   CounterType      = " + s.CounterType)
        Console.WriteLine("   RawValue         = " + s.RawValue)
        Console.WriteLine("   SystemFrequency  = " + s.SystemFrequency)
        Console.WriteLine("   TimeStamp        = " + s.TimeStamp)
        Console.WriteLine("   TimeStamp100nSec = " + s.TimeStamp100nSec)
        Console.WriteLine("++++++++++++++++++++++")

    End Sub
End Class
'</Snippet1>
