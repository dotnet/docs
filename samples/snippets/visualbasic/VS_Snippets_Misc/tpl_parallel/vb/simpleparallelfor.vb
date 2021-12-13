' <snippet01>
Imports System.Diagnostics
Imports System.Runtime.InteropServices
Imports System.Threading.Tasks

Module MultiplyMatrices
#Region "Sequential_Loop"
    Sub MultiplyMatricesSequential(ByVal matA As Double(,), ByVal matB As Double(,), ByVal result As Double(,))
        Dim matACols As Integer = matA.GetLength(1)
        Dim matBCols As Integer = matB.GetLength(1)
        Dim matARows As Integer = matA.GetLength(0)

        For i As Integer = 0 To matARows - 1
            For j As Integer = 0 To matBCols - 1
                Dim temp As Double = 0
                For k As Integer = 0 To matACols - 1
                    temp += matA(i, k) * matB(k, j)
                Next
                result(i, j) += temp
            Next
        Next
    End Sub
#End Region

#Region "Parallel_Loop"
    Private Sub MultiplyMatricesParallel(ByVal matA As Double(,), ByVal matB As Double(,), ByVal result As Double(,))
        Dim matACols As Integer = matA.GetLength(1)
        Dim matBCols As Integer = matB.GetLength(1)
        Dim matARows As Integer = matA.GetLength(0)

        ' A basic matrix multiplication.
        ' Parallelize the outer loop to partition the source array by rows.
        Parallel.For(0, matARows, Sub(i)
                                      For j As Integer = 0 To matBCols - 1
                                          Dim temp As Double = 0
                                          For k As Integer = 0 To matACols - 1
                                              temp += matA(i, k) * matB(k, j)
                                          Next
                                          result(i, j) += temp
                                      Next
                                  End Sub)
    End Sub
#End Region

#Region "Main"
    Sub Main(ByVal args As String())
        ' Set up matrices. Use small values to better view 
        ' result matrix. Increase the counts to see greater 
        ' speedup in the parallel loop vs. the sequential loop.
        Dim colCount As Integer = 180
        Dim rowCount As Integer = 2000
        Dim colCount2 As Integer = 270
        Dim m1 As Double(,) = InitializeMatrix(rowCount, colCount)
        Dim m2 As Double(,) = InitializeMatrix(colCount, colCount2)
        Dim result As Double(,) = New Double(rowCount - 1, colCount2 - 1) {}

        ' First do the sequential version.
        Console.Error.WriteLine("Executing sequential loop...")
        Dim stopwatch As New Stopwatch()
        stopwatch.Start()

        MultiplyMatricesSequential(m1, m2, result)
        stopwatch.[Stop]()
        Console.Error.WriteLine("Sequential loop time in milliseconds: {0}", stopwatch.ElapsedMilliseconds)

        ' For the skeptics.
        OfferToPrint(rowCount, colCount2, result)

        ' Reset timer and results matrix. 
        stopwatch.Reset()
        result = New Double(rowCount - 1, colCount2 - 1) {}

        ' Do the parallel loop.
        Console.Error.WriteLine("Executing parallel loop...")
        stopwatch.Start()
        MultiplyMatricesParallel(m1, m2, result)
        stopwatch.[Stop]()
        Console.Error.WriteLine("Parallel loop time in milliseconds: {0}", stopwatch.ElapsedMilliseconds)
        OfferToPrint(rowCount, colCount2, result)

        ' Keep the console window open in debug mode.
        Console.Error.WriteLine("Press any key to exit.")
        Console.ReadKey()
    End Sub
#End Region

#Region "Helper_Methods"
    Function InitializeMatrix(ByVal rows As Integer, ByVal cols As Integer) As Double(,)
        Dim matrix As Double(,) = New Double(rows - 1, cols - 1) {}

        Dim r As New Random()
        For i As Integer = 0 To rows - 1
            For j As Integer = 0 To cols - 1
                matrix(i, j) = r.[Next](100)
            Next
        Next
        Return matrix
    End Function

    Sub OfferToPrint(ByVal rowCount As Integer, ByVal colCount As Integer, ByVal matrix As Double(,))
        Console.Error.Write("Computation complete. Display results (y/n)? ")
        Dim c As Char = Console.ReadKey(True).KeyChar
        Console.Error.WriteLine(c)
        If Char.ToUpperInvariant(c) = "Y"c Then
            If Not Console.IsOutputRedirected AndAlso
                RuntimeInformation.IsOSPlatform(OSPlatform.Windows) Then Console.WindowWidth = 168

            Console.WriteLine()
            For x As Integer = 0 To rowCount - 1
                Console.WriteLine("ROW {0}: ", x)
                For y As Integer = 0 To colCount - 1
                    Console.Write("{0:#.##} ", matrix(x, y))
                Next
                Console.WriteLine()
            Next
        End If
    End Sub
#End Region
End Module
' </snippet01>
