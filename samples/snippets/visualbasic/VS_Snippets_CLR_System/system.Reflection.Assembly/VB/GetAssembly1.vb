Option Strict On
' <Snippet12>
Imports System.Reflection

Module Example
   Public Sub Main()
      ' Get a Type object.
      Dim t As Type = GetType(Integer)
      ' Instantiate an Assembly class to the assembly housing the Integer type.
      Dim assem As Assembly = Assembly.GetAssembly(t)
      ' Display the name of the assembly.
      Console.WriteLine("Name: {0}", assem.FullName)
      ' Get the location of the assembly using the file: protocol.
      Console.WriteLine("CodeBase: {0}", assem.CodeBase)
   End Sub
End Module
' The example displays output like the following:
'    Name: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
'    CodeBase: file:'/C:/Windows/Microsoft.NET/Framework64/v4.0.30319/mscorlib.dll
' </Snippet12>