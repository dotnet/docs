' <Snippet5>
Imports System.Reflection

Public Module Example
   Public Sub Main()
      ' Get the assembly from a known type in that assembly.
      Dim t As Type = GetType(Example)
      Dim assemFromType As Assembly = t.Assembly
      Console.WriteLine("Assembly that contains Example:")
      Console.WriteLine("   {0}", assemFromType.FullName)
      Console.WriteLine()
      
      ' Get the currently executing assembly.
      Dim currentAssem As Assembly = Assembly.GetExecutingAssembly()
      Console.WriteLine("Currently executing assembly:")
      Console.WriteLine("   {0}", currentAssem.FullName)
      Console.WriteLine()
      
      Console.WriteLine("The two Assembly objects are equal: {0}",
                        assemFromType.Equals(currentAssem))
   End Sub
End Module
' The example displays the following output:
'    Assembly that contains Example:
'       GetExecutingAssembly1, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
'
'    Currently executing assembly:
'       GetExecutingAssembly1, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
'
'    The two Assembly objects are equal: True
' </Snippet5>
