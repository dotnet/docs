'<Snippet1>
Imports System
Imports System.Runtime.InteropServices
Imports System.Text

Namespace UsageLibrary

   Class NativeMethods

      Private Sub New()
      End Sub

      ' The following method definitions violate the rule.

      <DllImport("kernel32.dll", CharSet := CharSet.Unicode, _ 
         SetLastError := True)> _ 
      Friend Shared Function ExpandEnvironmentStrings _ 
         (lpSrc As String, lpDst As StringBuilder, nSize As Integer) _ 
         As Integer
      End Function

      Friend Declare Unicode Function ExpandEnvironmentStrings2 _ 
         Lib "kernel32.dll" Alias "ExpandEnvironmentStrings" _ 
         (lpSrc As String, lpDst As StringBuilder, nSize As Integer) _ 
         As Integer

   End Class

   Public Class UseNativeMethod

      Shared Sub Main()
      
         Dim environmentVariable As String = "%TEMP%"
         Dim expandedVariable As New StringBuilder(100)

         ' Call the unmanaged method.
         NativeMethods.ExpandEnvironmentStrings( _ 
            environmentVariable, _ 
            expandedVariable, _ 
            expandedVariable.Capacity)

         ' Call the unmanaged method.
         NativeMethods.ExpandEnvironmentStrings2( _ 
            environmentVariable, _ 
            expandedVariable, _ 
            expandedVariable.Capacity)

         ' Call the equivalent managed method.
         Environment.ExpandEnvironmentVariables(environmentVariable)

      End Sub

   End Class

End Namespace
'</Snippet1>
