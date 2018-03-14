// <Snippet1>
using System;
using System.Reflection;
using System.Reflection.Emit;

public class Example
{
   public static void Main()
   {
      OpCode op = OpCodes.Add;
      foreach (var prp in op.GetType().GetProperties())
         Console.WriteLine("{0} ({1}): {2}", prp.Name, 
                           prp.PropertyType.Name, prp.GetValue(op));
   }
}
// The example displays the following output:
//       OperandType (OperandType): InlineNone
//       FlowControl (FlowControl): Next
//       OpCodeType (OpCodeType): Primitive
//       StackBehaviourPop (StackBehaviour): Pop1_pop1
//       StackBehaviourPush (StackBehaviour): Push1
//       Size (Int32): 1
//       Value (Int16): 88
//       Name (String): add
// </Snippet1>

