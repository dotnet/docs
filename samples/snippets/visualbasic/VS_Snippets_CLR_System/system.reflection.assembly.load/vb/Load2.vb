' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Reflection

Module Example
   Public Sub Main()
      Dim fullName As String = "sysglobl, Version=4.0.0.0, Culture=neutral, " +
                               "PublicKeyToken=b03f5f7f11d50a3a, processor architecture=MSIL"
      Dim an As New AssemblyName(fullName)
      Dim assem As Assembly = Assembly.Load(an)
      Console.WriteLine("Public types in assembly {0}:", assem.FullName)
      For Each t As Type in assem.GetTypes()
         If t.IsPublic Then Console.WriteLine("   {0}", t.FullName)
      Next
   End Sub
End Module
' The example displays the following output:
'   Public types in assembly sysglobl, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a:
'      System.Globalization.CultureAndRegionInfoBuilder
'      System.Globalization.CultureAndRegionModifiers
' </Snippet2>
