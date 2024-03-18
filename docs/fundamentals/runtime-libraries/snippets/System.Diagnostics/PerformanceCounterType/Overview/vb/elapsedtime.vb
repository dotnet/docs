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

Public Class App2
   Private Shared PC As PerformanceCounter

   Public Shared Sub Main()
      Dim samplesList As New ArrayList()

      'If the category does not exist, create the category and exit.
      'Performance counters should not be created and immediately used.
      'There is a latency time to enable the counters, they should be created
      'prior to executing the App2lication that uses the counters.
      'Execute this sample a second time to use the counters.
      If Not (SetupCategory()) Then
        CreateCounters()
        CollectSamples(samplesList)
      End If

   End Sub


   Private Shared Function SetupCategory() As Boolean
      If Not PerformanceCounterCategory.Exists("ElapsedTimeSampleCategory") Then

         Dim CCDC As New CounterCreationDataCollection()

         ' Add the counter.
         Dim ETimeData As New CounterCreationData()
         ETimeData.CounterType = PerformanceCounterType.ElapsedTime
         ETimeData.CounterName = "ElapsedTimeSample"
         CCDC.Add(ETimeData)

         ' Create the category.
         PerformanceCounterCategory.Create("ElapsedTimeSampleCategory", _
            "Demonstrates usage of the ElapsedTime performance counter type.", CCDC)

         Return True
      Else
         Console.WriteLine("Category exists - ElapsedTimeSampleCategory")
         Return False
      End If
   End Function 'SetupCategory


   Private Shared Sub CreateCounters()
      ' Create the counter.
      PC = New PerformanceCounter("ElapsedTimeSampleCategory", _
            "ElapsedTimeSample", False)
   End Sub



   Private Shared Sub CollectSamples(samplesList As ArrayList)

      Dim pcValue As Long
      Dim Start As DateTime

      ' Initialize the counter.
      QueryPerformanceCounter(pcValue)
      PC.RawValue = pcValue
      Start = DateTime.Now

      ' Loop for the samples.
      Dim j As Integer
      For j = 0 To 999
         ' Output the values.
         If j Mod 10 = 9 Then
            Console.WriteLine(("NextValue() = " _
                + PC.NextValue().ToString()))
            Console.WriteLine(("Actual elapsed time = " _
                + DateTime.Now.Subtract(Start).ToString()))
            OutputSample(PC.NextSample())
            samplesList.Add(PC.NextSample())
         End If

         ' reset the counter on 100th iteration.
         If j Mod 100 = 0 Then
            QueryPerformanceCounter(pcValue)
            PC.RawValue = pcValue
            Start = DateTime.Now
         End If
         System.Threading.Thread.Sleep(50)
      Next j

      Console.WriteLine(("Elapsed time = " + _
            DateTime.Now.Subtract(Start).ToString()))
   End Sub 


   Private Shared Sub OutputSample(s As CounterSample)
      Console.WriteLine(ControlChars.Lf + ControlChars.Cr + "+++++++")

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

      Console.WriteLine("+++++++")
   End Sub

   ' Reads the counter information to enable setting the RawValue.
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
Public Class App2

    Public Shared Sub Main()
        CollectSamples()
    End Sub

    Private Shared Sub CollectSamples()

        Dim categoryName As String = "ElapsedTimeSampleCategory"
        Dim counterName As String = "ElapsedTimeSample"

        If Not PerformanceCounterCategory.Exists(categoryName) Then

            Dim CCDC As New CounterCreationDataCollection()

            ' Add the counter.
            Dim ETimeData As New CounterCreationData()
            ETimeData.CounterType = PerformanceCounterType.ElapsedTime
            ETimeData.CounterName = counterName
            CCDC.Add(ETimeData)

            ' Create the category.
            PerformanceCounterCategory.Create(categoryName,
               "Demonstrates ElapsedTime performance counter usage.",
                   PerformanceCounterCategoryType.SingleInstance, CCDC)

        Else
            Console.WriteLine("Category exists - {0}", categoryName)
        End If

        '<Snippet3>
        ' Create the counter.
        Dim PC As PerformanceCounter
        PC = New PerformanceCounter(categoryName, counterName, False)

        ' Initialize the counter.
        PC.RawValue = Stopwatch.GetTimestamp()
        '</Snippet3>

        Dim Start As DateTime = DateTime.Now

        ' Loop for the samples.
        Dim j As Integer
        For j = 0 To 99
            ' Output the values.
            If j Mod 10 = 9 Then
                Console.WriteLine(("NextValue() = " _
                    + PC.NextValue().ToString()))
                Console.WriteLine(("Actual elapsed time = " _
                    + DateTime.Now.Subtract(Start).ToString()))
                OutputSample(PC.NextSample())
            End If

            ' Reset the counter every 20th iteration.
            If j Mod 20 = 0 Then
                PC.RawValue = Stopwatch.GetTimestamp()
                Start = DateTime.Now
            End If
            System.Threading.Thread.Sleep(50)
        Next j

        Console.WriteLine(("Elapsed time = " +
              DateTime.Now.Subtract(Start).ToString()))
    End Sub


    Private Shared Sub OutputSample(ByVal s As CounterSample)
        Console.WriteLine(ControlChars.Lf + ControlChars.Cr + "+++++++")

        Console.WriteLine("Sample values - " + ControlChars.Cr _
              + ControlChars.Lf)
        Console.WriteLine(("   BaseValue        = " _
              + s.BaseValue.ToString()))
        Console.WriteLine(("   CounterFrequency = " +
              s.CounterFrequency.ToString()))
        Console.WriteLine(("   CounterTimeStamp = " +
              s.CounterTimeStamp.ToString()))
        Console.WriteLine(("   CounterType      = " +
              s.CounterType.ToString()))
        Console.WriteLine(("   RawValue         = " +
              s.RawValue.ToString()))
        Console.WriteLine(("   SystemFrequency  = " +
              s.SystemFrequency.ToString()))
        Console.WriteLine(("   TimeStamp        = " +
              s.TimeStamp.ToString()))
        Console.WriteLine(("   TimeStamp100nSec = " +
              s.TimeStamp100nSec.ToString()))

        Console.WriteLine("+++++++")
    End Sub
End Class
'</snippet2>

#End If
