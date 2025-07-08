'<snippet1>
Imports System.Collections
Imports System.Collections.Specialized
Imports System.Diagnostics
Imports System.Runtime.Versioning

<SupportedOSPlatform("Windows")>
Public Class App6
    Private Shared PC As PerformanceCounter
    Private Shared BPC As PerformanceCounter

    Public Shared Sub Main()
        Dim samplesList As New ArrayList()

        'If the category does not exist, create the category and exit.
        'Performance counters should not be created and immediately used.
        'There is a latency time to enable the counters, they should be created
        'prior to executing the App6lication that uses the counters.
        'Execute this sample a second time to use the counters.
        If Not (SetupCategory()) Then
            CreateCounters()
            CollectSamples(samplesList)
            CalculateResults(samplesList)
        End If

    End Sub

    Private Shared Function SetupCategory() As Boolean


        If Not PerformanceCounterCategory.Exists("RawFractionSampleCategory") Then


            Dim CCDC As New CounterCreationDataCollection()

            ' Add the counter.
            Dim rf As New CounterCreationData()
            rf.CounterType = PerformanceCounterType.RawFraction
            rf.CounterName = "RawFractionSample"
            CCDC.Add(rf)

            ' Add the base counter.
            Dim rfBase As New CounterCreationData()
            rfBase.CounterType = PerformanceCounterType.RawBase
            rfBase.CounterName = "RawFractionSampleBase"
            CCDC.Add(rfBase)

            ' Create the category.
            PerformanceCounterCategory.Create("RawFractionSampleCategory",
            "Demonstrates usage of the RawFraction performance counter type.",
                PerformanceCounterCategoryType.SingleInstance, CCDC)

            Return True
        Else
            Console.WriteLine("Category exists - RawFractionSampleCategory")
            Return False
        End If
    End Function 'SetupCategory


    Private Shared Sub CreateCounters()
        ' Create the counters.
        PC = New PerformanceCounter("RawFractionSampleCategory", "RawFractionSample", False)

        BPC = New PerformanceCounter("RawFractionSampleCategory", "RawFractionSampleBase", False)

        PC.RawValue = 0
        BPC.RawValue = 0
    End Sub


    Private Shared Sub CollectSamples(ByVal samplesList As ArrayList)

        Dim r As New Random(DateTime.Now.Millisecond)

        ' Initialize the performance counter.
        PC.NextSample()

        ' Loop for the samples.
        Dim j As Integer
        For j = 0 To 99
            Dim value As Integer = r.Next(1, 10)
            Console.Write((j.ToString() + " = " + value.ToString()))

            ' Increment the base every time, because the counter measures the number 
            ' of high hits (raw fraction value) against all the hits (base value).
            BPC.Increment()

            ' Get the % of samples that are 9 or 10 out of all the samples taken.
            If value >= 9 Then
                PC.Increment()
            End If
            ' Copy out the next value every ten times around the loop.
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
        For i = 0 To samplesList.Count - 1
            ' Output the sample.
            OutputSample(CType(samplesList(i), CounterSample))

            ' Use .NET to calculate the counter value.
            Console.WriteLine(".NET computed counter value = " + CounterSampleCalculator.ComputeCounterValue(CType(samplesList(i), CounterSample)).ToString())

            ' Calculate the counter value manually.
            Console.WriteLine("My computed counter value = " + MyComputeCounterValue(CType(samplesList(i), CounterSample)).ToString())
        Next i
    End Sub


    '++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++
    ' Formula from MSDN -
    '      Description - This counter type shows the ratio of a subset to its set as a percentage.
    '			For example, it compares the number of bytes in use on a disk to the
    '			total number of bytes on the disk. Counters of this type display the 
    '			current percentage only, not an average over time.
    '
    ' Generic type - Instantaneous, Percentage 
    '	    Formula - (N0 / D0), where D represents a measured attribute and N represents one
    '			component of that attribute.
    '
    '		Average - SUM (N / D) /x 
    '		Example - Paging File\% Usage Peak
    '++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++
    Private Shared Function MyComputeCounterValue(ByVal rfSample As CounterSample) As [Single]
        Dim numerator As [Single] = CType(rfSample.RawValue, [Single])
        Dim denomenator As [Single] = CType(rfSample.BaseValue, [Single])
        Dim counterValue As [Single] = numerator / denomenator * 100
        Return counterValue
    End Function 'MyComputeCounterValue


    ' Output information about the counter sample.
    Private Shared Sub OutputSample(ByVal s As CounterSample)
        Console.WriteLine("+++++++++++")
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
