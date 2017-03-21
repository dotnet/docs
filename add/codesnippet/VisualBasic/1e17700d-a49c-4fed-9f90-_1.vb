Public Class StateObject
   Public workSocket As Socket = Nothing
   Public const BUFFER_SIZE As Integer = 1024
   Public buffer(BUFFER_SIZE) As byte
   Public sb As New StringBuilder()
End Class 'StateObject