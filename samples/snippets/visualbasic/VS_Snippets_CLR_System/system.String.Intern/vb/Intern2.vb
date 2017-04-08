' Visual Basic .NET Document
Option Strict On

Imports System
Imports System.Text

<Assembly: CLSCompliant(True)>
Module modMain
   Public Sub Main()
      ' <Snippet2>
		Dim str1 As String = String.Empty
		Dim str2 As String = String.Empty

		Dim sb As StringBuilder = New StringBuilder().Append(String.Empty)
		str2 = String.Intern(sb.ToString())	
		
		If CObj(str1) Is CObj(str2) Then
			Console.WriteLine("The strings are equal.")
		Else
			Console.WriteLine("The strings are not equal.")
		End If	
		' </Snippet2>	
   End Sub
End Module

