    Sub MovePiece(fromPosition As String, toPosition As String)
       Dim bag As StateBag = ViewState
       Dim piece As Object = bag(fromPosition)
       If Not (piece Is Nothing) Then
          bag.Remove(fromPosition)
          bag.Add(toPosition, piece)
          RenderBoard()
       Else
          Throw New InvalidPositionException("There is no game piece at the ""from"" position.")
       End If
    End Sub 'MovePiece