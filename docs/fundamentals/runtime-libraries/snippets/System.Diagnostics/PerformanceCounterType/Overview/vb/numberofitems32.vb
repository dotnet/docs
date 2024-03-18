'<snippet1>
Imports System.Collections
Imports System.Collections.Specialized
Imports System.Diagnostics
Imports System.Runtime.Versioning

<SupportedOSPlatform("Windows")>
Public Class NumberOfItems64

    Private Shared PC As PerformanceCounter


    Public Shared Sub Main()
        Dim samplesList As New ArrayList()
        'If the category does not exist, create the category and exit.
        'Performance counters should not be created and immediately used.
        'There is a latency time to enable the counters, they should be created
        'prior to executing the application that uses the counters.
        'Execute this sample a second time to use the counters.
        If Not (SetupCategory()) Then
            CreateCounters()
            CollectSamples(samplesList)
            CalculateResults(samplesList)
        End If
    End Sub


    Private Shared Function SetupCategory() As Boolean
        If Not PerformanceCounterCategory.Exists("NumberOfItems32SampleCategory") Then

            Dim CCDC As New CounterCreationDataCollection()

            ' Add the counter.
            Dim NOI64 As New CounterCreationData()
            NOI64.CounterType = PerformanceCounterType.NumberOfItems64
            NOI64.CounterName = "NumberOfItems32Sample"
            CCDC.Add(NOI64)

            ' Create the category.
            PerformanceCounterCategory.Create("NumberOfItems32SampleCategory", _
            "Demonstrates usage of the NumberOfItems32 performance counter type.", _
                      PerformanceCounterCategoryType.SingleInstance, CCDC)

            Return True
        Else
            Console.WriteLine("Category exists - NumberOfItems32SampleCategory")
            Return False
        End If
    End Function 'SetupCategory


    Private Shared Sub CreateCounters()
        ' Create the counter.
        PC = New PerformanceCounter("NumberOfItems32SampleCategory", "NumberOfItems32Sample", False)

        PC.RawValue = 0
    End Sub


    Private Shared Sub CollectSamples(ByVal samplesList As ArrayList)



        Dim r As New Random(DateTime.Now.Millisecond)

        ' Loop for the samples.
        Dim j As Integer
        For j = 0 To 99

            Dim value As Integer = r.Next(1, 10)
            Console.Write(j.ToString() + " = " + value.ToString())

            PC.IncrementBy(value)

            If j Mod 10 = 9 Then
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
    '++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++
    Private Shared Function MyComputeCounterValue(ByVal s0 As CounterSample, ByVal s1 As CounterSample) As [Single]
        Dim counterValue As [Single] = s1.RawValue
        Return counterValue
    End Function 'MyComputeCounterValue


    ' Output information about the counter sample.
    Private Shared Sub OutputSample(ByVal s As CounterSample)
        Console.WriteLine(ControlChars.Lf + ControlChars.Cr + "+++++++++++")
        Console.WriteLine("Sample values - " + ControlChars.Lf + ControlChars.Cr)
        Console.WriteLine("   BaseValue        = " + s.BaseValue.ToString())
        Console.WriteLine("   CounterFrequency = " + s.CounterFrequency.ToString())
        Console.WriteLine("   CounterTimeStamp = " + s.CounterTimeStamp.ToString())
        Console.WriteLine("   CounterType      = " + s.CounterType.ToString())
        Console.WriteLine("   RawValue         = " + s.RawValue.ToString())
        Console.WriteLine("   SystemFrequency  = " + s.SystemFrequency.ToString())
        Console.WriteLine("   TimeStamp        = " + s.TimeStamp.ToString())
        Console.WriteLine("   TimeStamp100nSec = " + s.TimeStamp100nSec.ToString())
        Console.WriteLine("++++++++++++++++++++++")
    End Sub
End Class


'</snippet1>
