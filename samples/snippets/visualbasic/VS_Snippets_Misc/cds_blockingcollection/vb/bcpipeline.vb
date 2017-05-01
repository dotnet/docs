'<snippet07>
Imports System
Imports System.Collections
Imports System.Collections.Concurrent
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading
Imports System.Threading.Tasks

Namespace BlockingCollectionPipeline
    Class PipeLineDemo
        Public Shared Sub Main()
            Dim cts As New CancellationTokenSource()

            ' Start up a UI thread for cancellation.
            Task.Factory.StartNew(Sub()

                                      If (Console.ReadKey().KeyChar = "c"c) Then
                                          cts.Cancel()
                                      End If
                                  End Sub)
            'Generate some source data.
            Dim sourceArrays() As BlockingCollection(Of Integer)
            ReDim sourceArrays(5)
            For i As Integer = 0 To sourceArrays.Length - 1
                sourceArrays(i) = New BlockingCollection(Of Integer)(500)
            Next

            Parallel.For(0, sourceArrays.Length * 500, Sub(j)

                                                           Dim k = BlockingCollection(Of Integer).TryAddToAny(sourceArrays, j)
                                                           If (k >= 0) Then
                                                               Console.WriteLine("added {0} to source data", j)
                                                           End If
                                                       End Sub)

            For Each arr In sourceArrays
                arr.CompleteAdding()
            Next

            ' First filter accepts the ints, keeps back a small percentage
            ' as a processing fee, and converts the results to decimals.
            Dim filter1 = New PipelineFilter(Of Integer, Decimal)(
            sourceArrays,
            Function(n)
                Return Convert.ToDecimal(n * 0.97)
            End Function,
                        cts.Token,
                        "filter1"
             )
            ' Second filter accepts the decimals and converts them to 
            ' System.Strings.
            Dim filter2 = New PipelineFilter(Of Decimal, String)(
            filter1.m_output,
            Function(s) (String.Format("{0}", s)),
            cts.Token,
            "filter2"
             )
            ' Third filter uses the constructor with an Action<T>
            ' that renders its output to the screen, 
            ' not a blocking collection.
            Dim filter3 = New PipelineFilter(Of String, String)(
            filter2.m_output,
            Sub(s) Console.WriteLine("The final result is {0}", s),
            cts.Token,
            "filter3"
             )
            ' Start up the pipeline!
            Try

                Parallel.Invoke(
                             Sub() filter1.Run(),
                             Sub() filter2.Run(),
                             Sub() filter3.Run()
                         )

            Catch ae As AggregateException
                For Each ex In ae.InnerExceptions
                    Console.WriteLine(ex.Message + ex.StackTrace)
                Next
            Finally
                cts.Dispose()
            End Try
          
            ' You will need to press twice if you ran to the end:
            ' once for the cancellation thread, and once for this thread.
            Console.WriteLine("Press any key.")
            Console.ReadKey()
        End Sub
    End Class
        class PipelineFilter(Of TInput, TOutput)

        Private m_processor As Func(Of TInput, TOutput) = Nothing
        Public m_input() As BlockingCollection(Of TInput) = Nothing
        Public m_output() As BlockingCollection(Of TOutput) = Nothing
        Private m_outputProcessor As Action(Of TInput) = Nothing
        Private m_token As CancellationToken
        Public Name As String
        Public Sub New(ByVal input() As BlockingCollection(Of TInput),
                ByVal processor As Func(Of TInput, TOutput),
                ByVal token As CancellationToken,
                ByVal _name As String)

            m_input = input
            '  m_output = New BlockingCollection(Of TOutput)()
            ReDim m_output(5)
            For i As Integer = 0 To m_output.Length - 1
                m_output(i) = New BlockingCollection(Of TOutput)(500)
                m_processor = processor
                m_token = token
                name = _name
            Next
        End Sub

        ' Use this constructor for the final endpoint, which does
        ' something like write to file or screen, instead of 
        ' pushing to another pipeline filter.
        Public Sub New(ByVal input() As BlockingCollection(Of TInput),
             ByVal renderer As Action(Of TInput),
           ByVal token As CancellationToken,
            ByVal _name As String)

            m_input = input
            m_outputProcessor = renderer
            m_token = token
            name = _name
        End Sub
        Public Sub Run()

            Console.WriteLine("{0} is running", Me.Name)
            While ((m_input.All(Function(bc) bc.IsCompleted) = False) And m_token.IsCancellationRequested = False)

                Dim receivedItem As TInput
                Dim i As Integer = BlockingCollection(Of TInput).TryTakeFromAny(
                        m_input, receivedItem, 50, m_token)
                If (i >= 0) Then

                    If (Not m_output Is Nothing) Then ' we pass data to another blocking collection

                        Dim outputItem As TOutput = m_processor(receivedItem)
                        BlockingCollection(Of TOutput).AddToAny(m_output, outputItem)
                        Console.WriteLine("{0} sent{1} to next", Me.Name, outputItem)

                    Else ' we're an endpoint

                        m_outputProcessor(receivedItem)
                    End If

                    else
                    Console.WriteLine("Unable to retrieve data from previous filter")
                End If
                        End While
            If (Not m_output Is Nothing) Then

                For Each bc In m_output
                    bc.CompleteAdding()
                Next

            End If
        End Sub
    End Class
End Namespace

'</snippet07>



