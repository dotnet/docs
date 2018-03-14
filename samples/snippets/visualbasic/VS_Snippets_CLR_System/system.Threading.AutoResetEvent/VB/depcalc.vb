'<snippet2>
Imports System
Imports System.Threading

Class TermInfo
    Public terms() As Integer
    Public order As Integer
    Public baseValue As Integer
    Public trigger As AutoResetEvent
End Class

Class DepCalc
    Private Const numTerms As Integer = 3

    Public Shared Sub Main()
        Dim trigger As New AutoResetEvent(False)
        Dim tinfo As New TermInfo()
        Dim termThread As Thread
        Dim terms() As Integer = New Integer(numTerms){}
        Dim result As Integer = 0

        tinfo.terms = terms
        tinfo.trigger = trigger

        For i As Integer = 0 To numTerms - 1
            tinfo.order = i
            'Create and start the term calc thread.
            termThread = New Thread(AddressOf TermThreadProc)
            termThread.Start(tinfo)
            ' simulate a number crunching delay
            Thread.Sleep(1000)
            tinfo.baseValue = DateTime.Now.Millisecond
            trigger.Set()
            termThread.Join()
            result += terms(i)
        Next i

        Console.WriteLine("Result = {0}", result)
    End Sub

    Private Shared Sub TermThreadProc(data As Object)
        Dim tinfo As TermInfo = CType(data, TermInfo)

        Console.WriteLine("Term[{0}] is starting...", tinfo.order)
        ' set the precalculation
        DIm preValue As Integer = DateTime.Now.Millisecond + tinfo.order

        ' wait for base value to be ready
        tinfo.trigger.WaitOne()
        Dim rnd As New Random(tinfo.baseValue)

        tinfo.terms(tinfo.order) = preValue * rnd.Next(10000)
        Console.WriteLine("Term[{0}] has finished with a value of: {1}",
            tinfo.order, tinfo.terms(tinfo.order))
    End Sub
End Class
'</snippet2>
