Imports System
Imports System.Reflection
Imports Microsoft.VisualBasic

Public Class AssemblyName_GetAssemblyName
   
   Public Shared Sub Main()
      
      ' Replace the string "MyAssembly.exe" with the name of an assembly,
      ' including a path if necessary. If you do not have another assembly
      ' to use, you can use whatever name you give to this assembly.
      '
      Dim myAssemblyName As AssemblyName = AssemblyName.GetAssemblyName("MyAssembly.exe")
      Console.WriteLine(vbCrLf & "Displaying assembly information:" & vbCrLf)
      Console.WriteLine(myAssemblyName.ToString())
   End Sub 'Main 
End Class 'AssemblyName_GetAssemblyName 