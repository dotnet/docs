
Imports System
Imports System.Reflection
Imports System.Reflection.Emit

 _

Class TakesSBArgumentExample
   
   
   
   ' <Snippet1>

   Public Shared Sub Main()

      ' We need a blank OpCode object for reference when calling FieldInfo.GetValue().

      Dim blankOpCode As New OpCode()
      
      Dim myOpCodesType As Type = Type.GetType("System.Reflection.Emit.OpCodes")
      Dim listOfOpCodes As FieldInfo() = myOpCodesType.GetFields()
      
      Console.WriteLine("Which OpCodes take single-byte arguments?")
      Console.WriteLine("-----------------------------------------")
      
      ' Now, let's reflect on each FieldInfo and create an instance of the OpCode it represents.
      Dim opCodeFI As FieldInfo
      For Each opCodeFI In  listOfOpCodes
         Dim theOpCode As Object = opCodeFI.GetValue(blankOpCode)
         
         Console.WriteLine("{0}: {1}", opCodeFI.Name, _
			   OpCodes.TakesSingleByteArgument(CType(theOpCode, OpCode)).ToString())
      Next opCodeFI

   End Sub 'Main

   ' </Snippet1>  

End Class 'TakesSBArgumentExample 

