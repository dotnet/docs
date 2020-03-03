
Module SimpleArray
   Public Sub Main()
      ' Declare an array with 7 elements.
      Dim students(6) As Integer

      ' Assign values to each element.
      students(0) = 23
      students(1) = 19
      students(2) = 21
      students(3) = 17
      students(4) = 19
      students(5) = 20
      students(6) = 22
      
      ' Display the value of each element.
      For ctr As Integer = 0 To 6
         Dim grade As String = If(ctr = 0, "kindergarten", $"grade {ctr}")
         Console.WriteLine($"Students in {grade}: {students(ctr)}")
      Next
   End Sub
End Module
' The example displays the following output:
'     Students in kindergarten: 23
'     Students in grade 1: 19
'     Students in grade 2: 21
'     Students in grade 3: 17
'     Students in grade 4: 19
'     Students in grade 5: 20
'     Students in grade 6: 22
