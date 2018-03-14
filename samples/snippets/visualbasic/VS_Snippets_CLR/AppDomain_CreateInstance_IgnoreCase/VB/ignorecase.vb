Option Strict On
Option Explicit On

' <Snippet1>
Imports System
Imports System.Reflection

Module Test

   Sub Main()
      InstantiateINT32(False)	' Failed!
      InstantiateINT32(True)	' OK!
   End Sub 'Main

   Sub InstantiateINT32(ignoreCase As Boolean)
      Try
         Dim currentDomain As AppDomain = AppDomain.CurrentDomain
         Dim instance As Object = currentDomain.CreateInstanceAndUnwrap( _
            "mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", _
            "SYSTEM.INT32", _
            ignoreCase, _
            BindingFlags.Default, _
            Nothing, _
            Nothing, _
            Nothing, _
            Nothing, _
            Nothing  _
         )
         Console.WriteLine(instance.GetType())
      Catch e As TypeLoadException
         Console.WriteLine(e.Message)
      End Try
   End Sub 'InstantiateINT32

End Module 'Test
' </Snippet1>