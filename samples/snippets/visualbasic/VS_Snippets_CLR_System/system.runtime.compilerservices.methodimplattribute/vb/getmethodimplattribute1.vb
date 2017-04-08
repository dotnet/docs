' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet2>
Imports System.Reflection

Module Example
   Public Sub Main()
      ' Use reflection to get a reference to the GetCalendarName method.
      Dim assem As Assembly = Assembly.LoadFrom(".\Example.dll")
      Dim type As Type = assem.GetType("Utility")
      Dim methodInfo As MethodInfo = type.GetMethod("GetCalendarName")
      
      ' Determine whether the method has any custom attributes.
      Console.Write("Utility.GetCalendarName custom attributes:")
      Dim attribs() As Object = methodInfo.GetCustomAttributes(False)
      If attribs.Length > 0 Then
         Console.WriteLine()
         For Each attrib As Object In attribs
            Console.WriteLine("   " + attrib.ToString())   
         Next
      Else
         Console.WriteLine("   <None>")
      End If

      ' Get the method's metadata flags.
      Dim flags As MethodImplAttributes = methodInfo.GetMethodImplementationFlags()
      Console.WriteLine("Utility.GetCalendarName flags: {0}", flags.ToString())      
   End Sub
End Module
' The example displays the following output:
'     Utility.GetCalendarName custom attributes:   <None>
'     Utility.GetCalendarName flags: NoInlining
' </Snippet2>
