Imports System
Imports System.Reflection

Public Class Example

    Public Shared Sub Main()

        ' Demonstrate the effect of the Visual Basic When keyword, which
        ' generates a Filter clause in the Try block.
        Dim e As New Example()
        Console.WriteLine()
        e.MethodBodyExample("String argument")
        e.MethodBodyExample(Nothing)

        ' Get method body information.
        Dim mi As MethodInfo = _
            GetType(Example).GetMethod("MethodBodyExample")
        Dim mb As MethodBody = mi.GetMethodBody()
        Console.WriteLine(vbCrLf & "Method: {0}", mi)

        ' Display the general information included in the 
        ' MethodBody object.
        Console.WriteLine("    Local variables are initialized: {0}", _
            mb.InitLocals)
        Console.WriteLine("    Maximum number of items on the operand stack: {0}", _
            mb.MaxStackSize)