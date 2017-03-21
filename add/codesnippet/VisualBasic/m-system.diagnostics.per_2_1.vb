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
    End Sub 'CollectSamples