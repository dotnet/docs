' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Reflection
Imports System.Reflection.Emit

Module Example
   Public Sub Main()
      Dim op As OpCode = OpCodes.Add
      For Each prp In op.GetType().GetProperties()
         Console.WriteLine("{0} ({1}): {2}", prp.Name, 
                           prp.PropertyType.Name, prp.GetValue(op))
      Next
   End Sub
End Module
' The example displays the following output:
'       OperandType (OperandType): InlineNone
'       FlowControl (FlowControl): Next
'       OpCodeType (OpCodeType): Primitive
'       StackBehaviourPop (StackBehaviour): Pop1_pop1
'       StackBehaviourPush (StackBehaviour): Push1
'       Size (Int32): 1
'       Value (Int16): 88
'       Name (String): add
' </Snippet1>
