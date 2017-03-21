
Public Class Headers

    <MatchAttribute("TITLE>(.*?)<")> _
    Public Title As String

    <MatchAttribute("", Pattern:="h1>(.*?)<", IgnoreCase:=True)> _
    Public H1 As String

    <MatchAttribute("H2>((([^<,]*),?)+)<", Group:=3, Capture:=4)> _
    Public Element As String

    <MatchAttribute("H2>((([^<,]*),?){2,})<", Group:=3, MaxRepeats:=0)> _
    Public Elements1() As String

    <MatchAttribute("H2>((([^<,]*),?){2,})<", Group:=3, MaxRepeats:=1)> _
    Public Elements2() As String

    <MatchAttribute("H3 ([^=]*)=([^>]*)", Group:=1)> _
    Public Attribute As String

    <MatchAttribute("H3 ([^=]*)=([^>]*)", Group:=2)> _
    Public Value As String
End Class 'Headers