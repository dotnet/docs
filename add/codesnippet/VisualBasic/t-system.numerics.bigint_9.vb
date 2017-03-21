      Dim number As BigInteger = Int64.MaxValue ^ 5
      Dim repetitions As Integer = 1000000
      Dim actualRepetitions As Integer = 0
      ' Perform some repetitive operation 1 million times.
      For ctr As Integer = 0 To repetitions
         ' Perform some operation. If it fails, exit the loop.
         If Not SomeOperationSucceeds() Then Exit For
         ' The following code executes if the operation succeeds.
         actualRepetitions += 1
      Next
      number += actualRepetitions