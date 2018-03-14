' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim values() As Object = { 10S, 20S, 10I, 20I, 10L, 20L,
                                 10R, 20R, 10US, 20US, 10UI, 20UI,
                                 10UL, 20UL }
      Dim baseValue As UInt64 = 20
      Dim baseType As String = baseValue.GetType().Name
      
      For Each value In values
         Console.WriteLine("{0} ({1}) = {2} ({3}): {4}",
                           baseValue, baseType,
                           value, value.GetType().Name,
                           baseValue.Equals(value))
      Next
   End Sub
End Module
' The example displays the following output:
'       20 (UInt64) = 10 (Int16): False
'       20 (UInt64) = 20 (Int16): False
'       20 (UInt64) = 10 (Int32): False
'       20 (UInt64) = 20 (Int32): False
'       20 (UInt64) = 10 (Int64): False
'       20 (UInt64) = 20 (Int64): False
'       20 (UInt64) = 10 (Double): False
'       20 (UInt64) = 20 (Double): False
'       20 (UInt64) = 10 (UInt16): False
'       20 (UInt64) = 20 (UInt16): False
'       20 (UInt64) = 10 (UInt32): False
'       20 (UInt64) = 20 (UInt32): False
'       20 (UInt64) = 10 (UInt64): False
'       20 (UInt64) = 20 (UInt64): True
' </Snippet1>
