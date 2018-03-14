' Visual Basic .NET Document
Option Strict On

' <Snippet14>
Imports System.Runtime.CompilerServices

<Assembly: CLSCompliant(True)>
 
Public Class ErrorClass : Inherits Exception
   Dim msg As String
   
   Public Sub New(errorMessage As String)
      msg = errorMessage
   End Sub
   
   Public Overrides ReadOnly Property Message As String
      Get
         Return msg
      End Get   
   End Property
End Class

Public Module StringUtilities
   <Extension()> Public Function SplitString(value As String, index As Integer) As String()
      If index < 0 Or index > value.Length Then
         Dim BadIndex As New ErrorClass("The index is not within the string.")
         Throw BadIndex
      End If
      Dim retVal() As String = { value.Substring(0, index - 1), 
                                 value.Substring(index) }
      Return retVal
   End Function
End Module
' </Snippet14>



Module Example
   Public Sub Main()

   End Sub
End Module

