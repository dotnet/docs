' Visual Basic .NET Document
Option Strict On

Module modMain

   Public Sub Main()
      ' <Snippet1>
      Dim integerValue As Integer = 1216
      Dim uIntegerValue As UShort
      
      If integerValue >= UShort.MinValue And integerValue <= UShort.MaxValue Then
         uIntegerValue = CUShort(integerValue) 
         Console.WriteLine(uIntegerValue)
      Else
         Console.WriteLine("Unable to convert {0} to a UInt16t.", integerValue)   
      End If   
      ' </Snippet1>
   End Sub
End Module

