' Visual Basic .NET Document
Option Strict On

' <Snippet6>
Module Example
   Public Sub Main()
      Dim rnd As New Random()
      ' Generate five random Boolean values.
      For ctr As Integer = 1 To 5
         Dim bool As Boolean = Convert.ToBoolean(rnd.Next(0, 2))
         Console.WriteLine("True or False: {0}", bool)
      Next
   End Sub
End Module
' The example displays the following output:
'       True or False: False
'       True or False: True
'       True or False: False
'       True or False: False
'       True or False: True
' </Snippet6>
