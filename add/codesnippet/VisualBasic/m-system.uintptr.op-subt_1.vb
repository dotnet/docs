      Dim arr() As Integer = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10}
      Dim ptr As UIntPtr = CType(arr(arr.GetUpperBound(0)), UIntPtr)
      For ctr As Integer= 0 To arr.GetUpperBound(0)
         Dim newPtr As UIntPtr = UIntPtr.Subtract(ptr, ctr)
         Console.Write("{0}   ", newPtr)
      Next