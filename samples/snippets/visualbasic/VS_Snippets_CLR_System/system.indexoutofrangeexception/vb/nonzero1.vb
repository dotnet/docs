' Visual Basic .NET Document
Option Infer On
'Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim values = Array.CreateInstance(GetType(Integer), { 10 }, { 1 })
      Dim value As Integer = 2
      ' Assign values.
      For ctr As Integer = 0 To values.Length - 1
         values(ctr) = value
         value *= 2
      Next
      
      ' Display values.
      For ctr As Integer = 0 To values.Length - 1
         Console.Write("{0}    ", values(ctr))
      Next
   End Sub
End Module
' The example displays the following output:
'    Unhandled Exception: 
'    System.IndexOutOfRangeException: Index was outside the bounds of the array.
'       at System.Array.InternalGetReference(Void* elemRef, Int32 rank, Int32* pIndices)
'       at System.Array.SetValue(Object value, Int32 index)
'       at Microsoft.VisualBasic.CompilerServices.NewLateBinding.ObjectLateIndexSetComplex(Obje
'    ct Instance, Object[] Arguments, String[] ArgumentNames, Boolean OptimisticSet, Boolean RV
'    alueBase)
'       at Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateIndexSet(Object Instance,
'    Object[] Arguments, String[] ArgumentNames)
'       at Example.Main()
' </Snippet1>
