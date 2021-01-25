' <Snippet19>
Module ExampleMeasure
    Sub Main()
        Dim source = Enumerable.Range(0, 3000000)
        ' Define parallel and non-parallel queries.
        Dim queryToMeasure = From num In source.AsParallel()
                             Where num Mod 3 = 0
                             Select Math.Sqrt(num)

        Console.WriteLine("Measuring...")

        ' The query does not run until it is enumerated.
        ' Therefore, start the timer here.
        Dim sw = Stopwatch.StartNew()

        ' For pure query cost, enumerate and do nothing else.
        For Each n As Double In queryToMeasure
        Next

        sw.Stop()
        Dim elapsed As Long = sw.ElapsedMilliseconds  ' or sw.ElapsedTicks
        Console.WriteLine($"Total query time: {elapsed} ms.")

        Console.WriteLine("Press any key to exit.")
        Console.ReadKey()
    End Sub
End Module
' </Snippet19>

