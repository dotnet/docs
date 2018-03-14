
using System;
using System.Reflection;
using System.Reflection.Emit;

class TakesSBArgumentExample

{
	
// <Snippet1>

public static void Main()
{
   // We need a blank OpCode object for reference when calling FieldInfo.GetValue().

   OpCode blankOpCode = new OpCode(); 

   Type myOpCodesType = Type.GetType("System.Reflection.Emit.OpCodes");
   FieldInfo[] listOfOpCodes = myOpCodesType.GetFields();

   Console.WriteLine("Which OpCodes take single-byte arguments?");
   Console.WriteLine("-----------------------------------------");

   // Now, let's reflect on each FieldInfo and create an instance of the OpCode it represents.

   foreach (FieldInfo opCodeFI in listOfOpCodes)
   {
	object theOpCode = opCodeFI.GetValue(blankOpCode);
	
	Console.WriteLine("{0}: {1}", opCodeFI.Name, 
			  OpCodes.TakesSingleByteArgument((OpCode)theOpCode).ToString());
   }

}

// </Snippet1>

}
