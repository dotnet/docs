' Visual Basic .NET Document
' Uses IsInterned to determine whether a string is interned (True) or not (False).
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim str1 As String = "a"
      Dim str2 As String = str1 + "b"
      Dim str3 As String = str2 + "c"
      Dim strings() As String = { "value", "part1" + "_" + "part2", str3, 
                                  String.Empty, Nothing }
      For Each value In strings
         If value Is Nothing Then Continue For
         
         Dim interned As Boolean = (String.IsInterned(value) IsNot Nothing)
         If interned Then
            Console.WriteLine("'{0}' is in the string intern pool.", 
                              value)
         Else
            Console.WriteLine("'{0}' is not in the string intern pool.",
                              value)                      
         End If
      Next
   End Sub
End Module
' The example displays the following output:
'       'value' is in the string intern pool.
'       'part1_part2' is in the string intern pool.
'       'abc' is not in the string intern pool.
'       '' is in the string intern pool.
' </Snippet1>
