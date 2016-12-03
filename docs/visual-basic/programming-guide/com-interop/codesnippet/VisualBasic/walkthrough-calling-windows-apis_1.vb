    Declare Auto Function MBox Lib "user32.dll" Alias "MessageBox" (
        ByVal hWnd As Integer,
        ByVal txt As String,
        ByVal caption As String,
        ByVal Typ As Integer) As Integer