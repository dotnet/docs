Imports System
Imports System.Linq
Imports System.Threading

Class RaceConditionExample
    Shared Sub Main()
        Console.WriteLine("=== Race Condition Example ===")
        DemonstrateRaceCondition()
        
        Console.WriteLine(Environment.NewLine & "=== Fixed Version ===")
        DemonstrateCorrectApproach()
    End Sub

    ' <RaceConditionBad>
    Shared Sub DemonstrateRaceCondition()
        Dim total As Integer = 0
        Dim numbers = Enumerable.Range(0, 10000)

        ' UNSAFE: Multiple threads writing to shared variable
        numbers.AsParallel().ForAll(Sub(n) total += n)

        Console.WriteLine($"Total (with race condition): {total}")
        ' Expected: 49,995,000 but result is unpredictable due to race condition
    End Sub
    ' </RaceConditionBad>

    ' <RaceConditionGood>
    Shared Sub DemonstrateCorrectApproach()
        Dim numbers = Enumerable.Range(0, 10000)

        ' SAFE: Use thread-safe aggregate operation
        Dim total As Integer = numbers.AsParallel().Sum()

        Console.WriteLine($"Total (correct): {total}")
        ' Result is always 49,995,000
    End Sub
    ' </RaceConditionGood>
End Class
