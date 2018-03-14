Function runningTotal(ByVal num As Integer) As Integer
    Static applesSold As Integer
    applesSold = applesSold + num
    Return applesSold
End Function