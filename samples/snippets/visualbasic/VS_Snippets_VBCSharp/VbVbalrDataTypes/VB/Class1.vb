Public Class Class1

' Added 6/15/2005 for Generic Procedures in Visual Basic
Public Class GenericProcedures

    '<Snippet15>
    Public Sub testSub(Of t)(ByVal arg As t)
    End Sub
    Public Sub callTestSub()
        testSub("Use this string")
    End Sub
    '</Snippet15>

    '<Snippet14>
    Public Function findElement(Of T As IComparable) (
            ByVal searchArray As T(), ByVal searchValue As T) As Integer

        If searchArray.GetLength(0) > 0 Then
            For i As Integer = 0 To searchArray.GetUpperBound(0)
                If searchArray(i).CompareTo(searchValue) = 0 Then Return i
            Next i
        End If

        Return -1
    End Function
    '</Snippet14>

    '<Snippet13>
    Public Sub tryFindElement()
        Dim stringArray() As String = {"abc", "def", "xyz"}
        Dim stringSearch As String = "abc"
        Dim integerArray() As Integer = {7, 8, 9}
        Dim integerSearch As Integer = 8
        Dim dateArray() As Date = {#4/17/1969#, #9/20/1998#, #5/31/2004#}
        Dim dateSearch As Date = Microsoft.VisualBasic.DateAndTime.Today
        MsgBox(CStr(findElement(Of String)(stringArray, stringSearch)))
        MsgBox(CStr(findElement(Of Integer)(integerArray, integerSearch)))
        MsgBox(CStr(findElement(Of Date)(dateArray, dateSearch)))
    End Sub
    '</Snippet13>

End Class

    Public Sub ByteTest()
        ' For topic Byte Data Type
        '<Snippet16>
        ' The valid range of a Byte variable is 0 through 255.
        Dim b As Byte
        b = 30
        ' The following statement causes an error because the value is too large.
        'b = 256
        ' The following statement causes an error because the value is negative.
        'b = -5
        ' The following statement sets b to 6.
        b = CByte(5.7)

        ' The following statements apply bit-shift operators to b.
        ' The initial value of b is 6.
        Console.WriteLine(b)
        ' Bit shift to the right divides the number in half. In this 
        ' example, binary 110 becomes 11.
        b >>= 1
        ' The following statement displays 3.
        Console.WriteLine(b)
        ' Now shift back to the original position, and then one more bit
        ' to the left. Each shift to the left doubles the value. In this
        ' example, binary 11 becomes 1100.
        b <<= 2
        ' The following statement displays 12.
        Console.WriteLine(b)
        '</Snippet16>
    End Sub

  Sub TestChar()
    '**********************************************************************
    '<Snippet12>
    Dim charVar As Char
    ' The following statement attempts to convert a String literal to Char.
    ' Because Option Strict is On, it generates a compiler error.
    charVar = "Z"
    ' The following statement succeeds because it specifies a Char literal.
    charVar = "Z"c
    ' The following statement succeeds because it converts String to Char.
    charVar = CChar("Z")
    '</Snippet12>
  End Sub


  Sub TestFloatMod()
    '**********************************************************************
    '<Snippet11>
    Dim two As Double = 2.0
    Dim zeroPointTwo As Double = 0.2
    Dim quotient As Double = two / zeroPointTwo
    Dim doubleRemainder As Double = two Mod zeroPointTwo

    MsgBox("2.0 is represented as " & two.ToString("G17") &
        vbCrLf & "0.2 is represented as " & zeroPointTwo.ToString("G17") &
        vbCrLf & "2.0 / 0.2 generates " & quotient.ToString("G17") &
        vbCrLf & "2.0 Mod 0.2 generates " &
        doubleRemainder.ToString("G17"))

    Dim decimalRemainder As Decimal = 2D Mod 0.2D
    MsgBox("2.0D Mod 0.2D generates " & CStr(decimalRemainder))
    '</Snippet11>
  End Sub


  Sub TestFloatComp()
    '**********************************************************************
    '<Snippet10>
    Dim oneThird As Double = 1.0 / 3.0
    Dim pointThrees As Double = 0.333333333333333

    ' The following comparison does not indicate equality.
    Dim exactlyEqual As Boolean = (oneThird = pointThrees)

    ' The following comparison indicates equality.
    Dim closeEnough As Double = 0.000000000000001
    Dim absoluteDifference As Double = Math.Abs(oneThird - pointThrees)
    Dim practicallyEqual As Boolean = (absoluteDifference < closeEnough)

    MsgBox("1.0 / 3.0 is represented as " & oneThird.ToString("G17") &
        vbCrLf & "0.333333333333333 is represented as " &
        pointThrees.ToString("G17") &
        vbCrLf & "Exact comparison generates " & CStr(exactlyEqual) &
        vbCrLf & "Acceptable difference comparison generates " &
        CStr(practicallyEqual))
    '</Snippet10>
  End Sub
End Class


'********************************************************************
Class TestQueues
  '<Snippet9>
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
  '</Snippet9>
End Class


'********************************************************************
Class TestSimpleList
'<Snippet8>
Public Sub useSimpleList()
  Dim iList As New simpleList(Of Integer)(2)
  Dim sList As New simpleList(Of String)(3)
  Dim dList As New simpleList(Of Date)(2)
  iList.add(10)
  iList.add(20)
  iList.add(30)
  sList.add("First")
  sList.add("extra")
  sList.add("Second")
  sList.add("Third")
  sList.remove(1)
  dList.add(#1/1/2003#)
  dList.add(#3/3/2003#)
  dList.insert(#2/2/2003#, 1)
  Dim s = 
    "Simple list of 3 Integer items (reported length " &
     CStr(iList.listLength) & "):" &
     vbCrLf & CStr(iList.listItem(0)) &
     vbCrLf & CStr(iList.listItem(1)) &
     vbCrLf & CStr(iList.listItem(2)) &
     vbCrLf &
     "Simple list of 4 - 1 String items (reported length " &
     CStr(sList.listLength) & "):" &
     vbCrLf & CStr(sList.listItem(0)) &
     vbCrLf & CStr(sList.listItem(1)) &
     vbCrLf & CStr(sList.listItem(2)) &
     vbCrLf &
     "Simple list of 2 + 1 Date items (reported length " &
     CStr(dList.listLength) & "):" &
     vbCrLf & CStr(dList.listItem(0)) &
     vbCrLf & CStr(dList.listItem(1)) &
     vbCrLf & CStr(dList.listItem(2))
  MsgBox(s)
End Sub
'</Snippet8>
End Class


'********************************************************************
'<Snippet7>
Public Class simpleList(Of itemType)
  Private items() As itemType
  Private top As Integer
  Private nextp As Integer
  Public Sub New()
    Me.New(9)
  End Sub
  Public Sub New(ByVal t As Integer)
    MyBase.New()
    items = New itemType(t) {}
    top = t
    nextp = 0
  End Sub
  Public Sub add(ByVal i As itemType)
    insert(i, nextp)
  End Sub
  Public Sub insert(ByVal i As itemType, ByVal p As Integer)
    If p > nextp OrElse p < 0 Then
      Throw New System.ArgumentOutOfRangeException("p", 
        " less than 0 or beyond next available list position")
    ElseIf nextp > top Then
      Throw New System.ArgumentException("No room to insert at ", 
        "p")
    ElseIf p < nextp Then
      For j As Integer = nextp To p + 1 Step -1
        items(j) = items(j - 1)
      Next j
    End If
    items(p) = i
    nextp += 1
  End Sub
  Public Sub remove(ByVal p As Integer)
    If p >= nextp OrElse p < 0 Then
        Throw New System.ArgumentOutOfRangeException("p", 
            " less than 0 or beyond last list item")
    ElseIf nextp = 0 Then
        Throw New System.ArgumentException("List empty; cannot remove ", 
            "p")
    ElseIf p < nextp - 1 Then
        For j As Integer = p To nextp - 2
            items(j) = items(j + 1)
        Next j
    End If
    nextp -= 1
  End Sub
  Public ReadOnly Property listLength() As Integer
    Get
      Return nextp
    End Get
  End Property
  Public ReadOnly Property listItem(ByVal p As Integer) As itemType
    Get
      If p >= nextp OrElse p < 0 Then
        Throw New System.ArgumentOutOfRangeException("p", 
          " less than 0 or beyond last list item")
        End If
      Return items(p)
    End Get
  End Property
End Class
'</Snippet7>


'*************************************************************************
Public Class Generics

  '***********************************************************************
  '<Snippet6>
  Public Class thisClass(Of t As {IComparable, IDisposable, Class, New})
      ' Insert code that defines class members.
  End Class
  '</Snippet6>


  '***********************************************************************
  '<Snippet5>
  Public Class itemManager(Of t As IComparable)
      ' Insert code that defines class members.
  End Class
  '</Snippet5>


  '***********************************************************************
  '<Snippet4>
  Public Sub processNewItem(ByVal newItem As Integer)
      Dim tempItem As Integer
      ' Inserted code now processes an Integer item.
  End Sub
  '</Snippet4>


  '***********************************************************************
  '<Snippet3>
  Public integerClass As New classHolder(Of Integer)
  Friend stringClass As New classHolder(Of String)
  '</Snippet3>


  '***********************************************************************
  '<Snippet2>
  Public Class classHolder(Of t)
      Public Sub processNewItem(ByVal newItem As t)
          Dim tempItem As t
          ' Insert code that processes an item of data type t.
      End Sub
  End Class
  '</Snippet2>


  '***********************************************************************
  '<Snippet1>
  Public stringQ As New System.Collections.Generic.Queue(Of String)
  '</Snippet1>
End Class
