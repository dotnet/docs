'<snippet1>
Imports System

Public Class ReplaceTest
    
    Public Shared Sub Main()
        Dim errString As String = "This docment uses 3 other docments to docment the docmentation"
                
        Console.WriteLine("The original string is:{0}'{1}'{0}", Environment.NewLine, errString)

        ' Correct the spelling of "document".  
        Dim correctString As String = errString.Replace("docment", "document")
      
        Console.WriteLine("After correcting the string, the result is:{0}'{1}'", Environment.NewLine, correctString)
    End Sub
End Class
'
' This code example produces the following output:
'
' The original string is:
' 'This docment uses 3 other docments to docment the docmentation'
'
' After correcting the string, the result is:
' 'This document uses 3 other documents to document the documentation'
'
'</snippet1>