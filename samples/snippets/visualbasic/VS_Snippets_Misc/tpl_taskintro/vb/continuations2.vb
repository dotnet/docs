' Visual Basic .NET Document
Option Strict On

' <Snippet24>

Namespace ContinuationsTwo
    Module Example
        Public Sub Main()
            Dim displayData = Task.Factory.StartNew(Function()
                                                        Dim rnd As New Random()
                                                        Dim values(99) As Integer
                                                        For ctr = 0 To values.GetUpperBound(0)
                                                            values(ctr) = rnd.Next()
                                                        Next
                                                        Return values
                                                    End Function). _
            ContinueWith(Function(x)
                             Dim n As Integer = x.Result.Length
                             Dim sum As Long
                             Dim mean As Double

                             For ctr = 0 To x.Result.GetUpperBound(0)
                                 sum += x.Result(ctr)
                             Next
                             mean = sum / n
                             Return Tuple.Create(n, sum, mean)
                         End Function). _
            ContinueWith(Function(x)
                             Return String.Format("N={0:N0}, Total = {1:N0}, Mean = {2:N2}",
                                                 x.Result.Item1, x.Result.Item2,
                                                 x.Result.Item3)
                         End Function)
            Console.WriteLine(displayData.Result)
        End Sub
    End Module
    ' The example displays output like the following:
    '   N=100, Total = 110,081,653,682, Mean = 1,100,816,536.82
End Namespace
' </Snippet24>
