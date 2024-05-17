' Visual Basic .NET Document
Option Strict On

Imports System.Globalization
Imports System.Threading

Module Example
    Public Sub S1()
        ' <Snippet13>
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Request.UserLanguages(0))
        ' </Snippet13>
    End Sub
End Module


Public Class Request
   Private Shared langs(3) As String
   Public Shared ReadOnly Property UserLanguages As String()
      Get
         Return langs   
      End Get
   End Property    
End Class
