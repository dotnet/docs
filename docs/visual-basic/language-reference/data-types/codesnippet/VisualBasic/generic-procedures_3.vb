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