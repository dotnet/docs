' Visual Basic .NET Document
' Illustrates System.Convert.ToString(String) returns the same string.
Option Strict On

' <Snippet2>
Module Example
   Public Sub Main()
      Dim article As String = "An"
      Dim noun As String = "apple"
      Dim str1 As String = String.Format("{0} {1}", article, noun)
      Dim str2 As String = Convert.ToString(str1)

      Console.WriteLine("str1 is interned: {0}",
                        Not String.IsInterned(str1) Is Nothing)
      Console.WriteLine("str1 and str2 are the same reference: {0}",
                        Object.ReferenceEquals(str1, str2))
   End Sub
End Module
' The example displays the following output:
'       str1 is interned: False
'       str1 and str2 are the same reference: True
' </Snippet2>

