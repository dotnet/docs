' Visual Basic .NET Document
Option Strict On

' <Snippet11>
Imports System.Linq

Module Example
   Public Sub Main()
      Dim source = Enumerable.Range(100, 20000)

      ' Result sequence might be out of order.
      Dim parallelQuery = From num In source.AsParallel()
                          Where num Mod 10 = 0
                          Select num

      ' Process result sequence in parallel
      parallelQuery.ForAll(Sub(e)
                              DoSomething(e)
                           End Sub)

      ' Or use For Each to merge results first
      ' as in this example, Where results must
      ' be serialized sequentially through static Console method.
      For Each n In parallelQuery
         Console.Write("{0} ", n)
      Next

      ' You can also use ToArray, ToList, etc, as with LINQ to Objects.
      Dim parallelQuery2 = (From num In source.AsParallel()
                            Where num Mod 10 = 0
                            Select num).ToArray()

      ' Method syntax is also supported
      Dim parallelQuery3 = source.AsParallel().Where(Function(n)
                                         Return (n Mod 10) = 0
                                         End Function).Select(Function(n)
                                         Return n
                           End Function)

      For Each i As Integer In parallelQuery3
         Console.Write("{0} ", i)
      Next
      
      
      Console.WriteLine()
      Console.WriteLine("Press any key to exit...")
      Console.ReadLine()
   End Sub

   ' A toy function to demonstrate syntax. Typically you need a more
   ' computationally expensive method to see speedup over sequential queries.
   Sub DoSomething(ByVal i As Integer)
      Console.Write("{0:###.## }", Math.Sqrt(i))
   End Sub
End Module
' </Snippet11>


