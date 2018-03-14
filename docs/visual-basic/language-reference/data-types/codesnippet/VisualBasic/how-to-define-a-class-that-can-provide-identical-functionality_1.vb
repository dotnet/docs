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