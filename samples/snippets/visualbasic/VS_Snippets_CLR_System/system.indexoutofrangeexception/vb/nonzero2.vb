' Visual Basic .NET Document
Option Infer On
'Option Strict On

' <Snippet2>
Module Example
   Public Sub Main()
      Dim values = Array.CreateInstance(GetType(Integer), { 10 }, { 1 })
      Dim value As Integer = 2
      ' Assign values.
      For ctr As Integer = values.GetLowerBound(0) To values.GetUpperBound(0)
         values(ctr) = value
         value *= 2
      Next
      
      ' Display values.
      For ctr As Integer = values.GetLowerBound(0) To values.GetUpperBound(0)
         Console.Write("{0}    ", values(ctr))
      Next
   End Sub
End Module
' The example displays the following output:
'       2    4    8    16    32    64    128    256    512    1024
' </Snippet2>
