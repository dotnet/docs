' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization
Imports System.Reflection
Imports System.Resources
Imports System.Threading

' <Snippet2>
<Assembly:NeutralResourcesLanguageAttribute("en")>
' </Snippet2>

Public Class StringLibrary
   Public Function GetGreeting() As String
      Dim rm As New ResourceManager("Strings", _
                                    Assembly.GetAssembly(GetType(StringLibrary)))
      Dim greeting As String = rm.GetString("Greeting")
      Return greeting
   End Function
End Class
' </Snippet1>

