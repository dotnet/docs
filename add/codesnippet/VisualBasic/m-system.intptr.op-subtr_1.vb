      Dim arr() As Integer = {2, 4, 6, 8, 10, 12, 14, 16, 18, 20 }
      Dim ptr As IntPtr = Marshal.UnsafeAddrOfPinnedArrayElement(arr, arr.GetUpperBound(0))
      For ctr As Integer= 0 To arr.GetUpperBound(0)
         Dim newPtr As IntPtr = ptr - ctr * Len(arr(0))
         Console.Write("{0}   ", Marshal.ReadInt32(newPtr))
      Next