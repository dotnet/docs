' <Snippet1>
Option Explicit
Option Strict

Imports System
Imports System.Globalization

Public Class MainClass
    
    Public Shared Sub Main()
        Dim dt As DateTime = DateTime.Now
        Dim myformat() As String =  {"d", "D", _
                                    "f", "F", _
                                    "g", "G", _
                                    "m", _
                                    "r", _
                                    "s", _
                                    "t", "T", _
                                    "u", "U", _
                                    "y", _
                                    "dddd, MMMM dd yyyy", _
                                    "ddd, MMM d ""'""yy", _
                                    "dddd, MMMM dd", _
                                    "M/yy", _
                                    "dd-MM-yy"}
        Dim mydate As String
        Dim i As Integer
        For i = 0 To myformat.Length - 1
            mydate = dt.ToString(myformat(i), DateTimeFormatInfo.InvariantInfo)
            Console.WriteLine(String.Concat(myformat(i), " :", mydate))
        Next i

    ' Output.
    '
    ' d :08/17/2000
    ' D :Thursday, August 17, 2000
    ' f :Thursday, August 17, 2000 16:32
    ' F :Thursday, August 17, 2000 16:32:32
    ' g :08/17/2000 16:32
    ' G :08/17/2000 16:32:32
    ' m :August 17
    ' r :Thu, 17 Aug 2000 23:32:32 GMT
    ' s :2000-08-17T16:32:32
    ' t :16:32
    ' T :16:32:32
    ' u :2000-08-17 23:32:32Z
    ' U :Thursday, August 17, 2000 23:32:32
    ' y :August, 2000
    ' dddd, MMMM dd yyyy :Thursday, August 17 2000
    ' ddd, MMM d "'"yy :Thu, Aug 17 '00
    ' dddd, MMMM dd :Thursday, August 17
    ' M/yy :8/00
    ' dd-MM-yy :17-08-00
    End Sub 'Main 
End Class 'MainClass
' </Snippet1>
