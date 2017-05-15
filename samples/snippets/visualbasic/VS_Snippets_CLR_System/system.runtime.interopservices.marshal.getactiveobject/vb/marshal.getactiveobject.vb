'<snippet1>

Imports System
Imports System.Runtime.InteropServices

Module Module1

    Sub Main()
        Console.WriteLine(vbcrlf + "Sample: VB System.Runtime.InteropServices.Marshal.GetActiveObject.vb" + vbcrlf) 
        GetObj(1, "Word.Application")
        GetObj(2, "Excel.Application")
    End Sub


    Sub GetObj(ByVal i As Integer, ByVal progID As [String])
        Dim obj As [Object] = Nothing
        
        Console.WriteLine((vbLf & i & ") Object obj = GetActiveObject(""") + progID & """)")
        Try
            obj = Marshal.GetActiveObject(progID)
        Catch e As Exception
            Write2Console((vbLf & "   Failure: obj did not get initialized" & vbLf & "   Exception = ") + e.ToString().Substring(0, 43), 0)
        End Try
        
        If obj IsNot Nothing Then
            Write2Console(vbLf & "   Success: obj = " & obj.ToString(), 1)
        End If
    End Sub

    Sub Write2Console(ByVal s As [String], ByVal color As Integer)
        Console.ForegroundColor = If(color = 1, ConsoleColor.Green, ConsoleColor.Red)
        Console.WriteLine(s)
        Console.ForegroundColor = ConsoleColor.Gray
    End Sub

End Module

'Expected Output:
'
'Sample: VB System.Runtime.InteropServices.Marshal.GetActiveObject.vb
'
'1) Object obj = GetActiveObject("Word.Application")
'
'   Success: obj = System.__ComObject
'
'2) Object obj = GetActiveObject("Excel.Application")
'
'   Failure: obj did not get initialized
'   Exception = System.Runtime.InteropServices.COMException
'
'</snippet1>
