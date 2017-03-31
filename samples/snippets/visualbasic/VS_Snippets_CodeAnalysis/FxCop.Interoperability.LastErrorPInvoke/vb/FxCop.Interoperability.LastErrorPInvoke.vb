'<Snippet1>
Imports System
Imports System.Runtime.InteropServices
Imports System.Text

Namespace InteroperabilityLibrary

   Class NativeMethods

      Private Sub New()
      End Sub

      ' Violates rule UseManagedEquivalentsOfWin32Api.
      Friend Declare Auto Function _
         ExpandEnvironmentStrings Lib "kernel32.dll" _ 
         (lpSrc As String, lpDst As StringBuilder, nSize As Integer) _ 
         As Integer

   End Class

   Public Class UseNativeMethod

      Dim environmentVariable As String = "%TEMP%"
      Dim expandedVariable As StringBuilder

      Sub ViolateRule()
      
         expandedVariable = New StringBuilder(100)

         If NativeMethods.ExpandEnvironmentStrings( _ 
            environmentVariable, _ 
            expandedVariable, _ 
            expandedVariable.Capacity) = 0

            ' Violates rule CallGetLastErrorImmediatelyAfterPInvoke.
            Console.Error.WriteLine(Marshal.GetLastWin32Error())
         Else
            Console.WriteLine(expandedVariable)
         End If

      End Sub

      Sub SatisfyRule()
      
         expandedVariable = New StringBuilder(100)

         If NativeMethods.ExpandEnvironmentStrings( _ 
            environmentVariable, _ 
            expandedVariable, _ 
            expandedVariable.Capacity) = 0
          
            ' Satisfies rule CallGetLastErrorImmediatelyAfterPInvoke.
            Dim lastError As Integer = Marshal.GetLastWin32Error()
            Console.Error.WriteLine(lastError)
         Else
            Console.WriteLine(expandedVariable)
         End If

      End Sub

   End Class

End Namespace
'</Snippet1>
