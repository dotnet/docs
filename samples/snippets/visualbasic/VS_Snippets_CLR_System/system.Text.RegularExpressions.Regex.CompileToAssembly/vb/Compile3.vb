' Code to illustrate creating an assembly
Option Strict On

' <Snippet3>
Imports System.Collections.Generic
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Text.RegularExpressions

Module RegexCompilationTest
   Public Sub Main()
      Dim expr As RegexCompilationInfo
      Dim compilationList As New List(Of RegexCompilationInfo)
          
      ' Define regular expression to detect duplicate words
      expr = New RegexCompilationInfo("\b(?<word>\w+)\s+(\k<word>)\b", _
                 RegexOptions.IgnoreCase Or RegexOptions.CultureInvariant, _
                 "DuplicatedString", _
                 "Utilities.RegularExpressions", _
                 True)
      ' Add info object to list of objects
      compilationList.Add(expr)

      ' Define regular expression to validate format of email address
      expr = New RegexCompilationInfo("^(?("")(""[^""]+?""@)|(([0-9A-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9A-Z])@))" + _ 
                 "(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9A-Z][-\w]*[0-9A-Z]\.)+[A-Z]{2,6}))$", _
                 RegexOptions.IgnoreCase Or RegexOptions.CultureInvariant, _
                 "EmailAddress", _
                 "Utilities.RegularExpressions", _
                 True)
      ' Add info object to list of objects
      compilationList.Add(expr)

      ' Apply AssemblyTitle attribute to the new assembly
      '
      ' Define the parameter(s) of the AssemblyTitle attribute's constructor 
      Dim params() As Type = { GetType(String) }
      ' Define the assembly's title
      Dim paramValues() As Object = { "General-purpose library of compiled regular expressions" }
      ' Get the ConstructorInfo object representing the attribute's constructor
      Dim ctor As ConstructorInfo = GetType(System.Reflection.AssemblyTitleAttribute).GetConstructor(params)
      ' Create the CustomAttributeBuilder object array
      Dim attBuilder() As CustomAttributeBuilder = { New CustomAttributeBuilder(ctor, paramValues) } 
                                                         
      ' Generate assembly with compiled regular expressions
      Dim compilationArray(compilationList.Count - 1) As RegexCompilationInfo
      Dim assemName As New AssemblyName("RegexLib, Version=1.0.0.1001, Culture=neutral, PublicKeyToken=null")
      compilationList.CopyTo(compilationArray) 
      Regex.CompileToAssembly(compilationArray, assemName, attBuilder) 
   End Sub
End Module
' </Snippet3>
