' Notice that the sample is conditionally compiled for Everett vs.
' Whidbey builds.  Whidbey introduced new APIs that are not available
' in Everett.  Snippet IDs do not overlap between Whidbey and Everett;
' Snippet #1 is Everett, Snippet #2 and #3 are Whidbey.

#If BELOW_WHIDBEY_BUILD Then

'<snippet1>
Imports System.Collections
Imports System.Collections.Specialized
Imports System.Diagnostics
Imports System.Runtime.InteropServices
    
Public Class App

   Private Shared PC As PerformanceCounter
   Private Shared BPC As PerformanceCounter


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

      If Not PerformanceCounterCategory.Exists("AverageTimer32SampleCategory") Then

         Dim CCDC As New CounterCreationDataCollection()

         ' Add the counter.
         Dim averageTimer32 As New CounterCreationData()
         averageTimer32.CounterType = PerformanceCounterType.AverageTimer32
         averageTimer32.CounterName = "AverageTimer32Sample"
         CCDC.Add(averageTimer32)

         ' Add the base counter.
         Dim averageTimer32Base As New CounterCreationData()
         averageTimer32Base.CounterType = PerformanceCounterType.AverageBase
         averageTimer32Base.CounterName = "AverageTimer32SampleBase"
         CCDC.Add(averageTimer32Base)

         ' Create the category.
         PerformanceCounterCategory.Create( _
            "AverageTimer32SampleCategory", _
            "Demonstrates usage of the AverageTimer32 performance counter type", _
                   PerformanceCounterCategoryType.SingleInstance, CCDC)

         Return True
      Else
         Console.WriteLine(("Category exists - " + _
            "AverageTimer32SampleCategory"))
         Return False
      End If
   End Function 


   Private Shared Sub CreateCounters()
      ' Create the counters.
      PC = New PerformanceCounter("AverageTimer32SampleCategory", _
            "AverageTimer32Sample", False)

      BPC = New PerformanceCounter("AverageTimer32SampleCategory", _
            "AverageTimer32SampleBase", False)

      PC.RawValue = 0
      BPC.RawValue = 0
   End Sub 


   Private Shared Sub CollectSamples(samplesList As ArrayList)

      Dim perfTime As Long = 0
      Dim r As New Random(DateTime.Now.Millisecond)

      ' Loop for the samples.
      Dim i As Integer
      For i = 0 To 9

         QueryPerformanceCounter(perfTime)
         PC.RawValue = perfTime

         BPC.IncrementBy(10)

         System.Threading.Thread.Sleep(1000)
         Console.WriteLine(("Next value = " + PC.NextValue().ToString()))
         samplesList.Add(PC.NextSample())
      Next i
   End Sub 


   Private Shared Sub CalculateResults(samplesList As ArrayList)
      Dim i As Integer
      Dim sample1 As CounterSample
      Dim sample2 As CounterSample
      For i = 0 To (samplesList.Count - 1) - 1
         ' Output the sample.
         sample1 = CType(samplesList(i), CounterSample)
         sample2 = CType(samplesList(i+1), CounterSample)
         OutputSample(sample1)
         OutputSample(sample2)

         ' Use .NET to calculate the counter value.
         Console.WriteLine((".NET computed counter value = " _
            + CounterSample.Calculate(sample1, sample2).ToString()))

         ' Calculate the counter value manually.
         Console.WriteLine(("My computed counter value = " _
            + MyComputeCounterValue(sample1, sample2).ToString()))

      Next i
   End Sub


  '++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//+++++++
  ' PERF_AVERAGE_TIMER
  '  Description - This counter type measures the time it takes, on 
  '     average, to complete a process or operation. Counters of this
  '     type display a ratio of the total elapsed time of the sample 
  '     interval to the number of processes or operations completed
  '     during that time. This counter type measures time in ticks 
  '     of the system clock. The F variable represents the number of
  '     ticks per second. The value of F is factored into the equation
  '     so that the result can be displayed in seconds.
  '
  '  Generic type - Average
  '
  '  Formula - ((N1 - N0) / F) / (D1 - D0), where the numerator (N)
  '     represents the number of ticks counted during the last 
  '     sample interval, F represents the frequency of the ticks, 
  '     and the denominator (D) represents the number of operations
  '     completed during the last sample interval.
  '
  '  Average - ((Nx - N0) / F) / (Dx - D0)
  '
  '  Example - PhysicalDisk\ Avg. Disk sec/Transfer 
  '++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//+++++++
   Private Shared Function MyComputeCounterValue( _
                                    s0 As CounterSample, _
                                    s1 As CounterSample) As Single
      Dim n1 As Int64 = s1.RawValue
      Dim n0 As Int64 = s0.RawValue
      Dim f As Decimal = CType(s1.SystemFrequency, Decimal)
      Dim d1 As Int64 = s1.BaseValue
      Dim d0 As Int64 = s0.BaseValue

      Dim numerator As Double = System.Convert.ToDouble(n1 - n0)
      Dim denominator As Double = System.Convert.ToDouble(d1 - d0)
      Dim counterValue As Single = CType(numerator, Single)
      counterValue = counterValue / CType(f, Single)
      counterValue = counterValue / CType(denominator, Single)

      Return counterValue
   End Function 


   ' Output information about the counter sample.
   Private Shared Sub OutputSample(s As CounterSample)
      Console.WriteLine("+++++++++++")
      Console.WriteLine("Sample values - " + ControlChars.Cr _
            + ControlChars.Lf)
      Console.WriteLine(("   BaseValue        = " _
            + s.BaseValue.ToString()))
      Console.WriteLine(("   CounterFrequency = " + _
            s.CounterFrequency.ToString()))
      Console.WriteLine(("   CounterTimeStamp = " + _
            s.CounterTimeStamp.ToString()))
      Console.WriteLine(("   CounterType      = " + _
            s.CounterType.ToString()))
      Console.WriteLine(("   RawValue         = " + _
            s.RawValue.ToString()))
      Console.WriteLine(("   SystemFrequency  = " + _
            s.SystemFrequency.ToString()))
      Console.WriteLine(("   TimeStamp        = " + _
            s.TimeStamp.ToString()))
      Console.WriteLine(("   TimeStamp100nSec = " + _
            s.TimeStamp100nSec.ToString()))
      Console.WriteLine("++++++++++++++++++++++")
   End Sub

   <DllImport("Kernel32.dll")>  _
   Public Shared Function _
        QueryPerformanceCounter(ByRef value As Long) As Boolean
   End Function

End Class

'</snippet1>

#Else

'<snippet2>
Imports System.Collections
Imports System.Collections.Specialized
Imports System.Diagnostics
Imports System.Runtime.InteropServices
Imports System.Runtime.Versioning

<SupportedOSPlatform("Windows")>
Public Class App

    Private Const categoryName As String = "AverageTimer32SampleCategory"
    Private Const counterName As String = "AverageTimer32Sample"
    Private Const baseCounterName As String = "AverageTimer32SampleBase"

    Private Shared PC As PerformanceCounter
    Private Shared BPC As PerformanceCounter


    Public Shared Sub Main()
        Dim samplesList As New ArrayList()

        SetupCategory()
        CreateCounters()
        CollectSamples(samplesList)
        CalculateResults(samplesList)
    End Sub


    Private Shared Function SetupCategory() As Boolean

        If Not PerformanceCounterCategory.Exists(categoryName) Then

            Dim CCDC As New CounterCreationDataCollection()

            ' Add the counter.
            Dim averageTimer32 As New CounterCreationData()
            averageTimer32.CounterType = PerformanceCounterType.AverageTimer32
            averageTimer32.CounterName = counterName
            CCDC.Add(averageTimer32)

            ' Add the base counter.
            Dim averageTimer32Base As New CounterCreationData()
            averageTimer32Base.CounterType = PerformanceCounterType.AverageBase
            averageTimer32Base.CounterName = baseCounterName
            CCDC.Add(averageTimer32Base)

            ' Create the category.
            PerformanceCounterCategory.Create( _
               categoryName, _
               "Demonstrates usage of the AverageTimer32 performance counter type", _
                 PerformanceCounterCategoryType.SingleInstance, CCDC)

            Console.WriteLine("Category created - " + categoryName)

            Return True
        Else
            Console.WriteLine(("Category exists - " + _
               categoryName))
            Return False
        End If
    End Function


    Private Shared Sub CreateCounters()
        ' Create the counters.
        PC = New PerformanceCounter(categoryName, _
              counterName, False)

        BPC = New PerformanceCounter(categoryName, _
              baseCounterName, False)

        PC.RawValue = 0
        BPC.RawValue = 0
    End Sub


    Private Shared Sub CollectSamples(ByVal samplesList As ArrayList)

        Dim r As New Random(DateTime.Now.Millisecond)

        ' Loop for the samples.
        Dim i As Integer
        For i = 0 To 9

            PC.RawValue = Stopwatch.GetTimeStamp()

            BPC.IncrementBy(10)

            System.Threading.Thread.Sleep(1000)
            Console.WriteLine(("Next value = " + PC.NextValue().ToString()))
            samplesList.Add(PC.NextSample())
        Next i
    End Sub


    Private Shared Sub CalculateResults(ByVal samplesList As ArrayList)
        Dim i As Integer
        Dim sample1 As CounterSample
        Dim sample2 As CounterSample
        For i = 0 To (samplesList.Count - 1) - 1
            ' Output the sample.
            sample1 = CType(samplesList(i), CounterSample)
            sample2 = CType(samplesList(i + 1), CounterSample)
            OutputSample(sample1)
            OutputSample(sample2)

            ' Use .NET to calculate the counter value.
            Console.WriteLine((".NET computed counter value = " _
               + CounterSample.Calculate(sample1, sample2).ToString()))

            ' Calculate the counter value manually.
            Console.WriteLine(("My computed counter value = " _
               + MyComputeCounterValue(sample1, sample2).ToString()))

        Next i
    End Sub


    '++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//+++++++
    ' PERF_AVERAGE_TIMER
    '  Description - This counter type measures the time it takes, on 
    '     average, to complete a process or operation. Counters of this
    '     type display a ratio of the total elapsed time of the sample 
    '     interval to the number of processes or operations completed
    '     during that time. This counter type measures time in ticks 
    '     of the system clock. The F variable represents the number of
    '     ticks per second. The value of F is factored into the equation
    '     so that the result can be displayed in seconds.
    '
    '  Generic type - Average
    '
    '  Formula - ((N1 - N0) / F) / (D1 - D0), where the numerator (N)
    '     represents the number of ticks counted during the last 
    '     sample interval, F represents the frequency of the ticks, 
    '     and the denominator (D) represents the number of operations
    '     completed during the last sample interval.
    '
    '  Average - ((Nx - N0) / F) / (Dx - D0)
    '
    '  Example - PhysicalDisk\ Avg. Disk sec/Transfer 
    '++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//+++++++
    Private Shared Function MyComputeCounterValue( _
    ByVal s0 As CounterSample, _
    ByVal s1 As CounterSample) As Single
        Dim n1 As Int64 = s1.RawValue
        Dim n0 As Int64 = s0.RawValue
        Dim f As Decimal = CType(s1.SystemFrequency, Decimal)
        Dim d1 As Int64 = s1.BaseValue
        Dim d0 As Int64 = s0.BaseValue

        Dim numerator As Double = System.Convert.ToDouble(n1 - n0)
        Dim denominator As Double = System.Convert.ToDouble(d1 - d0)
        Dim counterValue As Single = CType(numerator, Single)
        counterValue = counterValue / CType(f, Single)
        counterValue = counterValue / CType(denominator, Single)

        Return counterValue
    End Function


    ' Output information about the counter sample.
    Private Shared Sub OutputSample(ByVal s As CounterSample)
        Console.WriteLine("+++++++++++")
        Console.WriteLine("Sample values - " + ControlChars.Cr _
              + ControlChars.Lf)
        Console.WriteLine(("   CounterType      = " + _
              s.CounterType.ToString()))
        Console.WriteLine(("   RawValue         = " + _
              s.RawValue.ToString()))
        Console.WriteLine(("   BaseValue        = " _
              + s.BaseValue.ToString()))
        Console.WriteLine(("   CounterFrequency = " + _
              s.CounterFrequency.ToString()))
        Console.WriteLine(("   CounterTimeStamp = " + _
              s.CounterTimeStamp.ToString()))
        Console.WriteLine(("   SystemFrequency  = " + _
              s.SystemFrequency.ToString()))
        Console.WriteLine(("   TimeStamp        = " + _
              s.TimeStamp.ToString()))
        Console.WriteLine(("   TimeStamp100nSec = " + _
              s.TimeStamp100nSec.ToString()))
        Console.WriteLine("++++++++++++++++++++++")
    End Sub


End Class

'</snippet2>

#End If
