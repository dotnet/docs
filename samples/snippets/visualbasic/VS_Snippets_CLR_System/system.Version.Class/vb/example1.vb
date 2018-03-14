' Visual Basic .NET Document
Option Strict On

' <Snippet6>
Imports System.Reflection

<Assembly:AssemblyVersionAttribute("2.0.1")>
Module Example1
   Public Sub Main()
       Dim thisAssem As Assembly = GetType(Example1).Assembly
       Dim thisAssemName As AssemblyName = thisAssem.GetName()
       
       Dim ver As Version = thisAssemName.Version
       
       Console.WriteLine("This is version {0} of {1}.", ver, thisAssemName.Name)    
   End Sub
End Module
' The example displays the following output:
'      This is version 2.0.1.0 of Example1.
' </Snippet6>
