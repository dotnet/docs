  Public Sub usequeue()
    Dim queueDouble As New System.Collections.Generic.Queue(Of Double)
    Dim queueString As New System.Collections.Generic.Queue(Of String)
    queueDouble.Enqueue(1.1)
    queueDouble.Enqueue(2.2)
    queueDouble.Enqueue(3.3)
    queueDouble.Enqueue(4.4)
    queueString.Enqueue("First string of three")
    queueString.Enqueue("Second string of three")
    queueString.Enqueue("Third string of three")
    Dim s As String = "Queue of Double items (reported length " &
        CStr(queueDouble.Count) & "):"
    For i As Integer = 1 To queueDouble.Count
      s &= vbCrLf & CStr(queueDouble.Dequeue())
    Next i
    s &= vbCrLf & "Queue of String items (reported length " &
        CStr(queueString.Count) & "):"
    For i As Integer = 1 To queueString.Count
      s &= vbCrLf & queueString.Dequeue()
    Next i
    MsgBox(s)
  End Sub