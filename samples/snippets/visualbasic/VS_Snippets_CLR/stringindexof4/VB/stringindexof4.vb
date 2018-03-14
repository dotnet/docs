'<snippet1>
Imports System

Public Class IndexOfTest
    
    Public Shared Sub Main()
        Dim strSource As String = "This is the string which we will perform the search on"
        
        Console.WriteLine("The search string is:{0}{1}{0}", Environment.NewLine, strSource)
        Dim strTarget As String = ""
        Dim found As Integer = 0
        Dim totFinds As Integer = 0
        
        Do
            Console.Write("Please enter a search value to look for in the above string (hit Enter to exit) ==> ")
            
            strTarget = Console.ReadLine()
            If strTarget <> "" Then
                Dim i As Integer
                
                
                For i = 0 To strSource.Length - 1
                    
                    found = strSource.IndexOf(strTarget, i)
                    If found >= 0 Then
                        
                        totFinds += 1
                        i = found
                    Else
                        Exit For
                    End If
                Next i
            Else
                Return
            
            End If
            Console.WriteLine("{0}The search parameter '{1}' was found {2} times.{0}", Environment.NewLine, strTarget, totFinds)
            
            totFinds = 0
        
        Loop While True
    End Sub 'Main
End Class 'IndexOfTest
'</snippet1>